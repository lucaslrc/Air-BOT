using System;

namespace Air_BOT.Services.Methods
{
    public class GetPression
    {
        public string GetPressionMetar(string Metar)
        {
            var Pression = Metar.Substring(Metar.IndexOf("/"));

            Console.WriteLine(Pression);

            return "";
        }
    }
}