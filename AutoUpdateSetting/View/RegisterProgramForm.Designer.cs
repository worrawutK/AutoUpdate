namespace AutoUpdateSetting
{
    partial class RegisterProgramForm
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBoxProgramName = new System.Windows.Forms.TextBox();
            this.labelProgramName = new System.Windows.Forms.Label();
            this.labelPath = new System.Windows.Forms.Label();
            this.labelProgramVersion = new System.Windows.Forms.Label();
            this.textBoxProgramVersion = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelHeader = new System.Windows.Forms.Label();
            this.pictureBoxRegister = new System.Windows.Forms.PictureBox();
            this.pictureBoxCancel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRegister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.treeView1.Location = new System.Drawing.Point(12, 174);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(405, 265);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(88, 136);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(329, 28);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // textBoxProgramName
            // 
            this.textBoxProgramName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBoxProgramName.Location = new System.Drawing.Point(184, 67);
            this.textBoxProgramName.Name = "textBoxProgramName";
            this.textBoxProgramName.Size = new System.Drawing.Size(233, 29);
            this.textBoxProgramName.TabIndex = 3;
            // 
            // labelProgramName
            // 
            this.labelProgramName.AutoSize = true;
            this.labelProgramName.BackColor = System.Drawing.Color.Transparent;
            this.labelProgramName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelProgramName.ForeColor = System.Drawing.Color.White;
            this.labelProgramName.Location = new System.Drawing.Point(12, 69);
            this.labelProgramName.Name = "labelProgramName";
            this.labelProgramName.Size = new System.Drawing.Size(150, 24);
            this.labelProgramName.TabIndex = 4;
            this.labelProgramName.Text = "Program Name";
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.BackColor = System.Drawing.Color.Transparent;
            this.labelPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelPath.ForeColor = System.Drawing.Color.White;
            this.labelPath.Location = new System.Drawing.Point(12, 137);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(51, 24);
            this.labelPath.TabIndex = 4;
            this.labelPath.Text = "Path";
            // 
            // labelProgramVersion
            // 
            this.labelProgramVersion.AutoSize = true;
            this.labelProgramVersion.BackColor = System.Drawing.Color.Transparent;
            this.labelProgramVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelProgramVersion.ForeColor = System.Drawing.Color.White;
            this.labelProgramVersion.Location = new System.Drawing.Point(12, 103);
            this.labelProgramVersion.Name = "labelProgramVersion";
            this.labelProgramVersion.Size = new System.Drawing.Size(167, 24);
            this.labelProgramVersion.TabIndex = 4;
            this.labelProgramVersion.Text = "Program Version";
            // 
            // textBoxProgramVersion
            // 
            this.textBoxProgramVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBoxProgramVersion.Location = new System.Drawing.Point(184, 101);
            this.textBoxProgramVersion.Name = "textBoxProgramVersion";
            this.textBoxProgramVersion.Size = new System.Drawing.Size(233, 29);
            this.textBoxProgramVersion.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::AutoUpdateSetting.Properties.Resources.background_vertical;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(430, 502);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.BackColor = System.Drawing.Color.Transparent;
            this.labelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(9, 9);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(338, 39);
            this.labelHeader.TabIndex = 12;
            this.labelHeader.Text = "Manage Application";
            // 
            // pictureBoxRegister
            // 
            this.pictureBoxRegister.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxRegister.Image = global::AutoUpdateSetting.Properties.Resources.button_resister;
            this.pictureBoxRegister.Location = new System.Drawing.Point(12, 445);
            this.pictureBoxRegister.Name = "pictureBoxRegister";
            this.pictureBoxRegister.Size = new System.Drawing.Size(159, 49);
            this.pictureBoxRegister.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRegister.TabIndex = 17;
            this.pictureBoxRegister.TabStop = false;
            this.pictureBoxRegister.Click += new System.EventHandler(this.pictureBoxRegister_Click);
            this.pictureBoxRegister.MouseLeave += new System.EventHandler(this.pictureBoxRegister_MouseLeave);
            this.pictureBoxRegister.MouseHover += new System.EventHandler(this.pictureBoxRegister_MouseHover);
            // 
            // pictureBoxCancel
            // 
            this.pictureBoxCancel.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxCancel.Image = global::AutoUpdateSetting.Properties.Resources.button_Cancel;
            this.pictureBoxCancel.Location = new System.Drawing.Point(252, 444);
            this.pictureBoxCancel.Name = "pictureBoxCancel";
            this.pictureBoxCancel.Size = new System.Drawing.Size(165, 50);
            this.pictureBoxCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCancel.TabIndex = 18;
            this.pictureBoxCancel.TabStop = false;
            this.pictureBoxCancel.Click += new System.EventHandler(this.pictureBoxCancel_Click);
            this.pictureBoxCancel.MouseLeave += new System.EventHandler(this.pictureBoxCancel_MouseLeave);
            this.pictureBoxCancel.MouseHover += new System.EventHandler(this.pictureBoxCancel_MouseHover);
            // 
            // RegisterProgramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 502);
            this.Controls.Add(this.pictureBoxCancel);
            this.Controls.Add(this.pictureBoxRegister);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.labelProgramVersion);
            this.Controls.Add(this.labelProgramName);
            this.Controls.Add(this.textBoxProgramVersion);
            this.Controls.Add(this.textBoxProgramName);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegisterProgramForm";
            this.Text = "RegisterProgramForm";
            this.Load += new System.EventHandler(this.RegisterProgramForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRegister)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBoxProgramName;
        private System.Windows.Forms.Label labelProgramName;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Label labelProgramVersion;
        private System.Windows.Forms.TextBox textBoxProgramVersion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.PictureBox pictureBoxRegister;
        private System.Windows.Forms.PictureBox pictureBoxCancel;
    }
}