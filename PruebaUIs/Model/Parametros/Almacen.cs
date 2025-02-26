using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaUIs.Model.Parametros
{
    public class Almacen
    {
        public string COD_ALM { get; set; }
        public string DES_ALM { get; set; }
        public DateTime FEC_CREA { get; set; }
        public string COD_LOC { get; set; }
        public string DES_NOM_ENC { get; set; }
        public decimal? VAL_ZALM_ALT { get; set; }
        public decimal? VAL_ZALM_SUP { get; set; }
        public bool FLG_AMB_CTRL { get; set; }
        public bool FLG_ALM_CANJE { get; set; }
        public string COD_USER { get; set; }
        public DateTime FEC_ABM { get; set; }

        public Almacen(string cOD_ALM, string dES_ALM, DateTime fEC_CREA, string cOD_LOC, string dES_NOM_ENC,
                         decimal? vAL_ZALM_ALT, decimal? vAL_ZALM_SUP, bool fLG_AMB_CTRL, bool fLG_ALM_CANJE,
                         string cOD_USER, DateTime fEC_ABM)
        {
            COD_ALM = cOD_ALM;
            DES_ALM = dES_ALM;
            FEC_CREA = fEC_CREA;
            COD_LOC = cOD_LOC;
            DES_NOM_ENC = dES_NOM_ENC;
            VAL_ZALM_ALT = vAL_ZALM_ALT;
            VAL_ZALM_SUP = vAL_ZALM_SUP;
            FLG_AMB_CTRL = fLG_AMB_CTRL;
            FLG_ALM_CANJE = fLG_ALM_CANJE;
            COD_USER = cOD_USER;
            FEC_ABM = fEC_ABM;
        }
    }
}
