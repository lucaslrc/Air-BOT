using System.Collections.Generic;

namespace Air_BOT.Services.Helpers
{
    public class AirportListIcao
    {
        string[] listaIcaoAcre = {
            "/SBCZ", "/SBRB", "/SBRB", "/SBTK"
        };

        string[] listaIcaoAlagoas = {
            "/SBMO"
        };

        string[] listaIcaoAmapa = {
            "/SBMQ", "/SBAM", "/SBOI"
        };

        string[] listaIcaoAmazonas = {
            "/SBEG", "/SBTT", "/SBTF", "/SBUA"
        };

        string[] listaIcaoBahia = {
            "/SBSV", "/SBIL", "/SBPS", "/SBQV", "/SBUF", "/SBLP", "/SBNR", "/SBFE",
            "SBLE"
        };

        string[] listaIcaoCeara = {
            "/SBFZ", "/SBJU"
        };

        string[] listaIcaoDistritoFederal = {
            "/SBBR"
        };

        string[] listaIcaoEspiritoSanto = {
            "/SBVT"
        };

        string[] listaIcaoGoias = {
            "/SBGO", "/SBCN", "/SBIT", "/SBMC"
        };

        string[] listaIcaoMaranhao = {
            "/SBIZ", "/SBSL", "/SBIZ", "/SBSL", "/SBCI"
        };

        string[] listaIcaoMatoGrosso = {
            "/SBCY", "/SBAT", "/SBBW", "/SBSO"
        };

        string[] listaIcaoMatoGrossoDoSul = {
            "/SBCG", "/SBCR", "/SBPP", "/SBDO"
        };

        string[] listaIcaoMinasGerais = {
            "/SBCF", "/SBZM", "/SBIP", "/SBBQ", "/SBPR", "/SBMK", "/SBBH", "/SBPC",
            "/SBUR", "/SBUL", "/SBAX", "/SBEP", "/SBGV", "/SBJF", "/SBMV", "/SBMM",
            "/SBVG"
        };

        string[] listaIcaoPara = {
            "/SBHT", "/SBBE", "/SBJC", "/SBMA", "/SBCJ", "/SBSN", "/SBAA", "/SBMD",
            "/SBTB", "/SBTU"
        };

        string[] listaIcaoParaiba = {
            "/SBJP", "/SBKG", "/SBCZ"
        };

        string[] listaIcaoParana = {
            "/SBLO", "/SBCT", "/SBBI", "/SBFI", "/SBCA", "/SBMG", "/SBTL", "/SBTD"
        };

        string[] listaIcaoPernambuco = {
            "/SBPL", "/SBRF", "/SBFN"
        };

        string[] listaIcaoPiaui = {
            "/SBPB", "/SBTE"
        };

        string[] listaIcaoRioDeJaneiro = {
            "/SBGL", "/SBRJ", "/SBCP", "/SBJR", "/SBME", "/SBAF", "/SBSC", "/SBBZ",
            "/SBCB", "/SBAF"
        };

        string[] listaIcaoRioGrandeDoNorte = {
            "/SBSG", "/SBMS"
        };

        string[] listaIcaoRioGrandeDoSul = {
            "/SBPA", "/SBBG", "/SBPK", "/SBUG", "/SBCO", "/SBPX", "/SBPF", "/SBPK",
            "/SBRG", "/SBSM", "/SBNM", "/SBTR"
        };

        string[] listaIcaoRondonia = {
            "/SBPV", "/SBJI", "/SBVH", "/SBGM"
        };

        string[] listaIcaoRoraima = {
            "/SBBV"
        };

        string[] listaIcaoSantaCatarina = {
            "/SBFL", "/SBCM", "/SBJG", "/SBLJ", "/SBNF", "/SBJV", "/SBCD", "/SBCH"
        };

        string[] listaIcaoSaoPaulo = {
            "/SBGP", "/SBGR", "/SBKP", "/SBBP", "/SBJD", "/SBMT", "/SBSP", "/SBSJ",
            "/SBAU", "/SBAQ", "/SBAS", "/SBAE", "/SBML", "/SBDN", "/SBRP", "/SBSR",
            "/SBUP", "/SBBT", "/SBBU", "/SBIL", "/SBLN", "/SBST", "/SBSY", "/SBGW",
            "/SBTA"
        };

