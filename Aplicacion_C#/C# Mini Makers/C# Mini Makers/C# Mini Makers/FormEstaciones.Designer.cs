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
            this.comboBoxFecha = new System.Windows.Forms.ComboBox();
            this.comboBoxAvatar = new System.Windows.Forms.ComboBox();
            this.buttonSeleccionar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.dataGridViewEstaciones = new System.Windows.Forms.DataGridView();
            this.labelEstaciones = new System.Windows.Forms.Label();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.comboBoxOrdenar = new System.Windows.Forms.ComboBox();
            this.buttonReiniciar = new System.Windows.Forms.Button();
            this.labelFichero = new System.Windows.Forms.Label();
            this.pictureBoxLinea = new System.Windows.Forms.PictureBox();
            this.buttonCerrar = new System.Windows.Forms.PictureBox();
            this.pictureBoxEstaciones = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEstaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLinea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEstaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxFecha
            // 
            this.comboBoxFecha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.comboBoxFecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxFecha.Font = new System.Drawing.Font("Quicksand", 10F);
            this.comboBoxFecha.ForeColor = System.Drawing.Color.White;
            this.comboBoxFecha.FormattingEnabled = true;
            this.comboBoxFecha.Location = new System.Drawing.Point(178, 152);
            this.comboBoxFecha.Name = "comboBoxFecha";
            this.comboBoxFecha.Size = new System.Drawing.Size(124, 27);
            this.comboBoxFecha.TabIndex = 34;
            this.comboBoxFecha.Text = "Filtrar per Data";
            // 
            // comboBoxAvatar
            // 
            this.comboBoxAvatar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.comboBoxAvatar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxAvatar.Font = new System.Drawing.Font("Quicksand", 10F);
            this.comboBoxAvatar.ForeColor = System.Drawing.Color.White;
            this.comboBoxAvatar.FormattingEnabled = true;
            this.comboBoxAvatar.Location = new System.Drawing.Point(43, 152);
            this.comboBoxAvatar.Name = "comboBoxAvatar";
            this.comboBoxAvatar.Size = new System.Drawing.Size(129, 27);
            this.comboBoxAvatar.TabIndex = 33;
            this.comboBoxAvatar.Text = "Filtrar per Avatar";
            // 
            // buttonSeleccionar
            // 
            this.buttonSeleccionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.buttonSeleccionar.FlatAppearance.BorderSize = 0;
            this.buttonSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSeleccionar.Font = new System.Drawing.Font("Quicksand", 10F);
            this.buttonSeleccionar.ForeColor = System.Drawing.Color.White;
            this.buttonSeleccionar.Location = new System.Drawing.Point(43, 102);
            this.buttonSeleccionar.Name = "buttonSeleccionar";
            this.buttonSeleccionar.Size = new System.Drawing.Size(144, 31);
            this.buttonSeleccionar.TabIndex = 32;
            this.buttonSeleccionar.Text = "Seleccionar Arxiu";
            this.buttonSeleccionar.UseVisualStyleBackColor = false;
            this.buttonSeleccionar.Click += new System.EventHandler(this.buttonSeleccionar_Click);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.buttonEliminar.FlatAppearance.BorderSize = 0;
            this.buttonEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEliminar.Font = new System.Drawing.Font("Quicksand", 10F);
            this.buttonEliminar.ForeColor = System.Drawing.Color.White;
            this.buttonEliminar.Location = new System.Drawing.Point(323, 102);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(117, 31);
            this.buttonEliminar.TabIndex = 30;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = false;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // dataGridViewEstaciones
            // 
            this.dataGridViewEstaciones.AllowUserToOrderColumns = true;
            this.dataGridViewEstaciones.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(208)))), ((int)(((byte)(253)))));
            this.dataGridViewEstaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewEstaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEstaciones.Location = new System.Drawing.Point(43, 185);
            this.dataGridViewEstaciones.Name = "dataGridViewEstaciones";
            this.dataGridViewEstaciones.Size = new System.Drawing.Size(711, 291);
            this.dataGridViewEstaciones.TabIndex = 29;
            // 
            // labelEstaciones
            // 
            this.labelEstaciones.AutoSize = true;
            this.labelEstaciones.Font = new System.Drawing.Font("Cherry Bomb One", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(19)))), ((int)(((byte)(128)))));
            this.labelEstaciones.Location = new System.Drawing.Point(83, 28);
            this.labelEstaciones.Name = "labelEstaciones";
            this.labelEstaciones.Size = new System.Drawing.Size(337, 48);
            this.labelEstaciones.TabIndex = 26;
            this.labelEstaciones.Text = "Explora les Estacions";
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.buttonGuardar.FlatAppearance.BorderSize = 0;
            this.buttonGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGuardar.Font = new System.Drawing.Font("Quicksand", 10F);
            this.buttonGuardar.ForeColor = System.Drawing.Color.White;
            this.buttonGuardar.Location = new System.Drawing.Point(193, 102);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(124, 31);
            this.buttonGuardar.TabIndex = 49;
            this.buttonGuardar.Text = "Guardar Arxiu";
            this.buttonGuardar.UseVisualStyleBackColor = false;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // comboBoxOrdenar
            // 
            this.comboBoxOrdenar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.comboBoxOrdenar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxOrdenar.Font = new System.Drawing.Font("Quicksand", 10F);
            this.comboBoxOrdenar.ForeColor = System.Drawing.Color.White;
            this.comboBoxOrdenar.FormattingEnabled = true;
            this.comboBoxOrdenar.Items.AddRange(new object[] {
            "Avatar",
            "Temps 1",
            "Temps 2",
            "Temps 3",
            "Temps Total",
            "Errades 1",
            "Errades 2",
            "Errades 3",
            "Errades Totals",
            "Data"});
            this.comboBoxOrdenar.Location = new System.Drawing.Point(308, 152);
            this.comboBoxOrdenar.Name = "comboBoxOrdenar";
            this.comboBoxOrdenar.Size = new System.Drawing.Size(121, 27);
            this.comboBoxOrdenar.TabIndex = 50;
            this.comboBoxOrdenar.Text = "Ordenar per";
            // 
            // buttonReiniciar
            // 
            this.buttonReiniciar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.buttonReiniciar.FlatAppearance.BorderSize = 0;
            this.buttonReiniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReiniciar.Font = new System.Drawing.Font("Quicksand", 10F);
            this.buttonReiniciar.ForeColor = System.Drawing.Color.White;
            this.buttonReiniciar.Location = new System.Drawing.Point(435, 152);
            this.buttonReiniciar.Name = "buttonReiniciar";
            this.buttonReiniciar.Size = new System.Drawing.Size(82, 27);
            this.buttonReiniciar.TabIndex = 56;
            this.buttonReiniciar.Text = "Reiniciar";
            this.buttonReiniciar.UseVisualStyleBackColor = false;
            this.buttonReiniciar.Click += new System.EventHandler(this.buttonReiniciar_Click);
            // 
            // labelFichero
            // 
            this.labelFichero.AutoSize = true;
            this.labelFichero.Font = new System.Drawing.Font("Quicksand", 10F, System.Drawing.FontStyle.Bold);
            this.labelFichero.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(19)))), ((int)(((byte)(128)))));
            this.labelFichero.Location = new System.Drawing.Point(579, 154);
            this.labelFichero.Name = "labelFichero";
            this.labelFichero.Size = new System.Drawing.Size(0, 21);
            this.labelFichero.TabIndex = 55;
            this.labelFichero.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelFichero.TextChanged += new System.EventHandler(this.labelFichero_TextChanged);
            // 
            // pictureBoxLinea
            // 
            this.pictureBoxLinea.Image = global::C__Mini_Makers.Properties.Resources.Linea;
            this.pictureBoxLinea.Location = new System.Drawing.Point(43, 142);
            this.pictureBoxLinea.Name = "pictureBoxLinea";
            this.pictureBoxLinea.Size = new System.Drawing.Size(709, 2);
            this.pictureBoxLinea.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxLinea.TabIndex = 62;
            this.pictureBoxLinea.TabStop = false;
            // 
            // buttonCerrar
            // 
            this.buttonCerrar.Image = global::C__Mini_Makers.Properties.Resources.Flecha;
            this.buttonCerrar.Location = new System.Drawing.Point(43, 38);
            this.buttonCerrar.Name = "buttonCerrar";
            this.buttonCerrar.Size = new System.Drawing.Size(38, 31);
            this.buttonCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.buttonCerrar.TabIndex = 61;
            this.buttonCerrar.TabStop = false;
            this.buttonCerrar.Click += new System.EventHandler(this.buttonCerrar_Click);
            // 
            // pictureBoxEstaciones
            // 
            this.pictureBoxEstaciones.Image = global::C__Mini_Makers.Properties.Resources.Estaciones;
            this.pictureBoxEstaciones.Location = new System.Drawing.Point(678, 36);
            this.pictureBoxEstaciones.Name = "pictureBoxEstaciones";
            this.pictureBoxEstaciones.Size = new System.Drawing.Size(76, 76);
            this.pictureBoxEstaciones.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxEstaciones.TabIndex = 57;
            this.pictureBoxEstaciones.TabStop = false;
            // 
            // FormEstaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(203)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(800, 511);
            this.Controls.Add(this.pictureBoxLinea);
            this.Controls.Add(this.buttonCerrar);
            this.Controls.Add(this.pictureBoxEstaciones);
            this.Controls.Add(this.buttonReiniciar);
            this.Controls.Add(this.labelFichero);
            this.Controls.Add(this.comboBoxOrdenar);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.comboBoxFecha);
            this.Controls.Add(this.comboBoxAvatar);
            this.Controls.Add(this.buttonSeleccionar);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.dataGridViewEstaciones);
            this.Controls.Add(this.labelEstaciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormEstaciones";
            this.Text = "FormEstaciones";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEstaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLinea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonCerrar)).EndInit();
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
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.ComboBox comboBoxOrdenar;
        private System.Windows.Forms.Button buttonReiniciar;
        private System.Windows.Forms.Label labelFichero;
        private System.Windows.Forms.PictureBox pictureBoxEstaciones;
        private System.Windows.Forms.PictureBox buttonCerrar;
        private System.Windows.Forms.PictureBox pictureBoxLinea;
    }
}