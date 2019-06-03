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
using AutoUpdateSetting.View;
namespace AutoUpdateSetting
{
    public partial class MainForm : Form
    {
        //private MenuProgram c_MenuProgram;

        private MenuProgram c_MenuFrom;
        public MenuProgram MenuFrom
        {
            get { return c_MenuFrom; }
            set {
                c_MenuFrom = value;
                switch (MenuFrom)
                {
                    case MenuProgram.DEFAULT:
                        pictureBoxManageFiles.Image = AutoUpdateSetting.Properties.Resources.manage_files;
                        pictureBoxManageApplication.Image = AutoUpdateSetting.Properties.Resources.manage_application;
                        pictureBoxManageCellcon.Image = AutoUpdateSetting.Properties.Resources.manage_cellcon;
                        pictureBoxManageMachines.Image = AutoUpdateSetting.Properties.Resources.manage_machine;
                        break;
                    case MenuProgram.MANAGEFILES:
                        pictureBoxManageFiles.Image = AutoUpdateSetting.Properties.Resources.manage_files_cursor;
                        pictureBoxManageApplication.Image = AutoUpdateSetting.Properties.Resources.manage_application;
                        pictureBoxManageCellcon.Image = AutoUpdateSetting.Properties.Resources.manage_cellcon;
                        pictureBoxManageMachines.Image = AutoUpdateSetting.Properties.Resources.manage_machine;
                        break;
                    case MenuProgram.MANAGEAPPLICATION:
                        pictureBoxManageFiles.Image = AutoUpdateSetting.Properties.Resources.manage_files;
                        pictureBoxManageApplication.Image = AutoUpdateSetting.Properties.Resources.manage_application_cursor;
                        pictureBoxManageCellcon.Image = AutoUpdateSetting.Properties.Resources.manage_cellcon;
                        pictureBoxManageMachines.Image = AutoUpdateSetting.Properties.Resources.manage_machine;
                        break;
                    case MenuProgram.MANAGECELLCON:
                        pictureBoxManageFiles.Image = AutoUpdateSetting.Properties.Resources.manage_files;
                        pictureBoxManageApplication.Image = AutoUpdateSetting.Properties.Resources.manage_application;
                        pictureBoxManageCellcon.Image = AutoUpdateSetting.Properties.Resources.manage_cellcon_cursor;
                        pictureBoxManageMachines.Image = AutoUpdateSetting.Properties.Resources.manage_machine;
                        break;
                    case MenuProgram.MANAGEMACHINES:
                        pictureBoxManageFiles.Image = AutoUpdateSetting.Properties.Resources.manage_files;
                        pictureBoxManageApplication.Image = AutoUpdateSetting.Properties.Resources.manage_application;
                        pictureBoxManageCellcon.Image = AutoUpdateSetting.Properties.Resources.manage_cellcon;
                        pictureBoxManageMachines.Image = AutoUpdateSetting.Properties.Resources.manage_machine_cursor;
                        break;
                }
            }
        }

        public MainForm()
        {
            InitializeComponent();
            MenuFrom = MenuProgram.DEFAULT;
        }

        private void pictureBoxAddFile_Click(object sender, EventArgs e)
        {
            MenuFrom = MenuProgram.MANAGEFILES;
            panelMain.Controls.Clear();
            ManageFiles manageFiles = new ManageFiles(this);
            panelMain.Controls.Add(manageFiles);
            //AddFileForm addFileForm = new AddFileForm();
            //addFileForm.ShowDialog();
        }

        private void pictureBoxRegisterProgram_Click(object sender, EventArgs e)
        {
            MenuFrom = MenuProgram.MANAGEAPPLICATION;
            ManageApplication manageApplication = new ManageApplication(this);
            panelMain.Controls.Clear();
            panelMain.Controls.Add(manageApplication);
            //RegisterProgramForm registerProgramForm = new RegisterProgramForm();
            //registerProgramForm.ShowDialog();
        }

        private void pictureBoxRegisterProgramCellCon_Click(object sender, EventArgs e)
        {
            MenuFrom = MenuProgram.MANAGECELLCON;
            ManageCellcon manageCellcon = new ManageCellcon(this);
            panelMain.Controls.Clear();
            panelMain.Controls.Add(manageCellcon);

            //RegisterProgramCellconForm registerProgramCellconForm = new RegisterProgramCellconForm();
            //registerProgramCellconForm.ShowDialog();
        }

