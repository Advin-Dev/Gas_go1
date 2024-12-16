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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter arch = new StreamWriter(Directory.GetCurrentDirectory() + "\\reporte2.htm");
            arch.WriteLine("<html>REPORTE GENERAL DE USUARIOS<br>Fecha:" + System.DateTime.Now.ToString() + "<br><br>");
            arch.WriteLine("<table border=1 cellspacing=0>");
            arch.WriteLine("<tr><td>Id_usuario</td><td>usuario</td><td>Cuenta</td><td>Clave</td><td>Nivel</td><td>Idioma</td></tr>");

            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=Gas_go;";
            string query = "Select * from usuarios";
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
                                    + "</td><td>" + reader.GetString(4) + "</td><td>" + reader.GetString(5) + "</td></tr>");
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
            Uri dir = new Uri(Directory.GetCurrentDirectory() + "\\reporte2.htm");
            webBrowser1.Url = dir;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome", "\"" + Directory.GetCurrentDirectory() + "\\reporte2.htm" + "\"");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Excel", "\"" + Directory.GetCurrentDirectory() + "\\reporte2.htm" + "\"");
        }

        private void Form7_Load(object sender, EventArgs e)
        {

            if (Form1.nivel != 1)
            {
                if (Form1.idioma == 2)
                {
                    MessageBox.Show("Access denied... \nAccess only granted to administrator accounts", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }

                else
                {
                    MessageBox.Show("Acceso denegado... \nSólo cuentas administradoras tinen acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }

            }
            if (Form1.idioma == 2)
            {
                this.Text = "User report";
                button1.Text = "Generate";
                button4.Text = "Exit";


            }
            button1_Click(sender, e); //Buscar

        }
    }
}
