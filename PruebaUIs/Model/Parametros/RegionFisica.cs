using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaUIs.Model.Parametros
{
    public class RegionFisica
    {
        public short COD_REG { get; set; }
        public string DES_REG { get; set; }
        public string COD_USER { get; set; }
        public DateTime FEC_ABM { get; set; }

        public RegionFisica(short cOD_REG, string dES_REG, string cOD_USER, DateTime fEC_ABM)
        {
            COD_REG = cOD_REG;
            DES_REG = dES_REG;
            COD_USER = cOD_USER;
            FEC_ABM = fEC_ABM;
        }

        public RegionFisica(string dES_REG, string cOD_USER, DateTime fEC_ABM)
        {
            DES_REG = dES_REG;
            COD_USER = cOD_USER;
            FEC_ABM = fEC_ABM;
        }
    }
}
