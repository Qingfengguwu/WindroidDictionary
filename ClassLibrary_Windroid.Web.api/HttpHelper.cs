using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassLibrary_Windroid.Web.api
{
    public static class HttpHelper
    {
        /// <summary>
        /// 获取返回结果字符串
        /// </summary>
        /// <param name="RequestURL">请求URL字符串</param>
        /// <returns>从HTTP页面返回的结果字符串</returns>
        public static string GetHttpData(string RequestURL)
        {
            string result = null;
            Uri url = new Uri(RequestURL);//初始化uri
            Stream stream = null;
            StreamReader reader = null;
            try
            {
                HttpWebRequest request = (System.Net.HttpWebRequest)WebRequest.Create(url);//初始化请求
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();//得到响应
                stream = response.GetResponseStream();//获取响应的主体
                reader = new StreamReader(stream);//初始化读取器
                result = reader.ReadToEnd();//读取，存储结果
                reader.Close();
                stream.Close();
            }
            catch (System.Net.WebException)
            {
                return "<System>Request Time Out!";
            }
            return result;
        }

        /// <summary>
        /// 从HTTP返回的结果中切割字符串并提取关心的字符串
        /// </summary>
        /// <param name="resultString">从HTTP页面返回的结果字符串</param>
        /// <param name="start">区间开始字符串</param>
        /// <param name="end">区间结束字符串</param>
        /// <returns></returns>
        public static string ExtractValueString(string resultString, string start, string end)
        {
            string[] strArray = resultString.Split(new string[] { start, end },
                StringSplitOptions.RemoveEmptyEntries);//RemoveEmptyEntries表示返回值不包括空元素
            return strArray[1];
        }

        /// <summary>
        /// 从HTTP返回的结果中切割字符串并提取关心的整形数值
        /// </summary>
        /// <param name="resultString">从HTTP页面返回的结果字符串</param>
        /// <param name="start">区间开始字符串</param>
        /// <param name="end">区间结束字符串</param>
        /// <returns>提取的整形值</returns>
        public static int ExtractValueInt(string resultString, string start, string end)
        {
            string[] strArray = resultString.Split(new string[] { start, end },
                StringSplitOptions.RemoveEmptyEntries);//RemoveEmptyEntries表示返回值不包括空元素
            return int.Parse(strArray[1]);
        }

        /// <summary>
        ///获取一个时间戳
        /// </summary>
        /// <returns>返回整形时间戳</returns>
        public static int GetTimeStamp()
        {
            int outTime;
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            string temp = Convert.ToInt64(ts.TotalSeconds).ToString();
            int.TryParse(temp, out outTime);
            return outTime;
        }

        /// <summary>
        /// 对字符串进行MD5加密
        /// </summary>
        /// <param name="str">待加密的字符串</param>
        /// <returns>加密后的MD5字符串</returns>
        public static string StrToMD5(string str)
        {
            byte[] data = Encoding.GetEncoding("GB2312").GetBytes(str);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] OutBytes = md5.ComputeHash(data);
             string OutString = "";
            for (int i = 0; i<OutBytes.Length; i++){
                OutString += OutBytes[i].ToString("x2");
            }            // return OutString.ToUpper();
            return OutString.ToLower();
        }

        /// <summary>
        /// 将符合json规则的unicode转换为汉字
        /// </summary>
        /// <param name="str">符合json规则的字符串</param>
        /// <returns>汉字</returns>
        public static string UnicodeToGB2312(string str)
        {
            string outStr = "";
            Regex reg = new Regex(@"(?i)\\u([0-9a-f]{4})");
            outStr = reg.Replace(str, delegate (Match m1)
            {
                return ((char)Convert.ToInt32(m1.Groups[1].Value, 16)).ToString();
            });
            return outStr;
        }




    }
}
