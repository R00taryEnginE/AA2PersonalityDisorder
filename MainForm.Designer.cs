
namespace AA2PersonalityDisorder
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.globalStatusStrip = new System.Windows.Forms.StatusStrip();
            this.globalStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.generalTab = new System.Windows.Forms.TabPage();
            this.projectSetupGroupBox = new System.Windows.Forms.GroupBox();
            this.loadProjectButton = new System.Windows.Forms.Button();
            this.saveProjectButton = new System.Windows.Forms.Button();
            this.filesSetupGroupBox = new System.Windows.Forms.GroupBox();
            this.audioDirTextbox = new System.Windows.Forms.TextBox();
            this.setAudioDirButton = new System.Windows.Forms.Button();
            this.open02DialogButton = new System.Windows.Forms.Button();
            this.dialog02EditorTab = new System.Windows.Forms.TabPage();
            this.dialog02DataLabel = new System.Windows.Forms.Label();
            this.dialog02EditorPage = new AA2PersonalityDisorder.Dialog02EditorPage();
            this.globalStatusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.generalTab.SuspendLayout();
            this.projectSetupGroupBox.SuspendLayout();
            this.filesSetupGroupBox.SuspendLayout();
            this.dialog02EditorTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // globalStatusStrip
            // 
            this.globalStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.globalStatusLabel});
            this.globalStatusStrip.Location = new System.Drawing.Point(0, 912);
            this.globalStatusStrip.Name = "globalStatusStrip";
            this.globalStatusStrip.Size = new System.Drawing.Size(1358, 22);
            this.globalStatusStrip.TabIndex = 0;
            this.globalStatusStrip.Text = "statusStrip1";
            // 
            // globalStatusLabel
            // 
            this.globalStatusLabel.Name = "globalStatusLabel";
            this.globalStatusLabel.Size = new System.Drawing.Size(70, 17);
            this.globalStatusLabel.Text = "Status Label";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1358, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoBackupToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // autoBackupToolStripMenuItem
            // 
            this.autoBackupToolStripMenuItem.Checked = true;
            this.autoBackupToolStripMenuItem.CheckOnClick = true;
            this.autoBackupToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoBackupToolStripMenuItem.Name = "autoBackupToolStripMenuItem";
            this.autoBackupToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.autoBackupToolStripMenuItem.Text = "Auto Backup";
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.generalTab);
            this.mainTabControl.Controls.Add(this.dialog02EditorTab);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(0, 24);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(1358, 888);
            this.mainTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.mainTabControl.TabIndex = 2;
            // 
            // generalTab
            // 
            this.generalTab.BackColor = System.Drawing.Color.Transparent;
            this.generalTab.Controls.Add(this.projectSetupGroupBox);
            this.generalTab.Controls.Add(this.filesSetupGroupBox);
            this.generalTab.Location = new System.Drawing.Point(4, 22);
            this.generalTab.Name = "generalTab";
            this.generalTab.Size = new System.Drawing.Size(1350, 862);
            this.generalTab.TabIndex = 2;
            this.generalTab.Text = "General";
            // 
            // projectSetupGroupBox
            // 
            this.projectSetupGroupBox.Controls.Add(this.loadProjectButton);
            this.projectSetupGroupBox.Controls.Add(this.saveProjectButton);
            this.projectSetupGroupBox.Location = new System.Drawing.Point(8, 3);
            this.projectSetupGroupBox.Name = "projectSetupGroupBox";
            this.projectSetupGroupBox.Size = new System.Drawing.Size(384, 88);
            this.projectSetupGroupBox.TabIndex = 2;
            this.projectSetupGroupBox.TabStop = false;
            this.projectSetupGroupBox.Text = "Project Setup";
            // 
            // loadProjectButton
            // 
            this.loadProjectButton.Location = new System.Drawing.Point(189, 19);
            this.loadProjectButton.Name = "loadProjectButton";
            this.loadProjectButton.Size = new System.Drawing.Size(177, 50);
            this.loadProjectButton.TabIndex = 1;
            this.loadProjectButton.Text = "Load Existing Project";
            this.loadProjectButton.UseVisualStyleBackColor = true;
            this.loadProjectButton.Click += new System.EventHandler(this.loadProjectButton_Click);
            // 
            // saveProjectButton
            // 
            this.saveProjectButton.Location = new System.Drawing.Point(6, 19);
            this.saveProjectButton.Name = "saveProjectButton";
            this.saveProjectButton.Size = new System.Drawing.Size(177, 50);
            this.saveProjectButton.TabIndex = 0;
            this.saveProjectButton.Text = "Save Project";
            this.saveProjectButton.UseVisualStyleBackColor = true;
            this.saveProjectButton.Click += new System.EventHandler(this.saveProjectButton_Click);
            // 
            // filesSetupGroupBox
            // 
            this.filesSetupGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.filesSetupGroupBox.Controls.Add(this.dialog02DataLabel);
            this.filesSetupGroupBox.Controls.Add(this.audioDirTextbox);
            this.filesSetupGroupBox.Controls.Add(this.setAudioDirButton);
            this.filesSetupGroupBox.Controls.Add(this.open02DialogButton);
            this.filesSetupGroupBox.Location = new System.Drawing.Point(8, 97);
            this.filesSetupGroupBox.Name = "filesSetupGroupBox";
            this.filesSetupGroupBox.Size = new System.Drawing.Size(504, 207);
            this.filesSetupGroupBox.TabIndex = 0;
            this.filesSetupGroupBox.TabStop = false;
            this.filesSetupGroupBox.Text = "Project Files";
            // 
            // audioDirTextbox
            // 
            this.audioDirTextbox.Location = new System.Drawing.Point(163, 84);
            this.audioDirTextbox.Name = "audioDirTextbox";
            this.audioDirTextbox.ReadOnly = true;
            this.audioDirTextbox.Size = new System.Drawing.Size(310, 20);
            this.audioDirTextbox.TabIndex = 3;
            this.audioDirTextbox.Text = "Select directory";
            // 
            // setAudioDirButton
            // 
            this.setAudioDirButton.Location = new System.Drawing.Point(6, 76);
            this.setAudioDirButton.Name = "setAudioDirButton";
            this.setAudioDirButton.Size = new System.Drawing.Size(151, 35);
            this.setAudioDirButton.TabIndex = 2;
            this.setAudioDirButton.Text = "Set Audio Directory";
            this.setAudioDirButton.UseVisualStyleBackColor = true;
            this.setAudioDirButton.Click += new System.EventHandler(this.setAudioDirButton_Click);
            // 
            // open02DialogButton
            // 
            this.open02DialogButton.Location = new System.Drawing.Point(6, 35);
            this.open02DialogButton.Name = "open02DialogButton";
            this.open02DialogButton.Size = new System.Drawing.Size(151, 35);
            this.open02DialogButton.TabIndex = 0;
            this.open02DialogButton.Text = "Set 02 Dialog Data";
            this.open02DialogButton.UseVisualStyleBackColor = true;
            this.open02DialogButton.Click += new System.EventHandler(this.open02DialogButton_Click);
            // 
            // dialog02EditorTab
            // 
            this.dialog02EditorTab.Controls.Add(this.dialog02EditorPage);
            this.dialog02EditorTab.Location = new System.Drawing.Point(4, 22);
            this.dialog02EditorTab.Name = "dialog02EditorTab";
            this.dialog02EditorTab.Size = new System.Drawing.Size(1350, 862);
            this.dialog02EditorTab.TabIndex = 1;
            this.dialog02EditorTab.Text = "02 Dialog Editor";
            this.dialog02EditorTab.UseVisualStyleBackColor = true;
            // 
            // dialog02DataLabel
            // 
            this.dialog02DataLabel.AutoSize = true;
            this.dialog02DataLabel.Location = new System.Drawing.Point(163, 46);
            this.dialog02DataLabel.Name = "dialog02DataLabel";
            this.dialog02DataLabel.Size = new System.Drawing.Size(80, 13);
            this.dialog02DataLabel.TabIndex = 4;
            this.dialog02DataLabel.Text = "No data loaded";
            // 
            // dialog02EditorPage
            // 
            this.dialog02EditorPage.BackColor = System.Drawing.SystemColors.Control;
            this.dialog02EditorPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dialog02EditorPage.Location = new System.Drawing.Point(0, 0);
            this.dialog02EditorPage.Name = "dialog02EditorPage";
            this.dialog02EditorPage.Size = new System.Drawing.Size(1350, 862);
            this.dialog02EditorPage.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1358, 934);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.globalStatusStrip);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AA2 Personality Disorder";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.globalStatusStrip.ResumeLayout(false);
            this.globalStatusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mainTabControl.ResumeLayout(false);
            this.generalTab.ResumeLayout(false);
            this.projectSetupGroupBox.ResumeLayout(false);
            this.filesSetupGroupBox.ResumeLayout(false);
            this.filesSetupGroupBox.PerformLayout();
            this.dialog02EditorTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip globalStatusStrip;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoBackupToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel globalStatusLabel;
        private System.Windows.Forms.TabPage dialog02EditorTab;
        private Dialog02EditorPage dialog02EditorPage;
        private System.Windows.Forms.TabPage generalTab;
        private System.Windows.Forms.GroupBox filesSetupGroupBox;
        private System.Windows.Forms.Button open02DialogButton;
        private System.Windows.Forms.GroupBox projectSetupGroupBox;
        private System.Windows.Forms.Button saveProjectButton;
        private System.Windows.Forms.Button loadProjectButton;
        private System.Windows.Forms.TextBox audioDirTextbox;
        private System.Windows.Forms.Button setAudioDirButton;
        private System.Windows.Forms.Label dialog02DataLabel;
    }
}

