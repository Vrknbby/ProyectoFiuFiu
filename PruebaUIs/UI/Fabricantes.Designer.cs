
namespace PruebaUIs
{
    partial class Fabricante
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.cboPersona = new MaterialSkin.Controls.MaterialComboBox();
            this.buscarBtn = new MaterialSkin.Controls.MaterialButton();
            this.tblFabricantes = new MaterialSkin.Controls.MaterialListView();
            this.eliminarBtn = new MaterialSkin.Controls.MaterialButton();
            this.modificarBtn = new MaterialSkin.Controls.MaterialButton();
            this.cancelarBtn = new MaterialSkin.Controls.MaterialButton();
            this.guardarBtn = new MaterialSkin.Controls.MaterialButton();
            this.fechaCreaModAnuTxt = new System.Windows.Forms.DateTimePicker();
            this.codUsuarioTxt = new MaterialSkin.Controls.MaterialTextBox();
            this.codFabricanteTxt = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialCard1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.cboPersona);
            this.materialCard1.Controls.Add(this.buscarBtn);
            this.materialCard1.Controls.Add(this.tblFabricantes);
            this.materialCard1.Controls.Add(this.eliminarBtn);
            this.materialCard1.Controls.Add(this.modificarBtn);
            this.materialCard1.Controls.Add(this.cancelarBtn);
            this.materialCard1.Controls.Add(this.guardarBtn);
            this.materialCard1.Controls.Add(this.fechaCreaModAnuTxt);
            this.materialCard1.Controls.Add(this.codUsuarioTxt);
            this.materialCard1.Controls.Add(this.codFabricanteTxt);
            this.materialCard1.Controls.Add(this.materialLabel4);
            this.materialCard1.Controls.Add(this.materialLabel3);
            this.materialCard1.Controls.Add(this.materialLabel2);
            this.materialCard1.Controls.Add(this.materialLabel1);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(-4, 62);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(9, 11, 9, 11);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(9, 11, 9, 11);
            this.materialCard1.Size = new System.Drawing.Size(868, 430);
            this.materialCard1.TabIndex = 0;
            // 
            // cboPersona
            // 
            this.cboPersona.AutoResize = false;
            this.cboPersona.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboPersona.Depth = 0;
            this.cboPersona.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboPersona.DropDownHeight = 174;
            this.cboPersona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPersona.DropDownWidth = 121;
            this.cboPersona.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboPersona.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cboPersona.FormattingEnabled = true;
            this.cboPersona.IntegralHeight = false;
            this.cboPersona.ItemHeight = 43;
            this.cboPersona.Location = new System.Drawing.Point(452, 20);
            this.cboPersona.MaxDropDownItems = 4;
            this.cboPersona.MouseState = MaterialSkin.MouseState.OUT;
            this.cboPersona.Name = "cboPersona";
            this.cboPersona.Size = new System.Drawing.Size(259, 49);
            this.cboPersona.StartIndex = 0;
            this.cboPersona.TabIndex = 51;
            // 
            // buscarBtn
            // 
            this.buscarBtn.AutoSize = false;
            this.buscarBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buscarBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buscarBtn.Depth = 0;
            this.buscarBtn.HighEmphasis = true;
            this.buscarBtn.Icon = null;
            this.buscarBtn.Location = new System.Drawing.Point(731, 13);
            this.buscarBtn.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.buscarBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.buscarBtn.Name = "buscarBtn";
            this.buscarBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buscarBtn.Size = new System.Drawing.Size(112, 29);
            this.buscarBtn.TabIndex = 13;
            this.buscarBtn.Text = "BUSCAR";
            this.buscarBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buscarBtn.UseAccentColor = false;
            this.buscarBtn.UseVisualStyleBackColor = true;
            this.buscarBtn.Click += new System.EventHandler(this.buscarBtn_Click);
            // 
            // tblFabricantes
            // 
            this.tblFabricantes.AutoSizeTable = false;
            this.tblFabricantes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tblFabricantes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tblFabricantes.Depth = 0;
            this.tblFabricantes.FullRowSelect = true;
            this.tblFabricantes.HideSelection = false;
            this.tblFabricantes.Location = new System.Drawing.Point(30, 214);
            this.tblFabricantes.MinimumSize = new System.Drawing.Size(200, 100);
            this.tblFabricantes.MouseLocation = new System.Drawing.Point(-1, -1);
            this.tblFabricantes.MouseState = MaterialSkin.MouseState.OUT;
            this.tblFabricantes.Name = "tblFabricantes";
            this.tblFabricantes.OwnerDraw = true;
            this.tblFabricantes.Size = new System.Drawing.Size(813, 202);
            this.tblFabricantes.TabIndex = 12;
            this.tblFabricantes.UseCompatibleStateImageBehavior = false;
            this.tblFabricantes.View = System.Windows.Forms.View.Details;
            this.tblFabricantes.SelectedIndexChanged += new System.EventHandler(this.tblFabricantes_SelectedIndexChanged);
            // 
            // eliminarBtn
            // 
            this.eliminarBtn.AutoSize = false;
            this.eliminarBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.eliminarBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.eliminarBtn.Depth = 0;
            this.eliminarBtn.HighEmphasis = true;
            this.eliminarBtn.Icon = null;
            this.eliminarBtn.Location = new System.Drawing.Point(731, 176);
            this.eliminarBtn.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.eliminarBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.eliminarBtn.Name = "eliminarBtn";
            this.eliminarBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.eliminarBtn.Size = new System.Drawing.Size(109, 29);
            this.eliminarBtn.TabIndex = 11;
            this.eliminarBtn.Text = "Eliminar";
            this.eliminarBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.eliminarBtn.UseAccentColor = false;
            this.eliminarBtn.UseVisualStyleBackColor = true;
            this.eliminarBtn.Click += new System.EventHandler(this.eliminarBtn_Click);
            // 
            // modificarBtn
            // 
            this.modificarBtn.AutoSize = false;
            this.modificarBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.modificarBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.modificarBtn.Depth = 0;
            this.modificarBtn.Enabled = false;
            this.modificarBtn.HighEmphasis = true;
            this.modificarBtn.Icon = null;
            this.modificarBtn.Location = new System.Drawing.Point(731, 95);
            this.modificarBtn.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.modificarBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.modificarBtn.Name = "modificarBtn";
            this.modificarBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.modificarBtn.Size = new System.Drawing.Size(112, 29);
            this.modificarBtn.TabIndex = 10;
            this.modificarBtn.Text = "Modificar";
            this.modificarBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.modificarBtn.UseAccentColor = false;
            this.modificarBtn.UseVisualStyleBackColor = true;
            this.modificarBtn.Click += new System.EventHandler(this.modificarBtn_Click);
            // 
            // cancelarBtn
            // 
            this.cancelarBtn.AutoSize = false;
            this.cancelarBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cancelarBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.cancelarBtn.Depth = 0;
            this.cancelarBtn.HighEmphasis = true;
            this.cancelarBtn.Icon = null;
            this.cancelarBtn.Location = new System.Drawing.Point(731, 136);
            this.cancelarBtn.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.cancelarBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.cancelarBtn.Name = "cancelarBtn";
            this.cancelarBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.cancelarBtn.Size = new System.Drawing.Size(109, 29);
            this.cancelarBtn.TabIndex = 9;
            this.cancelarBtn.Text = "Cancelar";
            this.cancelarBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.cancelarBtn.UseAccentColor = false;
            this.cancelarBtn.UseVisualStyleBackColor = true;
            this.cancelarBtn.Click += new System.EventHandler(this.cancelarBtn_Click);
            // 
            // guardarBtn
            // 
            this.guardarBtn.AutoSize = false;
            this.guardarBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.guardarBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.guardarBtn.Depth = 0;
            this.guardarBtn.HighEmphasis = true;
            this.guardarBtn.Icon = null;
            this.guardarBtn.Location = new System.Drawing.Point(731, 54);
            this.guardarBtn.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.guardarBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.guardarBtn.Name = "guardarBtn";
            this.guardarBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.guardarBtn.Size = new System.Drawing.Size(112, 29);
            this.guardarBtn.TabIndex = 8;
            this.guardarBtn.Text = "GUARDAR";
            this.guardarBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.guardarBtn.UseAccentColor = false;
            this.guardarBtn.UseVisualStyleBackColor = true;
            this.guardarBtn.Click += new System.EventHandler(this.guardarBtn_Click);
            // 
            // fechaCreaModAnuTxt
            // 
            this.fechaCreaModAnuTxt.Enabled = false;
            this.fechaCreaModAnuTxt.Location = new System.Drawing.Point(482, 141);
            this.fechaCreaModAnuTxt.Margin = new System.Windows.Forms.Padding(2);
            this.fechaCreaModAnuTxt.Name = "fechaCreaModAnuTxt";
            this.fechaCreaModAnuTxt.Size = new System.Drawing.Size(151, 20);
            this.fechaCreaModAnuTxt.TabIndex = 7;
            // 
            // codUsuarioTxt
            // 
            this.codUsuarioTxt.AnimateReadOnly = false;
            this.codUsuarioTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.codUsuarioTxt.Depth = 0;
            this.codUsuarioTxt.Enabled = false;
            this.codUsuarioTxt.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.codUsuarioTxt.LeadingIcon = null;
            this.codUsuarioTxt.Location = new System.Drawing.Point(166, 94);
            this.codUsuarioTxt.Margin = new System.Windows.Forms.Padding(2);
            this.codUsuarioTxt.MaxLength = 50;
            this.codUsuarioTxt.MouseState = MaterialSkin.MouseState.OUT;
            this.codUsuarioTxt.Multiline = false;
            this.codUsuarioTxt.Name = "codUsuarioTxt";
            this.codUsuarioTxt.Size = new System.Drawing.Size(191, 36);
            this.codUsuarioTxt.TabIndex = 6;
            this.codUsuarioTxt.Text = "";
            this.codUsuarioTxt.TrailingIcon = null;
            this.codUsuarioTxt.UseTallSize = false;
            // 
            // codFabricanteTxt
            // 
            this.codFabricanteTxt.AnimateReadOnly = false;
            this.codFabricanteTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.codFabricanteTxt.Depth = 0;
            this.codFabricanteTxt.Enabled = false;
            this.codFabricanteTxt.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.codFabricanteTxt.LeadingIcon = null;
            this.codFabricanteTxt.Location = new System.Drawing.Point(166, 33);
            this.codFabricanteTxt.Margin = new System.Windows.Forms.Padding(2);
            this.codFabricanteTxt.MaxLength = 50;
            this.codFabricanteTxt.MouseState = MaterialSkin.MouseState.OUT;
            this.codFabricanteTxt.Multiline = false;
            this.codFabricanteTxt.Name = "codFabricanteTxt";
            this.codFabricanteTxt.Size = new System.Drawing.Size(191, 36);
            this.codFabricanteTxt.TabIndex = 4;
            this.codFabricanteTxt.Text = "";
            this.codFabricanteTxt.TrailingIcon = null;
            this.codFabricanteTxt.UseTallSize = false;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.Location = new System.Drawing.Point(396, 101);
            this.materialLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(292, 19);
            this.materialLabel4.TabIndex = 3;
            this.materialLabel4.Text = "Fecha Creacion/Modificacion/Anulacion:";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(27, 96);
            this.materialLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(116, 19);
            this.materialLabel3.TabIndex = 2;
            this.materialLabel3.Text = "Cod.  de Usuario";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(384, 38);
            this.materialLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(63, 19);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "Persona:";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(27, 36);
            this.materialLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(116, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Cod. Fabricante:";
            // 
            // Fabricante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 494);
            this.Controls.Add(this.materialCard1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Fabricante";
            this.Padding = new System.Windows.Forms.Padding(2, 51, 2, 2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fabricantes";
            this.Load += new System.EventHandler(this.Fabricante_Load);
            this.materialCard1.ResumeLayout(false);
            this.materialCard1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private System.Windows.Forms.DateTimePicker fechaCreaModAnuTxt;
        private MaterialSkin.Controls.MaterialTextBox codUsuarioTxt;
        private MaterialSkin.Controls.MaterialTextBox codFabricanteTxt;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialButton cancelarBtn;
        private MaterialSkin.Controls.MaterialButton guardarBtn;
        private MaterialSkin.Controls.MaterialListView tblFabricantes;
        private MaterialSkin.Controls.MaterialButton eliminarBtn;
        private MaterialSkin.Controls.MaterialButton modificarBtn;
        private MaterialSkin.Controls.MaterialButton buscarBtn;
        private MaterialSkin.Controls.MaterialComboBox cboPersona;
    }
}