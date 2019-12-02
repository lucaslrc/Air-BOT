using System.Collections.Generic;

namespace Air_BOT.Services.Helpers
{
    public class ListVariations
    {
        public List<VariationsWeatherModel> Variations = new List<VariationsWeatherModel>() {
            new VariationsWeatherModel {WeatherTag = "NSC", WeatherInfo = "Sem nuvens significativas no nível"},
            new VariationsWeatherModel {WeatherTag = "FEW", WeatherInfo = $"Formação de nuvens no nível"},
            new VariationsWeatherModel {WeatherTag = "BKN", WeatherInfo = $"Nublado com nuvens no nível"},
            new VariationsWeatherModel {WeatherTag = "OVC", WeatherInfo = $"Céu encoberto com nuvens no nível"},
            new VariationsWeatherModel {WeatherTag = "SCT", WeatherInfo = $"Nuvens esparsas no nível"},
        };
    }
}