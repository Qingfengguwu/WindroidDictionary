using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_Windroid.Web.api;
using Newtonsoft.Json;

namespace TEST_program
{
    class Program
    {
        static void Main(string[] args)
        {
            Request test = new Request("我爱微软" , "zh" , "jp");
            //test.RequestStr = "http://api.fanyi.baidu.com/api/trans/vip/translate?q=" + Request.UrlEncode(test.Q) + "&from=" + test.From + "&to=" + test.To + "&appid=" + Request.Appid + "&salt=" + test.Salt + "&sign=" + test.Sign;

            string json_str = HttpHelper.GetHttpData(test.RequestStr);
           
            json_str= "["+ json_str + "]";
            Console.WriteLine(json_str);
            TransResult res = new TransResult();
            List<TransResult> Transresult = JsonConvert.DeserializeObject<List<TransResult>>(json_str);
            foreach (TransResult transresult in Transresult)
            {
                //Console.WriteLine("UserName:" + jobInfo.from + "UserID:" + jobInfo.to);
                res.from = transresult.from;
                res.to = transresult.to;

                //res.trans_result.src = transresult.trans_result.src;
                //res.trans_result.dst = transresult.trans_result.dst;
            }
            //Console.WriteLine(HttpHelper.UnicodeToGB2312(res.trans_result.dst));

            res.src = HttpHelper.ExtractValueString(json_str, "src\":\"", "\",\"dst");
            res.dst = HttpHelper.ExtractValueString(json_str, "dst\":\"", "\"}]}]");
            Console.WriteLine(HttpHelper.UnicodeToGB2312(res.dst));

            Console.ReadKey();

        }


    }
}
