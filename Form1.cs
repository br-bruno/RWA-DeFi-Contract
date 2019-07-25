using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OiMundo

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Conta contaBruno = new Conta();
            contaBruno.titular = "Bruno";
            contaBruno.numero = 1;
            contaBruno.Deposita(100.0);
            MessageBox.Show("Saldo: " + contaBruno.saldo);
            contaBruno.Saca(50.0);
            MessageBox.Show("Saldo: " + contaBruno.saldo);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Conta mauricio = new Conta();
            mauricio.saldo = 2000.0;

            Conta copia = mauricio;
            copia.saldo = 3000.0;

            MessageBox.Show("mauricio = " + mauricio.saldo);
            MessageBox.Show("copia = " + copia.saldo);
        }
    }
}
