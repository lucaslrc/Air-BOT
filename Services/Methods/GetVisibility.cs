using System;
using System.Linq;
using Air_BOT.Services.Helpers;

namespace Air_BOT.Services.Methods
{
    public class GetVisibility
    {
        private ListWeather ListW = new ListWeather();
        
        public string GetVisibilityMetar(string Metar)
        {
            var visibility = Metar.Substring(Metar.IndexOf("KT"));

            var resultVisibility = string.Empty;


            if (visibility.Substring(3, 12).Contains("9999"))
            {
                resultVisibility = "Distância: Acima dos 10km (quilômetros).";
            }
            else if (visibility.Substring(3, 4).Where(c => char.IsLetter(c)).Count() > 0)
            {
                if (ListW.Weather.Any(x => x.WeatherTag == visibility) == true)
                {
                    return null;
                }
                else
                {
                    if (visibility.Substring(6).Contains("V"))
                    {
                        var v = visibility.Substring(11, 4);
                        
                        Console.WriteLine(v);
                        Console.WriteLine(v.Where(c => char.IsNumber(c)).Count() > 0);

                        if(v.Where(c => char.IsNumber(c)).Count() > 0)
                        {
                            double conv = int.Parse(v);

                            var result = conv / 1000;

                            resultVisibility = $"Distância: {result.ToString()}km (quilômetros).";
                        }
                    }
                }
            }
            else
            {
                double conv = int.Parse(visibility.Substring(3, 5));

                var result = conv / 1000;

                resultVisibility = $"Distância: {result.ToString()}km (quilômetros).";
            }

            return resultVisibility;
        }
    }
}