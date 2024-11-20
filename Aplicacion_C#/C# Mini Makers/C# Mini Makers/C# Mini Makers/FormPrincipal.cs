using System;
using System.Drawing;
using System.Windows.Forms;

namespace C__Mini_Makers
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();

            RedondearElementos();
        }

        /// <summary>
        /// Abre el form de los participantes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonParticipantes_Click(object sender, EventArgs e)
        {
            FormParticipantes participantes = new FormParticipantes();
            participantes.Show();
        }

        /// <summary>
        /// Abre el form de las partidas del Simon Dice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSimon_Click(object sender, EventArgs e)
        {
            FormSimon simon = new FormSimon();
            simon.Show();
        }

        /// <summary>
        /// Abre el form de las partidas del juego de las estaciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEstaciones_Click(object sender, EventArgs e)
        {
            FormEstaciones estaciones = new FormEstaciones();
            estaciones.Show();
        }

        /// <summary>
        /// Redeondea las esquinas de los botones y paneles al iniciar el form
        /// </summary>
        private void RedondearElementos()
        {
            RedondearPanel(panelParticipantes);
            RedondearPanel(panelSimon);
            RedondearPanel(panelEstaciones);

            RedondearBoton(buttonEstaciones);
            RedondearBoton(buttonParticipantes);
            RedondearBoton(buttonSimon);
        }

        /// <summary>
        /// Redondea las esquinas del panel seleccionado
        /// </summary>
        /// <param name="panel"></param>
        private void RedondearPanel(Panel panel)
        {
            var radio = 10;

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radio, radio, 180, 90);
            path.AddArc(panel.Width - radio, 0, radio, radio, 270, 90);
            path.AddArc(panel.Width - radio, panel.Height - radio, radio, radio, 0, 90);
            path.AddArc(0, panel.Height - radio, radio, radio, 90, 90);
            path.CloseAllFigures();

            panel.Region = new Region(path);
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
    }
}
