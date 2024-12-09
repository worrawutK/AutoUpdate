namespace AutoUpdateSetting.View
{
    partial class ManageMachines
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
            this.labelProgram = new System.Windows.Forms.Label();
            this.labelMachine = new System.Windows.Forms.Label();
            this.treeViewMachine = new System.Windows.Forms.TreeView();
            this.treeViewCellconVersion = new System.Windows.Forms.TreeView();
            this.comboBoxCellconName = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRegister)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxRegister
            // 
            this.pictureBoxRegister.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxRegister.Image = global::AutoUpdateSetting.Properties.Resources.button_resister;
            this.pictureBoxRegister.Location = new System.Drawing.Point(38, 547);
            this.pictureBoxRegister.Name = "pictureBoxRegister";
            this.pictureBoxRegister.Size = new System.Drawing.Size(246, 64);
            this.pictureBoxRegister.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRegister.TabIndex = 25;
            this.pictureBoxRegister.TabStop = false;
            this.pictureBoxRegister.Click += new System.EventHandler(this.PictureBoxRegister_Click);
            this.pictureBoxRegister.MouseLeave += new System.EventHandler(this.pictureBoxRegister_MouseLeave);
            this.pictureBoxRegister.MouseHover += new System.EventHandler(this.pictureBoxRegister_MouseHover);
            // 
            // labelProgram
            // 
            this.labelProgram.AutoSize = true;
            this.labelProgram.BackColor = System.Drawing.Color.Transparent;
            this.labelProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelProgram.ForeColor = System.Drawing.Color.White;
            this.labelProgram.Location = new System.Drawing.Point(35, 295);
            this.labelProgram.Name = "labelProgram";
            this.labelProgram.Size = new System.Drawing.Size(89, 24);
            this.labelProgram.TabIndex = 23;
            this.labelProgram.Text = "Program";
            // 
            // labelMachine
            // 
            this.labelMachine.AutoSize = true;
            this.labelMachine.BackColor = System.Drawing.Color.Transparent;
            this.labelMachine.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelMachine.ForeColor = System.Drawing.Color.White;
            this.labelMachine.Location = new System.Drawing.Point(34, 36);
            this.labelMachine.Name = "labelMachine";
            this.labelMachine.Size = new System.Drawing.Size(90, 24);
            this.labelMachine.TabIndex = 24;
            this.labelMachine.Text = "Machine";
            // 
            // treeViewMachine
            // 
            this.treeViewMachine.CheckBoxes = true;
            this.treeViewMachine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.treeViewMachine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.treeViewMachine.Location = new System.Drawing.Point(152, 36);
            this.treeViewMachine.Name = "treeViewMachine";
            this.treeViewMachine.Size = new System.Drawing.Size(333, 235);
            this.treeViewMachine.TabIndex = 22;
            this.treeViewMachine.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewMachine_AfterCheck);
            // 
            // treeViewCellconVersion
            // 
            this.treeViewCellconVersion.CheckBoxes = true;
            this.treeViewCellconVersion.Location = new System.Drawing.Point(152, 331);
            this.treeViewCellconVersion.Name = "treeViewCellconVersion";
            this.treeViewCellconVersion.Size = new System.Drawing.Size(333, 194);
            this.treeViewCellconVersion.TabIndex = 21;
            this.treeViewCellconVersion.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewCellconVersion_AfterCheck);
            // 
            // comboBoxCellconName
            // 
            this.comboBoxCellconName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxCellconName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxCellconName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.comboBoxCellconName.FormattingEnabled = true;
            this.comboBoxCellconName.Location = new System.Drawing.Point(152, 291);
            this.comboBoxCellconName.Name = "comboBoxCellconName";
            this.comboBoxCellconName.Size = new System.Drawing.Size(333, 33);
            this.comboBoxCellconName.TabIndex = 20;
            this.comboBoxCellconName.SelectedValueChanged += new System.EventHandler(this.ComboBoxCellconName_SelectedValueChanged);
            // 
            // ManageMachines
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.pictureBoxRegister);
            this.Controls.Add(this.labelProgram);
            this.Controls.Add(this.labelMachine);
            this.Controls.Add(this.treeViewMachine);
            this.Controls.Add(this.treeViewCellconVersion);
            this.Controls.Add(this.comboBoxCellconName);
            this.Name = "ManageMachines";
            this.Size = new System.Drawing.Size(948, 734);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRegister)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxRegister;
        private System.Windows.Forms.Label labelProgram;
        private System.Windows.Forms.Label labelMachine;
        private System.Windows.Forms.TreeView treeViewMachine;
        private System.Windows.Forms.TreeView treeViewCellconVersion;
        private System.Windows.Forms.ComboBox comboBoxCellconName;
    }
}
