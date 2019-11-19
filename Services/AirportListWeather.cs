using System.Collections.Generic;
using System.Linq;
using System;
using System.Xml;

namespace Air_BOT
{
    public class AirportListWeather
    {
        private string A = "2019111816 - METAR SBEG 181600Z 03007KT 9999 SCT020 SCT100 30/24 Q1010=";

        public void TesteMetar()
        {
            Console.WriteLine(GetWeather(this.A));
        }

        public string GetWeather(string Metar)
        {
            var resultWeather = string.Empty;
            var resultVariation = string.Empty;

            var GetWeather = new List<WeatherModel>() {
                new WeatherModel {WeatherTag = "DZ", WeatherInfo = "Chuvisco."},
                new WeatherModel {WeatherTag = "RA", WeatherInfo = "Chuva."},
                new WeatherModel {WeatherTag = "-RA", WeatherInfo = "Chuva fraca."},
                new WeatherModel {WeatherTag = "+RA", WeatherInfo = "Chuva forte."},
                new WeatherModel {WeatherTag = "TS", WeatherInfo = "Trovoada."},
                new WeatherModel {WeatherTag = "SH", WeatherInfo = "Pancada."},
                new WeatherModel {WeatherTag = "HZ", WeatherInfo = "Névoa Seca."},
                new WeatherModel {WeatherTag = "BR", WeatherInfo = "Névoa úmida."},
                new WeatherModel {WeatherTag = "FG", WeatherInfo = "Nevoeiro."},
                new WeatherModel {WeatherTag = "CAVOK", WeatherInfo = "CAVOK, hora de voar!"},
                // new WeatherModel {WeatherTag = "GR", WeatherInfo = "Granizo."}
            };

            var GetVariationsWeather = new List<VariationsWeatherModel>() {
                new VariationsWeatherModel {WeatherTag = "NSC", WeatherInfo = "Sem nuvens significativas no nível"},
                new VariationsWeatherModel {WeatherTag = "FEW", WeatherInfo = $"Formação de nuvens no nível"},
                new VariationsWeatherModel {WeatherTag = "BKN", WeatherInfo = $"Nublado com nuvens no nível"},
                new VariationsWeatherModel {WeatherTag = "OVC", WeatherInfo = $"Céu encoberto com nuvens no nível"},
                new VariationsWeatherModel {WeatherTag = "SCT", WeatherInfo = $"Nuvens esparsas no nível"},
            };

            foreach (var item in GetWeather)
            {
                if (Metar.Contains(item.WeatherTag))
                {
                    resultWeather = item.WeatherInfo + "\n";
                }
            }

            foreach (var item in GetVariationsWeather)
            {
                var a = this.A.Substring(this.A.IndexOf("SCT"));

                if (Metar.Contains(item.WeatherTag))
                {
                    if (GetVariationsWeather.Where(x => x.WeatherTag == this.A.Substring(this.A.IndexOf(item.WeatherTag))) != null)
                    {
                        Console.WriteLine(GetVariationsWeather.Where(x => x.WeatherTag == this.A.Substring(this.A.IndexOf(item.WeatherTag))).ToString());
                    }   

                    // Console.WriteLine(this.A.Substring(this.A.(item.WeatherTag), 5).Contains(item.WeatherTag));

                    resultVariation += $"{item.WeatherInfo} {Metar.Substring(Metar.IndexOf(item.WeatherTag, 6)).Substring(3, 3)} FT.\n";
                }

                // var b = this.A.Substring(this.A.IndexOf("SCT"), item.WeatherTag.Length);
            
                // Console.WriteLine(b.Substring(6, 4).Contains(item.WeatherTag));
                
            }

            if (resultWeather.Length == 0 || resultVariation.Length == 0)
            {
                if (resultWeather.Length == 0)
                {
                    return resultVariation;
                }
                else
                {
                    return resultWeather;
                }
            }
            else
            {
                return $"{resultWeather}"
                     + $"{resultVariation}";
            }
        }
    }
}