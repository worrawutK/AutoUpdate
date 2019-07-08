namespace AutoUpdateSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.labelHeader = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.pictureBoxExit = new System.Windows.Forms.PictureBox();
            this.pictureBoxManageMachines = new System.Windows.Forms.PictureBox();
            this.pictureBoxManageCellcon = new System.Windows.Forms.PictureBox();
            this.pictureBoxManageApplication = new System.Windows.Forms.PictureBox();
            this.pictureBoxManageFiles = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelVersion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxManageMachines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxManageCellcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxManageApplication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxManageFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.BackColor = System.Drawing.Color.Transparent;
            this.labelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(22, 21);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(677, 55);
            this.labelHeader.TabIndex = 3;
            this.labelHeader.Text = "Cellcon Management System";
            // 
            // panelMain
            // 
            this.panelMain.AutoScroll = true;
            this.panelMain.BackColor = System.Drawing.Color.Transparent;
            this.panelMain.Location = new System.Drawing.Point(287, 108);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(956, 719);
            this.panelMain.TabIndex = 4;
            // 
            // pictureBoxExit
            // 
            this.pictureBoxExit.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxExit.Image = global::AutoUpdateSetting.Properties.Resources.exitProgram;
            this.pictureBoxExit.Location = new System.Drawing.Point(21, 395);
            this.pictureBoxExit.Name = "pictureBoxExit";
            this.pictureBoxExit.Size = new System.Drawing.Size(246, 67);
            this.pictureBoxExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxExit.TabIndex = 2;
            this.pictureBoxExit.TabStop = false;
            this.pictureBoxExit.Click += new System.EventHandler(this.pictureBoxExit_Click);
            this.pictureBoxExit.MouseLeave += new System.EventHandler(this.pictureBoxExit_MouseLeave);
            this.pictureBoxExit.MouseHover += new System.EventHandler(this.pictureBoxExit_MouseHover);
            // 
            // pictureBoxManageMachines
            // 
            this.pictureBoxManageMachines.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxManageMachines.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxManageMachines.Image = global::AutoUpdateSetting.Properties.Resources.manage_machine;
            this.pictureBoxManageMachines.Location = new System.Drawing.Point(21, 322);
            this.pictureBoxManageMachines.Name = "pictureBoxManageMachines";
            this.pictureBoxManageMachines.Size = new System.Drawing.Size(246, 67);
            this.pictureBoxManageMachines.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxManageMachines.TabIndex = 0;
            this.pictureBoxManageMachines.TabStop = false;
            this.pictureBoxManageMachines.Click += new System.EventHandler(this.pictureBoxSettingProgramMachine_Click);
            this.pictureBoxManageMachines.MouseLeave += new System.EventHandler(this.pictureBoxSettingProgramMachine_MouseLeave);
            this.pictureBoxManageMachines.MouseHover += new System.EventHandler(this.pictureBoxSettingProgramMachine_MouseHover);
            // 
            // pictureBoxManageCellcon
            // 
            this.pictureBoxManageCellcon.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxManageCellcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxManageCellcon.Image = global::AutoUpdateSetting.Properties.Resources.manage_cellcon;
            this.pictureBoxManageCellcon.Location = new System.Drawing.Point(21, 250);
            this.pictureBoxManageCellcon.Name = "pictureBoxManageCellcon";
            this.pictureBoxManageCellcon.Size = new System.Drawing.Size(246, 66);
            this.pictureBoxManageCellcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxManageCellcon.TabIndex = 0;
            this.pictureBoxManageCellcon.TabStop = false;
            this.pictureBoxManageCellcon.Click += new System.EventHandler(this.pictureBoxRegisterProgramCellCon_Click);
            this.pictureBoxManageCellcon.MouseLeave += new System.EventHandler(this.pictureBoxRegisterProgramCellCon_MouseLeave);
            this.pictureBoxManageCellcon.MouseHover += new System.EventHandler(this.pictureBoxRegisterProgramCellCon_MouseHover);
            // 
            // pictureBoxManageApplication
            // 
            this.pictureBoxManageApplication.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxManageApplication.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxManageApplication.Image = global::AutoUpdateSetting.Properties.Resources.manage_application;
            this.pictureBoxManageApplication.Location = new System.Drawing.Point(21, 178);
            this.pictureBoxManageApplication.Name = "pictureBoxManageApplication";
            this.pictureBoxManageApplication.Size = new System.Drawing.Size(246, 66);
            this.pictureBoxManageApplication.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxManageApplication.TabIndex = 0;
            this.pictureBoxManageApplication.TabStop = false;
            this.pictureBoxManageApplication.Click += new System.EventHandler(this.pictureBoxRegisterProgram_Click);
            this.pictureBoxManageApplication.MouseLeave += new System.EventHandler(this.pictureBoxRegisterProgram_MouseLeave);
            this.pictureBoxManageApplication.MouseHover += new System.EventHandler(this.pictureBoxRegisterProgram_MouseHover);
            // 
            // pictureBoxManageFiles
            // 
            this.pictureBoxManageFiles.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxManageFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxManageFiles.Image = global::AutoUpdateSetting.Properties.Resources.manage_files;
            this.pictureBoxManageFiles.Location = new System.Drawing.Point(21, 108);
            this.pictureBoxManageFiles.Name = "pictureBoxManageFiles";
            this.pictureBoxManageFiles.Size = new System.Drawing.Size(246, 64);
            this.pictureBoxManageFiles.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxManageFiles.TabIndex = 0;
            this.pictureBoxManageFiles.TabStop = false;
            this.pictureBoxManageFiles.Click += new System.EventHandler(this.pictureBoxAddFile_Click);
            this.pictureBoxManageFiles.MouseLeave += new System.EventHandler(this.pictureBoxAddFile_MouseLeave);
            this.pictureBoxManageFiles.MouseHover += new System.EventHandler(this.pictureBoxAddFile_MouseHover);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::AutoUpdateSetting.Properties.Resources.background_blue_01;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1255, 862);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // labelVersion
            // 
            this.labelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVersion.BackColor = System.Drawing.Color.Transparent;
            this.labelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelVersion.ForeColor = System.Drawing.Color.White;
            this.labelVersion.Location = new System.Drawing.Point(1054, 837);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(189, 16);
            this.labelVersion.TabIndex = 5;
            this.labelVersion.Text = "Version";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 862);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.pictureBoxExit);
            this.Controls.Add(this.pictureBoxManageMachines);
            this.Controls.Add(this.pictureBoxManageCellcon);
            this.Controls.Add(this.pictureBoxManageApplication);
            this.Controls.Add(this.pictureBoxManageFiles);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cellcon Management System";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxManageMachines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxManageCellcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxManageApplication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxManageFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxManageFiles;
        private System.Windows.Forms.PictureBox pictureBoxManageApplication;
        private System.Windows.Forms.PictureBox pictureBoxManageCellcon;
        private System.Windows.Forms.PictureBox pictureBoxManageMachines;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBoxExit;
        private System.Windows.Forms.Label labelHeader;
        public System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label labelVersion;
    }
}