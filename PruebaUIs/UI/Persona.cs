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
using System.Text.RegularExpressions;

namespace PruebaUIs
{
    public partial class Persona : MaterialForm
    {
        private PersonaRepository personaRepository = new PersonaRepository();
        private UbigeoRepository ubigeoRepository = new UbigeoRepository();
        private bool Modificar = false;
        private Personas personaSelect = null;

        public Persona()
        {
            InitializeComponent();

            CargarPaises();
            cboDepartamento.DataSource = null;
            cboCiudad.DataSource = null;
            cboBarrio.DataSource = null;
            CargarPersonas();

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

        private void Persona_Load(object sender, EventArgs e)
        {
            if (Global.UsuarioSesion != null && !string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                txtCodUsuario.Text = Global.UsuarioSesion.COD_USER;
                
            }
           
        }

        private void CargarPaises()
        {
            List<Ubigeo> paises = ubigeoRepository.BuscarTodosLosPaises();
            
            paises.Insert(0, new Ubigeo { COD_PAIS = "", DES_PAIS = "-- Seleccionar --" });
            cboPais.DataSource = paises;
            cboPais.DisplayMember = "DES_PAIS";
            cboPais.ValueMember = "COD_PAIS";
        }

        private void CargarDepartamentos(string codPais)
        {
            try
            {
                List<Ubigeo> departamentos = ubigeoRepository.BuscarDepartamentosPorPais(codPais);
                departamentos.Insert(0, new Ubigeo { COD_DPTO = 0, DES_DPTO = "-- Seleccionar --" });
                cboDepartamento.DataSource = departamentos;
                cboDepartamento.DisplayMember = "DES_DPTO";
                cboDepartamento.ValueMember = "COD_DPTO";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar departamentos: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCiudades(string codPais, short codDpto)
        {
            try
            {
                List<Ubigeo> ciudades = ubigeoRepository.BuscarCiudadesPorPaisDpto(codPais, codDpto);
                ciudades.Insert(0, new Ubigeo { COD_CIU = 0, DES_CIU = "-- Seleccionar --" });
                cboCiudad.DataSource = ciudades;
                cboCiudad.DisplayMember = "DES_CIU";
                cboCiudad.ValueMember = "COD_CIU";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ciudades: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarBarrios(string codPais, short codDpto, short codCiu)
        {
            try
            {
                List<Ubigeo> barrios = ubigeoRepository.BuscarBarriosPorUbicacion(codPais, codDpto, codCiu);
                barrios.Insert(0, new Ubigeo { COD_BARR = 0, DES_BARR = "-- Seleccionar --" });
                cboBarrio.DataSource = barrios;
                cboBarrio.DisplayMember = "DES_BARR";
                cboBarrio.ValueMember = "COD_BARR";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar barrios: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboPais.SelectedIndex > 0)
                {
                    string codPais = cboPais.SelectedValue.ToString();
                    CargarDepartamentos(codPais);
                }
                else
                {
                    cboDepartamento.DataSource = null;
                    cboCiudad.DataSource = null;
                    cboBarrio.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar país: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboDepartamento.SelectedIndex > 0 && cboPais.SelectedIndex > 0)
                {
                    string codPais = cboPais.SelectedValue.ToString();
                    short codDpto = (short)cboDepartamento.SelectedValue;
                    CargarCiudades(codPais, codDpto);
                }
                else
                {
                    cboCiudad.DataSource = null;
                    cboBarrio.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar departamento: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboCiudad.SelectedIndex > 0 && cboDepartamento.SelectedIndex > 0 && cboPais.SelectedIndex > 0)
                {
                    string codPais = cboPais.SelectedValue.ToString();
                    short codDpto = (short)cboDepartamento.SelectedValue;
                    short codCiu = (short)cboCiudad.SelectedValue;
                    CargarBarrios(codPais, codDpto, codCiu);
                }
                else
                {
                    cboBarrio.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar ciudad: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioSesion == null || string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                MessageBox.Show("El usuario ADMIN solo permite el registro de Usuarios.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCodPersona.Text) ||
                    string.IsNullOrWhiteSpace(txtDesPersona.Text) ||
                    cboPais.SelectedIndex <= 0 ||
                    cboDepartamento.SelectedIndex <= 0 ||
                    cboCiudad.SelectedIndex <= 0 ||
                    cboBarrio.SelectedIndex <= 0 ||
                    string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                    string.IsNullOrWhiteSpace(txtRuc.Text) ||
                    string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefono1.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefono2.Text) ||
                    string.IsNullOrWhiteSpace(txtPaginaWeb.Text) ||
                    (!rbJuridico1.Checked && !rbJuridico2.Checked) ||
                    (!rbSexo1.Checked && !rbSexo2.Checked))
            {
                MessageBox.Show("Complete todos los campos obligatorios.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!EsCorreoValido(txtCorreo.Text))
            {
                MessageBox.Show("Formato de correo inválido. Ejemplo: example@gmail.com",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime fechaActual = DateTime.Now;
            // Recopilar datos de ubicación
            bool flgPerJur = rbJuridico1.Checked;   // true si es persona jurídica
            bool flgSexPer = rbJuridico2.Checked;        // true si el sexo es femenino

            // Capturar datos de ubicación desde los ComboBox
            string codPais = cboPais.SelectedValue.ToString();
            short codDpto = (short)cboDepartamento.SelectedValue;
            short codCiu = (short)cboCiudad.SelectedValue;
            short codBarr = (short)cboBarrio.SelectedValue;

            Personas per = new Personas(
                txtCodPersona.Text,
                txtDesPersona.Text,
                flgPerJur,
                flgSexPer,
                codPais,
                codDpto,
                codCiu,
                codBarr,
                txtDireccion.Text,
                txtRuc.Text,
                txtCorreo.Text,
                txtTelefono1.Text,
                txtTelefono2.Text,
                txtPaginaWeb.Text,
                Global.UsuarioSesion.COD_USER,
                fechaActual
            );

            personaRepository.InsertarPersona(per);
            Limpiar();
            MessageBox.Show("Persona insertada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioSesion == null || string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                MessageBox.Show("El usuario ADMIN solo permite el registro de Usuarios.",
                                "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Modificar && personaSelect != null)
            {
                DateTime fechaActual = DateTime.Now;
                personaSelect.DES_PER = txtDesPersona.Text;
                personaSelect.FLG_PER_JUR = rbJuridico1.Checked;
                personaSelect.FLG_SEX_PER = rbSexo1.Checked;
                personaSelect.COD_PAIS = cboPais.SelectedValue.ToString();
                personaSelect.COD_DPTO = (short)cboDepartamento.SelectedValue;
                personaSelect.COD_CIU = (short)cboCiudad.SelectedValue;
                personaSelect.COD_BARR = (short)cboBarrio.SelectedValue;
                personaSelect.DES_DIR = txtDireccion.Text;
                personaSelect.NRO_RUC = txtRuc.Text;
                personaSelect.EMAIL_EMP = txtCorreo.Text;
                personaSelect.EMP_TELF1 = txtTelefono1.Text;
                personaSelect.EMP_TELF2 = txtTelefono2.Text;
                personaSelect.WWW_URL = txtPaginaWeb.Text;
                personaSelect.COD_USER = Global.UsuarioSesion.COD_USER;
                personaSelect.FEC_ABM = fechaActual;
             
                personaRepository.ActualizarPersona(personaSelect);
                Limpiar();
                MessageBox.Show("Persona actualizada correctamente.",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                MessageBox.Show("Seleccione una persona de la lista para modificar.",
                                "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tblPersona_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tblPersona.SelectedItems.Count > 0)
            {
                try
                {
                    
                    ListViewItem item = tblPersona.SelectedItems[0];
                    string codPer = item.SubItems[0].Text;

                    
                    personaSelect = personaRepository.BuscarPersonaPorCodigo(codPer);
                    if (personaSelect != null)
                    {
                        
                        txtCodPersona.Text = personaSelect.COD_PER;
                        txtDesPersona.Text = personaSelect.DES_PER;

                        if (personaSelect.FLG_PER_JUR == true)
                        {
                            rbJuridico1.Checked = true;
                            rbJuridico2.Checked = false;
                        }
                        else
                        {
                            rbJuridico1.Checked = false;
                            rbJuridico2.Checked = true;
                        }

                        if (personaSelect.FLG_SEX_PER == true)
                        {
                            rbSexo1.Checked = true;
                            rbSexo2.Checked = false;
                        }
                        else
                        {
                            rbSexo1.Checked = false;
                            rbSexo2.Checked = true;
                        }

                        cboPais.SelectedValue = personaSelect.COD_PAIS;
                        CargarDepartamentos(personaSelect.COD_PAIS);
                        cboDepartamento.SelectedValue = personaSelect.COD_DPTO;
                        CargarCiudades(personaSelect.COD_PAIS, personaSelect.COD_DPTO ?? 0);
                        cboCiudad.SelectedValue = personaSelect.COD_CIU;
                        CargarBarrios(personaSelect.COD_PAIS, personaSelect.COD_DPTO ?? 0, personaSelect.COD_CIU ?? 0);
                        cboBarrio.SelectedValue = personaSelect.COD_BARR;

                        txtDireccion.Text = personaSelect.DES_DIR;
                        txtRuc.Text = personaSelect.NRO_RUC;
                        txtCorreo.Text = personaSelect.EMAIL_EMP;
                        txtTelefono1.Text = personaSelect.EMP_TELF1;
                        txtTelefono2.Text = personaSelect.EMP_TELF2;
                        txtPaginaWeb.Text = personaSelect.WWW_URL;
                        txtCodUsuario.Text = personaSelect.COD_USER;

                        cboPais.Refresh();
                        cboDepartamento.Refresh();
                        cboCiudad.Refresh();
                        cboBarrio.Refresh();
                        Application.DoEvents();

                        txtCodPersona.Enabled = false;
                        Modificar = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la persona: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void CargarPersonas()
        {
            try
            {
                if (tblPersona.Columns.Count == 0)
                {
                    tblPersona.Columns.Add("Código", 100);
                    tblPersona.Columns.Add("Descripción", 150);
                    tblPersona.Columns.Add("Persona Jurídica", 100);
                    tblPersona.Columns.Add("Sexo Femenino", 100);
                    tblPersona.Columns.Add("País", 100);
                    tblPersona.Columns.Add("Depto", 80);
                    tblPersona.Columns.Add("Ciudad", 80);
                    tblPersona.Columns.Add("Barrio", 80);
                    tblPersona.Columns.Add("Dirección", 150);
                    tblPersona.Columns.Add("RUC", 100);
                    tblPersona.Columns.Add("Email", 150);
                    tblPersona.Columns.Add("Teléfono 1", 100);
                    tblPersona.Columns.Add("Teléfono 2", 100);
                    tblPersona.Columns.Add("Sitio Web", 150);
                    tblPersona.Columns.Add("Usuario", 100);
                    tblPersona.Columns.Add("Fec. ABM", 150);
                }
                tblPersona.Items.Clear();

                List<Personas> lista = personaRepository.BuscarTodasLasPersonas();
                foreach (Personas per in lista)
                {
                    ListViewItem item = new ListViewItem(per.COD_PER);
                    item.SubItems.Add(per.DES_PER);
                    item.SubItems.Add((per.FLG_PER_JUR == true) ? "Sí" : "No");
                    item.SubItems.Add((per.FLG_SEX_PER == true) ? "Femenino" : "Masculino");
                    item.SubItems.Add(per.COD_PAIS);
                    item.SubItems.Add(per.COD_DPTO.ToString());
                    item.SubItems.Add(per.COD_CIU.ToString());
                    item.SubItems.Add(per.COD_BARR.ToString());
                    item.SubItems.Add(per.DES_DIR);
                    item.SubItems.Add(per.NRO_RUC);
                    item.SubItems.Add(per.EMAIL_EMP);
                    item.SubItems.Add(per.EMP_TELF1);
                    item.SubItems.Add(per.EMP_TELF2);
                    item.SubItems.Add(per.WWW_URL);
                    item.SubItems.Add(per.COD_USER);
                    item.SubItems.Add(per.FEC_ABM.ToString());
                    tblPersona.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar personas: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            txtCodPersona.Clear();
            txtDesPersona.Clear();
            txtDireccion.Clear();
            txtRuc.Clear();
            txtCorreo.Clear();
            txtTelefono1.Clear();
            txtTelefono2.Clear();
            txtPaginaWeb.Clear();

            rbJuridico1.Checked = false; 
            rbJuridico2.Checked = false;
            rbSexo1.Checked = false;
            rbSexo2.Checked = false;

            if (cboPais.Items.Count > 0) cboPais.SelectedIndex = 0;
            cboDepartamento.DataSource = null;
            cboCiudad.DataSource = null;
            cboBarrio.DataSource = null;

            txtCodPersona.Enabled = true;

            if (Global.UsuarioSesion != null && !string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
                txtCodUsuario.Text = Global.UsuarioSesion.COD_USER;
            else
                txtCodUsuario.Text = "";

            cboPais.Refresh();
            cboDepartamento.Refresh();
            cboCiudad.Refresh();
            cboBarrio.Refresh();
            Application.DoEvents();

            Modificar = false;
            personaSelect = null;

            CargarPersonas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioSesion == null || string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                MessageBox.Show("El usuario ADMIN solo permite el registro de Usuarios.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Modificar || personaSelect == null)
            {
                MessageBox.Show("Seleccione una persona para eliminar.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("¿Está seguro de eliminar la persona seleccionada?",
                                                  "Confirmar eliminación",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                personaRepository.EliminarPersona(personaSelect.COD_PER);

                Limpiar();

                MessageBox.Show("Persona eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            CuadroDialogo input = new CuadroDialogo("Ingrese el código de la persona a buscar", "Buscar Persona");
            if (input.ShowDialog() == DialogResult.OK)
            {
                string codBuscado = input.InputText;
                if (string.IsNullOrWhiteSpace(codBuscado))
                {
                    MessageBox.Show("Debe ingresar un código de persona válido.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Personas per = personaRepository.BuscarPersonaPorCodigo(codBuscado);

                tblPersona.Clear();
                tblPersona.Columns.Add("Código", 100);
                tblPersona.Columns.Add("Descripción", 150);
                tblPersona.Columns.Add("Persona Jurídica", 100);
                tblPersona.Columns.Add("Sexo Femenino", 100);
                tblPersona.Columns.Add("País", 100);
                tblPersona.Columns.Add("Depto", 80);
                tblPersona.Columns.Add("Ciudad", 80);
                tblPersona.Columns.Add("Barrio", 80);
                tblPersona.Columns.Add("Dirección", 150);
                tblPersona.Columns.Add("RUC", 100);
                tblPersona.Columns.Add("Email", 150);
                tblPersona.Columns.Add("Teléfono 1", 100);
                tblPersona.Columns.Add("Teléfono 2", 100);
                tblPersona.Columns.Add("Sitio Web", 150);
                tblPersona.Columns.Add("Usuario", 100);
                tblPersona.Columns.Add("Fec. ABM", 150);

                if (per != null)
                {
                    ListViewItem item = new ListViewItem(per.COD_PER);
                    item.SubItems.Add(per.DES_PER);
                    item.SubItems.Add((per.FLG_PER_JUR == true) ? "Sí" : "No");
                    item.SubItems.Add((per.FLG_SEX_PER == true) ? "Femenino" : "Masculino");
                    item.SubItems.Add(per.COD_PAIS);
                    item.SubItems.Add(per.COD_DPTO.ToString());
                    item.SubItems.Add(per.COD_CIU.ToString());
                    item.SubItems.Add(per.COD_BARR.ToString());
                    item.SubItems.Add(per.DES_DIR);
                    item.SubItems.Add(per.NRO_RUC);
                    item.SubItems.Add(per.EMAIL_EMP);
                    item.SubItems.Add(per.EMP_TELF1);
                    item.SubItems.Add(per.EMP_TELF2);
                    item.SubItems.Add(per.WWW_URL);
                    item.SubItems.Add(per.COD_USER);
                    item.SubItems.Add(per.FEC_ABM.ToString());
                    tblPersona.Items.Add(item);
                }
                else
                {
                    MessageBox.Show("No se encontró una persona con ese código.",
                                    "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private bool EsCorreoValido(string correo)
        {
            
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(correo, pattern);
        }
    }
}
