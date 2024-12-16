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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter arch = new StreamWriter(Directory.GetCurrentDirectory() + "\\reporte3.htm");
            arch.WriteLine("<html>REPORTE GENERAL DE GASOLINA<br>Fecha:" + System.DateTime.Now.ToString() + "<br><br>");
            arch.WriteLine("<table border=1 cellspacing=0>");
            arch.WriteLine("<tr><td>Id_gasolina</td><td>gasolina</td><td>Precio</td><td>Tipo</td></tr>");

            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=Gas_go;";
            string query = "Select * from gasolinas";
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
                                    + "</td></tr>");
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron datos.");
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            arch.WriteLine("</table></html>");
            arch.Close();
            Uri dir = new Uri(Directory.GetCurrentDirectory() + "\\reporte3.htm");
            webBrowser1.Url = dir;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome", "\"" + Directory.GetCurrentDirectory() + "\\reporte3.htm" + "\"");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Excel", "\"" + Directory.GetCurrentDirectory() + "\\reporte3.htm" + "\"");
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            if (Form1.idioma == 2)
            {
                this.Text = "Furniture report";
                button1.Text = "Generate";
                button4.Text = "Exit";


            }
            button1_Click(sender, e); //Buscar

        }
    }
}
