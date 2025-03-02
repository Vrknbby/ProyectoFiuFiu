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
    public partial class Region_Fisica : MaterialForm
    {

        RegionFisicaRepository regionFisicaRepository = new RegionFisicaRepository();
        bool Modificar = false;
        RegionFisica regionFisicaSelect = null;
        public Region_Fisica()
        {
            InitializeComponent();

            
            cargarRegiones();
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

        private void Region_Fisica_Load(object sender, EventArgs e)
        {
            if (Global.UsuarioSesion != null && !string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                TxtCodUsuario.Text = Global.UsuarioSesion.COD_USER;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            DateTime fechaActual = DateTime.Now;
            RegionFisica region = null;
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Debe ingresar una descripción.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
=======

>>>>>>> Cristian
            if (Global.UsuarioSesion == null || string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                MessageBox.Show("El usuario ADMIN solo permite el registro de Usuarios.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
<<<<<<< HEAD
            region = new RegionFisica(GenerarNuevoCodigoRegion(), txtDescripcion.Text, Global.UsuarioSesion.COD_USER, fechaActual);
            regionFisicaRepository.InsertarRegistroFiscal(region);
            Limpiar();
            MessageBox.Show("Región insertada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
=======

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Por favor, complete el campo de descripción.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime fechaActual = DateTime.Now;
            RegionFisica region = new RegionFisica(GenerarNuevoCodigoRegion(), txtDescripcion.Text, Global.UsuarioSesion.COD_USER, fechaActual);
            regionFisicaRepository.InsertarRegistroFiscal(region);
            Limpiar();
            MessageBox.Show("Región insertada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
>>>>>>> Cristian
            Modificar = false;
        }


        private void cargarRegiones()
        {
            if (tblRegionFisica.Columns.Count == 0)
            {
                tblRegionFisica.Columns.Add("Codigo de Region", 225);
                tblRegionFisica.Columns.Add("Descripcion", 225);
                tblRegionFisica.Columns.Add("Codigo de Usuario", 225);
                tblRegionFisica.Columns.Add("Fecha de Creacion", 225);
            }

            tblRegionFisica.Items.Clear();

            List<RegionFisica> Regiones = regionFisicaRepository.BuscarTodosLosRegistrosFiscales();

            foreach (RegionFisica region in Regiones)
            {
                ListViewItem item = new ListViewItem(region.COD_REG.ToString());
                item.SubItems.Add(region.DES_REG);
                item.SubItems.Add(region.COD_USER);
                item.SubItems.Add(region.FEC_ABM.ToString());
                tblRegionFisica.Items.Add(item);
            }
        }


        public short GenerarNuevoCodigoRegion()
        {
            
            List<RegionFisica> regiones = regionFisicaRepository.BuscarTodosLosRegistrosFiscales();
            short maxCodigo = regiones.Any() ? regiones.Max(r => r.COD_REG) : (short)0;
            if (maxCodigo >= short.MaxValue)
            {
                throw new Exception("Se ha alcanzado el límite de códigos disponibles.");
            }
            return (short)(maxCodigo + 1);
        }

        private void tblRegionFisica_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tblRegionFisica.SelectedItems.Count > 0)
            {
                ListViewItem item = tblRegionFisica.SelectedItems[0];
                string codigo = item.SubItems[0].Text;
                txtDescripcion.Text = item.SubItems[1].Text;  
                TxtCodUsuario.Text = item.SubItems[2].Text;

                regionFisicaSelect = regionFisicaRepository.BuscarRegistroFiscalPorCodigo(short.Parse(codigo));
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
                if (Modificar == true)
                {
                    DateTime fechaActual = DateTime.Now;
                    RegionFisica region = regionFisicaSelect;
                    region.COD_USER = Global.UsuarioSesion.COD_USER;
                    region.DES_REG = txtDescripcion.Text;
                    region.FEC_ABM = fechaActual;
                    regionFisicaRepository.ActualizarRegistroFiscal(region);
                    Limpiar();
                    MessageBox.Show("Campos actualizados con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Seleccione una region de la tabla para modificar.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Limpiar()
        {
            txtDescripcion.Clear();
            if (Global.UsuarioSesion != null && !string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                TxtCodUsuario.Text = Global.UsuarioSesion.COD_USER.ToString();
            }
            else
            {
                TxtCodUsuario.Text = "";
            }
            cargarRegiones();
            Modificar = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioSesion == null || string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                MessageBox.Show("El usuario ADMIN solo permite el registro de Usuarios.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                CuadroDialogo Input = new CuadroDialogo("Ingrese la Region que desea Buscar", "Buscar Region");
                if (Input.ShowDialog() == DialogResult.OK)
                {
                    string mensaje = Input.InputText;

                    if (!string.IsNullOrWhiteSpace(mensaje))
                    {
                        List<RegionFisica> regiones = regionFisicaRepository.BuscarTodosLosRegistrosFiscales();
                        tblRegionFisica.Clear();
                        tblRegionFisica.Columns.Add("Codigo de Region", 225);
                        tblRegionFisica.Columns.Add("Descripcion", 225);
                        tblRegionFisica.Columns.Add("Codigo de Usuario", 225);
                        tblRegionFisica.Columns.Add("Fecha de Creacion", 225);
                        foreach (RegionFisica region in regiones)
                        {
                            if (region.DES_REG.ToLower().Contains(mensaje.ToLower()))
                            {
                                ListViewItem item = new ListViewItem(region.COD_REG.ToString());
                                item.SubItems.Add(region.DES_REG);
                                item.SubItems.Add(region.COD_USER);
                                item.SubItems.Add(region.FEC_ABM.ToString());
                                tblRegionFisica.Items.Add(item);
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
