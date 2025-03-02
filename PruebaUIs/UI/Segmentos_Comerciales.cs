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
    public partial class Segmentos_Comerciales : MaterialForm
    {

        SegmentosComercialesRepository segComRepository = new SegmentosComercialesRepository();
        bool Modificar = false;
        SegmentoComerciales segComSelect = null;
        public Segmentos_Comerciales()
        {
            InitializeComponent();
            cargarSegmentos();
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

        private void Segmentos_Comerciales_Load(object sender, EventArgs e)
        {
            if (Global.UsuarioSesion != null && !string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                TxtCodUsuario.Text = Global.UsuarioSesion.COD_USER;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioSesion == null || string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                MessageBox.Show("El usuario ADMIN solo permite el registro de Usuarios.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (string.IsNullOrWhiteSpace(txtCodSegmento.Text) ||
                string.IsNullOrWhiteSpace(txtDesSegmento.Text) ||
                string.IsNullOrWhiteSpace(txtCodSubSegmento.Text) ||
                string.IsNullOrWhiteSpace(txtDesSubSegmento.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime fechaActual = DateTime.Now;
            SegmentoComerciales segCom = new SegmentoComerciales(
                txtCodSegmento.Text,
                txtDesSegmento.Text,
                txtCodSubSegmento.Text,
                txtDesSubSegmento.Text,
                Global.UsuarioSesion.COD_USER,
                fechaActual
            );
            segComRepository.InsertarSegmentoComercial(segCom);
            Limpiar();
            MessageBox.Show("Segmento y subsegmento insertados correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Modificar = false;
        }

        private void Limpiar()
        {
            txtCodSegmento.Clear();
            txtDesSegmento.Clear();
            txtCodSubSegmento.Clear();
            txtDesSubSegmento.Clear();
            if (!txtCodSegmento.Enabled)
            {
                txtCodSegmento.Enabled = true;
            }
            if (!txtCodSubSegmento.Enabled)
            {
                txtCodSubSegmento.Enabled = true;
            }
            if (Global.UsuarioSesion != null && !string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                TxtCodUsuario.Text = Global.UsuarioSesion.COD_USER;
            }
            else
            {
                TxtCodUsuario.Text = "";
            }
            cargarSegmentos();
            Modificar = false;
        }

        private void cargarSegmentos()
        {
            if (tblSegmentosComerciales.Columns.Count == 0)
            {
                tblSegmentosComerciales.Columns.Add("Código de Segmento", 150);
                tblSegmentosComerciales.Columns.Add("Descripción de Segmento", 150);
                tblSegmentosComerciales.Columns.Add("Código de Subsegmento", 150);
                tblSegmentosComerciales.Columns.Add("Descripción de Subsegmento", 150);
                tblSegmentosComerciales.Columns.Add("Código de Usuario", 150);
                tblSegmentosComerciales.Columns.Add("Fecha de Creación", 150);
            }

            tblSegmentosComerciales.Items.Clear();

            List<SegmentoComerciales> segmentos = segComRepository.BuscarTodosLosSegmentosComerciales();

            foreach (SegmentoComerciales seg in segmentos)
            {
                ListViewItem item = new ListViewItem(seg.COD_SEG);
                item.SubItems.Add(seg.DES_SEG);
                item.SubItems.Add(seg.COD_SSEG);
                item.SubItems.Add(seg.DES_SSEG);
                item.SubItems.Add(seg.COD_USER);
                item.SubItems.Add(seg.FEC_ABM.ToString());
                tblSegmentosComerciales.Items.Add(item);
            }
        }

        private void tblSegmentosComerciales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tblSegmentosComerciales.SelectedItems.Count > 0)
            {
                ListViewItem item = tblSegmentosComerciales.SelectedItems[0];
                string codSeg = item.SubItems[0].Text;
                string codSseg = item.SubItems[2].Text;

                txtCodSegmento.Text = item.SubItems[0].Text;
                txtDesSegmento.Text = item.SubItems[1].Text;
                txtCodSubSegmento.Text = item.SubItems[2].Text;
                txtDesSubSegmento.Text = item.SubItems[3].Text;
                TxtCodUsuario.Text = item.SubItems[4].Text;

                txtCodSegmento.Enabled = false;
                txtCodSubSegmento.Enabled = false;

                segComSelect = segComRepository.BuscarSegmentoComercialPorCodigo(codSeg, codSseg);
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

            if (Modificar && segComSelect != null)
            {

                DateTime fechaActual = DateTime.Now;
                segComSelect.COD_SEG = txtCodSegmento.Text;
                segComSelect.DES_SEG = txtDesSegmento.Text;
                segComSelect.COD_SSEG = txtCodSubSegmento.Text;
                segComSelect.DES_SSEG = txtDesSubSegmento.Text;
                segComSelect.COD_USER = Global.UsuarioSesion.COD_USER;
                segComSelect.FEC_ABM = fechaActual;

                segComRepository.ActualizarSegmentoComercial(segComSelect);
                Limpiar();
                MessageBox.Show("Segmento y subsegmento actualizados correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Seleccione un segmento y subsegmento de la tabla para modificar.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioSesion == null || string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                MessageBox.Show("El usuario ADMIN solo permite el registro de Usuarios.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CuadroDialogo input = new CuadroDialogo("Ingrese el código de segmento y subsegmento separados por un espacio", "Buscar Segmento");
            if (input.ShowDialog() == DialogResult.OK)
            {
                string[] partes = input.InputText.Split(' ');
                if (partes.Length < 2)
                {
                    MessageBox.Show("Debe ingresar ambos valores: código de segmento y código de subsegmento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string codSeg = partes[0].Trim();
                string codSseg = partes[1].Trim();

                SegmentoComerciales seg = segComRepository.BuscarSegmentoComercialPorCodigo(codSeg, codSseg);
                tblSegmentosComerciales.Clear();
                tblSegmentosComerciales.Columns.Add("Código de Segmento", 150);
                tblSegmentosComerciales.Columns.Add("Descripción de Segmento", 150);
                tblSegmentosComerciales.Columns.Add("Código de Subsegmento", 150);
                tblSegmentosComerciales.Columns.Add("Descripción de Subsegmento", 150);
                tblSegmentosComerciales.Columns.Add("Código de Usuario", 150);
                tblSegmentosComerciales.Columns.Add("Fecha de Creación", 150);

                if (seg != null)
                {
                    ListViewItem item = new ListViewItem(seg.COD_SEG);
                    item.SubItems.Add(seg.DES_SEG);
                    item.SubItems.Add(seg.COD_SSEG);
                    item.SubItems.Add(seg.DES_SSEG);
                    item.SubItems.Add(seg.COD_USER);
                    item.SubItems.Add(seg.FEC_ABM.ToString());
                    tblSegmentosComerciales.Items.Add(item);
                }
                else
                {
                    MessageBox.Show("No se encontró un segmento con esos valores.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tblSegmentosComerciales.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccione un segmento para eliminar.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("¿Está seguro de eliminar el segmento seleccionado?",
                                            "Confirmar eliminación",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ListViewItem item = tblSegmentosComerciales.SelectedItems[0];
                string codSeg = item.SubItems[0].Text;
                string codSseg = item.SubItems[2].Text;

                try
                {
                    segComRepository.EliminarSegmentoComercial(codSeg, codSseg);
                    Limpiar();
                    MessageBox.Show("Segmento y subsegmento eliminados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al eliminar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
