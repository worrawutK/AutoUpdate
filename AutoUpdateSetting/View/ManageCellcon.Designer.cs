namespace AutoUpdateSetting.View
{
    partial class ManageCellcon
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
            this.labelCellconVersion = new System.Windows.Forms.Label();
            this.labelCellconName = new System.Windows.Forms.Label();
            this.textBoxCellconVersion = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.labelApplication = new System.Windows.Forms.Label();
            this.pictureBoxRegister = new System.Windows.Forms.PictureBox();
            this.comboBoxCellconName = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRegister)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCellconVersion
            // 
            this.labelCellconVersion.AutoSize = true;
            this.labelCellconVersion.BackColor = System.Drawing.Color.Transparent;
            this.labelCellconVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelCellconVersion.ForeColor = System.Drawing.Color.White;
            this.labelCellconVersion.Location = new System.Drawing.Point(32, 75);
            this.labelCellconVersion.Name = "labelCellconVersion";
            this.labelCellconVersion.Size = new System.Drawing.Size(159, 24);
            this.labelCellconVersion.TabIndex = 21;
            this.labelCellconVersion.Text = "Cellcon Version";
            // 
            // labelCellconName
            // 
            this.labelCellconName.AutoSize = true;
            this.labelCellconName.BackColor = System.Drawing.Color.Transparent;
            this.labelCellconName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelCellconName.ForeColor = System.Drawing.Color.White;
            this.labelCellconName.Location = new System.Drawing.Point(32, 27);
            this.labelCellconName.Name = "labelCellconName";
            this.labelCellconName.Size = new System.Drawing.Size(142, 24);
            this.labelCellconName.TabIndex = 22;
            this.labelCellconName.Text = "Cellcon Name";
            // 
            // textBoxCellconVersion
            // 
            this.textBoxCellconVersion.Enabled = false;
            this.textBoxCellconVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBoxCellconVersion.Location = new System.Drawing.Point(195, 74);
            this.textBoxCellconVersion.Name = "textBoxCellconVersion";
            this.textBoxCellconVersion.Size = new System.Drawing.Size(329, 26);
            this.textBoxCellconVersion.TabIndex = 19;
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.treeView1.Location = new System.Drawing.Point(195, 122);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(452, 280);
            this.treeView1.TabIndex = 18;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterCheck);
            // 
            // labelApplication
            // 
            this.labelApplication.AutoSize = true;
            this.labelApplication.BackColor = System.Drawing.Color.Transparent;
            this.labelApplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelApplication.ForeColor = System.Drawing.Color.White;
            this.labelApplication.Location = new System.Drawing.Point(32, 122);
            this.labelApplication.Name = "labelApplication";
            this.labelApplication.Size = new System.Drawing.Size(151, 24);
            this.labelApplication.TabIndex = 25;
            this.labelApplication.Text = "Application List";
            // 
            // pictureBoxRegister
            // 
            this.pictureBoxRegister.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxRegister.Image = global::AutoUpdateSetting.Properties.Resources.button_resister;
            this.pictureBoxRegister.Location = new System.Drawing.Point(36, 432);
            this.pictureBoxRegister.Name = "pictureBoxRegister";
            this.pictureBoxRegister.Size = new System.Drawing.Size(246, 64);
            this.pictureBoxRegister.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRegister.TabIndex = 23;
            this.pictureBoxRegister.TabStop = false;
            this.pictureBoxRegister.Click += new System.EventHandler(this.PictureBoxRegister_Click);
            this.pictureBoxRegister.MouseLeave += new System.EventHandler(this.pictureBoxRegister_MouseLeave);
            this.pictureBoxRegister.MouseHover += new System.EventHandler(this.pictureBoxRegister_MouseHover);
            // 
            // comboBoxCellconName
            // 
            this.comboBoxCellconName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.comboBoxCellconName.FormattingEnabled = true;
            this.comboBoxCellconName.Location = new System.Drawing.Point(195, 27);
            this.comboBoxCellconName.Name = "comboBoxCellconName";
            this.comboBoxCellconName.Size = new System.Drawing.Size(329, 28);
            this.comboBoxCellconName.TabIndex = 30;
            this.comboBoxCellconName.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCellconName_SelectedIndexChanged);
            // 
            // ManageCellcon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.comboBoxCellconName);
            this.Controls.Add(this.labelApplication);
            this.Controls.Add(this.pictureBoxRegister);
            this.Controls.Add(this.labelCellconVersion);
            this.Controls.Add(this.labelCellconName);
            this.Controls.Add(this.textBoxCellconVersion);
            this.Controls.Add(this.treeView1);
            this.Name = "ManageCellcon";
            this.Size = new System.Drawing.Size(948, 734);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRegister)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxRegister;
        private System.Windows.Forms.Label labelCellconVersion;
        private System.Windows.Forms.Label labelCellconName;
        private System.Windows.Forms.TextBox textBoxCellconVersion;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label labelApplication;
        private System.Windows.Forms.ComboBox comboBoxCellconName;
    }
}
