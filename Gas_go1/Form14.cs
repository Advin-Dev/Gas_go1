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
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // BOTÓN GENERAR 

            StreamWriter arch = new StreamWriter(Directory.GetCurrentDirectory() + "\\reporte8.htm");
            arch.WriteLine("<html>REPORTE SUMARIO DE ENTREGAS<br>Fecha:" + System.DateTime.Now.ToString() + "<br><br>");
            arch.WriteLine("<table border=3 cellspacing=0>");
            arch.WriteLine("<tr><td>Id_empleado</td><td>Empleado</td><td>Telefono</td><td>Correo</td><td>Domicilio</td><td>Id_entrega</td><td>Id_empleadof</td><td>Id_gasolinaf</td><td>Id_usuariof</td><td>FHentrega</td><td>PrecioEntrega</td></tr>");
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=Gas_go;";
            string query = "select * from empleados, entregas where empleados.id_empleado=entregas.id_empleado order by empleado, id_entrega";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader;
            int actual = 0;
            int anterior = 0;
            int cant = 0;
            int total = 0;
            double subtotal = 0;
            double grantotal = 0;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        actual = Convert.ToInt32(reader.GetString(0));
                        if (actual == anterior)
                        {
                            arch.WriteLine("<tr><td></td><td></td><td></td><td></td><td></td><td>" + reader.GetString(6)
                                + "</td><td>" + reader.GetString(7) + "</td><td>" + reader.GetString(8)
                                + "</td><td>" + reader.GetString(9) + "</td><td>" + reader.GetString(10)
                                + "</td><td>" + reader.GetString(5)
                                + "</td></tr>");
                        }
                        else
                        {
                            if (anterior != 0)
                            {
                                arch.WriteLine("<tr><td>Son</td><td>" + cant.ToString()
                                + "</td><td>Ventas</td><td></td><td></td><td></td><td></td><td></td>"
                                + "<td><td></td><td></td><td></td><td>Subtotal del cliente:</td><td>" + subtotal.ToString("0.00")
                                + "</td></tr><tr><td> </td><tr>");
                                grantotal = grantotal + subtotal;
                                subtotal = 0.00;
                                cant = 0;
                            }
                            arch.WriteLine("<tr><td>" + reader.GetString(0) + "</td><td>" + reader.GetString(1)
                                + "</td><td>" + reader.GetString(2) + "</td><td>" + reader.GetString(4)
                                + "</td><td>" + reader.GetString(3) + "</td><td>" + reader.GetString(6)
                                + "</td><td>" + reader.GetString(7) + "</td><td>" + reader.GetString(8)
                                + "</td><td>" + reader.GetString(9) + "</td><td>" + reader.GetString(10)
                                + "</td><td>" + reader.GetString(5) + "</td></tr>");

                        }
                        subtotal = subtotal + Convert.ToDouble(reader.GetString(5));
                        cant++;
                        total++;
                        anterior = actual;
                    } // LLAVE WHILE
                    arch.WriteLine("<tr><td>Son</td><td>" + cant.ToString()
                                + "</td><td>Ventas</td><td></td><td></td><td></td><td></td><td></td>"
                                + "<td><td></td><td></td><td></td><td>Subtotal del cliente:</td><td>" + subtotal.ToString("0.00")
                                + "</td></tr><tr><td> </td><tr>");
                    grantotal = grantotal + subtotal;
                }
                else
                {
                    MessageBox.Show("No se econtraron datos." + "Aviso" + MessageBoxIcon.Warning);
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            arch.WriteLine("</table></html>");
            arch.WriteLine("Total de ventas: " + total.ToString() + ". Sumatoria de los costos: " + grantotal.ToString("0.00"));
            arch.Close();
            Uri dir = new Uri(Directory.GetCurrentDirectory() + "\\reporte8.htm");
            webBrowser1.Url = dir;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome", "\"" + Directory.GetCurrentDirectory() + "\\reporte8.htm" + "\"");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Excel", "\"" + Directory.GetCurrentDirectory() + "\\reporte8.htm" + "\"");
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            if (Form1.idioma == 2)
            {
                this.Text = "Summary report";
                button1.Text = "Generate";
                button4.Text = "Exit";


            }
            button1_Click(sender, e); //Buscar

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
