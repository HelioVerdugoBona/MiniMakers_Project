using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C__Mini_Makers
{
    public partial class FormParticipantes : Form
    {
        List<Nombre_Avatar> partidas;
        String ruta;
        public FormParticipantes()
        {
            InitializeComponent();

            DesactivarElementos();
            ActivarElementos();
            RedondearBotones();
        }

        /// <summary>
        /// Permite cerrar el form actual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Te lleva al form de confirmacion para eliminar el fichero
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            FormEliminar formEliminar = new FormEliminar(ruta);
            // Si el fichero es elimindao se vacia el DataGridView
            formEliminar.FicheroEliminado += () =>
            {
                dataGridViewParticipantes.DataSource = null;
                labelFichero.Text = null;
            };
            formEliminar.ShowDialog();
        }

        /// <summary>
        /// Permite seleccionar un archivo para mostrar sus datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSeleccionar_Click(object sender, EventArgs e)
        {
            // Abre la ventana para seleccionar un fichero
            OpenFileDialog fichero = new OpenFileDialog();
            fichero.Filter = "Ficheros JSON (*.json)|*.json";

            // Try Catch que comprueba que el archivo seleccionado no esta vacio
            try
            {
                if (fichero.ShowDialog().Equals(DialogResult.OK))
                {
                    ruta = fichero.FileName;

                    // Guarda el contenido del fichero en una Lista de Objetos
                    JArray arrayPartidas = JArray.Parse(File.ReadAllText(fichero.FileName));
                    partidas = arrayPartidas.ToObject<List<Nombre_Avatar>>();

                    // Elimina los datos de ejemplo
                    partidas.RemoveAll(partida => partida.avatar == "Exemple" || partida.nombre == "ejemplo");

                    // Crea una Lista para guardar solo el nombre o el avatar
                    var mostrarNombre = partidas.Select(partidas => new { partidas.nombre }).Distinct().OrderBy(partida => partida.nombre).ToList();
                    var mostrarAvatar = partidas.Select(partidas => new { partidas.avatar }).Distinct().OrderBy(partida => partida.avatar).ToList();

                    // Comprueba si la Lista de nombres no esta vacia y la muestra
                    if (mostrarNombre.Any() && mostrarNombre.Any(nombre => !string.IsNullOrEmpty(nombre.nombre)))
                    {
                        dataGridViewParticipantes.DataSource = null;
                        dataGridViewParticipantes.DataSource = mostrarNombre;

                        dataGridViewParticipantes.Columns["nombre"].HeaderText = "Nom";

                        labelFichero.Text = fichero.SafeFileName;
                    }
                    // Comprueba si la Lista de nombres no esta vacia y la muestra
                    else if (mostrarAvatar.Any() && mostrarAvatar.Any(avatar => !string.IsNullOrEmpty(avatar.avatar)))
                    {
                        dataGridViewParticipantes.DataSource = null;
                        dataGridViewParticipantes.DataSource = mostrarAvatar;

                        dataGridViewParticipantes.Columns["avatar"].HeaderText = "Avatar";

                        labelFichero.Text = fichero.SafeFileName;
                    }
                    // Si las dos estan vacías mustra un mensaje
                    else
                    {
                        MessageBox.Show("Este archivo no es compatible.");
                    }
                    dataGridViewParticipantes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Este archivo esta vacío.");
            }
        }

        /// <summary>
        /// Permite guardar un fichero con los datos mostrados en el DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            // Abre la ventana para guardar un fichero
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos JSON (*.json)|*.json";
            saveFileDialog.Title = "Guardar archivo JSON";

            // Comprueba que el fichero se puede guardar correctamente
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();

                // Recorre las filas del DataGridView y guarda el contenido en una Lista
                foreach (DataGridViewRow row in dataGridViewParticipantes.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        Dictionary<string, object> rowData = new Dictionary<string, object>();
                        if (partidas.Any() && partidas.Any(nombre => !string.IsNullOrEmpty(nombre.nombre)))
                        {
                            rowData["nombre"] = row.Cells["nombre"].Value ?? string.Empty;
                        }
                        else
                        {
                            rowData["avatar"] = row.Cells["avatar"].Value ?? string.Empty;
                        }

                        data.Add(rowData);
                    }
                }

                // Guarda el contenido de la Lista data en el fichero
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);

                File.WriteAllText(filePath, json);

                // Vacia el contenido del DataGridView
                dataGridViewParticipantes.DataSource = null;
                labelFichero.Text = null;

                MessageBox.Show("Datos guardados correctamente.");
            }
        }

        /// <summary>
        /// Activa los elementos cuando el labelFichero tiene contenido
        /// </summary>
        private void ActivarElementos()
        {
            labelFichero.TextChanged += labelFichero_TextChanged;

            dataGridViewParticipantes.CellFormatting += dataGridViewParticipantes_CellFormatting;
        }

        /// <summary>
        /// Activa los botones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelFichero_TextChanged(object sender, EventArgs e)
        {
            buttonEliminar.Enabled = !string.IsNullOrEmpty(labelFichero.Text);
            buttonGuardar.Enabled = !string.IsNullOrEmpty(labelFichero.Text);
        }
        /// <summary>
        /// Desactiva los elementos al iniciar el form
        /// </summary>
        private void DesactivarElementos()
        {
            buttonEliminar.Enabled = false;
            buttonGuardar.Enabled = false;
        }

        /// <summary>
        /// Redeondea las esquinas de los botones al iniciar el form
        /// </summary>
        private void RedondearBotones()
        {
            RedondearBoton(buttonSeleccionar);
            RedondearBoton(buttonGuardar);
            RedondearBoton(buttonEliminar);
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
        /// Colorea el dataGridView del form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewParticipantes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewParticipantes.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = Color.FromArgb(236, 208, 253);
                    cell.Style.ForeColor = Color.FromArgb(57, 19, 128);
                }
            }
        }
    }
}