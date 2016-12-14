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
        public static int[] wuqi_duiying = new int[9];
        public static int wuqi_qianghua;

        public static string dun_name = "";
        public static int[] dun_duiying = new int[9];
        public static int dun_qianghua;

        public static string yifu_name = "";
        public static int[] yifu_duiying = new int[9];
        public static int yifu_qianghua;

        public static string zhilun_name = "";
        public static int[] zhilun_duiying = new int[8];
        public static int zhilun_qianghua;

        public static string shou_name = "";
        public static int[] shou_duiying = new int[8];
        public static int shou_qianghua;




    }
    /// <summary>
    /// 骑士配置
    /// </summary>
    class kssmzhuangzai
    {

        static int wuligongji;
        static int mofagongji;
        static int wulifangyu;
        static int mofafangyu;
        static int critical;
        static int balance;
        static int shuxingzhi;
        static shuxingleixing shuxingtype;

        static int[][] shuxing;

        static int wulichengzhang;
        static int mofachengzhang;


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
            wuligongji = wuligongji + Chushihua.zhilun_duiying[0] * (100 + 5 * Chushihua.zhilun_qianghua) / 100;
            mofagongji = mofagongji + Chushihua.zhilun_duiying[1] * (100 + 5 * Chushihua.zhilun_qianghua) / 100;
            wulifangyu = wulifangyu + Chushihua.zhilun_duiying[2] * (100 + 5 * Chushihua.zhilun_qianghua) / 100;
            mofafangyu = mofafangyu + Chushihua.zhilun_duiying[3] * (100 + 5 * Chushihua.zhilun_qianghua) / 100;
            critical = critical + Chushihua.zhilun_duiying[4];
            balance = balance + Chushihua.zhilun_duiying[5];

            if (Chushihua.zhilun_duiying[6] != -1)
            {
                shuxing[Chushihua.zhilun_duiying[6]][0] = shuxing[Chushihua.zhilun_duiying[6]][0] + Chushihua.zhilun_duiying[7];
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
                    if (shuxing[i][0] > max)
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


    /// <summary>
    /// 卡配置
    /// </summary>
    class cardzhuangzai
    {

        static bool card_cunzai = true;
        static wulimofaleixing card_wmtype = wulimofaleixing.物理;
        static int card_atk = 0;
        static int card_sdk = 0;
        static int card_fadong = 0;//不带%
        static int card_balance = 0;
        static int card_critical = 0;
        static int card_shuxingzhi = 0;
        static shuxingleixing card_shuxingtype = 0;


        public static card peizhi(Carddata duiying, int jieduan)
        {
            int queshengflag = 1;
            card_wmtype = (wulimofaleixing)(int.Parse(duiying.type));

            card_fadong = (int)duiying.sk[jieduan];//不带%
            while (card_fadong == -1)
            {
                card_fadong = (int)duiying.sk[jieduan - queshengflag];//不带%
                queshengflag++;
            }
            queshengflag = 1;

            card_balance = (int)duiying.ba[jieduan];
            while (card_balance == -1)
            {
                card_balance = (int)duiying.ba[jieduan - queshengflag];//不带%
                queshengflag++;
            }
            queshengflag = 1;

            card_critical = (int)duiying.ct[jieduan];
            while (card_critical == -1)
            {
                card_critical = (int)duiying.ct[jieduan - queshengflag];//不带%
                queshengflag++;
            }
            queshengflag = 1;

            queshengflag = 0;
            while (duiying.elevalue[jieduan - queshengflag] == -1)
            {
                queshengflag++;
            }
            card_shuxingzhi = Convert.ToInt32((duiying.elevalue[jieduan - queshengflag] * 100) - 100);
            queshengflag = 1;

            if (duiying.eletype=="0")
            {
                card_shuxingtype=shuxingleixing.earth;
            }
            else
            {
                card_shuxingtype = (shuxingleixing)(int.Parse(duiying.eletype) - 1);
            }
            

            int adbenjimax = 0;
            int sdbenjimax = 0;

            if (jieduan == 5)
            {
                //合体卡
                adbenjimax = heti_adsdjisuan("ad", 5, duiying);
                sdbenjimax = heti_adsdjisuan("sd", 5, duiying);
            }
            else if (jieduan == 3 || jieduan == 4)
            {
                //突破 凸+
                adbenjimax = adsdjisuan("ad", jieduan, adsdjisuan("ad", 2, 0, duiying), duiying);
                sdbenjimax = adsdjisuan("sd", jieduan, adsdjisuan("sd", 2, 0, duiying), duiying);
            }
            else
            {
                //正常
                adbenjimax = adsdjisuan("ad", jieduan, 0, duiying);
                sdbenjimax = adsdjisuan("sd", jieduan, 0, duiying);
            }

            card_atk = adbenjimax;
            card_sdk = sdbenjimax;

            card card_obj = new card(card_cunzai, card_wmtype, card_atk, card_sdk, card_fadong, card_balance, card_critical, card_shuxingzhi, card_shuxingtype);

            return card_obj;

        }
        public static int adsdjisuan(string type, int jieduan, int max, Carddata duiying)
        {
            int benjimax = 0;
            for (int i = 0; i <= jieduan; i++)
            {
                if (jieduan == 0 || jieduan == 3 || jieduan == 4)
                {

                    if (type == "ad")
                    {
                        benjimax = (int)(max * 0.1 * 2 + duiying.atk.Base[jieduan]);
                        benjimax = (int)(benjimax * (1 + duiying.atk.coef[jieduan] * (duiying.level[jieduan] - 1)));
                        return benjimax;
                    }
                    else
                    {
                        benjimax = (int)(max * 0.1 * 2 + duiying.satk.Base[jieduan]);
                        benjimax = (int)(benjimax * (1 + duiying.satk.coef[jieduan] * (duiying.level[jieduan] - 1)));
                        return benjimax;
                    }

                }
                else
                {
                    benjimax = (int)(benjimax * 0.1);
                    if (type == "ad")
                    {
                        benjimax = (int)(benjimax * 2 + duiying.atk.Base[i]);
                        benjimax = (int)(benjimax * (1 + duiying.atk.coef[i] * (duiying.level[i] - 1)));
                    }
                    else
                    {
                        benjimax = (int)(benjimax * 2 + duiying.satk.Base[i]);
                        benjimax = (int)(benjimax * (1 + duiying.satk.coef[i] * (duiying.level[i] - 1)));
                    }
                }
            }
            return benjimax;
        }

        public static int heti_adsdjisuan(string type, int jieduan, Carddata duiying)
        {
            int temp;
            int benjimax = 0;
            temp = card_xml.listchaxun(duiying.combinesubname, card_xml.card_list);
            Carddata tempdata = card_xml.card_list[temp];

            benjimax = (int)(adsdjisuan(type, 2, 0, duiying) * 0.2);
            benjimax = (int)(benjimax + adsdjisuan(type, 2, 0, tempdata) * 0.2);

            if (type == "ad")
            {
                benjimax = (int)(benjimax+ duiying.atk.Base[jieduan]);
                benjimax = (int)(benjimax * (1 + duiying.atk.coef[jieduan] * (duiying.level[jieduan] - 1)));

            }
            else
            {
                benjimax = (int)(benjimax + duiying.satk.Base[jieduan]);
                benjimax = (int)(benjimax * (1 + duiying.satk.coef[jieduan] * (duiying.level[jieduan] - 1)));

            }
            return benjimax;
        }

    }

}
