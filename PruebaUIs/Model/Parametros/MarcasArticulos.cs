using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaUIs.Model.Parametros
{
    public class MarcasArticulos
    {
        public string COD_MAR { get; set; }
        public string DES_MAR { get; set; }
        public string COD_USER { get; set; }
        public DateTime FEC_ABM { get; set; }

        public MarcasArticulos(string cOD_MAR, string dES_MAR, string cOD_USER, DateTime fEC_ABM)
        {
            COD_MAR = cOD_MAR;
            DES_MAR = dES_MAR;
            COD_USER = cOD_USER;
            FEC_ABM = fEC_ABM;
        }

        public MarcasArticulos(string dES_MAR, string cOD_USER, DateTime fEC_ABM)
        {
            DES_MAR = dES_MAR;
            COD_USER = cOD_USER;
            FEC_ABM = fEC_ABM;
        }
    }
}
