using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaUIs.Model.Parametros
{
    public class Cliente
    {
        public string COD_CLI { get; set; }
        public string COD_PER { get; set; }
        public string COD_GRP_EMP { get; set; }
        public string COD_VEN { get; set; }
        public string COD_SEG { get; set; }
        public string COD_SSEG { get; set; }
        public bool FLG_INH_MOV { get; set; }
        public string COD_USER { get; set; }
        public DateTime FEC_ABM { get; set; }

        public Cliente(string cOD_CLI, string cOD_PER, string cOD_GRP_EMP, string cOD_VEN,
                         string cOD_SEG, string cOD_SSEG, bool fLG_INH_MOV, string cOD_USER, DateTime fEC_ABM)
        {
            COD_CLI = cOD_CLI;
            COD_PER = cOD_PER;
            COD_GRP_EMP = cOD_GRP_EMP;
            COD_VEN = cOD_VEN;
            COD_SEG = cOD_SEG;
            COD_SSEG = cOD_SSEG;
            FLG_INH_MOV = fLG_INH_MOV;
            COD_USER = cOD_USER;
            FEC_ABM = fEC_ABM;
        }
    }
}
