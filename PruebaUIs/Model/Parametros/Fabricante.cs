using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaUIs.Model.Parametros
{
    public class Fabricante
    {
        public string COD_FABRICANTE { get; set; }
        public string COD_PER { get; set; }
        public string COD_USER { get; set; }
        public DateTime FEC_ABM { get; set; }

        public Fabricante(string cOD_FABRICANTE, string cOD_PER, string cOD_USER, DateTime fEC_ABM)
        {
            COD_FABRICANTE = cOD_FABRICANTE;
            COD_PER = cOD_PER;
            COD_USER = cOD_USER;
            FEC_ABM = fEC_ABM;
        }
    }
}
