using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Checker
{
    public static class Helper
    {
        public static void SendMessageTele(string message, string chatId = "-651055820")
        {
            var request = (HttpWebRequest)WebRequest.Create("https://api.telegram.org/bot5013030663:AAE3Aq258oAtDaSQQ4UZrdWEf74mI-6I_2g/sendMessage?chat_id=" + chatId + "&text=" + message);
            request.GetResponse();
        }
    }
}
