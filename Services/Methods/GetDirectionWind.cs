using System;
using System.Linq;
using Air_BOT.Services.Helpers;

namespace Air_BOT.Services.WeatherServices.Methods
{
    public class GetDirectionWind
    {
        private ListWeather ListW = new ListWeather();
        public string GetWindDirection(string Metar)
        {
            try
            {
                var result = string.Empty;

                var variation = Metar.Substring(Metar.IndexOf("KT"), 9).Substring(3, 3);

                var windDirection = Metar.Substring(32, 3);

                foreach (var item in ListW.Weather)
                {
                    if (Metar.Contains("VRB"))
                    {
                        var vrbSpeed = Metar.Substring(Metar.IndexOf("VRB"), 5).Substring(3);
                        result = "Variante";
                    }
                    else if (!variation.Contains(item.WeatherTag) && variation.Contains("V"))
                    {
                        int testWindDirection = int.Parse(windDirection.ToCharArray());

                        if (variation.Substring(variation.IndexOf("V")).Any(c => char.IsNumber(c)))
                        {
                            var variation1 = Metar.Substring(Metar.IndexOf("KT")).Substring(3, 3);
                            var variation2 = Metar.Substring(Metar.IndexOf("KT")).Substring(7, 3);

                            int testVar1 = int.Parse(variation1);
                            int testVar2 = int.Parse(variation2);

                            result = $"{windDirection} com variações entre {variation1} e {variation2}";
                        }
                    }
                    else
                    {
                        int testWindDirection = int.Parse(windDirection.ToCharArray());
                        
                        result = $"{windDirection}°";
                    }
                }
                return result;
            }
            catch (System.Exception Exception)
            {
                Console.WriteLine(  $"\n___________________________________________________________________\n" +
                                    $"\nData: {DateTime.Now.ToString("dd/MM/yyyy - hh:mm:ss")}\n" +
                                    $"\nClasse:       GetDirectionWind\n" +
                                    $"\nMétodo:       GetWindDirection()\n" +
                                    $"\nExceção executada, verifique-a:\n\n{Exception}" +
                                    $"\n___________________________________________________________________\n" );
                
                return "Não foi possível decodificar a direção do vento";
            }
            
        }
    }
}