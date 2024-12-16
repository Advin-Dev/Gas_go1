using MySql.Data.MySqlClient;
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

namespace Gas_go1
{
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // BOTÓN GENERAR
            int total = 0;
            StreamWriter arch = new StreamWriter(Directory.GetCurrentDirectory() + "\\reporte9.htm");
            arch.WriteLine("<html>REPORTE DE ENTREGAS POR PERIODO<br>Fecha: " + System.DateTime.Now.ToString() + "<br><br>");
            arch.WriteLine("<table border=3 cellspacing=0");
            arch.WriteLine("<tr><td>Id_venta</td><td>Id_clientef</td><td>Id_mueblef</td><td>Id_usuario</td><td>FechaHora</td><td>PrecioVenta</td></tr>");

            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=Gas_go;";
            string query = "Select * from entregas where FHentrega>=" + textBox1.Text.Substring(6, 4) + textBox1.Text.Substring(3, 2) + textBox1.Text.Substring(0, 2) +
                    " and FHentrega<=" + textBox2.Text.Substring(6, 4) + textBox2.Text.Substring(3, 2) + textBox2.Text.Substring(0, 2);

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        arch.WriteLine("<tr><td>" + reader.GetString(0) + "</td><td>" + reader.GetString(1)
                                      + "</td><td>" + reader.GetString(2) + "</td><td>" + reader.GetString(3)
                                      + "</td><td>" + reader.GetString(4) + "</td><td>" + reader.GetString(5)
                                      + "</td></tr>");
                        total++;
                    }
                }
                else
                {
                    if (Form1.idioma == 2)
                    {
                        MessageBox.Show("No data found.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron datos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            arch.WriteLine("</table></html>");
            arch.WriteLine("<br>");
            arch.WriteLine("Total de registros: " + total.ToString());
            arch.Close();
            Uri dir = new Uri(Directory.GetCurrentDirectory() + "\\reporte9.htm");
            webBrowser1.Url = dir;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // BOTÓN CHROME
            System.Diagnostics.Process.Start("Chrome", "\"" + Directory.GetCurrentDirectory() + "\\reporte9.htm" + "\"");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // BOTÓN EXCEL
            System.Diagnostics.Process.Start("excel", "\"" + Directory.GetCurrentDirectory() + "\\reporte9.htm" + "\"");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Today.AddMonths(-1).ToString().Substring(0, 10);
            textBox2.Text = DateTime.Today.ToString().Substring(0, 10);

            // IDIOMA
            if (Form1.idioma == 2)
            {
                button1.Text = "Generate";
                button4.Text = "Exit";
                label1.Text = "Since:";
                label2.Text = "Until:";

                this.Text = "Deliveries' period report";

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
    }
}
