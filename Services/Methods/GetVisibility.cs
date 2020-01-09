using System;
using System.Linq;
using Air_BOT.Services.Helpers;

namespace Air_BOT.Services.WeatherServices.Methods
{
    public class GetVisibility
    {
        private ListWeather ListW = new ListWeather();
        
        public string GetVisibilityMetar(string Metar)
        {
            try
            {
                var visibility = Metar.Substring(Metar.IndexOf("KT"));

                var resultVisibility = string.Empty;


                if (visibility.Substring(3, 12).Contains("9999"))
                {
                    resultVisibility = "Acima dos 10km";
                }
                else if (visibility.Substring(3, 4).Where(c => char.IsLetter(c)).Count() > 0)
                {
                    if (ListW.Weather.Any(x => x.WeatherTag == visibility) == true)
                    {
                        return null;
                    }
                    else
                    {
                        if (visibility.Substring(6).Contains("V"))
                        {
                            var v = visibility.Substring(11, 4);

                            if(v.Where(c => char.IsNumber(c)).Count() > 0)
                            {
                                double conv = int.Parse(v);

                                var result = conv / 1000;

                                resultVisibility = $"{result.ToString()}km";
                            }
                        }
                    }
                }
                else
                {
                    double conv = int.Parse(visibility.Substring(3, 5));

                    var result = conv / 1000;

                    resultVisibility = $"{result.ToString()}km";
                }

                if (String.IsNullOrEmpty(resultVisibility))
                {
                    return "Não informado";
                }
                else
                {
                    return $"Distância: {resultVisibility}";
                }
            }
            catch (System.Exception Exception)
            {
                Console.WriteLine(  $"\n___________________________________________________________________\n" +
                                    $"\nData: {DateTime.Now.ToString("dd/MM/yyyy - hh:mm:ss")}\n" +
                                    $"\nClasse:       GetVisibility\n" +
                                    $"\nMétodo:       GetVisibilityMetar()\n" +
                                    $"\nExceção executada, verifique-a:\n\n{Exception}" +
                                    $"\n___________________________________________________________________\n" );

                return "Não foi possível decodificar a visibilidade";
            }
        }
    }
}