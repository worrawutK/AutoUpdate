namespace AutoUpdateSetting
{
    partial class SettingProgramMachineForm
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
            this.comboBoxCellconName = new System.Windows.Forms.ComboBox();
            this.treeViewCellconVersion = new System.Windows.Forms.TreeView();
            this.treeViewMachine = new System.Windows.Forms.TreeView();
            this.labelMachine = new System.Windows.Forms.Label();
            this.labelProgram = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelHeader = new System.Windows.Forms.Label();
            this.pictureBoxRegister = new System.Windows.Forms.PictureBox();
            this.pictureBoxCancel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRegister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxCellconName
            // 
            this.comboBoxCellconName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxCellconName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxCellconName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.comboBoxCellconName.FormattingEnabled = true;
            this.comboBoxCellconName.Location = new System.Drawing.Point(365, 96);
            this.comboBoxCellconName.Name = "comboBoxCellconName";
            this.comboBoxCellconName.Size = new System.Drawing.Size(295, 33);
            this.comboBoxCellconName.TabIndex = 0;
            this.comboBoxCellconName.SelectedValueChanged += new System.EventHandler(this.ComboBoxCellconName_SelectedValueChanged);
            // 
            // treeViewCellconVersion
            // 
            this.treeViewCellconVersion.CheckBoxes = true;
            this.treeViewCellconVersion.Location = new System.Drawing.Point(365, 136);
            this.treeViewCellconVersion.Name = "treeViewCellconVersion";
            this.treeViewCellconVersion.Size = new System.Drawing.Size(295, 194);
            this.treeViewCellconVersion.TabIndex = 1;
            this.treeViewCellconVersion.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewCellconVersion_AfterCheck);
            // 
            // treeViewMachine
            // 
            this.treeViewMachine.CheckBoxes = true;
            this.treeViewMachine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.treeViewMachine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.treeViewMachine.Location = new System.Drawing.Point(12, 95);
            this.treeViewMachine.Name = "treeViewMachine";
            this.treeViewMachine.Size = new System.Drawing.Size(333, 235);
            this.treeViewMachine.TabIndex = 2;
            this.treeViewMachine.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewMachine_AfterCheck);
            // 
            // labelMachine
            // 
            this.labelMachine.AutoSize = true;
            this.labelMachine.BackColor = System.Drawing.Color.Transparent;
            this.labelMachine.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelMachine.ForeColor = System.Drawing.Color.White;
            this.labelMachine.Location = new System.Drawing.Point(12, 67);
            this.labelMachine.Name = "labelMachine";
            this.labelMachine.Size = new System.Drawing.Size(90, 24);
            this.labelMachine.TabIndex = 5;
            this.labelMachine.Text = "Machine";
            // 
            // labelProgram
            // 
            this.labelProgram.AutoSize = true;
            this.labelProgram.BackColor = System.Drawing.Color.Transparent;
            this.labelProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelProgram.ForeColor = System.Drawing.Color.White;
            this.labelProgram.Location = new System.Drawing.Point(366, 67);
            this.labelProgram.Name = "labelProgram";
            this.labelProgram.Size = new System.Drawing.Size(89, 24);
            this.labelProgram.TabIndex = 5;
            this.labelProgram.Text = "Program";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::AutoUpdateSetting.Properties.Resources.backgrond_horizontal;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(675, 397);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.BackColor = System.Drawing.Color.Transparent;
            this.labelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(12, 12);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(295, 39);
            this.labelHeader.TabIndex = 14;
            this.labelHeader.Text = "Manage Machine";
            // 
            // pictureBoxRegister
            // 
            this.pictureBoxRegister.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxRegister.Image = global::AutoUpdateSetting.Properties.Resources.button_resister;
            this.pictureBoxRegister.Location = new System.Drawing.Point(12, 336);
            this.pictureBoxRegister.Name = "pictureBoxRegister";
            this.pictureBoxRegister.Size = new System.Drawing.Size(159, 49);
            this.pictureBoxRegister.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRegister.TabIndex = 18;
            this.pictureBoxRegister.TabStop = false;
            this.pictureBoxRegister.Click += new System.EventHandler(this.pictureBoxRegister_Click);
            this.pictureBoxRegister.MouseLeave += new System.EventHandler(this.pictureBoxRegister_MouseLeave);
            this.pictureBoxRegister.MouseHover += new System.EventHandler(this.pictureBoxRegister_MouseHover);
            // 
            // pictureBoxCancel
            // 
            this.pictureBoxCancel.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxCancel.Image = global::AutoUpdateSetting.Properties.Resources.button_Cancel;
            this.pictureBoxCancel.Location = new System.Drawing.Point(495, 336);
            this.pictureBoxCancel.Name = "pictureBoxCancel";
            this.pictureBoxCancel.Size = new System.Drawing.Size(165, 50);
            this.pictureBoxCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCancel.TabIndex = 19;
            this.pictureBoxCancel.TabStop = false;
            this.pictureBoxCancel.Click += new System.EventHandler(this.pictureBoxCancel_Click);
            this.pictureBoxCancel.MouseLeave += new System.EventHandler(this.pictureBoxCancel_MouseLeave);
            this.pictureBoxCancel.MouseHover += new System.EventHandler(this.pictureBoxCancel_MouseHover);
            // 
            // SettingProgramMachineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 397);
            this.Controls.Add(this.pictureBoxCancel);
            this.Controls.Add(this.pictureBoxRegister);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.labelProgram);
            this.Controls.Add(this.labelMachine);
            this.Controls.Add(this.treeViewMachine);
            this.Controls.Add(this.treeViewCellconVersion);
            this.Controls.Add(this.comboBoxCellconName);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingProgramMachineForm";
            this.Text = "SettingProgramMachine";
            this.Load += new System.EventHandler(this.SettingProgramMachineForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRegister)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCellconName;
        private System.Windows.Forms.TreeView treeViewCellconVersion;
        private System.Windows.Forms.TreeView treeViewMachine;
        private System.Windows.Forms.Label labelMachine;
        private System.Windows.Forms.Label labelProgram;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.PictureBox pictureBoxRegister;
        private System.Windows.Forms.PictureBox pictureBoxCancel;
    }
}