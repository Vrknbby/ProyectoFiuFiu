using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaUIs.Model
{
    public class Locacion
    {


        public bool FLG_DEP_CEN { get; set; }
        public string COD_LOC { get; set; }
        public string DES_LOC { get; set; }
        public DateTime FEC_CREA { get; set; }
        public string DES_NOM_ENC { get; set; }
        public bool FLG_LOC_VIR { get; set; }
        public string COD_PAIS { get; set; }
        public int COD_DPTO { get; set; }
        public int COD_CIU { get; set; }
        public int COD_BARR { get; set; }
        public string DES_DIR_LOC { get; set; }
        public decimal VAL_ZLOC_ALT { get; set; }
        public decimal VAL_ZLOC_SUP { get; set; }
        public int VAL_COB_ESP { get; set; }
        public string COD_USER { get; set; }
        public DateTime FEC_ABM { get; set; }

        public Locacion(bool fLG_DEP_CEN,
            string dES_LOC, DateTime fEC_CREA, string dES_NOM_ENC,
            bool fLG_LOC_VIR, string cOD_PAIS, int cOD_DPTO, int cOD_CIU,
            int cOD_BARR, string dES_DIR_LOC, decimal vAL_ZLOC_ALT, decimal vAL_ZLOC_SUP,
            int vAL_COB_ESP, string cOD_USER, DateTime fEC_ABM)
        {
            FLG_DEP_CEN = fLG_DEP_CEN;
            DES_LOC = dES_LOC;
            FEC_CREA = fEC_CREA;
            DES_NOM_ENC = dES_NOM_ENC;
            FLG_LOC_VIR = fLG_LOC_VIR;
            COD_PAIS = cOD_PAIS;
            COD_DPTO = cOD_DPTO;
            COD_CIU = cOD_CIU;
            COD_BARR = cOD_BARR;
            DES_DIR_LOC = dES_DIR_LOC;
            VAL_ZLOC_ALT = vAL_ZLOC_ALT;
            VAL_ZLOC_SUP = vAL_ZLOC_SUP;
            VAL_COB_ESP = vAL_COB_ESP;
            COD_USER = cOD_USER;
            FEC_ABM = fEC_ABM;
        }
        public Locacion(bool fLG_DEP_CEN, string cOD_LOC,
            string dES_LOC, DateTime fEC_CREA, string dES_NOM_ENC,
            bool fLG_LOC_VIR, string cOD_PAIS, int cOD_DPTO, int cOD_CIU,
            int cOD_BARR, string dES_DIR_LOC, decimal vAL_ZLOC_ALT, decimal vAL_ZLOC_SUP,
            int vAL_COB_ESP, string cOD_USER, DateTime fEC_ABM)
        {
            FLG_DEP_CEN = fLG_DEP_CEN;
            COD_LOC = cOD_LOC;
            DES_LOC = dES_LOC;
            FEC_CREA = fEC_CREA;
            DES_NOM_ENC = dES_NOM_ENC;
            FLG_LOC_VIR = fLG_LOC_VIR;
            COD_PAIS = cOD_PAIS;
            COD_DPTO = cOD_DPTO;
            COD_CIU = cOD_CIU;
            COD_BARR = cOD_BARR;
            DES_DIR_LOC = dES_DIR_LOC;
            VAL_ZLOC_ALT = vAL_ZLOC_ALT;
            VAL_ZLOC_SUP = vAL_ZLOC_SUP;
            VAL_COB_ESP = vAL_COB_ESP;
            COD_USER = cOD_USER;
            FEC_ABM = fEC_ABM;
        }

        public Locacion()
        {
        }
    }



}
