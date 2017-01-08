using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_Windroid.Web.api;
using System.Security.Cryptography;

namespace TEST_program
{
    class Request
    {
        private string q;
        private string from;
        private string to;
        private static long appid = ;//这里是用户appID
        private int salt;
        private string sign;
        private static string key = "";//这里是密钥
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
        #endregion

        public Request(string q,string from,string to)
        {
            this.q = q;
            this.from = from;
            this.to = to;
            salt = HttpHelper.GetTimeStamp();
            //string sign0 = appid.ToString() + q + salt.ToString() + key;
            //string sign = HttpHelper.StrToMD5(appid.ToString() + q + salt.ToString() + key);
            //Console.WriteLine("加密前的sign值："+sign0);
            //Console.WriteLine("加密后的sign值："+sign);
            sign = HttpHelper.StrToMD5(appid.ToString() + q + salt.ToString() + key);
            requestStr = "http://api.fanyi.baidu.com/api/trans/vip/translate?q=" + q + "&from=" + from + "&to=" + to + "&appid=" + appid + "&salt=" + salt + "&sign=" + sign;
        }




    }
}
