using System.Linq;
using Air_BOT.Services.Helpers;

namespace Air_BOT.Services.Methods
{
    public class GetWind
    {
        private ListWeather ListW = new ListWeather();

        public string GetWindMetar(string Metar)
        {
            var variation = Metar.Substring(Metar.IndexOf("KT"), 9).Substring(3);

            var windSpeed = Metar.Substring(35, 2);
            var windDirection = Metar.Substring(32, 3); 

            var gustsVerification = Metar.Substring(32, 10);

            var result = string.Empty;

            foreach (var item in ListW.Weather)
            {
                if (Metar.Contains("VRB"))
                {
                    var vrbSpeed = Metar.Substring(Metar.IndexOf("VRB"), 5).Substring(3);

                    if (Metar.Substring(32, 9).Contains("G"))
                    {
                        var gusts = gustsVerification.Substring(gustsVerification.IndexOf("G"), 3).Substring(1);

                        result = $"Direção: Variável;\n"
                            + $"Velocidade: {vrbSpeed}KT (nós), com rajadas de {gusts}KT.";
                    }
                    else
                    {
                        result = $"Direção: Variável;\n"
                            + $"Velocidade: {vrbSpeed}KT (nós).";
                    }
                }
                else if (!variation.Contains(item.WeatherTag) && variation.Contains("V"))
                {
                    var variation1 = Metar.Substring(Metar.IndexOf("KT")).Substring(3, 3);
                    var variation2 = Metar.Substring(Metar.IndexOf("KT")).Substring(7, 3);

                    if (variation.Substring(variation.IndexOf("V")).Any(c => char.IsNumber(c)))
                    {
                        result = $"Direção: {windDirection}° (graus);\n"
                            + $"Com variações entre {variation1}° e {variation2}° (graus).\n"
                            + $"Velocidade: {windSpeed}KT (nós).";
                    }
                    else if (Metar.Substring(32, 9).Contains("G"))
                    {
                        var gusts = gustsVerification.Substring(gustsVerification.IndexOf("G"), 3).Substring(1);

                        result = $"Direção: {windDirection}° (graus);\n"
                            + $"Com variações entre {variation1}° e {variation2}° (graus).\n"
                            + $"Velocidade: {windSpeed}KT (nós), com rajadas de {gusts}KT.";
                    }
                    else
                    {
                        result = $"Direção: {windDirection}° (graus);\n"
                            + $"Velocidade: {windSpeed}KT (nós).";
                    }
                }
                else
                {
                    if (Metar.Substring(32, 9).Contains("G"))
                    {
                        var gusts = gustsVerification.Substring(gustsVerification.IndexOf("G"), 3).Substring(1);

                        result = $"Direção: {windDirection}° (graus);\n"
                            + $"Velocidade: {windSpeed}KT (nós), com rajadas de {gusts}KT.";
                    }
                    else
                    {
                        result = $"Direção: {windDirection}° (graus);\n"
                            + $"Velocidade: {windSpeed}KT (nós).";
                    }   
                }
            }

            return result;
        }
    }
}