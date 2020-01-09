using System.Collections.Generic;
using Air_BOT.Models;

namespace Air_BOT.Services.Helpers
{
    public class ListVariations
    {
        public List<VariationsWeatherModel> Variations = new List<VariationsWeatherModel>() {
            new VariationsWeatherModel {WeatherTag = "NSC", WeatherInfo = "Sem nuvens significativas"},
            new VariationsWeatherModel {WeatherTag = "FEW", WeatherInfo = $"Formação de nuvens"},
            new VariationsWeatherModel {WeatherTag = "BKN", WeatherInfo = $"Nublado com nuvens"},
            new VariationsWeatherModel {WeatherTag = "OVC", WeatherInfo = $"Céu encoberto com nuvens"},
            new VariationsWeatherModel {WeatherTag = "SCT", WeatherInfo = $"Nuvens esparsas"},
        };
    }
}