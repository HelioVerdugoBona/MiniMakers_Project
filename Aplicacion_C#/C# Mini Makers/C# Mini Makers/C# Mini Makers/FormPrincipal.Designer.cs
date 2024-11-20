namespace C__Mini_Makers
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTitulo = new System.Windows.Forms.Label();
            this.panelParticipantes = new System.Windows.Forms.Panel();
            this.pictureBoxParticipantes = new System.Windows.Forms.PictureBox();
            this.buttonParticipantes = new System.Windows.Forms.Button();
            this.labelTxtParticipantes = new System.Windows.Forms.Label();
            this.labelParticipantes = new System.Windows.Forms.Label();
            this.panelSimon = new System.Windows.Forms.Panel();
            this.pictureBoxSimon = new System.Windows.Forms.PictureBox();
            this.buttonSimon = new System.Windows.Forms.Button();
            this.labelSimon = new System.Windows.Forms.Label();
            this.labelTxtSimon = new System.Windows.Forms.Label();
            this.panelEstaciones = new System.Windows.Forms.Panel();
            this.pictureBoxEstaciones = new System.Windows.Forms.PictureBox();
            this.buttonEstaciones = new System.Windows.Forms.Button();
            this.labelEstaciones = new System.Windows.Forms.Label();
            this.labelTxtEstaciones = new System.Windows.Forms.Label();
            this.panelParticipantes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxParticipantes)).BeginInit();
            this.panelSimon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSimon)).BeginInit();
            this.panelEstaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEstaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Cherry Bomb One", 50F);
            this.labelTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(19)))), ((int)(((byte)(128)))));
            this.labelTitulo.Location = new System.Drawing.Point(198, 38);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(408, 97);
            this.labelTitulo.TabIndex = 3;
            this.labelTitulo.Text = "Mini Makers";
            // 
            // panelParticipantes
            // 
            this.panelParticipantes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(167)))), ((int)(((byte)(251)))));
            this.panelParticipantes.Controls.Add(this.pictureBoxParticipantes);
            this.panelParticipantes.Controls.Add(this.buttonParticipantes);
            this.panelParticipantes.Controls.Add(this.labelTxtParticipantes);
            this.panelParticipantes.Controls.Add(this.labelParticipantes);
            this.panelParticipantes.Location = new System.Drawing.Point(63, 179);
            this.panelParticipantes.Name = "panelParticipantes";
            this.panelParticipantes.Size = new System.Drawing.Size(200, 273);
            this.panelParticipantes.TabIndex = 7;
            // 
            // pictureBoxParticipantes
            // 
            this.pictureBoxParticipantes.Image = global::C__Mini_Makers.Properties.Resources.Participantes;
            this.pictureBoxParticipantes.Location = new System.Drawing.Point(13, 11);
            this.pictureBoxParticipantes.Name = "pictureBoxParticipantes";
            this.pictureBoxParticipantes.Size = new System.Drawing.Size(40, 38);
            this.pictureBoxParticipantes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxParticipantes.TabIndex = 7;
            this.pictureBoxParticipantes.TabStop = false;
            // 
            // buttonParticipantes
            // 
            this.buttonParticipantes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.buttonParticipantes.FlatAppearance.BorderSize = 0;
            this.buttonParticipantes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonParticipantes.Font = new System.Drawing.Font("Quicksand", 10F);
            this.buttonParticipantes.ForeColor = System.Drawing.Color.White;
            this.buttonParticipantes.Location = new System.Drawing.Point(27, 225);
            this.buttonParticipantes.Name = "buttonParticipantes";
            this.buttonParticipantes.Size = new System.Drawing.Size(150, 28);
            this.buttonParticipantes.TabIndex = 6;
            this.buttonParticipantes.Text = "Entrar";
            this.buttonParticipantes.UseVisualStyleBackColor = false;
            this.buttonParticipantes.Click += new System.EventHandler(this.buttonParticipantes_Click);
            // 
            // labelTxtParticipantes
            // 
            this.labelTxtParticipantes.AutoSize = true;
            this.labelTxtParticipantes.BackColor = System.Drawing.Color.Transparent;
            this.labelTxtParticipantes.Font = new System.Drawing.Font("Quicksand", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTxtParticipantes.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelTxtParticipantes.Location = new System.Drawing.Point(27, 122);
            this.labelTxtParticipantes.MinimumSize = new System.Drawing.Size(150, 100);
            this.labelTxtParticipantes.Name = "labelTxtParticipantes";
            this.labelTxtParticipantes.Size = new System.Drawing.Size(150, 100);
            this.labelTxtParticipantes.TabIndex = 5;
            this.labelTxtParticipantes.Text = "Pots  viusalitzar editar\r\nels participants\r\ndels diferentes jocs";
            // 
            // labelParticipantes
            // 
            this.labelParticipantes.AutoSize = true;
            this.labelParticipantes.Font = new System.Drawing.Font("Quicksand", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelParticipantes.ForeColor = System.Drawing.Color.White;
            this.labelParticipantes.Location = new System.Drawing.Point(40, 58);
            this.labelParticipantes.Name = "labelParticipantes";
            this.labelParticipantes.Size = new System.Drawing.Size(122, 30);
            this.labelParticipantes.TabIndex = 4;
            this.labelParticipantes.Text = "Participants";
            // 
            // panelSimon
            // 
            this.panelSimon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(167)))), ((int)(((byte)(251)))));
            this.panelSimon.Controls.Add(this.pictureBoxSimon);
            this.panelSimon.Controls.Add(this.buttonSimon);
            this.panelSimon.Controls.Add(this.labelSimon);
            this.panelSimon.Controls.Add(this.labelTxtSimon);
            this.panelSimon.Location = new System.Drawing.Point(300, 179);
            this.panelSimon.Name = "panelSimon";
            this.panelSimon.Size = new System.Drawing.Size(200, 273);
            this.panelSimon.TabIndex = 8;
            // 
            // pictureBoxSimon
            // 
            this.pictureBoxSimon.Image = global::C__Mini_Makers.Properties.Resources.SimonDice;
            this.pictureBoxSimon.Location = new System.Drawing.Point(11, 11);
            this.pictureBoxSimon.Name = "pictureBoxSimon";
            this.pictureBoxSimon.Size = new System.Drawing.Size(40, 38);
            this.pictureBoxSimon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSimon.TabIndex = 14;
            this.pictureBoxSimon.TabStop = false;
            // 
            // buttonSimon
            // 
            this.buttonSimon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.buttonSimon.FlatAppearance.BorderSize = 0;
            this.buttonSimon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSimon.Font = new System.Drawing.Font("Quicksand", 10F);
            this.buttonSimon.ForeColor = System.Drawing.Color.White;
            this.buttonSimon.Location = new System.Drawing.Point(24, 225);
            this.buttonSimon.Name = "buttonSimon";
            this.buttonSimon.Size = new System.Drawing.Size(150, 28);
            this.buttonSimon.TabIndex = 15;
            this.buttonSimon.Text = "Entrar";
            this.buttonSimon.UseVisualStyleBackColor = false;
            this.buttonSimon.Click += new System.EventHandler(this.buttonSimon_Click);
            // 
            // labelSimon
            // 
            this.labelSimon.AutoSize = true;
            this.labelSimon.Font = new System.Drawing.Font("Quicksand", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSimon.ForeColor = System.Drawing.Color.White;
            this.labelSimon.Location = new System.Drawing.Point(51, 58);
            this.labelSimon.Name = "labelSimon";
            this.labelSimon.Size = new System.Drawing.Size(92, 30);
            this.labelSimon.TabIndex = 12;
            this.labelSimon.Text = "Simó Diu";
            // 
            // labelTxtSimon
            // 
            this.labelTxtSimon.AutoSize = true;
            this.labelTxtSimon.BackColor = System.Drawing.Color.Transparent;
            this.labelTxtSimon.Font = new System.Drawing.Font("Quicksand", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTxtSimon.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelTxtSimon.Location = new System.Drawing.Point(20, 122);
            this.labelTxtSimon.MinimumSize = new System.Drawing.Size(150, 100);
            this.labelTxtSimon.Name = "labelTxtSimon";
            this.labelTxtSimon.Size = new System.Drawing.Size(150, 100);
            this.labelTxtSimon.TabIndex = 13;
            this.labelTxtSimon.Text = "Pots visualitzar\r\nels arxius del joc\r\nSmó Diu, també es\r\npot editar y eliminar";
            // 
            // panelEstaciones
            // 
            this.panelEstaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(167)))), ((int)(((byte)(251)))));
            this.panelEstaciones.Controls.Add(this.pictureBoxEstaciones);
            this.panelEstaciones.Controls.Add(this.buttonEstaciones);
            this.panelEstaciones.Controls.Add(this.labelEstaciones);
            this.panelEstaciones.Controls.Add(this.labelTxtEstaciones);
            this.panelEstaciones.Location = new System.Drawing.Point(539, 179);
            this.panelEstaciones.Name = "panelEstaciones";
            this.panelEstaciones.Size = new System.Drawing.Size(200, 273);
            this.panelEstaciones.TabIndex = 16;
            // 
            // pictureBoxEstaciones
            // 
            this.pictureBoxEstaciones.Image = global::C__Mini_Makers.Properties.Resources.Estaciones;
            this.pictureBoxEstaciones.Location = new System.Drawing.Point(12, 11);
            this.pictureBoxEstaciones.Name = "pictureBoxEstaciones";
            this.pictureBoxEstaciones.Size = new System.Drawing.Size(40, 38);
            this.pictureBoxEstaciones.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxEstaciones.TabIndex = 8;
            this.pictureBoxEstaciones.TabStop = false;
            // 
            // buttonEstaciones
            // 
            this.buttonEstaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.buttonEstaciones.FlatAppearance.BorderSize = 0;
            this.buttonEstaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEstaciones.Font = new System.Drawing.Font("Quicksand", 10F);
            this.buttonEstaciones.ForeColor = System.Drawing.Color.White;
            this.buttonEstaciones.Location = new System.Drawing.Point(26, 225);
            this.buttonEstaciones.Name = "buttonEstaciones";
            this.buttonEstaciones.Size = new System.Drawing.Size(150, 28);
            this.buttonEstaciones.TabIndex = 10;
            this.buttonEstaciones.Text = "Entrar";
            this.buttonEstaciones.UseVisualStyleBackColor = false;
            this.buttonEstaciones.Click += new System.EventHandler(this.buttonEstaciones_Click);
            // 
            // labelEstaciones
            // 
            this.labelEstaciones.AutoSize = true;
            this.labelEstaciones.Font = new System.Drawing.Font("Quicksand", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstaciones.ForeColor = System.Drawing.Color.White;
            this.labelEstaciones.Location = new System.Drawing.Point(36, 45);
            this.labelEstaciones.MaximumSize = new System.Drawing.Size(200, 0);
            this.labelEstaciones.Name = "labelEstaciones";
            this.labelEstaciones.Size = new System.Drawing.Size(113, 60);
            this.labelEstaciones.TabIndex = 7;
            this.labelEstaciones.Text = "Explora les Estacions";
            this.labelEstaciones.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelTxtEstaciones
            // 
            this.labelTxtEstaciones.AutoSize = true;
            this.labelTxtEstaciones.BackColor = System.Drawing.Color.Transparent;
            this.labelTxtEstaciones.Font = new System.Drawing.Font("Quicksand", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTxtEstaciones.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelTxtEstaciones.Location = new System.Drawing.Point(22, 122);
            this.labelTxtEstaciones.MinimumSize = new System.Drawing.Size(150, 100);
            this.labelTxtEstaciones.Name = "labelTxtEstaciones";
            this.labelTxtEstaciones.Size = new System.Drawing.Size(150, 100);
            this.labelTxtEstaciones.TabIndex = 9;
            this.labelTxtEstaciones.Text = "Pots visualitzar\r\nels arxius del joc\r\nExplora les Estacions,\r\ntambé es pot editar" +
    "\r\ny eliminar";
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(203)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(800, 511);
            this.Controls.Add(this.panelEstaciones);
            this.Controls.Add(this.panelSimon);
            this.Controls.Add(this.panelParticipantes);
            this.Controls.Add(this.labelTitulo);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormPrincipal";
            this.Text = "Form Principal";
            this.panelParticipantes.ResumeLayout(false);
            this.panelParticipantes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxParticipantes)).EndInit();
            this.panelSimon.ResumeLayout(false);
            this.panelSimon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSimon)).EndInit();
            this.panelEstaciones.ResumeLayout(false);
            this.panelEstaciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEstaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Panel panelParticipantes;
        private System.Windows.Forms.PictureBox pictureBoxParticipantes;
        private System.Windows.Forms.Button buttonParticipantes;
        private System.Windows.Forms.Label labelTxtParticipantes;
        private System.Windows.Forms.Label labelParticipantes;
        private System.Windows.Forms.Panel panelSimon;
        private System.Windows.Forms.PictureBox pictureBoxSimon;
        private System.Windows.Forms.Button buttonSimon;
        private System.Windows.Forms.Label labelSimon;
        private System.Windows.Forms.Label labelTxtSimon;
        private System.Windows.Forms.Panel panelEstaciones;
        private System.Windows.Forms.PictureBox pictureBoxEstaciones;
        private System.Windows.Forms.Button buttonEstaciones;
        private System.Windows.Forms.Label labelEstaciones;
        private System.Windows.Forms.Label labelTxtEstaciones;
    }
}

