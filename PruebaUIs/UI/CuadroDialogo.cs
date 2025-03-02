using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaUIs.UI
{
    public partial class CuadroDialogo : Form
    {
        private TextBox txtInput;
        private Button btnOk;
        private Button btnCancel;

        public string InputText { get; private set; }

        public CuadroDialogo(string mensaje, string titulo)
        {
            this.Text = titulo;
            this.Width = 400;
            this.Height = 200;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            Label lblMensaje = new Label() { Left = 20, Top = 20, Text = mensaje, AutoSize = true };
            txtInput = new TextBox() { Left = 20, Top = 50, Width = 340 };
            btnOk = new Button() { Text = "Enviar", Left = 120, Width = 80, Top = 90, DialogResult = DialogResult.OK };
            btnCancel = new Button() { Text = "Cancelar", Left = 220, Width = 80, Top = 90, DialogResult = DialogResult.Cancel };

            btnOk.Click += (sender, e) => { InputText = txtInput.Text; this.Close(); };
            btnCancel.Click += (sender, e) => { this.Close(); };

            this.Controls.Add(lblMensaje);
            this.Controls.Add(txtInput);
            this.Controls.Add(btnOk);
            this.Controls.Add(btnCancel);
        }
    }
}
