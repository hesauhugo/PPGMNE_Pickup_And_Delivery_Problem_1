using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gurobi;
using ProblemasDeTransporte;

namespace Aula3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ProblemaDoTransporte MeuProblema;
        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
            MeuProblema.Aleatorio = new Random(MeuProblema.Semente);
            progressBar1.PerformStep();
            MeuProblema.CriarCustosOfertasDemandas();
            progressBar1.PerformStep();
            MeuProblema.Ambiente = new GRBEnv();
            MeuProblema.Modelo = new GRBModel(MeuProblema.Ambiente);
            progressBar1.PerformStep();
            Stopwatch Cronometro = new Stopwatch();
            Cronometro.Start();
            progressBar1.PerformStep();
            MeuProblema.CriarModeloMatematico();
            MeuProblema.Modelo.Write("ModeloTeste.lp");
            progressBar1.PerformStep();
            MeuProblema.Modelo.Parameters.TimeLimit = 10;
            MeuProblema.Modelo.Optimize();
            progressBar1.PerformStep();
            MeuProblema.Modelo.Write("ModeloTeste10.sol");
            Cronometro.Stop();
            progressBar1.PerformStep();
            lbl_tempo_resolucao.Text = "Tempo para resolução(" + Cronometro.ElapsedMilliseconds.ToString() + ") ms";
            progressBar1.Value =0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MeuProblema = new ProblemaDoTransporte();
            txt_numero_origens.Text = MeuProblema.NumeroOrigens.ToString();
            txt_numero_destinos.Text = MeuProblema.NumeroDestinos.ToString();
            txt_numero_transbordos.Text = MeuProblema.NumeroTransbordos.ToString();
            txt_semente.Text = MeuProblema.Semente.ToString();

        }

        private void txt_numero_origens_TextChanged(object sender, EventArgs e)
        {
            int result = 0;
            int.TryParse(txt_numero_origens.Text, out result);
            MeuProblema.NumeroOrigens = result;
            txt_numero_origens.Text = MeuProblema.NumeroOrigens.ToString();
        }

        private void txt_numero_destinos_TextChanged(object sender, EventArgs e)
        {
            int result = 0;
            int.TryParse(txt_numero_destinos.Text, out result);
            MeuProblema.NumeroDestinos = result;
            txt_numero_destinos.Text = MeuProblema.NumeroDestinos.ToString();
        }

        private void txt_numero_transbordos_TextChanged(object sender, EventArgs e)
        {
            int result = 0;
            int.TryParse(txt_numero_transbordos.Text, out result);
            MeuProblema.NumeroTransbordos = result;
            txt_numero_transbordos.Text = MeuProblema.NumeroTransbordos.ToString();

        }

        private void txt_semente_TextChanged(object sender, EventArgs e)
        {
            int result = 0;
            int.TryParse(txt_semente.Text, out result);
            MeuProblema.Semente = result;
            txt_semente.Text = MeuProblema.Semente.ToString();
        }
    }
}
namespace ProblemasDeTransporte
{
    class ProblemaDoTransporte
    {
        private int numeroOrigens =50;
        public  int NumeroOrigens 
        { 
            get => numeroOrigens;
            set
            {
                if (value < 50)
                    numeroOrigens = value;
                else
                    numeroOrigens = 50;
            }
        }
        private int numeroDestinos = 200;
        public int NumeroDestinos 
        { 
            get => numeroDestinos;
            set {
                if (value < 200)
                    numeroDestinos = value;
                else
                    numeroDestinos = 200;
                  } 
        }
        private int numeroTransbordos = 40;
        public int NumeroTransbordos
        {
            get => numeroTransbordos;
            set => numeroTransbordos = value;
        }
        private int semente = 1;
        public int Semente
        {
            get => semente;
            set => semente = value;
        }
        public int[,] MatrizCustosVariaveisOrigensDestinos;
        public int[,] MatrizCustosVariaveisOrigensTranbordos;
        public int[,] MatrizCustosVariaveisTransbordosDestinos;
        public int[] CustosHabilitacaoOrigens;
        public int[] CustosHabilitacaoTransbordo;
        public int[] Ofertas;
        public int[] Demandas;
        public int[] CapacidadeTransbordo;
        public Random Aleatorio;
        public GRBEnv Ambiente;
        public GRBModel Modelo;
        GRBVar[,] X; //Transporte entre Origem-Destino
        GRBVar[,] Y; //Transporte entre Origem-Transbordo
        GRBVar[,] W; //Transporte entre Transbordo-Destino
        GRBVar[] Z; //Habilitação de Origem
        GRBVar[] V; //Habilitação de Transbordo
        

