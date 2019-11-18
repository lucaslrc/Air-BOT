using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Air_BOT
{
    public class AirportListIcao
    {
        public string GetIcaoInfo(string userIcao)
        {
            var result = string.Empty;

            var GetIcao = new List<IcaoModel>() {
                new IcaoModel {Icao = "SBGR", IcaoInformation = "Aeroporto Internacional de Guarulhos, Governador André Franco Montoro - São Paulo."},
                new IcaoModel {Icao = "SBSP", IcaoInformation = "Aeroporto de Congonhas, Deputado Freitas Nobre - São Paulo."},
                new IcaoModel {Icao = "SBGL", IcaoInformation = "Aeroporto Internacional do Galeão, Tom Jobim - Rio de Janeiro."},
                new IcaoModel {Icao = "SBRJ", IcaoInformation = "Aeroporto do Rio de Janeiro, Santos Dummont - Rio de Janeiro."},
                new IcaoModel {Icao = "SBRF", IcaoInformation = "Aeroporto Internacional do Recife/Guararapes, Gilberto Freyre - Pernambuco."},
                new IcaoModel {Icao = "SBPA", IcaoInformation = "Aeroporto Internacional de Porto Alegre, Salgado Filho - Rio Grande do Sul."},
                new IcaoModel {Icao = "SBCT", IcaoInformation = "Aeroporto Internacional de Curitiba, Afonso Pena - Curitiba"},
                new IcaoModel {Icao = "SBBR", IcaoInformation = "Aeroporto Internacional de Brasília, Presidente Juscelino Kubitschek - Brasília."}
            };

            foreach (var item in GetIcao)
            {
                if (userIcao == item.Icao)
                {
                    result = item.IcaoInformation;
                }
            }

            if(result.Length == 0)
            {
                return "Não foi possível buscar informações sobre este aeroporto.";
            }
            else
            {
                return result;
            }
        }
    }
}