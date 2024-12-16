using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gas_go1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            if (Form1.idioma == 2)
            {
                this.Text = "Gasoline information";
                button1.Text = "Search";
                button2.Text = "Add";
                button3.Text = "Delete";
                button4.Text = "Edit";
                button5.Text = "Exit";

                label1.Text = "Id_gasoline";
                label2.Text = "gasoline";
                label3.Text = "Stock";
                label4.Text = "Price";
                label5.Text = "Type";



                dataGridView1.Columns.Add("id_gasolina", "id_gasolina");
                dataGridView1.Columns.Add("gasolina", "gasolina");
                dataGridView1.Columns.Add("tipo", "tipo");
                dataGridView1.Columns.Add("precio", "precio");
                dataGridView1.Columns.Add("existencia", "existencia");




            }
            else
            {
                dataGridView1.Columns.Add("id_gasolina", "id_gasolina");
                dataGridView1.Columns.Add("gasolina", "gasolina");
                dataGridView1.Columns.Add("precio", "precio");
                dataGridView1.Columns.Add("tipo", "tipo");
                dataGridView1.Columns.Add("existencia", "existencia");
             

            }


            button1_Click(sender, e); //Buscar


        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=Gas_go;";
            string query = "Select * from gasolinas where gasolina like '%" + textBox1.Text + "%' or existencia like '%" + textBox1.Text + "%' or precio like '%" + textBox1.Text + "%' or tipo like '%"  + textBox1.Text + "%'";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader;

            dataGridView1.Rows.Clear();
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2),
                            reader.GetString(3), reader.GetString(4));
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


        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=Gas_go;";
            string query = "insert into gasolinas values(null,'" + textBox3.Text + "','" + textBox4.Text + "','"
                + textBox5.Text + "','" + textBox6.Text + "')";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader;
            databaseConnection.Open();
            reader = commandDatabase.ExecuteReader();
            databaseConnection.Close();
            button1_Click(sender, e); //Buscar

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=Gas_go;";
            string query = "delete from gasolinas where id_gasolina=" + textBox2.Text;
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader;
            databaseConnection.Open();
            reader = commandDatabase.ExecuteReader();
            databaseConnection.Close();
            button1_Click(sender, e); //Buscar

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=Gas_go;";
            string query = "update gasolinas set gasolina='"
                + textBox3.Text + "', precio='"
                + textBox4.Text + "', tipo='"
                + textBox5.Text + "', existencia='"
                + textBox6.Text + 
                 "' where id_gasolina=" + textBox2.Text;
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            button1_Click(sender, e); //Buscar

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // FIJAR ENTER AL BUSCAR
            if (e.KeyChar == 13) button1_Click(sender, e);
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            // TXT LIBERAR GASOLINA

            char[] c = textBox3.Text.ToCharArray();
            if (textBox3.TextLength > 36)
            {
                if (Form1.idioma == 2)
                {
                    MessageBox.Show("The format should not be more than 36 letters.");
                    textBox3.Focus();
                }
                else
                {
                    MessageBox.Show("El formato no debe ser mayor a 36 letras");
                    textBox3.Focus();
                    return;
                }

            }
            for (int i = 0; i < textBox3.TextLength; i++)
            {
                if (!Char.IsLetter(c[i]) && !Char.IsWhiteSpace(c[i]))
                {
                    if (Form1.idioma == 2)
                    {
                        MessageBox.Show("The format is not correct.");
                        textBox3.Focus();
                    }
                    else
                    {
                        MessageBox.Show("El formato no es correcto");
                        textBox3.Focus();
                        return;
                    }

                }
            }
        }



        private void textBox5_Leave(object sender, EventArgs e)
        {

            char[] c = textBox5.Text.ToCharArray();
            if (textBox5.TextLength > 8)
            {
                if (Form1.idioma == 2)
                {
                    MessageBox.Show("The format should not be more than 8 letters.");
                    textBox5.Focus();
                }
                else
                {
                    MessageBox.Show("El formato no debe ser mayor a 8 letras");
                    textBox5.Focus();
                    return;
                }

            }
            for (int i = 0; i < textBox5.TextLength; i++)
            {
                if (!Char.IsLetter(c[i]) && !Char.IsWhiteSpace(c[i]))
                {
                    if (Form1.idioma == 2)
                    {
                        MessageBox.Show("The format is not correct.");
                        textBox5.Focus();
                    }
                    else
                    {
                        MessageBox.Show("El formato no es correcto");
                        textBox5.Focus();
                        return;
                    }

                }
            }

        }

        private void textBox4_Leave(object sender, EventArgs e)
        {

            if (textBox4.TextLength != 0)
            {
                // VALIDACION DECIMALES
                try
                {
                    double num = Convert.ToDouble(textBox4.Text);
                }
                catch (Exception xx)
                {
                    if (Form1.idioma == 2)
                    {
                        MessageBox.Show("The number format is not correct.\n" + xx.Message);
                        textBox4.Focus();
                    }
                    else
                    {
                        MessageBox.Show("El formato numero no es correcto.\n" + xx.Message);
                        textBox4.Focus();
                    }
                }



            }

        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.TextLength != 0)
            {
                // VALIDACION ID
                try
                {
                    double num = Convert.ToDouble(textBox6.Text);
                }
                catch (Exception xx)
                {
                    if (Form1.idioma == 2)
                    {
                        MessageBox.Show("The number format is not correct.\n" + xx.Message);
                        textBox6.Focus();
                    }
                    else
                    {
                        MessageBox.Show("El formato numero no es correcto.\n" + xx.Message);
                        textBox6.Focus();
                    }

                }
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.TextLength != 0)
            {
                // VALIDACION ID
                try
                {
                    double num = Convert.ToDouble(textBox2.Text);
                }
                catch (Exception xx)
                {
                    if (Form1.idioma == 2)
                    {
                        MessageBox.Show("The number format is not correct.\n" + xx.Message);
                        textBox2.Focus();
                    }
                    else
                    {
                        MessageBox.Show("El formato numero no es correcto.\n" + xx.Message);
                        textBox2.Focus();
                    }

                }
            }
        }
    }

}
