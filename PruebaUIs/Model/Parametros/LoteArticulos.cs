using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaUIs.Model.Parametros
{
    public class LoteArticulos
    {
        public string NRO_LOTE { get; set; }
        public string COD_ART { get; set; }
        public string COD_PRV { get; set; }
        public bool FLG_CON_CONS { get; set; }
        public bool? FLG_CON_CANJE { get; set; }
        public string COD_CARTA { get; set; }
        public DateTime FEC_INI_LOTE { get; set; }
        public DateTime FEC_FIN_LOTE { get; set; }
        public decimal? VAL_MAX_CANJE { get; set; }
        public string COD_USER { get; set; }
        public DateTime FEC_ABM { get; set; }

        public LoteArticulos(string nRO_LOTE, string cOD_ART, string cOD_PRV, bool fLG_CON_CONS, bool? fLG_CON_CANJE, string cOD_CARTA, DateTime fEC_INI_LOTE, DateTime fEC_FIN_LOTE, decimal? vAL_MAX_CANJE, string cOD_USER, DateTime fEC_ABM)
        {
            NRO_LOTE = nRO_LOTE;
            COD_ART = cOD_ART;
            COD_PRV = cOD_PRV;
            FLG_CON_CONS = fLG_CON_CONS;
            FLG_CON_CANJE = fLG_CON_CANJE;
            COD_CARTA = cOD_CARTA;
            FEC_INI_LOTE = fEC_INI_LOTE;
            FEC_FIN_LOTE = fEC_FIN_LOTE;
            VAL_MAX_CANJE = vAL_MAX_CANJE;
            COD_USER = cOD_USER;
            FEC_ABM = fEC_ABM;
        }
    }
}
