using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
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
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.textBoxFichero.ReadOnly = true;

            buttonEliminar.Enabled = false;
            buttonGuardar.Enabled = false;
            comboBoxAvatar.Enabled = false;
            comboBoxFecha.Enabled = false;
            comboBoxOrdenar.Enabled = false;

            textBoxFichero.TextChanged += textBoxFichero_TextChanged;
            comboBoxAvatar.SelectedIndexChanged += comboBoxAvatar_SelectedIndexChanged;
            comboBoxFecha.SelectedIndexChanged += comboBoxFecha_SelectedIndexChanged;
            comboBoxOrdenar.SelectedIndexChanged += comboBoxOrdenar_SelectedIndexChanged;
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            FormEliminar formEliminar = new FormEliminar(ruta);
            formEliminar.FicheroEliminado += () =>
            {
                dataGridViewEstaciones.DataSource = null;
                comboBoxAvatar.Text = "Filtrar por Nombre";
                comboBoxFecha.Text = "Filtrar por Fecha";
                comboBoxOrdenar.Text = "Ordenar por";
                textBoxFichero.Clear();
            };
            formEliminar.ShowDialog();
        }

        private void buttonSeleccionar_Click(object sender, EventArgs e)
        {
            OpenFileDialog fichero = new OpenFileDialog
            {
                Filter = "Ficheros JSON (*.json)|*.json"
            };

            if (fichero.ShowDialog().Equals(DialogResult.OK))
            {
                textBoxFichero.Text = fichero.SafeFileName;
                ruta = fichero.FileName;

                JArray arrayPartidas = JArray.Parse(File.ReadAllText(fichero.FileName));
                partidas = arrayPartidas.ToObject<List<PartidasEstaciones>>();

                ActualizarDataGridView();
            }
        }

        private void textBoxFichero_TextChanged(object sender, EventArgs e)
        {
            bool isEnabled = !string.IsNullOrEmpty(textBoxFichero.Text);
            buttonEliminar.Enabled = isEnabled;
            buttonGuardar.Enabled = isEnabled;
            comboBoxFecha.Enabled = isEnabled;
            comboBoxAvatar.Enabled = isEnabled;
            comboBoxOrdenar.Enabled = isEnabled;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                Title = "Guardar archivo JSON"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();

                foreach (DataGridViewRow row in dataGridViewEstaciones.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        Dictionary<string, object> rowData = new Dictionary<string, object>
                        {
                            { "nombre", row.Cells["nombre"].Value ?? string.Empty }
                        };
                        data.Add(rowData);
                    }
                }

                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(saveFileDialog.FileName, json);

                dataGridViewEstaciones.DataSource = null;
                comboBoxAvatar.Text = "Filtrar por Avatar";
                comboBoxFecha.Text = "Filtrar por Fecha";
                comboBoxOrdenar.Text = "Ordenar por";
                textBoxFichero.Clear();

                MessageBox.Show("Datos guardados correctamente.");
            }
        }

        private void comboBoxAvatar_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarOrdenarPartidas();
        }

        private void comboBoxFecha_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarOrdenarPartidas();
        }

        private void comboBoxOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarOrdenarPartidas();
        }

        private void FiltrarOrdenarPartidas()
        {
            string avatarSeleccionado = comboBoxAvatar.SelectedItem?.ToString();
            string fechaSeleccionada = comboBoxFecha.SelectedItem?.ToString();

            var partidasFiltradas = partidas.AsEnumerable();

            if (!string.IsNullOrEmpty(avatarSeleccionado))
            {
                partidasFiltradas = partidasFiltradas.Where(partida => partida.nombre == avatarSeleccionado);
            }

            if (!string.IsNullOrEmpty(fechaSeleccionada))
            {
                partidasFiltradas = partidasFiltradas.Where(partida => partida.fecha == fechaSeleccionada);
            }

            string criterioSeleccionado = comboBoxOrdenar.SelectedItem?.ToString(); // Obtiene el criterio de ordenación

            if (criterioSeleccionado == "Nombre")
            {
                partidasFiltradas = partidasFiltradas.OrderBy(partida => partida.nombre);
            }
            else if (criterioSeleccionado == "Tiempo 1")
            {
                partidasFiltradas = partidasFiltradas.OrderBy(partida => partida.tiempo1);
            }
            else if (criterioSeleccionado == "Tiempo 2")
            {
                partidasFiltradas = partidasFiltradas.OrderBy(partida => partida.tiempo2);
            }
            else if (criterioSeleccionado == "Tiempo 3")
            {
                partidasFiltradas = partidasFiltradas.OrderBy(partida => partida.tiempo3);
            }
            else if (criterioSeleccionado == "Tiempo Total")
            {
                partidasFiltradas = partidasFiltradas.OrderBy(partida => partida.tiempoTotal);
            }
            else if (criterioSeleccionado == "Intento 1")
            {
                partidasFiltradas = partidasFiltradas.OrderBy(partida => partida.intento1);
            }
            else if (criterioSeleccionado == "Intento 2")
            {
                partidasFiltradas = partidasFiltradas.OrderBy(partida => partida.intento2);
            }
            else if (criterioSeleccionado == "Intento 3")
            {
                partidasFiltradas = partidasFiltradas.OrderBy(partida => partida.intento3);
            }
            else if (criterioSeleccionado == "Intentos Total")
            {
                partidasFiltradas = partidasFiltradas.OrderBy(partida => partida.intentosTotales);
            }
            else if (criterioSeleccionado == "Fecha")
            {
                partidasFiltradas = partidasFiltradas.OrderBy(partida => partida.fecha);
            }

            dataGridViewEstaciones.DataSource = partidasFiltradas.ToList();
        }

        private void ActualizarDataGridView()
        {
            dataGridViewEstaciones.DataSource = null;
            dataGridViewEstaciones.DataSource = partidas;

            if (dataGridViewEstaciones.Columns["nombre"] != null)
                dataGridViewEstaciones.Columns["nombre"].HeaderText = "Nombre";
            if (dataGridViewEstaciones.Columns["tiempo1"] != null)
                dataGridViewEstaciones.Columns["tiempo1"].HeaderText = "Tiempo 1";
            if (dataGridViewEstaciones.Columns["tiempo2"] != null)
                dataGridViewEstaciones.Columns["tiempo2"].HeaderText = "Tiempo 2";
            if (dataGridViewEstaciones.Columns["tiempo3"] != null)
                dataGridViewEstaciones.Columns["tiempo3"].HeaderText = "Tiempo 3";
            if (dataGridViewEstaciones.Columns["tiempoTotal"] != null)
                dataGridViewEstaciones.Columns["tiempoTotal"].HeaderText = "Tiempo Total";
            if (dataGridViewEstaciones.Columns["intento1"] != null)
                dataGridViewEstaciones.Columns["intento1"].HeaderText = "Intento 1";
            if (dataGridViewEstaciones.Columns["intento2"] != null)
                dataGridViewEstaciones.Columns["intento2"].HeaderText = "Intento 2";
            if (dataGridViewEstaciones.Columns["intento3"] != null)
                dataGridViewEstaciones.Columns["intento3"].HeaderText = "Intento 3";
            if (dataGridViewEstaciones.Columns["intentosTotales"] != null)
                dataGridViewEstaciones.Columns["intentosTotales"].HeaderText = "Intentos Total";
            if (dataGridViewEstaciones.Columns["fecha"] != null)
                dataGridViewEstaciones.Columns["fecha"].HeaderText = "Fecha";

            comboBoxAvatar.Items.Clear();
            comboBoxFecha.Items.Clear();

            var avataresUnicos = partidas.Select(partida => partida.nombre).Distinct().OrderBy(n => n);
            comboBoxAvatar.Items.AddRange(avataresUnicos.ToArray());

            var fechasUnicas = partidas.Select(partida => partida.fecha).Distinct().OrderBy(f => f);
            comboBoxFecha.Items.AddRange(fechasUnicas.ToArray());
        }

        private void buttonReiniciar_Click(object sender, EventArgs e)
        {
            comboBoxAvatar.Text = "Filtrar por Avatar";
            comboBoxFecha.Text = "Filtrar por Fecha";
            comboBoxOrdenar.Text = "Ordenar por";

            ActualizarDataGridView();
        }
    }
}
