using MaterialSkin.Controls;
using System;
using PruebaUIs.Model.Parametros;
using PruebaUIs.Repository.Parametros;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PruebaUIs.Variables;
using PruebaUIs.UI;

namespace PruebaUIs
{
    public partial class Vendedores : MaterialForm
    {
        private Vendedor vendedorSelect = null;
        private VendedorRepository vendedorRepository = new VendedorRepository();
        private PersonaRepository personaRepository = new PersonaRepository();

        public Vendedores()
        {
            InitializeComponent();
        }

        private void Vendedores_Load(object sender, EventArgs e)
        {
            if (Global.UsuarioSesion != null && !string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                codUserTxt.Text = Global.UsuarioSesion.COD_USER;

            }
            CargarVendedores();
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

        private void CargarVendedores()
        {
            try
            {
                if (tblVendedores.Columns.Count == 0)
                {
                    tblVendedores.Columns.Add("Código del vendedor", 100);
                    tblVendedores.Columns.Add("Código del persona", 100);
                    tblVendedores.Columns.Add("Inhabilitado para realizar operaciones (S/N)", 100);
                    tblVendedores.Columns.Add("Código de usuario", 80);
                    tblVendedores.Columns.Add("Fecha de Creación/Modificación/Anulación", 150);
                }
                tblVendedores.Items.Clear();

                List<Vendedor> lista = vendedorRepository.BuscarTodosLosVendedores();
                foreach (Vendedor prov in lista)
                {
                    ListViewItem item = new ListViewItem(prov.COD_VEN);
                    item.SubItems.Add(prov.COD_PER);
                    item.SubItems.Add((prov.FLG_INH_MOV == true) ? "Sí" : "No");

                    item.SubItems.Add(prov.COD_USER);
                    item.SubItems.Add(prov.FEC_ABM.ToString());
                    tblVendedores.Items.Add(item);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar vendedores: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string GenerarCodigoVendedor()
        {
            List<Vendedor> vendedores = vendedorRepository.BuscarTodosLosVendedores();
            string ultimoCodigo = vendedores.OrderByDescending(p => p.COD_VEN).Select(p => p.COD_VEN).FirstOrDefault();
            int nuevoNumero = 1;

            if (!string.IsNullOrEmpty(ultimoCodigo))
            {
                string numeroStr = ultimoCodigo.Substring(3);
                if (int.TryParse(numeroStr, out int numero)) nuevoNumero = numero + 1;
            }

            int longDigito = nuevoNumero.ToString().Length + 1;

            string nuevoCodigo = $"VEN{nuevoNumero:D7}";
            while (vendedores.Any(p => p.COD_VEN == nuevoCodigo))
            {
                nuevoNumero++;
                nuevoCodigo = $"VEN{nuevoNumero:D7}";
            }
            return nuevoCodigo;
        }

        private void guardarBtn_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioSesion == null || string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                MessageBox.Show("El usuario ADMIN solo permite el registro de Usuarios.",
                                "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboPersona.SelectedIndex <= 0 ||
                (!rbtInhabilitadoNo.Checked && !rbtInhabilitadoSi.Checked))
            {
                MessageBox.Show("Complete todos los campos obligatorios.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DateTime fechaActual = DateTime.Now;
            bool flg = true;

            if (rbtInhabilitadoSi.Checked)
            {
                flg = true;
            }
            else
            {
                flg = false;
            }
            Vendedor proveedor = new Vendedor(GenerarCodigoVendedor(),
                cboPersona.SelectedValue.ToString(),
                flg,
                codUserTxt.Text,
                fechaActual);
            vendedorRepository.InsertarVendedor(proveedor);
            Limpiar();

        }

        private void buscarBtn_Click(object sender, EventArgs e)
        {

            CuadroDialogo input = new CuadroDialogo("Ingrese el código del vendedor a buscar", "Buscar Vendedor");
            if (input.ShowDialog() == DialogResult.OK)
            {
                string codBuscado = input.InputText;
                if (string.IsNullOrWhiteSpace(codBuscado))
                {
                    MessageBox.Show("Debe ingresar un código de vendedor válido.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Vendedor prv = vendedorRepository.BuscarVendedorPorCodigo(codBuscado);

                tblVendedores.Clear();
                tblVendedores.Columns.Add("Código del vendedor", 100);
                tblVendedores.Columns.Add("Código del persona", 100);
                tblVendedores.Columns.Add("Inhabilitado para realizar operaciones (S/N)", 100);
                tblVendedores.Columns.Add("Código de usuario", 80);
                tblVendedores.Columns.Add("Fecha de Creación/Modificación/Anulación", 150);

                if (prv != null)
                {
                    ListViewItem item = new ListViewItem(prv.COD_VEN);
                    item.SubItems.Add(prv.COD_PER);
                    item.SubItems.Add((prv.FLG_INH_MOV == true) ? "Sí" : "No");
                    item.SubItems.Add(prv.COD_USER);
                    item.SubItems.Add(prv.FEC_ABM.ToString());
                    tblVendedores.Items.Add(item);
                }
                else
                {
                    MessageBox.Show("No se encontró un vendedor con ese código.",
                                    "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void tblVendedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tblVendedores.SelectedItems.Count > 0)
            {
                try
                {

                    ListViewItem item = tblVendedores.SelectedItems[0];
                    string codVen = item.SubItems[0].Text;


                    vendedorSelect = vendedorRepository.BuscarVendedorPorCodigo(codVen);
                    if (vendedorSelect != null)
                    {

                        codVendedorTxt.Text = vendedorSelect.COD_VEN;
                        cboPersona.SelectedValue = vendedorSelect.COD_PER;
                        codUserTxt.Text = vendedorSelect.COD_USER;

                        if (vendedorSelect.FLG_INH_MOV == true)
                        {
                            rbtInhabilitadoNo.Checked = false;
                            rbtInhabilitadoSi.Checked = true;
                        }
                        else
                        {
                            rbtInhabilitadoNo.Checked = true;
                            rbtInhabilitadoSi.Checked = false;
                        }
                        fechaCreaModAnuTxt.Value = vendedorSelect.FEC_ABM;

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

        private void Limpiar()
        {
            codVendedorTxt.Text = "";
            if (Global.UsuarioSesion != null && !string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
                codUserTxt.Text = Global.UsuarioSesion.COD_USER;
            else
                codUserTxt.Text = ""; cboPersona.SelectedIndex = 0;
            cboPersona.Refresh();
            rbtInhabilitadoSi.Checked = false;
            rbtInhabilitadoNo.Checked = false;
            fechaCreaModAnuTxt.Value = DateTime.Now;
            modificarBtn.Enabled = false;
            guardarBtn.Enabled = true;
            vendedorSelect = null;
            CargarVendedores();
        }

        private void cancelarBtn_Click(object sender, EventArgs e)
        {
            Limpiar();
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
            vendedorSelect.COD_USER = Global.UsuarioSesion.COD_USER;
            vendedorSelect.COD_PER = cboPersona.SelectedValue.ToString();

            if (rbtInhabilitadoSi.Checked)
            {
                vendedorSelect.FLG_INH_MOV = true;
            }
            else
            {
                vendedorSelect.FLG_INH_MOV = false;
            }
            vendedorSelect.FEC_ABM = fechaActual;

            vendedorRepository.ActualizarVendedor(vendedorSelect);
            MessageBox.Show("Vendedor actualizada correctamente.",
                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (vendedorSelect == null)
            {
                MessageBox.Show("Seleccione un vendedor para eliminar.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("¿Está seguro de eliminar el vendedor seleccionado?",
                  "Confirmar eliminación",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    vendedorRepository.EliminarVendedor(vendedorSelect.COD_VEN);

                    Limpiar();

                    MessageBox.Show("Vendedor eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }
    }
}
