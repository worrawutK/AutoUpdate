using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoUpdateSetting
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void pictureBoxAddFile_Click(object sender, EventArgs e)
        {
            AddFileForm addFileForm = new AddFileForm();
            addFileForm.ShowDialog();
        }

        private void pictureBoxRegisterProgram_Click(object sender, EventArgs e)
        {
            RegisterProgramForm registerProgramForm = new RegisterProgramForm();
            registerProgramForm.ShowDialog();
        }

        private void pictureBoxRegisterProgramCellCon_Click(object sender, EventArgs e)
        {
            RegisterProgramCellconForm registerProgramCellconForm = new RegisterProgramCellconForm();
            registerProgramCellconForm.ShowDialog();
        }

        private void pictureBoxSettingProgramMachine_Click(object sender, EventArgs e)
        {
            SettingProgramMachineForm setting = new SettingProgramMachineForm();
            setting.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //pictureBox1.Controls.Add(pictureBoxAddFile);
            //pictureBoxAddFile.Location = new Point(24, 12);

            pictureBoxAddFile.Parent = pictureBox1;
            pictureBoxRegisterProgram.Parent = pictureBox1;
            pictureBoxRegisterProgramCellCon.Parent = pictureBox1;
            pictureBoxSettingProgramMachine.Parent = pictureBox1;
            pictureBoxExit.Parent = pictureBox1;
            labelHeader.Parent = pictureBox1;
        }

        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region View
        private void pictureBoxSettingProgramMachine_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxSettingProgramMachine.Image = AutoUpdateSetting.Properties.Resources.manage_machine;
        }
        private void pictureBoxRegisterProgramCellCon_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxRegisterProgramCellCon.Image = AutoUpdateSetting.Properties.Resources.manage_cellcon;
        }
        private void pictureBoxRegisterProgram_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxRegisterProgram.Image = AutoUpdateSetting.Properties.Resources.manage_application;
        }
        private void pictureBoxAddFile_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxAddFile.Image = AutoUpdateSetting.Properties.Resources.manage_files;
        }

        private void pictureBoxExit_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxExit.Image = AutoUpdateSetting.Properties.Resources.exitProgram;
        }

        private void pictureBoxSettingProgramMachine_MouseHover(object sender, EventArgs e)
        {
            pictureBoxSettingProgramMachine.Image = AutoUpdateSetting.Properties.Resources.manage_machine_cursor;
        }

        private void pictureBoxRegisterProgramCellCon_MouseHover(object sender, EventArgs e)
        {
            pictureBoxRegisterProgramCellCon.Image = AutoUpdateSetting.Properties.Resources.manage_cellcon_cursor;
        }
        private void pictureBoxRegisterProgram_MouseHover(object sender, EventArgs e)
        {
            pictureBoxRegisterProgram.Image = AutoUpdateSetting.Properties.Resources.manage_application_cursor;
        }
        private void pictureBoxAddFile_MouseHover(object sender, EventArgs e)
        {
            pictureBoxAddFile.Image = AutoUpdateSetting.Properties.Resources.manage_files_cursor;

        }
        private void pictureBoxExit_MouseHover(object sender, EventArgs e)
        {
            pictureBoxExit.Image = AutoUpdateSetting.Properties.Resources.exitProgram_cursor;
        }
        #endregion

    }
}
