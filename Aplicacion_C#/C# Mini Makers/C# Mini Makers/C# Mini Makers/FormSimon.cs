using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace C__Mini_Makers
{
    public partial class FormSimon : Form
    {
        List<PartidasSimon> partidas;
        String ruta;

        public FormSimon()
        {
            InitializeComponent();

            DesactivarElementos();
            ActivarElementos();
            RedondearBotones();

            this.dataGridViewSimon.CellFormatting += new DataGridViewCellFormattingEventHandler(this.dataGridViewSimon_CellFormatting);
            this.dataGridViewSimon.DataError += new DataGridViewDataErrorEventHandler(this.dataGridViewSimon_DataError);

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

            // Si el fichero es elimindao se vacia el DataGridView y se reinician los filtros
            formEliminar.FicheroEliminado += () =>
            {
                dataGridViewSimon.DataSource = null;
                ReiniciarComboBox();
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
                    partidas = arrayPartidas.ToObject<List<PartidasSimon>>();

                    // Elimina los datos de ejemplo
                    partidas.RemoveAll(partida => partida.nombre == "ejemplo");

                    // Comprueba que el fichero seleccionado es compatible 
                    if (partidas.Any() && partidas.Any(nombre => !string.IsNullOrEmpty(nombre.nombre)) && partidas.Any(fecha => !string.IsNullOrEmpty(fecha.fecha)))
                    {
                        labelFichero.Text = fichero.SafeFileName;
                    }
                    // Muestra un mensaje si el fichero no es compatible
                    else
                    {
                        MessageBox.Show("Este archivo JSON no es compatible.");
                        partidas = null;
                        labelFichero.Text = null;
                    }
                    ActualizarDataGridView();
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
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "JSON files (*.json)|*.json",
                Title = "Guardar archivo JSON"
            };

            // Comprueba que el fichero se puede guardar correctamente
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();

                // Recorre las filas del DataGridView y guarda el contenido en una Lista
                foreach (DataGridViewRow row in dataGridViewSimon.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        int rondas = 0;
                        int.TryParse(row.Cells["rondas"].Value?.ToString(), out rondas);

                        Dictionary<string, object> rowData = new Dictionary<string, object>
                        {
                            { "nombre", row.Cells["nombre"].Value ?? string.Empty },
                            { "rondas", rondas },
                            { "tiempo", row.Cells["tiempo"].Value ?? string.Empty },
                            { "fecha", row.Cells["fecha"].Value ?? string.Empty }
                        };
                        data.Add(rowData);
                    }
                }

                // Guarda el contenido de la Lista data en el fichero
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(saveFileDialog.FileName, json);

                // Vacia el contenido del DataGridView
                dataGridViewSimon.DataSource = null;
                ReiniciarComboBox();
                labelFichero.Text = null;

                MessageBox.Show("Dades guardades correctament.");
            }
        }

        /// <summary>
        /// Permite reiniciar los comboBox de los filtros y el de ordenar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReiniciar_Click(object sender, EventArgs e)
        {
            ReiniciarComboBox();
            ActualizarDataGridView();
        }

        /// <summary>
        /// Reinicia el texto de los ComoboBox
        /// </summary>
        private void ReiniciarComboBox()
        {
            comboBoxNombre.Text = "Filtrar per Nom";
            comboBoxFecha.Text = "Filtrar per Data";
            comboBoxOrdenar.Text = "Ordenar per";
        }

        /// <summary>
        /// Llama al metodo de filtrar y ordenar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarOrdenarPartidas();
        }

        /// <summary>
        /// Filtra y ordena segun los criterios seleccionados
        /// </summary>
        private void FiltrarOrdenarPartidas()
        {
            string nombreSeleccionado = comboBoxNombre.SelectedItem?.ToString();
            string fechaSeleccionada = comboBoxFecha.SelectedItem?.ToString();

            var partidasFiltradas = partidas.AsEnumerable();

            // Filtra segun el nombre seleccionado
            if (!string.IsNullOrEmpty(nombreSeleccionado))
            {
                partidasFiltradas = partidasFiltradas.Where(partida => partida.nombre == nombreSeleccionado);
            }

            // Filtra segun la fecha seleccionada
            if (!string.IsNullOrEmpty(fechaSeleccionada))
            {
                partidasFiltradas = partidasFiltradas.Where(partida => partida.fecha == fechaSeleccionada);
            }

            string criterioSeleccionado = comboBoxOrdenar.SelectedItem?.ToString();

            // Ordena segun el criterio seleccionado
            if (criterioSeleccionado == "Nom")
            {
                partidasFiltradas = partidasFiltradas.OrderBy(partida => partida.nombre);
            }
            else if (criterioSeleccionado == "Rondes")
            {
                partidasFiltradas = partidasFiltradas.OrderBy(partida => partida.rondas);
            }
            else if (criterioSeleccionado == "Temps")
            {
                partidasFiltradas = partidasFiltradas.OrderBy(partida => partida.tiempo);
            }
            else if (criterioSeleccionado == "Data")
            {
                partidasFiltradas = partidasFiltradas.OrderBy(partida => partida.fecha);
            }

            dataGridViewSimon.DataSource = partidasFiltradas.ToList();
        }

        /// <summary>
        /// Activa los elementos cuando el labelFichero tiene contenido
        /// </summary>
        private void ActivarElementos()
        {
            labelFichero.TextChanged += labelFichero_TextChanged;

            comboBoxNombre.SelectedIndexChanged += comboBox_SelectedIndexChanged;
            comboBoxFecha.SelectedIndexChanged += comboBox_SelectedIndexChanged;
            comboBoxOrdenar.SelectedIndexChanged += comboBox_SelectedIndexChanged;
        }

        /// <summary>
        /// Activa los elementos cuando el labelFichero tiene contenido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelFichero_TextChanged(object sender, EventArgs e)
        {
            bool isEnabled = !string.IsNullOrEmpty(labelFichero.Text);

            buttonEliminar.Enabled = isEnabled;
            buttonGuardar.Enabled = isEnabled;
            buttonReiniciar.Enabled = isEnabled;

            comboBoxFecha.Enabled = isEnabled;
            comboBoxNombre.Enabled = isEnabled;
            comboBoxOrdenar.Enabled = isEnabled;
        }

        /// <summary>
        /// Desactiva los elementos al iniciar el form
        /// </summary>
        private void DesactivarElementos()
        {
            buttonEliminar.Enabled = false;
            buttonGuardar.Enabled = false;
            buttonReiniciar.Enabled = false;

            comboBoxFecha.Enabled = false;
            comboBoxNombre.Enabled = false;
            comboBoxOrdenar.Enabled = false;
        }

        /// <summary>
        /// Actializa el dataGridView del form para que muestre el contenido de la Lista partidas
        /// </summary>
        private void ActualizarDataGridView()
        {
            dataGridViewSimon.DataSource = null;
            dataGridViewSimon.DataSource = partidas;

            // Actualiza las cabeceras de las columnas
            if (dataGridViewSimon.Columns["nombre"] != null)
                dataGridViewSimon.Columns["nombre"].HeaderText = "Nom";
            if (dataGridViewSimon.Columns["rondas"] != null)
                dataGridViewSimon.Columns["rondas"].HeaderText = "Rondes";
            if (dataGridViewSimon.Columns["tiempo"] != null)
                dataGridViewSimon.Columns["tiempo"].HeaderText = "Temps";
            if (dataGridViewSimon.Columns["fecha"] != null)
                dataGridViewSimon.Columns["fecha"].HeaderText = "Data";

            dataGridViewSimon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            comboBoxNombre.Items.Clear();
            comboBoxFecha.Items.Clear();

            // Cargar los nombres y fechas unicas en los comboBox
            if (partidas != null)
            {
                var nombresUnicos = partidas.Select(partida => partida.nombre).Distinct().OrderBy(n => n);
                comboBoxNombre.Items.AddRange(nombresUnicos.ToArray());

                var fechasUnicas = partidas.Select(partida => partida.fecha).Distinct().OrderBy(f => f);
                comboBoxFecha.Items.AddRange(fechasUnicas.ToArray());
            }
        }

        /// <summary>
        /// Redeondea las esquinas de los botones
        /// </summary>
        private void RedondearBotones()
        {
            RedondearBoton(buttonSeleccionar);
            RedondearBoton(buttonGuardar);
            RedondearBoton(buttonEliminar);
            RedondearBoton(buttonReiniciar);
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
        private void dataGridViewSimon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewSimon.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = Color.FromArgb(236, 208, 253);
                    cell.Style.ForeColor = Color.FromArgb(57, 19, 128);
                }
            }
        }

        /// <summary>
        /// Controla que no se puedan poner caracteres alfabeticos en las celdas de un int
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewSimon_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string columnHeaderText = dataGridViewSimon.Columns[e.ColumnIndex].HeaderText;
            e.ThrowException = false;

            MessageBox.Show($"Error al introducir datos en la fila {e.RowIndex + 1}, columna '{columnHeaderText}'. " + "Por favor, comprueba el valor introducido.");
            e.Cancel = true;
        }
    }
}