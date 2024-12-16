using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Gas_go1
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            if (Form1.idioma == 2)
            {
                this.Text = "Sales information";
                button1.Text = "Search";
                button2.Text = "Add";
                button3.Text = "Delete";
                button4.Text = "Edit";
                button5.Text = "Exit";

                label1.Text = "Id_sale";
                label2.Text = "Id_clientf";
                label3.Text = "Id_furnituref";
                label4.Text = "Id_userf";
                label5.Text = "Datetime";
                label6.Text = "Salesprice";

                dataGridView1.Columns.Add("Id_sale", "Id_sale");
                dataGridView1.Columns.Add("Id_clientf", "Id_clientf");
                dataGridView1.Columns.Add("Id_furnituref", "Id_furnituref");
                dataGridView1.Columns.Add("Id_userf", "Id_userf");
                dataGridView1.Columns.Add("Datetime", "Datetime");
                dataGridView1.Columns.Add("Salesprice", "Salesprice");
                dataGridView1.Columns[4].Width = 125;






            }

            else
            {
                dataGridView1.Columns.Add("id_entrega", "id_entrega");
                dataGridView1.Columns.Add("id_empleadof", "id_empleadof");
                dataGridView1.Columns.Add("id_gasolinaf", "id_gasolinaf");
                dataGridView1.Columns.Add("id_usuariof", "id_usuariof");
                dataGridView1.Columns.Add("fhentrega", "fhentrega");
                dataGridView1.Columns.Add("precioentrega", "precioentrega");
                dataGridView1.Columns[4].Width = 125;



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
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=Gas_go;";
            string query = "Select * from entregas where id_empleado like '%" + textBox1.Text + "%' or id_gasolina like '%" + textBox1.Text + "%' or id_usuario like '%" + textBox1.Text + "%' or fhentrega like '%" + textBox1.Text + "%' or precioentrega like '%" + textBox1.Text + "%'";
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
                            reader.GetString(3), reader.GetString(4), reader.GetString(5));
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
            string query = "insert into entregas values(null,'" + textBox3.Text + "','" + textBox4.Text
                + "','" + textBox5.Text + "','" + textBox6.Text.Substring(6, 4) + textBox6.Text.Substring(3, 2)
                + textBox6.Text.Substring(0, 2) + textBox6.Text.Substring(11, 2) + textBox6.Text.Substring(14, 2)
                + textBox6.Text.Substring(17, 2) + "','" + textBox7.Text + "')";
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
            string query = "delete from entregas where id_entrega=" + textBox2.Text;
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
            string query = "update entregas set id_empleado='"
                + textBox3.Text.Trim() + "', id_gasolina='"
                + textBox4.Text.Trim() + "', id_usuario='"
                + textBox5.Text.Trim() + "', fhentrega='" + textBox6.Text.Substring(6, 4) + textBox6.Text.Substring(3, 2)
                + textBox6.Text.Substring(0, 2) + textBox6.Text.Substring(11, 2) + textBox6.Text.Substring(14, 2)
                + textBox6.Text.Substring(17, 2) + "', precioentrega='"
                + textBox7.Text.Trim() + "' where id_entrega=" + textBox2.Text;
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

        private void textBox6_Leave(object sender, EventArgs e)
        {
            // VALIDACION FECHA
            if (textBox6.TextLength != 0)
            {
                try
                {
                    DateTime date = Convert.ToDateTime(textBox6.Text);
                }
                catch (Exception xx)
                {
                    if (Form1.idioma == 2)
                    {
                        MessageBox.Show("The date format is not correct: DD/MM/AAAA HH:MM:SS\n" + xx.Message);
                        textBox6.Focus();
                    }
                    else
                    {
                        MessageBox.Show("El formato de fecha no es correcto: DD/MM/AAAA HH:MM:SS\n" + xx.Message);
                        textBox6.Focus();
                    }

                }
            }


        }





        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.TextLength != 0)
            {
                // VALIDACION DECIMALES
                try
                {
                    double num = Convert.ToDouble(textBox7.Text);
                }
                catch (Exception xx)
                {
                    if (Form1.idioma == 2)
                    {
                        MessageBox.Show("The number format is not correct.\n" + xx.Message);
                        textBox7.Focus();
                    }
                    else
                    {
                        MessageBox.Show("El formato numero no es correcto.\n" + xx.Message);
                        textBox7.Focus();
                    }
                }



            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.TextLength != 0)
            {
                // VALIDACION ID
                try
                {
                    double num = Convert.ToDouble(textBox3.Text);
                }
                catch (Exception xx)
                {
                    if (Form1.idioma == 2)
                    {
                        MessageBox.Show("The number format is not correct.\n" + xx.Message);
                        textBox3.Focus();
                    }
                    else
                    {
                        MessageBox.Show("El formato numero no es correcto.\n" + xx.Message);
                        textBox3.Focus();
                    }
                    char[] c = textBox3.Text.ToCharArray();
                    if (textBox3.TextLength > 20)
                    {
                        if (Form1.idioma == 2)
                        {
                            MessageBox.Show("The format must not be greater than 20 digits.");
                            textBox3.Focus();
                        }
                        else
                        {
                            MessageBox.Show("El formato no debe ser mayor a 20 digitos.");
                            textBox3.Focus();
                            return;
                        }
                    }

                }
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {

            if (textBox4.TextLength != 0)
            {
                // VALIDACION ID
                char[] c = textBox4.Text.ToCharArray();
                if (textBox4.TextLength > 20)
                {
                    if (Form1.idioma == 2)
                    {
                        MessageBox.Show("The format must not be greater than 20 digits.");
                        textBox4.Focus();
                    }
                    else
                    {
                        MessageBox.Show("El formato no debe ser mayor a 20 digitos.");
                        textBox4.Focus();
                        return;
                    }

                }
                try
                {
                    double num = Convert.ToInt32(textBox4.Text);
                }
                catch (Exception xx)
                {
                    if (Form1.idioma == 2)
                    {
                        MessageBox.Show("The format is not correct, check again.\n" + xx.Message);
                        textBox4.Focus();
                    }
                    else
                    {
                        MessageBox.Show("El formato no es correcto, verifique de nuevo.\n" + xx.Message);
                        textBox4.Focus();
                    }

                }
            }

        }

        private void textBox5_Leave(object sender, EventArgs e)
        {

            if (textBox5.TextLength != 0)
            {
                // VALIDACION ID
                char[] c = textBox5.Text.ToCharArray();
                if (textBox5.TextLength > 20)
                {
                    if (Form1.idioma == 2)
                    {
                        MessageBox.Show("The format must not be greater than 20 digits.");
                        textBox5.Focus();
                    }
                    else
                    {
                        MessageBox.Show("El formato no debe ser mayor a 20 digitos.");
                        textBox5.Focus();
                        return;
                    }
                }
                try
                {
                    double num = Convert.ToInt32(textBox5.Text);
                }
                catch (Exception xx)
                {
                    if (Form1.idioma == 2)
                    {
                        MessageBox.Show("The format is not correct, check again.\n" + xx.Message);
                        textBox5.Focus();
                    }
                    else
                    {
                        MessageBox.Show("El formato no es correcto, verifique de nuevo.\n" + xx.Message);
                        textBox5.Focus();
                    }

                }
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
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
                    char[] c = textBox2.Text.ToCharArray();
                    if (textBox2.TextLength > 20)
                    {
                        if (Form1.idioma == 2)
                        {
                            MessageBox.Show("The format must not be greater than 20 digits.");
                            textBox2.Focus();
                        }
                        else
                        {
                            MessageBox.Show("El formato no debe ser mayor a 20 digitos.");
                            textBox2.Focus();
                            return;
                        }
                    }

                }
            }
        }
    }
}
