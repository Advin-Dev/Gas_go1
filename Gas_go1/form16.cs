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
    public partial class form16 : Form
    {
        public form16()
        {
            InitializeComponent();
        }

        private void Form16_Load(object sender, EventArgs e)
        {
            if (Form1.idioma == 2)
            {
                this.Text = "Change of password";
                label1.Text = "Current password:";
                label2.Text = "New password:";
                label3.Text = "Confirm Password:";

                button1.Text = "Accept";
                button2.Text = "Cancel";

                //CONTRASEÑA

                this.Text = "Change of password";

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // BOTÓN ACEPTAR
            if (textBox2.Text != textBox3.Text)
            {
                if (Form1.idioma == 2)
                {
                    MessageBox.Show("New password not confirmed!", "Error modifiying password.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MessageBox.Show("Nueva contraseña no confirmada!", "Error al modificar la contraseña.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=Gas_go;";
            string query = "update usuarios set Clave = md5('" + textBox2.Text + "') where Cuenta = '" + Form1.usuario + "' and Clave = md5('" + textBox1.Text.Trim() + "');";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            int Modificados;
            if (textBox1.Text.Contains("%") || textBox1.Text.Contains("'"))
            { // SQL INJECTION
                MessageBox.Show("No se permite SQL Injection...", "Consulta no válidada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                databaseConnection.Open();
                Modificados = commandDatabase.ExecuteNonQuery();
                databaseConnection.Close();
                if (Modificados == 0)
                {
                    if (Form1.idioma == 2)
                    {
                        MessageBox.Show("No user exists.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Focus();
                    }
                    else
                    {
                        MessageBox.Show("No existe el usuario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Focus();
                    }

                }
                else
                {
                    if (Form1.idioma == 2)
                    {
                        MessageBox.Show("Password modified.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("contraseña cambiada.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }

                }
            }
            catch (Exception ex)
            {
                if (Form1.idioma == 2)
                {
                    MessageBox.Show("The password is not correct.\n", "Notice" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("La contraseña no es correcta.\n", "Aviso" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
