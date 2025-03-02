using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaUIs.Model.Parametros
{
    public class Articulo
    {
        public string COD_ART { get; set; }
        public string COD_UNICO { get; set; }
        public string COD_PADRE { get; set; }
        public string DES_ART { get; set; }
        public string COD_FABRICANTE { get; set; }
        public string CAR_UND_VTAP { get; set; }
        public string CAR_UND_VTAS { get; set; }
        public short VAL_NCOMP_VTAS { get; set; }
        public decimal CAR_UND_COMPACK { get; set; }
        public string COD_CAT { get; set; }
        public string COD_LIN { get; set; }
        public string COD_MAR { get; set; }
        public string COD_PRV { get; set; }
        public decimal VAL_TAS_IVA { get; set; }
        public decimal VAL_PUM_UMO { get; set; }
        public decimal VAL_CUN_UMO { get; set; }
        public decimal? VAL_SSG_ESP { get; set; }
        public decimal? VAL_STK_EXP { get; set; }
        public decimal? VAL_VTA_MIN { get; set; }
        public bool? FLG_ORIGEN { get; set; }
        public bool FLG_VTA_LIBRE { get; set; }
        public bool FLG_ART_CTR { get; set; }
        public bool FLG_ART_FRA { get; set; }
        public bool FLG_CAD_FRIO { get; set; }
        public bool FLG_ART_INA { get; set; }
        public bool FLG_INH_VTA { get; set; }
        public bool FLG_INH_COM { get; set; }
        public string CAR_ADICIONAL { get; set; }
        public string COD_USER { get; set; }
        public DateTime FEC_ABM { get; set; }

        public Articulo(string cOD_ART, string cOD_UNICO, string cOD_PADRE, string dES_ART, string cOD_FABRICANTE, string cAR_UND_VTAP, string cAR_UND_VTAS, short vAL_NCOMP_VTAS, decimal cAR_UND_COMPACK, string cOD_CAT, string cOD_LIN, string cOD_MAR, string cOD_PRV, decimal vAL_TAS_IVA, decimal vAL_PUM_UMO, decimal vAL_CUN_UMO, decimal? vAL_SSG_ESP, decimal? vAL_STK_EXP, decimal? vAL_VTA_MIN, bool? fLG_ORIGEN, bool fLG_VTA_LIBRE, bool fLG_ART_CTR, bool fLG_ART_FRA, bool fLG_CAD_FRIO, bool fLG_ART_INA, bool fLG_INH_VTA, bool fLG_INH_COM, string cAR_ADICIONAL, string cOD_USER, DateTime fEC_ABM)
        {
            COD_ART = cOD_ART;
            COD_UNICO = cOD_UNICO;
            COD_PADRE = cOD_PADRE;
            DES_ART = dES_ART;
            COD_FABRICANTE = cOD_FABRICANTE;
            CAR_UND_VTAP = cAR_UND_VTAP;
            CAR_UND_VTAS = cAR_UND_VTAS;
            VAL_NCOMP_VTAS = vAL_NCOMP_VTAS;
            CAR_UND_COMPACK = cAR_UND_COMPACK;
            COD_CAT = cOD_CAT;
            COD_LIN = cOD_LIN;
            COD_MAR = cOD_MAR;
            COD_PRV = cOD_PRV;
            VAL_TAS_IVA = vAL_TAS_IVA;
            VAL_PUM_UMO = vAL_PUM_UMO;
            VAL_CUN_UMO = vAL_CUN_UMO;
            VAL_SSG_ESP = vAL_SSG_ESP;
            VAL_STK_EXP = vAL_STK_EXP;
            VAL_VTA_MIN = vAL_VTA_MIN;
            FLG_ORIGEN = fLG_ORIGEN;
            FLG_VTA_LIBRE = fLG_VTA_LIBRE;
            FLG_ART_CTR = fLG_ART_CTR;
            FLG_ART_FRA = fLG_ART_FRA;
            FLG_CAD_FRIO = fLG_CAD_FRIO;
            FLG_ART_INA = fLG_ART_INA;
            FLG_INH_VTA = fLG_INH_VTA;
            FLG_INH_COM = fLG_INH_COM;
            CAR_ADICIONAL = cAR_ADICIONAL;
            COD_USER = cOD_USER;
            FEC_ABM = fEC_ABM;
        }
    }
}
