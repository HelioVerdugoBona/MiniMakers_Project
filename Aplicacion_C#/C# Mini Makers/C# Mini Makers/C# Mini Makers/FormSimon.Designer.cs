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
            this.comboBoxNombre = new System.Windows.Forms.ComboBox();
            this.dataGridViewSimon = new System.Windows.Forms.DataGridView();
            this.labelSimon = new System.Windows.Forms.Label();
            this.comboBoxFecha = new System.Windows.Forms.ComboBox();
            this.buttonSeleccionar = new System.Windows.Forms.Button();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.labelFichero = new System.Windows.Forms.Label();
            this.buttonReiniciar = new System.Windows.Forms.Button();
            this.comboBoxOrdenar = new System.Windows.Forms.ComboBox();
            this.buttonCerrar = new System.Windows.Forms.PictureBox();
            this.pictureBoxSimon = new System.Windows.Forms.PictureBox();
            this.pictureBoxLinea = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSimon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSimon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLinea)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxNombre
            // 
            this.comboBoxNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.comboBoxNombre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxNombre.Font = new System.Drawing.Font("Quicksand", 10F);
            this.comboBoxNombre.ForeColor = System.Drawing.Color.White;
            this.comboBoxNombre.FormattingEnabled = true;
            this.comboBoxNombre.Location = new System.Drawing.Point(43, 152);
            this.comboBoxNombre.Name = "comboBoxNombre";
            this.comboBoxNombre.Size = new System.Drawing.Size(124, 27);
            this.comboBoxNombre.TabIndex = 24;
            this.comboBoxNombre.Text = "Filtrar per Nom";
            this.comboBoxNombre.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // dataGridViewSimon
            // 
            this.dataGridViewSimon.AllowUserToOrderColumns = true;
            this.dataGridViewSimon.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(208)))), ((int)(((byte)(253)))));
            this.dataGridViewSimon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewSimon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSimon.Location = new System.Drawing.Point(43, 185);
            this.dataGridViewSimon.Name = "dataGridViewSimon";
            this.dataGridViewSimon.Size = new System.Drawing.Size(711, 291);
            this.dataGridViewSimon.TabIndex = 20;
            // 
            // labelSimon
            // 
            this.labelSimon.AutoSize = true;
            this.labelSimon.Font = new System.Drawing.Font("Cherry Bomb One", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSimon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(19)))), ((int)(((byte)(128)))));
            this.labelSimon.Location = new System.Drawing.Point(83, 28);
            this.labelSimon.Name = "labelSimon";
            this.labelSimon.Size = new System.Drawing.Size(149, 48);
            this.labelSimon.TabIndex = 17;
            this.labelSimon.Text = "Simó Diu";
            // 
            // comboBoxFecha
            // 
            this.comboBoxFecha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.comboBoxFecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxFecha.Font = new System.Drawing.Font("Quicksand", 10F);
            this.comboBoxFecha.ForeColor = System.Drawing.Color.White;
            this.comboBoxFecha.FormattingEnabled = true;
            this.comboBoxFecha.Location = new System.Drawing.Point(173, 152);
            this.comboBoxFecha.Name = "comboBoxFecha";
            this.comboBoxFecha.Size = new System.Drawing.Size(136, 27);
            this.comboBoxFecha.TabIndex = 25;
            this.comboBoxFecha.Text = "Filtrar per Data";
            this.comboBoxFecha.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
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
            this.buttonSeleccionar.TabIndex = 23;
            this.buttonSeleccionar.Text = "Seleccionar Arxiu";
            this.buttonSeleccionar.UseVisualStyleBackColor = false;
            this.buttonSeleccionar.Click += new System.EventHandler(this.buttonSeleccionar_Click);
            this.buttonSeleccionar.MouseCaptureChanged += new System.EventHandler(this.buttonReiniciar_Click);
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
            this.buttonGuardar.TabIndex = 22;
            this.buttonGuardar.Text = "Guardar Arxiu";
            this.buttonGuardar.UseVisualStyleBackColor = false;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
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
            this.buttonEliminar.TabIndex = 21;
            this.buttonEliminar.Text = "Eliminar Archivo";
            this.buttonEliminar.UseVisualStyleBackColor = false;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // labelFichero
            // 
            this.labelFichero.AutoSize = true;
            this.labelFichero.Font = new System.Drawing.Font("Quicksand", 10F, System.Drawing.FontStyle.Bold);
            this.labelFichero.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(19)))), ((int)(((byte)(128)))));
            this.labelFichero.Location = new System.Drawing.Point(579, 154);
            this.labelFichero.Name = "labelFichero";
            this.labelFichero.Size = new System.Drawing.Size(0, 21);
            this.labelFichero.TabIndex = 48;
            this.labelFichero.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelFichero.TextChanged += new System.EventHandler(this.labelFichero_TextChanged);
            // 
            // buttonReiniciar
            // 
            this.buttonReiniciar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.buttonReiniciar.FlatAppearance.BorderSize = 0;
            this.buttonReiniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReiniciar.Font = new System.Drawing.Font("Quicksand", 10F);
            this.buttonReiniciar.ForeColor = System.Drawing.Color.White;
            this.buttonReiniciar.Location = new System.Drawing.Point(442, 152);
            this.buttonReiniciar.Name = "buttonReiniciar";
            this.buttonReiniciar.Size = new System.Drawing.Size(82, 27);
            this.buttonReiniciar.TabIndex = 57;
            this.buttonReiniciar.Text = "Reiniciar";
            this.buttonReiniciar.UseVisualStyleBackColor = false;
            this.buttonReiniciar.Click += new System.EventHandler(this.buttonReiniciar_Click);
            // 
            // comboBoxOrdenar
            // 
            this.comboBoxOrdenar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.comboBoxOrdenar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxOrdenar.Font = new System.Drawing.Font("Quicksand", 10F);
            this.comboBoxOrdenar.ForeColor = System.Drawing.Color.White;
            this.comboBoxOrdenar.FormattingEnabled = true;
            this.comboBoxOrdenar.ItemHeight = 19;
            this.comboBoxOrdenar.Items.AddRange(new object[] {
            "Nom",
            "Rondes",
            "Temps",
            "Data"});
            this.comboBoxOrdenar.Location = new System.Drawing.Point(315, 152);
            this.comboBoxOrdenar.Name = "comboBoxOrdenar";
            this.comboBoxOrdenar.Size = new System.Drawing.Size(121, 27);
            this.comboBoxOrdenar.TabIndex = 51;
            this.comboBoxOrdenar.Text = "Ordenar per";
            this.comboBoxOrdenar.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // buttonCerrar
            // 
            this.buttonCerrar.Image = global::C__Mini_Makers.Properties.Resources.Flecha;
            this.buttonCerrar.Location = new System.Drawing.Point(43, 38);
            this.buttonCerrar.Name = "buttonCerrar";
            this.buttonCerrar.Size = new System.Drawing.Size(38, 31);
            this.buttonCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.buttonCerrar.TabIndex = 59;
            this.buttonCerrar.TabStop = false;
            this.buttonCerrar.Click += new System.EventHandler(this.buttonCerrar_Click);
            // 
            // pictureBoxSimon
            // 
            this.pictureBoxSimon.Image = global::C__Mini_Makers.Properties.Resources.SimonDice;
            this.pictureBoxSimon.Location = new System.Drawing.Point(678, 36);
            this.pictureBoxSimon.Name = "pictureBoxSimon";
            this.pictureBoxSimon.Size = new System.Drawing.Size(76, 76);
            this.pictureBoxSimon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSimon.TabIndex = 18;
            this.pictureBoxSimon.TabStop = false;
            // 
            // pictureBoxLinea
            // 
            this.pictureBoxLinea.Image = global::C__Mini_Makers.Properties.Resources.Linea;
            this.pictureBoxLinea.Location = new System.Drawing.Point(43, 142);
            this.pictureBoxLinea.Name = "pictureBoxLinea";
            this.pictureBoxLinea.Size = new System.Drawing.Size(709, 2);
            this.pictureBoxLinea.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxLinea.TabIndex = 63;
            this.pictureBoxLinea.TabStop = false;
            // 
            // FormSimon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(203)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(800, 511);
            this.Controls.Add(this.pictureBoxLinea);
            this.Controls.Add(this.buttonCerrar);
            this.Controls.Add(this.buttonReiniciar);
            this.Controls.Add(this.comboBoxOrdenar);
            this.Controls.Add(this.labelFichero);
            this.Controls.Add(this.comboBoxFecha);
            this.Controls.Add(this.comboBoxNombre);
            this.Controls.Add(this.buttonSeleccionar);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.dataGridViewSimon);
            this.Controls.Add(this.pictureBoxSimon);
            this.Controls.Add(this.labelSimon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormSimon";
            this.Text = "FormSimon";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSimon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSimon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLinea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxNombre;
        private System.Windows.Forms.DataGridView dataGridViewSimon;
        private System.Windows.Forms.PictureBox pictureBoxSimon;
        private System.Windows.Forms.Label labelSimon;
        private System.Windows.Forms.ComboBox comboBoxFecha;
        private System.Windows.Forms.Button buttonSeleccionar;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Label labelFichero;
        private System.Windows.Forms.Button buttonReiniciar;
        private System.Windows.Forms.ComboBox comboBoxOrdenar;
        private System.Windows.Forms.PictureBox buttonCerrar;
        private System.Windows.Forms.PictureBox pictureBoxLinea;
    }
}