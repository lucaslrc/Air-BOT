namespace Air_BOT.Services.Methods
{
    public class ConvertDate
    {
        public string ConvertDateMetar(string Date)
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