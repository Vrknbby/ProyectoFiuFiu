using MaterialSkin;
using MaterialSkin.Controls;
using PruebaUIs.Model.Parametros;
using PruebaUIs.Repository.Parametros;
using PruebaUIs.Variables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using PruebaUIs.UI;


namespace PruebaUIs
{
    public partial class Marcas_Articulos : MaterialForm
    {
        MarcasArtRepository marcasArtRepository = new MarcasArtRepository();
        bool Modificar = false;
        MarcasArticulos marcaSelect = null;
        public Marcas_Articulos()
        {
            InitializeComponent();
            cargarMarcas();
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

        private void Marcas_Articulos_Load(object sender, EventArgs e)
        {
            if (Global.UsuarioSesion != null && !string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                txtCodUsuario.Text = Global.UsuarioSesion.COD_USER;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioSesion == null || string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                MessageBox.Show("El usuario ADMIN solo permite el registro de Usuarios.",
                                  "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCodMarca.Text) ||
                string.IsNullOrWhiteSpace(txtDesMarca.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.",
                                  "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime fechaActual = DateTime.Now;
            MarcasArticulos marca = new MarcasArticulos(
                txtCodMarca.Text,
                txtDesMarca.Text,
                Global.UsuarioSesion.COD_USER,
                fechaActual
            );
            marcasArtRepository.InsertarMarca(marca);
            Limpiar();
            MessageBox.Show("Marca insertada correctamente",
                              "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Modificar = false;
        }

        private void cargarMarcas()
        {

            if (tblMarcasArticulos.Columns.Count == 0)
            {
                tblMarcasArticulos.Columns.Add("Código de Marca", 150);
                tblMarcasArticulos.Columns.Add("Descripción", 150);
                tblMarcasArticulos.Columns.Add("Código de Usuario", 150);
                tblMarcasArticulos.Columns.Add("Fecha de Creación", 150);
            }
            tblMarcasArticulos.Items.Clear();
            List<MarcasArticulos> marcas = marcasArtRepository.BuscarTodasLasMarcas();
            foreach (MarcasArticulos marca in marcas)
            {
                ListViewItem item = new ListViewItem(marca.COD_MAR);
                item.SubItems.Add(marca.DES_MAR);
                item.SubItems.Add(marca.COD_USER);
                item.SubItems.Add(marca.FEC_ABM.ToString());
                tblMarcasArticulos.Items.Add(item);
            }
        }

        private void tblMarcasArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tblMarcasArticulos.SelectedItems.Count > 0)
            {
                ListViewItem item = tblMarcasArticulos.SelectedItems[0];
                
                txtCodMarca.Text = item.SubItems[0].Text;
                txtDesMarca.Text = item.SubItems[1].Text;
                txtCodUsuario.Text = item.SubItems[2].Text;
                txtCodMarca.Enabled = false;
                marcaSelect = marcasArtRepository.BuscarMarcaPorCodigo(item.SubItems[0].Text);
                Modificar = true;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioSesion == null || string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                MessageBox.Show("El usuario ADMIN solo permite el registro de Usuarios.",
                                  "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Modificar && marcaSelect != null)
            {

                DateTime fechaActual = DateTime.Now;
                marcaSelect.DES_MAR = txtDesMarca.Text;
                marcaSelect.COD_USER = Global.UsuarioSesion.COD_USER;
                marcaSelect.FEC_ABM = fechaActual;

                marcasArtRepository.ActualizarMarca(marcaSelect);
                MessageBox.Show("Marca actualizada correctamente",
                                  "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("Seleccione una marca de la tabla para modificar.",
                                  "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tblMarcasArticulos.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccione una marca para eliminar.",
                                  "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("¿Está seguro de eliminar la marca seleccionada?",
                                                    "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ListViewItem item = tblMarcasArticulos.SelectedItems[0];
                string codMar = item.SubItems[0].Text;
                try
                {
                    marcasArtRepository.EliminarMarca(codMar);
                    Limpiar();
                    MessageBox.Show("Marca eliminada correctamente.",
                                      "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar la marca: " + ex.Message,
                                      "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioSesion == null || string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                MessageBox.Show("El usuario ADMIN solo permite el registro de Usuarios.",
                                  "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CuadroDialogo input = new CuadroDialogo("Ingrese el código de la marca a buscar", "Buscar Marca");
            if (input.ShowDialog() == DialogResult.OK)
            {
                string mensaje = input.InputText;
                if (!string.IsNullOrWhiteSpace(mensaje))
                {
                    List<MarcasArticulos> marcas = marcasArtRepository.BuscarTodasLasMarcas();
                    tblMarcasArticulos.Clear();
                    tblMarcasArticulos.Columns.Add("Código de Marca", 150);
                    tblMarcasArticulos.Columns.Add("Descripción", 150);
                    tblMarcasArticulos.Columns.Add("Código de Usuario", 150);
                    tblMarcasArticulos.Columns.Add("Fecha de Creación", 150);

                    foreach (MarcasArticulos marca in marcas)
                    {
                        if (marca.COD_MAR.ToLower().Contains(mensaje.ToLower()) ||
                            marca.DES_MAR.ToLower().Contains(mensaje.ToLower()))
                        {
                            ListViewItem item = new ListViewItem(marca.COD_MAR);
                            item.SubItems.Add(marca.DES_MAR);
                            item.SubItems.Add(marca.COD_USER);
                            item.SubItems.Add(marca.FEC_ABM.ToString());
                            tblMarcasArticulos.Items.Add(item);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debe ingresar un mensaje válido.",
                                      "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Limpiar()
        {
            txtCodMarca.Clear();
            txtDesMarca.Clear();
            // Habilitar el campo de código en caso de que esté deshabilitado
            if (!txtCodMarca.Enabled)
                txtCodMarca.Enabled = true;

            if (Global.UsuarioSesion != null && !string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                txtCodUsuario.Text = Global.UsuarioSesion.COD_USER;
            }
            else
            {
                txtCodUsuario.Text = "";
            }
            cargarMarcas();
            Modificar = false;
        }
    }
}
