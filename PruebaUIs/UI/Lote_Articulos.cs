using MaterialSkin.Controls;
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
    public partial class Lote_Articulos : MaterialForm
    {
        private LoteArticulosRepository loteArticulosRepository = new LoteArticulosRepository();
        private ProveedorRepository provedorRepository = new ProveedorRepository();
        private ArticuloRepository articuloRepository = new ArticuloRepository();
        private PersonaRepository personaRepository = new PersonaRepository();
        private LoteArticulos loteArticulosSelect = null;
        public Lote_Articulos()
        {
            InitializeComponent();
            CargarArticulos();
            CargarProveedores();
            CargarLoteArticulos();
        }
        private void CargarArticulos()
        {
            var articulos = articuloRepository.BuscarTodosLosArticulos();
            articulos.Insert(0, new Articulo { COD_ART = "", DES_ART = "-- Seleccionar --" });

            cboArticulo.DataSource = articulos;
            cboArticulo.DisplayMember = "DES_ART";
            cboArticulo.ValueMember = "COD_ART";

        }
        private void CargarProveedores()
        {
            var proveedores = provedorRepository.BuscarTodosLosProveedores();
            var personas = personaRepository.BuscarTodasLasPersonas();

            var listaProveedores = proveedores
                .Select(v => new
                {
                    v.COD_PRV,
                    Nombre = personas.FirstOrDefault(p => p.COD_PER == v.COD_PER)?.DES_PER ?? "Sin Nombre"
                })
                .ToList();

            listaProveedores.Insert(0, new { COD_PRV = "", Nombre = "-- Seleccionar --" });

            cboProveedor.DataSource = listaProveedores;
            cboProveedor.DisplayMember = "Nombre";
            cboProveedor.ValueMember = "COD_PRV";
        }
        private void CargarLoteArticulos()
        {
            try
            {
                if (tblLoteArticulos.Columns.Count == 0)
                {
                    tblLoteArticulos.Columns.Add("Numero de Lote", 150);
                    tblLoteArticulos.Columns.Add("Código de articulo o servicio", 150);
                    tblLoteArticulos.Columns.Add("Código de proveedo", 150);
                    tblLoteArticulos.Columns.Add("Articulo en consignación (S/N)", 150);
                    tblLoteArticulos.Columns.Add("Carta compromiso de canje? (S/N)", 150);
                    tblLoteArticulos.Columns.Add("Código de carta compromiso", 150);
                    tblLoteArticulos.Columns.Add("Fecha de inicio", 150);
                    tblLoteArticulos.Columns.Add("Fecha de fin", 150);
                    tblLoteArticulos.Columns.Add("Numero máximo de unidades para canje por vencimiento", 150);
                    tblLoteArticulos.Columns.Add("Código de usuario", 150);
                    tblLoteArticulos.Columns.Add("Fecha de Creación/Modificación/Anulación", 150);
                }
                tblLoteArticulos.Items.Clear();

                List<LoteArticulos> lista = loteArticulosRepository.BuscarTodosLosLoteArticulos();
                foreach (LoteArticulos lote in lista)
                {
                    ListViewItem item = new ListViewItem(lote.NRO_LOTE);
                    item.SubItems.Add(lote.COD_ART);
                    item.SubItems.Add(lote.COD_PRV);
                    item.SubItems.Add((lote.FLG_CON_CONS == true) ? "Sí" : "No");
                    item.SubItems.Add(lote.FLG_CON_CANJE.ToString());
                    item.SubItems.Add(lote.COD_CARTA);
                    item.SubItems.Add(lote.FEC_INI_LOTE.ToString());
                    item.SubItems.Add(lote.FEC_FIN_LOTE.ToString());
                    item.SubItems.Add(lote.VAL_MAX_CANJE.ToString());
                    item.SubItems.Add(lote.COD_USER);
                    item.SubItems.Add(lote.FEC_ABM.ToString());
                    tblLoteArticulos.Items.Add(item);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar lotes de articulo: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Lote_Articulos_Load(object sender, EventArgs e)
        {
            if (Global.UsuarioSesion != null && !string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
            {
                codUserTxt.Text = Global.UsuarioSesion.COD_USER;

            }

        }

        public string GenerarCodigoLote()
        {
            List<LoteArticulos> loteArticulos = loteArticulosRepository.BuscarTodosLosLoteArticulos();
            string ultimoCodigo = loteArticulos.OrderByDescending(p => p.NRO_LOTE).Select(p => p.NRO_LOTE).FirstOrDefault();
            int nuevoNumero = 1;

            if (!string.IsNullOrEmpty(ultimoCodigo))
            {
                string numeroStr = ultimoCodigo.Substring(3);
                if (int.TryParse(numeroStr, out int numero)) nuevoNumero = numero + 1;
            }

            int longDigito = nuevoNumero.ToString().Length + 1;

            string nuevoCodigo = $"LTA{nuevoNumero:D7}";
            while (loteArticulos.Any(p => p.NRO_LOTE == nuevoCodigo))
            {
                nuevoNumero++;
                nuevoCodigo = $"LTA{nuevoNumero:D7}";
            }
            return nuevoCodigo;
        }
        private void buscarBtn_Click(object sender, EventArgs e)
        {
            CuadroDialogo input = new CuadroDialogo("Ingrese el numero de lote \n, código de articulo\n y código de proveedor \n separados por un espacio", "Buscar Lote de Articulo");
            if (input.ShowDialog() == DialogResult.OK)
            {
                string[] partes = input.InputText.Split(' ');
                if (partes.Length < 3)
                {
                    MessageBox.Show("Debe ingresar los valores: numero de lote, código de articulo y código de proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string nroLote = partes[0].Trim();
                string codArt = partes[1].Trim();
                string codPrv = partes[2].Trim();

                LoteArticulos lote = loteArticulosRepository.BuscarLoteArticuloPorCodigo(nroLote, codArt, codPrv);

                tblLoteArticulos.Clear();
                tblLoteArticulos.Columns.Add("Numero de Lote", 150);
                tblLoteArticulos.Columns.Add("Código de articulo o servicio", 150);
                tblLoteArticulos.Columns.Add("Código de proveedo", 150);
                tblLoteArticulos.Columns.Add("Articulo en consignación (S/N)", 150);
                tblLoteArticulos.Columns.Add("Carta compromiso de canje? (S/N)", 150);
                tblLoteArticulos.Columns.Add("Código de carta compromiso", 150);
                tblLoteArticulos.Columns.Add("Fecha de inicio", 150);
                tblLoteArticulos.Columns.Add("Fecha de fin", 150);
                tblLoteArticulos.Columns.Add("Numero máximo de unidades para canje por vencimiento", 150);
                tblLoteArticulos.Columns.Add("Código de usuario", 150);
                tblLoteArticulos.Columns.Add("Fecha de Creación/Modificación/Anulación", 150);

                if (lote != null)
                {
                    ListViewItem item = new ListViewItem(lote.NRO_LOTE);
                    item.SubItems.Add(lote.COD_ART);
                    item.SubItems.Add(lote.COD_PRV);
                    item.SubItems.Add((lote.FLG_CON_CONS == true) ? "Sí" : "No");
                    item.SubItems.Add((lote.FLG_CON_CANJE == true) ? "Sí" : "No");
                    item.SubItems.Add(lote.COD_CARTA);
                    item.SubItems.Add(lote.FEC_INI_LOTE.ToString());
                    item.SubItems.Add(lote.FEC_FIN_LOTE.ToString());
                    item.SubItems.Add(lote.VAL_MAX_CANJE.ToString());
                    item.SubItems.Add(lote.COD_USER);
                    item.SubItems.Add(lote.FEC_ABM.ToString());
                    tblLoteArticulos.Items.Add(item);
                }
                else
                {
                    MessageBox.Show("No se encontró un lote de articulo con ese código.",
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
            if (string.IsNullOrWhiteSpace(codCartaCompromiso.Text) ||
                (!siArticuloConsignacionTxt.Checked && !noArticuloConsignacionTxt.Checked) ||
                (!siCartaCompromisoTxt.Checked && !noCartaCompromisoTxt.Checked) ||
                cboArticulo.SelectedIndex <= 0 ||
                cboProveedor.SelectedIndex <= 0)
            {
                MessageBox.Show("Complete todos los campos obligatorios.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DateTime fechaActual = DateTime.Now;
            bool flgArtCon = true;

            if (siArticuloConsignacionTxt.Checked)
            {
                flgArtCon = true;
            }
            else
            {
                flgArtCon = false;
            }

            bool flgCarta = true;

            if (siCartaCompromisoTxt.Checked)
            {
                flgCarta = true;
            }
            else
            {
                flgCarta = false;
            }
            LoteArticulos loteArticulos = new LoteArticulos(GenerarCodigoLote(),
                cboArticulo.SelectedValue.ToString(),
                cboProveedor.SelectedValue.ToString(),
                flgArtCon,
                flgCarta,
                codCartaCompromiso.Text.ToString(),
                fecInicioTxt.Value,
                fecFinTxt.Value,
                Convert.ToDecimal(nroMaximoUnidadesTxt.Text.ToString()),
                codUserTxt.Text,
                fechaActual);
            loteArticulosRepository.InsertarLoteArticulos(loteArticulos);
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
            if(loteArticulosSelect != null)
            {
                loteArticulosSelect.NRO_LOTE = nroLoteTxt.Text.ToString();
                loteArticulosSelect.COD_USER = Global.UsuarioSesion.COD_USER;
                loteArticulosSelect.COD_ART = cboArticulo.SelectedValue.ToString();
                loteArticulosSelect.COD_PRV = cboProveedor.SelectedValue.ToString();

                if (siArticuloConsignacionTxt.Checked)
                {
                    loteArticulosSelect.FLG_CON_CONS = true;
                }
                else
                {
                    loteArticulosSelect.FLG_CON_CONS = false;
                }

                if (siCartaCompromisoTxt.Checked)
                {
                    loteArticulosSelect.FLG_CON_CANJE = true;
                }
                else
                {
                    loteArticulosSelect.FLG_CON_CANJE = false;
                }
                loteArticulosSelect.COD_CARTA = codCartaCompromiso.Text.ToString();
                loteArticulosSelect.FEC_INI_LOTE = fecInicioTxt.Value;
                loteArticulosSelect.FEC_FIN_LOTE = fecFinTxt.Value;
                loteArticulosSelect.VAL_MAX_CANJE = Convert.ToDecimal(nroMaximoUnidadesTxt.Text.ToString());
                loteArticulosSelect.FEC_ABM = fechaActual;

                loteArticulosRepository.ActualizarLoteArticulos(loteArticulosSelect);

                Limpiar();
                MessageBox.Show("Lote de articulo actualizada correctamente.",
                 "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No has seleccionada un lote de articulos.",
                        "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void Limpiar()
        {
            nroLoteTxt.Text = "";
            if (Global.UsuarioSesion != null && !string.IsNullOrWhiteSpace(Global.UsuarioSesion.COD_USER))
                codUserTxt.Text = Global.UsuarioSesion.COD_USER;
            else
                codUserTxt.Text = ""; 
            cboArticulo.SelectedIndex = 0;
            cboProveedor.SelectedIndex = 0;
            cboArticulo.Refresh();
            cboProveedor.Refresh();
            codCartaCompromiso.Text = "";
            siArticuloConsignacionTxt.Checked = false;
            noArticuloConsignacionTxt.Checked = false;
            siCartaCompromisoTxt.Checked = false;
            noCartaCompromisoTxt.Checked = false;
            nroMaximoUnidadesTxt.Text = "";
            fecInicioTxt.Value = DateTime.Now;
            fecFinTxt.Value = DateTime.Now;
            fecCreaModAnulTxt.Value = DateTime.Now;
            guardarBtn.Enabled = true;
            modificarBtn.Enabled = false;
            CargarProveedores();
            CargarArticulos();
            CargarLoteArticulos();
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
            if (loteArticulosSelect == null)
            {
                MessageBox.Show("Seleccione un lote de articulo para eliminar.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("¿Está seguro de eliminar el lote de articulo seleccionado?",
                  "Confirmar eliminación",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    loteArticulosRepository.EliminarLoteArticulo(loteArticulosSelect.NRO_LOTE, loteArticulosSelect.COD_ART, loteArticulosSelect.COD_PRV);

                    Limpiar();

                    MessageBox.Show("Lote de articulo eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void tblLoteArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tblLoteArticulos.SelectedItems.Count > 0)
            {
                try
                {

                    ListViewItem item = tblLoteArticulos.SelectedItems[0];
                    string nroLote = item.SubItems[0].Text;
                    string codArt = item.SubItems[1].Text;
                    string codPrv = item.SubItems[2].Text;


                    loteArticulosSelect = loteArticulosRepository.BuscarLoteArticuloPorCodigo(nroLote, codArt, codPrv);
                    if (loteArticulosSelect != null)
                    {

                        nroLoteTxt.Text = loteArticulosSelect.COD_PRV;
                        cboArticulo.SelectedValue = loteArticulosSelect.COD_ART;
                        cboProveedor.SelectedValue = loteArticulosSelect.COD_PRV;
                        codUserTxt.Text = loteArticulosSelect.COD_USER;
                        nroMaximoUnidadesTxt.Text = loteArticulosSelect.VAL_MAX_CANJE.ToString();
                        codCartaCompromiso.Text = loteArticulosSelect.COD_CARTA;


                        if (loteArticulosSelect.FLG_CON_CONS == true)
                        {
                            noArticuloConsignacionTxt.Checked = false;
                            siArticuloConsignacionTxt.Checked = true;
                        }
                        else
                        {
                            noArticuloConsignacionTxt.Checked = true;
                            siArticuloConsignacionTxt.Checked = false;
                        }


                        if (loteArticulosSelect.FLG_CON_CANJE == true)
                        {
                            noCartaCompromisoTxt.Checked = false;
                            siCartaCompromisoTxt.Checked = true;
                        }
                        else
                        {
                            noCartaCompromisoTxt.Checked = true;
                            siCartaCompromisoTxt.Checked = false;
                        }
                        fecCreaModAnulTxt.Value = loteArticulosSelect.FEC_ABM;
                        cboArticulo.Refresh();
                        cboProveedor.Refresh();
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
    }
}

