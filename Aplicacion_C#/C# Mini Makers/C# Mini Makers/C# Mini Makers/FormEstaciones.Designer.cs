namespace C__Mini_Makers
{
    partial class FormEstaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEstaciones));
            this.comboBoxFecha = new System.Windows.Forms.ComboBox();
            this.comboBoxAvatar = new System.Windows.Forms.ComboBox();
            this.buttonSeleccionar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.dataGridViewEstaciones = new System.Windows.Forms.DataGridView();
            this.labelEstaciones = new System.Windows.Forms.Label();
            this.buttonCerrar = new System.Windows.Forms.Button();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.comboBoxOrdenar = new System.Windows.Forms.ComboBox();
            this.buttonReiniciar = new System.Windows.Forms.Button();
            this.labelFichero = new System.Windows.Forms.Label();
            this.textBoxFichero = new System.Windows.Forms.TextBox();
            this.pictureBoxEstaciones = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEstaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEstaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxFecha
            // 
            this.comboBoxFecha.Font = new System.Drawing.Font("Quicksand", 10F);
            this.comboBoxFecha.FormattingEnabled = true;
            this.comboBoxFecha.Location = new System.Drawing.Point(170, 91);
            this.comboBoxFecha.Name = "comboBoxFecha";
            this.comboBoxFecha.Size = new System.Drawing.Size(121, 27);
            this.comboBoxFecha.TabIndex = 34;
            this.comboBoxFecha.Text = "Filtrar por Fecha";
            // 
            // comboBoxAvatar
            // 
            this.comboBoxAvatar.Font = new System.Drawing.Font("Quicksand", 10F);
            this.comboBoxAvatar.FormattingEnabled = true;
            this.comboBoxAvatar.Location = new System.Drawing.Point(43, 91);
            this.comboBoxAvatar.Name = "comboBoxAvatar";
            this.comboBoxAvatar.Size = new System.Drawing.Size(121, 27);
            this.comboBoxAvatar.TabIndex = 33;
            this.comboBoxAvatar.Text = "Filtrar por Avatar";
            // 
            // buttonSeleccionar
            // 
            this.buttonSeleccionar.Font = new System.Drawing.Font("Quicksand", 10F);
            this.buttonSeleccionar.Location = new System.Drawing.Point(357, 395);
            this.buttonSeleccionar.Name = "buttonSeleccionar";
            this.buttonSeleccionar.Size = new System.Drawing.Size(144, 31);
            this.buttonSeleccionar.TabIndex = 32;
            this.buttonSeleccionar.Text = "Seleccionar Archivo";
            this.buttonSeleccionar.UseVisualStyleBackColor = true;
            this.buttonSeleccionar.Click += new System.EventHandler(this.buttonSeleccionar_Click);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Font = new System.Drawing.Font("Quicksand", 10F);
            this.buttonEliminar.Location = new System.Drawing.Point(637, 395);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(117, 31);
            this.buttonEliminar.TabIndex = 30;
            this.buttonEliminar.Text = "Eliminar Archivo";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // dataGridViewEstaciones
            // 
            this.dataGridViewEstaciones.AllowUserToOrderColumns = true;
            this.dataGridViewEstaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEstaciones.Location = new System.Drawing.Point(43, 121);
            this.dataGridViewEstaciones.Name = "dataGridViewEstaciones";
            this.dataGridViewEstaciones.Size = new System.Drawing.Size(711, 268);
            this.dataGridViewEstaciones.TabIndex = 29;
            // 
            // labelEstaciones
            // 
            this.labelEstaciones.AutoSize = true;
            this.labelEstaciones.Font = new System.Drawing.Font("Cherry Bomb One", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstaciones.Location = new System.Drawing.Point(36, 25);
            this.labelEstaciones.Name = "labelEstaciones";
            this.labelEstaciones.Size = new System.Drawing.Size(377, 48);
            this.labelEstaciones.TabIndex = 26;
            this.labelEstaciones.Text = "Descubre las Estaciones";
            // 
            // buttonCerrar
            // 
            this.buttonCerrar.Font = new System.Drawing.Font("Quicksand", 10F);
            this.buttonCerrar.Location = new System.Drawing.Point(44, 395);
            this.buttonCerrar.Name = "buttonCerrar";
            this.buttonCerrar.Size = new System.Drawing.Size(111, 31);
            this.buttonCerrar.TabIndex = 35;
            this.buttonCerrar.Text = "Cerrar";
            this.buttonCerrar.UseVisualStyleBackColor = true;
            this.buttonCerrar.Click += new System.EventHandler(this.buttonCerrar_Click);
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Font = new System.Drawing.Font("Quicksand", 10F);
            this.buttonGuardar.Location = new System.Drawing.Point(507, 395);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(124, 31);
            this.buttonGuardar.TabIndex = 49;
            this.buttonGuardar.Text = "Guardar Archivo";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // comboBoxOrdenar
            // 
            this.comboBoxOrdenar.Font = new System.Drawing.Font("Quicksand", 10F);
            this.comboBoxOrdenar.FormattingEnabled = true;
            this.comboBoxOrdenar.Items.AddRange(new object[] {
            "Nombre",
            "Tiempo 1",
            "Tiempo 2",
            "Tiempo 3",
            "Tiempo Total",
            "Intentos 1",
            "Intentos 2",
            "Intentos 3",
            "Intentos Total",
            "Fecha"});
            this.comboBoxOrdenar.Location = new System.Drawing.Point(297, 91);
            this.comboBoxOrdenar.Name = "comboBoxOrdenar";
            this.comboBoxOrdenar.Size = new System.Drawing.Size(121, 27);
            this.comboBoxOrdenar.TabIndex = 50;
            this.comboBoxOrdenar.Text = "Ordenar por";
            // 
            // buttonReiniciar
            // 
            this.buttonReiniciar.Font = new System.Drawing.Font("Quicksand", 10F);
            this.buttonReiniciar.Location = new System.Drawing.Point(424, 91);
            this.buttonReiniciar.Name = "buttonReiniciar";
            this.buttonReiniciar.Size = new System.Drawing.Size(82, 27);
            this.buttonReiniciar.TabIndex = 56;
            this.buttonReiniciar.Text = "Reiniciar";
            this.buttonReiniciar.UseVisualStyleBackColor = true;
            this.buttonReiniciar.Click += new System.EventHandler(this.buttonReiniciar_Click);
            // 
            // labelFichero
            // 
            this.labelFichero.AutoSize = true;
            this.labelFichero.Font = new System.Drawing.Font("Quicksand", 10F);
            this.labelFichero.Location = new System.Drawing.Point(569, 94);
            this.labelFichero.Name = "labelFichero";
            this.labelFichero.Size = new System.Drawing.Size(60, 21);
            this.labelFichero.TabIndex = 55;
            this.labelFichero.Text = "Fichero:";
            this.labelFichero.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBoxFichero
            // 
            this.textBoxFichero.Location = new System.Drawing.Point(631, 95);
            this.textBoxFichero.Name = "textBoxFichero";
            this.textBoxFichero.Size = new System.Drawing.Size(123, 20);
            this.textBoxFichero.TabIndex = 54;
            // 
            // pictureBoxEstaciones
            // 
            this.pictureBoxEstaciones.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxEstaciones.Image")));
            this.pictureBoxEstaciones.Location = new System.Drawing.Point(697, 12);
            this.pictureBoxEstaciones.Name = "pictureBoxEstaciones";
            this.pictureBoxEstaciones.Size = new System.Drawing.Size(57, 49);
            this.pictureBoxEstaciones.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxEstaciones.TabIndex = 57;
            this.pictureBoxEstaciones.TabStop = false;
            // 
            // FormEstaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBoxEstaciones);
            this.Controls.Add(this.buttonReiniciar);
            this.Controls.Add(this.labelFichero);
            this.Controls.Add(this.textBoxFichero);
            this.Controls.Add(this.comboBoxOrdenar);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.buttonCerrar);
            this.Controls.Add(this.comboBoxFecha);
            this.Controls.Add(this.comboBoxAvatar);
            this.Controls.Add(this.buttonSeleccionar);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.dataGridViewEstaciones);
            this.Controls.Add(this.labelEstaciones);
            this.Name = "FormEstaciones";
            this.Text = "FormEstaciones";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEstaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEstaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxFecha;
        private System.Windows.Forms.ComboBox comboBoxAvatar;
        private System.Windows.Forms.Button buttonSeleccionar;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.DataGridView dataGridViewEstaciones;
        private System.Windows.Forms.Label labelEstaciones;
        private System.Windows.Forms.Button buttonCerrar;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.ComboBox comboBoxOrdenar;
        private System.Windows.Forms.Button buttonReiniciar;
        private System.Windows.Forms.Label labelFichero;
        private System.Windows.Forms.TextBox textBoxFichero;
        private System.Windows.Forms.PictureBox pictureBoxEstaciones;
    }
}