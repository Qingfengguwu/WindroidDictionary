using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_Windroid.Web.api;
using System.Security.Cryptography;
using System.Web;

namespace TEST_program
{
    class Request
    {
        private string q;
        private string from;
        private string to;
        private static long appid = 20161220000034320;//这里是用户appID
        private int salt;
        private string sign;
        private static string key = "pKFMRZQgu5jC4DOQije_";//这里是密钥
        private string requestStr;

        #region 访问器
        public string Q
        {
            get
            {
                return q;
            }

            set
            {
                q = value;
            }
        }

        public string From
        {
            get
            {
                return from;
            }

            set
            {
                from = value;
            }
        }

        public string To
        {
            get
            {
                return to;
            }

            set
            {
                to = value;
            }
        }

        public static long Appid
        {
            get
            {
                return appid;
            }

            set
            {
                appid = value;
            }
        }

        public int Salt
        {
            get
            {
                return salt;
            }

            set
            {
                salt = value;
            }
        }

        public string Sign
        {
            get
            {
                return sign;
            }

            set
            {
                sign = value;
            }
        }

        public static string Key
        {
            get
            {
                return key;
            }

            set
            {
                key = value;
            }
        }

        public string RequestStr
        {
            get
            {
                return requestStr;
            }

            set
            {
                requestStr = value;
            }
        }

        public static long Appid1
        {
            get
            {
                return appid;
            }

            set
            {
                appid = value;
            }
        }

        public static string Key1
        {
            get
            {
                return key;
            }

            set
            {
                key = value;
            }
        }
        #endregion

        public Request(string q,string from,string to)
        {
            //byte[] b = System.Text.Encoding.UTF8.GetBytes(q);
            //string str_1 = System.Text.Encoding.UTF8.GetString(b);
            //this.q = HttpUtility.UrlEncode(q, Encoding.UTF8);
            this.q = q;          
            this.from = from;
            this.to = to;
            salt = HttpHelper.GetTimeStamp();
            string sign0 = appid + this.q + salt.ToString() + key;
            sign = HttpHelper.StrToMD5(sign0);
            Console.WriteLine("签名："+sign);          
            requestStr = "http://api.fanyi.baidu.com/api/trans/vip/translate?q=" + HttpUtility.UrlEncode(q, Encoding.UTF8) + "&from=" + from + "&to=" + to + "&appid=" + appid + "&salt=" + salt + "&sign=" + sign;
            //requestStr = HttpUtility.UrlEncode(requestStr, Encoding.UTF8);
            Console.WriteLine("请求URL是："+requestStr);
        }

        public static string UrlEncode(string str)
        {
            StringBuilder sb = new StringBuilder();
            byte[] byStr = System.Text.Encoding.UTF8.GetBytes(str); //默认是System.Text.Encoding.Default.GetBytes(str)
            for (int i = 0; i < byStr.Length; i++)
            {
                sb.Append(@"%" + Convert.ToString(byStr[i], 16));
            }

            return (sb.ToString());
        }




    }
}
