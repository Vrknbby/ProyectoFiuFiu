
namespace PruebaUIs
{
    partial class Vendedores
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
            this.buscarBtn = new MaterialSkin.Controls.MaterialButton();
            this.tblVendedores = new MaterialSkin.Controls.MaterialListView();
            this.eliminarBtn = new MaterialSkin.Controls.MaterialButton();
            this.cancelarBtn = new MaterialSkin.Controls.MaterialButton();
            this.modificarBtn = new MaterialSkin.Controls.MaterialButton();
            this.guardarBtn = new MaterialSkin.Controls.MaterialButton();
            this.fechaCreaModAnuTxt = new System.Windows.Forms.DateTimePicker();
            this.rbtInhabilitadoNo = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbtInhabilitadoSi = new MaterialSkin.Controls.MaterialRadioButton();
            this.codUserTxt = new MaterialSkin.Controls.MaterialTextBox();
            this.codPersonaTxt = new MaterialSkin.Controls.MaterialTextBox();
            this.codVendedorTxt = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
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
            this.materialCard1.Controls.Add(this.buscarBtn);
            this.materialCard1.Controls.Add(this.tblVendedores);
            this.materialCard1.Controls.Add(this.eliminarBtn);
            this.materialCard1.Controls.Add(this.cancelarBtn);
            this.materialCard1.Controls.Add(this.modificarBtn);
            this.materialCard1.Controls.Add(this.guardarBtn);
            this.materialCard1.Controls.Add(this.fechaCreaModAnuTxt);
            this.materialCard1.Controls.Add(this.rbtInhabilitadoNo);
            this.materialCard1.Controls.Add(this.rbtInhabilitadoSi);
            this.materialCard1.Controls.Add(this.codUserTxt);
            this.materialCard1.Controls.Add(this.codPersonaTxt);
            this.materialCard1.Controls.Add(this.codVendedorTxt);
            this.materialCard1.Controls.Add(this.materialLabel5);
            this.materialCard1.Controls.Add(this.materialLabel4);
            this.materialCard1.Controls.Add(this.materialLabel3);
            this.materialCard1.Controls.Add(this.materialLabel2);
            this.materialCard1.Controls.Add(this.materialLabel1);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(-2, 63);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(962, 548);
            this.materialCard1.TabIndex = 1;
            // 
            // buscarBtn
            // 
            this.buscarBtn.AutoSize = false;
            this.buscarBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buscarBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buscarBtn.Depth = 0;
            this.buscarBtn.HighEmphasis = true;
            this.buscarBtn.Icon = null;
            this.buscarBtn.Location = new System.Drawing.Point(779, 21);
            this.buscarBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buscarBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.buscarBtn.Name = "buscarBtn";
            this.buscarBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buscarBtn.Size = new System.Drawing.Size(139, 36);
            this.buscarBtn.TabIndex = 49;
            this.buscarBtn.Text = "Buscar";
            this.buscarBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buscarBtn.UseAccentColor = false;
            this.buscarBtn.UseVisualStyleBackColor = true;
            this.buscarBtn.Click += new System.EventHandler(this.buscarBtn_Click);
            // 
            // tblVendedores
            // 
            this.tblVendedores.AutoSizeTable = false;
            this.tblVendedores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tblVendedores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tblVendedores.Depth = 0;
            this.tblVendedores.FullRowSelect = true;
            this.tblVendedores.HideSelection = false;
            this.tblVendedores.Location = new System.Drawing.Point(23, 269);
            this.tblVendedores.MinimumSize = new System.Drawing.Size(200, 100);
            this.tblVendedores.MouseLocation = new System.Drawing.Point(-1, -1);
            this.tblVendedores.MouseState = MaterialSkin.MouseState.OUT;
            this.tblVendedores.Name = "tblVendedores";
            this.tblVendedores.OwnerDraw = true;
            this.tblVendedores.Size = new System.Drawing.Size(922, 262);
            this.tblVendedores.TabIndex = 48;
            this.tblVendedores.UseCompatibleStateImageBehavior = false;
            this.tblVendedores.View = System.Windows.Forms.View.Details;
            this.tblVendedores.SelectedIndexChanged += new System.EventHandler(this.tblVendedores_SelectedIndexChanged);
            // 
            // eliminarBtn
            // 
            this.eliminarBtn.AutoSize = false;
            this.eliminarBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.eliminarBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.eliminarBtn.Depth = 0;
            this.eliminarBtn.HighEmphasis = true;
            this.eliminarBtn.Icon = null;
            this.eliminarBtn.Location = new System.Drawing.Point(779, 216);
            this.eliminarBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.eliminarBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.eliminarBtn.Name = "eliminarBtn";
            this.eliminarBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.eliminarBtn.Size = new System.Drawing.Size(139, 36);
            this.eliminarBtn.TabIndex = 47;
            this.eliminarBtn.Text = "Eliminar";
            this.eliminarBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.eliminarBtn.UseAccentColor = false;
            this.eliminarBtn.UseVisualStyleBackColor = true;
            this.eliminarBtn.Click += new System.EventHandler(this.eliminarBtn_Click);
            // 
            // cancelarBtn
            // 
            this.cancelarBtn.AutoSize = false;
            this.cancelarBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cancelarBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.cancelarBtn.Depth = 0;
            this.cancelarBtn.HighEmphasis = true;
            this.cancelarBtn.Icon = null;
            this.cancelarBtn.Location = new System.Drawing.Point(779, 168);
            this.cancelarBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cancelarBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.cancelarBtn.Name = "cancelarBtn";
            this.cancelarBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.cancelarBtn.Size = new System.Drawing.Size(139, 36);
            this.cancelarBtn.TabIndex = 46;
            this.cancelarBtn.Text = "Cancelar";
            this.cancelarBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.cancelarBtn.UseAccentColor = false;
            this.cancelarBtn.UseVisualStyleBackColor = true;
            this.cancelarBtn.Click += new System.EventHandler(this.cancelarBtn_Click);
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
            this.modificarBtn.Location = new System.Drawing.Point(779, 120);
            this.modificarBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.modificarBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.modificarBtn.Name = "modificarBtn";
            this.modificarBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.modificarBtn.Size = new System.Drawing.Size(139, 36);
            this.modificarBtn.TabIndex = 45;
            this.modificarBtn.Text = "Modificar";
            this.modificarBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.modificarBtn.UseAccentColor = false;
            this.modificarBtn.UseVisualStyleBackColor = true;
            this.modificarBtn.Click += new System.EventHandler(this.modificarBtn_Click);
            // 
            // guardarBtn
            // 
            this.guardarBtn.AutoSize = false;
            this.guardarBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.guardarBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.guardarBtn.Depth = 0;
            this.guardarBtn.HighEmphasis = true;
            this.guardarBtn.Icon = null;
            this.guardarBtn.Location = new System.Drawing.Point(779, 69);
            this.guardarBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.guardarBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.guardarBtn.Name = "guardarBtn";
            this.guardarBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.guardarBtn.Size = new System.Drawing.Size(139, 36);
            this.guardarBtn.TabIndex = 44;
            this.guardarBtn.Text = "Guardar";
            this.guardarBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.guardarBtn.UseAccentColor = false;
            this.guardarBtn.UseVisualStyleBackColor = true;
            this.guardarBtn.Click += new System.EventHandler(this.guardarBtn_Click);
            // 
            // fechaCreaModAnuTxt
            // 
            this.fechaCreaModAnuTxt.Enabled = false;
            this.fechaCreaModAnuTxt.Location = new System.Drawing.Point(438, 154);
            this.fechaCreaModAnuTxt.Name = "fechaCreaModAnuTxt";
            this.fechaCreaModAnuTxt.Size = new System.Drawing.Size(200, 20);
            this.fechaCreaModAnuTxt.TabIndex = 25;
            // 
            // rbtInhabilitadoNo
            // 
            this.rbtInhabilitadoNo.AutoSize = true;
            this.rbtInhabilitadoNo.Depth = 0;
            this.rbtInhabilitadoNo.Location = new System.Drawing.Point(520, 62);
            this.rbtInhabilitadoNo.Margin = new System.Windows.Forms.Padding(0);
            this.rbtInhabilitadoNo.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbtInhabilitadoNo.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbtInhabilitadoNo.Name = "rbtInhabilitadoNo";
            this.rbtInhabilitadoNo.Ripple = true;
            this.rbtInhabilitadoNo.Size = new System.Drawing.Size(55, 37);
            this.rbtInhabilitadoNo.TabIndex = 24;
            this.rbtInhabilitadoNo.TabStop = true;
            this.rbtInhabilitadoNo.Text = "No";
            this.rbtInhabilitadoNo.UseVisualStyleBackColor = true;
            // 
            // rbtInhabilitadoSi
            // 
            this.rbtInhabilitadoSi.AutoSize = true;
            this.rbtInhabilitadoSi.Depth = 0;
            this.rbtInhabilitadoSi.Location = new System.Drawing.Point(438, 62);
            this.rbtInhabilitadoSi.Margin = new System.Windows.Forms.Padding(0);
            this.rbtInhabilitadoSi.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbtInhabilitadoSi.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbtInhabilitadoSi.Name = "rbtInhabilitadoSi";
            this.rbtInhabilitadoSi.Ripple = true;
            this.rbtInhabilitadoSi.Size = new System.Drawing.Size(49, 37);
            this.rbtInhabilitadoSi.TabIndex = 23;
            this.rbtInhabilitadoSi.TabStop = true;
            this.rbtInhabilitadoSi.Text = "Si";
            this.rbtInhabilitadoSi.UseVisualStyleBackColor = true;
            // 
            // codUserTxt
            // 
            this.codUserTxt.AnimateReadOnly = false;
            this.codUserTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.codUserTxt.Depth = 0;
            this.codUserTxt.Enabled = false;
            this.codUserTxt.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.codUserTxt.LeadingIcon = null;
            this.codUserTxt.Location = new System.Drawing.Point(152, 77);
            this.codUserTxt.MaxLength = 50;
            this.codUserTxt.MouseState = MaterialSkin.MouseState.OUT;
            this.codUserTxt.Multiline = false;
            this.codUserTxt.Name = "codUserTxt";
            this.codUserTxt.Size = new System.Drawing.Size(222, 36);
            this.codUserTxt.TabIndex = 7;
            this.codUserTxt.Text = "";
            this.codUserTxt.TrailingIcon = null;
            this.codUserTxt.UseTallSize = false;
            // 
            // codPersonaTxt
            // 
            this.codPersonaTxt.AnimateReadOnly = false;
            this.codPersonaTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.codPersonaTxt.Depth = 0;
            this.codPersonaTxt.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.codPersonaTxt.LeadingIcon = null;
            this.codPersonaTxt.Location = new System.Drawing.Point(152, 138);
            this.codPersonaTxt.MaxLength = 50;
            this.codPersonaTxt.MouseState = MaterialSkin.MouseState.OUT;
            this.codPersonaTxt.Multiline = false;
            this.codPersonaTxt.Name = "codPersonaTxt";
            this.codPersonaTxt.Size = new System.Drawing.Size(222, 36);
            this.codPersonaTxt.TabIndex = 6;
            this.codPersonaTxt.Text = "";
            this.codPersonaTxt.TrailingIcon = null;
            this.codPersonaTxt.UseTallSize = false;
            // 
            // codVendedorTxt
            // 
            this.codVendedorTxt.AnimateReadOnly = false;
            this.codVendedorTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.codVendedorTxt.Depth = 0;
            this.codVendedorTxt.Enabled = false;
            this.codVendedorTxt.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.codVendedorTxt.LeadingIcon = null;
            this.codVendedorTxt.Location = new System.Drawing.Point(165, 17);
            this.codVendedorTxt.MaxLength = 50;
            this.codVendedorTxt.MouseState = MaterialSkin.MouseState.OUT;
            this.codVendedorTxt.Multiline = false;
            this.codVendedorTxt.Name = "codVendedorTxt";
            this.codVendedorTxt.Size = new System.Drawing.Size(209, 36);
            this.codVendedorTxt.TabIndex = 5;
            this.codVendedorTxt.Text = "";
            this.codVendedorTxt.TrailingIcon = null;
            this.codVendedorTxt.UseTallSize = false;
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.Location = new System.Drawing.Point(435, 120);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(288, 19);
            this.materialLabel5.TabIndex = 4;
            this.materialLabel5.Text = "Fecha Creacion/Modificacion/Anulacion";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.Location = new System.Drawing.Point(435, 34);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(269, 19);
            this.materialLabel4.TabIndex = 3;
            this.materialLabel4.Text = "Inhabilitado para realizar Operaciones";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(20, 80);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(109, 19);
            this.materialLabel3.TabIndex = 2;
            this.materialLabel3.Text = "Codigo Usuario";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(20, 143);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(113, 19);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "Codigo Persona";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(20, 23);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(122, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Codigo Vendedor";
            // 
            // Vendedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 612);
            this.Controls.Add(this.materialCard1);
            this.Name = "Vendedores";
            this.Text = "Vendedores";
            this.Load += new System.EventHandler(this.Vendedores_Load);
            this.materialCard1.ResumeLayout(false);
            this.materialCard1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialListView tblVendedores;
        private MaterialSkin.Controls.MaterialButton eliminarBtn;
        private MaterialSkin.Controls.MaterialButton cancelarBtn;
        private MaterialSkin.Controls.MaterialButton modificarBtn;
        private MaterialSkin.Controls.MaterialButton guardarBtn;
        private System.Windows.Forms.DateTimePicker fechaCreaModAnuTxt;
        private MaterialSkin.Controls.MaterialRadioButton rbtInhabilitadoNo;
        private MaterialSkin.Controls.MaterialRadioButton rbtInhabilitadoSi;
        private MaterialSkin.Controls.MaterialTextBox codUserTxt;
        private MaterialSkin.Controls.MaterialTextBox codPersonaTxt;
        private MaterialSkin.Controls.MaterialTextBox codVendedorTxt;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialButton buscarBtn;
    }
}