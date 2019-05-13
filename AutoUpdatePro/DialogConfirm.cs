using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoUpdateProLibrary
{
    public partial class DialogConfirm : Form
    {
        private string c_Message;
        public DialogConfirm(string message)
        {
            InitializeComponent();
            c_Message = message;
        }

        private void ButtonYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void ButtonNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void DialogConfirm_Load(object sender, EventArgs e)
        {
            labelMessage.Text = c_Message;
        }
    }
}
