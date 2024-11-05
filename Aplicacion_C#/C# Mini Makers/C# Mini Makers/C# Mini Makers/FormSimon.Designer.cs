namespace C__Mini_Makers
{
    partial class FormSimon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSimon));
            this.comboBoxFecha = new System.Windows.Forms.ComboBox();
            this.comboBoxNombre = new System.Windows.Forms.ComboBox();
            this.buttonSeleccionar = new System.Windows.Forms.Button();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.dataGridViewSimon = new System.Windows.Forms.DataGridView();
            this.buttonCerrar = new System.Windows.Forms.Button();
            this.pictureBoxSimon = new System.Windows.Forms.PictureBox();
            this.labelSimon = new System.Windows.Forms.Label();
            this.labelFichero = new System.Windows.Forms.Label();
            this.textBoxFichero = new System.Windows.Forms.TextBox();
            this.comboBoxOrdenar = new System.Windows.Forms.ComboBox();
            this.buttonReiniciar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSimon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSimon)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxFecha
            // 
            this.comboBoxFecha.Font = new System.Drawing.Font("Quicksand", 10F);
            this.comboBoxFecha.FormattingEnabled = true;
            this.comboBoxFecha.Location = new System.Drawing.Point(188, 91);
            this.comboBoxFecha.Name = "comboBoxFecha";
            this.comboBoxFecha.Size = new System.Drawing.Size(136, 27);
            this.comboBoxFecha.TabIndex = 25;
            this.comboBoxFecha.Text = "Filtrar por Fecha";
            this.comboBoxFecha.SelectedIndexChanged += new System.EventHandler(this.comboBoxFecha_SelectedIndexChanged);
            // 
            // comboBoxNombre
            // 
            this.comboBoxNombre.Font = new System.Drawing.Font("Quicksand", 10F);
            this.comboBoxNombre.FormattingEnabled = true;
            this.comboBoxNombre.Location = new System.Drawing.Point(43, 91);
            this.comboBoxNombre.Name = "comboBoxNombre";
            this.comboBoxNombre.Size = new System.Drawing.Size(139, 27);
            this.comboBoxNombre.TabIndex = 24;
            this.comboBoxNombre.Text = "Filtrar por Nombre";
            this.comboBoxNombre.SelectedIndexChanged += new System.EventHandler(this.comboBoxNombre_SelectedIndexChanged);
            // 
            // buttonSeleccionar
            // 
            this.buttonSeleccionar.Font = new System.Drawing.Font("Quicksand", 10F);
            this.buttonSeleccionar.Location = new System.Drawing.Point(357, 395);
            this.buttonSeleccionar.Name = "buttonSeleccionar";
            this.buttonSeleccionar.Size = new System.Drawing.Size(144, 31);
            this.buttonSeleccionar.TabIndex = 23;
            this.buttonSeleccionar.Text = "Seleccionar Archivo";
            this.buttonSeleccionar.UseVisualStyleBackColor = true;
            this.buttonSeleccionar.Click += new System.EventHandler(this.buttonSeleccionar_Click);
            this.buttonSeleccionar.MouseCaptureChanged += new System.EventHandler(this.buttonReiniciar_Click);
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Font = new System.Drawing.Font("Quicksand", 10F);
            this.buttonGuardar.Location = new System.Drawing.Point(507, 395);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(124, 31);
            this.buttonGuardar.TabIndex = 22;
            this.buttonGuardar.Text = "Guardar Archivo";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Font = new System.Drawing.Font("Quicksand", 10F);
            this.buttonEliminar.Location = new System.Drawing.Point(637, 395);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(117, 31);
            this.buttonEliminar.TabIndex = 21;
            this.buttonEliminar.Text = "Eliminar Archivo";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // dataGridViewSimon
            // 
            this.dataGridViewSimon.AllowUserToOrderColumns = true;
            this.dataGridViewSimon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSimon.Location = new System.Drawing.Point(43, 121);
            this.dataGridViewSimon.Name = "dataGridViewSimon";
            this.dataGridViewSimon.Size = new System.Drawing.Size(711, 268);
            this.dataGridViewSimon.TabIndex = 20;
            // 
            // buttonCerrar
            // 
            this.buttonCerrar.Font = new System.Drawing.Font("Quicksand", 10F);
            this.buttonCerrar.Location = new System.Drawing.Point(43, 395);
            this.buttonCerrar.Name = "buttonCerrar";
            this.buttonCerrar.Size = new System.Drawing.Size(111, 31);
            this.buttonCerrar.TabIndex = 19;
            this.buttonCerrar.Text = "Cerrar";
            this.buttonCerrar.UseVisualStyleBackColor = true;
            this.buttonCerrar.Click += new System.EventHandler(this.buttonCerrar_Click);
            // 
            // pictureBoxSimon
            // 
            this.pictureBoxSimon.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSimon.Image")));
            this.pictureBoxSimon.Location = new System.Drawing.Point(697, 12);
            this.pictureBoxSimon.Name = "pictureBoxSimon";
            this.pictureBoxSimon.Size = new System.Drawing.Size(57, 49);
            this.pictureBoxSimon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSimon.TabIndex = 18;
            this.pictureBoxSimon.TabStop = false;
            // 
            // labelSimon
            // 
            this.labelSimon.AutoSize = true;
            this.labelSimon.Font = new System.Drawing.Font("Cherry Bomb One", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSimon.Location = new System.Drawing.Point(36, 25);
            this.labelSimon.Name = "labelSimon";
            this.labelSimon.Size = new System.Drawing.Size(180, 48);
            this.labelSimon.TabIndex = 17;
            this.labelSimon.Text = "Simon Dice";
            // 
            // labelFichero
            // 
            this.labelFichero.AutoSize = true;
            this.labelFichero.Font = new System.Drawing.Font("Quicksand", 10F);
            this.labelFichero.Location = new System.Drawing.Point(569, 94);
            this.labelFichero.Name = "labelFichero";
            this.labelFichero.Size = new System.Drawing.Size(60, 21);
            this.labelFichero.TabIndex = 48;
            this.labelFichero.Text = "Fichero:";
            this.labelFichero.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBoxFichero
            // 
            this.textBoxFichero.Location = new System.Drawing.Point(631, 95);
            this.textBoxFichero.Name = "textBoxFichero";
            this.textBoxFichero.Size = new System.Drawing.Size(123, 20);
            this.textBoxFichero.TabIndex = 47;
            this.textBoxFichero.TextChanged += new System.EventHandler(this.textBoxFichero_TextChanged);
            // 
            // comboBoxOrdenar
            // 
            this.comboBoxOrdenar.Font = new System.Drawing.Font("Quicksand", 10F);
            this.comboBoxOrdenar.FormattingEnabled = true;
            this.comboBoxOrdenar.Items.AddRange(new object[] {
            "Nombre",
            "Rondas",
            "Tiempo",
            "Fecha"});
            this.comboBoxOrdenar.Location = new System.Drawing.Point(330, 91);
            this.comboBoxOrdenar.Name = "comboBoxOrdenar";
            this.comboBoxOrdenar.Size = new System.Drawing.Size(121, 27);
            this.comboBoxOrdenar.TabIndex = 51;
            this.comboBoxOrdenar.Text = "Ordenar por";
            this.comboBoxOrdenar.SelectedIndexChanged += new System.EventHandler(this.comboBoxOrdenar_SelectedIndexChanged);
            // 
            // buttonReiniciar
            // 
            this.buttonReiniciar.Font = new System.Drawing.Font("Quicksand", 10F);
            this.buttonReiniciar.Location = new System.Drawing.Point(457, 90);
            this.buttonReiniciar.Name = "buttonReiniciar";
            this.buttonReiniciar.Size = new System.Drawing.Size(82, 27);
            this.buttonReiniciar.TabIndex = 57;
            this.buttonReiniciar.Text = "Reiniciar";
            this.buttonReiniciar.UseVisualStyleBackColor = true;
            // 
            // FormSimon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonReiniciar);
            this.Controls.Add(this.comboBoxOrdenar);
            this.Controls.Add(this.labelFichero);
            this.Controls.Add(this.textBoxFichero);
            this.Controls.Add(this.comboBoxFecha);
            this.Controls.Add(this.comboBoxNombre);
            this.Controls.Add(this.buttonSeleccionar);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.dataGridViewSimon);
            this.Controls.Add(this.buttonCerrar);
            this.Controls.Add(this.pictureBoxSimon);
            this.Controls.Add(this.labelSimon);
            this.Name = "FormSimon";
            this.Text = "FormSimon";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSimon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSimon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxFecha;
        private System.Windows.Forms.ComboBox comboBoxNombre;
        private System.Windows.Forms.Button buttonSeleccionar;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.DataGridView dataGridViewSimon;
        private System.Windows.Forms.Button buttonCerrar;
        private System.Windows.Forms.PictureBox pictureBoxSimon;
        private System.Windows.Forms.Label labelSimon;
        private System.Windows.Forms.Label labelFichero;
        private System.Windows.Forms.TextBox textBoxFichero;
        private System.Windows.Forms.ComboBox comboBoxOrdenar;
        private System.Windows.Forms.Button buttonReiniciar;
    }
}