using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JThomas.Tools; //classe de terceiro usada para imprimir o form do recibo

namespace MegaTime
{
    public partial class Recibo : Form
    {
        string recibo;
        string resultado;

        public Recibo(string texto,string premio)
        {
            InitializeComponent();
            recibo = texto;
            resultado = premio;
        }

        private void Recibo_Load(object sender, EventArgs e)
        {
            BackColor = ColorTranslator.FromHtml("#f5f5f5");
            folha.Text = recibo;
            lbl_premio.Text = resultado;
        }

        private void bt_print_Click(object sender, EventArgs e)
        {
            DialogResult imprimir;
            imprimir = MessageBox.Show("Deseja imprimir esse recibo?", "Imprimir", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if(imprimir == DialogResult.Yes)
                    FormPrint.Print(this);
        }
    }
}
