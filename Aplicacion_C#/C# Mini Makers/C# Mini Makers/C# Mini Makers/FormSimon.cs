using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
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
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.textBoxFichero.ReadOnly = true;
            buttonEliminar.Enabled = false;
            buttonGuardar.Enabled = false;
            comboBoxFecha.Enabled = false;
            comboBoxNombre.Enabled = false;
            comboBoxOrdenar.Enabled = false;

            textBoxFichero.TextChanged += textBoxFichero_TextChanged;
            comboBoxNombre.SelectedIndexChanged += comboBoxNombre_SelectedIndexChanged;
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
                dataGridViewSimon.DataSource = null;
                comboBoxNombre.Text = "Filtrar por Nombre";
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
                partidas = arrayPartidas.ToObject<List<PartidasSimon>>();

                ActualizarDataGridView();
            }
        }

        private void textBoxFichero_TextChanged(object sender, EventArgs e)
        {
            bool isEnabled = !string.IsNullOrEmpty(textBoxFichero.Text);
            buttonEliminar.Enabled = isEnabled;
            buttonGuardar.Enabled = isEnabled;
            comboBoxFecha.Enabled = isEnabled;
            comboBoxNombre.Enabled = isEnabled;
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

                foreach (DataGridViewRow row in dataGridViewSimon.Rows)
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

                dataGridViewSimon.DataSource = null;
                comboBoxNombre.Text = "Filtrar por Avatar";
                comboBoxFecha.Text = "Filtrar por Fecha";
                comboBoxOrdenar.Text = "Ordenar por";
                textBoxFichero.Clear();

                MessageBox.Show("Datos guardados correctamente.");
            }
        }

        private void comboBoxNombre_SelectedIndexChanged(object sender, EventArgs e)
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
            string nombreSeleccionado = comboBoxNombre.SelectedItem?.ToString();
            string fechaSeleccionada = comboBoxFecha.SelectedItem?.ToString();

            var partidasFiltradas = partidas.AsEnumerable();

            if (!string.IsNullOrEmpty(nombreSeleccionado))
            {
                partidasFiltradas = partidasFiltradas.Where(partida => partida.nombre == nombreSeleccionado);
            }

            if (!string.IsNullOrEmpty(fechaSeleccionada))
            {
                partidasFiltradas = partidasFiltradas.Where(partida => partida.fecha == fechaSeleccionada);
            }

            string criterioSeleccionado = comboBoxOrdenar.SelectedItem?.ToString();

            if (criterioSeleccionado == "Nombre")
            {
                partidasFiltradas = partidasFiltradas.OrderBy(partida => partida.nombre);
            }
            else if (criterioSeleccionado == "Rondas")
            {
                partidasFiltradas = partidasFiltradas.OrderBy(partida => partida.rondas);
            }
            else if (criterioSeleccionado == "Tiempo")
            {
                partidasFiltradas = partidasFiltradas.OrderBy(partida => partida.tiempo);
            }
            else if (criterioSeleccionado == "Fecha")
            {
                partidasFiltradas = partidasFiltradas.OrderBy(partida => partida.fecha);
            }

            dataGridViewSimon.DataSource = partidasFiltradas.ToList();
        }

        private void ActualizarDataGridView()
        {
            dataGridViewSimon.DataSource = null;
            dataGridViewSimon.DataSource = partidas;

            if (dataGridViewSimon.Columns["nombre"] != null)
                dataGridViewSimon.Columns["nombre"].HeaderText = "Nombre";
            if (dataGridViewSimon.Columns["rondas"] != null)
                dataGridViewSimon.Columns["rondas"].HeaderText = "Rondas";
            if (dataGridViewSimon.Columns["tiempo"] != null)
                dataGridViewSimon.Columns["tiempo"].HeaderText = "Tiempo";
            if (dataGridViewSimon.Columns["fecha"] != null)
                dataGridViewSimon.Columns["fecha"].HeaderText = "Fecha";

            dataGridViewSimon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            comboBoxNombre.Items.Clear();
            comboBoxFecha.Items.Clear();

            var nombresUnicos = partidas.Select(partida => partida.nombre).Distinct().OrderBy(n => n);
            comboBoxNombre.Items.AddRange(nombresUnicos.ToArray());

            var fechasUnicas = partidas.Select(partida => partida.fecha).Distinct().OrderBy(f => f);
            comboBoxFecha.Items.AddRange(fechasUnicas.ToArray());
        }

        private void buttonReiniciar_Click(object sender, EventArgs e)
        {
            comboBoxNombre.Text = "Filtrar por Nombre";
            comboBoxFecha.Text = "Filtrar por Fecha";
            comboBoxOrdenar.Text = "Ordenar por";

            ActualizarDataGridView();
        }
    }
}