using System;
using System.Linq;
using System.Collections.Generic;

namespace Air_BOT
{
    public class TranslateMetar
    {
        public string Translate(string Metar)
        {

            if (!Metar.Contains("SB", StringComparison.InvariantCultureIgnoreCase))
            {
                return "Não foi possível simplificar o METAR, esta função está disponível "
                     + "apenas para alguns aeroportos federais brasileiros.";
            }

            var Icao = Metar.Substring(19, 4);
            var dateYY = Metar.Substring(0, 4);
            var dateMM = Metar.Substring(5, 2);
            var dateDD = Metar.Substring(24, 2);
            var dateHH = Metar.Substring(26, 2);
            var windDirection = Metar.Substring(32, 3);
            var windSpeed = Metar.Substring(35, 2);
            var ifContainWindVariation = Metar.Substring(43, 1).Contains("V");
            var variationWind = Metar.Substring(40, 7);


            if (ifContainWindVariation)
            {
                var result = $"Metar: {Metar}\n"
                       + $"✈️ Icao selecionado: {Icao}\n"
                       + $"\n'/infoaero'\n"
                       + $"\n🕒 Metar confeccionado em {dateDD} de {ConvertDate(dateMM)} de {dateYY}, às {dateHH}:00 hora(s) (UTC).\n"
                       + $"\n☁️ Situação meteorológica:\n"
                       + $"\n🔴 Vento:" 
                       + $"\nDireção: {windDirection}° graus com velocidade de {windSpeed} nó(s).\n"
                       + $"Com variações entre {Metar.Substring(40, 3)}° e {Metar.Substring(44, 3)}° graus.\n"
                       + $"\n🔴 Tempo predominante:\n"
                       + $"{GetWeatherData(Metar)}\n";

                return result;
            }
            else
            {
                var result = $"Metar: {Metar}\n"
                           + $"✈️ Icao selecionado: {Icao}\n"
                           + $"\n'/infoaero'\n"
                           + $"\n🕒 Metar confeccionado em {dateDD} de {ConvertDate(dateMM)} de {dateYY}, às {dateHH}:00 hora(s) (UTC).\n"
                           + $"\n☁️ Situação meteorológica:\n"
                           + $"\n🔴 Vento:" 
                           + $"\nDireção: {windDirection}° graus com velocidade de {windSpeed} nó(s).\n"
                           + $"\n🔴 Tempo predominante:\n"
                           + $"{GetWeatherData(Metar)}\n";

                return result;
            }

        }

        public string ConvertIcaoForAirportName(string Icao)
        {
            if (Icao.Length == 0)
            {
                return "Não foi possível fazer a busca pelo aeroporto, digite um ICAO.";
            }

            return $"https://www.aisweb.aer.mil.br/index.cfm?i=aerodromos&codigo={Icao}";
        }

        protected string GetWeatherData(string Metar)
        {
            var airportWeather = new AirportListWeather();

            return airportWeather.GetWeather(Metar);
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