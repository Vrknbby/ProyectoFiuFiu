
namespace PruebaUIs
{
    partial class Familia_Articulos
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
            this.tblFamiliaArticulo = new MaterialSkin.Controls.MaterialListView();
            this.btnEliminar = new MaterialSkin.Controls.MaterialButton();
            this.btnBuscar = new MaterialSkin.Controls.MaterialButton();
            this.btnModificar = new MaterialSkin.Controls.MaterialButton();
            this.btnAgregar = new MaterialSkin.Controls.MaterialButton();
            this.txtDesLinea = new MaterialSkin.Controls.MaterialTextBox();
            this.txtDesCategoria = new MaterialSkin.Controls.MaterialTextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtCodLinea = new MaterialSkin.Controls.MaterialTextBox();
            this.txtCodUsuario = new MaterialSkin.Controls.MaterialTextBox();
            this.txtCodCategoria = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.btnCancelar = new MaterialSkin.Controls.MaterialButton();
            this.materialCard1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.btnCancelar);
            this.materialCard1.Controls.Add(this.tblFamiliaArticulo);
            this.materialCard1.Controls.Add(this.btnEliminar);
            this.materialCard1.Controls.Add(this.btnBuscar);
            this.materialCard1.Controls.Add(this.btnModificar);
            this.materialCard1.Controls.Add(this.btnAgregar);
            this.materialCard1.Controls.Add(this.txtDesLinea);
            this.materialCard1.Controls.Add(this.txtDesCategoria);
            this.materialCard1.Controls.Add(this.dateTimePicker1);
            this.materialCard1.Controls.Add(this.txtCodLinea);
            this.materialCard1.Controls.Add(this.txtCodUsuario);
            this.materialCard1.Controls.Add(this.txtCodCategoria);
            this.materialCard1.Controls.Add(this.materialLabel6);
            this.materialCard1.Controls.Add(this.materialLabel5);
            this.materialCard1.Controls.Add(this.materialLabel4);
            this.materialCard1.Controls.Add(this.materialLabel3);
            this.materialCard1.Controls.Add(this.materialLabel2);
            this.materialCard1.Controls.Add(this.materialLabel1);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(2, 68);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(866, 435);
            this.materialCard1.TabIndex = 0;
            // 
            // tblFamiliaArticulo
            // 
            this.tblFamiliaArticulo.AutoSizeTable = false;
            this.tblFamiliaArticulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tblFamiliaArticulo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tblFamiliaArticulo.Depth = 0;
            this.tblFamiliaArticulo.FullRowSelect = true;
            this.tblFamiliaArticulo.HideSelection = false;
            this.tblFamiliaArticulo.Location = new System.Drawing.Point(21, 226);
            this.tblFamiliaArticulo.MinimumSize = new System.Drawing.Size(200, 100);
            this.tblFamiliaArticulo.MouseLocation = new System.Drawing.Point(-1, -1);
            this.tblFamiliaArticulo.MouseState = MaterialSkin.MouseState.OUT;
            this.tblFamiliaArticulo.Name = "tblFamiliaArticulo";
            this.tblFamiliaArticulo.OwnerDraw = true;
            this.tblFamiliaArticulo.Size = new System.Drawing.Size(828, 192);
            this.tblFamiliaArticulo.TabIndex = 26;
            this.tblFamiliaArticulo.UseCompatibleStateImageBehavior = false;
            this.tblFamiliaArticulo.View = System.Windows.Forms.View.Details;
            this.tblFamiliaArticulo.SelectedIndexChanged += new System.EventHandler(this.tblFamiliaArticulo_SelectedIndexChanged);
            // 
            // btnEliminar
            // 
            this.btnEliminar.AutoSize = false;
            this.btnEliminar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEliminar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnEliminar.Depth = 0;
            this.btnEliminar.HighEmphasis = true;
            this.btnEliminar.Icon = null;
            this.btnEliminar.Location = new System.Drawing.Point(675, 159);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnEliminar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnEliminar.Size = new System.Drawing.Size(158, 36);
            this.btnEliminar.TabIndex = 25;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnEliminar.UseAccentColor = false;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.AutoSize = false;
            this.btnBuscar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBuscar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnBuscar.Depth = 0;
            this.btnBuscar.HighEmphasis = true;
            this.btnBuscar.Icon = null;
            this.btnBuscar.Location = new System.Drawing.Point(675, 111);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBuscar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnBuscar.Size = new System.Drawing.Size(158, 36);
            this.btnBuscar.TabIndex = 24;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnBuscar.UseAccentColor = false;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.AutoSize = false;
            this.btnModificar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnModificar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnModificar.Depth = 0;
            this.btnModificar.HighEmphasis = true;
            this.btnModificar.Icon = null;
            this.btnModificar.Location = new System.Drawing.Point(675, 63);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnModificar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnModificar.Size = new System.Drawing.Size(158, 36);
            this.btnModificar.TabIndex = 23;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnModificar.UseAccentColor = false;
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.AutoSize = false;
            this.btnAgregar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAgregar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAgregar.Depth = 0;
            this.btnAgregar.HighEmphasis = true;
            this.btnAgregar.Icon = null;
            this.btnAgregar.Location = new System.Drawing.Point(675, 18);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAgregar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAgregar.Size = new System.Drawing.Size(158, 36);
            this.btnAgregar.TabIndex = 22;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAgregar.UseAccentColor = false;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtDesLinea
            // 
            this.txtDesLinea.AnimateReadOnly = false;
            this.txtDesLinea.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDesLinea.Depth = 0;
            this.txtDesLinea.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtDesLinea.LeadingIcon = null;
            this.txtDesLinea.Location = new System.Drawing.Point(338, 136);
            this.txtDesLinea.MaxLength = 50;
            this.txtDesLinea.MouseState = MaterialSkin.MouseState.OUT;
            this.txtDesLinea.Multiline = false;
            this.txtDesLinea.Name = "txtDesLinea";
            this.txtDesLinea.Size = new System.Drawing.Size(288, 36);
            this.txtDesLinea.TabIndex = 11;
            this.txtDesLinea.Text = "";
            this.txtDesLinea.TrailingIcon = null;
            this.txtDesLinea.UseTallSize = false;
            // 
            // txtDesCategoria
            // 
            this.txtDesCategoria.AnimateReadOnly = false;
            this.txtDesCategoria.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDesCategoria.Depth = 0;
            this.txtDesCategoria.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtDesCategoria.LeadingIcon = null;
            this.txtDesCategoria.Location = new System.Drawing.Point(21, 136);
            this.txtDesCategoria.MaxLength = 50;
            this.txtDesCategoria.MouseState = MaterialSkin.MouseState.OUT;
            this.txtDesCategoria.Multiline = false;
            this.txtDesCategoria.Name = "txtDesCategoria";
            this.txtDesCategoria.Size = new System.Drawing.Size(288, 36);
            this.txtDesCategoria.TabIndex = 10;
            this.txtDesCategoria.Text = "";
            this.txtDesCategoria.TrailingIcon = null;
            this.txtDesCategoria.UseTallSize = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(388, 88);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // txtCodLinea
            // 
            this.txtCodLinea.AnimateReadOnly = false;
            this.txtCodLinea.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCodLinea.Depth = 0;
            this.txtCodLinea.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtCodLinea.LeadingIcon = null;
            this.txtCodLinea.Location = new System.Drawing.Point(100, 58);
            this.txtCodLinea.MaxLength = 50;
            this.txtCodLinea.MouseState = MaterialSkin.MouseState.OUT;
            this.txtCodLinea.Multiline = false;
            this.txtCodLinea.Name = "txtCodLinea";
            this.txtCodLinea.Size = new System.Drawing.Size(209, 36);
            this.txtCodLinea.TabIndex = 8;
            this.txtCodLinea.Text = "";
            this.txtCodLinea.TrailingIcon = null;
            this.txtCodLinea.UseTallSize = false;
            // 
            // txtCodUsuario
            // 
            this.txtCodUsuario.AnimateReadOnly = false;
            this.txtCodUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCodUsuario.Depth = 0;
            this.txtCodUsuario.Enabled = false;
            this.txtCodUsuario.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtCodUsuario.LeadingIcon = null;
            this.txtCodUsuario.Location = new System.Drawing.Point(431, 9);
            this.txtCodUsuario.MaxLength = 50;
            this.txtCodUsuario.MouseState = MaterialSkin.MouseState.OUT;
            this.txtCodUsuario.Multiline = false;
            this.txtCodUsuario.Name = "txtCodUsuario";
            this.txtCodUsuario.Size = new System.Drawing.Size(183, 36);
            this.txtCodUsuario.TabIndex = 7;
            this.txtCodUsuario.Text = "";
            this.txtCodUsuario.TrailingIcon = null;
            this.txtCodUsuario.UseTallSize = false;
            // 
            // txtCodCategoria
            // 
            this.txtCodCategoria.AnimateReadOnly = false;
            this.txtCodCategoria.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCodCategoria.Depth = 0;
            this.txtCodCategoria.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtCodCategoria.LeadingIcon = null;
            this.txtCodCategoria.Location = new System.Drawing.Point(126, 9);
            this.txtCodCategoria.MaxLength = 50;
            this.txtCodCategoria.MouseState = MaterialSkin.MouseState.OUT;
            this.txtCodCategoria.Multiline = false;
            this.txtCodCategoria.Name = "txtCodCategoria";
            this.txtCodCategoria.Size = new System.Drawing.Size(183, 36);
            this.txtCodCategoria.TabIndex = 6;
            this.txtCodCategoria.Text = "";
            this.txtCodCategoria.TrailingIcon = null;
            this.txtCodCategoria.UseTallSize = false;
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel6.Location = new System.Drawing.Point(338, 66);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(288, 19);
            this.materialLabel6.TabIndex = 5;
            this.materialLabel6.Text = "Fecha Creacion/Modificacion/Anulacion";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.Location = new System.Drawing.Point(338, 18);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(87, 19);
            this.materialLabel5.TabIndex = 4;
            this.materialLabel5.Text = "Cod Usuario";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.Location = new System.Drawing.Point(18, 111);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(156, 19);
            this.materialLabel4.TabIndex = 3;
            this.materialLabel4.Text = "Descripcion Categoria";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(22, 63);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(72, 19);
            this.materialLabel3.TabIndex = 2;
            this.materialLabel3.Text = "Cod Linea";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(335, 111);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(127, 19);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "Descripcion Linea";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(18, 18);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(101, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Cod Categoria";
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = false;
            this.btnCancelar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancelar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancelar.Depth = 0;
            this.btnCancelar.HighEmphasis = true;
            this.btnCancelar.Icon = null;
            this.btnCancelar.Location = new System.Drawing.Point(25, 181);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancelar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancelar.Size = new System.Drawing.Size(158, 36);
            this.btnCancelar.TabIndex = 27;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCancelar.UseAccentColor = false;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // Familia_Articulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 504);
            this.Controls.Add(this.materialCard1);
            this.Name = "Familia_Articulos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Familia Articulos";
            this.Load += new System.EventHandler(this.Familia_Articulos_Load);
            this.materialCard1.ResumeLayout(false);
            this.materialCard1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialTextBox txtDesLinea;
        private MaterialSkin.Controls.MaterialTextBox txtDesCategoria;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private MaterialSkin.Controls.MaterialTextBox txtCodLinea;
        private MaterialSkin.Controls.MaterialTextBox txtCodUsuario;
        private MaterialSkin.Controls.MaterialTextBox txtCodCategoria;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialListView tblFamiliaArticulo;
        private MaterialSkin.Controls.MaterialButton btnEliminar;
        private MaterialSkin.Controls.MaterialButton btnBuscar;
        private MaterialSkin.Controls.MaterialButton btnModificar;
        private MaterialSkin.Controls.MaterialButton btnAgregar;
        private MaterialSkin.Controls.MaterialButton btnCancelar;
    }
}