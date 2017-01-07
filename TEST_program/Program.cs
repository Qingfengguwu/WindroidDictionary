using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_Windroid.Web.api;

namespace TEST_program
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(HttpHelper.StrToMD5("hahahaha"));
            //Request test = new Request("apple","en","zh");
            //Console.WriteLine(HttpHelper.GetHttpData(test.RequestStr));
            Console.WriteLine(HttpHelper.unicodeToGB2312("\u82f9\u679c"));
            Console.ReadKey();

        }
    }
}
