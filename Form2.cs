using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aula3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnPDP_Click(object sender, EventArgs e)
        {
            PDP MeuPDP = new PDP();
            MeuPDP.LerRequisicoes(@"C:\Users\User\Documents\Mestrado\PMI\Aula02\Aula5\Requisicoes.txt");
            MeuPDP.LerVeiculos(@"C:\Users\User\Documents\Mestrado\PMI\Aula02\Aula5\Veiculos.txt");
            MeuPDP.CriarModelo();
            MeuPDP.Modelo.Write("ModeloPDP.lp");
            //MeuPDP.Modelo.Parameters.TimeLimit = 10;
            MeuPDP.Modelo.Optimize();
            MeuPDP.Modelo.Write("ModeloTestePDP.sol");

            List<Veiculo> veiculos = new List<Veiculo>();

            double total = veiculos.Sum((v) => v.Capacidade);

            veiculos.ForEach((conteudo) => {
                conteudo.Capacidade = 10;
                conteudo.LocalDestino = 11;
                conteudo.LocalOrigem = 20;
                });

            double somaTotal = veiculos.Where(w => w.LocalDestino is 10).Sum((v) => v.Capacidade);
        }
    }
}
