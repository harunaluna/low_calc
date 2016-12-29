using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace low
{
    class fiddler
    {
        public static bool Exceptionflag=false;


        public static string l_hand_x_name;
        public static string r_hand_x_name;
        public static string yifu_x_name;
        public static string ring_x_name;
        public static string necklace_x_name;

        public static string card1_name;
        public static string card1_id;
        public static string card1_class;
        public static string card2_name;
        public static string card2_id;
        public static string card2_class;
        public static string card3_name;
        public static string card3_id;
        public static string card3_class;

        public static int zt_flag = -1;
        public static int card_no;

        public static string pxorysetting = "";
        public static void DoQuit()
        {
            Fiddler.FiddlerApplication.Shutdown();
            Thread.Sleep(500);
        }

        /// <summary>
        /// amf解析
        /// </summary>
        /// <param name="amfshuju"></param>
        public static void decodeamf(Fiddler.Session amfshuju)
        {
            try
            {
                Exceptionflag = false;
                object msg;
                byte[] byteRequest = amfshuju.RequestBody;
                byte[] byteResponse = amfshuju.ResponseBody;

                zt_flag = -1;     //进入准备画面=0 开始对战=1 对战数据包=2    其他-1；

                byte[] target = new byte[byteRequest[7]];

                for (int i = 0; i < byteRequest[7]; i++)
                {
                    target[i] = byteRequest[8 + i];
                }

                string strtarget = Encoding.UTF8.GetString(target);

                if (strtarget == "Get_Battle_Data.get_swf_battle_status")
                {
                    //进入对战画面
                    zt_flag = 0;
                }
                else if (strtarget == "Get_Battle_Data.get_swf_battle_start" || strtarget == "Get_Battle_Data.get_swf_battle_next")
                {
                    //开始对战
                    zt_flag = 1;
                }

//                 else if (strtarget == "Get_Battle_Data.get_swf_battle_exec")
//                 {
//                     //对战数据包（废弃）
//                     zt_flag = 2;
//                 }

                else
                {
                    //其他
                    zt_flag = -1;
                    return;
                }

                #region gzip

                byte[] cbytes = byteResponse;
                using (MemoryStream dms = new MemoryStream())
                {
                    using (MemoryStream cms = new MemoryStream(cbytes))
                    {
                        using (System.IO.Compression.GZipStream gzip = new System.IO.Compression.GZipStream(cms, System.IO.Compression.CompressionMode.Decompress))
                        {
                            byte[] bytes1 = new byte[512000];
                            int len = 0;
                            //读取压缩流，同时会被解压
                            while ((len = gzip.Read(cbytes, 0, cbytes.Length)) > 0)
                            {
                                dms.Write(cbytes, 0, len);
                            }
                        }
                    }
                #endregion

                    byteResponse = dms.ToArray();

                    Stream streamResponse = new MemoryStream(byteResponse);

                    AMFAPI.Deserializer amfResponse = new AMFAPI.Deserializer(streamResponse);
                    msg = amfResponse.Deserialize();
                }
                #region 数据解析

                


                List<object> body = (List<object>)msg;
                Hashtable content = (Hashtable)body[0];

                if (content["error"] != null)
                {
                    l_hand_x_name = "";
                    r_hand_x_name = "";
                    yifu_x_name = "";
                    ring_x_name = "";
                    necklace_x_name = "";

                    card1_id = "";
                    card1_name = "";
                    card1_class = "";
                    card2_id = "";
                    card2_name = "";
                    card2_class = "";
                    card3_id = "";
                    card3_name = "";
                    card3_class = "";

                    return;
                }
                Hashtable chara_data = null;
                Hashtable diren_data = null;
                Hashtable equip = null;
                ArrayList setcard = null;

//                 Hashtable battle = null;
//                 ArrayList attack = null;
//                 ArrayList e_attack = null;
// 
//                 Hashtable b_setcards = null;
//                 ArrayList b_setcard = null;
//                 ArrayList b_e_setcard = null;



                switch (zt_flag)
                {
                    case 0:
                        {
                            //我方数据解析
                            chara_data = (Hashtable)content["chara_data"];
                            if (chara_data["equip"].GetType().ToString() != "System.Collections.ArrayList")
                            {
                                equip = (Hashtable)chara_data["equip"];
                            }
                            else
                            {
                                l_hand_x_name = "";
                                r_hand_x_name = "";
                                yifu_x_name = "";
                                ring_x_name = "";
                                necklace_x_name = "";
                            }

                            setcard = (ArrayList)chara_data["setcard"];
                            break;
                        }
                    case 1:
                        {
                            //敌方数据解析
                            diren_data = (Hashtable)content["target"];



                            if (diren_data.ContainsKey("equip"))
                            {
                                equip = (Hashtable)diren_data["equip"];
                            }
                            else
                            {
                                l_hand_x_name = "";
                                r_hand_x_name = "";
                                yifu_x_name = "";
                                ring_x_name = "";
                                necklace_x_name = "";
                            }

                            setcard = (ArrayList)diren_data["setcard"];
                            break;
                        }

                    case 2:
                        {
                            #region 对战数据保存(废弃)
                            //FileStream fs = new FileStream(Application.StartupPath + "\\log.txt", FileMode.Append);

                            //StreamWriter sw = new StreamWriter(fs);

                            //battle = (Hashtable)content["battle"];
                            //attack = (ArrayList)battle["attack"];
                            //e_attack = (ArrayList)battle["e_attack"];

                            //b_setcards = (Hashtable)content["setcards"];
                            //b_setcard = (ArrayList)b_setcards["setcard"];
                            //b_e_setcard = (ArrayList)b_setcards["e_setcard"];

                            //int setcard_longger = b_setcard.Capacity;
                            //int e_setcard_longger = b_e_setcard.Capacity;

                            //int attacklonger = attack.Capacity;
                            //int e_attacklonger = e_attack.Capacity;

                            //string b_card1_name=null;
                            //string b_card2_name=null;
                            //string b_card3_name=null;

                            //string b_e_card1_name = null;
                            //string b_e_card2_name = null;
                            //string b_e_card3_name = null;

                            

                            //#region cardname
                            //for (int i = 0; i < setcard_longger; i++)
                            //{
                            //    Hashtable card_data = (Hashtable)b_setcard[i];

                            //    switch (i)
                            //    {
                            //        case 0:
                            //            {
                            //                b_card1_name = (string)card_data["card_name"];
                            //                break;

                            //            }
                            //        case 1:
                            //            {
                            //                b_card2_name = (string)card_data["card_name"];
                            //                break;
                            //            }
                            //        case 2:
                            //            {
                            //                b_card3_name = (string)card_data["card_name"];
                            //                break;
                            //            }
                            //        default:
                            //            break;
                            //    }
                            //}

                            //for (int i = 0; i < e_setcard_longger; i++)
                            //{
                            //    Hashtable card_data = (Hashtable)b_e_setcard[i];

                            //    switch (i)
                            //    {
                            //        case 0:
                            //            {
                            //                b_e_card1_name = (string)card_data["card_name"];
                            //                break;

                            //            }
                            //        case 1:
                            //            {
                            //                b_e_card2_name = (string)card_data["card_name"];
                            //                break;
                            //            }
                            //        case 2:
                            //            {
                            //                b_e_card3_name = (string)card_data["card_name"];
                            //                break;
                            //            }
                            //        default:
                            //            break;
                            //    }
                            //}
                            //#endregion

                            //#region 对战数据存入
                            //sw.WriteLine(DateTime.Now.ToLongTimeString().ToString() + "\t对战log"+" ");
                            //sw.WriteLine("我方：");
                            //for (int i = 0; i < attacklonger; i++)
                            //{
                            //    Hashtable battle_data = (Hashtable)attack[i];
                            //    int num = Convert.ToInt32(battle_data["action"]);
                            //    switch (num)
                            //    {
                            //        case 0:
                            //            {
                            //                sw.Write("kssm:" + battle_data["atk"].ToString() + "\t");
                            //                break;
                            //            }
                            //        case 1:
                            //            {
                            //                if (battle_data.ContainsKey("skill"))
                            //                {
                            //                    sw.Write(b_card1_name + ":" + battle_data["atk"].ToString() + " 技发" + "\t");
                            //                }
                            //                else
                            //                {
                            //                    sw.Write(b_card1_name + ":" + battle_data["atk"].ToString() + "\t");
                            //                }

                            //                break;
                            //            }
                            //        case 2:
                            //            {
                            //                if (battle_data.ContainsKey("skill"))
                            //                {
                            //                    sw.Write(b_card2_name + ":" + battle_data["atk"].ToString() + " 技发" + "\t");
                            //                }
                            //                else
                            //                {
                            //                    sw.Write(b_card2_name + ":" + battle_data["atk"].ToString() + "\t");
                            //                }
                            //                break;
                            //            }
                            //        case 3:
                            //            {
                            //                if (battle_data.ContainsKey("skill"))
                            //                {
                            //                    sw.Write(b_card3_name + ":" + battle_data["atk"].ToString() + " 技发" + "\t");
                            //                }
                            //                else
                            //                {
                            //                    sw.Write(b_card3_name + ":" + battle_data["atk"].ToString() + "\t");
                            //                }
                            //                break;
                            //            }
                            //        default:
                            //            break;
                            //    }
                            //}

                            //sw.WriteLine("\n敌方：");
                            //for (int i = 0; i < e_attacklonger; i++)
                            //{
                            //    Hashtable battle_data = (Hashtable)e_attack[i];
                            //    int num = Convert.ToInt32(battle_data["action"]);
                            //    switch (num)
                            //    {
                            //        case 0:
                            //            {
                            //                sw.Write("kssm:" + battle_data["atk"].ToString() + "\t");
                            //                break;
                            //            }
                            //        case 1:
                            //            {
                            //                if (battle_data.ContainsKey("skill"))
                            //                {
                            //                    sw.Write(b_e_card1_name + ":" + battle_data["atk"].ToString() + " 技发" + "\t");
                            //                }
                            //                else
                            //                {
                            //                    sw.Write(b_e_card1_name + ":" + battle_data["atk"].ToString() + "\t");
                            //                }

                            //                break;
                            //            }
                            //        case 2:
                            //            {
                            //                if (battle_data.ContainsKey("skill"))
                            //                {
                            //                    sw.Write(b_e_card2_name + ":" + battle_data["atk"].ToString() + " 技发" + "\t");
                            //                }
                            //                else
                            //                {
                            //                    sw.Write(b_e_card2_name + ":" + battle_data["atk"].ToString() + "\t");
                            //                }
                            //                break;
                            //            }
                            //        case 3:
                            //            {
                            //                if (battle_data.ContainsKey("skill"))
                            //                {
                            //                    sw.Write(b_e_card3_name + ":" + battle_data["atk"].ToString() + " 技发" + "\t");
                            //                }
                            //                else
                            //                {
                            //                    sw.Write(b_e_card3_name + ":" + battle_data["atk"].ToString() + "\t");
                            //                }
                            //                break;
                            //            }
                            //        default:
                            //            break;
                            //    }
                            //}
                            //sw.WriteLine();
                            //#endregion

                            //sw.Flush();
                            //fs.Flush();
                            //sw.Close();
                            //fs.Close();
#endregion
                            break;
                        }
                    default:
                        break;
                }

                if (equip != null)
                {
                    if (equip.ContainsKey("l_hand"))
                    {
                        ArrayList l_hand = (ArrayList)equip["l_hand"];
                        Hashtable l_hand_x = (Hashtable)l_hand[0];
                        l_hand_x_name = (string)l_hand_x["item_name"];
                    }
                    else
                    {
                        l_hand_x_name = "";
                    }

                    if (equip.ContainsKey("r_hand"))
                    {
                        ArrayList r_hand = (ArrayList)equip["r_hand"];
                        Hashtable r_hand_x = (Hashtable)r_hand[0];
                        r_hand_x_name = (string)r_hand_x["item_name"];
                    }
                    else
                    {
                        r_hand_x_name = "";
                    }
                    if (equip.ContainsKey("body"))
                    {
                        ArrayList yifu = (ArrayList)equip["body"];
                        Hashtable yifu_x = (Hashtable)yifu[0];
                        yifu_x_name = (string)yifu_x["item_name"];
                    }
                    else
                    {
                        yifu_x_name = "";
                    }
                    if (equip.ContainsKey("ring"))
                    {
                        ArrayList ring = (ArrayList)equip["ring"];
                        Hashtable ring_x = (Hashtable)ring[0];
                        ring_x_name = (string)ring_x["item_name"];
                    }
                    else
                    {
                        ring_x_name = "";
                    }
                    if (equip.ContainsKey("necklace"))
                    {
                        ArrayList necklace = (ArrayList)equip["necklace"];
                        Hashtable necklace_x = (Hashtable)necklace[0];
                        necklace_x_name = (string)necklace_x["item_name"];
                    }
                    else
                    {
                        necklace_x_name = "";
                    }

                }

                if (setcard == null)
                {
                    card_no = 0;
                }
                else
                {
                    card_no = setcard.Count;
                }

                for (int i = 1; i <= card_no; i++)
                {
                    Hashtable card = (Hashtable)setcard[i - 1];
                    string card_name = (string)card["card_name"];
                    string card_id = (string)card["card_id"];
                    string card_class = (string)card["class"];
                    switch (i)
                    {
                        case 1: { card1_id = card_id; card1_name = card_name; card1_class = card_class; break; }  //卡1
                        case 2: { card2_id = card_id; card2_name = card_name; card2_class = card_class; break; } //卡2
                        case 3: { card3_id = card_id; card3_name = card_name; card3_class = card_class; break; } //卡3
                        default:
                            break;
                    }
                }
                switch (card_no)
                {
                    case 0:
                        {
                            card1_id = "";
                            card1_name = "";
                            card1_class = "";
                            card2_id = "";
                            card2_name = "";
                            card2_class = "";
                            card3_id = "";
                            card3_name = "";
                            card3_class = "";

                        } break;
                    case 1:
                        {
                            card2_id = "";
                            card2_name = "";
                            card2_class = "";
                            card3_id = "";
                            card3_name = "";
                            card3_class = "";

                        } break;
                    case 2:
                        {
                            card3_id = "";
                            card3_name = "";
                            card3_class = "";

                        } break;
                    default:
                        break;
                }



                #endregion



            }
            catch (Exception)
            {
                Exceptionflag = true;
                //throw;
                return;
                
            }

        }



    }
}
