﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace low
{
    /// <summary>
    /// 属性类型
    /// </summary>
    enum shuxingleixing
    {
        earth = 0,
        water = 1,
        fire = 2,
        wind = 3
    }
    /// <summary>
    /// 物理魔法类型
    /// </summary>
    enum wulimofaleixing
    {
        物理 = 0,
        魔法 = 1
    }

    /// <summary>
    /// 骑士
    /// </summary>
    class kssm
    {
        public wulimofaleixing kssm_wmtype = 0;
        public int wuligongji;
        public int mofagongji;
        public int wulifangyu;
        public int mofafangyu;
        public int balance;
        public int critical;
        public int shuxingzhi;
        public shuxingleixing shuxingtype;


        /// <summary>
        /// 骑士方法重写
        /// </summary>
        /// <param name="wuligongji">物理攻击</param>
        /// <param name="mofagongji">魔法攻击</param>
        /// <param name="wulifangyu">物理防御</param>
        /// <param name="mofafangyu">魔法防御</param>
        /// <param name="balance">B值</param>
        /// <param name="critical">C值</param>
        /// <param name="shuxingzhi">属性值</param>
        /// <param name="shuxingtype">属性种类</param>
        public kssm(int wuligongji, int mofagongji, int wulifangyu, int mofafangyu, int balance, int critical, int shuxingzhi, shuxingleixing shuxingtype)
        {
            this.wuligongji = wuligongji;
            this.mofagongji = mofagongji;
            this.wulifangyu = wulifangyu;
            this.mofafangyu = mofafangyu;
            this.balance = balance;
            this.critical = critical;
            if (this.critical > 50)
            {
                this.critical = 50;
            }
            this.shuxingzhi = shuxingzhi;
            this.shuxingtype = shuxingtype;
            if (this.wuligongji >= this.mofagongji)
            {
                this.kssm_wmtype = wulimofaleixing.物理;
            }
            else
            {
                this.kssm_wmtype = wulimofaleixing.魔法;
            }
        }
    }

    /// <summary>
    /// 卡
    /// </summary>
    class card
    {
        public bool cunzai = false; //  卡片是否存在
        public wulimofaleixing card_wmtype;
        public int atk;
        public int sdk;
        public int fadong;//不带%
        public int balance;
        public int critical;
        public int shuxingzhi;
        public shuxingleixing shuxingtype;

        /// <summary>
        /// 卡方法重写
        /// </summary>
        /// <param name="cunzai">卡是否存在</param>
        /// <param name="card_wmtype">物理魔法类型</param>
        /// <param name="atk">攻击</param>
        /// <param name="sdk">技攻</param>
        /// <param name="fadong">发动</param>
        /// <param name="balance">B值</param>
        /// <param name="critical">C值</param>
        /// <param name="shuxingzhi">属性值</param>
        /// <param name="shuxingtype">属性类型</param>
        public card(bool cunzai, wulimofaleixing card_wmtype, int atk, int sdk, int fadong, int balance, int critical, int shuxingzhi, shuxingleixing shuxingtype)
        {
            this.cunzai = cunzai;
            this.card_wmtype = card_wmtype;
            this.atk = atk;
            this.sdk = sdk;
            this.fadong = fadong;
            this.balance = balance;
            this.critical = critical;
            this.shuxingzhi = shuxingzhi;
            this.shuxingtype = shuxingtype;
        }

    }

    /// <summary>
    /// 卡xml配置
    /// </summary>
    public class Carddata
    {
        //数组定义： 0   1   2   3   4   5   6
        //         无印 2m  4m  凸  凸+ 極  極+（放弃，预留）
        public class Atk
        {
            public double[] Base = new double[7] { -1, -1, -1, -1, -1, -1, -1 };

            public double[] coef = new double[7] { -1, -1, -1, -1, -1, -1, -1 };
        }
        public class Satk
        {
            public double[] Base = new double[7] { -1, -1, -1, -1, -1, -1, -1 };

            public double[] coef = new double[7] { -1, -1, -1, -1, -1, -1, -1 };
        }

        public string name;

        public string combinename;

        public string combinesubname;

        public string type;

        public string eletype;

        public double[] elevalue = new double[7] { -1, -1, -1, -1, -1, -1, -1 };

        public double[] level = new double[7] { -1, -1, -1, -1, -1, -1, -1 };

        public Atk atk = new Atk();

        public Satk satk = new Satk();

        public double[] sk = new double[7] { -1, -1, -1, -1, -1, -1, -1 };

        public double[] ct = new double[7] { -1, -1, -1, -1, -1, -1, -1 };

        public double[] ba = new double[7] { -1, -1, -1, -1, -1, -1, -1 };

        public static void shuzuchuli(ref double[] array, XmlNodeList list)
        {

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].InnerText.ToString() != "")
                {
                    array[i] = Convert.ToDouble(list[i].InnerText);
                }
                else
                {
                    array[i] = -1;
                }

            }
        }

        public static void limitchuli(ref double[] array, XmlNodeList list)
        {
            if (list.Count != 0)
            {
                array[4] = Convert.ToDouble(list[0].InnerText);
            }
        }

        public static void combinechuli(ref double[] array, XmlNodeList list, int type)
        {
            if (list.Count != 0)
            {
                array[type] = Convert.ToDouble(list[0].InnerText);
            }
        }

    }


}
