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
    public partial class FormEstaciones : Form
{
        List<PartidasEstaciones> partidas;
        string ruta;

        public FormEstaciones()
        {
            InitializeComponent();

            DesactivarElementos();
            ActivarElementos();
            RedondearBotones();

            this.dataGridViewEstaciones.CellFormatting += new DataGridViewCellFormattingEventHandler(this.dataGridViewEstaciones_CellFormatting);
            this.dataGridViewEstaciones.DataError += new DataGridViewDataErrorEventHandler(this.dataGridViewEstaciones_DataError);
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
                dataGridViewEstaciones.DataSource = null;
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
                    partidas = arrayPartidas.ToObject<List<PartidasEstaciones>>();

                    // Elimina los datos de ejemplo
                    partidas.RemoveAll(p => p.avatar == "Exemple");

                    // Comprueba que el fichero seleccionado es compatible 
                    if (partidas.Any() && partidas.Any(avatar => !string.IsNullOrEmpty(avatar.avatar)) && partidas.Any(data => !string.IsNullOrEmpty(data.data)))
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
                foreach (DataGridViewRow row in dataGridViewEstaciones.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        int errada1 = 0, errada2 = 0, errada3 = 0, erradesTotals = 0;

                        int.TryParse(row.Cells["erradesNVL1"].Value?.ToString(), out errada1);
                        int.TryParse(row.Cells["erradesNVL2"].Value?.ToString(), out errada2);
                        int.TryParse(row.Cells["erradesNVL3"].Value?.ToString(), out errada3);
                        int.TryParse(row.Cells["erradesTotals"].Value?.ToString(), out erradesTotals);

                        Dictionary<string, object> rowData = new Dictionary<string, object>
                {
                    { "avatar", row.Cells["avatar"].Value ?? string.Empty },
                    { "tempsNVL1", row.Cells["tempsNVL1"].Value ?? string.Empty },
                    { "tempsNVL2", row.Cells["tempsNVL2"].Value ?? string.Empty },
                    { "tempsNVL3", row.Cells["tempsNVL3"].Value ?? string.Empty },
                    { "tempsTotal", row.Cells["tempsTotal"].Value ?? string.Empty },
                    { "erradesNVL1", errada1 },
                    { "erradesNVL2", errada2 },
                    { "erradesNVL3", errada3 },
                    { "erradesTotals", erradesTotals },
                    { "data", row.Cells["data"].Value ?? string.Empty }
                };
                        data.Add(rowData);
                    }
                }

                // Guarda el contenido de la Lista data en el fichero
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(saveFileDialog.FileName, json);

                // Vacia el contenido del DataGridView
                dataGridViewEstaciones.DataSource = null;
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
            comboBoxAvatar.Text = "Filtrar per Nom";
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
            string avatarSeleccionado = comboBoxAvatar.SelectedItem?.ToString();
            string fechaSeleccionada = comboBoxFecha.SelectedItem?.ToString();

            var partidasFiltradas = partidas.AsEnumerable();

            // Filtra segun el nombre seleccionado
            if (!string.IsNullOrEmpty(avatarSeleccionado))
            {
                partidasFiltradas = partidasFiltradas.Where(partida => partida.avatar == avatarSeleccionado);
            }

            // Filtra segun la fecha seleccionada
            if (!string.IsNullOrEmpty(fechaSeleccionada))
            {
                partidasFiltradas = partidasFiltradas.Where(partida => partida.data == fechaSeleccionada);
            }

            string criterioSeleccionado = comboBoxOrdenar.SelectedItem?.ToString();

            // Ordena segun el criterio seleccionado
            if (criterioSeleccionado == "Avatar")
            {
                partidasFiltradas = partidasFiltradas.OrderBy(partida => partida.avatar);
            }
            else if (criterioSeleccionado == "Temps 1")
            {
                partidasFiltradas = partidasFiltradas.OrderBy(partida => partida.tempsNVL1);
            }
            else if (criterioSeleccionado == "Temps 2")
            {
                partidasFiltradas = partidasFiltradas.OrderBy(partida => partida.tempsNVL2);
            }
            else if (criterioSeleccionado == "Temps 3")
            {
                partidasFiltradas = partidasFiltradas.OrderBy(partida => partida.tempsNVL3);
            }
            else if (criterioSeleccionado == "Temps Total")
            {
                partidasFiltradas = partidasFiltradas.OrderBy(partida => partida.tempsTotal);
            }
            else if (criterioSeleccionado == "Errades 1")
            {
                partidasFiltradas = partidasFiltradas.OrderBy(partida => partida.erradesNVL1);
            }
            else if (criterioSeleccionado == "Errades 2")
            {
                partidasFiltradas = partidasFiltradas.OrderBy(partida => partida.erradesNVL2);
            }
            else if (criterioSeleccionado == "Errades 3")
            {
                partidasFiltradas = partidasFiltradas.OrderBy(partida => partida.erradesNVL3);
            }
            else if (criterioSeleccionado == "Errades Totals")
            {
                partidasFiltradas = partidasFiltradas.OrderBy(partida => partida.erradesTotals);
            }
            else if (criterioSeleccionado == "Data")
            {
                partidasFiltradas = partidasFiltradas.OrderBy(partida => partida.data);
            }

