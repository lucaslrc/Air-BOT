using System.Linq;

namespace Air_BOT.Services.Methods
{
    public class GetTemperature
    {
        public string GetTemperatureMetar(string Metar)
        {
            var a = Metar.Reverse().ToArray();

            string b = new string(a);
            string c = new string(b.Substring(b.IndexOf("/")).Substring(1, 2));

            string tLeft = new string(c.ToCharArray().Reverse().ToArray());
            string tRight = Metar.Substring(Metar.IndexOf("/"), 3).Substring(1);

            return $"Temperatura: {tLeft}°C;\n"
                 + $"Ponto de orvalho: {tRight}°C.";
        }
    }
}