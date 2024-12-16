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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }




        private void Form3_Load(object sender, EventArgs e)
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
            // idioma
            if (Form1.idioma == 2)
            {

                this.Text = "User information";

                button1.Text = "Search";
                button2.Text = "Add";
                button3.Text = "Delete";
                button4.Text = "Edit";
                button5.Text = "Exit";

                label1.Text = "Id_user";
                label2.Text = "User";
                label3.Text = "Account";
                label4.Text = "Password";
                label5.Text = "Level";
                label6.Text = "Language";

                // FORMULARIO LOAD
                dataGridView1.Columns.Add("Id_user", "Id_user");
                dataGridView1.Columns.Add("User", "User");
                dataGridView1.Columns.Add("Account", "Account");
                dataGridView1.Columns.Add("Password", "Password");
                dataGridView1.Columns.Add("Level", "Level");
                dataGridView1.Columns.Add("Language", "Language");


            }
            else
            {
                dataGridView1.Columns.Add("id_usuario", "id_usuario");
                dataGridView1.Columns.Add("usuario", "usuario");
                dataGridView1.Columns.Add("cuenta", "cuenta");
                dataGridView1.Columns.Add("clave", "clave");
                dataGridView1.Columns.Add("nivel", "nivel");
                dataGridView1.Columns.Add("Idioma", "Idioma");

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
            string query = "Select * from usuarios where usuario like '%" + textBox1.Text + "%' or cuenta like '%"
                + textBox1.Text + "%' or clave like '%" + textBox1.Text + "%' or nivel like '%"
                + textBox1.Text + "%' or idioma like '%" + textBox1.Text + "%'";
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
            string query = "insert into usuarios values(null,'" + textBox3.Text + "','" + textBox4.Text + "',md5('"
                + textBox5.Text + "'),'" + textBox6.Text + "','" + textBox7.Text + "')";
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
            string query = "delete from usuarios where Id_usuario=" + textBox2.Text;
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
            string query = "update usuarios set usuario='"
                + textBox3.Text.Trim() + "', cuenta='"
                + textBox4.Text.Trim() + "', clave='"
                + textBox5.Text.Trim() + "', nivel='"
                + textBox6.Text.Trim() + "', idioma='"
                + textBox7.Text.Trim() + "' where id_usuario=" + textBox2.Text;
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

        private void textBox3_Leave(object sender, EventArgs e)
        {
            // TXT LIBERAR USUARIO
            char[] c = textBox3.Text.ToCharArray();
            if (textBox3.TextLength > 40)
            {
                if (Form1.idioma == 2)
                {
                    MessageBox.Show("The format should not be more than 40 letters.");
                    textBox3.Focus();
                }
                else
                {
                    MessageBox.Show("El formato no debe ser mayor a 40 letras.");
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
                        MessageBox.Show("El formato no es correcto.");
                        textBox3.Focus();
                        return;
                    }

                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // FIJAR ENTER AL BUSCAR
            if (e.KeyChar == 13) button1_Click(sender, e);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            // TXT LIBERAR cuents
            char[] c = textBox4.Text.ToCharArray();
            if (textBox4.TextLength > 20)
            {
                if (Form1.idioma == 2)
                {
                    MessageBox.Show("The format must  not be greater than 20 characters.");
                    textBox4.Focus();
                }
                else
                {
                    MessageBox.Show("El formato no debe ser mayor a 20 caracteres.");
                    textBox4.Focus();
                    return;
                }

            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            // TXT LIBERAR CONTRASEÑA
            char[] c = textBox5.Text.ToCharArray();
            if (textBox5.TextLength > 128)
            {
                if (Form1.idioma == 2)
                {
                    MessageBox.Show("The format must  not be greater than 128 characters.");
                    textBox5.Focus();
                }
                else
                {
                    MessageBox.Show("El formato no debe ser mayor a 128 caracteres.");
                    textBox5.Focus();
                    return;
                }

            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {

            if (textBox6.TextLength != 0)
            {
                // VALIDACION NIVEL
                char[] c = textBox6.Text.ToCharArray();
                if (textBox6.TextLength > 1)
                {
                    if (Form1.idioma == 2)
                    {
                        MessageBox.Show("The format must not be greater than 1 digits.");
                        textBox6.Focus();
                    }
                    else
                    {
                        MessageBox.Show("El formato no debe ser mayor a 1 digitos");
                        textBox6.Focus();
                        return;
                    }

                }
                try
                {
                    int num = Convert.ToInt32(textBox6.Text);
                }
                catch (Exception xx)
                {
                    if (Form1.idioma == 2)
                    {
                        MessageBox.Show("The format is not correct, check again.\n" + xx.Message);
                        textBox6.Focus();
                    }
                    else
                    {
                        MessageBox.Show("El formato no es correcto, verifique de nuevo.\n" + xx.Message);
                        textBox6.Focus();
                    }

                }
            }

        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.TextLength != 0)
            {
                // VALIDACION IDIOMA
                char[] c = textBox7.Text.ToCharArray();
                if (textBox7.TextLength > 1)
                {
                    if (Form1.idioma == 2)
                    {
                        MessageBox.Show("The format must not be greater than 1 digits.");
                        textBox7.Focus();
                    }
                    else
                    {
                        MessageBox.Show("El formato no debe ser mayor a 1 digitos.");
                        textBox7.Focus();
                        return;
                    }

                }
                try
                {
                    int num = Convert.ToInt32(textBox7.Text);
                }
                catch (Exception xx)
                {
                    if (Form1.idioma == 2)
                    {
                        MessageBox.Show("The format is not correct, check again.\n" + xx.Message);
                        textBox7.Focus();
                    }
                    else
                    {
                        MessageBox.Show("El formato no es correcto, verifique de nuevo.\n" + xx.Message);
                        textBox7.Focus();
                    }

                }
            }

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
