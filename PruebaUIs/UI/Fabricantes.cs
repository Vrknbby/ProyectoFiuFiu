using MaterialSkin;
using MaterialSkin.Controls;
using PruebaUIs.Model.Parametros;
using PruebaUIs.Repository.Parametros;
using PruebaUIs.UI;
using PruebaUIs.Variables;
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
using Fabricantes = PruebaUIs.Model.Parametros.Fabricante;
namespace PruebaUIs
{
    public partial class Fabricante : MaterialForm
    {
        private FabricanteRepository fabricanteRepository = new FabricanteRepository();
        private PersonaRepository personaRepository = new PersonaRepository();
        private Fabricantes fabricanteSelect = null;
        public Fabricante()
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
            CargarFabricantes();
            CargarPersonas();
        }
        private void CargarPersonas()
        {
            var personas = personaRepository.BuscarTodasLasPersonas();
            personas.Insert(0, new Personas { COD_PER = "", DES_PER = "-- Seleccionar --" });

            cboPersona.DataSource = personas;
            cboPersona.DisplayMember = "DES_PER";
            cboPersona.ValueMember = "COD_PER";
        }
        private void CargarFabricantes()
        {
            try
            {
                if (tblFabricantes.Columns.Count == 0)
                {
                    tblFabricantes.Columns.Add("Código del fabricante", 100);
                    tblFabricantes.Columns.Add("Código del persona", 100);
                    tblFabricantes.Columns.Add("Código de usuario", 80);
                    tblFabricantes.Columns.Add("Fecha de Creación/Modificación/Anulación", 150);
                }
                tblFabricantes.Items.Clear();

                List<Fabricantes> lista = fabricanteRepository.BuscarTodosLosFabricantes();
                foreach (Fabricantes fab in lista)
                {
                    ListViewItem item = new ListViewItem(fab.COD_FABRICANTE);
                    item.SubItems.Add(fab.COD_PER);

                    item.SubItems.Add(fab.COD_USER);
                    item.SubItems.Add(fab.FEC_ABM.ToString());
                    tblFabricantes.Items.Add(item);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar fabricantes: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string GenerarCodigoFabricante()
        {
            List<Fabricantes> fabricantes = fabricanteRepository.BuscarTodosLosFabricantes();
            string ultimoCodigo = fabricantes.OrderByDescending(p => p.COD_FABRICANTE).Select(p => p.COD_FABRICANTE).FirstOrDefault();
            int nuevoNumero = 1;

            if (!string.IsNullOrEmpty(ultimoCodigo))
            {
                string numeroStr = ultimoCodigo.Substring(3);
                if (int.TryParse(numeroStr, out int numero)) nuevoNumero = numero + 1;
            }

            int longDigito = nuevoNumero.ToString().Length + 1;

            string nuevoCodigo = $"FAB{nuevoNumero:D7}";
            while (fabricantes.Any(p => p.COD_FABRICANTE == nuevoCodigo))
            {
                nuevoNumero++;
                nuevoCodigo = $"FAB{nuevoNumero:D7}";
            }
            return nuevoCodigo;
        }

        private void Fabricante_Load(object sender, EventArgs e)
        {
            if (Global.UsuarioSesion != null && !string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                codUsuarioTxt.Text = Global.UsuarioSesion.COD_USER;

            }
        }

        private void buscarBtn_Click(object sender, EventArgs e)
        {
            CuadroDialogo input = new CuadroDialogo("Ingrese el código del fabricante a buscar", "Buscar Vendedor");
            if (input.ShowDialog() == DialogResult.OK)
            {
                string codBuscado = input.InputText;
                if (string.IsNullOrWhiteSpace(codBuscado))
                {
                    MessageBox.Show("Debe ingresar un código de fabricante válido.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Fabricantes fab = fabricanteRepository.BuscarFabricantePorCodigo(codBuscado);

                tblFabricantes.Clear();
                tblFabricantes.Columns.Add("Código del fabricante", 100);
                tblFabricantes.Columns.Add("Código del persona", 100);
                tblFabricantes.Columns.Add("Código de usuario", 80);
                tblFabricantes.Columns.Add("Fecha de Creación/Modificación/Anulación", 150);

                if (fab != null)
                {
                    ListViewItem item = new ListViewItem(fab.COD_FABRICANTE);
                    item.SubItems.Add(fab.COD_PER);
                    item.SubItems.Add(fab.COD_USER);
                    item.SubItems.Add(fab.FEC_ABM.ToString());
                    tblFabricantes.Items.Add(item);
                }
                else
                {
                    MessageBox.Show("No se encontró un fabricante con ese código.",
                                    "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void guardarBtn_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioSesion == null || string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                MessageBox.Show("El usuario ADMIN solo permite el registro de Usuarios.",
                                "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboPersona.SelectedIndex <= 0 )
            {
                MessageBox.Show("Complete todos los campos obligatorios.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DateTime fechaActual = DateTime.Now;

            Fabricantes fabricante = new Fabricantes(GenerarCodigoFabricante(),
                cboPersona.SelectedValue.ToString(),
                codUsuarioTxt.Text,
                fechaActual);
            fabricanteRepository.InsertarFabricante(fabricante);
            Limpiar();

        }

        private void tblFabricantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tblFabricantes.SelectedItems.Count > 0)
            {
                try
                {

                    ListViewItem item = tblFabricantes.SelectedItems[0];
                    string codVen = item.SubItems[0].Text;


                    fabricanteSelect = fabricanteRepository.BuscarFabricantePorCodigo(codVen);
                    if (fabricanteSelect != null)
                    {

                        codFabricanteTxt.Text = fabricanteSelect.COD_FABRICANTE;
                        cboPersona.SelectedValue = fabricanteSelect.COD_PER;
                        codUsuarioTxt.Text = fabricanteSelect.COD_USER;


                        fechaCreaModAnuTxt.Value = fabricanteSelect.FEC_ABM;

                        cboPersona.Refresh();
                        Application.DoEvents();
                        modificarBtn.Enabled = true;
                        guardarBtn.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void Limpiar()
        {
            codFabricanteTxt.Text = "";
            if (Global.UsuarioSesion != null && !string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
                codUsuarioTxt.Text = Global.UsuarioSesion.COD_USER;
            else
                codUsuarioTxt.Text = ""; cboPersona.SelectedIndex = 0;
            cboPersona.Refresh();
            fechaCreaModAnuTxt.Value = DateTime.Now;
            modificarBtn.Enabled = false;
            guardarBtn.Enabled = true;
            fabricanteSelect = null;
            CargarFabricantes();
        }

        private void cancelarBtn_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void eliminarBtn_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioSesion == null || string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                MessageBox.Show("El usuario ADMIN solo permite el registro de Usuarios.",
                                "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (fabricanteSelect == null)
            {
                MessageBox.Show("Seleccione un fabricante para eliminar.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("¿Está seguro de eliminar el fabricante seleccionado?",
                  "Confirmar eliminación",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    fabricanteRepository.EliminarFabricante(fabricanteSelect.COD_FABRICANTE);

                    Limpiar();

                    MessageBox.Show("Fabricante eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void modificarBtn_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioSesion == null || string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                MessageBox.Show("El usuario ADMIN solo permite el registro de Usuarios.",
                                "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DateTime fechaActual = DateTime.Now;
            fabricanteSelect.COD_USER = Global.UsuarioSesion.COD_USER;
            fabricanteSelect.COD_PER = cboPersona.SelectedValue.ToString();

            fabricanteSelect.FEC_ABM = fechaActual;

            fabricanteRepository.ActualizarFabricante(fabricanteSelect);
            MessageBox.Show("Fabricante actualizada correctamente.",
                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Limpiar();

        }
    }
}