        public ProblemaDoTransporte(int numOrigens, int numDestinos, int numTransbordos, int semente)
        {
            numeroOrigens = numOrigens;
            numeroDestinos = numDestinos;
            numeroTransbordos = numTransbordos;
            Aleatorio = new Random(semente);
            CriarCustosOfertasDemandas();
            Ambiente = new GRBEnv();
            Modelo = new GRBModel(Ambiente);
        }

        public ProblemaDoTransporte()
        {

        }

        public void CriarMatrizCustosVariaveisOrigensDestinos()
        {
            MatrizCustosVariaveisOrigensDestinos = new int[numeroOrigens, numeroDestinos];
            for (int i = 0; i < numeroOrigens; i++)
            {
                for (int j = 0; j < numeroDestinos; j++)
                {
                    MatrizCustosVariaveisOrigensDestinos[i, j] = Aleatorio.Next(10, 91);
                }
            }
        }
        public void CriarMatrizCustosVariaveisOrigensTransbordos()
        {
            MatrizCustosVariaveisOrigensTranbordos = new int[numeroOrigens, numeroTransbordos];
            for (int i = 0; i < numeroOrigens; i++)
            {
                for (int k = 0; k < numeroTransbordos; k++)
                {
                    MatrizCustosVariaveisOrigensTranbordos[i, k] = Aleatorio.Next(10, 91);
                }
            }
        }
        public void CriarMatrizCustosVariaveisTransbordosDestinos()
        {
            MatrizCustosVariaveisTransbordosDestinos = new int[numeroTransbordos, numeroDestinos];
            for (int k = 0; k < numeroTransbordos; k++)
            {
                for (int j = 0; j < numeroDestinos; j++)
                {
                    MatrizCustosVariaveisTransbordosDestinos[k, j] = Aleatorio.Next(10, 91);
                }
            }
        }
        public void CriarCustosHabilitacaoOrigens()
        {
            CustosHabilitacaoOrigens = new int[NumeroOrigens];
            for (int i = 0; i < NumeroOrigens; i++)
            {
                CustosHabilitacaoOrigens[i] = Aleatorio.Next(1500, 6000);
            }
        }
        public void CriarCustosHabilitacaoTransbordos()
        {
            CustosHabilitacaoTransbordo = new int[NumeroTransbordos];
            for (int k = 0; k < NumeroTransbordos; k++)
            {
                CustosHabilitacaoTransbordo[k] = Aleatorio.Next(1500, 6000);
            }
        }
        public void CriarOfertas()
        {
            Ofertas = new int[NumeroOrigens];
            for (int i = 0; i < NumeroOrigens; i++)
            {
                Ofertas[i] = Aleatorio.Next(500, 901);
            }
        }
        public void CriarDemandas()
        {
            Demandas = new int[NumeroDestinos];
            for (int j = 0; j < NumeroDestinos; j++)
            {
                Demandas[j] = Aleatorio.Next(50, 201);
            }
        }
        public void CriarCapacidadesTransbordos()
        {
            CapacidadeTransbordo = new int[NumeroTransbordos];
            for (int k = 0; k < NumeroTransbordos; k++)
            {
                CapacidadeTransbordo[k] = Aleatorio.Next(3000, 6001);
            }
        }
        public void CriarCustosOfertasDemandas()
        {
            //CriarMatrizCustosVariaveisOrigensDestinos();
            CriarMatrizCustosVariaveisOrigensTransbordos();
            CriarMatrizCustosVariaveisTransbordosDestinos();
            CriarCustosHabilitacaoOrigens();
            CriarCustosHabilitacaoTransbordos();
            CriarOfertas();
            CriarDemandas();
            CriarCapacidadesTransbordos();
        }
        public void CriarModeloMatematico()
        {
            //CriarVariaveisDecisaoX();
            CriarVariaveisDecisaoZ();
            CriarVariaveiesDecisaoW();
            CriarVariaveisDecisaoV();
            CriarVariaveisDecisaoY();
            CriarRestricoesOferta();
            CriarRestricoesDemanda();
            CriarRestricoesHabilitacaoTransbordos();
            CriarRestricoesPreservacaoFluxoTransbordo();
        }
        public void CriarVariaveisDecisaoX()
        {
            X = new GRBVar[NumeroOrigens, NumeroDestinos];
            for (int i = 0; i < NumeroOrigens; i++)
            {
                for (int j = 0; j < NumeroDestinos; j++)
                {
                    X[i, j] = Modelo.AddVar(0, double.MaxValue, MatrizCustosVariaveisOrigensDestinos[i, j], GRB.CONTINUOUS, $"x_{i}_{j}");
                }
            }
        }
        public void CriarVariaveisDecisaoZ()
        {
            Z = new GRBVar[NumeroOrigens];
            for (int i = 0; i < NumeroOrigens; i++)
            {
                Z[i] = Modelo.AddVar(0, 1, CustosHabilitacaoOrigens[i], GRB.BINARY, $"z_{i}");
            }
        }
        public void CriarVariaveisDecisaoY()
        {
            Y = new GRBVar[NumeroOrigens, NumeroTransbordos];
            for (int i = 0; i < NumeroOrigens; i++)
            {
                for (int k = 0; k < NumeroTransbordos; k++)
                {
                    Y[i, k] = Modelo.AddVar(0, double.MaxValue, MatrizCustosVariaveisOrigensTranbordos[i, k], GRB.CONTINUOUS, $"y_{i}_{k}");
                }
            }
        }
        public void CriarVariaveiesDecisaoW()
        {
            W = new GRBVar[NumeroTransbordos, NumeroDestinos];
            for (int k = 0; k < NumeroTransbordos; k++)
            {
                for (int j = 0; j < NumeroDestinos; j++)
                {
                    W[k, j] = Modelo.AddVar(0, double.MaxValue, MatrizCustosVariaveisTransbordosDestinos[k, j], GRB.CONTINUOUS, $"w_{k}_{j}");
                }
            }
        }
        public void CriarVariaveisDecisaoV()
        {
            V = new GRBVar[NumeroTransbordos];
            for (int k = 0; k < NumeroTransbordos; k++)
            {
                V[k] = Modelo.AddVar(0, 1, CustosHabilitacaoTransbordo[k], GRB.BINARY, $"v_{k}");
            }
        }
        public void CriarRestricoesOferta()
        {
            GRBLinExpr expr = new GRBLinExpr();
            for (int i = 0; i < NumeroOrigens; i++)
            {
                expr.Clear();
                for (int k = 0; k < NumeroTransbordos; k++)
                {
                    expr.AddTerm(1, Y[i, k]);
                }
                Modelo.AddConstr(expr <= Ofertas[i] * Z[i], $"Of_{i}");
            }
        }
        public void CriarRestricoesDemanda()
        {
            GRBLinExpr expr = new GRBLinExpr();
            for (int j = 0; j < NumeroDestinos; j++)
            {
                expr.Clear();
                for (int k = 0; k < NumeroTransbordos; k++)
                {
                    expr.AddTerm(1, W[k, j]);
                }
                Modelo.AddConstr(expr >= Demandas[j], $"De_{j}");
            }
        }
        public void CriarRestricoesPreservacaoFluxoTransbordo()
        {
            GRBLinExpr Chegada = new GRBLinExpr();
            GRBLinExpr Saida = new GRBLinExpr();
            for (int k = 0; k < NumeroTransbordos; k++)
            {
                Chegada.Clear();
                for (int i = 0; i < NumeroOrigens; i++)
                {
                    Chegada.AddTerm(1, Y[i, k]);
                }
                Saida.Clear();
                for (int j = 0; j < NumeroDestinos; j++)
                {
                    Saida.AddTerm(1, W[k, j]);
                }
                Modelo.AddConstr(Chegada == Saida, $"Fl_{k}");
            }
        }
        public void CriarRestricoesHabilitacaoTransbordos()
        {
            GRBLinExpr Chegada = new GRBLinExpr();
            for (int k = 0; k < NumeroTransbordos; k++)
            {
                Chegada.Clear();
                for (int i = 0; i < NumeroOrigens; i++)
                {
                    Chegada.AddTerm(1, Y[i, k]);
                }
                Modelo.AddConstr(Chegada <= CapacidadeTransbordo[k] * V[k], $"HT_{k}");
            }
        }
    }
}
