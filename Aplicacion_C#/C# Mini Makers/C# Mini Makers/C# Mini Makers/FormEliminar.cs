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
            ficheroSeleccionado = fichero;

            RedondearBotones();
        }

        /// <summary>
        /// Redondea los botones al iniciar el form
        /// </summary>
        private void RedondearBotones()
        {
            RedondearBoton(buttonCancelar);
            RedondearBoton(buttonConfirmar);
        }

        /// <summary>
        /// Redondea las esquinas del boton seleccionado
        /// </summary>
        /// <param name="btn"></param>
        private void RedondearBoton(Button btn)
        {
            var radio = 10;
            
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radio, radio, 180, 90);
            path.AddArc(btn.Width - radio, 0, radio, radio, 270, 90);
            path.AddArc(btn.Width - radio, btn.Height - radio, radio, radio, 0, 90);
            path.AddArc(0, btn.Height - radio, radio, radio, 90, 90);
            path.CloseAllFigures();

            btn.Region = new Region(path);
        }

        /// <summary>
        /// Cierra el form sin hacer nada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Cierra el form despues de eliminar el archivo del form anterior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(ficheroSeleccionado))
                {
                    System.IO.File.Delete(ficheroSeleccionado);
                    MessageBox.Show("Fitxer eliminat correctament.");
                    FicheroEliminado?.Invoke();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("El fitxer no existeix.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el fitxer: {ex.Message}");
            }
        }
    }
}
