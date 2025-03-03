using MaterialSkin;
using MaterialSkin.Controls;
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
using PruebaUIs.Repository;
using PruebaUIs.Model;
using PruebaUIs.Variables;
using PruebaUIs.UI;

namespace PruebaUIs
{
    public partial class Provedor : MaterialForm
    {
        private Proveedor proveedorSelect = null;
        private ProveedorRepository proveedorRepository = new ProveedorRepository();

        public Provedor()
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
            CargarProveedores();
        }

        private void Provedor_Load(object sender, EventArgs e)
        {
            if (Global.UsuarioSesion != null && !string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                codUserTxt.Text = Global.UsuarioSesion.COD_USER;

            }
        }

        private void CargarProveedores()
        {
            try
            {
                if (tblProveedor.Columns.Count == 0)
                {
                    tblProveedor.Columns.Add("Código de Proveedor", 100);
                    tblProveedor.Columns.Add("Código de Persona", 100);
                    tblProveedor.Columns.Add("Inhabilitado para realizar operaciones (S/N)", 100);
                    tblProveedor.Columns.Add("Tiempo de atención de la compra (días)", 100);
                    tblProveedor.Columns.Add("Compra mínima en unidades monetarias", 100);
                    tblProveedor.Columns.Add("Código de usuario", 80);
                    tblProveedor.Columns.Add("Fecha de Creación/Modificación/Anulación", 150);
                }
                tblProveedor.Items.Clear();

                List<Proveedor> lista = proveedorRepository.BuscarTodosLosProveedores();
                foreach (Proveedor prov in lista)
                {
                    ListViewItem item = new ListViewItem(prov.COD_PRV);
                    item.SubItems.Add(prov.COD_PER);
                    item.SubItems.Add((prov.FLG_INH_MOV == true) ? "Sí" : "No");
                    item.SubItems.Add(prov.VAL_TIE_ATC.ToString());
                    item.SubItems.Add(prov.VAL_CMN_UMO.ToString());
                    item.SubItems.Add(prov.COD_USER);
                    item.SubItems.Add(prov.FEC_ABM.ToString());
                    tblProveedor.Items.Add(item);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proveedores: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buscarProveedorBtn_Click(object sender, EventArgs e)
        {
            CuadroDialogo input = new CuadroDialogo("Ingrese el código del proveedor a buscar", "Buscar Proveedor");
            if (input.ShowDialog() == DialogResult.OK)
            {
                string codBuscado = input.InputText;
                if (string.IsNullOrWhiteSpace(codBuscado))
                {
                    MessageBox.Show("Debe ingresar un código de proveedor válido.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Proveedor prv = proveedorRepository.BuscarProveedorPorCodigo(codBuscado);

                tblProveedor.Clear();
                tblProveedor.Columns.Add("Código de Proveedor", 100);
                tblProveedor.Columns.Add("Código de Persona", 100);
                tblProveedor.Columns.Add("Inhabilitado para realizar operaciones (S/N)", 100);
                tblProveedor.Columns.Add("Tiempo de atención de la compra (días)", 100);
                tblProveedor.Columns.Add("Compra mínima en unidades monetarias", 100);
                tblProveedor.Columns.Add("Código de usuario", 80);
                tblProveedor.Columns.Add("Fecha de Creación/Modificación/Anulación", 150);

                if (prv != null)
                {
                    ListViewItem item = new ListViewItem(prv.COD_PRV);
                    item.SubItems.Add(prv.COD_PER);
                    item.SubItems.Add((prv.FLG_INH_MOV == true) ? "Sí" : "No");
                    item.SubItems.Add(prv.VAL_TIE_ATC.ToString());
                    item.SubItems.Add(prv.VAL_CMN_UMO.ToString());
                    item.SubItems.Add(prv.COD_USER);
                    item.SubItems.Add(prv.FEC_ABM.ToString());
                    tblProveedor.Items.Add(item);
                }
                else
                {
                    MessageBox.Show("No se encontró un proveedor con ese código.",
                                    "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void GuardarProveedorBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(codPersonaTxt.Text) ||
                string.IsNullOrWhiteSpace(compraMinimaProveedorTxt.Text) ||
                string.IsNullOrWhiteSpace(tiempoAtencionProveedorTxt.Text) ||
                (!siProveedorRbtn.Checked && !noProveedorRbtn.Checked))
            {
                MessageBox.Show("Complete todos los campos obligatorios.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DateTime fechaActual = DateTime.Now;
            bool flg = true;

            if (siProveedorRbtn.Checked)
            {
                flg = true;
            }
            else
            {
                flg = false;
            }
            Proveedor proveedor = new Proveedor(GenerarCodigoProveedor(),
                codPersonaTxt.Text, 
                flg,
                int.Parse(tiempoAtencionProveedorTxt.Text.ToString()),
                int.Parse(compraMinimaProveedorTxt.Text.ToString()),
                codUserTxt.Text,
                fechaActual);
            proveedorRepository.InsertarProveedor(proveedor);
        }

        public string GenerarCodigoProveedor()
        {
            List<Proveedor> proveedores = proveedorRepository.BuscarTodosLosProveedores();
            string ultimoCodigo = proveedores.OrderByDescending(p => p.COD_PRV).Select(p => p.COD_PRV).FirstOrDefault();
            int nuevoNumero = 1;

            if (!string.IsNullOrEmpty(ultimoCodigo))
            {
                string numeroStr = ultimoCodigo.Substring(3);
                if (int.TryParse(numeroStr, out int numero)) nuevoNumero = numero + 1;
            }

            int longDigito = nuevoNumero.ToString().Length + 1;

            string nuevoCodigo = $"PRV{nuevoNumero:D7}";
            while (proveedores.Any(p => p.COD_PRV == nuevoCodigo))
            {
                nuevoNumero++;
                nuevoCodigo = $"PRV{nuevoNumero:D7}";
            }
            return nuevoCodigo;
        }

        private void tblProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tblProveedor.SelectedItems.Count > 0)
            {
                try
                {

                    ListViewItem item = tblProveedor.SelectedItems[0];
                    string codPrv = item.SubItems[0].Text;


                    proveedorSelect = proveedorRepository.BuscarProveedorPorCodigo(codPrv);
                    if (proveedorSelect != null)
                    {

                        codProveedorTxt.Text = proveedorSelect.COD_PRV;
                        codPersonaTxt.Text = proveedorSelect.COD_PER;
                        codUserTxt.Text = proveedorSelect.COD_USER;
                        compraMinimaProveedorTxt.Text = proveedorSelect.VAL_CMN_UMO.ToString();
                        tiempoAtencionProveedorTxt.Text = proveedorSelect.VAL_TIE_ATC.ToString();

                        if (proveedorSelect.FLG_INH_MOV == true)
                        {
                            noProveedorRbtn.Checked = false;
                            siProveedorRbtn.Checked = true;
                        }
                        else
                        {
                            noProveedorRbtn.Checked = true;
                            siProveedorRbtn.Checked = false;
                        }
                        fechaCreaModAnuTxt.Value = proveedorSelect.FEC_ABM;

                        codPersonaTxt.Enabled = false;
                        modificarProveedorBtn.Enabled = true;
                        GuardarProveedorBtn.Enabled = false;
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
            codProveedorTxt.Text = "";
            codUserTxt.Text = Global.UsuarioSesion.COD_USER;
            codPersonaTxt.Enabled = true;
            codPersonaTxt.Text = "";
            tiempoAtencionProveedorTxt.Text = "";
            compraMinimaProveedorTxt.Text = "";
            siProveedorRbtn.Checked = false;
            noProveedorRbtn.Checked = false;
            fechaCreaModAnuTxt.Value = DateTime.Now;
            modificarProveedorBtn.Enabled = false;
            GuardarProveedorBtn.Enabled = true;
            proveedorSelect = null;
            CargarProveedores();
        }
        private void cancelarProveedorBtn_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void modificarProveedorBtn_Click(object sender, EventArgs e)
        {
            DateTime fechaActual = DateTime.Now;
            proveedorSelect.COD_USER = Global.UsuarioSesion.COD_USER;
            if (siProveedorRbtn.Checked)
            {
                proveedorSelect.FLG_INH_MOV = true;
            }
            else
            {
                proveedorSelect.FLG_INH_MOV = false;
            }
            proveedorSelect.VAL_TIE_ATC = Convert.ToInt32(tiempoAtencionProveedorTxt.Text.ToString());
            proveedorSelect.VAL_CMN_UMO = Convert.ToInt32(compraMinimaProveedorTxt.Text.ToString());
            proveedorSelect.FEC_ABM = fechaActual;

            proveedorRepository.ActualizarProveedor(proveedorSelect);
            MessageBox.Show("Persona actualizada correctamente.",
                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Limpiar();


        }

        private void eliminarProveedorBtn_Click(object sender, EventArgs e)
        {
            if(proveedorSelect == null)
            {
                MessageBox.Show("Seleccione un proveedor para eliminar.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("¿Está seguro de eliminar el proveedor seleccionado?",
                  "Confirmar eliminación",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    proveedorRepository.EliminarProveedor(proveedorSelect.COD_PRV);

                    Limpiar();

                    MessageBox.Show("Proveedor eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
                     
        }
    }
}
