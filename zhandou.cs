using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace low
{
    class zhandou
    {
        //随机数定义
        private Random ran = new Random();
        //zjkssm
        private wulimofaleixing zjkssm_wmtype;
        private int zjkssm_wuligongji;
        private int zjkssm_mofagongji;
        private int zjkssm_wulifangyu;
        private int zjkssm_mofafangyu;
        private int zjkssm_balance;
        private int zjkssm_critical;
        private int zjkssm_shuxingzhi;
        private shuxingleixing zjkssm_shuxingtype;

        //drkssm
        private wulimofaleixing drkssm_wmtype;
        private int drkssm_wuligongji;
        private int drkssm_mofagongji;
        private int drkssm_wulifangyu;
        private int drkssm_mofafangyu;
        private int drkssm_balance;
        private int drkssm_critical;
        private int drkssm_shuxingzhi;
        private shuxingleixing drkssm_shuxingtype;

        //card
        private bool card_cunzai;
        private wulimofaleixing card_wmtype;
        private int card_atk;
        private int card_sdk;
        private int card_fadong;//不带%
        private int card_balance;
        private int card_critical;
        private int card_shuxingzhi;
        private shuxingleixing card_shuxingtype;

        /// <summary>
        /// 计算胜率
        /// </summary>
        /// <param name="zjkssm">自己骑士属性</param>
        /// <param name="zjcard_1">自己卡1数据</param>
        /// <param name="zjcard_2">自己卡2数据</param>
        /// <param name="zjcard_3">自己卡3数据</param>
        /// <param name="drkssm">敌人骑士属性</param>
        /// <param name="drcard_1">敌人卡1数据</param>
        /// <param name="drcard_2">敌人卡1数据</param>
        /// <param name="drcard_3">敌人卡1数据</param>
        /// <returns>胜率</returns>
        public int jisuan(kssm zjkssm, card zjcard_1, card zjcard_2, card zjcard_3, kssm drkssm, card drcard_1, card drcard_2, card drcard_3)
        {
            int shenglv = 0;
            for (int i = 0; i < 10000; i++)
            {
                int zjkssm_data1 = kssm_jisuan(zjkssm, drkssm);
                int zjkssm_data2 = kssm_jisuan(zjkssm, drkssm);
                int zjkssm_data3 = kssm_jisuan(zjkssm, drkssm);

                int zjcard_1_data1 = card_jisuan(zjcard_1, drkssm);
                int zjcard_1_data2 = card_jisuan(zjcard_1, drkssm);

                int zjcard_2_data1 = card_jisuan(zjcard_2, drkssm);
                int zjcard_2_data2 = card_jisuan(zjcard_2, drkssm);

                int zjcard_3_data1 = card_jisuan(zjcard_3, drkssm);
                int zjcard_3_data2 = card_jisuan(zjcard_3, drkssm);

                int zjdata = zjkssm_data1 + zjkssm_data2 + zjkssm_data3 +
                    zjcard_1_data1 + zjcard_1_data2 +
                    zjcard_2_data1 + zjcard_2_data2 +
                    zjcard_3_data1 + zjcard_3_data2;


                 //Console.WriteLine("第{0}轮",i+1);
                
                 //Console.WriteLine("zjkssm_data1:" + zjkssm_data1 + " zjkssm_data2:" + zjkssm_data2 + " zjkssm_data3:" + zjkssm_data3 +
                 //    " zjcard_1_data1:" + zjcard_1_data1 + " zjcard_1_data2:" + zjcard_1_data2 +
                 //    " zjcard_2_data1:" + zjcard_2_data1 + " zjcard_2_data2:" + zjcard_2_data2 +
                 //    " zjcard_3_data1:" + zjcard_3_data1 + " zjcard_3_data2:" + zjcard_3_data2);

                int drkssm_data1 = kssm_jisuan(drkssm, zjkssm);
                int drkssm_data2 = kssm_jisuan(drkssm, zjkssm);
                int drkssm_data3 = kssm_jisuan(drkssm, zjkssm);

                int drcard_1_data1 = card_jisuan(drcard_1, zjkssm);
                int drcard_1_data2 = card_jisuan(drcard_1, zjkssm);

                int drcard_2_data1 = card_jisuan(drcard_2, zjkssm);
                int drcard_2_data2 = card_jisuan(drcard_2, zjkssm);

                int drcard_3_data1 = card_jisuan(drcard_3, zjkssm);
                int drcard_3_data2 = card_jisuan(drcard_3, zjkssm);

                int drdata = drkssm_data1 + drkssm_data2 + drkssm_data3 +
                    drcard_1_data1 + drcard_1_data2 +
                    drcard_2_data1 + drcard_2_data2 +
                    drcard_3_data1 + drcard_3_data2;

                //Console.WriteLine("drkssm_data1:" + drkssm_data1 + " drkssm_data2:" + drkssm_data2 + " drkssm_data3:" + drkssm_data3 +
                //  " drcard_1_data1:" + drcard_1_data1 + " drcard_1_data2:" + drcard_1_data2 +
                //  " drcard_2_data1:" + drcard_2_data1 + " drcard_2_data2:" + drcard_2_data2 +
                //  " drcard_3_data1:" + drcard_3_data1 + " drcard_3_data2:" + drcard_3_data2+"\n");



                if (zjdata > drdata)
                {
                    shenglv++;
                }
            }


            return shenglv;
        }

        /// <summary>
        /// //kssm计算
        /// </summary>
        /// <param name="zjkssm">自己骑士属性</param>
        /// <param name="drkssm">敌人骑士属性</param>
        /// <returns>伤害值</returns>
        public int kssm_jisuan(kssm zjkssm, kssm drkssm)
        {
            //zjkssm属性
            this.zjkssm_wmtype = zjkssm.kssm_wmtype;
            this.zjkssm_wuligongji = zjkssm.wuligongji;
            this.zjkssm_mofagongji = zjkssm.mofagongji;
            this.zjkssm_wulifangyu = zjkssm.wulifangyu;
            this.zjkssm_mofafangyu = zjkssm.mofafangyu;
            this.zjkssm_balance = zjkssm.balance;
            this.zjkssm_critical = zjkssm.critical;
            this.zjkssm_shuxingtype = zjkssm.shuxingtype;
            this.zjkssm_shuxingzhi = zjkssm.shuxingzhi;
            //drkssm属性
            this.drkssm_wmtype = drkssm.kssm_wmtype;
            this.drkssm_wuligongji = drkssm.wuligongji;
            this.drkssm_mofagongji = drkssm.mofagongji;
            this.drkssm_wulifangyu = drkssm.wulifangyu;
            this.drkssm_mofafangyu = drkssm.mofafangyu;
            this.drkssm_balance = drkssm.balance;
            this.drkssm_critical = drkssm.critical;
            this.drkssm_shuxingtype = drkssm.shuxingtype;
            this.drkssm_shuxingzhi = drkssm.shuxingzhi;
            //局部变量
            int zjkssm_atk;
            int drksssm_def;
            bool kezhi;

            //计算
            if (this.zjkssm_wmtype == wulimofaleixing.物理)
            {
                zjkssm_atk = this.zjkssm_wuligongji;
                drksssm_def = this.drkssm_wulifangyu;
            }
            else
            {
                zjkssm_atk = this.zjkssm_mofagongji;
                drksssm_def = this.drkssm_mofafangyu;
            }

            int zjdata = 0;

            kezhi = shuxingkezhi(this.drkssm_shuxingzhi, this.drkssm_shuxingtype, this.zjkssm_shuxingtype);


            //属性
            if (kezhi == true)
            {
                zjdata = zjkssm_atk * (100 + this.zjkssm_shuxingzhi) / 100;
            }
            else
            {
                zjdata = zjkssm_atk;
            }
            //b值
            zjdata = zjdata * this.ran.Next(100 - zjkssm_balance, 100 + zjkssm_balance) / 100;

            //c值
            if (this.ran.Next(100) > this.zjkssm_critical)
            {
                zjdata = zjdata - drksssm_def;
            }

            //打不动情况
            if (zjdata < 0)
            {
                zjdata = 0;
            }
            return zjdata;
        }



        /// <summary>
        /// 卡计算
        /// </summary>
        /// <param name="zjcard">自己的卡属性</param>
        /// <param name="drkssm">敌人骑士属性</param>
        /// <returns>伤害值</returns>
        public int card_jisuan(card zjcard, kssm drkssm)
        {
            //zjcard属性
            this.card_cunzai = zjcard.cunzai;
            this.card_wmtype = zjcard.card_wmtype;
            this.card_atk = zjcard.atk;
            this.card_sdk = zjcard.sdk;
            this.card_balance = zjcard.balance;
            this.card_critical = zjcard.critical;
            this.card_fadong = zjcard.fadong;
            this.card_shuxingtype = zjcard.shuxingtype;
            this.card_shuxingzhi = zjcard.shuxingzhi;

            //drkssm属性
            this.drkssm_wmtype = drkssm.kssm_wmtype;
            this.drkssm_wuligongji = drkssm.wuligongji;
            this.drkssm_mofagongji = drkssm.mofagongji;
            this.drkssm_wulifangyu = drkssm.wulifangyu;
            this.drkssm_mofafangyu = drkssm.mofafangyu;
            this.drkssm_balance = drkssm.balance;
            this.drkssm_critical = drkssm.critical;
            this.drkssm_shuxingtype = drkssm.shuxingtype;
            this.drkssm_shuxingzhi = drkssm.shuxingzhi;

            //局部变量
            int card_data = 0;
            int card_gongji;
            int drkssm_def;
            bool card_kezhi;

            //计算
            if (this.card_cunzai == false)
            {
                return 0;
            }
            else
            {
                //物理魔法type
                if (this.card_wmtype == wulimofaleixing.物理)
                {
                    drkssm_def = this.drkssm_wulifangyu;
                }
                else
                {
                    drkssm_def = this.drkssm_mofafangyu;
                }

                //属性克制
                card_kezhi = shuxingkezhi(this.drkssm_shuxingzhi, this.drkssm_shuxingtype, this.card_shuxingtype);

                //技发判定
                if (this.ran.Next(100) < this.card_fadong)
                {
                    card_gongji = this.card_sdk;
                }
                else
                {
                    card_gongji = this.card_atk;
                }

                //属性计算
                if (card_kezhi == true)
                {
                    card_data = card_gongji * (100 + this.card_shuxingzhi) / 100;
                }
                else
                {
                    card_data = card_gongji;
                }


                //b值
                card_data = card_data * this.ran.Next(100 - this.card_balance, 100 + this.card_balance) / 100;

                //c值
                if (this.ran.Next(100) > this.card_critical)
                {
                    card_data = card_data - drkssm_def;
                }

                //打不动情况
                if (card_data < 0)
                {
                    card_data = 0;
                }
            }

            return card_data;
        }





        /// <summary>
        /// 属性克制判断
        /// </summary>
        /// <param name="drshuxingzhi">敌人属性值</param>
        /// <param name="drshuxingtype">敌人属性种类</param>
        /// <param name="zjshuxingtype">自己属性种类（人/卡）</param>
        /// <returns></returns>
        public bool shuxingkezhi(int drshuxingzhi, shuxingleixing drshuxingtype, shuxingleixing zjshuxingtype)
        {
            bool kezhi = false;
            if (drshuxingzhi > 0)
            {
                if (zjshuxingtype == shuxingleixing.wind)
                {
                    if (zjshuxingtype - drshuxingtype == 3)
                    {
                        kezhi = true;
                    }
                    else
                    {
                        kezhi = false;
                    }
                }
                else
                {
                    if (zjshuxingtype - drshuxingtype == -1)
                    {
                        kezhi = true;
                    }
                    else
                    {
                        kezhi = false;
                    }
                }
            }
            else
            {
                kezhi = false;
            }
            return kezhi;
        }

    }
}
