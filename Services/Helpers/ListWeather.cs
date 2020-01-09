using System.Collections.Generic;
using Air_BOT.Models;

namespace Air_BOT.Services.Helpers
{
    public class ListWeather
    {
        public List<WeatherModel> Weather = new List<WeatherModel>() {
            new WeatherModel {WeatherTag = "CAVOK", WeatherInfo = "CAVOK (Ceiling And Visibility OK)"},
            new WeatherModel {WeatherTag = "VCTS", WeatherInfo = "Tempestade nas proximidades do aeroporto"},
            new WeatherModel {WeatherTag = "VCSH", WeatherInfo = "Chuva leve nas proximidades do aeroporto"},
            new WeatherModel {WeatherTag = "TCU", WeatherInfo = "Presença de 'Tower Cumulus'"},
            new WeatherModel {WeatherTag = "CB", WeatherInfo = "Presença de 'Cumulus Nimbus'"},
            new WeatherModel {WeatherTag = "RETSRA", WeatherInfo = "Chuva e trovoada recente"},
            new WeatherModel {WeatherTag = "RERA", WeatherInfo = "Chuva recente"},
            new WeatherModel {WeatherTag = "RETS", WeatherInfo = "Trovoada recente"},
            new WeatherModel {WeatherTag = "TSRA", WeatherInfo = "Chuva com trovoada"},
            new WeatherModel {WeatherTag = "DZ", WeatherInfo = "Chuvisco"},
            new WeatherModel {WeatherTag = "RA", WeatherInfo = "Chuva"},
            new WeatherModel {WeatherTag = "TS", WeatherInfo = "Trovoada"},
            new WeatherModel {WeatherTag = "SH", WeatherInfo = "Pancadas de chuva"},
            new WeatherModel {WeatherTag = "HZ", WeatherInfo = "Névoa Seca"},
            new WeatherModel {WeatherTag = "BR", WeatherInfo = "Névoa úmida"},
            new WeatherModel {WeatherTag = "FG", WeatherInfo = "Nevoeiro "},
            new WeatherModel {WeatherTag = "GR", WeatherInfo = "Granizo"}
        };
    }
}