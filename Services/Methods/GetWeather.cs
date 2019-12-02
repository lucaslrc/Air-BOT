using System;
using System.Text.RegularExpressions;
using Air_BOT.Services.Helpers;

namespace Air_BOT.Services.Methods
{
    public class GetWeather
    {
        private ListWeather ListW = new ListWeather();
        private ListVariations ListV = new ListVariations();

        public string GetWeatherMetar(string Metar)
        {
            var resultWeather = string.Empty;
            var resultVariation = string.Empty;

            foreach (var item in ListW.Weather)
            {
                if (Metar.Substring(Metar.IndexOf("KT")).Contains(item.WeatherTag))
                {
                    var weather = Metar.Substring(Metar.IndexOf("KT"));

                    string pattern = $@"\b{item.WeatherTag}+\w*?\b";

                    foreach (Match match in Regex.Matches(weather, pattern, RegexOptions.IgnoreCase))
                    {
                        resultWeather += $"{item.WeatherInfo}\n";
                    }
                }
            }

            foreach (var item in ListV.Variations)
            {
                if (Metar.Contains(item.WeatherTag))
                {   
                    var variation = Metar.Substring(Metar.IndexOf(item.WeatherTag));

                    string pattern = $@"\b{item.WeatherTag}+\w*?\b";

                    foreach (Match match in Regex.Matches(variation, pattern, RegexOptions.IgnoreCase))
                    {
                        if (String.IsNullOrWhiteSpace(match.Value.Substring(3)))
                        {
                            resultVariation += $"{item.WeatherInfo} não informado.\n";
                        }
                        else
                        {
                            resultVariation += $"{item.WeatherInfo} {match.Value.Substring(3, 3)}.\n";
                        }
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