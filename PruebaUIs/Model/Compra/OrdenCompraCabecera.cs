using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaUIs.Model.Compra
{
    public class OrdenCompraCabecera
    {
        public string DOC_NRO_OCO { get; set; }
        public string COD_PRV { get; set; }
        public DateTime FEC_MOV { get; set; }
        public DateTime FEC_REC_MER { get; set; }
        public string NRO_RUC { get; set; }
        public string DOC_REF { get; set; }
        public string TXT_OBSERVACION { get; set; }
        public bool FLG_EST_OCO { get; set; }
        public string COD_USER { get; set; }
        public DateTime FEC_ABM { get; set; }

        public OrdenCompraCabecera(string dOC_NRO_OCO, string cOD_PRV, DateTime fEC_MOV, DateTime fEC_REC_MER, string nRO_RUC, string dOC_REF, string tXT_OBSERVACION, bool fLG_EST_OCO, string cOD_USER, DateTime fEC_ABM)
        {
            DOC_NRO_OCO = dOC_NRO_OCO;
            COD_PRV = cOD_PRV;
            FEC_MOV = fEC_MOV;
            FEC_REC_MER = fEC_REC_MER;
            NRO_RUC = nRO_RUC;
            DOC_REF = dOC_REF;
            TXT_OBSERVACION = tXT_OBSERVACION;
            FLG_EST_OCO = fLG_EST_OCO;
            COD_USER = cOD_USER;
            FEC_ABM = fEC_ABM;
        }
    }
}
