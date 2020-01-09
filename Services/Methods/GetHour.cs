using System;

namespace Air_BOT.Services.WeatherServices.Methods
{
    public class GetHour
    {
        public string ConvertHourMetar(string Metar)
        {
            try
            {
                var dateHH = Metar.Substring(8, 2);

                int testInt = int.Parse(dateHH);

                return $"{dateHH} horas (UTC)";
            }
            catch (System.Exception Exception)
            {
                Console.WriteLine(  $"\n___________________________________________________________________\n" +
                                    $"\nData: {DateTime.Now.ToString("dd/MM/yyyy - hh:mm:ss")}\n" +
                                    $"\nClasse:       GetHour\n" +
                                    $"\nMétodo:       GetHourMetar()\n" +
                                    $"\nExceção executada, verifique-a:\n\n{Exception}" +
                                    $"\n___________________________________________________________________\n" );

                return "Não foi possível decodificar o horário";
            }
            
        }
    }
}