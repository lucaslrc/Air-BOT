using System;
using System.Net;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;
using System.Collections.Generic;
using System.IO;

namespace Air_BOT
{
    class Program
    {
        static ITelegramBotClient botClient;

        public static void Main(string[] args)
        {
            botClient = new TelegramBotClient("668648971:AAF-71Stk_POcLfu4E7nfRArtc3OQsbjei4");

            var me = botClient.GetMeAsync().Result;

            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
            Thread.Sleep(int.MaxValue);
        }

        public static void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null || e.Message.Text != string.Empty)
            {
                switch (e.Message.Text)
                {
                    case "/datetime":
                        DateTime date = DateTime.Now;
                            botClient.SendTextMessageAsync(
                            chatId: e.Message.Chat,
                            text: $"{date} - Horário de Brasília."
                        );
                    break;

                    case "/metar":
                            botClient.SendTextMessageAsync(
                            chatId: e.Message.Chat,
                            text: $"{GetIcaoCode("SBMG")}"
                        );
                    break;
                }
            }
        }

        public static string GetIcaoCode(string Code)
        {
            var request = (HttpWebRequest)WebRequest.Create($"http://www.redemet.aer.mil.br/api/consulta_automatica/index.php?local={Code}&msg=metar");
 
            request.Method = "GET";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
    
            var content = string.Empty;
    
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(stream))
                    {
                        content = sr.ReadToEnd();
                    }
                }
            }
    
            return content;
        }
    }
}