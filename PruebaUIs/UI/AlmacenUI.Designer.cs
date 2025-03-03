
namespace PruebaUIs.UI
{
    partial class AlmacenUI
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
            this.gbCanje = new System.Windows.Forms.GroupBox();
            this.rbCanjeSI = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbCanjeNO = new MaterialSkin.Controls.MaterialRadioButton();
            this.gbAmbienteControlado = new System.Windows.Forms.GroupBox();
            this.rbClimaSI = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbClimaNO = new MaterialSkin.Controls.MaterialRadioButton();
            this.cbxLocacion = new MaterialSkin.Controls.MaterialComboBox();
            this.tblAlmacenes = new MaterialSkin.Controls.MaterialListView();
            this.btnEliminar = new MaterialSkin.Controls.MaterialButton();
            this.btnCancelar = new MaterialSkin.Controls.MaterialButton();
            this.btnModificar = new MaterialSkin.Controls.MaterialButton();
            this.btnGuardar = new MaterialSkin.Controls.MaterialButton();
            this.btnBuscar = new MaterialSkin.Controls.MaterialButton();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.dateCreacion = new System.Windows.Forms.DateTimePicker();
            this.dateModificacion = new System.Windows.Forms.DateTimePicker();
            this.txtSuperficieAlmacen = new MaterialSkin.Controls.MaterialTextBox();
            this.txtDescripcion = new MaterialSkin.Controls.MaterialTextBox();
            this.txtAlturaAlmacen = new MaterialSkin.Controls.MaterialTextBox();
            this.txtEncargado = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel11 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialCard1.SuspendLayout();
            this.gbCanje.SuspendLayout();
            this.gbAmbienteControlado.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.gbCanje);
            this.materialCard1.Controls.Add(this.gbAmbienteControlado);
            this.materialCard1.Controls.Add(this.cbxLocacion);
            this.materialCard1.Controls.Add(this.tblAlmacenes);
            this.materialCard1.Controls.Add(this.btnEliminar);
            this.materialCard1.Controls.Add(this.btnCancelar);
            this.materialCard1.Controls.Add(this.btnModificar);
            this.materialCard1.Controls.Add(this.btnGuardar);
            this.materialCard1.Controls.Add(this.btnBuscar);
            this.materialCard1.Controls.Add(this.materialDivider1);
            this.materialCard1.Controls.Add(this.dateCreacion);
            this.materialCard1.Controls.Add(this.dateModificacion);
            this.materialCard1.Controls.Add(this.txtSuperficieAlmacen);
            this.materialCard1.Controls.Add(this.txtDescripcion);
            this.materialCard1.Controls.Add(this.txtAlturaAlmacen);
            this.materialCard1.Controls.Add(this.txtEncargado);
            this.materialCard1.Controls.Add(this.materialLabel11);
            this.materialCard1.Controls.Add(this.materialLabel6);
            this.materialCard1.Controls.Add(this.materialLabel5);
            this.materialCard1.Controls.Add(this.materialLabel4);
            this.materialCard1.Controls.Add(this.materialLabel3);
            this.materialCard1.Controls.Add(this.materialLabel2);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(0, 64);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(1412, 576);
            this.materialCard1.TabIndex = 1;
            // 
            // gbCanje
            // 
            this.gbCanje.Controls.Add(this.rbCanjeSI);
            this.gbCanje.Controls.Add(this.rbCanjeNO);
            this.gbCanje.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCanje.Location = new System.Drawing.Point(907, 208);
            this.gbCanje.Name = "gbCanje";
            this.gbCanje.Size = new System.Drawing.Size(334, 75);
            this.gbCanje.TabIndex = 47;
            this.gbCanje.TabStop = false;
            this.gbCanje.Text = "Almacen de canje";
            // 
            // rbCanjeSI
            // 
            this.rbCanjeSI.AutoSize = true;
            this.rbCanjeSI.Depth = 0;
            this.rbCanjeSI.Location = new System.Drawing.Point(58, 22);
            this.rbCanjeSI.Margin = new System.Windows.Forms.Padding(0);
            this.rbCanjeSI.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbCanjeSI.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbCanjeSI.Name = "rbCanjeSI";
            this.rbCanjeSI.Ripple = true;
            this.rbCanjeSI.Size = new System.Drawing.Size(49, 37);
            this.rbCanjeSI.TabIndex = 21;
            this.rbCanjeSI.TabStop = true;
            this.rbCanjeSI.Text = "Si";
            this.rbCanjeSI.UseVisualStyleBackColor = true;
            // 
            // rbCanjeNO
            // 
            this.rbCanjeNO.AutoSize = true;
            this.rbCanjeNO.Depth = 0;
            this.rbCanjeNO.Location = new System.Drawing.Point(218, 22);
            this.rbCanjeNO.Margin = new System.Windows.Forms.Padding(0);
            this.rbCanjeNO.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbCanjeNO.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbCanjeNO.Name = "rbCanjeNO";
            this.rbCanjeNO.Ripple = true;
            this.rbCanjeNO.Size = new System.Drawing.Size(55, 37);
            this.rbCanjeNO.TabIndex = 22;
            this.rbCanjeNO.TabStop = true;
            this.rbCanjeNO.Text = "No";
            this.rbCanjeNO.UseVisualStyleBackColor = true;
            // 
            // gbAmbienteControlado
            // 
            this.gbAmbienteControlado.Controls.Add(this.rbClimaSI);
            this.gbAmbienteControlado.Controls.Add(this.rbClimaNO);
            this.gbAmbienteControlado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAmbienteControlado.Location = new System.Drawing.Point(907, 107);
            this.gbAmbienteControlado.Name = "gbAmbienteControlado";
            this.gbAmbienteControlado.Size = new System.Drawing.Size(334, 80);
            this.gbAmbienteControlado.TabIndex = 46;
            this.gbAmbienteControlado.TabStop = false;
            this.gbAmbienteControlado.Text = "Ambiente con clima controlado";
            // 
            // rbClimaSI
            // 
            this.rbClimaSI.AutoSize = true;
            this.rbClimaSI.Depth = 0;
            this.rbClimaSI.Location = new System.Drawing.Point(58, 22);
            this.rbClimaSI.Margin = new System.Windows.Forms.Padding(0);
            this.rbClimaSI.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbClimaSI.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbClimaSI.Name = "rbClimaSI";
            this.rbClimaSI.Ripple = true;
            this.rbClimaSI.Size = new System.Drawing.Size(49, 37);
            this.rbClimaSI.TabIndex = 23;
            this.rbClimaSI.TabStop = true;
            this.rbClimaSI.Text = "Si";
            this.rbClimaSI.UseVisualStyleBackColor = true;
            // 
            // rbClimaNO
            // 
            this.rbClimaNO.AutoSize = true;
            this.rbClimaNO.Depth = 0;
            this.rbClimaNO.Location = new System.Drawing.Point(218, 22);
            this.rbClimaNO.Margin = new System.Windows.Forms.Padding(0);
            this.rbClimaNO.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbClimaNO.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbClimaNO.Name = "rbClimaNO";
            this.rbClimaNO.Ripple = true;
            this.rbClimaNO.Size = new System.Drawing.Size(55, 37);
            this.rbClimaNO.TabIndex = 24;
            this.rbClimaNO.TabStop = true;
            this.rbClimaNO.Text = "No";
            this.rbClimaNO.UseVisualStyleBackColor = true;
            // 
            // cbxLocacion
            // 
            this.cbxLocacion.AutoResize = false;
            this.cbxLocacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbxLocacion.Depth = 0;
            this.cbxLocacion.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbxLocacion.DropDownHeight = 174;
            this.cbxLocacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLocacion.DropDownWidth = 121;
            this.cbxLocacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbxLocacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbxLocacion.FormattingEnabled = true;
            this.cbxLocacion.IntegralHeight = false;
            this.cbxLocacion.ItemHeight = 43;
            this.cbxLocacion.Location = new System.Drawing.Point(599, 199);
            this.cbxLocacion.MaxDropDownItems = 4;
            this.cbxLocacion.MouseState = MaterialSkin.MouseState.OUT;
            this.cbxLocacion.Name = "cbxLocacion";
            this.cbxLocacion.Size = new System.Drawing.Size(295, 49);
            this.cbxLocacion.StartIndex = 0;
            this.cbxLocacion.TabIndex = 45;
            // 
            // tblAlmacenes
            // 
            this.tblAlmacenes.AutoSizeTable = false;
            this.tblAlmacenes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tblAlmacenes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tblAlmacenes.Depth = 0;
            this.tblAlmacenes.FullRowSelect = true;
            this.tblAlmacenes.HideSelection = false;
            this.tblAlmacenes.Location = new System.Drawing.Point(17, 317);
            this.tblAlmacenes.MinimumSize = new System.Drawing.Size(200, 100);
            this.tblAlmacenes.MouseLocation = new System.Drawing.Point(-1, -1);
            this.tblAlmacenes.MouseState = MaterialSkin.MouseState.OUT;
            this.tblAlmacenes.Name = "tblAlmacenes";
            this.tblAlmacenes.OwnerDraw = true;
            this.tblAlmacenes.Size = new System.Drawing.Size(1377, 248);
            this.tblAlmacenes.TabIndex = 44;
            this.tblAlmacenes.UseCompatibleStateImageBehavior = false;
            this.tblAlmacenes.View = System.Windows.Forms.View.Details;
            this.tblAlmacenes.SelectedIndexChanged += new System.EventHandler(this.tblAlmacenes_SelectedIndexChanged);
            // 
            // btnEliminar
            // 
            this.btnEliminar.AutoSize = false;
            this.btnEliminar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEliminar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnEliminar.Depth = 0;
            this.btnEliminar.HighEmphasis = true;
            this.btnEliminar.Icon = null;
            this.btnEliminar.Location = new System.Drawing.Point(1248, 247);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnEliminar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnEliminar.Size = new System.Drawing.Size(139, 36);
            this.btnEliminar.TabIndex = 43;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnEliminar.UseAccentColor = false;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = false;
            this.btnCancelar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancelar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancelar.Depth = 0;
            this.btnCancelar.HighEmphasis = true;
            this.btnCancelar.Icon = null;
            this.btnCancelar.Location = new System.Drawing.Point(1248, 199);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancelar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancelar.Size = new System.Drawing.Size(139, 36);
            this.btnCancelar.TabIndex = 42;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCancelar.UseAccentColor = false;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.AutoSize = false;
            this.btnModificar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnModificar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnModificar.Depth = 0;
            this.btnModificar.HighEmphasis = true;
            this.btnModificar.Icon = null;
            this.btnModificar.Location = new System.Drawing.Point(1248, 151);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnModificar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnModificar.Size = new System.Drawing.Size(139, 36);
            this.btnModificar.TabIndex = 41;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnModificar.UseAccentColor = false;
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.AutoSize = false;
            this.btnGuardar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGuardar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnGuardar.Depth = 0;
            this.btnGuardar.HighEmphasis = true;
            this.btnGuardar.Icon = null;
            this.btnGuardar.Location = new System.Drawing.Point(1248, 100);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnGuardar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnGuardar.Size = new System.Drawing.Size(139, 36);
            this.btnGuardar.TabIndex = 40;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnGuardar.UseAccentColor = false;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.AutoSize = false;
            this.btnBuscar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBuscar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnBuscar.Depth = 0;
            this.btnBuscar.HighEmphasis = true;
            this.btnBuscar.Icon = null;
            this.btnBuscar.Location = new System.Drawing.Point(1238, 17);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBuscar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnBuscar.Size = new System.Drawing.Size(156, 36);
            this.btnBuscar.TabIndex = 39;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnBuscar.UseAccentColor = false;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(0, 70);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(1406, 23);
            this.materialDivider1.TabIndex = 27;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // dateCreacion
            // 
            this.dateCreacion.Location = new System.Drawing.Point(980, 20);
            this.dateCreacion.Name = "dateCreacion";
            this.dateCreacion.Size = new System.Drawing.Size(200, 20);
            this.dateCreacion.TabIndex = 26;
            // 
            // dateModificacion
            // 
            this.dateModificacion.Enabled = false;
            this.dateModificacion.Location = new System.Drawing.Point(0, 0);
            this.dateModificacion.Name = "dateModificacion";
            this.dateModificacion.Size = new System.Drawing.Size(200, 20);
            this.dateModificacion.TabIndex = 25;
            // 
            // txtSuperficieAlmacen
            // 
            this.txtSuperficieAlmacen.AnimateReadOnly = false;
            this.txtSuperficieAlmacen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSuperficieAlmacen.Depth = 0;
            this.txtSuperficieAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtSuperficieAlmacen.LeadingIcon = null;
            this.txtSuperficieAlmacen.Location = new System.Drawing.Point(169, 201);
            this.txtSuperficieAlmacen.MaxLength = 50;
            this.txtSuperficieAlmacen.MouseState = MaterialSkin.MouseState.OUT;
            this.txtSuperficieAlmacen.Multiline = false;
            this.txtSuperficieAlmacen.Name = "txtSuperficieAlmacen";
            this.txtSuperficieAlmacen.Size = new System.Drawing.Size(274, 36);
            this.txtSuperficieAlmacen.TabIndex = 17;
            this.txtSuperficieAlmacen.Text = "";
            this.txtSuperficieAlmacen.TrailingIcon = null;
            this.txtSuperficieAlmacen.UseTallSize = false;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.AnimateReadOnly = false;
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescripcion.Depth = 0;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtDescripcion.LeadingIcon = null;
            this.txtDescripcion.Location = new System.Drawing.Point(399, 17);
            this.txtDescripcion.MaxLength = 50;
            this.txtDescripcion.MouseState = MaterialSkin.MouseState.OUT;
            this.txtDescripcion.Multiline = false;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(229, 36);
            this.txtDescripcion.TabIndex = 16;
            this.txtDescripcion.Text = "";
            this.txtDescripcion.TrailingIcon = null;
            this.txtDescripcion.UseTallSize = false;
            // 
            // txtAlturaAlmacen
            // 
            this.txtAlturaAlmacen.AnimateReadOnly = false;
            this.txtAlturaAlmacen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAlturaAlmacen.Depth = 0;
            this.txtAlturaAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtAlturaAlmacen.LeadingIcon = null;
            this.txtAlturaAlmacen.Location = new System.Drawing.Point(599, 118);
            this.txtAlturaAlmacen.MaxLength = 50;
            this.txtAlturaAlmacen.MouseState = MaterialSkin.MouseState.OUT;
            this.txtAlturaAlmacen.Multiline = false;
            this.txtAlturaAlmacen.Name = "txtAlturaAlmacen";
            this.txtAlturaAlmacen.Size = new System.Drawing.Size(295, 36);
            this.txtAlturaAlmacen.TabIndex = 15;
            this.txtAlturaAlmacen.Text = "";
            this.txtAlturaAlmacen.TrailingIcon = null;
            this.txtAlturaAlmacen.UseTallSize = false;
            // 
            // txtEncargado
            // 
            this.txtEncargado.AnimateReadOnly = false;
            this.txtEncargado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEncargado.Depth = 0;
            this.txtEncargado.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtEncargado.LeadingIcon = null;
            this.txtEncargado.Location = new System.Drawing.Point(169, 118);
            this.txtEncargado.MaxLength = 50;
            this.txtEncargado.MouseState = MaterialSkin.MouseState.OUT;
            this.txtEncargado.Multiline = false;
            this.txtEncargado.Name = "txtEncargado";
            this.txtEncargado.Size = new System.Drawing.Size(274, 36);
            this.txtEncargado.TabIndex = 14;
            this.txtEncargado.Text = "";
            this.txtEncargado.TrailingIcon = null;
            this.txtEncargado.UseTallSize = false;
            // 
            // materialLabel11
            // 
            this.materialLabel11.AutoSize = true;
            this.materialLabel11.Depth = 0;
            this.materialLabel11.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel11.Location = new System.Drawing.Point(257, 24);
            this.materialLabel11.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel11.Name = "materialLabel11";
            this.materialLabel11.Size = new System.Drawing.Size(123, 19);
            this.materialLabel11.TabIndex = 10;
            this.materialLabel11.Text = "Nombre Almacen";
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel6.Location = new System.Drawing.Point(17, 204);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(138, 19);
            this.materialLabel6.TabIndex = 5;
            this.materialLabel6.Text = "Superficie Almacen";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.Location = new System.Drawing.Point(470, 125);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(109, 19);
            this.materialLabel5.TabIndex = 4;
            this.materialLabel5.Text = "Altura Almacen";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.Location = new System.Drawing.Point(17, 125);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(137, 19);
            this.materialLabel4.TabIndex = 3;
            this.materialLabel4.Text = "Nombre Encargado";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(484, 208);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(66, 19);
            this.materialLabel3.TabIndex = 2;
            this.materialLabel3.Text = "Locacion";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(678, 24);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(238, 19);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "Fecha de Creacion de la Locacion";
            // 
            // AlmacenUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1413, 648);
            this.Controls.Add(this.materialCard1);
            this.Name = "AlmacenUI";
            this.Text = "Almacen";
            this.materialCard1.ResumeLayout(false);
            this.materialCard1.PerformLayout();
            this.gbCanje.ResumeLayout(false);
            this.gbCanje.PerformLayout();
            this.gbAmbienteControlado.ResumeLayout(false);
            this.gbAmbienteControlado.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private System.Windows.Forms.GroupBox gbCanje;
        private MaterialSkin.Controls.MaterialRadioButton rbCanjeSI;
        private MaterialSkin.Controls.MaterialRadioButton rbCanjeNO;
        private System.Windows.Forms.GroupBox gbAmbienteControlado;
        private MaterialSkin.Controls.MaterialRadioButton rbClimaSI;
        private MaterialSkin.Controls.MaterialRadioButton rbClimaNO;
        private MaterialSkin.Controls.MaterialComboBox cbxLocacion;
        private MaterialSkin.Controls.MaterialListView tblAlmacenes;
        private MaterialSkin.Controls.MaterialButton btnEliminar;
        private MaterialSkin.Controls.MaterialButton btnCancelar;
        private MaterialSkin.Controls.MaterialButton btnModificar;
        private MaterialSkin.Controls.MaterialButton btnGuardar;
        private MaterialSkin.Controls.MaterialButton btnBuscar;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private System.Windows.Forms.DateTimePicker dateCreacion;
        private System.Windows.Forms.DateTimePicker dateModificacion;
        private MaterialSkin.Controls.MaterialTextBox txtSuperficieAlmacen;
        private MaterialSkin.Controls.MaterialTextBox txtDescripcion;
        private MaterialSkin.Controls.MaterialTextBox txtAlturaAlmacen;
        private MaterialSkin.Controls.MaterialTextBox txtEncargado;
        private MaterialSkin.Controls.MaterialLabel materialLabel11;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
    }
}