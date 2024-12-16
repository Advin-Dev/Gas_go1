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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter arch = new StreamWriter(Directory.GetCurrentDirectory() + "\\ReporteEntregasXperiodo.htm");
            arch.WriteLine("<html>REPORTE DE ENTREGAS POR GASOLINA<br><br>");
            arch.WriteLine("<table border=1 cellspacing=0>");
            arch.WriteLine("<tr><td>Gasolina</td><td>Cantidad</td><td>Total</td></tr>");

            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=Gas_go;";
            string query = "select gasolina, if(isnull(cantidad),0,cantidad) cantidad, if(isnull(total),0,total) total from gasolinas left join( select id_gasolina, count(id_entrega) cantidad, sum(precioentrega) total from entregas group by id_gasolina)t on t.id_gasolina = gasolinas.id_gasolina";
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
                                    + "</td><td>" + reader.GetString(2) + "</td></tr>");
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
            Uri dir = new Uri(Directory.GetCurrentDirectory() + "\\ReporteEntregasXperiodo.htm");
            webBrowser1.Url = dir;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome", "\"" + Directory.GetCurrentDirectory() + "\\ReporteEntregasXperiodo.htm" + "\"");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Excel", "\"" + Directory.GetCurrentDirectory() + "\\ReporteEntregasXperiodo.htm" + "\"");
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            if (Form1.idioma == 2)
            {
                this.Text = "Deliveries report by Gasoline";
                button1.Text = "Generate";
                button4.Text = "Exit";


            }
            button1_Click(sender, e); //Buscar

        }
    }
}
