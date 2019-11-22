using System.Collections.Generic;
using System.Linq;
using System;
using System.Xml;

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
                new WeatherModel {WeatherTag = "SH", WeatherInfo = "Pancadas de chuva."},
                new WeatherModel {WeatherTag = "HZ", WeatherInfo = "Névoa Seca."},
                new WeatherModel {WeatherTag = "BR", WeatherInfo = "Névoa úmida."},
                new WeatherModel {WeatherTag = "FG", WeatherInfo = "Nevoeiro."},
                new WeatherModel {WeatherTag = "CAVOK", WeatherInfo = "CAVOK (Ceiling And Visibility OK)."},
                new WeatherModel {WeatherTag = "VCTS", WeatherInfo = "Tempestade na vizinhança do aeroporto."},
                new WeatherModel {WeatherTag = "VCSH", WeatherInfo = "Chuva leve na vizinhança do aeroporto."},
                new WeatherModel {WeatherTag = "TCU", WeatherInfo = "Presença de 'Tower Cumulus'."},
                new WeatherModel {WeatherTag = "CB", WeatherInfo = "Presença de 'Cumulus Nimbus'."}
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
                    var variation1 = Metar.Substring(Metar.IndexOf(item.WeatherTag)).Substring(0, 6);
                    var variation2 = Metar.Substring(Metar.IndexOf(item.WeatherTag)).Substring(0, 14).Substring(7, 7);

                    if (variation1.Contains(item.WeatherTag) == variation2.Contains(item.WeatherTag))
                    {
                        resultVariation += $"{item.WeatherInfo} {variation1.Substring(3)} e {variation2.Substring(3)} FT.\n";
                    }
                    else
                    {
                        resultVariation += $"{item.WeatherInfo} {Metar.Substring(Metar.IndexOf(item.WeatherTag)).Substring(3, 3)} FT.\n";
                    }
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