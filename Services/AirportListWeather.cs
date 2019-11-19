using System.Collections.Generic;
using System.Linq;
using System;
using System.Xml;

namespace Air_BOT
{
    public class AirportListWeather
    {
        private string Metar = "2019111816 - METAR SBEG 181600Z 03007KT 9999 SCT020 SCT100 30/24 Q1010=";

        public void TesteMetar()
        {
            Console.WriteLine(GetWeather(this.Metar));
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
                if (Metar.Contains(item.WeatherTag))
                {
                    resultVariation += $"{item.WeatherInfo} {Metar.Substring(Metar.IndexOf(item.WeatherTag, 6)).Substring(3, 3)} FT.\n";
                }

                var a = this.Metar.Substring(this.Metar.IndexOf("SCT"));

                Console.WriteLine(a.Substring(6, 4));
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