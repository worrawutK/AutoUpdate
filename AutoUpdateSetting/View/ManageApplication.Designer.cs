namespace AutoUpdateSetting.View
{
    partial class ManageApplication
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
            this.pictureBoxRegister = new System.Windows.Forms.PictureBox();
            this.labelPath = new System.Windows.Forms.Label();
            this.labelProgramVersion = new System.Windows.Forms.Label();
            this.labelProgramName = new System.Windows.Forms.Label();
            this.textBoxProgramVersion = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxProgramName = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRegister)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxRegister
            // 
            this.pictureBoxRegister.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxRegister.Image = global::AutoUpdateSetting.Properties.Resources.button_resister;
            this.pictureBoxRegister.Location = new System.Drawing.Point(39, 514);
            this.pictureBoxRegister.Name = "pictureBoxRegister";
            this.pictureBoxRegister.Size = new System.Drawing.Size(246, 64);
            this.pictureBoxRegister.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRegister.TabIndex = 26;
            this.pictureBoxRegister.TabStop = false;
            this.pictureBoxRegister.Click += new System.EventHandler(this.PictureBoxRegister_Click);
            this.pictureBoxRegister.MouseLeave += new System.EventHandler(this.pictureBoxRegister_MouseLeave);
            this.pictureBoxRegister.MouseHover += new System.EventHandler(this.pictureBoxRegister_MouseHover);
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.BackColor = System.Drawing.Color.Transparent;
            this.labelPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelPath.ForeColor = System.Drawing.Color.White;
            this.labelPath.Location = new System.Drawing.Point(35, 119);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(51, 24);
            this.labelPath.TabIndex = 23;
            this.labelPath.Text = "Path";
            // 
            // labelProgramVersion
            // 
            this.labelProgramVersion.AutoSize = true;
            this.labelProgramVersion.BackColor = System.Drawing.Color.Transparent;
            this.labelProgramVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelProgramVersion.ForeColor = System.Drawing.Color.White;
            this.labelProgramVersion.Location = new System.Drawing.Point(35, 72);
            this.labelProgramVersion.Name = "labelProgramVersion";
            this.labelProgramVersion.Size = new System.Drawing.Size(167, 24);
            this.labelProgramVersion.TabIndex = 24;
            this.labelProgramVersion.Text = "Program Version";
            // 
            // labelProgramName
            // 
            this.labelProgramName.AutoSize = true;
            this.labelProgramName.BackColor = System.Drawing.Color.Transparent;
            this.labelProgramName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelProgramName.ForeColor = System.Drawing.Color.White;
            this.labelProgramName.Location = new System.Drawing.Point(35, 27);
            this.labelProgramName.Name = "labelProgramName";
            this.labelProgramName.Size = new System.Drawing.Size(150, 24);
            this.labelProgramName.TabIndex = 25;
            this.labelProgramName.Text = "Program Name";
            // 
            // textBoxProgramVersion
            // 
            this.textBoxProgramVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBoxProgramVersion.Location = new System.Drawing.Point(207, 70);
            this.textBoxProgramVersion.Name = "textBoxProgramVersion";
            this.textBoxProgramVersion.Size = new System.Drawing.Size(329, 29);
            this.textBoxProgramVersion.TabIndex = 21;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(207, 119);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(329, 28);
            this.comboBox1.TabIndex = 20;
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.ComboBox1_SelectedValueChanged);
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.treeView1.Location = new System.Drawing.Point(207, 168);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(429, 285);
            this.treeView1.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(35, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 24);
            this.label1.TabIndex = 27;
            this.label1.Text = "Select Files";
            // 
            // comboBoxProgramName
            // 
            this.comboBoxProgramName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.comboBoxProgramName.FormattingEnabled = true;
            this.comboBoxProgramName.Location = new System.Drawing.Point(207, 23);
            this.comboBoxProgramName.Name = "comboBoxProgramName";
            this.comboBoxProgramName.Size = new System.Drawing.Size(329, 28);
            this.comboBoxProgramName.TabIndex = 29;
            this.comboBoxProgramName.SelectedIndexChanged += new System.EventHandler(this.ComboBoxProgramName_SelectedIndexChanged);
            // 
            // ManageApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.comboBoxProgramName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxRegister);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.labelProgramVersion);
            this.Controls.Add(this.labelProgramName);
            this.Controls.Add(this.textBoxProgramVersion);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.treeView1);
            this.Name = "ManageApplication";
            this.Size = new System.Drawing.Size(952, 738);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRegister)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxRegister;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Label labelProgramVersion;
        private System.Windows.Forms.Label labelProgramName;
        private System.Windows.Forms.TextBox textBoxProgramVersion;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxProgramName;
    }
}
