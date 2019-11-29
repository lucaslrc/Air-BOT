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

        static string Icao = string.Empty;

        public static void Main(string[] args)
        {
            botClient = new TelegramBotClient("668648971:AAHjB4WFaVeQFbtSuYpAwEbJJfw2jU6b6J0");

            var me = botClient.GetMeAsync().Result;

            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
            Thread.Sleep(int.MaxValue);
        }

        public static void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text == "/start")
            {
                e.Message.Text = "";

                botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "Olá, seja bem-vindo.\n"
                        + "Digite algum ICAO para consulta. Exemplo: 'SBGR'\n"
                        + "Ou se preferir veja a lista de ICAO's:\n"
                        + "'/listaicaos'"
                );
            }
            else if (e.Message.Text.Length == 4 || e.Message.Text.Length == 5)
            {
                if (Icao.Length >= 4)
                {
                    Icao = string.Empty;
                }

                if (e.Message.Text.Contains("/"))
                {
                   botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat,
                        text: $"{GetIcaoCode(e.Message.Text.Substring(1))}\n"
                            + "'/simplificar'"
                    ); 
                }
                else
                {
                    botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat,
                        text: $"{GetIcaoCode(e.Message.Text)}"
                            + "'/simplificar'"
                    );
                }

                Icao += e.Message.Text;
            }
            else if (e.Message.Text.Length < 4 && e.Message.Text.Contains("/"))
            {
                if (e.Message.Text.Length == 3)
                {
                    var list = new AirportListIcao();

                    botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat,
                        text: $"{list.GetEstado(e.Message.Text)}"
                    );

                    e.Message.Text = string.Empty;
                }
                else
                {
                    botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat,
                        text: "Não foi possível ralizar esta ação."
                    );

                    e.Message.Text = string.Empty;
                }
            }
            else if (e.Message.Text == "/simplificar")
            {
                if (String.IsNullOrEmpty(Icao))
                {
                    botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat,
                        text: "Não foi possível realizar esta ação, tente novamente usando outro METAR."
                    );
                }
                else if (Icao.Contains("/"))
                {
                    var translateMetar = new TranslateMetar();
                    botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat,
                        text: translateMetar.Translate(GetIcaoCode(Icao.Substring(1)))
                    );
                }
                else
                {
                    var translateMetar = new TranslateMetar();
                    botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat,
                        text: translateMetar.Translate(GetIcaoCode(Icao))
                    );
                }
            }
            else if (e.Message.Text == "/infoaero")
            {
                var aPlist = new TranslateMetar();

                botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: aPlist.ConvertIcaoForAirportName(Icao)
                );

                Icao = string.Empty;        
            }
            else if (e.Message.Text == "/listaicaos")
            {
                botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "Selecione um estado:\n"
                     
                        + "\n/AC  - " + " /AL  -  " + "/AP  -  " + "/AM\n"

                        + "\n/BA  -  " + "/CE  -  " + "/DF  -  " + "/ES\n"

                        + "\n/GO  -  " + "/MA  -  " + "/MT  -  " + "/MS\n"

                        + "\n/MG  -  " + "/PA  -  " + "/PB  -  " + "/PR\n" 

                        + "\n/PE  -  " + "/PI  -  " + "/RJ  -  " + "/RN\n"

                        + "\n/RS  -  " + "/RO  -  " + "/RR  -  " + "/SC\n" 

                        + "\n/SE  -  " + "/SP  -  " + "/TO\n"
                );
            }
            else
            {
                botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "Não consegui te entender.\n"
                        + "Veja a lista de comandos:\n"
                        + "\n'/start'\n"
                        + "'/listaicaos'"
                );
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

            if (content.Contains("não localizada na base de dados da REDEMET"))
            {
                return string.Empty + content;
            }
            else
            {
                return content;
            }
        }
    }
}