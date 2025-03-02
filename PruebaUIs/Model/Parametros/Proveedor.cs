using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaUIs.Model
{
    class Proveedor
    {
        public string COD_PRV { get; set; }
        public string COD_PER { get; set; }
        public bool FLG_INH_MOV { get; set; }
        public int VAL_TIE_ATC { get; set; }
        public int VAL_CMN_UMO { get; set; }
        public string COD_USER { get; set; }
        public DateTime FEC_ABM { get; set; }


        public Proveedor(string cOD_PRV, string cOD_PER,
            bool fLG_INH_MOV, int vAL_TIE_ATC, int vAL_CMN_UMO,
            string cOD_USER, DateTime fEC_ABM)
        {
            COD_PRV = cOD_PRV;
            COD_PER = cOD_PER;
            FLG_INH_MOV = fLG_INH_MOV;
            VAL_TIE_ATC = vAL_TIE_ATC;
            VAL_CMN_UMO = vAL_CMN_UMO;
            COD_USER = cOD_USER;
            FEC_ABM = fEC_ABM;
        }
        public Proveedor(string cOD_PER,
            bool fLG_INH_MOV, int vAL_TIE_ATC, int vAL_CMN_UMO,
            string cOD_USER, DateTime fEC_ABM)
        {
            COD_PER = cOD_PER;
            FLG_INH_MOV = fLG_INH_MOV;
            VAL_TIE_ATC = vAL_TIE_ATC;
            VAL_CMN_UMO = vAL_CMN_UMO;
            COD_USER = cOD_USER;
            FEC_ABM = fEC_ABM;
        }

    }
}
