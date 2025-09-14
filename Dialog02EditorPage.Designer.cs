namespace AA2PersonalityDisorder
{
    partial class Dialog02EditorPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.dialogSearchButton = new System.Windows.Forms.Button();
            this.dialogSearchInput = new System.Windows.Forms.TextBox();
            this.dialogConditionsGridView = new System.Windows.Forms.DataGridView();
            this.ItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisplayText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exportLstFileButton = new System.Windows.Forms.Button();
            this.dialogGroupPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.dialogGroupsGridView = new System.Windows.Forms.DataGridView();
            this.dialog02Textbox = new System.Windows.Forms.TextBox();
            this.audioPreviewGroupBox = new System.Windows.Forms.GroupBox();
            this.audioPlayButton = new System.Windows.Forms.Button();
            this.volumeTrackBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dialogConditionsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dialogGroupsGridView)).BeginInit();
            this.audioPreviewGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dialogSearchButton);
            this.panel1.Controls.Add(this.dialogSearchInput);
            this.panel1.Controls.Add(this.dialogConditionsGridView);
            this.panel1.Controls.Add(this.exportLstFileButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 862);
            this.panel1.TabIndex = 0;
            // 
            // dialogSearchButton
            // 
            this.dialogSearchButton.Location = new System.Drawing.Point(3, 66);
            this.dialogSearchButton.Name = "dialogSearchButton";
            this.dialogSearchButton.Size = new System.Drawing.Size(75, 23);
            this.dialogSearchButton.TabIndex = 2;
            this.dialogSearchButton.Text = "Search";
            this.dialogSearchButton.UseVisualStyleBackColor = true;
            this.dialogSearchButton.Click += new System.EventHandler(this.dialogSearchButton_Click);
            // 
            // dialogSearchInput
            // 
            this.dialogSearchInput.Location = new System.Drawing.Point(84, 68);
            this.dialogSearchInput.Name = "dialogSearchInput";
            this.dialogSearchInput.Size = new System.Drawing.Size(253, 20);
            this.dialogSearchInput.TabIndex = 1;
            this.dialogSearchInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dialogSearchInput_KeyPress);
            // 
            // dialogConditionsGridView
            // 
            this.dialogConditionsGridView.AllowUserToAddRows = false;
            this.dialogConditionsGridView.AllowUserToDeleteRows = false;
            this.dialogConditionsGridView.AllowUserToResizeRows = false;
            this.dialogConditionsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dialogConditionsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dialogConditionsGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dialogConditionsGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dialogConditionsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dialogConditionsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemId,
            this.DisplayText});
            this.dialogConditionsGridView.Location = new System.Drawing.Point(0, 94);
            this.dialogConditionsGridView.MultiSelect = false;
            this.dialogConditionsGridView.Name = "dialogConditionsGridView";
            this.dialogConditionsGridView.ReadOnly = true;
            this.dialogConditionsGridView.RowHeadersVisible = false;
            this.dialogConditionsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dialogConditionsGridView.Size = new System.Drawing.Size(340, 768);
            this.dialogConditionsGridView.TabIndex = 1;
            this.dialogConditionsGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dialogConditionsGridView_CellFormatting);
            this.dialogConditionsGridView.SelectionChanged += new System.EventHandler(this.dialogConditionsGridView_SelectionChanged);
            // 
            // ItemId
            // 
            this.ItemId.DataPropertyName = "ItemId";
            this.ItemId.FillWeight = 30.45685F;
            this.ItemId.HeaderText = "ID";
            this.ItemId.Name = "ItemId";
            this.ItemId.ReadOnly = true;
            this.ItemId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DisplayText
            // 
            this.DisplayText.DataPropertyName = "DisplayText";
            this.DisplayText.FillWeight = 169.5432F;
            this.DisplayText.HeaderText = "Condition";
            this.DisplayText.Name = "DisplayText";
            this.DisplayText.ReadOnly = true;
            this.DisplayText.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // exportLstFileButton
            // 
            this.exportLstFileButton.Location = new System.Drawing.Point(3, 3);
            this.exportLstFileButton.Name = "exportLstFileButton";
            this.exportLstFileButton.Size = new System.Drawing.Size(334, 50);
            this.exportLstFileButton.TabIndex = 0;
            this.exportLstFileButton.Text = "Export Current LST File";
            this.exportLstFileButton.UseVisualStyleBackColor = true;
            this.exportLstFileButton.Click += new System.EventHandler(this.exportDialogLstFileButton_Click);
            // 
            // dialogGroupPropertyGrid
            // 
            this.dialogGroupPropertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dialogGroupPropertyGrid.BackColor = System.Drawing.SystemColors.Control;
            this.dialogGroupPropertyGrid.CommandsBackColor = System.Drawing.SystemColors.Control;
            this.dialogGroupPropertyGrid.Location = new System.Drawing.Point(996, 147);
            this.dialogGroupPropertyGrid.Name = "dialogGroupPropertyGrid";
            this.dialogGroupPropertyGrid.Size = new System.Drawing.Size(351, 712);
            this.dialogGroupPropertyGrid.TabIndex = 3;
            // 
            // dialogGroupsGridView
            // 
            this.dialogGroupsGridView.AllowUserToAddRows = false;
            this.dialogGroupsGridView.AllowUserToDeleteRows = false;
            this.dialogGroupsGridView.AllowUserToResizeRows = false;
            this.dialogGroupsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dialogGroupsGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dialogGroupsGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dialogGroupsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dialogGroupsGridView.Location = new System.Drawing.Point(346, 3);
            this.dialogGroupsGridView.MultiSelect = false;
            this.dialogGroupsGridView.Name = "dialogGroupsGridView";
            this.dialogGroupsGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dialogGroupsGridView.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dialogGroupsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dialogGroupsGridView.Size = new System.Drawing.Size(1001, 138);
            this.dialogGroupsGridView.TabIndex = 3;
            this.dialogGroupsGridView.DataSourceChanged += new System.EventHandler(this.dialogGroupsGridView_DataSourceChanged);
            this.dialogGroupsGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dialogGroupsGridView_CellFormatting);
            this.dialogGroupsGridView.SelectionChanged += new System.EventHandler(this.dialogGroupsGridView_SelectionChanged);
            // 
            // dialog02Textbox
            // 
            this.dialog02Textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dialog02Textbox.Location = new System.Drawing.Point(346, 173);
            this.dialog02Textbox.Multiline = true;
            this.dialog02Textbox.Name = "dialog02Textbox";
            this.dialog02Textbox.Size = new System.Drawing.Size(644, 73);
            this.dialog02Textbox.TabIndex = 6;
            // 
            // audioPreviewGroupBox
            // 
            this.audioPreviewGroupBox.Controls.Add(this.label1);
            this.audioPreviewGroupBox.Controls.Add(this.volumeTrackBar);
            this.audioPreviewGroupBox.Controls.Add(this.audioPlayButton);
            this.audioPreviewGroupBox.Location = new System.Drawing.Point(346, 252);
            this.audioPreviewGroupBox.Name = "audioPreviewGroupBox";
            this.audioPreviewGroupBox.Size = new System.Drawing.Size(275, 155);
            this.audioPreviewGroupBox.TabIndex = 7;
            this.audioPreviewGroupBox.TabStop = false;
            this.audioPreviewGroupBox.Text = "Audio Preview";
            // 
            // audioPlayButton
            // 
            this.audioPlayButton.Location = new System.Drawing.Point(6, 32);
            this.audioPlayButton.Name = "audioPlayButton";
            this.audioPlayButton.Size = new System.Drawing.Size(73, 45);
            this.audioPlayButton.TabIndex = 0;
            this.audioPlayButton.Text = "Play";
            this.audioPlayButton.UseVisualStyleBackColor = true;
            this.audioPlayButton.Click += new System.EventHandler(this.audioPlayButton_Click);
            // 
            // volumeTrackBar
            // 
            this.volumeTrackBar.Location = new System.Drawing.Point(85, 32);
            this.volumeTrackBar.Name = "volumeTrackBar";
            this.volumeTrackBar.Size = new System.Drawing.Size(105, 45);
            this.volumeTrackBar.TabIndex = 1;
            this.volumeTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.volumeTrackBar.Value = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // Dialog02EditorPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.audioPreviewGroupBox);
            this.Controls.Add(this.dialog02Textbox);
            this.Controls.Add(this.dialogGroupsGridView);
            this.Controls.Add(this.dialogGroupPropertyGrid);
            this.Controls.Add(this.panel1);
            this.Name = "Dialog02EditorPage";
            this.Size = new System.Drawing.Size(1350, 862);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dialogConditionsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dialogGroupsGridView)).EndInit();
            this.audioPreviewGroupBox.ResumeLayout(false);
            this.audioPreviewGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button exportLstFileButton;
        private System.Windows.Forms.DataGridView dialogConditionsGridView;
        private System.Windows.Forms.TextBox dialogSearchInput;
        private System.Windows.Forms.Button dialogSearchButton;
        private System.Windows.Forms.PropertyGrid dialogGroupPropertyGrid;
        private System.Windows.Forms.DataGridView dialogGroupsGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayText;
        private System.Windows.Forms.TextBox dialog02Textbox;
        private System.Windows.Forms.GroupBox audioPreviewGroupBox;
        private System.Windows.Forms.TrackBar volumeTrackBar;
        private System.Windows.Forms.Button audioPlayButton;
        private System.Windows.Forms.Label label1;
    }
}
