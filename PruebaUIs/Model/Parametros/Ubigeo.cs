using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaUIs.Model.Parametros
{
    public class Ubigeo
    {
        public string COD_PAIS { get; set; }
        public string DES_PAIS { get; set; }
        public short COD_DPTO { get; set; }
        public string DES_DPTO { get; set; }
        public short COD_CIU { get; set; }
        public string DES_CIU { get; set; }
        public short COD_BARR { get; set; }
        public string DES_BARR { get; set; }
        public string CAR_IDIOMA { get; set; }
        public string DES_CON { get; set; }
        public short COD_REG { get; set; }
        public string UBI_LATITUD { get; set; }
        public string UBI_LONGITUD { get; set; }
        public string COD_USER { get; set; }
        public DateTime FEC_ABM { get; set; }

        public Ubigeo(string cOD_PAIS, string dES_PAIS, short cOD_DPTO, string dES_DPTO,
                        short cOD_CIU, string dES_CIU, short cOD_BARR, string dES_BARR,
                        string cAR_IDIOMA, string dES_CON, short cOD_REG, string uBI_LATITUD,
                        string uBI_LONGITUD, string cOD_USER, DateTime fEC_ABM)
        {
            COD_PAIS = cOD_PAIS;
            DES_PAIS = dES_PAIS;
            COD_DPTO = cOD_DPTO;
            DES_DPTO = dES_DPTO;
            COD_CIU = cOD_CIU;
            DES_CIU = dES_CIU;
            COD_BARR = cOD_BARR;
            DES_BARR = dES_BARR;
            CAR_IDIOMA = cAR_IDIOMA;
            DES_CON = dES_CON;
            COD_REG = cOD_REG;
            UBI_LATITUD = uBI_LATITUD;
            UBI_LONGITUD = uBI_LONGITUD;
            COD_USER = cOD_USER;
            FEC_ABM = fEC_ABM;
        }

        public Ubigeo(string cOD_PAIS, short cOD_DPTO, short cOD_CIU, short cOD_BARR,
                        string dES_PAIS, string dES_DPTO, string dES_CIU, string dES_BARR,
                        string cAR_IDIOMA, string dES_CON, short cOD_REG, string cOD_USER, DateTime fEC_ABM)
        {
            COD_PAIS = cOD_PAIS;
            COD_DPTO = cOD_DPTO;
            COD_CIU = cOD_CIU;
            COD_BARR = cOD_BARR;
            DES_PAIS = dES_PAIS;
            DES_DPTO = dES_DPTO;
            DES_CIU = dES_CIU;
            DES_BARR = dES_BARR;
            CAR_IDIOMA = cAR_IDIOMA;
            DES_CON = dES_CON;
            COD_REG = cOD_REG;
            COD_USER = cOD_USER;
            FEC_ABM = fEC_ABM;
        }
    }
}
