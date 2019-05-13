namespace AutoUpdateSetting.View
{
    partial class FormConfirmRegisterProgram
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
            this.labelHeader = new System.Windows.Forms.Label();
            this.pictureBoxCancel = new System.Windows.Forms.PictureBox();
            this.pictureBoxOk = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.treeViewItem = new System.Windows.Forms.TreeView();
            this.fileDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.BackColor = System.Drawing.Color.Transparent;
            this.labelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(12, 12);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(147, 39);
            this.labelHeader.TabIndex = 17;
            this.labelHeader.Text = "Confirm";
            // 
            // pictureBoxCancel
            // 
            this.pictureBoxCancel.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxCancel.Image = global::AutoUpdateSetting.Properties.Resources.button_Cancel;
            this.pictureBoxCancel.Location = new System.Drawing.Point(287, 356);
            this.pictureBoxCancel.Name = "pictureBoxCancel";
            this.pictureBoxCancel.Size = new System.Drawing.Size(231, 69);
            this.pictureBoxCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCancel.TabIndex = 19;
            this.pictureBoxCancel.TabStop = false;
            this.pictureBoxCancel.Click += new System.EventHandler(this.pictureBoxCancel_Click);
            this.pictureBoxCancel.MouseLeave += new System.EventHandler(this.pictureBoxCancel_MouseLeave);
            this.pictureBoxCancel.MouseHover += new System.EventHandler(this.pictureBoxCancel_MouseHover);
            // 
            // pictureBoxOk
            // 
            this.pictureBoxOk.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxOk.Image = global::AutoUpdateSetting.Properties.Resources.button_Ok;
            this.pictureBoxOk.Location = new System.Drawing.Point(12, 357);
            this.pictureBoxOk.Name = "pictureBoxOk";
            this.pictureBoxOk.Size = new System.Drawing.Size(231, 66);
            this.pictureBoxOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxOk.TabIndex = 18;
            this.pictureBoxOk.TabStop = false;
            this.pictureBoxOk.Click += new System.EventHandler(this.pictureBoxOk_Click);
            this.pictureBoxOk.MouseLeave += new System.EventHandler(this.pictureBoxOk_MouseLeave);
            this.pictureBoxOk.MouseHover += new System.EventHandler(this.pictureBoxOk_MouseHover);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::AutoUpdateSetting.Properties.Resources.backgrond_horizontal;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(537, 437);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // treeViewItem
            // 
            this.treeViewItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.treeViewItem.Location = new System.Drawing.Point(12, 68);
            this.treeViewItem.Name = "treeViewItem";
            this.treeViewItem.Size = new System.Drawing.Size(506, 282);
            this.treeViewItem.TabIndex = 20;
            // 
            // fileDataBindingSource
            // 
            this.fileDataBindingSource.DataSource = typeof(AutoUpdateSetting.Model.FileData);
            // 
            // FormConfirmRegisterProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 437);
            this.ControlBox = false;
            this.Controls.Add(this.treeViewItem);
            this.Controls.Add(this.pictureBoxCancel);
            this.Controls.Add(this.pictureBoxOk);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormConfirmRegisterProgram";
            this.Text = "FormConfirmRegisterProgram";
            this.Load += new System.EventHandler(this.FormConfirmRegisterProgram_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileDataBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource fileDataBindingSource;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.PictureBox pictureBoxOk;
        private System.Windows.Forms.PictureBox pictureBoxCancel;
        private System.Windows.Forms.TreeView treeViewItem;
    }
}