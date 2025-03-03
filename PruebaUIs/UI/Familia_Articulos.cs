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
    public partial class Familia_Articulos : MaterialForm
    {

        FamiliaArticuloRepository fmaRepository = new FamiliaArticuloRepository();
        bool Modificar = false;
        FamiliaArticulos fmaSelect = null;
        public Familia_Articulos()
        {
            InitializeComponent();
            cargarFMAArticulos();
        }

        private void Familia_Articulos_Load(object sender, EventArgs e)
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
                MessageBox.Show("El usuario ADMIN solo permite el registro de Usuarios.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Validar que se hayan completado los campos obligatorios
            if (string.IsNullOrWhiteSpace(txtCodCategoria.Text) ||
                string.IsNullOrWhiteSpace(txtDesCategoria.Text) ||
                string.IsNullOrWhiteSpace(txtCodLinea.Text) ||
                string.IsNullOrWhiteSpace(txtDesLinea.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime fechaActual = DateTime.Now;
            FamiliaArticulos fma = new FamiliaArticulos(
                txtCodCategoria.Text,
                txtDesCategoria.Text,
                txtCodLinea.Text,
                txtDesLinea.Text,
                Global.UsuarioSesion.COD_USER,
                fechaActual
            );
            fmaRepository.InsertarFMAArticulo(fma);
            Limpiar();
            MessageBox.Show("Registro insertado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Modificar = false;
        }

        private void cargarFMAArticulos()
        {
            // Configurar columnas del ListView si aún no se han creado
            if (tblFamiliaArticulo.Columns.Count == 0)
            {
                tblFamiliaArticulo.Columns.Add("Código de Categoría", 150);
                tblFamiliaArticulo.Columns.Add("Descripción de Categoría", 150);
                tblFamiliaArticulo.Columns.Add("Código de Línea", 150);
                tblFamiliaArticulo.Columns.Add("Descripción de Línea", 150);
                tblFamiliaArticulo.Columns.Add("Código de Usuario", 150);
                tblFamiliaArticulo.Columns.Add("Fecha de Creación", 150);
            }
            tblFamiliaArticulo.Items.Clear();

            List<FamiliaArticulos> fmaList = fmaRepository.BuscarTodosLosFMAArticulos();
            foreach (FamiliaArticulos fma in fmaList)
            {
                ListViewItem item = new ListViewItem(fma.COD_CAT);
                item.SubItems.Add(fma.DES_CAT);
                item.SubItems.Add(fma.COD_LIN);
                item.SubItems.Add(fma.DES_LIN);
                item.SubItems.Add(fma.COD_USER);
                item.SubItems.Add(fma.FEC_ABM.ToString());
                tblFamiliaArticulo.Items.Add(item);
            }
        }

        private void tblFamiliaArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tblFamiliaArticulo.SelectedItems.Count > 0)
            {
                ListViewItem item = tblFamiliaArticulo.SelectedItems[0];

                txtCodCategoria.Text = item.SubItems[0].Text;
                txtDesCategoria.Text = item.SubItems[1].Text;
                txtCodLinea.Text = item.SubItems[2].Text;
                txtDesLinea.Text = item.SubItems[3].Text;
                txtCodUsuario.Text = item.SubItems[4].Text;

                txtCodCategoria.Enabled = false;
                txtCodLinea.Enabled = false;

                fmaSelect = fmaRepository.BuscarFMAArticuloPorCodigo(item.SubItems[0].Text, item.SubItems[2].Text);
                Modificar = true;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioSesion == null || string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                MessageBox.Show("El usuario ADMIN solo permite el registro de Usuarios.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Modificar && fmaSelect != null)
            {

                DateTime fechaActual = DateTime.Now;
                fmaSelect.DES_CAT = txtDesCategoria.Text;
                fmaSelect.DES_LIN = txtDesLinea.Text;
                fmaSelect.COD_USER = Global.UsuarioSesion.COD_USER;
                fmaSelect.FEC_ABM = fechaActual;

                fmaRepository.ActualizarFMAArticulo(fmaSelect);
                MessageBox.Show("Registro actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("Seleccione un registro de la tabla para modificar.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tblFamiliaArticulo.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccione un registro para eliminar.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("¿Está seguro de eliminar el registro seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ListViewItem item = tblFamiliaArticulo.SelectedItems[0];
                string codCat = item.SubItems[0].Text;
                string codLin = item.SubItems[2].Text;
                try
                {
                    fmaRepository.EliminarFMAArticulo(codCat, codLin);
                    Limpiar();
                    MessageBox.Show("Registro eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioSesion == null || string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                MessageBox.Show("El usuario ADMIN solo permite el registro de Usuarios.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CuadroDialogo input = new CuadroDialogo("Ingrese el código de categoría y de línea separados por un espacio", "Buscar Registro");
            if (input.ShowDialog() == DialogResult.OK)
            {

                string[] partes = input.InputText.Split(' ');
                if (partes.Length < 2)
                {
                    MessageBox.Show("Debe ingresar ambos valores: código de segmento y código de subsegmento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string codCat = partes[0].Trim();
                string codLin = partes[1].Trim();


                FamiliaArticulos fma = fmaRepository.BuscarFMAArticuloPorCodigo(codCat, codLin);
                tblFamiliaArticulo.Clear();
                tblFamiliaArticulo.Columns.Add("Código de Categoría", 150);
                tblFamiliaArticulo.Columns.Add("Descripción de Categoría", 150);
                tblFamiliaArticulo.Columns.Add("Código de Línea", 150);
                tblFamiliaArticulo.Columns.Add("Descripción de Línea", 150);
                tblFamiliaArticulo.Columns.Add("Código de Usuario", 150);
                tblFamiliaArticulo.Columns.Add("Fecha de Creación", 150);

                if (fma != null)
                {
                    ListViewItem item = new ListViewItem(fma.COD_CAT);
                    item.SubItems.Add(fma.DES_CAT);
                    item.SubItems.Add(fma.COD_LIN);
                    item.SubItems.Add(fma.DES_LIN);
                    item.SubItems.Add(fma.COD_USER);
                    item.SubItems.Add(fma.FEC_ABM.ToString());
                    tblFamiliaArticulo.Items.Add(item);
                }
                else
                {
                    MessageBox.Show("No se encontró un registro con esos valores.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            txtCodCategoria.Clear();
            txtDesCategoria.Clear();
            txtCodLinea.Clear();
            txtDesLinea.Clear();

            // Habilitar los campos clave en caso de estar deshabilitados
            if (!txtCodCategoria.Enabled)
                txtCodCategoria.Enabled = true;
            if (!txtCodLinea.Enabled)
                txtCodLinea.Enabled = true;

            if (Global.UsuarioSesion != null && !string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                txtCodUsuario.Text = Global.UsuarioSesion.COD_USER;
            }
            else
            {
                txtCodUsuario.Text = "";
            }
            cargarFMAArticulos();
            Modificar = false;
        }
    }
}
