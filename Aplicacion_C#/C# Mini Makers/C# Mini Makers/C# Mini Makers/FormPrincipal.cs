using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C__Mini_Makers
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void buttonParticipantes_Click(object sender, EventArgs e)
        {
            FormParticipantes participantes = new FormParticipantes();
            participantes.Show();
        }

        private void buttonSimon_Click(object sender, EventArgs e)
        {
            FormSimon simon = new FormSimon();
            simon.Show();
        }

        private void buttonEstaciones_Click(object sender, EventArgs e)
        {
            FormEstaciones estaciones = new FormEstaciones();
            estaciones.Show();
        }
    }
}
