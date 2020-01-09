using System;
using System.Drawing;
using System.Text;
using Air_BOT.Models;
using Air_BOT.Services.WeatherServices.Methods;

namespace Air_BOT.Services
{
    public class AirportListWeather
    {
        private GetDate Gdate = new GetDate();
        private GetHour Ghour = new GetHour();
        private GetDirectionWind Gdirection = new GetDirectionWind();
        private GetWindSpeed Gspeed = new GetWindSpeed();
        private GetVisibility Gvisibility = new GetVisibility();
        private GetWeather Gweather = new GetWeather();
        private GetTemperature Gtemperature = new GetTemperature();
        private GetDewPoint GdewPoint = new GetDewPoint();
        private GetPression Gpression = new GetPression();

        public string GetWeatherInfo(string Metar)
        {
            var result = string.Empty;

            if (string.IsNullOrEmpty(Metar))
            {
                return  
                        $"{Metar}\n" +
                        $"Não foi possível simplificar o METAR, por favor insira um ICAO válido para busca do METAR.";
            }
            else if (!Metar.Contains("SB", StringComparison.InvariantCultureIgnoreCase))
            {
                return  
                        $"{Metar}\n" +
                        $"Não foi possível simplificar o METAR, esta função está disponível " +
                        $"apenas para alguns aeroportos federais brasileiros.";
            }
            else if (Metar.Contains("SPECI") || Metar.Contains("COR"))
            {
                return  
                        $"{Metar}\n" +
                        $"Este METAR possui código SPECI ou COR, estamos desenvolvendo " +
                        $"a funcionalidade para decodificar a mensagem.";
            }
            else
            {
                var stringBuilder = new StringBuilder();

                for (int i = 0; i < Gweather.GetWeatherMetar(Metar).Length; i++)
                {
                    stringBuilder.Append("\n" + Gweather.GetWeatherMetar(Metar)[i] + "\n");
                }

                result = 
                        $"----------------------------------------------------------------" +
                        $"\n📄 METAR: \n" +
                        $"{Metar}" +
                        $"----------------------------------------------------------------" +
                        $"\n\n'/infoaero'" +
                        $"\n'/googlemaps'\n\n" +
                        $"----------------------------------------------------------------" +
                        $"\n📅 Data:\n" +
                        $"\n➡️  {Gdate.ConvertDateMetar(Metar)[1]} às {Ghour.ConvertHourMetar(Metar)}\n" +
                        $"----------------------------------------------------------------" +
                        $"\n💨 Vento:\n" +
                        $"\n➡️  Direção: {Gdirection.GetWindDirection(Metar)}\n" +
                        $"➡️  Velocidade: {Gspeed.GetSpeedWind(Metar)}\n" +
                        $"----------------------------------------------------------------" +
                        $"\n🌡️ Temperatura:\n" +
                        $"\n➡️ Atual: {Gtemperature.GetTemperatureMetar(Metar)}°C\n" +
                        $"➡️ Ponto de Orvalho: {GdewPoint.GetDewPointMetar(Metar)}°C\n" +
                        $"----------------------------------------------------------------" +
                        $"\n🎈 Pressão:\n" +
                        $"\n➡️ {Gpression.GetPressionMetar(Metar)} hPa\n" +
                        $"----------------------------------------------------------------" +
                        $"\n📡 Tempo:\n" +
                        $"{stringBuilder.ToString()}" +
                        $"----------------------------------------------------------------" +
                        $"\nFim do relatório.";
            }

            return result;
        }
    }
}