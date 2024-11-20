namespace C__Mini_Makers
{
    partial class FormParticipantes
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
            this.buttonSeleccionar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.dataGridViewParticipantes = new System.Windows.Forms.DataGridView();
            this.labelParticipantes = new System.Windows.Forms.Label();
            this.labelFichero = new System.Windows.Forms.Label();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.buttonCerrar = new System.Windows.Forms.PictureBox();
            this.pictureBoxParticipantes = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParticipantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxParticipantes)).BeginInit();
            this.SuspendLayout();
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
            this.buttonSeleccionar.TabIndex = 41;
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
            this.buttonEliminar.TabIndex = 39;
            this.buttonEliminar.Text = "Eliminar Archivo";
            this.buttonEliminar.UseVisualStyleBackColor = false;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // dataGridViewParticipantes
            // 
            this.dataGridViewParticipantes.AllowUserToOrderColumns = true;
            this.dataGridViewParticipantes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(208)))), ((int)(((byte)(253)))));
            this.dataGridViewParticipantes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewParticipantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewParticipantes.Location = new System.Drawing.Point(43, 142);
            this.dataGridViewParticipantes.Name = "dataGridViewParticipantes";
            this.dataGridViewParticipantes.Size = new System.Drawing.Size(711, 334);
            this.dataGridViewParticipantes.TabIndex = 38;
            // 
            // labelParticipantes
            // 
            this.labelParticipantes.AutoSize = true;
            this.labelParticipantes.Font = new System.Drawing.Font("Cherry Bomb One", 25F);
            this.labelParticipantes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(19)))), ((int)(((byte)(128)))));
            this.labelParticipantes.Location = new System.Drawing.Point(88, 25);
            this.labelParticipantes.Name = "labelParticipantes";
            this.labelParticipantes.Size = new System.Drawing.Size(213, 49);
            this.labelParticipantes.TabIndex = 35;
            this.labelParticipantes.Text = "Participants";
            // 
            // labelFichero
            // 
            this.labelFichero.AutoSize = true;
            this.labelFichero.Font = new System.Drawing.Font("Quicksand", 10F, System.Drawing.FontStyle.Bold);
            this.labelFichero.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(19)))), ((int)(((byte)(128)))));
            this.labelFichero.Location = new System.Drawing.Point(579, 108);
            this.labelFichero.Name = "labelFichero";
            this.labelFichero.Size = new System.Drawing.Size(0, 21);
            this.labelFichero.TabIndex = 46;
            this.labelFichero.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelFichero.TextChanged += new System.EventHandler(this.labelFichero_TextChanged);
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
            this.buttonGuardar.TabIndex = 47;
            this.buttonGuardar.Text = "Guardar Arxiu";
            this.buttonGuardar.UseVisualStyleBackColor = false;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // buttonCerrar
            // 
            this.buttonCerrar.Image = global::C__Mini_Makers.Properties.Resources.Flecha;
            this.buttonCerrar.Location = new System.Drawing.Point(43, 38);
            this.buttonCerrar.Name = "buttonCerrar";
            this.buttonCerrar.Size = new System.Drawing.Size(38, 31);
            this.buttonCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.buttonCerrar.TabIndex = 60;
            this.buttonCerrar.TabStop = false;
            this.buttonCerrar.Click += new System.EventHandler(this.buttonCerrar_Click);
            // 
            // pictureBoxParticipantes
            // 
            this.pictureBoxParticipantes.Image = global::C__Mini_Makers.Properties.Resources.Participantes;
            this.pictureBoxParticipantes.Location = new System.Drawing.Point(678, 12);
            this.pictureBoxParticipantes.Name = "pictureBoxParticipantes";
            this.pictureBoxParticipantes.Size = new System.Drawing.Size(76, 76);
            this.pictureBoxParticipantes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxParticipantes.TabIndex = 58;
            this.pictureBoxParticipantes.TabStop = false;
            // 
            // FormParticipantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(203)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(800, 511);
            this.Controls.Add(this.buttonCerrar);
            this.Controls.Add(this.pictureBoxParticipantes);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.labelFichero);
            this.Controls.Add(this.buttonSeleccionar);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.dataGridViewParticipantes);
            this.Controls.Add(this.labelParticipantes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormParticipantes";
            this.Text = "FormParticipantes";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParticipantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxParticipantes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonSeleccionar;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.DataGridView dataGridViewParticipantes;
        private System.Windows.Forms.Label labelParticipantes;
        private System.Windows.Forms.Label labelFichero;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.PictureBox pictureBoxParticipantes;
        private System.Windows.Forms.PictureBox buttonCerrar;
    }
}