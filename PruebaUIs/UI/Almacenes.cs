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
    public partial class Almacenes : MaterialForm
    {

        AlmacenRepository almacenRepository = new AlmacenRepository();
        LocacionRepository locacionRepository = new LocacionRepository();
        Almacen almacenSelect = null;
        bool Modificar = false;
        public Almacenes()
        {
            InitializeComponent();
            cargarAlmacenes();
            cargarLocaciones();
            rbCanjeSI.Checked = true;
            rbClimaSI.Checked = true;
            
        }

        private void Alamacenes_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioSesion?.COD_USER == null)
            {
                MessageBox.Show("El usuario ADMIN solo permite el registro de Usuarios.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Modificar)
            {
                MessageBox.Show("No puede insertar en modo Modificar.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var campos = new Dictionary<Control, string>
                {
                    { txtDescripcion, "La descripción es obligatoria." },
                    { txtEncargado, "Debe ingresar el nombre del encargado." }
                };

            foreach (var campo in campos)
            {
                if (campo.Key is TextBox txt && string.IsNullOrWhiteSpace(txt.Text))
                {
                    MessageBox.Show(campo.Value, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    campo.Key.Focus();
                    return;
                }
            }

            if (cbxLocacion.SelectedValue == null || cbxLocacion.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Debe seleccionar una locación válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbxLocacion.Focus();
                return;
            }

            if (!decimal.TryParse(txtAlturaAlmacen.Text, out decimal altura) || !decimal.TryParse(txtSuperficieAlmacen.Text, out decimal superficie))
            {
                MessageBox.Show("Debe ingresar valores numéricos válidos para altura y superficie.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAlturaAlmacen.Focus();
                return;
            }

            almacenRepository.InsertarAlmacen(new Almacen(
                GenerarCodigoAlmacen(),
                txtDescripcion.Text,
                dateCreacion.Value,
                cbxLocacion.SelectedValue.ToString(),
                txtEncargado.Text,
                altura,
                superficie,
                rbClimaSI.Checked,
                rbCanjeSI.Checked,
                Global.UsuarioSesion.COD_USER,
                DateTime.Now
            ));

            limpiar();
            MessageBox.Show("Almacén insertado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        public string GenerarCodigoAlmacen()
        {
            
            List<Almacen> almacenes = almacenRepository.BuscarTodosLosAlmacenes();
            string ultimoCodigo = almacenes.OrderByDescending(A => A.COD_ALM).Select(A => A.COD_ALM).FirstOrDefault();
            int nuevoNumero = 1;

            if (!string.IsNullOrEmpty(ultimoCodigo))
            {
                string numeroStr = ultimoCodigo.Substring(1);
                if (int.TryParse(numeroStr, out int numero)) nuevoNumero = numero + 1;
            }
            int longDigito = nuevoNumero.ToString().Length + 1;
            string nuevoCodigo = $"ALM{nuevoNumero:D17}";
            while (almacenes.Any(A => A.COD_ALM == nuevoCodigo))
            {
                nuevoNumero++;
                nuevoCodigo = $"ALM{nuevoNumero:D17}";
            }
            return nuevoCodigo;
        }


        private void cargarAlmacenes()
        {
            if (tblAlmacenes.Columns.Count == 0)
            {
                var columnas = new (string Nombre, int Ancho)[]
                {
            ("Código de Almacén", 225), ("Descripción", 200), ("Fecha de Creación", 150),
            ("Código de Localización", 150), ("Nombre Encargado", 200), ("Altura Zona Almacén", 150),
            ("Superficie Zona Almacén", 150), ("Ambiente Controlado", 150), ("Almacén de Canje", 150),
            ("Usuario", 150), ("Fecha de Modificación", 150)
                };

                tblAlmacenes.Columns.AddRange(columnas.Select(c => new ColumnHeader { Text = c.Nombre, Width = c.Ancho }).ToArray());
            }

            tblAlmacenes.Items.Clear();

            var almacenes = almacenRepository.BuscarTodosLosAlmacenes();

            tblAlmacenes.Items.AddRange(almacenes.Select(a => new ListViewItem(new[]
            {
                    a.COD_ALM, a.DES_ALM, a.FEC_CREA.ToString(),
                    a.COD_LOC, a.DES_NOM_ENC, a.VAL_ZALM_ALT?.ToString(),
                    a.VAL_ZALM_SUP?.ToString(), a.FLG_AMB_CTRL ? "Sí" : "No",
                    a.FLG_ALM_CANJE ? "Sí" : "No", a.COD_USER, a.FEC_ABM.ToString()
                })).ToArray());
            }



        private void cargarLocaciones()
        {
            List<Locacion> locaciones = locacionRepository.BuscarTodasLasLocaciones();
            if (locaciones == null || !locaciones.Any())
            {
                MessageBox.Show("No hay locaciones disponibles.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            locaciones.Insert(0, new Locacion { COD_LOC = "", DES_LOC = "-- Seleccionar --" });
            cbxLocacion.DisplayMember = "DES_LOC";
            cbxLocacion.ValueMember = "COD_LOC";
            cbxLocacion.DataSource = locaciones;
        }

        private void limpiar()
        {
            Global.LimpiarControles(this);
            cargarAlmacenes();
            rbCanjeSI.Checked = true;
            rbClimaSI.Checked = true;
            cargarLocaciones();
            almacenSelect = null;
            Modificar = false;

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioSesion == null || string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                MessageBox.Show("El usuario ADMIN solo permite la modificación de Almacenes.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Modificar && almacenSelect != null)
            {
                if (cbxLocacion.SelectedValue == null || cbxLocacion.SelectedValue.ToString() == "")
                {
                    MessageBox.Show("Debe seleccionar una locación válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbxLocacion.Focus();
                    return;
                }

                if (!decimal.TryParse(txtAlturaAlmacen.Text, out decimal altura) || !decimal.TryParse(txtSuperficieAlmacen.Text, out decimal superficie))
                {
                    MessageBox.Show("Debe ingresar valores numéricos válidos para altura y superficie.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAlturaAlmacen.Focus();
                    return;
                }

                DateTime fechaActual = DateTime.Now;
                almacenSelect.DES_ALM = txtDescripcion.Text;
                almacenSelect.FEC_CREA = dateCreacion.Value;
                almacenSelect.COD_LOC = cbxLocacion.SelectedValue.ToString();
                almacenSelect.DES_NOM_ENC = txtEncargado.Text;
                almacenSelect.VAL_ZALM_ALT = altura;
                almacenSelect.VAL_ZALM_SUP = superficie;
                almacenSelect.FLG_AMB_CTRL = rbClimaSI.Checked;
                almacenSelect.FLG_ALM_CANJE = rbCanjeSI.Checked;
                almacenSelect.COD_USER = Global.UsuarioSesion.COD_USER;
                almacenSelect.FEC_ABM = fechaActual;

                almacenRepository.EditarAlmacen(almacenSelect);
                limpiar();
                MessageBox.Show("Almacén actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Seleccione un almacén de la tabla para modificar.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tblAlmacenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tblAlmacenes.SelectedItems.Count > 0)
            {
                ListViewItem item = tblAlmacenes.SelectedItems[0];

                string codigoAlmacen = item.SubItems[0].Text;
                string descripcion = item.SubItems[1].Text;
                string fechaCreacion = item.SubItems[2].Text;
                string codigoLocacion = item.SubItems[3].Text;
                string encargado = item.SubItems[4].Text;
                string altura = item.SubItems[5].Text;
                string superficie = item.SubItems[6].Text;
                bool ambienteControlado = item.SubItems[7].Text == "Sí";
                bool canje = item.SubItems[8].Text == "Sí";

                txtDescripcion.Text = descripcion;
                dateCreacion.Value = DateTime.TryParse(fechaCreacion, out DateTime fecha) ? fecha : DateTime.Now;
                cbxLocacion.SelectedValue = codigoLocacion;
                txtEncargado.Text = encargado;
                txtAlturaAlmacen.Text = altura;
                txtSuperficieAlmacen.Text = superficie;
                rbClimaSI.Checked = ambienteControlado;
                rbClimaNO.Checked = !ambienteControlado;
                rbCanjeSI.Checked = canje;
                rbCanjeNO.Checked = !canje;

                cbxLocacion.Refresh();
                Application.DoEvents();

                List<Almacen> listaAlmacenes = almacenRepository.BuscarTodosLosAlmacenes();
                foreach (Almacen almacen in listaAlmacenes)
                {
                    if (almacen.COD_ALM.Equals(codigoAlmacen))
                    {
                        almacenSelect = almacen;
                        break;
                    }
                }
                Modificar = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Global.UsuarioSesion == null || string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
                {
                    MessageBox.Show("El usuario ADMIN solo permite la eliminación de Almacenes.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (tblAlmacenes.SelectedItems.Count == 0 || almacenSelect == null)
                {
                    MessageBox.Show("Seleccione un almacén para eliminar.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show("¿Está seguro de eliminar el almacén seleccionado?",
                                                      "Confirmar eliminación",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    almacenRepository.EliminarAlmacen(almacenSelect.COD_ALM);
                    limpiar();
                    MessageBox.Show("Almacén eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el almacén: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioSesion == null || string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                MessageBox.Show("El usuario ADMIN solo permite la búsqueda de Almacenes.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CuadroDialogo Input = new CuadroDialogo("Ingrese el nombre del almacén que desea buscar", "Buscar Almacén");
            if (Input.ShowDialog() == DialogResult.OK)
            {
                string mensaje = Input.InputText.Trim();

                if (!string.IsNullOrWhiteSpace(mensaje))
                {
                    List<Almacen> almacenes = almacenRepository.BuscarTodosLosAlmacenes();
                    tblAlmacenes.Clear();

                    var columnas = new (string Nombre, int Ancho)[]
                    {
                ("Código de Almacén", 225), ("Descripción", 200), ("Fecha de Creación", 150),
                ("Código de Localización", 150), ("Nombre Encargado", 200), ("Altura Zona Almacén", 150),
                ("Superficie Zona Almacén", 150), ("Ambiente Controlado", 150), ("Almacén de Canje", 150),
                ("Usuario", 150), ("Fecha de Modificación", 150)
                    };

                    tblAlmacenes.Columns.AddRange(columnas.Select(c => new ColumnHeader { Text = c.Nombre, Width = c.Ancho }).ToArray());

                    foreach (var a in almacenes)
                    {
                        if (a.DES_ALM.ToLower().Contains(mensaje.ToLower()))
                        {
                            var item = new ListViewItem(new[]
                            {
                        a.COD_ALM,
                        a.DES_ALM,
                        a.FEC_CREA.ToString(""),
                        a.COD_LOC,
                        a.DES_NOM_ENC,
                        a.VAL_ZALM_ALT?.ToString(),
                        a.VAL_ZALM_SUP?.ToString(),
                        a.FLG_AMB_CTRL ? "Sí" : "No",
                        a.FLG_ALM_CANJE ? "Sí" : "No",
                        a.COD_USER,
                        a.FEC_ABM.ToString("")
                    });

                            tblAlmacenes.Items.Add(item);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debe ingresar un nombre de almacén válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
