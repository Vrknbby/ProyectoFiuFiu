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
            string pais = cbxPais.SelectedValue.ToString();
            if (string.IsNullOrWhiteSpace(pais))
                return string.Empty;

            return pais.Substring(0, Math.Min(3, pais.Length)).ToUpper();

        }

        public short GenerarNuevoCodigoDepartamento()
        {

            List<Ubigeo> ubicaciones = ubigeoRepository.BuscarTodasLasUbicaciones();
            short maxCodigo = ubicaciones.Any() ? ubicaciones.Max(r => r.COD_DPTO) : (short)0;
            if (maxCodigo >= short.MaxValue)
            {
                throw new Exception("Se ha alcanzado el límite de códigos disponibles.");
            }
            return (short)(maxCodigo + 1);
        }

        public short GenerarNuevoCodigoCiudad()
        {

            List<Ubigeo> ubicaciones = ubigeoRepository.BuscarTodasLasUbicaciones();
            short maxCodigo = ubicaciones.Any() ? ubicaciones.Max(r => r.COD_CIU) : (short)0;
            if (maxCodigo >= short.MaxValue)
            {
                throw new Exception("Se ha alcanzado el límite de códigos disponibles.");
            }
            return (short)(maxCodigo + 1);
        }

        public short GenerarNuevoCodigoBarrio()
        {

            List<Ubigeo> ubicaciones = ubigeoRepository.BuscarTodasLasUbicaciones();
            short maxCodigo = ubicaciones.Any() ? ubicaciones.Max(r => r.COD_BARR) : (short)0;
            if (maxCodigo >= short.MaxValue)
            {
                throw new Exception("Se ha alcanzado el límite de códigos disponibles.");
            }
            return (short)(maxCodigo + 1);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DateTime fechaActual = DateTime.Now;
            Ubigeo ubigeo = null;
            if (Global.UsuarioSesion == null || string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                MessageBox.Show("El usuario ADMIN solo permite el registro de Usuarios.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ubigeo = new Ubigeo(GenerarNuevoCodigoPais(), cbxPais.SelectedValue.ToString(), GenerarNuevoCodigoDepartamento(), txtDepartamento.Text, GenerarNuevoCodigoCiudad(),
                txtCiudad.Text, GenerarNuevoCodigoBarrio(), txtBarrio.Text, txtIdioma.Text, cbxContinente.SelectedValue.ToString(), short.Parse(cbxRegion.SelectedValue.ToString()), txtLatitud.Text, txtLogitud.Text, Global.UsuarioSesion.COD_USER, fechaActual);

            ubigeoRepository.InsertarUbicacion(ubigeo);
            limpiar();
            MessageBox.Show("Ubicacion insertada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void cargarComboBoxRegion()
        {
            List<RegionFisica> regiones = regionFisicaRepository.BuscarTodosLosRegistrosFiscales(); 

            cbxRegion.DisplayMember = "DES_REG"; 
            cbxRegion.ValueMember = "COD_REG";   
            cbxRegion.DataSource = regiones;    
        }

        private void CargarContinentes()
        {
        
            List<string> continentes = new List<string>
            {
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
            cargarUbigeos();
        }

        private void tblUbigeo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tblUbigeo.SelectedItems.Count > 0)
            {
                ListViewItem item = tblUbigeo.SelectedItems[0];
                string codigo = item.SubItems[0].Text;
                cbxPais.SelectedItem = item.SubItems[1].Text;
                txtDepartamento.Text = item.SubItems[3].Text;
                txtCiudad.Text = item.SubItems[5].Text;
                txtBarrio.Text = item.SubItems[7].Text;
                txtIdioma.Text = item.SubItems[8].Text;
                cbxContinente.SelectedItem = item.SubItems[9].Text;
                cbxRegion.SelectedValue = short.Parse(item.SubItems[10].Text);
                txtLatitud.Text = item.SubItems[11].Text;
                txtLogitud.Text = item.SubItems[12].Text;



                List<Ubigeo> listaUbigeos = ubigeoRepository.BuscarTodasLasUbicaciones();
                foreach(Ubigeo ubicacion in listaUbigeos)
                {
                    if (ubicacion.COD_PAIS.Equals(codigo))
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
                if (Modificar)
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
            if (Modificar)
            {
                ubigeoRepository.EliminarUbicacion(ubigeoSelect.COD_PAIS, ubigeoSelect.COD_DPTO, ubigeoSelect.COD_CIU, ubigeoSelect.COD_BARR);
                limpiar();
                MessageBox.Show("Ubicacion eliminada con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Seleccione una ubicacion para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}
