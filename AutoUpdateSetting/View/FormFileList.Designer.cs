namespace AutoUpdateSetting.View
{
    partial class FormFileList
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
            this.listBoxFileList = new System.Windows.Forms.ListBox();
            this.listBoxProgramName = new System.Windows.Forms.ListBox();
            this.pictureBoxSelect = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelFileName = new System.Windows.Forms.Label();
            this.labelHeader = new System.Windows.Forms.Label();
            this.pictureBoxCancel = new System.Windows.Forms.PictureBox();
            this.labelVersion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxFileList
            // 
            this.listBoxFileList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.listBoxFileList.FormattingEnabled = true;
            this.listBoxFileList.ItemHeight = 20;
            this.listBoxFileList.Location = new System.Drawing.Point(312, 87);
            this.listBoxFileList.Name = "listBoxFileList";
            this.listBoxFileList.Size = new System.Drawing.Size(202, 304);
            this.listBoxFileList.TabIndex = 1;
            // 
            // listBoxProgramName
            // 
            this.listBoxProgramName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.listBoxProgramName.FormattingEnabled = true;
            this.listBoxProgramName.ItemHeight = 20;
            this.listBoxProgramName.Location = new System.Drawing.Point(22, 87);
            this.listBoxProgramName.Name = "listBoxProgramName";
            this.listBoxProgramName.Size = new System.Drawing.Size(273, 304);
            this.listBoxProgramName.TabIndex = 2;
            this.listBoxProgramName.SelectedIndexChanged += new System.EventHandler(this.listBoxProgramName_SelectedIndexChanged);
            this.listBoxProgramName.SelectedValueChanged += new System.EventHandler(this.listBoxProgramName_SelectedValueChanged);
            // 
            // pictureBoxSelect
            // 
            this.pictureBoxSelect.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSelect.Image = global::AutoUpdateSetting.Properties.Resources.button_select;
            this.pictureBoxSelect.Location = new System.Drawing.Point(22, 402);
            this.pictureBoxSelect.Name = "pictureBoxSelect";
            this.pictureBoxSelect.Size = new System.Drawing.Size(187, 51);
            this.pictureBoxSelect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSelect.TabIndex = 5;
            this.pictureBoxSelect.TabStop = false;
            this.pictureBoxSelect.Click += new System.EventHandler(this.pictureBoxSelect_Click);
            this.pictureBoxSelect.MouseLeave += new System.EventHandler(this.pictureBoxSelect_MouseLeave);
            this.pictureBoxSelect.MouseHover += new System.EventHandler(this.pictureBoxSelect_MouseHover);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::AutoUpdateSetting.Properties.Resources.background_blue_01;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(535, 466);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.BackColor = System.Drawing.Color.Transparent;
            this.labelFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelFileName.ForeColor = System.Drawing.Color.White;
            this.labelFileName.Location = new System.Drawing.Point(23, 56);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(106, 24);
            this.labelFileName.TabIndex = 7;
            this.labelFileName.Text = "File Name";
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.BackColor = System.Drawing.Color.Transparent;
            this.labelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(23, 9);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(180, 37);
            this.labelHeader.TabIndex = 8;
            this.labelHeader.Text = "Server File";
            // 
            // pictureBoxCancel
            // 
            this.pictureBoxCancel.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxCancel.Image = global::AutoUpdateSetting.Properties.Resources.button_Cancel;
            this.pictureBoxCancel.Location = new System.Drawing.Point(349, 403);
            this.pictureBoxCancel.Name = "pictureBoxCancel";
            this.pictureBoxCancel.Size = new System.Drawing.Size(165, 50);
            this.pictureBoxCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCancel.TabIndex = 18;
            this.pictureBoxCancel.TabStop = false;
            this.pictureBoxCancel.Click += new System.EventHandler(this.pictureBoxCancel_Click);
            this.pictureBoxCancel.MouseLeave += new System.EventHandler(this.pictureBoxCancel_MouseLeave);
            this.pictureBoxCancel.MouseHover += new System.EventHandler(this.pictureBoxCancel_MouseHover);
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.BackColor = System.Drawing.Color.Transparent;
            this.labelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelVersion.ForeColor = System.Drawing.Color.White;
            this.labelVersion.Location = new System.Drawing.Point(311, 57);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(82, 24);
            this.labelVersion.TabIndex = 7;
            this.labelVersion.Text = "Version";
            // 
            // FormFileList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 466);
            this.Controls.Add(this.listBoxFileList);
            this.Controls.Add(this.pictureBoxCancel);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.listBoxProgramName);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.labelFileName);
            this.Controls.Add(this.pictureBoxSelect);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormFileList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormFileList";
            this.Load += new System.EventHandler(this.FormFileList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBoxFileList;
        private System.Windows.Forms.ListBox listBoxProgramName;
        private System.Windows.Forms.PictureBox pictureBoxSelect;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.PictureBox pictureBoxCancel;
        private System.Windows.Forms.Label labelVersion;
    }
}