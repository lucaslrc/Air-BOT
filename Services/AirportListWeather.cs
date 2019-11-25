using System.Collections.Generic;
using System.Linq;
using System;
using System.Xml;

namespace Air_BOT
{
    public class AirportListWeather
    {
        List<WeatherModel> Weather = new List<WeatherModel>() {
            new WeatherModel {WeatherTag = "CAVOK", WeatherInfo = "CAVOK (Ceiling And Visibility OK)."},
            new WeatherModel {WeatherTag = "VCTS", WeatherInfo = "Tempestade na vizinhança do aeroporto."},
            new WeatherModel {WeatherTag = "VCSH", WeatherInfo = "Chuva leve na vizinhança do aeroporto."},
            new WeatherModel {WeatherTag = "TCU", WeatherInfo = "Presença de 'Tower Cumulus'."},
            new WeatherModel {WeatherTag = "CB", WeatherInfo = "Presença de 'Cumulus Nimbus'."},
            new WeatherModel {WeatherTag = "RETSRA", WeatherInfo = "Chuva e trovoada recente."},
            new WeatherModel {WeatherTag = "RERA", WeatherInfo = "Chuva recente."},
            new WeatherModel {WeatherTag = "RETS", WeatherInfo = "Trovoada recente."},
            new WeatherModel {WeatherTag = "DZ", WeatherInfo = "Chuvisco."},
            new WeatherModel {WeatherTag = "RA", WeatherInfo = "Chuva."},
            new WeatherModel {WeatherTag = "-RA", WeatherInfo = "Chuva fraca."},
            new WeatherModel {WeatherTag = "+RA", WeatherInfo = "Chuva forte."},
            new WeatherModel {WeatherTag = "TS", WeatherInfo = "Trovoada."},
            new WeatherModel {WeatherTag = "SH", WeatherInfo = "Pancadas de chuva."},
            new WeatherModel {WeatherTag = "HZ", WeatherInfo = "Névoa Seca."},
            new WeatherModel {WeatherTag = "BR", WeatherInfo = "Névoa úmida."},
            new WeatherModel {WeatherTag = "FG", WeatherInfo = "Nevoeiro."},
            new WeatherModel {WeatherTag = "GR", WeatherInfo = "Granizo."}
        };

        List<VariationsWeatherModel> Variations = new List<VariationsWeatherModel>() {
            new VariationsWeatherModel {WeatherTag = "NSC", WeatherInfo = "Sem nuvens significativas no nível"},
            new VariationsWeatherModel {WeatherTag = "FEW", WeatherInfo = $"Formação de nuvens no nível"},
            new VariationsWeatherModel {WeatherTag = "BKN", WeatherInfo = $"Nublado com nuvens no nível"},
            new VariationsWeatherModel {WeatherTag = "OVC", WeatherInfo = $"Céu encoberto com nuvens no nível"},
            new VariationsWeatherModel {WeatherTag = "SCT", WeatherInfo = $"Nuvens esparsas no nível"},
        };

        public string GetWeatherInfo(string Metar)
        {
            return GetWind(Metar);
        }

        protected string GetWind(string Metar)
        {
            var variation = Metar.Substring(Metar.IndexOf("KT"), 7).Substring(6);

            var windSpeed = Metar.Substring(35, 2);
            var windDirection = Metar.Substring(32, 3); 

            var gustsVerification = Metar.Substring(32, 10);

            var result = string.Empty;

            foreach (var item in Weather)
            {
                if (Metar.Contains("VRB"))
                {
                    var vrbSpeed = Metar.Substring(Metar.IndexOf("VRB"), 5).Substring(3);

                    if (Metar.Substring(32, 9).Contains("G"))
                    {
                        var gusts = gustsVerification.Substring(gustsVerification.IndexOf("G"), 3).Substring(1);

                        result = $"Direção: Variável;\n"
                            + $"Velocidade: {vrbSpeed}KT (nós), com rajadas de {gusts}KT.";
                    }
                    else
                    {
                        result = $"Direção: Variável;\n"
                            + $"Velocidade: {vrbSpeed}KT (nós).";
                    }
                }
                else if (!variation.Contains(item.WeatherTag) && variation.Contains("V"))
                {
                    var variation1 = Metar.Substring(39, 8).Substring(0, 4);
                    var variation2 = Metar.Substring(39, 8).Substring(5, 3);

                    if (Metar.Substring(32, 9).Contains("G"))
                    {
                        var gusts = gustsVerification.Substring(gustsVerification.IndexOf("G"), 3).Substring(1);

                        result = $"Direção: {windDirection}° (graus);\n"
                            + $"Com variações entre {variation1}° e {variation2}° (graus).\n"
                            + $"Velocidade: {windSpeed}KT (nós), com rajadas de {gusts}KT;";
                    }
                    else
                    {
                        result = $"Direção: {windDirection}° (graus);\n"
                            + $"Com variações entre {variation1}° e {variation2}° (graus).\n"
                            + $"Velocidade: {windSpeed}KT (nós);";
                    }
                }
                else
                {
                    if (Metar.Substring(32, 9).Contains("G"))
                    {
                        var gusts = gustsVerification.Substring(gustsVerification.IndexOf("G"), 3).Substring(1);

                        result = $"Direção: {windDirection}° (graus);\n"
                            + $"Velocidade: {windSpeed}KT (nós), com rajadas de {gusts}KT.";
                    }
                    else
                    {
                        result = $"Direção: {windDirection}° (graus);\n"
                            + $"Velocidade: {windSpeed}KT (nós).";
                    }   
                }
            }

            return result;
        }

        public string GetWeather(string Metar)
        {
            var resultWind = string.Empty;
            var resultWeather = string.Empty;
            var resultVariation = string.Empty;

            foreach (var item in Weather)
            {
                if (Metar.Substring(24).Contains(item.WeatherTag))
                {
                    resultWeather = item.WeatherInfo + "\n";
                }
            }

            foreach (var item in Variations)
            {
                if (Metar.Contains(item.WeatherTag))
                {   
                    var variation1 = Metar.Substring(Metar.IndexOf(item.WeatherTag)).Substring(0, 6);
                    var variation2 = Metar.Substring(Metar.IndexOf(item.WeatherTag)).Substring(0, 14).Substring(7, 7);

                    if (variation1.Contains(item.WeatherTag) == variation2.Contains(item.WeatherTag))
                    {
                        resultVariation += $"{item.WeatherInfo} {variation1.Substring(3)} e {variation2.Substring(3)} FT (pés).\n";
                    }
                    else
                    {
                        resultVariation += $"{item.WeatherInfo} {Metar.Substring(Metar.IndexOf(item.WeatherTag)).Substring(3, 3)} FT (pés).\n";
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

        public string GetVisibility(string Metar)
        {
            var visibility = Metar.Substring(Metar.IndexOf("KT")).Substring(3, 4);

            double conv = int.Parse(visibility);

            var resultVisibility = string.Empty;

            if (visibility.Contains("9999"))
            {
                resultVisibility = "Distância: Acima dos 10km (quilômetros).";
            }
            else
            {
                var result = conv / 1000;

                resultVisibility = $"Distância: {result.ToString()}km (quilômetros).";
            }

            return resultVisibility;
        }

        public string GetTemperature(string Metar)
        {
            return null;
        }
    }
}