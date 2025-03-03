using MaterialSkin.Controls;
using PruebaUIs.Model;
using PruebaUIs.Model.Parametros;
using PruebaUIs.Repository;
using PruebaUIs.Repository.Parametros;
using PruebaUIs.UI;
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

namespace PruebaUIs
{
    public partial class Local : MaterialForm
    {

        LocacionRepository locacionRepository = new LocacionRepository();
        UbigeoRepository ubigeoRepository = new UbigeoRepository();
        Ubigeo ubigeoSelected = null;
        bool Deposito = true;
        bool Virtual = true;

        bool Modificar = false;
        Locacion locacionSelected = null;
        public Local()
        {
            InitializeComponent();
            cargarLocacion();
            cargarPaises();
            cargarUbigeo();
            checkSI.Checked = true;
            checkSIVirtual.Checked = true;
        }

        private void Local_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioSesion == null || string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                MessageBox.Show("El usuario ADMIN solo permite el registro de Usuarios.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Modificar)
            {
                MessageBox.Show("No se puede insertar una locación mientras se está en modo modificación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCodLocacion.Text))
            {
                MessageBox.Show("El código de locación es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("La descripción es obligatoria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEncargado.Text))
            {
                MessageBox.Show("El nombre del encargado es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ubigeoSelected == null)
            {
                MessageBox.Show("Debe seleccionar una ubicación válida (País, Departamento, Ciudad, Barrio).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(ubigeoSelected.COD_PAIS))
            {
                MessageBox.Show("El código de país es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ubigeoSelected.COD_DPTO <= 0)
            {
                MessageBox.Show("El código de departamento debe ser válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ubigeoSelected.COD_CIU <= 0)
            {
                MessageBox.Show("El código de ciudad debe ser válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ubigeoSelected.COD_BARR <= 0)
            {
                MessageBox.Show("El código de barrio debe ser válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("La dirección es obligatoria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal altura;
            if (!decimal.TryParse(txtAltura.Text, out altura) || altura < 0)
            {
                MessageBox.Show("La altura debe ser un número decimal positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal superficie;
            if (!decimal.TryParse(txtSuperficie.Text, out superficie) || superficie < 0)
            {
                MessageBox.Show("La superficie debe ser un número decimal positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            short cobertura;
            if (!short.TryParse(txtCobertura.Text, out cobertura) || cobertura < 0)
            {
                MessageBox.Show("La cobertura debe ser un número entero positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime fechaActual = DateTime.Now;

            Locacion locacion = new Locacion(
                Deposito,
                txtCodLocacion.Text,
                txtDescripcion.Text,
                FechaLocal.Value,
                txtEncargado.Text,
                Virtual,
                ubigeoSelected.COD_PAIS,
                ubigeoSelected.COD_DPTO,
                ubigeoSelected.COD_CIU,
                ubigeoSelected.COD_BARR,
                txtDireccion.Text,
                altura,
                superficie,
                cobertura,
                Global.UsuarioSesion.COD_USER,
                fechaActual
            );

            locacionRepository.InsertarLocacion(locacion);
            limpiar();
            MessageBox.Show("Locación insertada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void cargarLocacion()
        {
            if (tblLocacion.Columns.Count == 0)
            {
                tblLocacion.Columns.Add("Locación para Depósito Central (S/N)", 225);
                tblLocacion.Columns.Add("Código de Locación", 225);
                tblLocacion.Columns.Add("Descripción del Local", 225);
                tblLocacion.Columns.Add("Fecha de Creación de la Locación", 225);
                tblLocacion.Columns.Add("Nombre del Encargado", 225);
                tblLocacion.Columns.Add("Local Virtual (S/N)", 225);
                tblLocacion.Columns.Add("Código de País", 225);
                tblLocacion.Columns.Add("Código de Departamento", 225);
                tblLocacion.Columns.Add("Código de Ciudad", 225);
                tblLocacion.Columns.Add("Código de Barrio", 225);
                tblLocacion.Columns.Add("Dirección de la Locación", 225);
                tblLocacion.Columns.Add("Altura del Local", 225);
                tblLocacion.Columns.Add("Superficie del Local", 225);
                tblLocacion.Columns.Add("Cobertura de Stock Disponible (días)", 225);
                tblLocacion.Columns.Add("Código de Usuario", 225);
                tblLocacion.Columns.Add("Fecha de Creación/Modificación/Anulación", 225);
            }

            tblLocacion.Items.Clear();

            List<Locacion> Regionlocacioneses = locacionRepository.BuscarTodasLasLocaciones();

            foreach (Locacion locacion in Regionlocacioneses)
            {
                ListViewItem item = new ListViewItem(locacion.FLG_DEP_CEN.ToString());
                item.SubItems.Add(locacion.COD_LOC);
                item.SubItems.Add(locacion.DES_LOC);
                item.SubItems.Add(locacion.FEC_CREA.ToString());
                item.SubItems.Add(locacion.DES_NOM_ENC);
                item.SubItems.Add(locacion.FLG_LOC_VIR.ToString());
                item.SubItems.Add(locacion.COD_PAIS);
                item.SubItems.Add(locacion.COD_DPTO.ToString());
                item.SubItems.Add(locacion.COD_CIU.ToString());
                item.SubItems.Add(locacion.COD_BARR.ToString());
                item.SubItems.Add(locacion.DES_DIR_LOC);
                item.SubItems.Add(locacion.VAL_ZLOC_ALT.ToString());
                item.SubItems.Add(locacion.VAL_ZLOC_SUP.ToString());
                item.SubItems.Add(locacion.VAL_COB_ESP.ToString());
                item.SubItems.Add(locacion.COD_USER);
                item.SubItems.Add(locacion.FEC_ABM.ToString());

                tblLocacion.Items.Add(item);
            }
        }

        private void cargarPaises()
        {
            List<Ubigeo> listaUbicaciones = ubigeoRepository.BuscarTodasLasUbicaciones();

            cbxPais.DisplayMember = "DES_PAIS";
            cbxPais.ValueMember = "COD_PAIS";
            cbxPais.DataSource = listaUbicaciones;
        }

        private void cbxPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarUbigeo();
        }

      
        private void cargarUbigeo()
        {
            if (cbxPais.SelectedItem != null)
            {
                ubigeoSelected = (Ubigeo)cbxPais.SelectedItem;
            }
        }
        private void checkNO_CheckedChanged(object sender, EventArgs e)
        {
            if (checkNO.Checked)
            {
                checkSI.Checked = false;
                Deposito = false;
            }
        }

        private void checkSI_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSI.Checked)
            {
                checkNO.Checked = false;
                Deposito = true;
            }
        }

        private void checkSIVirtual_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSIVirtual.Checked)
            {
                checkNOVirtual.Checked = false;
                Virtual = true;
            }
        }

        private void checkNOVirtual_CheckedChanged(object sender, EventArgs e)
        {
            if (checkNOVirtual.Checked)
            {
                checkSIVirtual.Checked = false;
                Virtual = false;
            }
        }


        private void limpiar()
        {
           
            txtCodLocacion.Clear();
            txtDescripcion.Clear();
            txtEncargado.Clear();
            txtDireccion.Clear();
            txtAltura.Clear();
            txtSuperficie.Clear();
            txtCobertura.Clear();
            FechaLocal.Value = DateTime.Now;
            checkSI.Checked = !checkSI.Checked;
            checkNO.Checked = !checkNO.Checked;
            checkSIVirtual.Checked = !checkSIVirtual.Checked;
            checkNOVirtual.Checked = !checkNOVirtual.Checked;
            cbxPais.SelectedIndex = -1;
            Modificar = false;
            txtCodLocacion.Enabled = true;
            locacionSelected = null;
            cargarLocacion();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioSesion == null || string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                MessageBox.Show("El usuario ADMIN solo permite el registro de Usuarios.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
               
                if (Modificar)
                {

                    DateTime fechaActual = DateTime.Now;
                    Locacion locacion = locacionSelected;
                    locacion.COD_LOC = txtCodLocacion.Text;
                    locacion.COD_PAIS = ubigeoSelected.COD_PAIS;
                    locacion.COD_DPTO = ubigeoSelected.COD_DPTO;
                    locacion.COD_CIU = ubigeoSelected.COD_CIU;
                    locacion.COD_BARR = ubigeoSelected.COD_BARR;
                    locacion.FLG_DEP_CEN = Deposito;
                    locacion.DES_LOC = txtDescripcion.Text;
                    locacion.DES_DIR_LOC = txtDireccion.Text;
                    locacion.DES_NOM_ENC = txtEncargado.Text;
                    locacion.VAL_ZLOC_ALT = decimal.Parse(txtAltura.Text);
                    locacion.VAL_ZLOC_SUP = decimal.Parse(txtSuperficie.Text);
                    locacion.VAL_COB_ESP = int.Parse(txtCobertura.Text);
                    locacion.COD_USER = Global.UsuarioSesion.COD_USER;
                    locacion.FEC_ABM = fechaActual;
                    locacion.FEC_CREA = DateTime.Parse(FechaLocal.Text);
                    locacionRepository.ActualizarLocacion(locacion);
                    limpiar();
                    MessageBox.Show("Campos actualizados con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Seleccione una locacion de la tabla.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void tblLocacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tblLocacion.SelectedItems.Count > 0)
            {

                ListViewItem item = tblLocacion.SelectedItems[0];
                string codigo = item.SubItems[1].Text;
                txtCodLocacion.Text = item.SubItems[1].Text;
                if (bool.Parse(item.SubItems[0].Text))
                {
                    checkSI.Checked = true;
                }
                else
                {
                    checkNO.Checked = true;
                }

                txtDescripcion.Text = item.SubItems[2].Text;
                FechaLocal.Value = DateTime.Parse(item.SubItems[3].Text);
                txtEncargado.Text = item.SubItems[4].Text;
                if (bool.Parse(item.SubItems[5].Text))
                {
                    checkSIVirtual.Checked = true;
                }
                else
                {
                    checkNOVirtual.Checked = true;
                }
                cbxPais.SelectedValue = item.SubItems[6].Text;
                txtDireccion.Text = item.SubItems[10].Text;
                txtAltura.Text = item.SubItems[11].Text;
                txtSuperficie.Text = item.SubItems[12].Text;
                txtCobertura.Text = item.SubItems[13].Text;

                cbxPais.Refresh();

                List<Locacion> listaLocaciones = locacionRepository.BuscarTodasLasLocaciones();
                foreach (Locacion locacion in listaLocaciones)
                {
                    if (locacion.COD_LOC.Equals(codigo))
                    {
                        locacionSelected = locacion;
                        break;
                    }
                }
                Modificar = true;
                txtCodLocacion.Enabled = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Modificar)
            {
                locacionRepository.EliminarLocacion(locacionSelected.COD_LOC);
                limpiar();
                MessageBox.Show("Locacion eliminada con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Seleccione una Locacion para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioSesion == null || string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                MessageBox.Show("El usuario ADMIN solo permite el registro de Usuarios.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                CuadroDialogo Input = new CuadroDialogo("Inserte Codigo Locacion", "Buscar Locacion");
                if (Input.ShowDialog() == DialogResult.OK)
                {
                    string mensaje = Input.InputText;

                    if (!string.IsNullOrWhiteSpace(mensaje))
                    {
                        List<Locacion> locaciones = locacionRepository.BuscarTodasLasLocaciones();
                        tblLocacion.Clear();
                        tblLocacion.Columns.Add("Locación para Depósito Central (S/N)", 225);
                        tblLocacion.Columns.Add("Código de Locación", 225);
                        tblLocacion.Columns.Add("Descripción del Local", 225);
                        tblLocacion.Columns.Add("Fecha de Creación de la Locación", 225);
                        tblLocacion.Columns.Add("Nombre del Encargado", 225);
                        tblLocacion.Columns.Add("Local Virtual (S/N)", 225);
                        tblLocacion.Columns.Add("Código de País", 225);
                        tblLocacion.Columns.Add("Código de Departamento", 225);
                        tblLocacion.Columns.Add("Código de Ciudad", 225);
                        tblLocacion.Columns.Add("Código de Barrio", 225);
                        tblLocacion.Columns.Add("Dirección de la Locación", 225);
                        tblLocacion.Columns.Add("Altura del Local", 225);
                        tblLocacion.Columns.Add("Superficie del Local", 225);
                        tblLocacion.Columns.Add("Cobertura de Stock Disponible (días)", 225);
                        tblLocacion.Columns.Add("Código de Usuario", 225);
                        tblLocacion.Columns.Add("Fecha de Creación/Modificación/Anulación", 225);
                        foreach (Locacion locacion in locaciones)
                        {
                            if (locacion.COD_LOC.ToLower().Contains(mensaje.ToLower()))
                            {
                                ListViewItem item = new ListViewItem(locacion.FLG_DEP_CEN.ToString());
                                item.SubItems.Add(locacion.COD_LOC);
                                item.SubItems.Add(locacion.DES_LOC);
                                item.SubItems.Add(locacion.FEC_CREA.ToString());
                                item.SubItems.Add(locacion.DES_NOM_ENC);
                                item.SubItems.Add(locacion.FLG_LOC_VIR.ToString());
                                item.SubItems.Add(locacion.COD_PAIS);
                                item.SubItems.Add(locacion.COD_DPTO.ToString());
                                item.SubItems.Add(locacion.COD_CIU.ToString());
                                item.SubItems.Add(locacion.COD_BARR.ToString());
                                item.SubItems.Add(locacion.DES_DIR_LOC);
                                item.SubItems.Add(locacion.VAL_ZLOC_ALT.ToString());
                                item.SubItems.Add(locacion.VAL_ZLOC_SUP.ToString());
                                item.SubItems.Add(locacion.VAL_COB_ESP.ToString());
                                item.SubItems.Add(locacion.COD_USER);
                                item.SubItems.Add(locacion.FEC_ABM.ToString());

                                tblLocacion.Items.Add(item);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar un mensaje válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }

}
