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
    public partial class Ubicacion_Geografica : MaterialForm
    {

        UbigeoRepository ubigeoRepository = new UbigeoRepository();
        RegionFisicaRepository regionFisicaRepository = new RegionFisicaRepository();
        bool Modificar = false;

        Ubigeo ubigeoSelect = null;

        public Ubicacion_Geografica()
        {
            InitializeComponent();
            cargarUbigeos();
            cargarComboBoxRegion();
            CargarContinentes();
            CargarPaises();
        }

        private void Ubicacion_Geografica_Load(object sender, EventArgs e)
        {
           
  
        }

        

        private void cargarUbigeos()
        {
            if (tblUbigeo.Columns.Count == 0)
            {
                tblUbigeo.Columns.Add("Código de País", 150);
                tblUbigeo.Columns.Add("País", 100);
                tblUbigeo.Columns.Add("Código de Departamento", 150);
                tblUbigeo.Columns.Add("Departamento", 100);
                tblUbigeo.Columns.Add("Código de Ciudad", 150);
                tblUbigeo.Columns.Add("Ciudad", 100);
                tblUbigeo.Columns.Add("Código de Barrio", 150);
                tblUbigeo.Columns.Add("Barrio", 100);
                tblUbigeo.Columns.Add("Idioma Oficial", 100);
                tblUbigeo.Columns.Add("Continente", 100);
                tblUbigeo.Columns.Add("Código de Región", 150); 
                tblUbigeo.Columns.Add("Latitud", 100);
                tblUbigeo.Columns.Add("Longitud", 100);
                tblUbigeo.Columns.Add("Usuario", 100);
                tblUbigeo.Columns.Add("Fecha de Creación/Modificación/Anulación", 100);
            }

            tblUbigeo.Items.Clear();

            List<Ubigeo> ubigeos = ubigeoRepository.BuscarTodasLasUbicaciones();

            foreach (Ubigeo ubicacion in ubigeos)
            {
                ListViewItem item = new ListViewItem(ubicacion.COD_PAIS);
                item.SubItems.Add(ubicacion.DES_PAIS);
                item.SubItems.Add(ubicacion.COD_DPTO.ToString());
                item.SubItems.Add(ubicacion.DES_DPTO);
                item.SubItems.Add(ubicacion.COD_CIU.ToString());
                item.SubItems.Add(ubicacion.DES_CIU);
                item.SubItems.Add(ubicacion.COD_BARR.ToString());
                item.SubItems.Add(ubicacion.DES_BARR);
                item.SubItems.Add(ubicacion.CAR_IDIOMA);
                item.SubItems.Add(ubicacion.DES_CON);
                item.SubItems.Add(ubicacion.COD_REG.ToString());
                item.SubItems.Add(ubicacion.UBI_LATITUD);
                item.SubItems.Add(ubicacion.UBI_LONGITUD);
                item.SubItems.Add(ubicacion.COD_USER);
                item.SubItems.Add(ubicacion.FEC_ABM.ToString());
                tblUbigeo.Items.Add(item);
            }
        }



        public string GenerarNuevoCodigoPais()
        {
            try
            {
                if (cbxPais.SelectedValue == null)
                    throw new Exception("Debe seleccionar un país.");

                string pais = cbxPais.SelectedValue.ToString();
                if (string.IsNullOrWhiteSpace(pais))
                    return string.Empty;

                return pais.Substring(0, Math.Min(3, pais.Length)).ToUpper();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar código de país: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }

        }

        public short GenerarNuevoCodigoDepartamento()
        {
            try
            {
                List<Ubigeo> ubicaciones = ubigeoRepository.BuscarTodasLasUbicaciones();
                short maxCodigo = ubicaciones.Any() ? ubicaciones.Max(r => r.COD_DPTO) : (short)0;
                if (maxCodigo >= short.MaxValue)
                    throw new Exception("Se ha alcanzado el límite de códigos disponibles.");
                return (short)(maxCodigo + 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar código de departamento: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public short GenerarNuevoCodigoCiudad()
        {
            try
            {
                List<Ubigeo> ubicaciones = ubigeoRepository.BuscarTodasLasUbicaciones();
                short maxCodigo = ubicaciones.Any() ? ubicaciones.Max(r => r.COD_CIU) : (short)0;
                if (maxCodigo >= short.MaxValue)
                    throw new Exception("Se ha alcanzado el límite de códigos disponibles.");
                return (short)(maxCodigo + 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar código de ciudad: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public short GenerarNuevoCodigoBarrio()
        {
            try
            {
                List<Ubigeo> ubicaciones = ubigeoRepository.BuscarTodasLasUbicaciones();
                short maxCodigo = ubicaciones.Any() ? ubicaciones.Max(r => r.COD_BARR) : (short)0;
                if (maxCodigo >= short.MaxValue)
                    throw new Exception("Se ha alcanzado el límite de códigos disponibles.");
                return (short)(maxCodigo + 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar código de barrio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DateTime fechaActual = DateTime.Now;
            
            if (Global.UsuarioSesion == null || string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                MessageBox.Show("El usuario ADMIN solo permite el registro de Usuarios.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbxPais.SelectedIndex == 0 ||
                cbxRegion.SelectedIndex == 0 ||
            string.IsNullOrWhiteSpace(txtDepartamento.Text) ||
            string.IsNullOrWhiteSpace(txtCiudad.Text) ||
            string.IsNullOrWhiteSpace(txtBarrio.Text) ||
            string.IsNullOrWhiteSpace(txtIdioma.Text) ||
            cbxContinente.SelectedIndex == 0 ||
            string.IsNullOrWhiteSpace(txtLatitud.Text) ||
            string.IsNullOrWhiteSpace(txtLogitud.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.",
                            "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Ubigeo ubigeo = new Ubigeo(
                GenerarNuevoCodigoPais(),
                cbxPais.SelectedValue.ToString(),
                GenerarNuevoCodigoDepartamento(),
                txtDepartamento.Text,
                GenerarNuevoCodigoCiudad(),
                txtCiudad.Text,
                GenerarNuevoCodigoBarrio(),
                txtBarrio.Text,
                txtIdioma.Text,
                cbxContinente.SelectedValue.ToString(),
                short.Parse(cbxRegion.SelectedValue.ToString()),
                txtLatitud.Text,
                txtLogitud.Text,
                Global.UsuarioSesion.COD_USER,
                fechaActual
            );

            ubigeoRepository.InsertarUbicacion(ubigeo);
            limpiar();
            MessageBox.Show("Ubicacion insertada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void cargarComboBoxRegion()
        {
            List<RegionFisica> regiones = regionFisicaRepository.BuscarTodosLosRegistrosFiscales();
            if (regiones == null || !regiones.Any())
            {
                MessageBox.Show("No hay regiones disponibles.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            regiones.Insert(0, new RegionFisica { COD_REG = 0, DES_REG = "-- Seleccionar --" });
            cbxRegion.DisplayMember = "DES_REG"; 
            cbxRegion.ValueMember = "COD_REG";   
            cbxRegion.DataSource = regiones;    
        }

        private void CargarContinentes()
        {
        
            List<string> continentes = new List<string>
            {
                "-- Seleccionar --",
                "África",
                "América",
                "Antártida",
                "Asia",
                "Europa",
                "Oceanía"
            };
            cbxContinente.DataSource = continentes;
        }


        private void CargarPaises()
        {
            List<string> paises = new List<string>
            {
                "-- Seleccionar --",
                "Afganistán", "Alemania", "Argentina", "Australia", "Bangladés", "Brasil", "Canadá", "Chile", "China",
                "Colombia", "Corea del Sur", "Costa Rica", "Cuba", "Dinamarca", "Ecuador", "Egipto", "El Salvador", "España",
                "Estados Unidos", "Filipinas", "Francia", "Grecia", "Guatemala", "Honduras", "India", "Indonesia", "Irán",
                "Italia", "Japón", "México", "Nicaragua", "Noruega", "Países Bajos", "Panamá", "Paraguay", "Perú", "Polonia",
                "Portugal", "Reino Unido", "República Dominicana", "Rusia", "Sudáfrica", "Suecia", "Suiza", "Tailandia",
                "Turquía", "Ucrania", "Uruguay", "Venezuela", "Vietnam"
            };

            cbxPais.DataSource = paises;
        }

        private void limpiar()
        {
            txtBarrio.Clear();
            txtCiudad.Clear();
            txtDepartamento.Clear();
            txtIdioma.Clear();
            txtLatitud.Clear();
            txtLogitud.Clear();

            cbxContinente.SelectedIndex= 0;
            cbxPais.SelectedIndex = 0;
            cbxRegion.SelectedIndex = 0;
            Modificar = false;
            ubigeoSelect = null;

            cbxPais.Refresh();
            cbxContinente.Refresh();
            cbxRegion.Refresh();
            Application.DoEvents();
            cargarUbigeos();
        }

        private void tblUbigeo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tblUbigeo.SelectedItems.Count > 0)
            {
                ListViewItem item = tblUbigeo.SelectedItems[0];
                string codigoPais = item.SubItems[0].Text;
                string pais = item.SubItems[1].Text;
                string codigoDepto = item.SubItems[2].Text;
                string depto = item.SubItems[3].Text;
                string codigoCiudad = item.SubItems[4].Text;
                string ciudad = item.SubItems[5].Text;
                string codigoBarrio = item.SubItems[6].Text;
                string barrio = item.SubItems[7].Text;
                string idioma = item.SubItems[8].Text;
                string continente = item.SubItems[9].Text;
                string codigoRegion = item.SubItems[10].Text;
                string latitud = item.SubItems[11].Text;
                string longitud = item.SubItems[12].Text;
                // Asignamos los valores a los controles del formulario
                cbxPais.SelectedItem = pais;
                txtDepartamento.Text = depto;
                txtCiudad.Text = ciudad;
                txtBarrio.Text = barrio;
                txtIdioma.Text = idioma;
                cbxContinente.SelectedItem = continente;
                try
                {
                    cbxRegion.SelectedValue = short.Parse(codigoRegion);
                }
                catch
                {
                    MessageBox.Show("Error al asignar el código de región.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txtLatitud.Text = latitud;
                txtLogitud.Text = longitud;

                cbxPais.Refresh();
                cbxContinente.Refresh();
                cbxRegion.Refresh();
                Application.DoEvents();

                // Validación: usar la clave compuesta para encontrar la ubicación correcta
                List<Ubigeo> listaUbigeos = ubigeoRepository.BuscarTodasLasUbicaciones();
                foreach (Ubigeo ubicacion in listaUbigeos)
                {
                    if (ubicacion.COD_PAIS.Equals(codigoPais) &&
                        ubicacion.COD_DPTO.ToString().Equals(codigoDepto) &&
                        ubicacion.COD_CIU.ToString().Equals(codigoCiudad) &&
                        ubicacion.COD_BARR.ToString().Equals(codigoBarrio))
                    {
                        ubigeoSelect = ubicacion;
                        break;
                    }
                }
                Modificar = true;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioSesion == null || string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                MessageBox.Show("El usuario ADMIN solo permite el registro de Usuarios.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (Modificar && ubigeoSelect != null)
                {
                    DateTime fechaActual = DateTime.Now;
                    Ubigeo ubi = ubigeoSelect;
                    ubi.COD_REG = short.Parse(cbxRegion.SelectedValue.ToString());
                    ubi.DES_DPTO = txtDepartamento.Text;
                    ubi.DES_BARR = txtBarrio.Text;
                    ubi.DES_CIU = txtCiudad.Text;
                    ubi.DES_CON = cbxContinente.SelectedItem.ToString();
                    ubi.UBI_LATITUD = txtLatitud.Text;
                    ubi.UBI_LONGITUD = txtLogitud.Text;
                    ubi.CAR_IDIOMA = txtIdioma.Text;
                    ubi.COD_USER = Global.UsuarioSesion.COD_USER;
                    ubi.FEC_ABM = fechaActual;
                    ubigeoRepository.ActualizarUbicacion(ubi);
                    limpiar();
                    MessageBox.Show("Campos actualizados con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                  
                     MessageBox.Show("Seleccione una Ubicacion de la tabla para modificar.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   
                }
            }
          
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Global.UsuarioSesion == null || string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
                {
                    MessageBox.Show("El usuario ADMIN solo permite el registro de Usuarios.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (tblUbigeo.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Seleccione una ubicación para eliminar.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult result = MessageBox.Show("¿Está seguro de eliminar la ubicación seleccionada?",
                                                        "Confirmar eliminación",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ubigeoRepository.EliminarUbicacion(ubigeoSelect.COD_PAIS, ubigeoSelect.COD_DPTO, ubigeoSelect.COD_CIU, ubigeoSelect.COD_BARR);
                    limpiar();
                    MessageBox.Show("Ubicación eliminada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la ubicación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioSesion == null || string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                MessageBox.Show("El usuario ADMIN solo permite el registro de Usuarios.",
                                  "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CuadroDialogo input = new CuadroDialogo("Ingrese el código de país a buscar", "Buscar Ubicación");
            if (input.ShowDialog() == DialogResult.OK)
            {
                string codBuscado = input.InputText;
                if (string.IsNullOrWhiteSpace(codBuscado))
                {
                    limpiar();
                    MessageBox.Show("Debe ingresar un código de país válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Se obtienen todas las ubicaciones
                List<Ubigeo> todasUbigeos = ubigeoRepository.BuscarTodasLasUbicaciones();

                // Filtrar las ubicaciones cuyo código de país coincide (ignorando mayúsculas/minúsculas)
                List<Ubigeo> filtradas = todasUbigeos.FindAll(u => u.COD_PAIS.Equals(codBuscado, StringComparison.OrdinalIgnoreCase));

                // Limpiar y configurar las columnas del ListView
                tblUbigeo.Clear();
                tblUbigeo.Columns.Add("Código de País", 150);
                tblUbigeo.Columns.Add("País", 100);
                tblUbigeo.Columns.Add("Código de Departamento", 150);
                tblUbigeo.Columns.Add("Departamento", 100);
                tblUbigeo.Columns.Add("Código de Ciudad", 150);
                tblUbigeo.Columns.Add("Ciudad", 100);
                tblUbigeo.Columns.Add("Código de Barrio", 150);
                tblUbigeo.Columns.Add("Barrio", 100);
                tblUbigeo.Columns.Add("Idioma Oficial", 100);
                tblUbigeo.Columns.Add("Continente", 100);
                tblUbigeo.Columns.Add("Código de Región", 150);
                tblUbigeo.Columns.Add("Latitud", 100);
                tblUbigeo.Columns.Add("Longitud", 100);
                tblUbigeo.Columns.Add("Usuario", 100);
                tblUbigeo.Columns.Add("Fecha de Creación/Modificación/Anulación", 100);

                if (filtradas.Count > 0)
                {
                    foreach (Ubigeo ubi in filtradas)
                    {
                        ListViewItem item = new ListViewItem(ubi.COD_PAIS);
                        item.SubItems.Add(ubi.DES_PAIS);
                        item.SubItems.Add(ubi.COD_DPTO.ToString());
                        item.SubItems.Add(ubi.DES_DPTO);
                        item.SubItems.Add(ubi.COD_CIU.ToString());
                        item.SubItems.Add(ubi.DES_CIU);
                        item.SubItems.Add(ubi.COD_BARR.ToString());
                        item.SubItems.Add(ubi.DES_BARR);
                        item.SubItems.Add(ubi.CAR_IDIOMA);
                        item.SubItems.Add(ubi.DES_CON);
                        item.SubItems.Add(ubi.COD_REG.ToString());
                        item.SubItems.Add(ubi.UBI_LATITUD);
                        item.SubItems.Add(ubi.UBI_LONGITUD);
                        item.SubItems.Add(ubi.COD_USER);
                        item.SubItems.Add(ubi.FEC_ABM.ToString());
                        tblUbigeo.Items.Add(item);
                    }
                }
                else
                {
                    limpiar();
                    MessageBox.Show("No se encontraron ubicaciones para el código de país ingresado.",
                                    "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
