using Fiddler;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace low
{
    public partial class Form1 : Form
    {
       

        static kssm ziji;
        static card ziji_1;
        static card ziji_2;
        static card ziji_3;
        static kssm diren;
        static card diren_1;
        static card diren_2;
        static card diren_3;


        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            jisuan_click();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Chushihua.chushihua();
            ka1_cb_1.SelectedIndex = 0;
            ka2_cb_1.SelectedIndex = 0;
            ka3_cb_1.SelectedIndex = 0;
            ka1_cb_2.SelectedIndex = 0;
            ka2_cb_2.SelectedIndex = 0;
            ka3_cb_2.SelectedIndex = 0;

            #region fidder建立

            List<Fiddler.Session> oAllSessions = new List<Fiddler.Session>();
            Fiddler.Session amfshuju;

            //Fiddler.FiddlerApplication.SetAppDisplayName("FiddlerCoreDemoApp");   //命名，没啥卵用


            Fiddler.FiddlerApplication.AfterSessionComplete += delegate(Fiddler.Session oS)
            {
                //确定返回值正确
                if (oS.fullUrl == "http://otome-a.smq.jp/flash/gateway.php")
                {
                    if (oS.responseCode == 200)
                    {
                        amfshuju = oS;
                        fiddler.decodeamf(amfshuju);
                        #region 数据输入
                        if (fiddler.zt_flag==0)
                        {
                            youshou_1.Text = fiddler.r_hand_x_name;
                            zuoshou_1.Text = fiddler.l_hand_x_name;
                            ti_1.Text = fiddler.yifu_x_name;
                            zhi_1.Text = fiddler.ring_x_name;
                            shou_1.Text = fiddler.necklace_x_name;

                            ka1_1.Text = fiddler.card1_name;

                            if (fiddler.card1_name!="")
                            {
                                if (Dict.card_tupo_dict.ContainsKey(fiddler.card1_id))
                                {
                                    ka1_cb_1.SelectedIndex = Convert.ToInt32(fiddler.card1_class);
                                }
                                else
                                {
                                    ka1_cb_1.SelectedIndex = Convert.ToInt32(fiddler.card1_class) - 1;
                                }
                            }
                            else
                            {
                                ka1_cb_1.SelectedIndex = 0;
                            }
                            

                            ka2_1.Text = fiddler.card2_name;
                            if (fiddler.card2_name != "")
                            {
                                if (Dict.card_tupo_dict.ContainsKey(fiddler.card2_id))
                                {
                                    ka2_cb_1.SelectedIndex = Convert.ToInt32(fiddler.card2_class);
                                }
                                else
                                {
                                    ka2_cb_1.SelectedIndex = Convert.ToInt32(fiddler.card2_class) - 1;
                                }
                            }
                            else
                            {
                                ka2_cb_1.SelectedIndex = 0;
                            }

                            ka3_1.Text = fiddler.card3_name;
                            if (fiddler.card3_name != "")
                            {
                                if (Dict.card_tupo_dict.ContainsKey(fiddler.card3_id))
                                {
                                    ka3_cb_1.SelectedIndex = Convert.ToInt32(fiddler.card3_class);
                                }
                                else
                                {
                                    ka3_cb_1.SelectedIndex = Convert.ToInt32(fiddler.card3_class) - 1;
                                }
                            }
                            else
                            {
                                ka3_cb_1.SelectedIndex = 0;
                            }


                            zj_chaxun_click();
                        }
                        else if (fiddler.zt_flag==1)
                        {
                            youshou_2.Text = fiddler.r_hand_x_name;
                            zuoshou_2.Text = fiddler.l_hand_x_name;
                            ti_2.Text = fiddler.yifu_x_name;
                            zhi_2.Text = fiddler.ring_x_name;
                            shou_2.Text = fiddler.necklace_x_name;

                            ka1_2.Text = fiddler.card1_name;
                            if (fiddler.card1_name != "")
                            {
                                if (Dict.card_tupo_dict.ContainsKey(fiddler.card1_id))
                                {
                                    ka1_cb_2.SelectedIndex = Convert.ToInt32(fiddler.card1_class);
                                }
                                else
                                {
                                    ka1_cb_2.SelectedIndex = Convert.ToInt32(fiddler.card1_class) - 1;
                                }
                            }
                            else
                            {
                                ka1_cb_2.SelectedIndex = 0;
                            }

                            ka2_2.Text = fiddler.card2_name;
                            if (fiddler.card2_name != "")
                            {
                                if (Dict.card_tupo_dict.ContainsKey(fiddler.card2_id))
                                {
                                    ka2_cb_2.SelectedIndex = Convert.ToInt32(fiddler.card2_class);
                                }
                                else
                                {
                                    ka2_cb_2.SelectedIndex = Convert.ToInt32(fiddler.card2_class) - 1;
                                }
                            }
                            else
                            {
                                ka2_cb_2.SelectedIndex = 0;
                            }

                            ka3_2.Text = fiddler.card3_name;
                            if (fiddler.card3_name != "")
                            {
                                if (Dict.card_tupo_dict.ContainsKey(fiddler.card3_id))
                                {
                                    ka3_cb_2.SelectedIndex = Convert.ToInt32(fiddler.card3_class);
                                }
                                else
                                {
                                    ka3_cb_2.SelectedIndex = Convert.ToInt32(fiddler.card3_class) - 1;
                                }
                            }
                            else
                            {
                                ka3_cb_2.SelectedIndex = 0;
                            }


                            dr_chaxun_click();
                            jisuan_click();
                        }
                        
                        
                        #endregion
                        

                    }
                    else
                    {
                        log_list.Items.Add(DateTime.Now.ToLongTimeString().ToString() + "\t" + "似乎炸了。错误代码");
                        //Console.WriteLine("似乎炸了。错误代码{0}", oS.responseCode);
                    }
                }
            };
            Fiddler.FiddlerApplication.OnNotification += delegate(object sender1, NotificationEventArgs oNEA) { Console.WriteLine("** NotifyUser: " + oNEA.NotifyString); };
            Fiddler.FiddlerApplication.Log.OnLogString += delegate(object sender1, LogEventArgs oLEA) { Console.WriteLine("** LogString: " + oLEA.LogString); };
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
            int iPort = 8877;


            Fiddler.FiddlerApplication.Startup(iPort, oFCSF);

            FiddlerApplication.Log.LogFormat("Created endpoint listening on port {0}", iPort);
            FiddlerApplication.Log.LogFormat("Starting with settings: [{0}]", oFCSF);
            FiddlerApplication.Log.LogFormat("Gateway: {0}", CONFIG.UpstreamGateway.ToString());

            #endregion



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
        }

        public void zj_chaxun_click()
        {
            #region 武器查询
            if (youshou_1.Text.ToString().IndexOf('+') == -1)
            {

                Chushihua.wuqi_name = youshou_1.Text.ToString();
                Chushihua.wuqi_qianghua = 0;
            }
            else
            {
                Chushihua.wuqi_name = youshou_1.Text.ToString().Substring(0, (youshou_1.Text.ToString().IndexOf('+') - 1));
                Chushihua.wuqi_qianghua = int.Parse(youshou_1.Text.ToString().Substring((youshou_1.Text.ToString().IndexOf('+') + 1), ((youshou_1.Text.ToString().Length - (youshou_1.Text.ToString().IndexOf('+') + 1)))));
            }

            if (Chushihua.wuqi_name != "")
            {
                if (Dict.wuqi_dict.ContainsKey(Chushihua.wuqi_name))
                {
                    Dict.wuqi_dict.TryGetValue(Chushihua.wuqi_name, out Chushihua.wuqi_duiying);
                }
                else
                {
                    //炸了
                    log_list.Items.Add(DateTime.Now.ToLongTimeString().ToString()+"\t"+"武器未找到，检查是否输入错误\n如未在列表中找到，请回帖报告\n(默认按无装备替代)");
                    
                    Dict.wuqi_dict.TryGetValue("なし", out Chushihua.wuqi_duiying);
                }
            }
            else
            {
                Dict.wuqi_dict.TryGetValue("なし", out Chushihua.wuqi_duiying);
            }
            #endregion

            #region 盾查询

            if (zuoshou_1.Text.ToString().IndexOf('+') == -1)
            {

                Chushihua.dun_name = zuoshou_1.Text.ToString();
                Chushihua.dun_qianghua = 0;
            }
            else
            {
                Chushihua.dun_name = zuoshou_1.Text.ToString().Substring(0, (zuoshou_1.Text.ToString().IndexOf('+') - 1));
                Chushihua.dun_qianghua = int.Parse(zuoshou_1.Text.ToString().Substring((zuoshou_1.Text.ToString().IndexOf('+') + 1), ((zuoshou_1.Text.ToString().Length - (zuoshou_1.Text.ToString().IndexOf('+') + 1)))));
            }


            if (Chushihua.dun_name != "")
            {
                if (Dict.dun_dict.ContainsKey(Chushihua.dun_name))
                {
                    Dict.dun_dict.TryGetValue(Chushihua.dun_name, out Chushihua.dun_duiying);
                }
                else
                {
                    log_list.Items.Add(DateTime.Now.ToLongTimeString().ToString() + "\t" + "盾未找到，检查是否输入错误\n如未在列表中找到，请回帖报告\n(默认按无装备替代)");
                    
                    Dict.dun_dict.TryGetValue("なし", out Chushihua.dun_duiying);

                }
            }
            else
            {
                Dict.dun_dict.TryGetValue("なし", out Chushihua.dun_duiying);
            }
            #endregion

            #region 衣服查询

            if (ti_1.Text.ToString().IndexOf('+') == -1)
            {

                Chushihua.yifu_name = ti_1.Text.ToString();
                Chushihua.yifu_qianghua = 0;
            }
            else
            {
                Chushihua.yifu_name = ti_1.Text.ToString().Substring(0, (ti_1.Text.ToString().IndexOf('+') - 1));
                Chushihua.yifu_qianghua = int.Parse(ti_1.Text.ToString().Substring((ti_1.Text.ToString().IndexOf('+') + 1), ((ti_1.Text.ToString().Length - (ti_1.Text.ToString().IndexOf('+') + 1)))));
            }

            if (Chushihua.yifu_name != "")
            {
                if (Dict.yifu_dict.ContainsKey(Chushihua.yifu_name))
                {
                    Dict.yifu_dict.TryGetValue(Chushihua.yifu_name, out Chushihua.yifu_duiying);
                }
                else
                {
                    log_list.Items.Add(DateTime.Now.ToLongTimeString().ToString() + "\t" + "衣服未找到，检查是否输入错误\n如未在列表中找到，请回帖报告\n(默认按无装备替代)");
                    Dict.yifu_dict.TryGetValue("なし", out Chushihua.yifu_duiying);

                }
            }
            else
            {
                Dict.yifu_dict.TryGetValue("なし", out Chushihua.yifu_duiying);
            }
            #endregion

            #region 指查询

            if (zhi_1.Text.ToString().IndexOf('+') == -1)
            {

                Chushihua.zhi_name = zhi_1.Text.ToString();
                Chushihua.zhi_qianghua = 0;
            }
            else
            {
                Chushihua.zhi_name = zhi_1.Text.ToString().Substring(0, (zhi_1.Text.ToString().IndexOf('+') - 1));
                Chushihua.zhi_qianghua = int.Parse(zhi_1.Text.ToString().Substring((zhi_1.Text.ToString().IndexOf('+') + 1), ((zhi_1.Text.ToString().Length - (zhi_1.Text.ToString().IndexOf('+') + 1)))));
            }

            if (Chushihua.zhi_name != "")
            {
                if (Dict.zhi_dict.ContainsKey(Chushihua.zhi_name))
                {
                    Dict.zhi_dict.TryGetValue(Chushihua.zhi_name, out Chushihua.zhi_duiying);
                }
                else
                {
                    log_list.Items.Add(DateTime.Now.ToLongTimeString().ToString() + "\t" + "戒指未找到，检查是否输入错误\n如未在列表中找到，请回帖报告\n(默认按无装备替代)");
                    Dict.zhi_dict.TryGetValue("なし", out Chushihua.zhi_duiying);

                }
            }
            else
            {
                Dict.zhi_dict.TryGetValue("なし", out Chushihua.zhi_duiying);
            }
            #endregion

            #region 首查询

            if (shou_1.Text.ToString().IndexOf('+') == -1)
            {

                Chushihua.shou_name = shou_1.Text.ToString();
                Chushihua.shou_qianghua = 0;
            }
            else
            {
                Chushihua.shou_name = shou_1.Text.ToString().Substring(0, (shou_1.Text.ToString().IndexOf('+') - 1));
                Chushihua.shou_qianghua = int.Parse(shou_1.Text.ToString().Substring((shou_1.Text.ToString().IndexOf('+') + 1), ((shou_1.Text.ToString().Length - (shou_1.Text.ToString().IndexOf('+') + 1)))));
            }

            if (Chushihua.shou_name != "")
            {
                if (Dict.shou_dict.ContainsKey(Chushihua.shou_name))
                {
                    Dict.shou_dict.TryGetValue(Chushihua.shou_name, out Chushihua.shou_duiying);
                }
                else
                {
                    log_list.Items.Add(DateTime.Now.ToLongTimeString().ToString() + "\t" + "项链未找到，检查是否输入错误\n如未在列表中找到，请回帖报告\n(默认按无装备替代)");
                    Dict.shou_dict.TryGetValue("なし", out Chushihua.shou_duiying);

                }
            }
            else
            {
                Dict.shou_dict.TryGetValue("なし", out Chushihua.shou_duiying);
            }
            #endregion

            #region 卡1查询
            Chushihua.card1_name = ka1_1.Text.ToString();
            Chushihua.card1_jieduan = ka1_cb_1.SelectedIndex;
            if (Chushihua.card1_name != "")
            {
                if (Dict.card_dict.ContainsKey(Chushihua.card1_name))
                {
                    Dict.card_dict.TryGetValue(Chushihua.card1_name, out Chushihua.card1_duiying);
                }
                else
                {
                    log_list.Items.Add(DateTime.Now.ToLongTimeString().ToString() + "\t" + "卡1未找到，检查是否输入错误\n如未在列表中找到，请回帖报告\n(默认按无装备替代)");
                    Dict.card_dict.TryGetValue("なし", out Chushihua.card1_duiying);
                    Chushihua.card1_jieduan = 0;
                }
            }
            else
            {
                Dict.card_dict.TryGetValue("なし", out Chushihua.card1_duiying);
                Chushihua.card1_jieduan = 0;
            }
            #endregion

            #region 卡2查询
            Chushihua.card2_name = ka2_1.Text.ToString();
            Chushihua.card2_jieduan = ka2_cb_1.SelectedIndex;
            if (Chushihua.card2_name != "")
            {
                if (Dict.card_dict.ContainsKey(Chushihua.card2_name))
                {
                    Dict.card_dict.TryGetValue(Chushihua.card2_name, out Chushihua.card2_duiying);
                }
                else
                {
                    log_list.Items.Add(DateTime.Now.ToLongTimeString().ToString() + "\t" + "卡2未找到，检查是否输入错误\n如未在列表中找到，请回帖报告\n(默认按无装备替代)");
                    Dict.card_dict.TryGetValue("なし", out Chushihua.card2_duiying);
                    Chushihua.card2_jieduan = 0;
                }
            }
            else
            {
                Dict.card_dict.TryGetValue("なし", out Chushihua.card2_duiying);
                Chushihua.card2_jieduan = 0;
            }
            #endregion

            #region 卡3查询
            Chushihua.card3_name = ka3_1.Text.ToString();
            Chushihua.card3_jieduan = ka3_cb_1.SelectedIndex;
            if (Chushihua.card3_name != "")
            {
                if (Dict.card_dict.ContainsKey(Chushihua.card3_name))
                {
                    Dict.card_dict.TryGetValue(Chushihua.card3_name, out Chushihua.card3_duiying);
                }
                else
                {
                    log_list.Items.Add(DateTime.Now.ToLongTimeString().ToString() + "\t" + "卡3未找到，检查是否输入错误\n如未在列表中找到，请回帖报告\n(默认按无装备替代)");
                    Dict.card_dict.TryGetValue("なし", out Chushihua.card3_duiying);
                    Chushihua.card3_jieduan = 0;
                }
            }
            else
            {
                Dict.card_dict.TryGetValue("なし", out Chushihua.card3_duiying);
                Chushihua.card3_jieduan = 0;
            }
            #endregion


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
            #region 武器查询
            if (youshou_2.Text.ToString().IndexOf('+') == -1)
            {

                Chushihua.wuqi_name = youshou_2.Text.ToString();
                Chushihua.wuqi_qianghua = 0;
            }
            else
            {
                Chushihua.wuqi_name = youshou_2.Text.ToString().Substring(0, (youshou_2.Text.ToString().IndexOf('+') - 1));
                Chushihua.wuqi_qianghua = int.Parse(youshou_2.Text.ToString().Substring((youshou_2.Text.ToString().IndexOf('+') + 1), ((youshou_2.Text.ToString().Length - (youshou_2.Text.ToString().IndexOf('+') + 1)))));
            }

            if (Chushihua.wuqi_name != "")
            {
                if (Dict.wuqi_dict.ContainsKey(Chushihua.wuqi_name))
                {
                    Dict.wuqi_dict.TryGetValue(Chushihua.wuqi_name, out Chushihua.wuqi_duiying);
                }
                else
                {
                    //炸了
                    log_list.Items.Add(DateTime.Now.ToLongTimeString().ToString() + "\t" + "武器未找到，检查是否输入错误\n如未在列表中找到，请回帖报告\n(默认按无装备替代)");

                    Dict.wuqi_dict.TryGetValue("なし", out Chushihua.wuqi_duiying);
                }
            }
            else
            {
                Dict.wuqi_dict.TryGetValue("なし", out Chushihua.wuqi_duiying);
            }
            #endregion

            #region 盾查询

            if (zuoshou_2.Text.ToString().IndexOf('+') == -1)
            {

                Chushihua.dun_name = zuoshou_2.Text.ToString();
                Chushihua.dun_qianghua = 0;
            }
            else
            {
                Chushihua.dun_name = zuoshou_2.Text.ToString().Substring(0, (zuoshou_2.Text.ToString().IndexOf('+') - 1));
                Chushihua.dun_qianghua = int.Parse(zuoshou_2.Text.ToString().Substring((zuoshou_2.Text.ToString().IndexOf('+') + 1), ((zuoshou_2.Text.ToString().Length - (zuoshou_2.Text.ToString().IndexOf('+') + 1)))));
            }


            if (Chushihua.dun_name != "")
            {
                if (Dict.dun_dict.ContainsKey(Chushihua.dun_name))
                {
                    Dict.dun_dict.TryGetValue(Chushihua.dun_name, out Chushihua.dun_duiying);
                }
                else
                {
                    log_list.Items.Add(DateTime.Now.ToLongTimeString().ToString() + "\t" + "盾未找到，检查是否输入错误\n如未在列表中找到，请回帖报告\n(默认按无装备替代)");
                    Dict.dun_dict.TryGetValue("なし", out Chushihua.dun_duiying);

                }
            }
            else
            {
                Dict.dun_dict.TryGetValue("なし", out Chushihua.dun_duiying);
            }
            #endregion

            #region 衣服查询

            if (ti_2.Text.ToString().IndexOf('+') == -1)
            {

                Chushihua.yifu_name = ti_2.Text.ToString();
                Chushihua.yifu_qianghua = 0;
            }
            else
            {
                Chushihua.yifu_name = ti_2.Text.ToString().Substring(0, (ti_2.Text.ToString().IndexOf('+') - 1));
                Chushihua.yifu_qianghua = int.Parse(ti_2.Text.ToString().Substring((ti_2.Text.ToString().IndexOf('+') + 1), ((ti_2.Text.ToString().Length - (ti_2.Text.ToString().IndexOf('+') + 1)))));
            }

            if (Chushihua.yifu_name != "")
            {
                if (Dict.yifu_dict.ContainsKey(Chushihua.yifu_name))
                {
                    Dict.yifu_dict.TryGetValue(Chushihua.yifu_name, out Chushihua.yifu_duiying);
                }
                else
                {
                    log_list.Items.Add(DateTime.Now.ToLongTimeString().ToString() + "\t" + "衣服未找到，检查是否输入错误\n如未在列表中找到，请回帖报告\n(默认按无装备替代)");
                    Dict.yifu_dict.TryGetValue("なし", out Chushihua.yifu_duiying);

                }
            }
            else
            {
                Dict.yifu_dict.TryGetValue("なし", out Chushihua.yifu_duiying);
            }
            #endregion

            #region 指查询

            if (zhi_2.Text.ToString().IndexOf('+') == -1)
            {

                Chushihua.zhi_name = zhi_2.Text.ToString();
                Chushihua.zhi_qianghua = 0;
            }
            else
            {
                Chushihua.zhi_name = zhi_2.Text.ToString().Substring(0, (zhi_2.Text.ToString().IndexOf('+') - 1));
                Chushihua.zhi_qianghua = int.Parse(zhi_2.Text.ToString().Substring((zhi_2.Text.ToString().IndexOf('+') + 1), ((zhi_2.Text.ToString().Length - (zhi_2.Text.ToString().IndexOf('+') + 1)))));
            }

            if (Chushihua.zhi_name != "")
            {
                if (Dict.zhi_dict.ContainsKey(Chushihua.zhi_name))
                {
                    Dict.zhi_dict.TryGetValue(Chushihua.zhi_name, out Chushihua.zhi_duiying);
                }
                else
                {
                    log_list.Items.Add(DateTime.Now.ToLongTimeString().ToString() + "\t" + "戒指未找到，检查是否输入错误\n如未在列表中找到，请回帖报告\n(默认按无装备替代)");
                    Dict.zhi_dict.TryGetValue("なし", out Chushihua.zhi_duiying);

                }
            }
            else
            {
                Dict.zhi_dict.TryGetValue("なし", out Chushihua.zhi_duiying);
            }
            #endregion

            #region 首查询

            if (shou_2.Text.ToString().IndexOf('+') == -1)
            {

                Chushihua.shou_name = shou_2.Text.ToString();
                Chushihua.shou_qianghua = 0;
            }
            else
            {
                Chushihua.shou_name = shou_2.Text.ToString().Substring(0, (shou_2.Text.ToString().IndexOf('+') - 1));
                Chushihua.shou_qianghua = int.Parse(shou_2.Text.ToString().Substring((shou_2.Text.ToString().IndexOf('+') + 1), ((shou_2.Text.ToString().Length - (shou_2.Text.ToString().IndexOf('+') + 1)))));
            }

            if (Chushihua.shou_name != "")
            {
                if (Dict.shou_dict.ContainsKey(Chushihua.shou_name))
                {
                    Dict.shou_dict.TryGetValue(Chushihua.shou_name, out Chushihua.shou_duiying);
                }
                else
                {
                    log_list.Items.Add(DateTime.Now.ToLongTimeString().ToString() + "\t" + "项链未找到，检查是否输入错误\n如未在列表中找到，请回帖报告\n(默认按无装备替代)");
                    Dict.shou_dict.TryGetValue("なし", out Chushihua.shou_duiying);

                }
            }
            else
            {
                Dict.shou_dict.TryGetValue("なし", out Chushihua.shou_duiying);
            }
            #endregion

            #region 卡1查询
            Chushihua.card1_name = ka1_2.Text.ToString();
            Chushihua.card1_jieduan = ka1_cb_2.SelectedIndex;
            if (Chushihua.card1_name != "")
            {
                if (Dict.card_dict.ContainsKey(Chushihua.card1_name))
                {
                    Dict.card_dict.TryGetValue(Chushihua.card1_name, out Chushihua.card1_duiying);
                }
                else
                {
                    log_list.Items.Add(DateTime.Now.ToLongTimeString().ToString() + "\t" + "卡1未找到，检查是否输入错误\n如未在列表中找到，请回帖报告\n(默认按无装备替代)");
                    Dict.card_dict.TryGetValue("なし", out Chushihua.card1_duiying);
                    Chushihua.card1_jieduan = 0;
                }
            }
            else
            {
                Dict.card_dict.TryGetValue("なし", out Chushihua.card1_duiying);
                Chushihua.card1_jieduan = 0;
            }
            #endregion

            #region 卡2查询
            Chushihua.card2_name = ka2_2.Text.ToString();
            Chushihua.card2_jieduan = ka2_cb_2.SelectedIndex;
            if (Chushihua.card2_name != "")
            {
                if (Dict.card_dict.ContainsKey(Chushihua.card2_name))
                {
                    Dict.card_dict.TryGetValue(Chushihua.card2_name, out Chushihua.card2_duiying);
                }
                else
                {
                    log_list.Items.Add(DateTime.Now.ToLongTimeString().ToString() + "\t" + "卡2未找到，检查是否输入错误\n如未在列表中找到，请回帖报告\n(默认按无装备替代)");
                    Dict.card_dict.TryGetValue("なし", out Chushihua.card2_duiying);
                    Chushihua.card2_jieduan = 0;
                }
            }
            else
            {
                Dict.card_dict.TryGetValue("なし", out Chushihua.card2_duiying);
                Chushihua.card2_jieduan = 0;
            }
            #endregion

            #region 卡3查询
            Chushihua.card3_name = ka3_2.Text.ToString();
            Chushihua.card3_jieduan = ka3_cb_2.SelectedIndex;
            if (Chushihua.card3_name != "")
            {
                if (Dict.card_dict.ContainsKey(Chushihua.card3_name))
                {
                    Dict.card_dict.TryGetValue(Chushihua.card3_name, out Chushihua.card3_duiying);
                }
                else
                {
                    log_list.Items.Add(DateTime.Now.ToLongTimeString().ToString() + "\t" + "卡3未找到，检查是否输入错误\n如未在列表中找到，请回帖报告\n(默认按无装备替代)");
                    Dict.card_dict.TryGetValue("なし", out Chushihua.card3_duiying);
                    Chushihua.card3_jieduan = 0;
                }
            }
            else
            {
                Dict.card_dict.TryGetValue("なし", out Chushihua.card3_duiying);
                Chushihua.card3_jieduan = 0;
            }
            #endregion


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
                log_list.Items.Add(DateTime.Now.ToLongTimeString().ToString() + "\t" + "boom");
            }
            else
            {
                zhandou asd = new zhandou();
                jieguo.Text = asd.jisuan(ziji, ziji_1, ziji_2, ziji_3, diren, diren_1, diren_2, diren_3) + "/10000";
            }
        }
    }


}
