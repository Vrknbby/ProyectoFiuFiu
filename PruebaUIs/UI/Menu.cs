﻿using MaterialSkin;
using MaterialSkin.Controls;
using PruebaUIs.Model;
using PruebaUIs.Repository;
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

namespace PruebaUIs
{
    public partial class Menu : MaterialForm
    {



        //VARIABLES PARA EL BORDE
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
        int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
        int nWidthEllipse, int nHeightEllipse);



        public Menu()
        {
            InitializeComponent();


            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 25, 25));

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
            UsuarioRepository usuarioRepository = new UsuarioRepository();
            DateTime fechaActual = DateTime.Now;
            Usuario user = null;
            user = new Usuario(GenerarCodigoUsuario(), descripcionUserTxt.Text, correoUserTxt.Text, passwordUserTxt.Text, true, fechaActual);
            usuarioRepository.InsertarUsuario(user);
        }
       

    }
}
