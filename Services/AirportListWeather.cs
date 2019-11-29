using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Globalization;
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
            new WeatherModel {WeatherTag = "TSRA", WeatherInfo = "Chuva com trovoada."},
            new WeatherModel {WeatherTag = "DZ", WeatherInfo = "Chuvisco."},
            new WeatherModel {WeatherTag = "RA", WeatherInfo = "Chuva."},
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
            var Icao = Metar.Substring(Metar.IndexOf("SB"), 4);
            var dateYY = Metar.Substring(0, 4);
            var dateMM = Metar.Substring(4, 2);
            var dateDD = Metar.Substring(6, 2);
            var dateHH = Metar.Substring(8, 2);

            var result = string.Empty;

            if (string.IsNullOrEmpty(Metar))
            {
                return "Não foi possível simplificar o METAR, por favor digite um METAR válido.";
            }
            else if (!Metar.Contains("SB", StringComparison.InvariantCultureIgnoreCase))
            {
                return "Não foi possível simplificar o METAR, esta função está disponível "
                    + "apenas para alguns aeroportos federais brasileiros.";
            }
            else if (Metar.Contains("CAVOK"))
            {
                result = $"Metar: {Metar}\n"
                    + $"✈️ Icao selecionado: {Icao}\n"
                    + $"\n'/infoaero'\n"
                    + $"\n📅 Metar confeccionado em {dateDD} de {ConvertDate(dateMM)} de {dateYY}, às {dateHH}:00 hora(s) (UTC).\n"
                    + $"\n☁️ Situação meteorológica:\n"
                    + $"\n🔴 Vento:" 
                    + $"\n{GetWind(Metar)}\n"
                    + $"\n🔴 Tempo predominante:\n"
                    + $"{GetWeather(Metar)}\n"
                    + $"🔴 Temperatura:\n"
                    + $"{GetTemperature(Metar)}";
            }
            else
            {
                result = $"Metar: {Metar}\n"
                    + $"✈️ Icao selecionado: {Icao}\n"
                    + $"\n'/infoaero'\n"
                    + $"\n📅 Metar confeccionado em {dateDD} de {ConvertDate(dateMM)} de {dateYY}, às {dateHH}:00 hora(s) (UTC).\n"
                    + $"\n☁️ Situação meteorológica:\n"
                    + $"\n🔴 Vento:" 
                    + $"\n{GetWind(Metar)}\n"
                    + $"\n🔴 Visibilidade:\n"
                    + $"{GetVisibility(Metar)}\n"
                    + $"\n🔴 Tempo predominante:\n"
                    + $"{GetWeather(Metar)}\n"
                    + $"🔴 Temperatura:\n"
                    + $"{GetTemperature(Metar)}";
            }
            return result;
        }

        protected string ConvertDate(string Date)
        {
            switch (Date)
            {
                case "1":
                    Date = "Janeiro";
                break;
                
                case "2":
                    Date = "Fevereiro";
                break;

                case "3":
                    Date = "Março";
                break;

                case "4":
                    Date = "Abril";
                break;

                case "5":
                    Date = "Maio";
                break;

                case "6":
                    Date = "Junho";
                break;

                case "7":
                    Date = "Julho";
                break;

                case "8":
                    Date = "Agosto";
                break;

                case "9":
                    Date = "Setembro";
                break;

                case "10":
                    Date = "Outubro";
                break;

                case "11":
                    Date = "Novembro";
                break;

                case "12":
                    Date = "Dezembro";
                break;
            }

            return Date;
        } 

        protected string GetWind(string Metar)
        {
            var variation = Metar.Substring(Metar.IndexOf("KT"), 7).Substring(3);

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
                    var variation1 = Metar.Substring(Metar.IndexOf("KT")).Substring(3, 3);
                    var variation2 = Metar.Substring(Metar.IndexOf("KT")).Substring(7, 3);

                    if (variation.Substring(variation.IndexOf("V")).Substring(1, 1).Where(c => char.IsNumber(c)).Count() > 0 == false)
                    {
                        result = $"Direção: {windDirection}° (graus);\n"
                            + $"Velocidade: {windSpeed}KT (nós).";
                    }
                    else if (Metar.Substring(32, 9).Contains("G"))
                    {
                        var gusts = gustsVerification.Substring(gustsVerification.IndexOf("G"), 3).Substring(1);

                        result = $"Direção: {windDirection}° (graus);\n"
                            + $"Com variações entre {variation1}° e {variation2}° (graus).\n"
                            + $"Velocidade: {windSpeed}KT (nós), com rajadas de {gusts}KT.";
                    }
                    else
                    {
                        result = $"Direção: {windDirection}° (graus);\n"
                            + $"Com variações entre {variation1}° e {variation2}° (graus).\n"
                            + $"Velocidade: {windSpeed}KT (nós).";
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

        protected string GetWeather(string Metar)
        {
            var resultWeather = string.Empty;
            var resultVariation = string.Empty;

            foreach (var item in Weather)
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

            foreach (var item in Variations)
            {
                if (Metar.Contains(item.WeatherTag))
                {   
                    var variation = Metar.Substring(Metar.IndexOf(item.WeatherTag));

                    string pattern = $@"\b{item.WeatherTag}+\w*?\b";

                    foreach (Match match in Regex.Matches(variation, pattern, RegexOptions.IgnoreCase))
                    {
                        resultVariation += $"{item.WeatherInfo} {match.Value.Substring(3, 3)}.\n";
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

        protected string GetVisibility(string Metar)
        {
            var visibility = Metar.Substring(Metar.IndexOf("KT"));

            var resultVisibility = string.Empty;


            if (visibility.Substring(3, 12).Contains("9999"))
            {
                resultVisibility = "Distância: Acima dos 10km (quilômetros).";
            }
            else if (visibility.Substring(3, 4).Where(c => char.IsLetter(c)).Count() > 0)
            {
                if (Weather.Any(x => x.WeatherTag == visibility) == true)
                {
                    return null;
                }
                else
                {
                    if (visibility.Substring(6).Contains("V"))
                    {
                        var v = visibility.Substring(11, 4);
                        
                        Console.WriteLine(v);
                        Console.WriteLine(v.Where(c => char.IsNumber(c)).Count() > 0);

                        if(v.Where(c => char.IsNumber(c)).Count() > 0)
                        {
                            double conv = int.Parse(v);

                            var result = conv / 1000;

                            resultVisibility = $"Distância: {result.ToString()}km (quilômetros).";
                        }
                    }
                }
            }
            else
            {
                double conv = int.Parse(visibility.Substring(3, 5));

                var result = conv / 1000;

                resultVisibility = $"Distância: {result.ToString()}km (quilômetros).";
            }

            return resultVisibility;
        }

        protected string GetTemperature(string Metar)
        {
            var a = Metar.Reverse().ToArray();

            string b = new string(a);
            string c = new string(b.Substring(b.IndexOf("/")).Substring(1, 2));

            string tLeft = new string(c.ToCharArray().Reverse().ToArray());
            string tRight = Metar.Substring(Metar.IndexOf("/"), 3).Substring(1);

            return $"Temperatura: {tLeft}°C;\n"
                 + $"Ponto de orvalho: {tRight}°C.";
        }
    }
}