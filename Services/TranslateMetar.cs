using System;
using System.Linq;

namespace Air_BOT
{
    public class TranslateMetar
    {
        public string Translate(string Metar)
        {
            var a = new AirportListWeather();

            return a.GetWeatherInfo(Metar);
        }

        public string ConvertIcaoForAirportName(string Icao)
        {
            if (Icao.Length == 0)
            {
                return "Não foi possível fazer a busca pelo aeroporto, digite um ICAO.";
            }
            else if (Icao.Contains("/"))
            {
                return $"https://www.aisweb.aer.mil.br/index.cfm?i=aerodromos&codigo={Icao.Substring(1)}\n"
                     + $"\nhttps://www.google.com/maps/search/?api=1&query={Icao.Substring(1)}";
            }
            else
            {
                return $"https://www.aisweb.aer.mil.br/index.cfm?i=aerodromos&codigo={Icao}\n"
                     + $"\nhttps://www.google.com/maps/search/?api=1&query={Icao}";
            }  
        }

        public string GetMapsLocation(string Icao)
        {
            if (Icao.Length == 0)
            {
                return "Não foi possível fazer a busca pelo aeroporto, digite um ICAO.";
            }
            else if (Icao.Contains("/"))
            {
                return $"https://www.google.com/maps/search/?api=1&query={Icao.Substring(1)}";
            }
            else
            {
                return $"\nhttps://www.google.com/maps/search/?api=1&query={Icao}";
            }  
        } 
    }
}