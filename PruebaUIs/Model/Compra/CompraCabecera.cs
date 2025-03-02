using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaUIs.Model.Compra
{
    public class CompraCabecera
    {
        public char TIP_DOC_COM { get; set; }
        public string DOC_NRO { get; set; }
        public DateTime FEC_MOV { get; set; }
        public string COD_PRV { get; set; }
        public string DOC_NRO_OCO { get; set; }
        public string TXT_OBSERVACION { get; set; }
        public string COD_USER { get; set; }
        public DateTime FEC_ABM { get; set; }

        public CompraCabecera(char tIP_DOC_COM, string dOC_NRO, DateTime fEC_MOV, string cOD_PRV, string dOC_NRO_OCO, string tXT_OBSERVACION, string cOD_USER, DateTime fEC_ABM)
        {
            TIP_DOC_COM = tIP_DOC_COM;
            DOC_NRO = dOC_NRO;
            FEC_MOV = fEC_MOV;
            COD_PRV = cOD_PRV;
            DOC_NRO_OCO = dOC_NRO_OCO;
            TXT_OBSERVACION = tXT_OBSERVACION;
            COD_USER = cOD_USER;
            FEC_ABM = fEC_ABM;
        }
    }
}
