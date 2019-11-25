using System;
using System.Linq;

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
                    + $"\n{GetInfo(Metar)}\n"
                    + $"\n🔴 Tempo predominante:\n"
                    + $"{GetWeatherData(Metar)}\n"
                    + $"\n🔴 Temperatura:\n"
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
                    + $"\n{GetInfo(Metar)}\n"
                    + $"\n🔴 Visibilidade:\n"
                    + $"{GetVisibilityData("2019112118 - METAR SBMG 211800Z VRB02KT 1500 SCT040 FEW050TCU 33/18 Q1010=")}\n"
                    + $"\n🔴 Tempo predominante:\n"
                    + $"{GetWeatherData(Metar)}\n"
                    + $"\n🔴 Temperatura:\n"
                    + $"{GetTemperature(Metar)}";
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

        protected string GetInfo(string Metar)
        {
            var a = new AirportListWeather();

            return a.GetWeatherInfo(Metar);
        }

        protected string GetVisibilityData(string Metar)
        {
            var a = new AirportListWeather();

            return a.GetVisibility(Metar);
        }

        protected string GetWeatherData(string Metar)
        {
            var airportWeather = new AirportListWeather();

            return airportWeather.GetWeather(Metar);
        }

        protected string GetTemperature(string Metar)
        {
            var tLeft = Metar.Substring(Metar.IndexOf("/", 1), 3).Reverse().ToArray().Count();
            var tRight = Metar.Substring(Metar.IndexOf("/"), 3).Substring(1);
            return $"Ponto de orvalho: {tRight}°c";
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