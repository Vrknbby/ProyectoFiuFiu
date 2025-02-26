using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaUIs.Model.Compra
{
    public class OrdenCompraATC
    {
        public string DOC_NRO_OCO { get; set; }
        public string COD_ART { get; set; }
        public string DOC_NRO { get; set; }
        public decimal VAL_ENT_UND { get; set; }
        public decimal VAL_SAL_UND { get; set; }
        public string DOC_REF { get; set; }
        public string TXT_OBSERVACION { get; set; }
        public string COD_USER { get; set; }
        public DateTime FEC_ABM { get; set; }

        public OrdenCompraATC(string dOC_NRO_OCO, string cOD_ART, string dOC_NRO, decimal vAL_ENT_UND, decimal vAL_SAL_UND, string dOC_REF, string tXT_OBSERVACION, string cOD_USER, DateTime fEC_ABM)
        {
            DOC_NRO_OCO = dOC_NRO_OCO;
            COD_ART = cOD_ART;
            DOC_NRO = dOC_NRO;
            VAL_ENT_UND = vAL_ENT_UND;
            VAL_SAL_UND = vAL_SAL_UND;
            DOC_REF = dOC_REF;
            TXT_OBSERVACION = tXT_OBSERVACION;
            COD_USER = cOD_USER;
            FEC_ABM = fEC_ABM;
        }
    }
}
