using Fiddler;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace low
{
    public partial class Form1 : Form
    {
        public static string SqlConnectionString = @"server=aliyun.sakurazxw.win;Database=low_calc;user id=root@;Password=395431120aA;port=9306;";
        MySqlConnection msqlConnection = new MySqlConnection(SqlConnectionString);
        MySqlCommand cmd = new MySqlCommand();


        static Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        static string port = config.AppSettings.Settings["port"].Value;

        static int iPort = Convert.ToInt32(port);   //开启端口

        static kssm ziji = null;
        static card ziji_1 = null;
        static card ziji_2 = null;
        static card ziji_3 = null;
        static kssm diren = null;
        static card diren_1 = null;
        static card diren_2 = null;
        static card diren_3 = null;

        public static int jieguo_data = 0;

        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void jisuan_Click(object sender, EventArgs e)
        {
            jisuan_click();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.Text = "ロードオブワルキューレ对战计算器" + Application.ProductVersion;
            try
            {
                msqlConnection.Open();
                cmd.Connection = msqlConnection;
            }
            catch (Exception)
            {
                MessageBox.Show("数据库连接失败,请重新打开软件（仍无效说明服务器已挂，暂时无法使用）");
                this.Close();
            }


            card_xml.cardzhuangzai();

            ka1_cb_1.SelectedIndex = 0;
            ka2_cb_1.SelectedIndex = 0;
            ka3_cb_1.SelectedIndex = 0;
            ka1_cb_2.SelectedIndex = 0;
            ka2_cb_2.SelectedIndex = 0;
            ka3_cb_2.SelectedIndex = 0;

            #region fidder建立

            List<Fiddler.Session> oAllSessions = new List<Fiddler.Session>();
            Fiddler.Session amfshuju;

            Fiddler.FiddlerApplication.AfterSessionComplete += delegate(Fiddler.Session oS)
            {
                //确定返回值正确
                if (oS.fullUrl == "http://otome-a.smq.jp/flash/gateway.php")
                {
                    if (oS.responseCode == 200)
                    {
                        amfshuju = oS;
                        fiddler.decodeamf(amfshuju);

                        if (fiddler.Exceptionflag == false)
                        {
                            #region 数据输入

                            if (fiddler.zt_flag == 0)
                            {
                                youshou_1.Text = fiddler.r_hand_x_name;
                                zuoshou_1.Text = fiddler.l_hand_x_name;
                                yifu_1.Text = fiddler.yifu_x_name;
                                zhilun_1.Text = fiddler.ring_x_name;
                                shou_1.Text = fiddler.necklace_x_name;

                                int index=0;

                                ka1_1.Text = fiddler.card1_name;
                                cardindexchaxun(fiddler.card1_name, fiddler.card1_id, fiddler.card1_class, ref index);
                                ka1_cb_1.SelectedIndex = index;

                                ka2_1.Text = fiddler.card2_name;
                                cardindexchaxun(fiddler.card2_name, fiddler.card2_id, fiddler.card2_class, ref index);
                                ka2_cb_1.SelectedIndex = index;

                                ka3_1.Text = fiddler.card3_name;
                                cardindexchaxun(fiddler.card3_name, fiddler.card3_id, fiddler.card3_class, ref index);
                                ka3_cb_1.SelectedIndex = index;

                                zj_chaxun_click();
                            }
                            else if (fiddler.zt_flag == 1)
                            {
                                youshou_2.Text = fiddler.r_hand_x_name;
                                zuoshou_2.Text = fiddler.l_hand_x_name;
                                yifu_2.Text = fiddler.yifu_x_name;
                                zhilun_2.Text = fiddler.ring_x_name;
                                shou_2.Text = fiddler.necklace_x_name;

                                int index = 0 ;
                                ka1_2.Text = fiddler.card1_name;
                                cardindexchaxun(fiddler.card1_name, fiddler.card1_id, fiddler.card1_class, ref index);
                                ka1_cb_2.SelectedIndex = index;

                                ka2_2.Text = fiddler.card2_name;
                                cardindexchaxun(fiddler.card2_name, fiddler.card2_id, fiddler.card2_class, ref index);
                                ka2_cb_2.SelectedIndex = index;

                                ka3_2.Text = fiddler.card3_name;
                                cardindexchaxun(fiddler.card3_name, fiddler.card3_id, fiddler.card3_class, ref index);
                                ka3_cb_2.SelectedIndex = index;


                                dr_chaxun_click();
                                jisuan_click();
                            }


                            #endregion
                        }
                        else
                        {
                            log_list.Items.Insert(0, DateTime.Now.ToLongTimeString().ToString() + "\t" + "amf数据异常，本次数据不计算胜率");
                        }

                    }
                    else
                    {
                        log_list.Items.Insert(0, DateTime.Now.ToLongTimeString().ToString() + "\t" + "似乎炸了。错误代码" + oS.responseCode);
                        //Console.WriteLine("似乎炸了。错误代码{0}", oS.responseCode);
                    }
                }
            };
            Fiddler.FiddlerApplication.OnNotification += delegate(object sender1, NotificationEventArgs oNEA) { Console.WriteLine("** NotifyUser: " + oNEA.NotifyString); };
            //Fiddler.FiddlerApplication.Log.OnLogString += delegate(object sender1, LogEventArgs oLEA) { Console.WriteLine("** LogString: " + oLEA.LogString); };

            Fiddler.FiddlerApplication.Log.OnLogString += delegate(object sender1, LogEventArgs oLEA) { log_list.Items.Insert(0, DateTime.Now.ToLongTimeString().ToString() + "\t" + "** LogString: " + oLEA.LogString); };


            Fiddler.FiddlerApplication.BeforeRequest += delegate(Fiddler.Session oS)
            {
                if (fiddler.pxorysetting == "")
                {
                    oS["X-OverrideGateway"] = null;
                }
                else
                {
                    oS["X-OverrideGateway"] = fiddler.pxorysetting;
                }

                oS.bBufferResponse = false;

                Monitor.Enter(oAllSessions);
                //保证截包截取在gateway.php
                if (oS.fullUrl == "http://otome-a.smq.jp/flash/gateway.php")
                {
                    if (oAllSessions.Count > 1000)
                    {
                        oAllSessions.Clear();
                    }
                    oAllSessions.Add(oS);
                }
                Monitor.Exit(oAllSessions);
            };


            Fiddler.CONFIG.IgnoreServerCertErrors = false;
            FiddlerApplication.Prefs.SetBoolPref("fiddler.network.streaming.abortifclientaborts", true);
            FiddlerCoreStartupFlags oFCSF = FiddlerCoreStartupFlags.None;



            string port = config.AppSettings.Settings["port"].Value;

            int iPort = Convert.ToInt32(port);   //开启端口

            jiantingduankou.Text = "监听端口：" + iPort;


            Fiddler.FiddlerApplication.Startup(iPort, oFCSF);

            FiddlerApplication.Log.LogFormat("Created endpoint listening on port {0}", iPort);
            FiddlerApplication.Log.LogFormat("Starting with settings: [{0}]", oFCSF);
            FiddlerApplication.Log.LogFormat("Gateway: {0}", CONFIG.UpstreamGateway.ToString());

            #endregion



        }

        public void zj_chaxun_click()
        {
            zhuangbeichaxun("右手", youshou_1.Text, ref Chushihua.wuqi_name, ref  Chushihua.wuqi_qianghua, ref Chushihua.wuqi_duiying);
            zhuangbeichaxun("左手", zuoshou_1.Text, ref Chushihua.dun_name, ref  Chushihua.dun_qianghua, ref Chushihua.dun_duiying);
            zhuangbeichaxun("衣服", yifu_1.Text, ref Chushihua.yifu_name, ref  Chushihua.yifu_qianghua, ref Chushihua.yifu_duiying);
            zhuangbeichaxun("指轮", zhilun_1.Text, ref Chushihua.zhilun_name, ref  Chushihua.zhilun_qianghua, ref Chushihua.zhilun_duiying);
            zhuangbeichaxun("首", shou_1.Text, ref Chushihua.shou_name, ref  Chushihua.shou_qianghua, ref Chushihua.shou_duiying);

            cardchaxun("卡1", ka1_1.Text, ka1_cb_1.SelectedIndex, out Chushihua.card1_name, out Chushihua.card1_jieduan, ref Chushihua.card1_duiying);
            cardchaxun("卡2", ka2_1.Text, ka2_cb_1.SelectedIndex, out Chushihua.card2_name, out Chushihua.card2_jieduan, ref Chushihua.card2_duiying);
            cardchaxun("卡3", ka3_1.Text, ka3_cb_1.SelectedIndex, out Chushihua.card3_name, out Chushihua.card3_jieduan, ref Chushihua.card3_duiying);


            ziji = kssmzhuangzai.peizhi();

            wuligongji_1.Text = "物理攻击:" + ziji.wuligongji;
            mofagongji_1.Text = "魔法攻击:" + ziji.mofagongji;
            wulifangyu_1.Text = "物理防御:" + ziji.wulifangyu;
            mofafangyu_1.Text = "魔法防御:" + ziji.mofafangyu;
            balance_1.Text = "B值:" + ziji.balance;
            critical_1.Text = "C值:" + ziji.critical;
            shuxing_1.Text = "属性:" + ziji.shuxingzhi + " " + ziji.shuxingtype;
            wulimofa_1.Text = "" + ziji.kssm_wmtype;

            ziji_1 = cardzhuangzai.peizhi(Chushihua.card1_duiying, Chushihua.card1_jieduan);
            ziji_2 = cardzhuangzai.peizhi(Chushihua.card2_duiying, Chushihua.card2_jieduan);
            ziji_3 = cardzhuangzai.peizhi(Chushihua.card3_duiying, Chushihua.card3_jieduan);

            zj_card_1.Text = "卡1：\nad" + ziji_1.atk
                + "\nsd" + ziji_1.sdk
                + "\n发动" + ziji_1.fadong
                + "\nB值" + ziji_1.balance
                + "\nC值" + ziji_1.critical
                + "\n属性" + ziji_1.shuxingtype + ziji_1.shuxingzhi;
            zj_card_2.Text = "卡1：\nad" + ziji_2.atk
                + "\nsd" + ziji_2.sdk
                + "\n发动" + ziji_2.fadong
                + "\nB值" + ziji_2.balance
                + "\nC值" + ziji_2.critical
                + "\n属性" + ziji_2.shuxingtype + ziji_2.shuxingzhi;
            zj_card_3.Text = "卡1：\nad" + ziji_3.atk
                + "\nsd" + ziji_3.sdk
                + "\n发动" + ziji_3.fadong
                + "\nB值" + ziji_3.balance
                + "\nC值" + ziji_3.critical
                + "\n属性" + ziji_3.shuxingtype + ziji_3.shuxingzhi;
        }

        public void dr_chaxun_click()
        {
            zhuangbeichaxun("右手", youshou_2.Text, ref Chushihua.wuqi_name, ref  Chushihua.wuqi_qianghua, ref Chushihua.wuqi_duiying);
            zhuangbeichaxun("左手", zuoshou_2.Text, ref Chushihua.dun_name, ref  Chushihua.dun_qianghua, ref Chushihua.dun_duiying);
            zhuangbeichaxun("衣服", yifu_2.Text, ref Chushihua.yifu_name, ref  Chushihua.yifu_qianghua, ref Chushihua.yifu_duiying);
            zhuangbeichaxun("指轮", zhilun_2.Text, ref Chushihua.zhilun_name, ref  Chushihua.zhilun_qianghua, ref Chushihua.zhilun_duiying);
            zhuangbeichaxun("首", shou_2.Text, ref Chushihua.shou_name, ref  Chushihua.shou_qianghua, ref Chushihua.shou_duiying);

            cardchaxun("卡1", ka1_2.Text, ka1_cb_2.SelectedIndex, out Chushihua.card1_name, out Chushihua.card1_jieduan, ref Chushihua.card1_duiying);
            cardchaxun("卡2", ka2_2.Text, ka2_cb_2.SelectedIndex, out Chushihua.card2_name, out Chushihua.card2_jieduan, ref Chushihua.card2_duiying);
            cardchaxun("卡3", ka3_2.Text, ka3_cb_2.SelectedIndex, out Chushihua.card3_name, out Chushihua.card3_jieduan, ref Chushihua.card3_duiying);



            diren = kssmzhuangzai.peizhi();

            wuligongji_2.Text = "物理攻击:" + diren.wuligongji;
            mofagongji_2.Text = "魔法攻击:" + diren.mofagongji;
            wulifangyu_2.Text = "物理防御:" + diren.wulifangyu;
            mofafangyu_2.Text = "魔法防御:" + diren.mofafangyu;
            balance_2.Text = "B值:" + diren.balance;
            critical_2.Text = "C值:" + diren.critical;
            shuxing_2.Text = "属性:" + diren.shuxingzhi + " " + diren.shuxingtype;
            wulimofa_2.Text = "" + diren.kssm_wmtype;



            diren_1 = cardzhuangzai.peizhi(Chushihua.card1_duiying, Chushihua.card1_jieduan);
            diren_2 = cardzhuangzai.peizhi(Chushihua.card2_duiying, Chushihua.card2_jieduan);
            diren_3 = cardzhuangzai.peizhi(Chushihua.card3_duiying, Chushihua.card3_jieduan);

            dr_card_1.Text = "卡1：\nad" + diren_1.atk
                + "\nsd" + diren_1.sdk
                + "\n发动" + diren_1.fadong
                + "\nB值" + diren_1.balance
                + "\nC值" + diren_1.critical
                + "\n属性" + diren_1.shuxingtype + diren_1.shuxingzhi;
            dr_card_2.Text = "卡1：\nad" + diren_2.atk
                + "\nsd" + diren_2.sdk
                + "\n发动" + diren_2.fadong
                + "\nB值" + diren_2.balance
                + "\nC值" + diren_2.critical
                + "\n属性" + diren_2.shuxingtype + diren_2.shuxingzhi;
            dr_card_3.Text = "卡1：\nad" + diren_3.atk
                + "\nsd" + diren_3.sdk
                + "\n发动" + diren_3.fadong
                + "\nB值" + diren_3.balance
                + "\nC值" + diren_3.critical
                + "\n属性" + diren_3.shuxingtype + diren_3.shuxingzhi;

        }

        public void jisuan_click()
        {
            if (ziji == null || diren == null)
            {
                log_list.Items.Insert(0, DateTime.Now.ToLongTimeString().ToString() + "\t" + "boom");
            }
            else
            {
                zhandou asd = new zhandou();
                jieguo_data = asd.jisuan(ziji, ziji_1, ziji_2, ziji_3, diren, diren_1, diren_2, diren_3);
                jieguo.Text = jieguo_data.ToString() + "/10000";
            }
        }



        public void zhuangbeichaxun(string type, string name, ref string dataname, ref int dataqianghua, ref int[] dataduiying)
        {
            try
            {
                if (name.IndexOf('+') == -1)
                {

                    dataname = name;
                    dataqianghua = 0;
                }
                else
                {
                    dataname = name.Substring(0, (name.IndexOf('+') - 1));
                    dataqianghua = int.Parse(name.Substring((name.IndexOf('+') + 1), ((name.Length - (name.IndexOf('+') + 1)))));
                }


                if (dataname != "")
                {
                    if (type == "指轮" || type == "首")
                    {
                        cmd.CommandText = "select atk,matk,def,mdef,C,B,eletype,elenum from " + type + " where name='" + dataname + "';";

                    }
                    else
                    {
                        cmd.CommandText = "select atk,matk,def,mdef,C,B,eletype,elenum,type from " + type + " where name='" + dataname + "';";
                    }
                    MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adap.Fill(ds);
                    DataTable dt = new DataTable();
                    dt = ds.Tables[0];

                    if (dt.Rows.Count != 0)
                    {
                        DataRow dr = dt.Rows[0];
                        for (int i = 0; i < dr.ItemArray.Length; i++)
                        {
                            dataduiying[i] = Convert.ToInt32(dr[i]);
                        }
                    }
                    else
                    {
                        //炸了
                        log_list.Items.Insert(0, DateTime.Now.ToLongTimeString().ToString() + "\t" + type + "未找到，检查是否输入错误\n如未在列表中找到，请回帖报告\n(默认按无装备替代)");

                        dataduiying = new int[] { 0, 0, 0, 0, 0, 0, -1, 0, 0 };
                    }
                }
                else
                {
                    dataduiying = new int[] { 0, 0, 0, 0, 0, 0, -1, 0, 0 };
                }
            }
            catch (Exception)
            {
                log_list.Items.Insert(0, DateTime.Now.ToLongTimeString().ToString() + "\t" + "数据库连接出现错误");
            }
        }


        public void cardchaxun(string type, string name, int index, out string dataname, out int datajieduan, ref Carddata dataduiying)
        {
            name = Regex.Replace(name, @"[☆★！=＝?·・Ｐ＄/]", "X");
            name = Regex.Replace(name, @"ＨＤ７", "HD7");

            int dataindex = 0;
            dataname = name;
            datajieduan = index;
            if (dataname != "")
            {
                if (index == 5)
                {

                    if (card_xml.heti_dict.ContainsKey(dataname))
                    {
                        card_xml.heti_dict.TryGetValue(dataname, out dataindex);
                        dataduiying = card_xml.card_list[dataindex];
                    }
                    else
                    {
                        //error
                        dataduiying = card_xml.card_list[0];
                        datajieduan = 0;
                    }
                }
                else
                {
                    dataindex = card_xml.listchaxun(dataname, card_xml.card_list);
                    if (dataindex != 0)
                    {
                        dataduiying = card_xml.card_list[dataindex];
                    }
                    else
                    {
                        log_list.Items.Insert(0, DateTime.Now.ToLongTimeString().ToString() + "\t" + type + "未找到，检查是否输入错误\n如未在列表中找到，请回帖报告");
                        dataduiying = card_xml.card_list[0];
                        datajieduan = 0;
                    }
                }
            }
            else
            {
                dataduiying = card_xml.card_list[0];
                datajieduan = 0;
            }
        }

        public void cardindexchaxun(string name, string id, string cardclass, ref int index)
        {
            try
            {
                if (name != "")
                {
                    cmd.CommandText = "select * from 合体卡 where id='" + id + "';";

                    MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adap.Fill(ds);

                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        index = 5;
                    }
                    else
                    {
                        cmd.CommandText = "select * from 限突 where id='" + id + "';";
                        adap = new MySqlDataAdapter(cmd);
                        adap.Fill(ds);
                        if (ds.Tables[0].Rows.Count != 0)
                        {
                            index = 4;
                        }
                        else
                        {
                            cmd.CommandText = "select * from 突破 where id='" + id + "';";
                            adap = new MySqlDataAdapter(cmd);
                            adap.Fill(ds);
                            if (ds.Tables[0].Rows.Count != 0)
                            {
                                index = 3;
                            }
                            else
                            {
                                index = Convert.ToInt32(cardclass) - 1;
                            }
                        }
                    }
                }
                else
                {
                    index = 0;
                }
            }
            catch (Exception)
            {

                log_list.Items.Insert(0, DateTime.Now.ToLongTimeString().ToString() + "\t" + "数据库连接出现错误");
            }
            
        }



        private void dr_card_1_TextChanged(object sender, EventArgs e)
        {
            if (diren_1 != null)
            {
                if (diren_1.sdk > 100000)
                {
                    //dr_card_1.Font = new Font(Font.FontFamily, Font.Size, System.Drawing.FontStyle.Bold);
                    dr_card_1.ForeColor = Color.Blue;
                }
                else if (diren_1.sdk > 70000)
                {
                    dr_card_1.ForeColor = Color.Red;
                }
                else
                {
                    dr_card_1.ForeColor = Color.Black;
                }

            }
        }

        private void dr_card_2_TextChanged(object sender, EventArgs e)
        {
            if (diren_2 != null)
            {
                if (diren_2.sdk > 100000)
                {
                    dr_card_2.ForeColor = Color.Blue;
                }
                else if (diren_2.sdk > 70000)
                {
                    dr_card_2.ForeColor = Color.Red;
                }
                else
                {
                    dr_card_2.ForeColor = Color.Black;
                }

            }
        }

        private void dr_card_3_TextChanged(object sender, EventArgs e)
        {
            if (diren_3 != null)
            {
                if (diren_3.sdk > 100000)
                {
                    dr_card_3.ForeColor = Color.Blue;
                }
                else if (diren_3.sdk > 70000)
                {
                    dr_card_3.ForeColor = Color.Red;
                }
                else
                {
                    dr_card_3.ForeColor = Color.Black;
                }

            }
        }

        private void zj_chaxun_Click(object sender, EventArgs e)
        {
            zj_chaxun_click();
        }

        private void dr_chaxun_Click(object sender, EventArgs e)
        {
            dr_chaxun_click();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            fiddler.DoQuit();
            msqlConnection.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                fiddler.pxorysetting = pxorydizhi.Text.ToString() + ":" + pxoryduankou.Text.ToString();
                if (fiddler.pxorysetting != ":")
                {

                    pxoryzhuangtai.Text = "启动代理：" + fiddler.pxorysetting;
                }
                else
                {
                    fiddler.pxorysetting = "";
                    log_list.Items.Insert(0, DateTime.Now.ToLongTimeString().ToString() + "\t" + "代理地址有误");
                    pxoryzhuangtai.Text = "未使用代理";
                }
            }
            else
            {
                fiddler.pxorysetting = "";
                pxoryzhuangtai.Text = "未使用代理";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            //this.Hide();
            f2.ShowDialog();
            this.Show();
            System.Configuration.ConfigurationManager.RefreshSection("appSettings");

            config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (config.AppSettings.Settings["port"].Value != port)
            {
                if (MessageBox.Show("监听端口已修改，是否重启程序？", " 提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    //重启
                    Application.Restart();
                }
                else
                {
                    //不重启
                    MessageBox.Show("监听端口设置在下次生效");
                }

            }
        }
    }


}
