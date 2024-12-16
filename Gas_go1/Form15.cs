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
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                if (Form1.idioma == 2)
                {
                    MessageBox.Show("You have not selected the new language!", "Error when modifting the language.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MessageBox.Show("¡No ha seleccionado el nuevo idioma!", "Error al modificar el idioma.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=Gas_go;";
            string query = "update usuarios set idioma = " + (comboBox1.SelectedIndex + 1).ToString() + " where Id_usuario = " + Form1.id_usuario;
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            int Modificados;
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
                    }
                    else
                    {
                        MessageBox.Show("No existe el usuario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    if (Form1.idioma == 2)
                    {
                        MessageBox.Show("The language has been modified!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("¡El idioma ha sido modificado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }

                }
            }
            catch (Exception ex)
            {
                if (Form1.idioma == 2)
                {
                    MessageBox.Show("Error when modifying the language.\n", "Notice" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Error al modificar el idioma.\n", "Aviso" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }


        }

        private void Form15_Load(object sender, EventArgs e)
        {
            if (Form1.idioma == 2)
            {
                this.Text = "Change of language";
                label1.Text = "Language selection:";
                button1.Text = "Accept";
                button2.Text = "Cancel";

                //idioma    


                this.Text = "Change of language";

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form15_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Form15_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Form1.idioma == 2)
            {
                MessageBox.Show("Restart the system to apply the changes successfully");

            }
            else { MessageBox.Show("Reiniciar para aplicar cambios correctamente"); }
        }
    }
}
