using System;
using FatturaElettronica;
using FatturaElettronica.Impostazioni;
using FatturaElettronica.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = Fattura.CreateInstance(Instance.PubblicaAmministrazione);
            var form = new FatturaElettronicaForm();
            form.FatturaElettronica = f;
            form.ShowDialog();

        }
    }
}
