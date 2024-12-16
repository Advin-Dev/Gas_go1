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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        int estado;

        int[,] estados = {
            { 0,'A', 1},
            { 1,'A', 1},
            { 1,'9', 1},
            { 1,'.', 1},
            { 1,'_', 1},
            { 1,'@', 2},
            { 2,'A', 3},
            { 3,'A', 3},
            { 3,'9', 3},
            { 3,'_', 3},
            { 3,'.', 4},
            { 4,'A', 5},
            { 5,'A', 5},
            { 5,'9', 5},
            { 5,'.', 5},
            { 5,'_', 5} };
        private bool ValidarCampo(string campo)
        {
            int i = 0, c = 0;
            char[] arr = campo.ToCharArray();
            estado = 0;
            checkBox1.Checked = false;
            for (c = 0; c < campo.Length; c++)
            {
                for (i = 0; i < estados.GetLength(0); i++)
                {
                    if (estados[i, 0] == estado &&
                        estados[i, 1] == 'A' &&
                        Char.IsLetter(arr[c]))
                    {
                        estado = estados[i, 2];
                        break;
                    }
                    else if (estados[i, 0] == estado &&
                        estados[i, 1] == '9' &&
                        Char.IsDigit(arr[c]))
                    {
                        estado = estados[i, 2];
                        break;
                    }
                    else if (estados[i, 0] == estado &&
                        estados[i, 1] == '.' && arr[c] == '.')
                    {
                        estado = estados[i, 2];
                        break;
                    }
                    else if (estados[i, 0] == estado &&
                        estados[i, 1] == '@' && arr[c] == '@')
                    {
                        estado = estados[i, 2];
                        break;
                    }
                    else if (estados[i, 0] == estado &&
                        estados[i, 1] == '_' && arr[c] == '_')
                    {
                        estado = estados[i, 2];
                        break;
                    }
                }
                if (i == estados.GetLength(0)) return true;
                //if (estado == 3) radioButton1.Checked = true;
                //if (estado == 4) radioButton2.Checked = true;
                if (estado == 5) checkBox1.Checked = true;
            }
            return false;
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            if (Form1.idioma == 2)
            {
                this.Text = "Client information";
                button1.Text = "Search";
                button2.Text = "Add";
                button3.Text = "Delete";
                button4.Text = "Edit";
                button5.Text = "Exit";

                label1.Text = "Id_employees";
                label2.Text = "Employees";
                label3.Text = "Phone number";
                label4.Text = "Address";
                label5.Text = "Email";
                label6.Text = "Salary";

                dataGridView1.Columns.Add("Id_employees", "Id_employees");
                dataGridView1.Columns.Add("Employees", "Employees");
                dataGridView1.Columns.Add("Phone number", "Phone number");
                dataGridView1.Columns.Add("Address", "Address");
                dataGridView1.Columns.Add("Email", "Email");
                dataGridView1.Columns.Add("Salary", "Salary");
                dataGridView1.Columns[2].Width = 150;
                dataGridView1.Columns[3].Width = 150;
                dataGridView1.Columns[4].Width = 150;
                checkBox1.Text = "Email correct";

            }
            else
            {
                dataGridView1.Columns.Add("id_empleado", "id_empleado");
                dataGridView1.Columns.Add("empleado", "empleado");
                dataGridView1.Columns.Add("telefono", "telefono");
                dataGridView1.Columns.Add("domicilio", "domicilio");
                dataGridView1.Columns.Add("correo", "correo");
                dataGridView1.Columns.Add("sueldo", "sueldo");
                dataGridView1.Columns[2].Width = 150;
                dataGridView1.Columns[3].Width = 150;
                dataGridView1.Columns[4].Width = 150;
                checkBox1.Text = "Correo correcto";
            }


            checkBox1.Text = "Correo correcto";
            button1_Click(sender, e); //Buscar



        }
        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=Gas_go;";
            string query = "Select * from empleados where empleado like '%" + textBox1.Text + "%' or telefono like '%"
                + textBox1.Text + "%' or domicilio like '%" + textBox1.Text + "%' or correo like '%" + textBox1.Text + "%' or sueldo like '%" + textBox1.Text + " %'";
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=Gas_go;";
            string query = "insert into empleados values(null ,'" + textBox3.Text + "','" + textBox4.Text + "','"
                + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')";
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
            string query = "update empelados set empleados='" + textBox3.Text.Trim() + "', telefono='" + textBox4.Text.Trim() + "', domicilio='"
                + textBox5.Text.Trim() + "', correo='" + textBox6.Text.Trim() + "', sueldo='" + textBox7.Text.Trim() +  "' where id_empleado=" + textBox2.Text;
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

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=Gas_go;";
            string query = "delete from empleados where id_empleado=" + textBox2.Text;
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader;
            databaseConnection.Open();
            reader = commandDatabase.ExecuteReader();
            databaseConnection.Close();
            button1_Click(sender, e); //Buscar
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // FIJAR ENTER AL BUSCAR
            if (e.KeyChar == 13) button1_Click(sender, e);
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            char[] c = textBox3.Text.ToCharArray();
            if (textBox3.TextLength > 40)
            {
                if (Form1.idioma == 2)
                {
                    MessageBox.Show("The format should not be greater than 40 letters.");
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

        private void textBox4_Leave(object sender, EventArgs e)
        {
            // TXT LIBERAR TELEFONO
            char[] c = textBox4.Text.ToCharArray();
            if (textBox4.TextLength == 0) { }


            else if (textBox4.TextLength != 10)
            {
                if (Form1.idioma == 2)
                {
                    MessageBox.Show("Wrong format, check again.");
                    textBox4.Focus();
                }
                else
                {
                    MessageBox.Show("Formato incorrecto, verifica de nuevo.");
                    textBox4.Focus();
                    return;
                }

            }
            for (int i = 0; i < textBox4.TextLength; i++)
            {
                if (!Char.IsDigit(c[i]))
                {
                    if (Form1.idioma == 2)
                    {
                        MessageBox.Show("The format is not correct.");
                        textBox4.Focus();
                    }
                    else
                    {
                        MessageBox.Show("El formato no es correcto.");
                        textBox4.Focus();
                        return;
                    }

                }
            }

        }



        private void textBox6_Leave(object sender, EventArgs e)
        {


            ValidarCampo(textBox6.Text);
            if (textBox6.TextLength == 0)
            {
            }

            else if (!checkBox1.Checked)
                if (Form1.idioma == 2)
                {
                    MessageBox.Show("Verifier message:\n" + "The field format is incorrect.");
                    textBox6.Focus();
                }
                else
                {
                    MessageBox.Show("Mensaje del verificador:\n" + "El formato del campo es incorrecto.");
                    textBox6.Focus();
                }

        }

        private void TextBox5_Leave(object sender, EventArgs e)
        {
            // TXT LIBERAR DOMICILIO
            char[] c = textBox5.Text.ToCharArray();
            if (textBox5.TextLength > 60)
            {
                if (Form1.idioma == 2)
                {
                    MessageBox.Show("The format should not be greater than 60 letters.");
                    textBox5.Focus();
                }
                else
                {
                    MessageBox.Show("El formato no debe ser mayor a 60 letras.");
                    textBox5.Focus();
                    return;
                }
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {
            if (ValidarCampo(textBox6.Text))
            {
                if (Form1.idioma == 2)
                {
                    label6.Text = "The format is wrong!";
                    label6.ForeColor = Color.Red;
                }
                else
                {
                    label6.Text = "El formato es incorrecto!";
                    label6.ForeColor = Color.Red;
                }
            }
            else
            {
                if (Form1.idioma == 2)
                {
                    label6.Text = "The format is correct!";
                    label6.ForeColor = Color.Blue;
                }
                else
                {
                    label6.Text = "El formato es correcto...";
                    label6.ForeColor = Color.Blue;
                }

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
           

        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            {

                if (textBox4.TextLength != 0)
                {
                    // VALIDACION SUELDO
                    try
                    {
                        double num = Convert.ToDouble(textBox7.Text);
                    }
                    catch (Exception xx)
                    {
                        if (Form1.idioma == 2)
                        {
                            MessageBox.Show("The number format is not correct.\n" + xx.Message);
                            textBox5.Focus();
                        }
                        else
                        {
                            MessageBox.Show("El formato numero no es correcto.\n" + xx.Message);
                            textBox5.Focus();
                        }

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

