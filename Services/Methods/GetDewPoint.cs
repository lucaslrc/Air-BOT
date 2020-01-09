using System;

namespace Air_BOT.Services.WeatherServices.Methods
{
    public class GetDewPoint
    {
        public string GetDewPointMetar(string Metar)
        {
            try
            {
                string dewPoint = Metar.Substring(Metar.IndexOf("/"), 3).Substring(1);

                int testInt = int.Parse(dewPoint);

                return dewPoint;
            }
            catch (System.Exception Exception)
            {
                Console.WriteLine(  $"\n___________________________________________________________________\n" +
                                    $"\nData: {DateTime.Now.ToString("dd/MM/yyyy - hh:mm:ss")}\n" +
                                    $"\nClasse:       GetDewPoint\n" +
                                    $"\nMétodo:       GetDewPointMetar()\n" +
                                    $"\nExceção executada, verifique-a:\n\n{Exception}" +
                                    $"\n___________________________________________________________________\n" );
                                    
                return "Não foi possível decodificar o ponto de orvalho"; 
            }
            
        }
    }
}