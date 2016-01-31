using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace low
{
    class Chushihua
    {
        public static string card1_name = "";
        public static Carddata card1_duiying;
        public static int card1_jieduan;

        public static string card2_name = "";
        public static Carddata card2_duiying;
        public static int card2_jieduan;

        public static string card3_name = "";
        public static Carddata card3_duiying;
        public static int card3_jieduan;

        public static string wuqi_name = "";
        public static int[] wuqi_duiying;
        public static int wuqi_qianghua;

        public static string dun_name = "";
        public static int[] dun_duiying;
        public static int dun_qianghua;

        public static string yifu_name = "";
        public static int[] yifu_duiying;
        public static int yifu_qianghua;

        public static string zhi_name = "";
        public static int[] zhi_duiying;
        public static int zhi_qianghua;

        public static string shou_name = "";
        public static int[] shou_duiying;
        public static int shou_qianghua;



        public static void chushihua()
        {
            //卡初始化
            string card_json = Card_datastr.cardstr;
            Cardpeizhi card_obj = JsonConvert.DeserializeObject<Cardpeizhi>(card_json);
            card_json = null;
            Dict.card_zhuangzai(card_obj);

            //武器初始化
            string wuqi_json = Wuqi_datastr.wuqistr;
            Wuqipeizhi wuqi_obj = JsonConvert.DeserializeObject<Wuqipeizhi>(wuqi_json);
            wuqi_json = null;
            Dict.wuqi_zhuangzai(wuqi_obj);

            //盾初始化
            string dun_json = Dun_datastr.dunstr;
            Dunpeizhi dun_obj = JsonConvert.DeserializeObject<Dunpeizhi>(dun_json);
            dun_json = null;
            Dict.dun_zhuangzai(dun_obj);

            //衣服初始化
            string yifu_json = Yifu_datastr.yifustr;
            Yifupeizhi yifu_obj = JsonConvert.DeserializeObject<Yifupeizhi>(yifu_json);
            yifu_json = null;
            Dict.yifu_zhuangzai(yifu_obj);

            //指初始化
            string zhi_json = Zhi_datastr.zhistr;
            Zhipeizhi zhi_obj = JsonConvert.DeserializeObject<Zhipeizhi>(zhi_json);
            zhi_json = null;
            Dict.zhi_zhuangzai(zhi_obj);

            //首初始化
            string shou_json = Shou_datastr.shoustr;
            Shoupeizhi shou_obj = JsonConvert.DeserializeObject<Shoupeizhi>(shou_json);
            shou_json = null;
            Dict.shou_zhuangzai(shou_obj);



        }


    }
    /// <summary>
    /// 骑士配置
    /// </summary>
    class kssmpeizhi
    {
        //kssm
       static int wuligongji ;
       static int mofagongji;
       static int wulifangyu ;
       static int mofafangyu ;
       static int critical ;
       static int balance ;
       static int shuxingzhi;
       static shuxingleixing shuxingtype;

       static int[][] shuxing;

       static int  wulichengzhang;
       static int  mofachengzhang;

        
        public static kssm peizhi()
        {
            wuligongji = 10;
            mofagongji = 10;
            wulifangyu = 10;
            mofafangyu = 10;
            critical = 10;
            balance = 5;
            shuxingzhi = 0;
             shuxingtype = 0;
            
            shuxing = new int[4][] { new int[] { 0, 0 }, new int[] { 0, 1 }, new int[] { 0, 2 }, new int[] { 0, 3 } };









            //武器
            if (Chushihua.wuqi_duiying[8] == 0)
            {
                wulichengzhang = 5;
                mofachengzhang = 0;
            }
            else
            {
                wulichengzhang = 0;
                mofachengzhang = 5;
            }

            wuligongji = wuligongji + Chushihua.wuqi_duiying[0] * (100 + wulichengzhang * Chushihua.wuqi_qianghua) / 100;
            mofagongji = mofagongji + Chushihua.wuqi_duiying[1] * (100 + mofachengzhang * Chushihua.wuqi_qianghua) / 100;
            wulifangyu = wulifangyu + Chushihua.wuqi_duiying[2];
            mofafangyu = mofafangyu + Chushihua.wuqi_duiying[3];
            critical = critical + Chushihua.wuqi_duiying[4];
            balance = balance + Chushihua.wuqi_duiying[5];

            if (Chushihua.wuqi_duiying[6] != -1)
            {
                shuxing[Chushihua.wuqi_duiying[6]][0] = shuxing[Chushihua.wuqi_duiying[6]][0] + Chushihua.wuqi_duiying[7];
            }


            //盾
            if (Chushihua.dun_duiying[8] == 0)
            {
                wulichengzhang = 2;
                mofachengzhang = 3;
            }
            else
            {
                wulichengzhang = 3;
                mofachengzhang = 2;
            }

            wuligongji = wuligongji + Chushihua.dun_duiying[0];
            mofagongji = mofagongji + Chushihua.dun_duiying[1];
            wulifangyu = wulifangyu + Chushihua.dun_duiying[2] * (100 + wulichengzhang * Chushihua.dun_qianghua) / 100;
            mofafangyu = mofafangyu + Chushihua.dun_duiying[3] * (100 + mofachengzhang * Chushihua.dun_qianghua) / 100;
            critical = critical + Chushihua.dun_duiying[4];
            balance = balance + Chushihua.dun_duiying[5];

            if (Chushihua.dun_duiying[6] != -1)
            {
                shuxing[Chushihua.dun_duiying[6]][0] = shuxing[Chushihua.dun_duiying[6]][0] + Chushihua.dun_duiying[7];
            }


            //衣服
            if (Chushihua.yifu_duiying[8] == 0)
            {
                wulichengzhang = 5;
                mofachengzhang = 2;
            }
            else
            {
                wulichengzhang = 2;
                mofachengzhang = 5;
            }

            wuligongji = wuligongji + Chushihua.yifu_duiying[0];
            mofagongji = mofagongji + Chushihua.yifu_duiying[1];
            wulifangyu = wulifangyu + Chushihua.yifu_duiying[2] * (100 + wulichengzhang * Chushihua.yifu_qianghua) / 100;
            mofafangyu = mofafangyu + Chushihua.yifu_duiying[3] * (100 + mofachengzhang * Chushihua.yifu_qianghua) / 100;
            critical = critical + Chushihua.yifu_duiying[4];
            balance = balance + Chushihua.yifu_duiying[5];

            if (Chushihua.yifu_duiying[6] != -1)
            {
                shuxing[Chushihua.yifu_duiying[6]][0] = shuxing[Chushihua.yifu_duiying[6]][0] + Chushihua.yifu_duiying[7];
            }

            //指
            wuligongji = wuligongji + Chushihua.zhi_duiying[0] * (100 + 5 * Chushihua.zhi_qianghua) / 100;
            mofagongji = mofagongji + Chushihua.zhi_duiying[1] * (100 + 5 * Chushihua.zhi_qianghua) / 100;
            wulifangyu = wulifangyu + Chushihua.zhi_duiying[2] * (100 + 5 * Chushihua.zhi_qianghua) / 100;
            mofafangyu = mofafangyu + Chushihua.zhi_duiying[3] * (100 + 5 * Chushihua.zhi_qianghua) / 100;
            critical = critical + Chushihua.zhi_duiying[4];
            balance = balance + Chushihua.zhi_duiying[5];

            if (Chushihua.zhi_duiying[6] != -1)
            {
                shuxing[Chushihua.zhi_duiying[6]][0] = shuxing[Chushihua.zhi_duiying[6]][0] + Chushihua.zhi_duiying[7];
            }


            //首
            wuligongji = wuligongji + Chushihua.shou_duiying[0] * (100 + 5 * Chushihua.shou_qianghua) / 100;
            mofagongji = mofagongji + Chushihua.shou_duiying[1] * (100 + 5 * Chushihua.shou_qianghua) / 100;
            wulifangyu = wulifangyu + Chushihua.shou_duiying[2] * (100 + 5 * Chushihua.shou_qianghua) / 100;
            mofafangyu = mofafangyu + Chushihua.shou_duiying[3] * (100 + 5 * Chushihua.shou_qianghua) / 100;
            critical = critical + Chushihua.shou_duiying[4];
            balance = balance + Chushihua.shou_duiying[5];

            if (Chushihua.shou_duiying[6] != -1)
            {
                shuxing[Chushihua.shou_duiying[6]][0] = shuxing[Chushihua.shou_duiying[6]][0] + Chushihua.shou_duiying[7];
            }

            shuxingjisuan();

            kssm kssm_obj = new kssm(wuligongji, mofagongji, wulifangyu, mofafangyu, balance, critical, shuxingzhi, shuxingtype);

            return kssm_obj;
        }
        public static void shuxingjisuan()
        {
            if (shuxing[0][0] == 0 && shuxing[1][0] == 0 && shuxing[2][0] == 0 && shuxing[3][0] == 0)
            {
                shuxingtype = 0;
                shuxingzhi = 0;
            }
            else
            {
                int max = 0, maxweizhi = 0, temp1 = 0, temp2 = 0;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (shuxing[j][0] > max)
                        {
                            max = shuxing[j][0];
                            maxweizhi = j;
                        }
                    }
                    if (shuxing[i][0]>max)
                    {
                        temp1 = shuxing[i][0];
                        temp2 = shuxing[i][1];
                        shuxing[i][0] = shuxing[maxweizhi][0];
                        shuxing[i][1] = shuxing[maxweizhi][1];
                        shuxing[maxweizhi][0] = temp1;
                        shuxing[maxweizhi][1] = temp2;
                    }
                    max = 0; maxweizhi = 0;
                    
                    
                    
                }

                if (shuxing[0][0] == shuxing[1][0])
                {
                    if (shuxing[1][0] == shuxing[2][0])
                    {
                        if (shuxing[2][0] == shuxing[3][0])
                        {
                            shuxingtype = shuxingleixing.earth;
                            shuxingzhi = shuxing[0][0];
                        }
                        else
                        {
                            switch (shuxing[3][1])
                            {
                                case 0: shuxingtype = shuxingleixing.water; break;
                                case 1: shuxingtype = shuxingleixing.earth; break;
                                case 2: shuxingtype = shuxingleixing.earth; break;
                                case 3: shuxingtype = shuxingleixing.earth; break;
                                default:
                                    break;
                            }
                            shuxingzhi = shuxing[0][0];
                        }
                    }
                    else
                    {
                        if (shuxing[0][1] < shuxing[1][1])
                        {
                            shuxingtype = (shuxingleixing)shuxing[0][1];
                            shuxingzhi = shuxing[0][0];
                        }
                        else
                        {
                            shuxingtype = (shuxingleixing)shuxing[1][1];
                            shuxingzhi = shuxing[1][0];
                        }
                    }
                }
                else
                {
                    shuxingtype = (shuxingleixing)shuxing[0][1];
                    shuxingzhi = shuxing[0][0];
                }

            }

        }
    }





}
