namespace AutoUpdateSetting
{
    partial class RegisterProgramCellconForm
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
            this.labelCellconVersion = new System.Windows.Forms.Label();
            this.labelCellconName = new System.Windows.Forms.Label();
            this.textBoxCellconVersion = new System.Windows.Forms.TextBox();
            this.textBoxCellconName = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.labelHeader = new System.Windows.Forms.Label();
            this.pictureBoxRegister = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxCancel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRegister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCellconVersion
            // 
            this.labelCellconVersion.AutoSize = true;
            this.labelCellconVersion.BackColor = System.Drawing.Color.Transparent;
            this.labelCellconVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelCellconVersion.ForeColor = System.Drawing.Color.White;
            this.labelCellconVersion.Location = new System.Drawing.Point(12, 100);
            this.labelCellconVersion.Name = "labelCellconVersion";
            this.labelCellconVersion.Size = new System.Drawing.Size(159, 24);
            this.labelCellconVersion.TabIndex = 11;
            this.labelCellconVersion.Text = "Cellcon Version";
            // 
            // labelCellconName
            // 
            this.labelCellconName.AutoSize = true;
            this.labelCellconName.BackColor = System.Drawing.Color.Transparent;
            this.labelCellconName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelCellconName.ForeColor = System.Drawing.Color.White;
            this.labelCellconName.Location = new System.Drawing.Point(12, 70);
            this.labelCellconName.Name = "labelCellconName";
            this.labelCellconName.Size = new System.Drawing.Size(142, 24);
            this.labelCellconName.TabIndex = 12;
            this.labelCellconName.Text = "Cellcon Name";
            // 
            // textBoxCellconVersion
            // 
            this.textBoxCellconVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBoxCellconVersion.Location = new System.Drawing.Point(175, 99);
            this.textBoxCellconVersion.Name = "textBoxCellconVersion";
            this.textBoxCellconVersion.Size = new System.Drawing.Size(250, 26);
            this.textBoxCellconVersion.TabIndex = 8;
            // 
            // textBoxCellconName
            // 
            this.textBoxCellconName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBoxCellconName.Location = new System.Drawing.Point(175, 69);
            this.textBoxCellconName.Name = "textBoxCellconName";
            this.textBoxCellconName.Size = new System.Drawing.Size(250, 26);
            this.textBoxCellconName.TabIndex = 9;
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.treeView1.Location = new System.Drawing.Point(12, 132);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(413, 280);
            this.treeView1.TabIndex = 5;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.BackColor = System.Drawing.Color.Transparent;
            this.labelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(12, 9);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(280, 39);
            this.labelHeader.TabIndex = 14;
            this.labelHeader.Text = "Manage Cellcon";
            // 
            // pictureBoxRegister
            // 
            this.pictureBoxRegister.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxRegister.Image = global::AutoUpdateSetting.Properties.Resources.button_resister;
            this.pictureBoxRegister.Location = new System.Drawing.Point(12, 417);
            this.pictureBoxRegister.Name = "pictureBoxRegister";
            this.pictureBoxRegister.Size = new System.Drawing.Size(159, 49);
            this.pictureBoxRegister.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRegister.TabIndex = 16;
            this.pictureBoxRegister.TabStop = false;
            this.pictureBoxRegister.Click += new System.EventHandler(this.pictureBoxRegister_Click);
            this.pictureBoxRegister.MouseLeave += new System.EventHandler(this.pictureBoxRegister_MouseLeave);
            this.pictureBoxRegister.MouseHover += new System.EventHandler(this.pictureBoxRegister_MouseHover);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::AutoUpdateSetting.Properties.Resources.background_vertical;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(440, 478);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBoxCancel
            // 
            this.pictureBoxCancel.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxCancel.Image = global::AutoUpdateSetting.Properties.Resources.button_Cancel;
            this.pictureBoxCancel.Location = new System.Drawing.Point(260, 416);
            this.pictureBoxCancel.Name = "pictureBoxCancel";
            this.pictureBoxCancel.Size = new System.Drawing.Size(165, 50);
            this.pictureBoxCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCancel.TabIndex = 17;
            this.pictureBoxCancel.TabStop = false;
            this.pictureBoxCancel.Click += new System.EventHandler(this.pictureBoxCancel_Click);
            this.pictureBoxCancel.MouseLeave += new System.EventHandler(this.pictureBoxCancel_MouseLeave);
            this.pictureBoxCancel.MouseHover += new System.EventHandler(this.pictureBoxCancel_MouseHover);
            // 
            // RegisterProgramCellconForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 478);
            this.Controls.Add(this.pictureBoxCancel);
            this.Controls.Add(this.pictureBoxRegister);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.labelCellconVersion);
            this.Controls.Add(this.labelCellconName);
            this.Controls.Add(this.textBoxCellconVersion);
            this.Controls.Add(this.textBoxCellconName);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegisterProgramCellconForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterProgramCellcon";
            this.Load += new System.EventHandler(this.RegisterProgramCellconForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRegister)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelCellconVersion;
        private System.Windows.Forms.Label labelCellconName;
        private System.Windows.Forms.TextBox textBoxCellconVersion;
        private System.Windows.Forms.TextBox textBoxCellconName;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.PictureBox pictureBoxRegister;
        private System.Windows.Forms.PictureBox pictureBoxCancel;
    }
}