using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaUIs.Model.Parametros
{
    public class Persona
    {
        public string COD_PER { get; set; }
        public string DES_PER { get; set; }
        public bool FLG_PER_JUR { get; set; }
        public bool FLG_SEX_PER { get; set; }
        public string COD_PAIS { get; set; }
        public short COD_DPTO { get; set; }
        public short COD_CIU { get; set; }
        public short COD_BARR { get; set; }
        public string DES_DIR { get; set; }
        public string NRO_RUC { get; set; }
        public string EMAIL_EMP { get; set; }
        public string EMP_TELF1 { get; set; }
        public string EMP_TELF2 { get; set; }
        public string WWW_URL { get; set; }
        public string COD_USER { get; set; }
        public DateTime FEC_ABM { get; set; }

        public Persona(string cOD_PER, string dES_PER, bool fLG_PER_JUR, bool fLG_SEX_PER, string cOD_PAIS,
                         short cOD_DPTO, short cOD_CIU, short cOD_BARR, string dES_DIR, string nRO_RUC,
                         string eMAIL_EMP, string eMP_TELF1, string eMP_TELF2, string wWW_URL,
                         string cOD_USER, DateTime fEC_ABM)
        {
            COD_PER = cOD_PER;
            DES_PER = dES_PER;
            FLG_PER_JUR = fLG_PER_JUR;
            FLG_SEX_PER = fLG_SEX_PER;
            COD_PAIS = cOD_PAIS;
            COD_DPTO = cOD_DPTO;
            COD_CIU = cOD_CIU;
            COD_BARR = cOD_BARR;
            DES_DIR = dES_DIR;
            NRO_RUC = nRO_RUC;
            EMAIL_EMP = eMAIL_EMP;
            EMP_TELF1 = eMP_TELF1;
            EMP_TELF2 = eMP_TELF2;
            WWW_URL = wWW_URL;
            COD_USER = cOD_USER;
            FEC_ABM = fEC_ABM;
        }

    }
}
