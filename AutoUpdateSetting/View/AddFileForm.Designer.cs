namespace AutoUpdateSetting
{
    partial class AddFileForm
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
            this.components = new System.ComponentModel.Container();
            this.buttonBrowseFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBoxAdditem = new System.Windows.Forms.PictureBox();
            this.pictureBoxUploadFiles = new System.Windows.Forms.PictureBox();
            this.textBoxPathFile = new System.Windows.Forms.TextBox();
            this.buttonBrowseServer = new System.Windows.Forms.Button();
            this.textBoxDirectory = new System.Windows.Forms.TextBox();
            this.textBoxFileVersion = new System.Windows.Forms.TextBox();
            this.fileDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listBoxItem = new System.Windows.Forms.ListBox();
            this.pictureBoxBackground = new System.Windows.Forms.PictureBox();
            this.labelHeader = new System.Windows.Forms.Label();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            this.labelFile = new System.Windows.Forms.Label();
            this.labelFileVersion = new System.Windows.Forms.Label();
            this.labelDirectory = new System.Windows.Forms.Label();
            this.labelFileName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAdditem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUploadFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBrowseFile
            // 
            this.buttonBrowseFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.buttonBrowseFile.ForeColor = System.Drawing.Color.Black;
            this.buttonBrowseFile.Location = new System.Drawing.Point(266, 109);
            this.buttonBrowseFile.Name = "buttonBrowseFile";
            this.buttonBrowseFile.Size = new System.Drawing.Size(125, 27);
            this.buttonBrowseFile.TabIndex = 1;
            this.buttonBrowseFile.Text = "Browse Local";
            this.buttonBrowseFile.UseVisualStyleBackColor = true;
            this.buttonBrowseFile.Click += new System.EventHandler(this.ButtonBrowseFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBoxAdditem
            // 
            this.pictureBoxAdditem.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxAdditem.Image = global::AutoUpdateSetting.Properties.Resources.add_file;
            this.pictureBoxAdditem.Location = new System.Drawing.Point(15, 245);
            this.pictureBoxAdditem.Name = "pictureBoxAdditem";
            this.pictureBoxAdditem.Size = new System.Drawing.Size(226, 68);
            this.pictureBoxAdditem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxAdditem.TabIndex = 2;
            this.pictureBoxAdditem.TabStop = false;
            this.pictureBoxAdditem.Click += new System.EventHandler(this.PictureBoxAdditem_Click);
            this.pictureBoxAdditem.MouseLeave += new System.EventHandler(this.PictureBoxAdditem_MouseLeave);
            this.pictureBoxAdditem.MouseHover += new System.EventHandler(this.PictureBoxAdditem_MouseHover);
            // 
            // pictureBoxUploadFiles
            // 
            this.pictureBoxUploadFiles.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxUploadFiles.Image = global::AutoUpdateSetting.Properties.Resources.upload_files;
            this.pictureBoxUploadFiles.Location = new System.Drawing.Point(423, 245);
            this.pictureBoxUploadFiles.Name = "pictureBoxUploadFiles";
            this.pictureBoxUploadFiles.Size = new System.Drawing.Size(225, 68);
            this.pictureBoxUploadFiles.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxUploadFiles.TabIndex = 2;
            this.pictureBoxUploadFiles.TabStop = false;
            this.pictureBoxUploadFiles.Click += new System.EventHandler(this.PictureBoxSaveToDbx_Click);
            this.pictureBoxUploadFiles.MouseLeave += new System.EventHandler(this.PictureBoxUploadFiles_MouseLeave);
            this.pictureBoxUploadFiles.MouseHover += new System.EventHandler(this.PictureBoxUploadFiles_MouseHover);
            // 
            // textBoxPathFile
            // 
            this.textBoxPathFile.BackColor = System.Drawing.Color.Silver;
            this.textBoxPathFile.Enabled = false;
            this.textBoxPathFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBoxPathFile.Location = new System.Drawing.Point(15, 79);
            this.textBoxPathFile.Name = "textBoxPathFile";
            this.textBoxPathFile.Size = new System.Drawing.Size(376, 26);
            this.textBoxPathFile.TabIndex = 2;
            // 
            // buttonBrowseServer
            // 
            this.buttonBrowseServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.buttonBrowseServer.ForeColor = System.Drawing.Color.Black;
            this.buttonBrowseServer.Location = new System.Drawing.Point(135, 109);
            this.buttonBrowseServer.Name = "buttonBrowseServer";
            this.buttonBrowseServer.Size = new System.Drawing.Size(125, 27);
            this.buttonBrowseServer.TabIndex = 3;
            this.buttonBrowseServer.Text = "Browse Server";
            this.buttonBrowseServer.UseVisualStyleBackColor = true;
            this.buttonBrowseServer.Click += new System.EventHandler(this.ButtonBrowseServer_Click);
            // 
            // textBoxDirectory
            // 
            this.textBoxDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBoxDirectory.Location = new System.Drawing.Point(15, 207);
            this.textBoxDirectory.Name = "textBoxDirectory";
            this.textBoxDirectory.Size = new System.Drawing.Size(376, 26);
            this.textBoxDirectory.TabIndex = 0;
            // 
            // textBoxFileVersion
            // 
            this.textBoxFileVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBoxFileVersion.Location = new System.Drawing.Point(15, 155);
            this.textBoxFileVersion.Name = "textBoxFileVersion";
            this.textBoxFileVersion.Size = new System.Drawing.Size(376, 26);
            this.textBoxFileVersion.TabIndex = 0;
            // 
            // fileDataBindingSource
            // 
            this.fileDataBindingSource.AllowNew = false;
            this.fileDataBindingSource.DataSource = typeof(AutoUpdateSetting.Model.FileData);
            // 
            // listBoxItem
            // 
            this.listBoxItem.DataSource = this.fileDataBindingSource;
            this.listBoxItem.DisplayMember = "Name";
            this.listBoxItem.FormattingEnabled = true;
            this.listBoxItem.Location = new System.Drawing.Point(423, 79);
            this.listBoxItem.Name = "listBoxItem";
            this.listBoxItem.Size = new System.Drawing.Size(278, 160);
            this.listBoxItem.TabIndex = 6;
            this.listBoxItem.ValueMember = "Name";
            // 
            // pictureBoxBackground
            // 
            this.pictureBoxBackground.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxBackground.Image = global::AutoUpdateSetting.Properties.Resources.background_blue_01;
            this.pictureBoxBackground.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxBackground.Name = "pictureBoxBackground";
            this.pictureBoxBackground.Size = new System.Drawing.Size(717, 329);
            this.pictureBoxBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBackground.TabIndex = 10;
            this.pictureBoxBackground.TabStop = false;
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.BackColor = System.Drawing.Color.Transparent;
            this.labelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(12, 9);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(236, 39);
            this.labelHeader.TabIndex = 11;
            this.labelHeader.Text = "Manage Files";
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxClose.Image = global::AutoUpdateSetting.Properties.Resources.close_03;
            this.pictureBoxClose.Location = new System.Drawing.Point(642, 1);
            this.pictureBoxClose.Name = "pictureBoxClose";
            this.pictureBoxClose.Size = new System.Drawing.Size(59, 51);
            this.pictureBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxClose.TabIndex = 12;
            this.pictureBoxClose.TabStop = false;
            this.pictureBoxClose.Click += new System.EventHandler(this.PictureBoxClose_Click);
            // 
            // labelFile
            // 
            this.labelFile.AutoSize = true;
            this.labelFile.BackColor = System.Drawing.Color.Transparent;
            this.labelFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelFile.ForeColor = System.Drawing.Color.White;
            this.labelFile.Location = new System.Drawing.Point(15, 54);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(45, 24);
            this.labelFile.TabIndex = 13;
            this.labelFile.Text = "File";
            // 
            // labelFileVersion
            // 
            this.labelFileVersion.AutoSize = true;
            this.labelFileVersion.BackColor = System.Drawing.Color.Transparent;
            this.labelFileVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelFileVersion.ForeColor = System.Drawing.Color.White;
            this.labelFileVersion.Location = new System.Drawing.Point(15, 130);
            this.labelFileVersion.Name = "labelFileVersion";
            this.labelFileVersion.Size = new System.Drawing.Size(123, 24);
            this.labelFileVersion.TabIndex = 14;
            this.labelFileVersion.Text = "File Version";
            // 
            // labelDirectory
            // 
            this.labelDirectory.AutoSize = true;
            this.labelDirectory.BackColor = System.Drawing.Color.Transparent;
            this.labelDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelDirectory.ForeColor = System.Drawing.Color.White;
            this.labelDirectory.Location = new System.Drawing.Point(15, 182);
            this.labelDirectory.Name = "labelDirectory";
            this.labelDirectory.Size = new System.Drawing.Size(93, 24);
            this.labelDirectory.TabIndex = 14;
            this.labelDirectory.Text = "Directory";
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.BackColor = System.Drawing.Color.Transparent;
            this.labelFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelFileName.ForeColor = System.Drawing.Color.White;
            this.labelFileName.Location = new System.Drawing.Point(424, 54);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(106, 24);
            this.labelFileName.TabIndex = 13;
            this.labelFileName.Text = "File Name";
            // 
            // AddFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(717, 329);
            this.Controls.Add(this.listBoxItem);
            this.Controls.Add(this.textBoxDirectory);
            this.Controls.Add(this.labelDirectory);
            this.Controls.Add(this.labelFileVersion);
            this.Controls.Add(this.textBoxFileVersion);
            this.Controls.Add(this.labelFileName);
            this.Controls.Add(this.labelFile);
            this.Controls.Add(this.buttonBrowseFile);
            this.Controls.Add(this.pictureBoxClose);
            this.Controls.Add(this.textBoxPathFile);
            this.Controls.Add(this.buttonBrowseServer);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.pictureBoxUploadFiles);
            this.Controls.Add(this.pictureBoxAdditem);
            this.Controls.Add(this.pictureBoxBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddFileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddFileForm";
            this.Load += new System.EventHandler(this.AddFileForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAdditem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUploadFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonBrowseFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBoxAdditem;
        private System.Windows.Forms.PictureBox pictureBoxUploadFiles;
        private System.Windows.Forms.TextBox textBoxDirectory;
        private System.Windows.Forms.TextBox textBoxFileVersion;
        private System.Windows.Forms.TextBox textBoxPathFile;
        private System.Windows.Forms.ListBox listBoxItem;
        private System.Windows.Forms.BindingSource fileDataBindingSource;
        private System.Windows.Forms.Button buttonBrowseServer;
        private System.Windows.Forms.PictureBox pictureBoxBackground;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.PictureBox pictureBoxClose;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.Label labelFileVersion;
        private System.Windows.Forms.Label labelDirectory;
        private System.Windows.Forms.Label labelFileName;
    }
}