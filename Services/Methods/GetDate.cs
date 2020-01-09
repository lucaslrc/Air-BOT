using System;

namespace Air_BOT.Services.WeatherServices.Methods
{
    public class GetDate
    {
        public string[] ConvertDateMetar(string Metar)
        {
            try
            {
                var stringYY = Metar.Substring(0, 4);
                var stringMM = Metar.Substring(4, 2);
                var stringDD = Metar.Substring(6, 2);

                var YY = int.Parse(stringYY);
                var MM = int.Parse(stringMM);
                var DD = int.Parse(stringDD);

                string[] arrayResult = {
                    $"{DateTime.Parse($"{DD},{MM},{YY}").ToString("dd/MM/yy")}",
                    $"{DateTime.Parse($"{DD},{MM},{YY}").ToString("dd")} de " +
                    $"{DateTime.Parse($"{DD},{MM},{YY}").ToString("MMMM")} de " +
                    $"{DateTime.Parse($"{DD},{MM},{YY}").ToString("yyyy")}",
                };

                return arrayResult; 
            }
            catch (System.Exception Exception)
            {
                Console.WriteLine(  $"\n___________________________________________________________________\n" +
                                    $"\nData: {DateTime.Now.ToString("dd/MM/yyyy - hh:mm:ss")}\n" +
                                    $"\nClasse:       GetDate\n" +
                                    $"\nMétodo:       GetDateMetar()\n" +
                                    $"\nExceção executada, verifique-a:\n\n{Exception}" +
                                    $"\n___________________________________________________________________\n" );

                string[] arrayResult = {
                    "Não foi possível converter a data do METAR, confira o código"
                };

                return arrayResult;
            }
        } 
    }
}