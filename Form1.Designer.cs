
namespace KeepAwake
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AwakePrograms = new System.Windows.Forms.ListBox();
            this.Add = new System.Windows.Forms.Button();
            this.Remove = new System.Windows.Forms.Button();
            this.Startup = new System.Windows.Forms.CheckBox();
            this.Active = new System.Windows.Forms.CheckBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // AwakePrograms
            // 
            this.AwakePrograms.FormattingEnabled = true;
            this.AwakePrograms.HorizontalScrollbar = true;
            this.AwakePrograms.ItemHeight = 15;
            this.AwakePrograms.Location = new System.Drawing.Point(12, 12);
            this.AwakePrograms.Name = "AwakePrograms";
            this.AwakePrograms.Size = new System.Drawing.Size(243, 214);
            this.AwakePrograms.TabIndex = 0;
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(261, 12);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 23);
            this.Add.TabIndex = 1;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Remove
            // 
            this.Remove.Location = new System.Drawing.Point(261, 41);
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(75, 23);
            this.Remove.TabIndex = 2;
            this.Remove.Text = "Remove";
            this.Remove.UseVisualStyleBackColor = true;
            this.Remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // Startup
            // 
            this.Startup.AutoSize = true;
            this.Startup.Location = new System.Drawing.Point(261, 70);
            this.Startup.Name = "Startup";
            this.Startup.Size = new System.Drawing.Size(64, 19);
            this.Startup.TabIndex = 3;
            this.Startup.Text = "Startup";
            this.Startup.UseVisualStyleBackColor = true;
            this.Startup.CheckedChanged += new System.EventHandler(this.Startup_CheckedChanged);
            // 
            // Active
            // 
            this.Active.AutoSize = true;
            this.Active.Enabled = false;
            this.Active.Location = new System.Drawing.Point(261, 95);
            this.Active.Name = "Active";
            this.Active.Size = new System.Drawing.Size(59, 19);
            this.Active.TabIndex = 4;
            this.Active.Text = "Active";
            this.Active.UseVisualStyleBackColor = true;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Text = "KeepAwake";
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 233);
            this.Controls.Add(this.Active);
            this.Controls.Add(this.Startup);
            this.Controls.Add(this.Remove);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.AwakePrograms);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "KeepAwake";
            this.Load += new System.EventHandler(this.FormLoad);
            this.Resize += new System.EventHandler(this.Form_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox AwakePrograms;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Remove;
        private System.Windows.Forms.CheckBox Startup;
        private System.Windows.Forms.CheckBox Active;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}

