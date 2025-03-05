using MaterialSkin;
using MaterialSkin.Controls;
using PruebaUIs.Model;
using PruebaUIs.Repository;
using PruebaUIs.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaUIs
{
    public partial class Menu : MaterialForm
    {


        UsuarioRepository usuarioRepository = new UsuarioRepository();

        public Menu()
        {
            InitializeComponent();
            CargarUsuarios();

            
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            tabPage2.BackColor = Color.White;
        }


        private void btnCompraArticulo_Click(object sender, EventArgs e)
        {
            Compra_Articulo nuevoform = new Compra_Articulo();
            nuevoform.Show();
            this.Hide();
        }


        //SECCION USUSARIO
        private void btnUserRegistrar_Click(object sender, EventArgs e)
        {
            UsuarioRepository usuarioRepository = new UsuarioRepository();
            DateTime fechaActual = DateTime.Now;
            Usuario user = null;
            //user = new Usuario(GenerarCodigoUsuario(), descripcionUserTxt.Text, correoUserTxt.Text, passwordUserTxt.Text, true, fechaActual);
            usuarioRepository.InsertarUsuario(user);
        }

        public string GenerarCodigoUsuario()
        {
            UsuarioRepository usuarioRepository = new UsuarioRepository();
            List<Usuario> usuarios = usuarioRepository.BuscarTodosLosUsuarios();
            string ultimoCodigo = usuarios.OrderByDescending(u => u.COD_USER).Select(u => u.COD_USER).FirstOrDefault();
            int nuevoNumero = 1; 

            if (!string.IsNullOrEmpty(ultimoCodigo))
            {
                string numeroStr = ultimoCodigo.Substring(1);
                if (int.TryParse(numeroStr, out int numero)) nuevoNumero = numero + 1;
            }
            int longDigito = nuevoNumero.ToString().Length + 1;
            string nuevoCodigo = $"U{nuevoNumero:D9}";
            while (usuarios.Any(u => u.COD_USER == nuevoCodigo))
            {
                nuevoNumero++;
                nuevoCodigo = $"U{nuevoNumero:D9}";
            }
            return nuevoCodigo;
        }

        private void btnUserRegistrar_Click_1(object sender, EventArgs e)
        {
            

            if (string.IsNullOrWhiteSpace(correoUserTxt.Text) || string.IsNullOrWhiteSpace(descripcionUserTxt.Text) || string.IsNullOrWhiteSpace(passwordUserTxt.Text) || string.IsNullOrWhiteSpace(confirmarPasswordUserTxt.Text))
            {
                MessageBox.Show("Porfavor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidarFormatoCorreo(correoUserTxt.Text))
            {
                MessageBox.Show("El correo no tiene un formato válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (usuarioRepository.CorreoExiste(correoUserTxt.Text))
            {
                MessageBox.Show("El correo ya está registrado. Utilice otro correo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (passwordUserTxt.Text != confirmarPasswordUserTxt.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden. Porfavor, verifíquelas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            DateTime fechaActual = DateTime.Now;
            Usuario user = null;
            user = new Usuario(GenerarCodigoUsuario(), descripcionUserTxt.Text, correoUserTxt.Text, passwordUserTxt.Text, true, fechaActual);
            usuarioRepository.InsertarUsuario(user);

            MessageBox.Show("Usuario registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CargarUsuarios();
            LimpiarCampos();
        }

        private bool ValidarFormatoCorreo(string correo)
        {
            string formato = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(correo, formato);
        }

        private void LimpiarCampos()
        {
            descripcionUserTxt.Clear();
            correoUserTxt.Clear();
            passwordUserTxt.Clear();
            confirmarPasswordUserTxt.Clear();
        }

        private void CargarUsuarios()
        {
            if (materialListView1.Columns.Count == 0)
            {
                materialListView1.Columns.Add("Cod_User", 150);
                materialListView1.Columns.Add("Descripcion", 300);
                materialListView1.Columns.Add("Email", 300);
                materialListView1.Columns.Add("Clave", 150);
                materialListView1.Columns.Add("Estado", 100);
                materialListView1.Columns.Add("Fecha Creacion", 300);

            }

            materialListView1.Items.Clear();

            List<Usuario> Usuarios = usuarioRepository.BuscarTodosLosUsuarios();

            foreach (Usuario usuario in Usuarios)
            {
                ListViewItem item = new ListViewItem(usuario.COD_USER);
                item.SubItems.Add(usuario.DES_USER);
                item.SubItems.Add(usuario.EMAIL_USER);
                item.SubItems.Add(usuario.CLAVE_USER);
                item.SubItems.Add(usuario.FLG_EST_USER.ToString());
                item.SubItems.Add(usuario.FEC_ABM.ToString());
                materialListView1.Items.Add(item);
            }
        }

        

        private void btnRegionFisica_Click(object sender, EventArgs e)
        {
            Region_Fisica nuevoform = new Region_Fisica();
            nuevoform.FormClosed += (s, args) => this.Show();
            nuevoform.Show();
            this.Hide();
        }

        private void btnUbicacionGeografica_Click(object sender, EventArgs e)
        {
            Ubicacion_Geografica nuevoform = new Ubicacion_Geografica();
            nuevoform.FormClosed += (s, args) => this.Show();
            nuevoform.Show();
            this.Hide();
        }

        private void btnSegmentoComerciales_Click(object sender, EventArgs e)
        {
            Segmentos_Comerciales nuevoform = new Segmentos_Comerciales();
            nuevoform.FormClosed += (s, args) => this.Show();
            nuevoform.Show();
            this.Hide();
        }

        private void btnMarcasArticulos_Click(object sender, EventArgs e)
        {
            Marcas_Articulos nuevoform = new Marcas_Articulos();
            nuevoform.FormClosed += (s, args) => this.Show();
            nuevoform.Show();
            this.Hide();
        }

        private void btnFamiliaArticulos_Click(object sender, EventArgs e)
        {
            Familia_Articulos nuevoform = new Familia_Articulos();
            nuevoform.FormClosed += (s, args) => this.Show();
            nuevoform.Show();
            this.Hide();
        }

        private void btnLocal_Click(object sender, EventArgs e)
        {
            Local nuevoform = new Local();
            nuevoform.FormClosed += (s, args) => this.Show();
            nuevoform.Show();
            this.Hide();
        }

        private void btnAlmacenes_Click(object sender, EventArgs e)
        {
            AlmacenUI nuevoform = new AlmacenUI();
            nuevoform.FormClosed += (s, args) => this.Show();
            nuevoform.Show();
            this.Hide();
        }

        private void btnPersona_Click(object sender, EventArgs e)
        {
            Persona nuevoform = new Persona();
            nuevoform.FormClosed += (s, args) => this.Show();
            nuevoform.Show();
            this.Hide();
        }

        private void btnTrabajador_Click(object sender, EventArgs e)
        {
            Trabajador nuevoform = new Trabajador();
            nuevoform.FormClosed += (s, args) => this.Show();
            nuevoform.Show();
            this.Hide();
        }

        private void btnVendedores_Click(object sender, EventArgs e)
        {
            Vendedores nuevoform = new Vendedores();
            nuevoform.FormClosed += (s, args) => this.Show();
            nuevoform.Show();
            this.Hide();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Clientes nuevoform = new Clientes();
            nuevoform.FormClosed += (s, args) => this.Show();
            nuevoform.Show();
            this.Hide();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            Provedor nuevoform = new Provedor();
            nuevoform.FormClosed += (s, args) => this.Show();
            nuevoform.Show();
            this.Hide();
        }

        private void btnFabricantes_Click(object sender, EventArgs e)
        {
            Fabricante nuevoform = new Fabricante();
            nuevoform.FormClosed += (s, args) => this.Show();
            nuevoform.Show();
            this.Hide();
        }

        private void btnMaestroArticulos_Click(object sender, EventArgs e)
        {
            Maestro_Articulos nuevoform = new Maestro_Articulos();
            nuevoform.FormClosed += (s, args) => this.Show();
            nuevoform.Show();
            this.Hide();
        }

        private void btnLoteArticulos_Click(object sender, EventArgs e)
        {
            Lote_Articulos nuevoform = new Lote_Articulos();
            nuevoform.FormClosed += (s, args) => this.Show();
            nuevoform.Show();
            this.Hide();
        }

    }
}
