using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace low
{
    public partial class Form2 : Form
    {
        static Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        string port = config.AppSettings.Settings["port"].Value;


        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int iport=Convert.ToInt32(duankou.Text);
                if (iport<=0||iport>65535)
                {
                    MessageBox.Show("请输入1~65535的整数数字");
                }
                else
                {                   
                    config.AppSettings.Settings["port"].Value = iport.ToString();
                    config.Save(ConfigurationSaveMode.Modified);
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("请输入1~65535的整数数字");
                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            System.Configuration.ConfigurationManager.RefreshSection("appSettings");

            duankou.Text = port;
        }
    }
}
