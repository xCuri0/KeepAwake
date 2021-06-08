using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeepAwake
{
    public partial class Form1 : Form
    {

        RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern ExecutionState SetThreadExecutionState(ExecutionState esFlags);

        [FlagsAttribute]
        private enum ExecutionState : uint
        {
            EsAwaymodeRequired = 0x00000040,
            EsContinuous = 0x80000000,
            EsDisplayRequired = 0x00000002,
            EsSystemRequired = 0x00000001
        }

        public Form1()
        {
            InitializeComponent();

            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1 && args[1] == "-tray") {
                Hide();
                ShowInTaskbar = false;
                WindowState = FormWindowState.Minimized;
                notifyIcon.Visible = true;
            }

            try
            {
                foreach (string item in File.ReadAllLines(Path.GetDirectoryName(Application.ExecutablePath) + "\\KeepAwake.dat"))
                {
                    AwakePrograms.Items.Add(item);
                }
            }
            catch (FileNotFoundException)
            { }
        }

        private void MonitorLoop()
        {
            Process[] processList;

            try
            {
                while (true)
                {
                    bool found = false;
                    processList = Process.GetProcesses();
                    foreach (var process in processList)
                    {
                        try
                        {
                            if (AwakePrograms.Items.IndexOf(process.MainModule.FileName.ToLower()) != -1)
                            {
                                found = true;
                                // Prevent sleep
                                SetThreadExecutionState(ExecutionState.EsContinuous | ExecutionState.EsSystemRequired);
                                if (!Active.Checked)
                                    Invoke(new Action(() =>
                                    {
                                        Active.Checked = true;
                                        Active.Update();
                                    }));
                                }
                        }
                        catch (Exception ex)
                        {
                            if (ex is Win32Exception || ex is InvalidOperationException)
                                continue;
                            throw;
                        }
                        System.Threading.Thread.Sleep(100);
                    }
                    if (!found)
                    {
                        // Allow sleep
                        SetThreadExecutionState(ExecutionState.EsContinuous);
                        Invoke(new Action(() =>
                        {
                            Active.Checked = false;
                            Active.Update();
                        }));
                    }
                }
            }
            catch (ObjectDisposedException)
            {
                return;
            }
        }
        private void FormLoad(object sender, EventArgs e)
        {
            notifyIcon.Icon = SystemIcons.Application;

            Startup.Checked = rk.GetValue("KeepAwake") != null;
            Startup.Update();

            Task.Run((Action)MonitorLoop);
        }

        private void SaveConfig()
        {
            List<string> wakePrograms = new List<string>();
            foreach (var program in AwakePrograms.Items)
                wakePrograms.Add(program.ToString());

            File.WriteAllLines(Path.GetDirectoryName(Application.ExecutablePath) + "\\KeepAwake.dat", wakePrograms.ToArray());
        }

        private void Add_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Executeable|*.exe";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (AwakePrograms.Items.IndexOf(openFileDialog.FileName.ToLower()) != -1)
                        return;

                    AwakePrograms.Items.Add(openFileDialog.FileName.ToLower());
                    SaveConfig();
                }
            }
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            AwakePrograms.Items.RemoveAt(AwakePrograms.SelectedIndex);
            SaveConfig();
        }

        private void Startup_CheckedChanged(object sender, EventArgs e)
        {
            if (Startup.Checked)
            {
                rk.SetValue("KeepAwake", Application.ExecutablePath + " -tray");
            }
            else
            {
                rk.DeleteValue("KeepAwake", false);
            }
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                ShowInTaskbar = false;
                notifyIcon.Visible = true;
            }
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            notifyIcon.Visible = false;
        }
    }
}
