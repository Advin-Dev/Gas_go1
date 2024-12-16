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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter arch = new StreamWriter(Directory.GetCurrentDirectory() + "\\reporte1.htm");
            arch.WriteLine("<html>REPORTE GENERAL DE EMPLEADOS<br>Fecha:" + System.DateTime.Now.ToString() + "<br><br>");
            arch.WriteLine("<table border=1 cellspacing=0>");
            arch.WriteLine("<tr><td>Id_empleado</td><td>Empleado</td><td>Telefono</td><td>Domicilio</td><td>Correo</td><td>Sueldo</td></tr>");

            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=Gas_go;";
            string query = "Select * from empleados";
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
            Uri dir = new Uri(Directory.GetCurrentDirectory() + "\\reporte1.htm");
            webBrowser1.Url = dir;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome", "\"" + Directory.GetCurrentDirectory() + "\\reporte1.htm"
            + "\"");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Excel", "\"" + Directory.GetCurrentDirectory() + "\\reporte1.htm"
            + "\"");
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            if (Form1.idioma == 2)
            {
                this.Text = "Clients report";
                button1.Text = "Generate";
                button4.Text = "Exit";
            }
            button1_Click(sender, e); //Buscar

        }
    }
}
