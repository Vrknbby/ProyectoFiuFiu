using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaUIs.Model
{
    public class Usuario
    {
        public string COD_USER { get; set; }
        public string DES_USER { get; set; }
        public string EMAIL_USER { get; set; }
        public string CLAVE_USER { get; set; }
        public bool FLG_EST_USER { get; set; }
        public DateTime FEC_ABM { get; set; }

        public Usuario(string cOD_USER, string dES_USER, string eMAIL_USER, string cLAVE_USER, bool fLG_EST_USER, DateTime fEC_ABM)
        {
            COD_USER = cOD_USER;
            DES_USER = dES_USER;
            EMAIL_USER = eMAIL_USER;
            CLAVE_USER = cLAVE_USER;
            FLG_EST_USER = fLG_EST_USER;
            FEC_ABM = fEC_ABM;
        }

        public Usuario(string dES_USER, string eMAIL_USER, string cLAVE_USER, bool fLG_EST_USER, DateTime fEC_ABM)
        {
            DES_USER = dES_USER;
            EMAIL_USER = eMAIL_USER;
            CLAVE_USER = cLAVE_USER;
            FLG_EST_USER = fLG_EST_USER;
            FEC_ABM = fEC_ABM;
        }


    }
}
