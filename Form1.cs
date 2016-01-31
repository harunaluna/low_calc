using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace low
{
    public partial class Form1 : Form
    {

        kssm ziji;




        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {



            //kssm
            int wuligongji = 49760;
            int mofagongji = 7510;
            int wulifangyu = 20390;
            int mofafangyu = 18490;
            int balance = 12;
            int critical = 45;
            int shuxingzhi = 0;
            shuxingleixing shuxingtype = shuxingleixing.earth;

            //card1(商人)
            bool card1_cunzai = true;
            wulimofaleixing card1_wmtype = wulimofaleixing.魔法;
            int card1_atk = 22487;
            int card1_sdk = 81922;
            int card1_fadong = 33;//不带%
            int card1_balance = 14;
            int card1_critical = 30;
            int card1_shuxingzhi = 50;
            shuxingleixing card1_shuxingtype = shuxingleixing.fire;

            //card2
            bool card2_cunzai = true;
            wulimofaleixing card2_wmtype = wulimofaleixing.物理;
            int card2_atk = 33515;
            int card2_sdk = 65816;
            int card2_fadong = 55;//不带%
            int card2_balance = 3;
            int card2_critical = 47;
            int card2_shuxingzhi = 50;
            shuxingleixing card2_shuxingtype = shuxingleixing.water;

            //card3
            bool card3_cunzai = true;
            wulimofaleixing card3_wmtype = wulimofaleixing.物理;
            int card3_atk = 39312;
            int card3_sdk = 64714;
            int card3_fadong = 54;//不带%
            int card3_balance = 12;
            int card3_critical = 28;
            int card3_shuxingzhi = 50;
            shuxingleixing card3_shuxingtype = shuxingleixing.earth;

            //自己定义
            //kssm ziji = new kssm(wuligongji, mofagongji, wulifangyu, mofafangyu, balance, critical, shuxingzhi, shuxingtype);



            card ziji_1 = new card(card1_cunzai, card1_wmtype, card1_atk, card1_sdk, card1_fadong, card1_balance, card1_critical, card1_shuxingzhi, card1_shuxingtype);

            card ziji_2 = new card(card2_cunzai, card2_wmtype, card2_atk, card2_sdk, card2_fadong, card2_balance, card2_critical, card2_shuxingzhi, card2_shuxingtype);

            card ziji_3 = new card(card3_cunzai, card3_wmtype, card3_atk, card3_sdk, card3_fadong, card3_balance, card3_critical, card3_shuxingzhi, card3_shuxingtype);





            //敌人定义
            //kssm
            wuligongji = 22585;
            mofagongji = 67135;
            wulifangyu = 26380;
            mofafangyu = 8535;
            balance = 15;
            critical = 46;
            shuxingzhi = 0;
            shuxingtype = shuxingleixing.earth;

            //card1
            card1_cunzai = true;
            card1_wmtype = wulimofaleixing.物理;
            card1_atk = 42242;
            card1_sdk = 65346;
            card1_fadong = 52;//不带%%
            card1_balance = 1;
            card1_critical = 41;
            card1_shuxingzhi = 60;
            card1_shuxingtype = shuxingleixing.water;

            //card2
            card2_cunzai = true;
            card2_wmtype = wulimofaleixing.物理;
            card2_atk = 33515;
            card2_sdk = 65816;
            card2_fadong = 55;//不带%
            card2_balance = 3;
            card2_critical = 47;
            card2_shuxingzhi = 50;
            card2_shuxingtype = shuxingleixing.water;

            //card3
            card3_cunzai = true;
            card3_wmtype = wulimofaleixing.物理;
            card3_atk = 11152;
            card3_sdk = 73408;
            card3_fadong = 61;//不带%
            card3_balance = 5;
            card3_critical = 46;
            card3_shuxingzhi = 65;
            card3_shuxingtype = shuxingleixing.wind;

            kssm diren = new kssm(wuligongji, mofagongji, wulifangyu, mofafangyu, balance, critical, shuxingzhi, shuxingtype);
            wuligongji_2.Text = "物理攻击:" + diren.wuligongji;
            mofagongji_2.Text = "魔法攻击:" + diren.mofagongji;
            wulifangyu_2.Text = "物理防御:" + diren.wulifangyu;
            mofafangyu_2.Text = "魔法防御:" + diren.mofafangyu;
            balance_2.Text = "B值:" + diren.balance;
            critical_2.Text = "C值:" + diren.critical;
            shuxing_2.Text = "属性:" + diren.shuxingzhi + " " + diren.shuxingtype;
            wulimofa_2.Text = "" + diren.kssm_wmtype;

            card diren_1 = new card(card1_cunzai, card1_wmtype, card1_atk, card1_sdk, card1_fadong, card1_balance, card1_critical, card1_shuxingzhi, card1_shuxingtype);

            card diren_2 = new card(card2_cunzai, card2_wmtype, card2_atk, card2_sdk, card2_fadong, card2_balance, card2_critical, card2_shuxingzhi, card2_shuxingtype);

            card diren_3 = new card(card3_cunzai, card3_wmtype, card3_atk, card3_sdk, card3_fadong, card3_balance, card3_critical, card3_shuxingzhi, card3_shuxingtype);





            zhandou asd = new zhandou();



            jieguo.Text = asd.jisuan(ziji, ziji_1, ziji_2, ziji_3, diren, diren_1, diren_2, diren_3) + "/10000";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Chushihua.chushihua();
        }

        private void zj_chaxun_Click(object sender, EventArgs e)
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
                    MessageBox.Show("武器未找到，检查是否输入错误\n如未在列表中找到，请回帖报告\n(默认按无装备替代)");

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
                    MessageBox.Show("盾未找到，检查是否输入错误\n如未在列表中找到，请回帖报告\n(默认按无装备替代)");
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
                    MessageBox.Show("衣服未找到，检查是否输入错误\n如未在列表中找到，请回帖报告\n(默认按无装备替代)");
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
                    MessageBox.Show("戒指未找到，检查是否输入错误\n如未在列表中找到，请回帖报告\n(默认按无装备替代)");
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
                    MessageBox.Show("盾未找到，检查是否输入错误\n如未在列表中找到，请回帖报告\n(默认按无装备替代)");
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
            if (Chushihua.card1_name != "")
            {
                if (Dict.card_dict.ContainsKey(Chushihua.card1_name))
                {
                    Dict.card_dict.TryGetValue(Chushihua.card1_name, out Chushihua.card1_duiying);
                }
                else
                {
                    MessageBox.Show("卡1未找到，检查是否输入错误\n如未在列表中找到，请回帖报告\n(默认按无装备替代)");
                    Dict.card_dict.TryGetValue("なし", out Chushihua.card1_duiying);

                }
            }
            else
            {
                Dict.card_dict.TryGetValue("なし", out Chushihua.card1_duiying);
            }
            #endregion

            #region 卡2查询
            Chushihua.card2_name = ka2_1.Text.ToString();
            if (Chushihua.card2_name != "")
            {
                if (Dict.card_dict.ContainsKey(Chushihua.card2_name))
                {
                    Dict.card_dict.TryGetValue(Chushihua.card2_name, out Chushihua.card2_duiying);
                }
                else
                {
                    MessageBox.Show("卡2未找到，检查是否输入错误\n如未在列表中找到，请回帖报告\n(默认按无装备替代)");
                    Dict.card_dict.TryGetValue("なし", out Chushihua.card2_duiying);

                }
            }
            else
            {
                Dict.card_dict.TryGetValue("なし", out Chushihua.card2_duiying);
            }
            #endregion

            #region 卡3查询
            Chushihua.card3_name = ka3_1.Text.ToString();
            if (Chushihua.card3_name != "")
            {
                if (Dict.card_dict.ContainsKey(Chushihua.card3_name))
                {
                    Dict.card_dict.TryGetValue(Chushihua.card3_name, out Chushihua.card3_duiying);
                }
                else
                {
                    MessageBox.Show("卡3未找到，检查是否输入错误\n如未在列表中找到，请回帖报告\n(默认按无装备替代)");
                    Dict.card_dict.TryGetValue("なし", out Chushihua.card3_duiying);

                }
            }
            else
            {
                Dict.card_dict.TryGetValue("なし", out Chushihua.card3_duiying);
            }
            #endregion


            ziji = kssmpeizhi.peizhi();

            wuligongji_1.Text = "物理攻击:" + ziji.wuligongji;
            mofagongji_1.Text = "魔法攻击:" + ziji.mofagongji;
            wulifangyu_1.Text = "物理防御:" + ziji.wulifangyu;
            mofafangyu_1.Text = "魔法防御:" + ziji.mofafangyu;
            balance_1.Text = "B值:" + ziji.balance;
            critical_1.Text = "C值:" + ziji.critical;
            shuxing_1.Text = "属性:" + ziji.shuxingzhi + " " + ziji.shuxingtype;
            wulimofa_1.Text = "" + ziji.kssm_wmtype;


        }
    }
}
