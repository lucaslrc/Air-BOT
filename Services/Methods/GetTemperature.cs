using System;
using System.Linq;

namespace Air_BOT.Services.WeatherServices.Methods
{
    public class GetTemperature
    {
        public string GetTemperatureMetar(string Metar)
        {
            try
            {
                var a = Metar.Reverse().ToArray();

                string b = new string(a);
                string c = new string(b.Substring(b.IndexOf("/")).Substring(1, 2));
                string temperature = new string(c.ToCharArray().Reverse().ToArray());

                int testInt = int.Parse(temperature);

                return temperature;
            }
            catch (System.Exception Exception)
            {
                Console.WriteLine(  $"\n___________________________________________________________________\n" +
                                    $"\nData: {DateTime.Now.ToString("dd/MM/yyyy - hh:mm:ss")}\n" +
                                    $"\nClasse:       GetTemperature\n" +
                                    $"\nMétodo:       GetTemperatureMetar()\n" +
                                    $"\nExceção executada, verifique-a:\n\n{Exception}" +
                                    $"\n___________________________________________________________________\n" );
                                    
                return "Não foi possível decodificar a temperatura";
            }
            
        }
    }
}