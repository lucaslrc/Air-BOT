using System;

namespace Air_BOT.Services.Methods
{
    public class GetPression
    {
        public string GetPressionMetar(string Metar)
        {
            string result = string.Empty;

            var Pression = Metar.Substring(Metar.IndexOf("/"));

            Console.WriteLine(Pression.Substring(Pression.IndexOf("Q")));

            result = $"QNH: {Pression.Substring(Pression.IndexOf("Q")).Substring(1, 4)} hPa (hectoPascal).";

            return result;
        }
    }
}