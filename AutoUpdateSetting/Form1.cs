using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoUpdateSetting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
      

        public byte[] FileToByteArray(string fileName)
        {
            byte[] buff = null;
            FileStream fs = new FileStream(fileName,
                                           FileMode.Open,
                                           FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            long numBytes = new FileInfo(fileName).Length;
            buff = br.ReadBytes((int)numBytes);
            return buff;
        }
        public bool ByteArrayToFile(string fileName, byte[] byteArray)
        {
            try
            {
                //FileMode.Append Overriable
                using (var fs = new FileStream(fileName, FileMode.Append, FileAccess.Write))
                {
                    fs.Write(byteArray, 0, byteArray.Length);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in process: {0}", ex);
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.APCSProDB);
            conn.Open();
            byte[] file = FileToByteArray(path);
            SqlCommand command = new SqlCommand(
                "insert into [APCSProDBFile].[dbo].[files] ([data]) values (@file)" 
                , conn);
            command.Parameters.AddWithValue("@file", file);

            SqlDataReader dr = command.ExecuteReader();
            conn.Close();
        }
        private const string path = @"XXX.Dll";
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.APCSProDB);
            conn.Open();
            int imageId = 1;
            SqlCommand command = new SqlCommand(
                "SELECT [id],[data] FROM [APCSProDBFile].[dbo].[files] where id = @id"
                , conn);
            command.Parameters.AddWithValue("@id", imageId);

            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                ByteArrayToFile(path, (byte[])dr["data"]);
            }
            conn.Close();
        }
        #region Commend Convet byte[] to file
        //public string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        //{
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        // Convert Image to byte[]
        //        image.Save(ms, format);
        //        byte[] imageBytes = ms.ToArray();

        //        // Convert byte[] to Base64 String
        //        string base64String = Convert.ToBase64String(imageBytes);
        //        return base64String;
        //    }
        //}
        //public byte[] ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        //{
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        // Convert Image to byte[]
        //        image.Save(ms, format);
        //        byte[] imageBytes = ms.ToArray();

        //        // Convert byte[] to Base64 String
        //       // string base64String = Convert.ToBase64String(imageBytes);
        //        return imageBytes;
        //    }
        //}
        //public Image Base64ToImage(string base64String)
        //{
        //    // Convert Base64 String to byte[]
        //    byte[] imageBytes = Convert.FromBase64String(base64String);
        //    MemoryStream ms = new MemoryStream(imageBytes, 0,
        //      imageBytes.Length);

        //    // Convert byte[] to Image
        //    ms.Write(imageBytes, 0, imageBytes.Length);
        //    Image image = Image.FromStream(ms, true);
        //    return image;
        //}
        //public Image Base64ToImage(byte[] imageBytes)
        //{
        //    //// Convert Base64 String to byte[]
        //    //byte[] imageBytes = Convert.FromBase64String(base64String);
        //    MemoryStream ms = new MemoryStream(imageBytes, 0,
        //      imageBytes.Length);

        //    // Convert byte[] to Image
        //    ms.Write(imageBytes, 0, imageBytes.Length);
        //    Image image = Image.FromStream(ms, true);
        //    return image;
        //}
        #endregion

        #region NewVersion
        private void btBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            foreach (string pathFile in openFileDialog1.FileNames)
            {
                listBox1.Items.Add(pathFile);
            }
            textBox1.Text = openFileDialog1.FileName;
        }
        #endregion



    }
}
