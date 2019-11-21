using System;

namespace Air_BOT
{
    public class TranslateMetar
    {
        public string Translate(string Metar)
        {
            var Icao = Metar.Substring(19, 4);
            var dateYY = Metar.Substring(0, 4);
            var dateMM = Metar.Substring(4, 2);
            var dateDD = Metar.Substring(24, 2);
            var dateHH = Metar.Substring(26, 2);
            var ifContainWindVariation = Metar.Substring(43, 1).Contains("V");

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
                    + $"\n{GetWindAllVariation(Metar)}\n"
                    + $"\n🔴 Tempo predominante:\n"
                    + $"{GetWeatherData(Metar)}\n";
            }
            else
            {
                result = $"Metar: {Metar}\n"
                    + $"✈️ Icao selecionado: {Icao}\n"
                    + $"\n'/infoaero'\n"
                    + $"\n📅 Metar confeccionado em {dateDD} de {ConvertDate(dateMM)} de {dateYY}, às {dateHH}:00 hora(s) (UTC).\n"
                    + $"\n☁️ Situação meteorológica:\n"
                    + $"\n🔴 Vento:" 
                    + $"\n{GetWindAllVariation(Metar)}\n"
                    + $"\n🔴 Visibilidade:\n"
                    + $"{GetVisibilityData(Metar)}\n"
                    + $"\n🔴 Tempo predominante:\n"
                    + $"{GetWeatherData(Metar)}\n"; 
            }
            return result;
        }

        public string ConvertIcaoForAirportName(string Icao)
        {
            if (Icao.Length == 0)
            {
                return "Não foi possível fazer a busca pelo aeroporto, digite um ICAO.";
            }
            else if (Icao.Contains("/"))
            {
                return $"https://www.aisweb.aer.mil.br/index.cfm?i=aerodromos&codigo={Icao.Substring(1)}";
            }
            else
            {
                return $"https://www.aisweb.aer.mil.br/index.cfm?i=aerodromos&codigo={Icao}";
            }  
        }

        protected string GetWeatherData(string Metar)
        {
            var airportWeather = new AirportListWeather();

            return airportWeather.GetWeather(Metar);
        }

        protected string GetVisibilityData(string Metar)
        {
            var result = string.Empty;

            if (Metar.Substring(39).Contains("V"))
            {
                var a = Metar.Substring(Metar.IndexOf("V"), 9).Substring(4);
                
                var b = int.Parse(a);

                if (b >= 9999)
                {
                    result = "Acima dos 10km.";
                }
                else
                {
                    var c = b / 1000;
                    result = $"Distância de {c}km";
                }

                return result;
            }
            else
            {
                var a = Metar.Substring(39, 6);

                var b = int.Parse(a);

                if (b >= 9999)
                {
                    result = "Visibilidade acima dos 10km.";
                }
                else
                {
                    var c = b / 1000;
                    result = $"Distância de {c}km";
                }

                return result;
            }
        }

        protected string GetWindAllVariation(string Metar)
        {
                var windSpeed = Metar.Substring(35, 2);
                var windDirection = Metar.Substring(32, 3);
                var variation1 = Metar.Substring(39, 8).Substring(0, 4);
                var variation2 = Metar.Substring(39, 8).Substring(5, 3);


            if (Metar.Contains("VRB"))
            {
                var vrbSpeed = Metar.Substring(Metar.IndexOf("VRB"), 5).Substring(3);

                return $"Direção: Variável;\n"
                     + $"Velocidade: {vrbSpeed}KT (nós).";
            }
            else if (Metar.Substring(39, 8).Contains("V"))
            {
                return $"Direção: {windDirection}° (graus);\n"
                     + $"Velocidade: {windSpeed}KT (nós);\n"
                     + $"Com variações entre {variation1}° e {variation2}° (graus).";
            }
            else
            {
                return $"Direção: {windDirection}° (graus);\n"
                     + $"Velocidade: {windSpeed}KT (nós).";
            }
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
    }
}