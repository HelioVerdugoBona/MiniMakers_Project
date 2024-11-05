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
    public partial class FormEliminar : Form
    {
        private string ficheroSeleccionado;
        public event Action FicheroEliminado;
        public FormEliminar(string fichero)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            ficheroSeleccionado = fichero;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(ficheroSeleccionado))
                {
                    System.IO.File.Delete(ficheroSeleccionado);
                    MessageBox.Show("Fichero eliminado correctamente.");
                    FicheroEliminado?.Invoke();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("El fichero no existe.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el fichero: {ex.Message}");
            }
        }
    }
}
