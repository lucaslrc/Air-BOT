using System.Collections.Generic;
using System.Linq;

namespace Air_BOT
{
    public class AirportListWeather
    {
        public string GetWeather(string Metar)
        {
            var result = string.Empty;

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
                new WeatherModel {WeatherTag = "NSC", WeatherInfo = "Sem nuvens significativas"},
                new WeatherModel {WeatherTag = "FEW", WeatherInfo = $"Formação de nuvens."},
                new WeatherModel {WeatherTag = "BKN", WeatherInfo = $"Nublado."},
                new WeatherModel {WeatherTag = "OVC", WeatherInfo = $"Céu encoberto."},
                new WeatherModel {WeatherTag = "SCT", WeatherInfo = $"Nuvens esparsas."},

                // new WeatherModel {WeatherTag = "GR", WeatherInfo = "Granizo."}
            };

            foreach (var item in GetWeather)
            {
                if (Metar.Contains(item.WeatherTag))
                {
                    result = item.WeatherInfo;
                }
            }

            if (result.Length == 0)
            {
                return "Limpo.";
            }
            else
            {
                return result;
            }
        }
    }
}