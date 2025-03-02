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

namespace PruebaUIs
{
    public partial class Compra_Articulo : MaterialForm
    {


        public Compra_Articulo()
        {
            InitializeComponent();

            

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

        private void Compra_Articulo_Load(object sender, EventArgs e)
        {

        }

        private void btnFabricante_Click(object sender, EventArgs e)
        {
            Fabricante nuevoform = new Fabricante();
            nuevoform.Show();
           
        }

        private void btnProvedores_Click(object sender, EventArgs e)
        {
            Provedor nuevoform = new Provedor();
            nuevoform.Show();
            
        }
    }
}
