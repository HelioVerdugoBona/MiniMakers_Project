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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormParticipantes));
            this.buttonSeleccionar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.dataGridViewParticipantes = new System.Windows.Forms.DataGridView();
            this.labelParticipantes = new System.Windows.Forms.Label();
            this.buttonCerrar = new System.Windows.Forms.Button();
            this.textBoxFichero = new System.Windows.Forms.TextBox();
            this.labelFichero = new System.Windows.Forms.Label();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.pictureBoxParticipantes = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParticipantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxParticipantes)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSeleccionar
            // 
            this.buttonSeleccionar.Font = new System.Drawing.Font("Quicksand", 10F);
            this.buttonSeleccionar.Location = new System.Drawing.Point(357, 395);
            this.buttonSeleccionar.Name = "buttonSeleccionar";
            this.buttonSeleccionar.Size = new System.Drawing.Size(144, 31);
            this.buttonSeleccionar.TabIndex = 41;
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
            this.buttonEliminar.TabIndex = 39;
            this.buttonEliminar.Text = "Eliminar Archivo";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // dataGridViewParticipantes
            // 
            this.dataGridViewParticipantes.AllowUserToOrderColumns = true;
            this.dataGridViewParticipantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewParticipantes.Location = new System.Drawing.Point(43, 121);
            this.dataGridViewParticipantes.Name = "dataGridViewParticipantes";
            this.dataGridViewParticipantes.Size = new System.Drawing.Size(711, 268);
            this.dataGridViewParticipantes.TabIndex = 38;
            // 
            // labelParticipantes
            // 
            this.labelParticipantes.AutoSize = true;
            this.labelParticipantes.Font = new System.Drawing.Font("Cherry Bomb One", 25F);
            this.labelParticipantes.Location = new System.Drawing.Point(36, 25);
            this.labelParticipantes.Name = "labelParticipantes";
            this.labelParticipantes.Size = new System.Drawing.Size(229, 49);
            this.labelParticipantes.TabIndex = 35;
            this.labelParticipantes.Text = "Participantes";
            // 
            // buttonCerrar
            // 
            this.buttonCerrar.Font = new System.Drawing.Font("Quicksand", 10F);
            this.buttonCerrar.Location = new System.Drawing.Point(43, 395);
            this.buttonCerrar.Name = "buttonCerrar";
            this.buttonCerrar.Size = new System.Drawing.Size(111, 31);
            this.buttonCerrar.TabIndex = 44;
            this.buttonCerrar.Text = "Cerrar";
            this.buttonCerrar.UseVisualStyleBackColor = true;
            this.buttonCerrar.Click += new System.EventHandler(this.buttonCerrar_Click);
            // 
            // textBoxFichero
            // 
            this.textBoxFichero.Location = new System.Drawing.Point(631, 95);
            this.textBoxFichero.Name = "textBoxFichero";
            this.textBoxFichero.Size = new System.Drawing.Size(123, 20);
            this.textBoxFichero.TabIndex = 45;
            // 
            // labelFichero
            // 
            this.labelFichero.AutoSize = true;
            this.labelFichero.Font = new System.Drawing.Font("Quicksand", 10F);
            this.labelFichero.Location = new System.Drawing.Point(569, 94);
            this.labelFichero.Name = "labelFichero";
            this.labelFichero.Size = new System.Drawing.Size(60, 21);
            this.labelFichero.TabIndex = 46;
            this.labelFichero.Text = "Fichero:";
            this.labelFichero.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Font = new System.Drawing.Font("Quicksand", 10F);
            this.buttonGuardar.Location = new System.Drawing.Point(507, 395);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(124, 31);
            this.buttonGuardar.TabIndex = 47;
            this.buttonGuardar.Text = "Guardar Archivo";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // pictureBoxParticipantes
            // 
            this.pictureBoxParticipantes.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxParticipantes.Image")));
            this.pictureBoxParticipantes.Location = new System.Drawing.Point(697, 12);
            this.pictureBoxParticipantes.Name = "pictureBoxParticipantes";
            this.pictureBoxParticipantes.Size = new System.Drawing.Size(57, 49);
            this.pictureBoxParticipantes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxParticipantes.TabIndex = 58;
            this.pictureBoxParticipantes.TabStop = false;
            // 
            // FormParticipantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBoxParticipantes);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.labelFichero);
            this.Controls.Add(this.textBoxFichero);
            this.Controls.Add(this.buttonCerrar);
            this.Controls.Add(this.buttonSeleccionar);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.dataGridViewParticipantes);
            this.Controls.Add(this.labelParticipantes);
            this.Name = "FormParticipantes";
            this.Text = "FormParticipantes";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParticipantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxParticipantes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonSeleccionar;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.DataGridView dataGridViewParticipantes;
        private System.Windows.Forms.Label labelParticipantes;
        private System.Windows.Forms.Button buttonCerrar;
        private System.Windows.Forms.TextBox textBoxFichero;
        private System.Windows.Forms.Label labelFichero;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.PictureBox pictureBoxParticipantes;
    }
}