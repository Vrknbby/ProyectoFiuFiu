using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PruebaUIs.Repository;
using PruebaUIs.Model;
namespace PruebaUIs
{
    public partial class Provedor : MaterialForm
    {

        //VARIABLES PARA EL BORDE
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
        int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
        int nWidthEllipse, int nHeightEllipse);


        public Provedor()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 25, 25));

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey800,
                Primary.BlueGrey900,
                Primary.BlueGrey500,
                Accent.Indigo700,
                TextShade.WHITE);
        }

        private void Provedor_Load(object sender, EventArgs e)
        {

        }

        private void buscarProveedorBtn_Click(object sender, EventArgs e)
        {
            string codPrv = codProveedorTxt.Text.ToString();
            ProveedorRepository proveedorRepository = new ProveedorRepository();
            DateTime fechaActual = DateTime.Now;
            Proveedor proveedor = null;
            proveedor = proveedorRepository.BuscarProveedorPorCodigo(codPrv);
            if (proveedor!= null)
            {
                codUserTxt.Text = proveedor.COD_USER.ToString();
                codPersonaTxt.Text = proveedor.COD_PER.ToString();
                if (Convert.ToBoolean(proveedor.FLG_INH_MOV))
                {
                    siProveedorRbtn.Checked = true;
                    noProveedorRbtn.Checked = false;

                }
                else
                {
                    siProveedorRbtn.Checked = false;
                    noProveedorRbtn.Checked = true;
                }
                tiempoAtencionProveedorTxt.Text = proveedor.VAL_TIE_ATC.ToString();
                compraMinimaProveedorTxt.Text = proveedor.VAL_CMN_UMO.ToString();
                fechaCreaModAnuTxt.Value = proveedor.FEC_ABM.Date;

            }
        }

        private void GuardarProveedorBtn_Click(object sender, EventArgs e)
        {
            ProveedorRepository proveedorRepository = new ProveedorRepository();
            DateTime fechaActual = DateTime.Now;
            bool flg = true;

            if (siProveedorRbtn.Checked)
            {
                flg = true;
            }
            else
            {
                flg = false;
            }
            Proveedor proveedor = new Proveedor(GenerarCodigoProveedor(),
                codPersonaTxt.Text, 
                flg,
                int.Parse(tiempoAtencionProveedorTxt.Text.ToString()),
                int.Parse(compraMinimaProveedorTxt.Text.ToString()),
                codUserTxt.Text,
                fechaActual);
            proveedorRepository.InsertarProveedor(proveedor);
        }

        public string GenerarCodigoProveedor()
        {
            ProveedorRepository proveedorRepository = new ProveedorRepository();
            List<Proveedor> proveedores = proveedorRepository.BuscarTodosLosProveedores();
            string ultimoCodigo = proveedores.OrderByDescending(p => p.COD_PRV).Select(p => p.COD_PRV).FirstOrDefault();
            int nuevoNumero = 1;

            if (!string.IsNullOrEmpty(ultimoCodigo))
            {
                string numeroStr = ultimoCodigo.Substring(3);
                if (int.TryParse(numeroStr, out int numero)) nuevoNumero = numero + 1;
            }

            int longDigito = nuevoNumero.ToString().Length + 1;

            string nuevoCodigo = $"PRV{nuevoNumero:D7}";
            while (proveedores.Any(p => p.COD_PRV == nuevoCodigo))
            {
                nuevoNumero++;
                nuevoCodigo = $"PRV{nuevoNumero:D7}";
            }
            return nuevoCodigo;
        }

    }
}
