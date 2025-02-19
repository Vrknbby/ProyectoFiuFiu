﻿using MaterialSkin;
using MaterialSkin.Controls;
using PruebaUIs.DB;
using PruebaUIs.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaUIs
{
    public partial class Login : MaterialForm
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
        int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
        int nWidthEllipse, int nHeightEllipse);
        UsuarioRepository usuarioRepository = new UsuarioRepository();
        public Login()
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

            // Boton ENTER
            this.AcceptButton = btnIngresar;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            PasswordTxt.Password = !PasswordTxt.Password;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
        
            if (txtIngresarUsuario.Text == "ADMIN" && PasswordTxt.Text == "ADMIN" && usuarioRepository.BuscarTodosLosUsuarios().Count == 0)
            {
                Menu nuevoform = new Menu();
                nuevoform.Show();
                this.Hide();
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtIngresarUsuario.Text) || string.IsNullOrWhiteSpace(PasswordTxt.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!ValidarCredenciales(txtIngresarUsuario.Text, PasswordTxt.Text))
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Menu nuevoform = new Menu();
                nuevoform.Show();
                this.Hide();
            }

            
        }

        private bool ValidarCredenciales(string usuario, string contraseña)
        {
            
            return usuarioRepository.ValidarCredenciales(usuario, contraseña);
        }


        
    }
}