            dataGridViewEstaciones.DataSource = partidasFiltradas.ToList();
        }

        /// <summary>
        /// Activa los elementos cuando el labelFichero tiene contenido
        /// </summary>
        private void ActivarElementos()
        {
            labelFichero.TextChanged += labelFichero_TextChanged;

            comboBoxAvatar.SelectedIndexChanged += comboBox_SelectedIndexChanged;
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
            comboBoxAvatar.Enabled = isEnabled;
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

            comboBoxAvatar.Enabled = false;
            comboBoxFecha.Enabled = false;
            comboBoxOrdenar.Enabled = false;
        }

        /// <summary>
        /// Actializa el dataGridView del form para que muestre el contenido de la Lista partidas
        /// </summary>
        private void ActualizarDataGridView()
        {
            dataGridViewEstaciones.DataSource = null;
            dataGridViewEstaciones.DataSource = partidas;

            // Actualiza las cabeceras de las columnas
            if (dataGridViewEstaciones.Columns["avatar"] != null)
                dataGridViewEstaciones.Columns["avatar"].HeaderText = "Avatar";
            if (dataGridViewEstaciones.Columns["tempsNVL1"] != null)
                dataGridViewEstaciones.Columns["tempsNVL1"].HeaderText = "Temps 1";
            if (dataGridViewEstaciones.Columns["tempsNVL2"] != null)
                dataGridViewEstaciones.Columns["tempsNVL2"].HeaderText = "Temps 2";
            if (dataGridViewEstaciones.Columns["tempsNVL3"] != null)
                dataGridViewEstaciones.Columns["tempsNVL3"].HeaderText = "Temps 3";
            if (dataGridViewEstaciones.Columns["tempsTotal"] != null)
                dataGridViewEstaciones.Columns["tempsTotal"].HeaderText = "Temps Total";
            if (dataGridViewEstaciones.Columns["erradesNVL1"] != null)
                dataGridViewEstaciones.Columns["erradesNVL1"].HeaderText = "Errades 1";
            if (dataGridViewEstaciones.Columns["erradesNVL2"] != null)
                dataGridViewEstaciones.Columns["erradesNVL2"].HeaderText = "Errades 2";
            if (dataGridViewEstaciones.Columns["erradesNVL3"] != null)
                dataGridViewEstaciones.Columns["erradesNVL3"].HeaderText = "Errades 3";
            if (dataGridViewEstaciones.Columns["erradesTotals"] != null)
                dataGridViewEstaciones.Columns["erradesTotals"].HeaderText = "Errades Totals";
            if (dataGridViewEstaciones.Columns["data"] != null)
                dataGridViewEstaciones.Columns["data"].HeaderText = "Data";


            comboBoxAvatar.Items.Clear();
            comboBoxFecha.Items.Clear();

            // Cargar los nombres y fechas unicas en los comboBox
            if (partidas != null)
            {
                var avataresUnicos = partidas.Select(partida => partida.avatar).Distinct().OrderBy(n => n);
                comboBoxAvatar.Items.AddRange(avataresUnicos.ToArray());

                var fechasUnicas = partidas.Select(partida => partida.data).Distinct().OrderBy(f => f);
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
        private void dataGridViewEstaciones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewEstaciones.Rows)
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
        private void dataGridViewEstaciones_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string columnHeaderText = dataGridViewEstaciones.Columns[e.ColumnIndex].HeaderText;
            e.ThrowException = false;

            MessageBox.Show($"Error al introducir datos en la fila {e.RowIndex + 1}, columna '{columnHeaderText}'. " + "Por favor, comprueba el valor introducido.");
            e.Cancel = true;
        }
    }
}