        private void pictureBoxSettingProgramMachine_Click(object sender, EventArgs e)
        {
            MenuFrom = MenuProgram.MANAGEMACHINES;
            ManageMachines manageMachines = new ManageMachines(this);
            panelMain.Controls.Clear();
            panelMain.Controls.Add(manageMachines);


            //SettingProgramMachineForm setting = new SettingProgramMachineForm();
            //setting.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //pictureBox1.Controls.Add(pictureBoxAddFile);
            //pictureBoxAddFile.Location = new Point(24, 12);

            pictureBoxManageFiles.Parent = pictureBox1;
            pictureBoxManageApplication.Parent = pictureBox1;
            pictureBoxManageCellcon.Parent = pictureBox1;
            pictureBoxManageMachines.Parent = pictureBox1;
            pictureBoxExit.Parent = pictureBox1;
            labelHeader.Parent = pictureBox1;
            panelMain.Parent = pictureBox1;

        }

        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public enum MenuProgram
        {
            DEFAULT,
            MANAGEFILES,
            MANAGEAPPLICATION,
            MANAGECELLCON,
            MANAGEMACHINES
            
        }
        private bool CheckMenu(MenuProgram menuProgram)
        {
            if (menuProgram == MenuFrom)
                return false;

            return true;
        }
        #region View
        private void pictureBoxSettingProgramMachine_MouseLeave(object sender, EventArgs e)
        {
            if (!CheckMenu(MenuProgram.MANAGEMACHINES))
                return;
            pictureBoxManageMachines.Image = AutoUpdateSetting.Properties.Resources.manage_machine;
        }
        private void pictureBoxRegisterProgramCellCon_MouseLeave(object sender, EventArgs e)
        {
            if (!CheckMenu(MenuProgram.MANAGECELLCON))
                return;
            pictureBoxManageCellcon.Image = AutoUpdateSetting.Properties.Resources.manage_cellcon;
        }
        private void pictureBoxRegisterProgram_MouseLeave(object sender, EventArgs e)
        {
            if (!CheckMenu(MenuProgram.MANAGEAPPLICATION))
                return;
            pictureBoxManageApplication.Image = AutoUpdateSetting.Properties.Resources.manage_application;
        }
        private void pictureBoxAddFile_MouseLeave(object sender, EventArgs e)
        {
            if (!CheckMenu(MenuProgram.MANAGEFILES))
                return;
            pictureBoxManageFiles.Image = AutoUpdateSetting.Properties.Resources.manage_files;
        }

        private void pictureBoxExit_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxExit.Image = AutoUpdateSetting.Properties.Resources.exitProgram;
        }

        private void pictureBoxSettingProgramMachine_MouseHover(object sender, EventArgs e)
        {
            if (!CheckMenu(MenuProgram.MANAGEMACHINES))
                return;
            pictureBoxManageMachines.Image = AutoUpdateSetting.Properties.Resources.manage_machine_cursor;
        }

        private void pictureBoxRegisterProgramCellCon_MouseHover(object sender, EventArgs e)
        {
            if (!CheckMenu(MenuProgram.MANAGECELLCON))
                return;
            pictureBoxManageCellcon.Image = AutoUpdateSetting.Properties.Resources.manage_cellcon_cursor;
        }
        private void pictureBoxRegisterProgram_MouseHover(object sender, EventArgs e)
        {
            if (!CheckMenu(MenuProgram.MANAGEAPPLICATION))
                return;
            pictureBoxManageApplication.Image = AutoUpdateSetting.Properties.Resources.manage_application_cursor;
        }
        private void pictureBoxAddFile_MouseHover(object sender, EventArgs e)
        {
            if (!CheckMenu(MenuProgram.MANAGEFILES))
                return;
            pictureBoxManageFiles.Image = AutoUpdateSetting.Properties.Resources.manage_files_cursor;

        }
        private void pictureBoxExit_MouseHover(object sender, EventArgs e)
        {
            pictureBoxExit.Image = AutoUpdateSetting.Properties.Resources.exitProgram_cursor;
        }
        #endregion

    }
}
