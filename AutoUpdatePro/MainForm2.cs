using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Windows.Forms;
//using MessageDialog;
using AutoUpdateProLibrary.Model;
using System.Configuration;
using System.Diagnostics;
using System.IO;
namespace AutoUpdateProLibrary
{
    public partial class MainForm2 : Form
    {
        public MainForm2()
        {

            InitializeComponent();
            try
            {
                c_CellCon = new Controller();
                c_SynchronizationContext = SynchronizationContext.Current;
            }
            catch (Exception ex)
            {
                Log.WriteMessage("InitializeComponent:" + ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString());
            }


        }
        private Controller c_CellCon;
        private SynchronizationContext c_SynchronizationContext;
        public Controller CellCon
        {
            get
            {
                return c_CellCon;
            }
            set
            {
                c_CellCon = value;
            }
        }
        private void MainForm2_Load(object sender, EventArgs e)
        {
            try
            {
                Thread thread1 = new Thread(UpdateFile);
                thread1.Start();
            }
            catch (Exception ex)
            {
                Log.WriteMessage("MainForm_Load:" + ex.Message.ToString());
                MessageBox.Show("Exception" + ex.ToString());
            }
        }
        public bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress, 1000);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }
            return pingable;
        }

        private void UpdateFile()
        {
            try
            {
                for (int i = 0; i < int.Parse(AppSettingHelper.GetAppSettingsValue("TimeOut")); i++)
                {
                    Thread.Sleep(1000);
                    if (PingHost(AppSettingHelper.GetAppSettingsValue("ServerIP")))
                    {
                        UpdateFileResult fileResult = c_CellCon.UpdateFile();
                        if (!fileResult.IsPass)
                        {
                            Log.WriteMessage("UpdateFile: " + fileResult.Cause);
                            c_SynchronizationContext.Post(x => ConfirmCloseProgram(fileResult.Cause), null);
                            return;
                        }
                        c_SynchronizationContext.Post(x => ConfirmCloseProgram(""), null);
                        return;
                    }
                }
                Log.WriteMessage("PingHost:ไม่สามารถเข้าถึง " + AppSettingHelper.GetAppSettingsValue("ServerIP") + " ได้");
                c_SynchronizationContext.Post(x =>
                {
                 //   this.ShowMessage("PingHost", "ไม่สามารถเข้าถึง " + AppSettingHelper.GetAppSettingsValue("ServerIP") +
                 //" ได้", "AutoUpdate");
                    ConfirmCloseProgram("PingHost:ไม่สามารถเข้าถึง " + AppSettingHelper.GetAppSettingsValue("ServerIP") + " ได้");
                }
               , null);
              
                //MessageBoxDialog.ShowMessageDialog("PingHost", "ไม่สามารถเข้าถึง " + AppSettingHelper.GetAppSettingsValue("ServerIP") +
                //    " ได้", "AutoUpdate");
            }
            catch (Exception ex)
            {
                Log.WriteMessage("UpdateFile:" + ex.Message.ToString());
                //    c_SynchronizationContext.Post(x => this.ShowMessage("UpdateFile", ex.Message.ToString(), "Exception"), null);
                MessageBox.Show("Exception:" + ex.Message);
            }



        }
        private void ShowMessage(string title, string message, string messageType)
        {
            //MessageBoxDialog.ShowMessageDialog(title, message, messageType);
        }
        private void ConfirmCloseProgram(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                DialogConfirm dialog = new DialogConfirm(message + "\nต้องการโหลดใหม่อีกครั้ง?");
                //;
                //MessageBoxDialog.ShowMessageDialog("", "xxxx", "");
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.Yes)
                {
                    Thread thread1 = new Thread(UpdateFile);
                    thread1.Start();
                    return;
                }

            }
            try
            {
                Process.Start(Path.Combine(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "UpdateMe"), "AutoUpdateMe.exe"));
            }
            catch (Exception ex)
            {
                Log.WriteMessage("Process.Start AutoUpdateMe:" + ex.Message.ToString());
                //MessageBoxDialog.ShowMessageDialog("Process.Start AutoUpdateMe", ex.Message.ToString(), "Exception");
            }

            Thread thread2 = new Thread(ClossProgram);
            thread2.Start();
        }
        private void ClossProgram()
        {
            // Thread.Sleep(1000);
            c_SynchronizationContext.Post(x => this.Close(), null);
        }
    }
}
