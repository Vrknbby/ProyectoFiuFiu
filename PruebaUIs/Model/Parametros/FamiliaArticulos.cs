using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaUIs.Model.Parametros
{
    public class FamiliaArticulos
    {
        public string COD_CAT { get; set; }
        public string DES_CAT { get; set; }
        public string COD_LIN { get; set; }
        public string DES_LIN { get; set; }
        public string COD_USER { get; set; }
        public DateTime FEC_ABM { get; set; }

        public FamiliaArticulos(string cOD_CAT, string dES_CAT, string cOD_LIN, string dES_LIN, string cOD_USER, DateTime fEC_ABM)
        {
            COD_CAT = cOD_CAT;
            DES_CAT = dES_CAT;
            COD_LIN = cOD_LIN;
            DES_LIN = dES_LIN;
            COD_USER = cOD_USER;
            FEC_ABM = fEC_ABM;
        }

        public FamiliaArticulos(string dES_CAT, string dES_LIN, string cOD_USER, DateTime fEC_ABM)
        {
            DES_CAT = dES_CAT;
            DES_LIN = dES_LIN;
            COD_USER = cOD_USER;
            FEC_ABM = fEC_ABM;
        }
    }
}
