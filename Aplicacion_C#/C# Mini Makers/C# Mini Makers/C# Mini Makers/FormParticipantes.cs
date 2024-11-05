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
        List<PartidasSimon> partidas;
        String ruta;
        public FormParticipantes()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.textBoxFichero.ReadOnly = true;
            buttonEliminar.Enabled = false;
            buttonGuardar.Enabled = false;

            textBoxFichero.TextChanged += textBoxFichero_TextChanged;
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
                dataGridViewParticipantes.DataSource = null;

                textBoxFichero.Clear();
            };
            formEliminar.ShowDialog();
        }

        private void buttonSeleccionar_Click(object sender, EventArgs e)
        {
            OpenFileDialog fichero = new OpenFileDialog();
            fichero.Filter = "Ficheros JSON (*.json)|*.json";
            if (fichero.ShowDialog().Equals(DialogResult.OK))
            {
                textBoxFichero.Text = fichero.SafeFileName;
                ruta = fichero.FileName;

                JArray arrayPartidas = JArray.Parse(File.ReadAllText(fichero.FileName));
                partidas = arrayPartidas.ToObject<List<PartidasSimon>>();

                var mostrarNombre = partidas.Select(partidas => new { partidas.nombre }).Distinct().OrderBy(partida => partida.nombre).ToList();

                dataGridViewParticipantes.DataSource = null;
                dataGridViewParticipantes.DataSource = mostrarNombre;

                if (dataGridViewParticipantes.Columns["nombre"] != null)
                {
                    dataGridViewParticipantes.Columns["nombre"].HeaderText = "Nombre";
                }

                dataGridViewParticipantes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
        private void textBoxFichero_TextChanged(object sender, EventArgs e)
        {
            buttonEliminar.Enabled = !string.IsNullOrEmpty(textBoxFichero.Text);
            buttonGuardar.Enabled = !string.IsNullOrEmpty(textBoxFichero.Text);
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            saveFileDialog.Title = "Guardar archivo JSON";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();

                foreach (DataGridViewRow row in dataGridViewParticipantes.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        Dictionary<string, object> rowData = new Dictionary<string, object>();
                        rowData["nombre"] = row.Cells["nombre"].Value ?? string.Empty;
                        data.Add(rowData);
                    }
                }

                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(saveFileDialog.FileName, json);

                dataGridViewParticipantes.DataSource = null;
                textBoxFichero.Clear();

                MessageBox.Show("Datos guardados correctamente.");
            }
        }
    }
}
