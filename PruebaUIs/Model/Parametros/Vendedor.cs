using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaUIs.Model.Parametros
{
    public class Vendedor
    {
        public string COD_VEN { get; set; }
        public string COD_PER { get; set; }
        public bool FLG_INH_MOV { get; set; }
        public string COD_USER { get; set; }
        public DateTime FEC_ABM { get; set; }

        public Vendedor()
        {
        }
        public Vendedor(string cOD_PER, bool fLG_INH_MOV, string cOD_USER, DateTime fEC_ABM)
        {
            COD_PER = cOD_PER;
            FLG_INH_MOV = fLG_INH_MOV;
            COD_USER = cOD_USER;
            FEC_ABM = fEC_ABM;
        }

        public Vendedor(string cOD_VEN, string cOD_PER, bool fLG_INH_MOV, string cOD_USER, DateTime fEC_ABM)
        {
            COD_VEN = cOD_VEN;
            COD_PER = cOD_PER;
            FLG_INH_MOV = fLG_INH_MOV;
            COD_USER = cOD_USER;
            FEC_ABM = fEC_ABM;
        }
    }
}
