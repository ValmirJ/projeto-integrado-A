using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API_OrgaoRegulador;

namespace MegaTime
{
    public partial class Inicio : Form
    {
        public int a = 3;        

        public Inicio()
        {
            InitializeComponent();
        }

        private void close()
        {
            throw new NotImplementedException();
        }

        private void bt_apostar_Click(object sender, EventArgs e)
        {
            Form1 aposta = new Form1(a);
            aposta.ShowDialog();
            Inicio formi = new Inicio();
            formi.Visible = false;
        }

        private void bt_consultar_Click(object sender, EventArgs e)
        {
            Consulta consulta = new Consulta();
            //this.Visible = false;
            consulta.ShowDialog();
        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
