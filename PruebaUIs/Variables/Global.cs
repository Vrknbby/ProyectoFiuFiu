using MaterialSkin.Controls;
using PruebaUIs.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaUIs.Variables
{
    public static class Global
    {
        public static Usuario UsuarioSesion { get; set; } = null;


        public static void LimpiarControles(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is MaterialTextBox txt) txt.Clear();
                else if (c is MaterialListView) continue;
                else if (c is MaterialRadioButton rb) rb.Checked = false;
                else if (c is MaterialComboBox cbo)
                {
                    if (cbo.Items.Count > 0) cbo.SelectedIndex = 0;
                    cbo.DataSource = null;
                    cbo.Refresh();
                }
                else if (c is GroupBox || c is Panel || c is TabPage)
                {
                    LimpiarControles(c);
                }
            }
        }
    }
}
