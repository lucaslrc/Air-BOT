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
            // new WeatherModel {WeatherTag = "GR", WeatherInfo = "Granizo."}
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
                List<string> othersCharacters = new List<string>() {
                    "Q","W","E","R","T","Y","U","I","O",
                    "P","A","S","D","F","G","H","J","K",
                    "L","Ç","Z","X","C","B","N","M"
                };
    
                var variation = Metar.Substring(Metar.IndexOf("KT"), 10);
                var windSpeed = Metar.Substring(35, 2);
                var windDirection = Metar.Substring(32, 3);
                var variation1 = Metar.Substring(39, 8).Substring(0, 4);
                var variation2 = Metar.Substring(39, 8).Substring(5, 3);
                var result = string.Empty;

                Console.WriteLine(variation);
        
                if (Metar.Contains("VRB"))
                {
                    var vrbSpeed = Metar.Substring(Metar.IndexOf("VRB"), 5).Substring(3);

                    result = $"Direção: Variável;\n"
                        + $"Velocidade: {vrbSpeed}KT (nós).";
                }
                else if (variation.Contains("V"))
                {
                    foreach (var item in Weather)
                    {
                        foreach (var cha in othersCharacters)
                        {
                            if (variation.Contains(item.WeatherTag))
                            {
                                result = $"Direção: {windDirection}° (graus);\n"
                                    + $"Velocidade: {windSpeed}KT (nós).";
                            }
                            else if (variation.Contains(cha))
                            {
                                result = $"Direção: {windDirection}° (graus);\n"
                                    + $"Velocidade: {windSpeed}KT (nós).";
                            }
                            else
                            {
                                result = $"Direção: {windDirection}° (graus);\n"
                                    + $"Velocidade: {windSpeed}KT (nós);\n"
                                    + $"Com variações entre {variation1}° e {variation2}° (graus).";
                            }

                            Console.WriteLine(variation.Contains(cha) + cha);
                        }
                        // foreach (var cha in othersCharacters)
                        // {
                        //     Console.WriteLine($"{variation.Contains(item.WeatherTag)} {variation.Contains(cha)}");
                        //     if (variation.Contains(item.WeatherTag))
                        //     {
                        //         result = $"Direção: {windDirection}° (graus);\n"
                        //             + $"Velocidade: {windSpeed}KT (nós).";
                        //     }
                        //     else if (variation.Substring(variation.IndexOf("V")).Contains(cha))
                        //     {
                        //         result = $"Direção: {windDirection}° (graus);\n"
                        //             + $"Velocidade: {windSpeed}KT (nós).";
                        //     }
                        //     else
                        //     {
                        //         result = $"Direção: {windDirection}° (graus);\n"
                        //             + $"Velocidade: {windSpeed}KT (nós);\n"
                        //             + $"Com variações entre {variation1}° e {variation2}° (graus).";
                        //     }
                        // }
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
                if (Metar.Contains(item.WeatherTag))
                {
                    
                    // var a = Metar.Substring(4);
                    // Console.WriteLine(a.Substring(Metar.IndexOf(item.WeatherTag)).Substring(0,6));
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