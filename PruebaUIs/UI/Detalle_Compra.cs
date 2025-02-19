using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaUIs
{
    public partial class Detalle_Compra : MaterialForm
    {
        public Detalle_Compra()
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

        private void Detalle_Compra_Load(object sender, EventArgs e)
        {

        }

        private void btnRegresarDetalleCompra_Click(object sender, EventArgs e)
        {
            Menu form = new Menu();
            form.Show(); // Abre el formulario anterior
            this.Close(); // Cierra el formulario actual
        }
    }
}
