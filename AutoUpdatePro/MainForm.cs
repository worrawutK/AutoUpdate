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
using MessageDialog;
using AutoUpdateProLibrary.Model;
using System.Configuration;
using System.Diagnostics;

namespace AutoUpdateProLibrary
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            c_CellCon = new Controller();
            c_SynchronizationContext = SynchronizationContext.Current;
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
        
        private void MainForm_Load(object sender, EventArgs e)
        {

            Thread thread1 = new Thread(UpdateFile);
            thread1.Start();
        }
        public bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress,1000);
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
            for (int i = 0; i < int.Parse(AppSettingHelper.GetAppSettingsValue("TimeOut")); i++)
            {
                Thread.Sleep(1000);
                if (PingHost(AppSettingHelper.GetAppSettingsValue("ServerIP")))
                {
                    UpdateFileResult fileResult = c_CellCon.UpdateFile();
                    if (!fileResult.IsPass)
                    {
                        c_SynchronizationContext.Post(x => CloseProgram(fileResult.Cause), null);
                        return;
                    }
                    c_SynchronizationContext.Post(x => CloseProgram(""), null);
                    return;
                }
            }
            
            MessageBoxDialog.ShowMessageDialog("PingHost", "ไม่สามารถเข้าถึง " + AppSettingHelper.GetAppSettingsValue("ServerIP") +
                " ได้", "AutoUpdate");
           
        }
        private void CloseProgram(string message)
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
                else
                {
                    this.Close();
                }
            }
            this.Close();
        }
    }
}
