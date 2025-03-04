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
    public partial class Clientes : MaterialForm
    {
        private ClienteRepository clienteRepository = new ClienteRepository();
        private PersonaRepository personaRepository = new PersonaRepository();
        private VendedorRepository vendedorRepository = new VendedorRepository();
        private SegmentosComercialesRepository segmentosComercialesRepository = new SegmentosComercialesRepository();
        private bool Modificar = false;
        private Cliente clienteSelect = null;
        public Clientes()
        {
            InitializeComponent();
            CargarPersonas();
            CargarVendedores();
            CargarSegmentos();
            cboSubSegmento.DataSource = null;

            CargarClientes();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            if (Global.UsuarioSesion != null && !string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                txtCodUsuario.Text = Global.UsuarioSesion.COD_USER;
            }
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
            var vendedores = vendedorRepository.BuscarTodosLosVendedores();
            var personas = personaRepository.BuscarTodasLasPersonas();

            var listaVendedores = vendedores
                .Select(v => new
                {
                    v.COD_VEN,
                    Nombre = personas.FirstOrDefault(p => p.COD_PER == v.COD_PER)?.DES_PER ?? "Sin Nombre"
                })
                .ToList();

            listaVendedores.Insert(0, new { COD_VEN = "", Nombre = "-- Seleccionar --" });

            cboVendedor.DataSource = listaVendedores;
            cboVendedor.DisplayMember = "Nombre";
            cboVendedor.ValueMember = "COD_VEN";
        }

        //private void CargarVendedores()
        //{
        //    var vendedores = vendedorRepository.BuscarTodosLosVendedores();
        //    var personas = personaRepository.BuscarTodasLasPersonas();


        //    vendedores.Insert(0, new Vendedor { COD_VEN = "", No = "-- Seleccionar --" });

        //    cboVendedor.DataSource = vendedores;
        //    cboVendedor.DisplayMember = "DES_VEN";
        //    cboVendedor.ValueMember = "COD_VEN";
        //}

        private void CargarSegmentos()
        {
            var segmentos = segmentosComercialesRepository.BuscarTodosLosSegmentosComerciales();
            segmentos.Insert(0, new SegmentoComerciales { COD_SEG = "", DES_SEG = "-- Seleccionar --" });

            cboSegmento.DataSource = segmentos;
            cboSegmento.DisplayMember = "DES_SEG";
            cboSegmento.ValueMember = "COD_SEG";
        }

        private void CargarSubsegmentos(string codSeg)
        {
            var subsegmentos = segmentosComercialesRepository.BuscarSubsegmentosPorSegmento(codSeg);
            subsegmentos.Insert(0, new SegmentoComerciales { COD_SSEG = "", DES_SSEG = "-- Seleccionar --" });

            cboSubSegmento.DataSource = subsegmentos;
            cboSubSegmento.DisplayMember = "DES_SSEG";
            cboSubSegmento.ValueMember = "COD_SSEG";
        }

        private void cboSegmento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboSegmento.SelectedIndex > 0)
                {
                    string codSeg = cboSegmento.SelectedValue.ToString();
                    CargarSubsegmentos(codSeg);
                }
                else
                {
                    cboSubSegmento.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar segmento: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarClientes()
        {
            try
            {
                if (tblClientes.Columns.Count == 0)
                {
                    tblClientes.Columns.Add("Código Cliente", 150);
                    tblClientes.Columns.Add("Código Persona", 150);
                    tblClientes.Columns.Add("Grupo Emp.", 150);
                    tblClientes.Columns.Add("Vendedor", 150);
                    tblClientes.Columns.Add("Segmento", 150);
                    tblClientes.Columns.Add("Subsegmento", 150);
                    tblClientes.Columns.Add("Inhabilita Mov.", 120);
                    tblClientes.Columns.Add("Usuario", 120);
                    tblClientes.Columns.Add("Fecha ABM", 150);
                }
                tblClientes.Items.Clear();

                List<Cliente> lista = clienteRepository.BuscarTodosLosClientes();
                foreach (var cli in lista)
                {
                    ListViewItem item = new ListViewItem(cli.COD_CLI);
                    item.SubItems.Add(cli.COD_PER);
                    item.SubItems.Add(cli.COD_GRP_EMP);
                    item.SubItems.Add(cli.COD_VEN);
                    item.SubItems.Add(cli.COD_SEG);
                    item.SubItems.Add(cli.COD_SSEG);
                    item.SubItems.Add(cli.FLG_INH_MOV ? "Sí" : "No");
                    item.SubItems.Add(cli.COD_USER);
                    item.SubItems.Add(cli.FEC_ABM.ToString());
                    tblClientes.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (string.IsNullOrWhiteSpace(txtCodCliente.Text) ||
                    string.IsNullOrWhiteSpace(txtGrupo.Text) ||
                    cboPersona.SelectedIndex <= 0 ||
                    cboSegmento.SelectedIndex <= 0 ||
                    cboSubSegmento.SelectedIndex <= 0)
            {
                MessageBox.Show("Complete todos los campos obligatorios.",
                                "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string codCli = txtCodCliente.Text;
            string codPer = cboPersona.SelectedValue.ToString();
            string codGrpEmp = txtGrupo.Text;
            string codVen = cboVendedor.SelectedValue.ToString();
            string codSeg = cboSegmento.SelectedValue.ToString();
            string codSseg = cboSubSegmento.SelectedValue.ToString();
            bool flgInhMov = rboInhabilitadoYes.Checked;
            string codUser = txtCodUsuario.Text;
            DateTime fecAbm = dtpFecAbm.Value;


            var vendedor = vendedorRepository.BuscarVendedorPorCodigo(codVen);
            if (vendedor != null && vendedor.COD_PER == codPer)
            {
                MessageBox.Show("El cliente no puede ser su propio vendedor.",
                                "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Cliente cli = new Cliente(
                codCli, codPer, codGrpEmp, codVen, codSeg, codSseg,
                flgInhMov, codUser, fecAbm
            );

            clienteRepository.InsertarCliente(cli);
            MessageBox.Show("Cliente insertado correctamente.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Limpiar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioSesion == null || string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                MessageBox.Show("El usuario ADMIN solo permite el registro de Usuarios.",
                                "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Modificar || clienteSelect == null)
            {
                MessageBox.Show("Seleccione un cliente de la lista para modificar.",
                                "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string codPer = cboPersona.SelectedValue.ToString();
            string codVen = cboVendedor.SelectedValue.ToString();
            var vendedor = vendedorRepository.BuscarVendedorPorCodigo(codVen);
            if (vendedor != null && vendedor.COD_PER == codPer)
            {
                MessageBox.Show("El cliente no puede ser su propio vendedor.",
                                "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clienteSelect.COD_PER = codPer;
            clienteSelect.COD_GRP_EMP = txtGrupo.Text;
            clienteSelect.COD_VEN = codVen;
            clienteSelect.COD_SEG = cboSegmento.SelectedValue.ToString();
            clienteSelect.COD_SSEG = cboSubSegmento.SelectedValue.ToString();
            clienteSelect.FLG_INH_MOV = rboInhabilitadoYes.Checked;
            clienteSelect.COD_USER = txtCodUsuario.Text;
            clienteSelect.FEC_ABM = dtpFecAbm.Value;

            // Actualizar en BD
            clienteRepository.ActualizarCliente(clienteSelect);
            MessageBox.Show("Cliente actualizado correctamente.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Limpiar();
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioSesion == null || string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                MessageBox.Show("El usuario ADMIN solo permite el registro de Usuarios.",
                                "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Modificar || clienteSelect == null)
            {
                MessageBox.Show("Seleccione un cliente para eliminar.",
                                "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("¿Está seguro de eliminar el cliente seleccionado?",
                                                  "Confirmar eliminación",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                clienteRepository.EliminarCliente(clienteSelect.COD_CLI);
                MessageBox.Show("Cliente eliminado correctamente.",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioSesion == null || string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                MessageBox.Show("El usuario ADMIN solo permite el registro de Usuarios.",
                                "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CuadroDialogo input = new CuadroDialogo("Ingrese el código del cliente a buscar", "Buscar Cliente");
            if (input.ShowDialog() == DialogResult.OK)
            {
                string codBuscado = input.InputText;
                if (string.IsNullOrWhiteSpace(codBuscado))
                {
                    MessageBox.Show("Debe ingresar un código de cliente válido.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

              
                Cliente cli = clienteRepository.BuscarClientePorCodigo(codBuscado);

     
                tblClientes.Clear();
                tblClientes.Columns.Add("Código Cliente", 150);
                tblClientes.Columns.Add("Código Persona", 150);
                tblClientes.Columns.Add("Grupo Emp.", 150);
                tblClientes.Columns.Add("Vendedor", 150);
                tblClientes.Columns.Add("Segmento", 150);
                tblClientes.Columns.Add("Subsegmento", 150);
                tblClientes.Columns.Add("Inhabilita Mov.", 120);
                tblClientes.Columns.Add("Usuario", 120);
                tblClientes.Columns.Add("Fecha ABM", 150);

                if (cli != null)
                {
                    ListViewItem item = new ListViewItem(cli.COD_CLI);
                    item.SubItems.Add(cli.COD_PER);
                    item.SubItems.Add(cli.COD_GRP_EMP);
                    item.SubItems.Add(cli.COD_VEN);
                    item.SubItems.Add(cli.COD_SEG);
                    item.SubItems.Add(cli.COD_SSEG);
                    item.SubItems.Add(cli.FLG_INH_MOV ? "Sí" : "No");
                    item.SubItems.Add(cli.COD_USER);
                    item.SubItems.Add(cli.FEC_ABM.ToString());
                    tblClientes.Items.Add(item);
                }
                else
                {
                    MessageBox.Show("No se encontró un cliente con ese código.",
                                    "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void tblClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tblClientes.SelectedItems.Count > 0)
            {
                try
                {
                    ListViewItem item = tblClientes.SelectedItems[0];
                    string codCli = item.SubItems[0].Text;

                    clienteSelect = clienteRepository.BuscarClientePorCodigo(codCli);
                    if (clienteSelect != null)
                    {
                        txtCodCliente.Text = clienteSelect.COD_CLI;
                        txtGrupo.Text = clienteSelect.COD_GRP_EMP;
                        cboPersona.SelectedValue = clienteSelect.COD_PER;
                        cboVendedor.SelectedValue = clienteSelect.COD_VEN;
                        cboSegmento.SelectedValue = clienteSelect.COD_SEG;
                        CargarSubsegmentos(clienteSelect.COD_SEG);
                        cboSubSegmento.SelectedValue = clienteSelect.COD_SSEG;
                        if (clienteSelect.FLG_INH_MOV)
                        {
                            rboInhabilitadoYes.Checked = true;
                            rboInhabilitadoNo.Checked = false;
                        }
                        else
                        {
                            rboInhabilitadoYes.Checked = false;
                            rboInhabilitadoNo.Checked = true;
                        }
                        txtCodUsuario.Text = clienteSelect.COD_USER;
                        dtpFecAbm.Value = clienteSelect.FEC_ABM;
                        cboPersona.Refresh();
                        cboVendedor.Refresh();
                        cboSegmento.Refresh();
                        cboSubSegmento.Refresh();
                        Application.DoEvents();

                        txtCodCliente.Enabled = false;
                        Modificar = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al seleccionar el cliente: " + ex.Message,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            txtCodCliente.Clear();
            txtGrupo.Clear();

            cboPersona.SelectedIndex = 0;
            cboVendedor.SelectedIndex = 0;
            cboSegmento.SelectedIndex = 0;
            cboSubSegmento.DataSource = null;

            rboInhabilitadoYes.Checked = false;
            rboInhabilitadoNo.Checked = false;

            dtpFecAbm.Value = DateTime.Now;

            txtCodCliente.Enabled = true;

            if (Global.UsuarioSesion != null && !string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
                txtCodUsuario.Text = Global.UsuarioSesion.COD_USER;
            else
                txtCodUsuario.Text = "";

            cboPersona.Refresh();
            cboVendedor.Refresh();
            cboSegmento.Refresh();
            cboSubSegmento.Refresh();
            Application.DoEvents();

            Modificar = false;
            clienteSelect = null;

            CargarClientes();
        }
    }
}
