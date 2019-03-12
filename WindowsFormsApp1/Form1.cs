using System;
using FatturaElettronica.Defaults;
using FatturaElettronica.Forms;
using System.Windows.Forms;
using FatturaElettronica.Ordinaria;

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
            var f = FatturaOrdinaria.CreateInstance(Instance.Privati);
            f.FatturaElettronicaHeader.DatiTrasmissione.CodiceDestinatario = "1234567";
            f.FatturaElettronicaHeader.DatiTrasmissione.PECDestinatario = "pec";
            var form = new FatturaElettronicaForm();
            form.FatturaElettronica = f;
            form.ShowDialog();

        }
    }
}
