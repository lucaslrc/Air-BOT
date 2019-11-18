using System.Collections.Generic;
using System.Linq;
using System;

namespace Air_BOT
{
    public class AirportListWeather
    {
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
                new VariationsWeatherModel {WeatherTag = "NSC", WeatherInfo = "Sem nuvens significativas"},
                new VariationsWeatherModel {WeatherTag = "FEW", WeatherInfo = $"Formação de nuvens"},
                new VariationsWeatherModel {WeatherTag = "BKN", WeatherInfo = $"Nublado"},
                new VariationsWeatherModel {WeatherTag = "OVC", WeatherInfo = $"Céu encoberto"},
                new VariationsWeatherModel {WeatherTag = "SCT", WeatherInfo = $"Nuvens esparsas"},
            };

            foreach (var item in GetWeather)
            {
                if (Metar.Contains(item.WeatherTag))
                {
                    // if (Metar.Contains("FEW"))
                    // {
                    //     result += $"{item.WeatherInfo} no nível {Metar.Substring(Metar.IndexOf("FEW", 6)).Substring(3, 3)} FT";
                    // }
                    // else if(Metar.Contains("BKN"))
                    // {
                    //     result += $"{item.WeatherInfo} no nível {Metar.Substring(Metar.IndexOf("BKN", 6)).Substring(3, 3)} FT";
                    // }
                    // else if (Metar.Contains("OVC"))
                    // {
                    //     result += $"{item.WeatherInfo} no nível {Metar.Substring(Metar.IndexOf("OVC", 6)).Substring(3, 3)} FT";
                    // }
                    // else if (Metar.Contains("SCT"))
                    // {
                    //     result += $"{item.WeatherInfo} no nível {Metar.Substring(Metar.IndexOf("SCT", 6)).Substring(3, 3)} FT";
                    // }
                    // else if (Metar.Contains("FEW") && Metar.Contains("BKN"))
                    // {
                    //     result += $"{item.WeatherInfo} no nível {Metar.Substring(Metar.IndexOf("FEW", 6)).Substring(3, 3)}FT.\n"
                    //             + $"{item.WeatherInfo} no nível {Metar.Substring(Metar.IndexOf("BKN", 6)).Substring(3, 3)} FT";
                    // }
                    
                    resultWeather = item.WeatherInfo;
                }
            }

            foreach (var item in GetVariationsWeather)
            {
                if (Metar.Contains(item.WeatherTag))
                {
                    resultVariation += $"{item.WeatherInfo} no nível {Metar.Substring(Metar.IndexOf(item.WeatherTag, 6)).Substring(3, 3)} FT.\n";
                }
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