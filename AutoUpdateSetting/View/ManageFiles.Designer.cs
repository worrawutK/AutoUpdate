namespace AutoUpdateSetting.View
{
    partial class ManageFiles
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
            this.components = new System.ComponentModel.Container();
            this.textBoxFileVersion = new System.Windows.Forms.TextBox();
            this.buttonBrowseFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBoxPathFile = new System.Windows.Forms.TextBox();
            this.buttonBrowseServer = new System.Windows.Forms.Button();
            this.pictureBoxUploadFiles = new System.Windows.Forms.PictureBox();
            this.pictureBoxAdditem = new System.Windows.Forms.PictureBox();
            this.fileDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listBoxItem = new System.Windows.Forms.ListBox();
            this.labelDirectory = new System.Windows.Forms.Label();
            this.labelFileVersion = new System.Windows.Forms.Label();
            this.labelFileName = new System.Windows.Forms.Label();
            this.labelFile = new System.Windows.Forms.Label();
            this.labelPathFile = new System.Windows.Forms.Label();
            this.labelPath = new System.Windows.Forms.Label();
            this.comboBoxDirectory = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUploadFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAdditem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxFileVersion
            // 
            this.textBoxFileVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBoxFileVersion.Location = new System.Drawing.Point(179, 112);
            this.textBoxFileVersion.Name = "textBoxFileVersion";
            this.textBoxFileVersion.Size = new System.Drawing.Size(376, 26);
            this.textBoxFileVersion.TabIndex = 15;
            // 
            // buttonBrowseFile
            // 
            this.buttonBrowseFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.buttonBrowseFile.ForeColor = System.Drawing.Color.Black;
            this.buttonBrowseFile.Location = new System.Drawing.Point(710, 30);
            this.buttonBrowseFile.Name = "buttonBrowseFile";
            this.buttonBrowseFile.Size = new System.Drawing.Size(125, 27);
            this.buttonBrowseFile.TabIndex = 17;
            this.buttonBrowseFile.Text = "Browse Local";
            this.buttonBrowseFile.UseVisualStyleBackColor = true;
            this.buttonBrowseFile.Click += new System.EventHandler(this.ButtonBrowseFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBoxPathFile
            // 
            this.textBoxPathFile.BackColor = System.Drawing.Color.Silver;
            this.textBoxPathFile.Enabled = false;
            this.textBoxPathFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBoxPathFile.Location = new System.Drawing.Point(179, 30);
            this.textBoxPathFile.Name = "textBoxPathFile";
            this.textBoxPathFile.Size = new System.Drawing.Size(376, 26);
            this.textBoxPathFile.TabIndex = 18;
            // 
            // buttonBrowseServer
            // 
            this.buttonBrowseServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.buttonBrowseServer.ForeColor = System.Drawing.Color.Black;
            this.buttonBrowseServer.Location = new System.Drawing.Point(570, 29);
            this.buttonBrowseServer.Name = "buttonBrowseServer";
            this.buttonBrowseServer.Size = new System.Drawing.Size(125, 27);
            this.buttonBrowseServer.TabIndex = 21;
            this.buttonBrowseServer.Text = "Browse Server";
            this.buttonBrowseServer.UseVisualStyleBackColor = true;
            this.buttonBrowseServer.Click += new System.EventHandler(this.ButtonBrowseServer_Click);
            // 
            // pictureBoxUploadFiles
            // 
            this.pictureBoxUploadFiles.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxUploadFiles.Image = global::AutoUpdateSetting.Properties.Resources.upload_files;
            this.pictureBoxUploadFiles.Location = new System.Drawing.Point(41, 505);
            this.pictureBoxUploadFiles.Name = "pictureBoxUploadFiles";
            this.pictureBoxUploadFiles.Size = new System.Drawing.Size(225, 68);
            this.pictureBoxUploadFiles.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxUploadFiles.TabIndex = 19;
            this.pictureBoxUploadFiles.TabStop = false;
            this.pictureBoxUploadFiles.Click += new System.EventHandler(this.PictureBoxUploadFiles_Click);
            this.pictureBoxUploadFiles.MouseLeave += new System.EventHandler(this.PictureBoxUploadFiles_MouseLeave);
            this.pictureBoxUploadFiles.MouseHover += new System.EventHandler(this.PictureBoxUploadFiles_MouseHover);
            // 
            // pictureBoxAdditem
            // 
            this.pictureBoxAdditem.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxAdditem.Image = global::AutoUpdateSetting.Properties.Resources.add_file;
            this.pictureBoxAdditem.Location = new System.Drawing.Point(41, 217);
            this.pictureBoxAdditem.Name = "pictureBoxAdditem";
            this.pictureBoxAdditem.Size = new System.Drawing.Size(226, 68);
            this.pictureBoxAdditem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxAdditem.TabIndex = 20;
            this.pictureBoxAdditem.TabStop = false;
            this.pictureBoxAdditem.Click += new System.EventHandler(this.PictureBoxAdditem_Click);
            this.pictureBoxAdditem.MouseLeave += new System.EventHandler(this.PictureBoxAdditem_MouseLeave);
            this.pictureBoxAdditem.MouseHover += new System.EventHandler(this.PictureBoxAdditem_MouseHover);
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
            this.listBoxItem.Location = new System.Drawing.Point(179, 320);
            this.listBoxItem.Name = "listBoxItem";
            this.listBoxItem.Size = new System.Drawing.Size(376, 160);
            this.listBoxItem.TabIndex = 22;
            this.listBoxItem.ValueMember = "Name";
            // 
            // labelDirectory
            // 
            this.labelDirectory.AutoSize = true;
            this.labelDirectory.BackColor = System.Drawing.Color.Transparent;
            this.labelDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelDirectory.ForeColor = System.Drawing.Color.White;
            this.labelDirectory.Location = new System.Drawing.Point(37, 166);
            this.labelDirectory.Name = "labelDirectory";
            this.labelDirectory.Size = new System.Drawing.Size(93, 24);
            this.labelDirectory.TabIndex = 26;
            this.labelDirectory.Text = "Directory";
            // 
            // labelFileVersion
            // 
            this.labelFileVersion.AutoSize = true;
            this.labelFileVersion.BackColor = System.Drawing.Color.Transparent;
            this.labelFileVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelFileVersion.ForeColor = System.Drawing.Color.White;
            this.labelFileVersion.Location = new System.Drawing.Point(37, 112);
            this.labelFileVersion.Name = "labelFileVersion";
            this.labelFileVersion.Size = new System.Drawing.Size(123, 24);
            this.labelFileVersion.TabIndex = 27;
            this.labelFileVersion.Text = "File Version";
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.BackColor = System.Drawing.Color.Transparent;
            this.labelFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelFileName.ForeColor = System.Drawing.Color.White;
            this.labelFileName.Location = new System.Drawing.Point(37, 320);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(106, 24);
            this.labelFileName.TabIndex = 24;
            this.labelFileName.Text = "File Name";
            // 
            // labelFile
            // 
            this.labelFile.AutoSize = true;
            this.labelFile.BackColor = System.Drawing.Color.Transparent;
            this.labelFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelFile.ForeColor = System.Drawing.Color.White;
            this.labelFile.Location = new System.Drawing.Point(37, 30);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(45, 24);
            this.labelFile.TabIndex = 25;
            this.labelFile.Text = "File";
            // 
            // labelPathFile
            // 
            this.labelPathFile.AutoSize = true;
            this.labelPathFile.BackColor = System.Drawing.Color.Transparent;
            this.labelPathFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelPathFile.ForeColor = System.Drawing.Color.White;
            this.labelPathFile.Location = new System.Drawing.Point(176, 77);
            this.labelPathFile.Name = "labelPathFile";
            this.labelPathFile.Size = new System.Drawing.Size(0, 16);
            this.labelPathFile.TabIndex = 25;
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.BackColor = System.Drawing.Color.Transparent;
            this.labelPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelPath.ForeColor = System.Drawing.Color.White;
            this.labelPath.Location = new System.Drawing.Point(37, 71);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(51, 24);
            this.labelPath.TabIndex = 25;
            this.labelPath.Text = "Path";
            // 
            // comboBoxDirectory
            // 
            this.comboBoxDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.comboBoxDirectory.FormattingEnabled = true;
            this.comboBoxDirectory.Items.AddRange(new object[] {
            "D:\\Apcs Pro\\CellconCommon",
            "D:\\Apcs Pro\\LPM"});
            this.comboBoxDirectory.Location = new System.Drawing.Point(179, 166);
            this.comboBoxDirectory.Name = "comboBoxDirectory";
            this.comboBoxDirectory.Size = new System.Drawing.Size(376, 28);
            this.comboBoxDirectory.TabIndex = 28;
            // 
            // ManageFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.comboBoxDirectory);
            this.Controls.Add(this.textBoxFileVersion);
            this.Controls.Add(this.buttonBrowseFile);
            this.Controls.Add(this.textBoxPathFile);
            this.Controls.Add(this.buttonBrowseServer);
            this.Controls.Add(this.pictureBoxUploadFiles);
            this.Controls.Add(this.pictureBoxAdditem);
            this.Controls.Add(this.listBoxItem);
            this.Controls.Add(this.labelDirectory);
            this.Controls.Add(this.labelFileVersion);
            this.Controls.Add(this.labelFileName);
            this.Controls.Add(this.labelPathFile);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.labelFile);
            this.Name = "ManageFiles";
            this.Size = new System.Drawing.Size(952, 738);
            this.Load += new System.EventHandler(this.ManageFiles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUploadFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAdditem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileDataBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFileVersion;
        private System.Windows.Forms.Button buttonBrowseFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBoxPathFile;
        private System.Windows.Forms.Button buttonBrowseServer;
        private System.Windows.Forms.PictureBox pictureBoxUploadFiles;
        private System.Windows.Forms.PictureBox pictureBoxAdditem;
        private System.Windows.Forms.BindingSource fileDataBindingSource;
        private System.Windows.Forms.ListBox listBoxItem;
        private System.Windows.Forms.Label labelDirectory;
        private System.Windows.Forms.Label labelFileVersion;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.Label labelPathFile;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.ComboBox comboBoxDirectory;
    }
}