        string[] listaIcaoSergipe = {
            "/SBAR"
        };

        string[] listaIcaoTocatins = {
            "/SBPJ", "/SBPN"
        };

        public string GetEstado(string sigla)
        {
            var result = string.Empty;

            switch (sigla)
            {
                case "/AC":
                    foreach (var item in listaIcaoAcre)
                    {
                        result += item + "     ";
                    }
                break;

                case "/AL":
                    foreach (var item in listaIcaoAlagoas)
                    {
                        result += item + "     ";
                    }
                break;

                case "/AP":
                    foreach (var item in listaIcaoAmapa)
                    {
                        result += item + "     ";
                    }
                break;

                case "/AM":
                    foreach (var item in listaIcaoAmazonas)
                    {
                        result += item + "     ";
                    }
                break;

                case "/BA":
                    foreach (var item in listaIcaoBahia)
                    {
                        result += item + "     ";
                    }
                break;

                case "/CE":
                    foreach (var item in listaIcaoCeara)
                    {
                        result += item + "     ";
                    }
                break;

                case "/DF":
                    foreach (var item in listaIcaoDistritoFederal)
                    {
                        result += item + "     ";
                    }
                break;

                case "/ES":
                    foreach (var item in listaIcaoEspiritoSanto)
                    {
                        result += item + "     ";
                    }
                break;
                    
                case "/GO":
                    foreach (var item in listaIcaoGoias)
                    {
                        result += item + "     ";
                    }
                break;

                case "/MA":
                    foreach (var item in listaIcaoMaranhao)
                    {
                        result += item + "     ";
                    }
                break;

                case "/MT":
                    foreach (var item in listaIcaoMatoGrosso)
                    {
                        result += item + "     ";
                    }
                break;

                case "/MS":
                    foreach (var item in listaIcaoMatoGrossoDoSul)
                    {
                        result += item + "     ";
                    }
                break;

                case "/MG":
                    foreach (var item in listaIcaoMinasGerais)
                    {
                        result += item + "     ";
                    }
                break;

                case "/PA":
                    foreach (var item in listaIcaoPara)
                    {
                        result += item + "     ";
                    };
                break;

                case "/PB":
                    foreach (var item in listaIcaoParaiba)
                    {
                        result += item + "     ";
                    }
                break;

                case "/PR":
                    foreach (var item in listaIcaoParana)
                    {
                        result += item + "     ";
                    }
                break;

                case "/PE":
                    foreach (var item in listaIcaoPernambuco)
                    {
                        result += item + "     ";
                    }
                break;

                case "/PI":
                    foreach (var item in listaIcaoPiaui)
                    {
                        result += item + "     ";
                    }
                break;

                case "/RJ":
                    foreach (var item in listaIcaoRioDeJaneiro)
                    {
                        result += item + "     ";
                    }
                break;

                case "/RN":
                    foreach (var item in listaIcaoRioGrandeDoNorte)
                    {
                        result += item + "     ";
                    }
                break;

                case "/RS":
                    foreach (var item in listaIcaoRioGrandeDoSul)
                    {
                        result += item + "     ";
                    }
                break;

                case "/RO":
                    foreach (var item in listaIcaoRondonia)
                    {
                        result += item + "     ";
                    }
                break;

                case "/RR":
                    foreach (var item in listaIcaoRoraima)
                    {
                        result += item + "     ";
                    }
                break;
                    
                case "/SC":
                    foreach (var item in listaIcaoSantaCatarina)
                    {
                        result += item + "     ";
                    }
                break;

                case "/SP":
                    foreach (var item in listaIcaoSaoPaulo)
                    {
                        result += item + "     ";
                    }
                break;

                case "/SE":
                    foreach (var item in listaIcaoSergipe)
                    {
                        result += item + "     ";
                    }
                break;

                case "/TO":
                    foreach (var item in listaIcaoTocatins)
                    {
                        result += item + "     ";
                    }
                break;

                default:
                    result = "Estado não localizado";
                break;
            }

            return result;
        }
    }
}