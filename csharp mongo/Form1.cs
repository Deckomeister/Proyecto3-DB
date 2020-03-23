using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharp_mongo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            Inicio Inicio = new Inicio();
            MessageBox.Show("Bienvenido a la Administracion");
            this.Hide();
            Inicio.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Inicio2 Inicio2 = new Inicio2();
            MessageBox.Show("Bienvenido Cliente");
            this.Hide();
            Inicio2.Show();
        }
    }
}
