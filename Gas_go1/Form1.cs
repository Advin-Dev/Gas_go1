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
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string usuario = "", usuarioa;
        public static int id_usuario = 0, nivel = 0, idioma = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 login = new Form2();
            login.ShowDialog();
            if (idioma == 2) { ingles(); }
            this.label1.Text = "Usuario Ingresado: " + usuarioa;


        }

        private void empelados_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form3 f3 = new Form3())
            {
                f3.ShowDialog(this);
            }
        }

        private void reporte1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form7 f7 = new Form7())
            {
                f7.ShowDialog(this);
            }
        }

        private void usuario_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form4 f4 = new Form4())
            {
                f4.ShowDialog(this);
            }
        }

        private void gasolinas_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form5 f5 = new Form5())
            {
                f5.ShowDialog(this);
            }
        }

        private void entregas_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form6 f6 = new Form6())
            {
                f6.ShowDialog(this);
            }
        }

        private void reporte2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form8 f8 = new Form8())
            {
                f8.ShowDialog(this);
            }
        }

        private void reporte3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form9 f9 = new Form9())
            {
                f9.ShowDialog(this);
            }
        }

        private void reporte4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form10 f10 = new Form10())
            {
                f10.ShowDialog(this);
            }
        }

        private void reporte5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form11 f11 = new Form11())
            {
                f11.ShowDialog(this);
            }
        }

        private void reporte6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form12 f12 = new Form12())
            {
                f12.ShowDialog(this);
            }
        }

        private void reporte7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form13 f13 = new Form13())
            {
                f13.ShowDialog(this);
            }

        }

        private void reporte8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form14 f14 = new Form14())
            {
                f14.ShowDialog(this);
            }
        }

        private void idiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (Form15 f15 = new Form15())
            {
                f15.ShowDialog(this);
            }

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
        }

        public void ingles()
        {
            this.Text = "Gasoline(English)";

            this.archivoToolStripMenuItem.Text = "File";
            this.empelados_ToolStripMenuItem.Text = "Employees";
            this.usuario_ToolStripMenuItem.Text = "Users";
            this.gasolinas_ToolStripMenuItem.Text = "Gasoline";
            this.entregas_ToolStripMenuItem.Text = "Deliveries";
            this.salirToolStripMenuItem.Text = "Exit";

            this.reportesToolStripMenuItem.Text = "Reports";
            this.reporte1ToolStripMenuItem.Text = "Employee report";
            this.reporte2ToolStripMenuItem.Text = "Users report";
            this.reporte3ToolStripMenuItem.Text = "Gasoline report";
            this.reporte4ToolStripMenuItem.Text = "Deliveries report";
            this.reporte5ToolStripMenuItem.Text = "Deliveries report by each Employee";
            this.reporte6ToolStripMenuItem.Text = "Deliveries report by each user";
            this.reporte7ToolStripMenuItem.Text = "Deliveries report by each gasoline";
            this.reporte8ToolStripMenuItem.Text = "Deliveries w/employee summary report";
            this.reporteDeEntregasPorPeriodoToolStripMenuItem.Text = "Deliveries' period report";

            this.perfilToolStripMenuItem.Text = "Profile";
            this.idiomaToolStripMenuItem.Text = "Language";
            this.contraseñaToolStripMenuItem.Text = "Password";
            this.label1.Text = "Current User: " + usuarioa;
        }

        private void reporteDeEntregasPorPeriodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form17 f17 = new Form17())
            {
                f17.ShowDialog(this);
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void contraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (form16 f16 = new form16())
            {
                f16.ShowDialog(this);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



    }
}

