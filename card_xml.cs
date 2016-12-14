using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace low
{
    class card_xml
    {
        public static List<Carddata> card_list = new List<Carddata>();
        //public static Dictionary<string, int> card_dict = new Dictionary<string, int>();
        public static Dictionary<string, int> heti_dict = new Dictionary<string, int>();

        public static void cardzhuangzai()
        {
            XmlDocument card_data = new XmlDocument();
            card_data.Load(@"D:\sakura\Downloads\dmm\data_walkure\xml\12.13.xml");
            XmlNode root = card_data.SelectSingleNode("root");
            XmlNodeList card_data_list = root.ChildNodes;

            foreach (XmlNode item in card_data_list)
            {
                Carddata carddata = new Carddata();

                carddata.name = item.SelectSingleNode("name").InnerText;
                carddata.type = item.SelectSingleNode("type").InnerText;
                carddata.eletype = item.SelectSingleNode("eletype").InnerText;

                Carddata.shuzuchuli(ref carddata.elevalue, item.SelectNodes("elevalue"));
                Carddata.shuzuchuli(ref carddata.level, item.SelectNodes("level"));

                XmlNode atk = item.SelectSingleNode("atk");
                Carddata.shuzuchuli(ref carddata.atk.Base, atk.SelectNodes("base"));
                Carddata.shuzuchuli(ref carddata.atk.coef, atk.SelectNodes("coef"));

                XmlNode satk = item.SelectSingleNode("satk");
                Carddata.shuzuchuli(ref carddata.satk.Base, satk.SelectNodes("base"));
                Carddata.shuzuchuli(ref carddata.satk.coef, satk.SelectNodes("coef"));

                Carddata.shuzuchuli(ref carddata.sk, item.SelectNodes("sk"));
                Carddata.shuzuchuli(ref carddata.ct, item.SelectNodes("ct"));
                Carddata.shuzuchuli(ref carddata.ba, item.SelectNodes("ba"));

                if (item.SelectNodes("limited").Count != 0)
                {
                    
                    int t = item.SelectNodes("limited").Count;
                    if (t == 1)
                    {
                        XmlNode limited = item.SelectNodes("limited")[0];

                        Carddata.limitchuli(ref carddata.elevalue, limited.SelectNodes("elevalue"));
                        Carddata.limitchuli(ref carddata.level, limited.SelectNodes("level"));

                        atk = limited.SelectSingleNode("atk");
                        if (atk != null)
                        {
                            Carddata.limitchuli(ref carddata.atk.Base, atk.SelectNodes("base"));
                            Carddata.limitchuli(ref carddata.atk.coef, atk.SelectNodes("coef"));
                        }
                        satk = limited.SelectSingleNode("satk");
                        if (satk != null)
                        {
                            Carddata.limitchuli(ref carddata.satk.Base, satk.SelectNodes("base"));
                            Carddata.limitchuli(ref carddata.satk.coef, satk.SelectNodes("coef"));
                        }

                        Carddata.limitchuli(ref carddata.sk, limited.SelectNodes("sk"));
                        Carddata.limitchuli(ref carddata.ct, limited.SelectNodes("ct"));
                        Carddata.limitchuli(ref carddata.ba, limited.SelectNodes("ba"));
                    }
                    else
                    {
                        //异常区域（断点常驻）
                    }
                }

                //合体
                if (item.SelectNodes("combine").Count != 0)
                {
                    int t = item.SelectNodes("combine").Count;
                    if (t == 2)
                    {
                        XmlNode combine_1 = item.SelectNodes("combine")[0];
                        XmlNode combine_2 = item.SelectNodes("combine")[1];

                        carddata.combinename = combine_1.SelectSingleNode("name").InnerText;
                        carddata.combinesubname = combine_1.SelectSingleNode("sub").InnerText;
                        heti_dict.Add(carddata.combinename, card_list.Count);
                        //设定默认假卡
                        if (carddata.combinename == "酔いどれ雀"
                            || carddata.combinename == "酔いどれ九尾狐"
                            || carddata.combinename == "水ノ地アイオーン"
                            || carddata.combinename == "水ノ地デルタ")
                        {
                            Carddata.combinechuli(ref carddata.elevalue, combine_1.SelectNodes("elevalue"), 5);
                            Carddata.combinechuli(ref carddata.level, combine_1.SelectNodes("level"), 5);

                            atk = combine_1.SelectSingleNode("atk");
                            Carddata.combinechuli(ref carddata.atk.Base, atk.SelectNodes("base"), 5);
                            Carddata.combinechuli(ref carddata.atk.coef, atk.SelectNodes("coef"), 5);

                            satk = combine_1.SelectSingleNode("satk");
                            Carddata.combinechuli(ref carddata.satk.Base, satk.SelectNodes("base"), 5);
                            Carddata.combinechuli(ref carddata.satk.coef, satk.SelectNodes("coef"), 5);

                            Carddata.combinechuli(ref carddata.sk, combine_1.SelectNodes("sk"), 5);
                            Carddata.combinechuli(ref carddata.ct, combine_1.SelectNodes("ct"), 5);
                            Carddata.combinechuli(ref carddata.ba, combine_1.SelectNodes("ba"), 5);
                        }
                        else
                        {
                            Carddata.combinechuli(ref carddata.elevalue, combine_2.SelectNodes("elevalue"), 5);
                            Carddata.combinechuli(ref carddata.level, combine_2.SelectNodes("level"), 5);

                            atk = combine_2.SelectSingleNode("atk");
                            Carddata.combinechuli(ref carddata.atk.Base, atk.SelectNodes("base"), 5);
                            Carddata.combinechuli(ref carddata.atk.coef, atk.SelectNodes("coef"), 5);

                            satk = combine_2.SelectSingleNode("satk");
                            Carddata.combinechuli(ref carddata.satk.Base, satk.SelectNodes("base"), 5);
                            Carddata.combinechuli(ref carddata.satk.coef, satk.SelectNodes("coef"), 5);

                            Carddata.combinechuli(ref carddata.sk, combine_2.SelectNodes("sk"), 5);
                            Carddata.combinechuli(ref carddata.ct, combine_2.SelectNodes("ct"), 5);
                            Carddata.combinechuli(ref carddata.ba, combine_2.SelectNodes("ba"), 5);
                        }

                    }
                    else
                    {
                        XmlNode combine = item.SelectNodes("combine")[0];
                        carddata.combinename = combine.SelectSingleNode("name").InnerText;
                        carddata.combinesubname = combine.SelectSingleNode("sub").InnerText;
                        heti_dict.Add(carddata.combinename, card_list.Count);


                        Carddata.combinechuli(ref carddata.elevalue, combine.SelectNodes("elevalue"), 5);
                        Carddata.combinechuli(ref carddata.level, combine.SelectNodes("level"), 5);

                        atk = combine.SelectSingleNode("atk");
                        Carddata.combinechuli(ref carddata.atk.Base, atk.SelectNodes("base"), 5);
                        Carddata.combinechuli(ref carddata.atk.coef, atk.SelectNodes("coef"), 5);

                        satk = combine.SelectSingleNode("satk");
                        Carddata.combinechuli(ref carddata.satk.Base, satk.SelectNodes("base"), 5);
                        Carddata.combinechuli(ref carddata.satk.coef, satk.SelectNodes("coef"), 5);

                        Carddata.combinechuli(ref carddata.sk, combine.SelectNodes("sk"), 5);
                        Carddata.combinechuli(ref carddata.ct, combine.SelectNodes("ct"), 5);
                        Carddata.combinechuli(ref carddata.ba, combine.SelectNodes("ba"), 5);
                    }

                }
                //card_dict.Add(carddata.name, card_list.Count);
                card_list.Add(carddata);
            }



        }


        public static int listchaxun(string name, List<Carddata> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                
                if (list[i].name.Contains(name))
                {
                    return i;
                }
            }
            return 0;
        }
    }

    
}
