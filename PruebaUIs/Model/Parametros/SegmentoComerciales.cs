using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaUIs.Model.Parametros
{
    public class SegmentoComerciales
    {
        public string COD_SEG { get; set; }
        public string DES_SEG { get; set; }
        public string COD_SSEG { get; set; }
        public string DES_SSEG { get; set; }
        public string COD_USER { get; set; }
        public DateTime FEC_ABM { get; set; }

        public SegmentoComerciales(string cOD_SEG, string dES_SEG, string cOD_SSEG, string dES_SSEG, string cOD_USER, DateTime fEC_ABM)
        {
            COD_SEG = cOD_SEG;
            DES_SEG = dES_SEG;
            COD_SSEG = cOD_SSEG;
            DES_SSEG = dES_SSEG;
            COD_USER = cOD_USER;
            FEC_ABM = fEC_ABM;
        }
        public SegmentoComerciales(string dES_SEG, string cOD_SSEG, string dES_SSEG, string cOD_USER, DateTime fEC_ABM)
        {
            DES_SEG = dES_SEG;
            COD_SSEG = cOD_SSEG;
            DES_SSEG = dES_SSEG;
            COD_USER = cOD_USER;
            FEC_ABM = fEC_ABM;
        }

    }
}
