using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaUIs.Model.Compra
{
    public class CompraDetalle
    {
        public char TIP_DOC_COM { get; set; }
        public string DOC_NRO { get; set; }
        public short NRO_LINEA { get; set; }
        public string COD_ART { get; set; }
        public decimal VAL_COM_UND { get; set; }
        public decimal VAL_BONC_UND { get; set; }
        public decimal VAL_MON_UMO { get; set; }
        public decimal VAL_IVA_UMO { get; set; }
        public string COD_USER { get; set; }
        public DateTime FEC_ABM { get; set; }

        public CompraDetalle(char tIP_DOC_COM, string dOC_NRO, short nRO_LINEA, string cOD_ART, decimal vAL_COM_UND, decimal vAL_BONC_UND, decimal vAL_MON_UMO, decimal vAL_IVA_UMO, string cOD_USER, DateTime fEC_ABM)
        {
            TIP_DOC_COM = tIP_DOC_COM;
            DOC_NRO = dOC_NRO;
            NRO_LINEA = nRO_LINEA;
            COD_ART = cOD_ART;
            VAL_COM_UND = vAL_COM_UND;
            VAL_BONC_UND = vAL_BONC_UND;
            VAL_MON_UMO = vAL_MON_UMO;
            VAL_IVA_UMO = vAL_IVA_UMO;
            COD_USER = cOD_USER;
            FEC_ABM = fEC_ABM;
        }
    }
}
