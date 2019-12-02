using System.Linq;
using System;
using Air_BOT.Services.Methods;

namespace Air_BOT.Services
{
    public class AirportListWeather
    {
        private ConvertDate Cdat = new ConvertDate();
        private GetTemperature Gtem = new GetTemperature();
        private GetVisibility Gvis = new GetVisibility();
        private GetWeather Gwea = new GetWeather();
        private GetWind Gwin = new GetWind();

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
                    + $"\n'/googlemaps'\n"
                    + $"\n📅 Metar confeccionado em {dateDD} de {Cdat.ConvertDateMetar(dateMM)} de {dateYY}, às {dateHH}:00 hora(s) (UTC).\n"
                    + $"\n☁️ Situação meteorológica:\n"
                    + $"\n🔴 Vento:" 
                    + $"\n{Gwin.GetWindMetar(Metar)}\n"
                    + $"\n🔴 Tempo predominante:\n"
                    + $"{Gwea.GetWeatherMetar(Metar)}\n"
                    + $"🔴 Temperatura:\n"
                    + $"{Gtem.GetTemperatureMetar(Metar)}";
            }
            else
            {
                result = $"Metar: {Metar}\n"
                    + $"✈️ Icao selecionado: {Icao}\n"
                    + $"\n'/infoaero'\n"
                    + $"\n'/googlemaps'\n"
                    + $"\n📅 Metar confeccionado em {dateDD} de {Cdat.ConvertDateMetar(dateMM)} de {dateYY}, às {dateHH}:00 hora(s) (UTC).\n"
                    + $"\n☁️ Situação meteorológica:\n"
                    + $"\n🔴 Vento:" 
                    + $"\n{Gwin.GetWindMetar(Metar)}\n"
                    + $"\n🔴 Visibilidade:\n"
                    + $"{Gvis.GetVisibilityMetar(Metar)}\n"
                    + $"\n🔴 Tempo predominante:\n"
                    + $"{Gwea.GetWeatherMetar(Metar)}\n"
                    + $"🔴 Temperatura:\n"
                    + $"{Gtem.GetTemperatureMetar(Metar)}";
            }
            return result;
        }
        
    }
}