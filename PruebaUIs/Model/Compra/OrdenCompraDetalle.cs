using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaUIs.Model.Compra
{
    public class OrdenCompraDetalle
    {
        public string DOC_NRO_OCO { get; set; }
        public short NRO_LINEA { get; set; }
        public string COD_ART { get; set; }
        public decimal VAL_VTA_UND { get; set; }
        public decimal VAL_BONV_UND { get; set; }
        public decimal VAL_MON_UMO { get; set; }
        public decimal VAL_CVT_UMO { get; set; }
        public decimal VAL_IVA_UMO { get; set; }
        public decimal VAL_ENT_UND { get; set; }
        public decimal VAL_SAL_UND { get; set; }
        public string COD_USER { get; set; }
        public DateTime FEC_ABM { get; set; }

        public OrdenCompraDetalle(string dOC_NRO_OCO, short nRO_LINEA, string cOD_ART, decimal vAL_VTA_UND, decimal vAL_BONV_UND, decimal vAL_MON_UMO, decimal vAL_CVT_UMO, decimal vAL_IVA_UMO, decimal vAL_ENT_UND, decimal vAL_SAL_UND, string cOD_USER, DateTime fEC_ABM)
        {
            DOC_NRO_OCO = dOC_NRO_OCO;
            NRO_LINEA = nRO_LINEA;
            COD_ART = cOD_ART;
            VAL_VTA_UND = vAL_VTA_UND;
            VAL_BONV_UND = vAL_BONV_UND;
            VAL_MON_UMO = vAL_MON_UMO;
            VAL_CVT_UMO = vAL_CVT_UMO;
            VAL_IVA_UMO = vAL_IVA_UMO;
            VAL_ENT_UND = vAL_ENT_UND;
            VAL_SAL_UND = vAL_SAL_UND;
            COD_USER = cOD_USER;
            FEC_ABM = fEC_ABM;
        }
    }
}
