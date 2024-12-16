
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



namespace Gas_go1
{
    public partial class Form2 : System.Windows.Forms.Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        int intentos = 0;


        private void button1_Click(object sender, EventArgs e)
        {
            {
                string connectionString = "datasource=localhost;port=3306;username=root;password=;database=Gas_go;";
                string query = "Select id_usuario, nivel, idioma, usuario from usuarios where cuenta ='" + txt_usuario.Text.Trim()
                             + "' and clave=md5('" + txt_contraseña.Text.Trim() + "');";
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                MySqlDataReader reader;
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Clear();
                if (txt_usuario.Text.Contains("%") || txt_usuario.Text.Contains("'"))
                {
                    MessageBox.Show("No se permite SQL Injection...", "Consulta no válida");
                    return;
                }

                try
                {
                    databaseConnection.Open();
                    reader = commandDatabase.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                        }
                        Form1.usuario = txt_usuario.Text;
                        Form1.id_usuario = Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value.ToString());
                        Form1.nivel = Convert.ToInt32(dataGridView1.Rows[0].Cells[1].Value.ToString());
                        Form1.idioma = Convert.ToInt32(dataGridView1.Rows[0].Cells[2].Value.ToString());
                        Form1.usuarioa = dataGridView1.Rows[0].Cells[3].Value.ToString();
                        this.Close();
                    }
                    else
                    {
                        intentos++;
                        MessageBox.Show("No se encontraron datos");
                        if (intentos >= 3)
                        {
                            button2_Click_1(sender, e);
                        }
                    }
                    databaseConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }





        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Form1.id_usuario == 0) button2_Click_1(sender, e);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("id_usuario", "id_usuario");
            dataGridView1.Columns.Add("cuenta", "cuenta");
            dataGridView1.Columns.Add("clave", "clave");
            dataGridView1.Columns.Add("usuario", "usuario");

        }
    }
}
