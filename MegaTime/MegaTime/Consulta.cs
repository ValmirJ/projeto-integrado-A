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
    public partial class Consulta : Form
    {
        EndPoint endpoint = new EndPoint();
        Recibo recibo;
        string premiostr;   //String da mensagem do prêmio
        long prot;
        //int[] nApostados = new int[20]; // vetor criado para armazenar os numeros apostados. Todos os seus 20 valores se iniciam em 0

        string[] napostados; // vetor que recebe todas dezenas apostadas através do Split usado na função obterTodasDezenasApostadas da API;
        int[] times = new int[25];//criar vetor com 25 posições (0 a 24) para administrar times selecionados
        //a posição 0 do vetor representará o time 1. a posição 24 o time 25
        //se o valor de uma tal posição for 0 = time não selecionado; se o valor for 2 quer dizer que foram escolhidos 2 numeros para o tal time

        //declarando o vetor que armazena os nomes dos times
        string[] nomeTimes = new string[25] { "Atlético Mineiro", "Atlético Paranaense", "Bahia","Botafogo","Ceará"
        ,"Corinthians","Coritiba","Cruzeiro","Flamengo","Fluminense","Fortaleza","Goiás","Grêmio","Guarani","Internacional"
        ,"Náutico","Palmeiras","Paraná Clube","Ponte preta","Santa Cruz","Santos","São Paulo","Sport","Vasco","Vitória"};

        int nAcertados, nTimeSorteado;
        float valorPremio, valorPremioDezenas, valorPremioTime;
        
/* ----------------------------------------------------------------------Funções---------------------------------------------------------------------------------*/
        public Consulta()
        {
            InitializeComponent();
        }
        private void zerarVetorTimes() // procedimento que zera o vetor, pois o times.Initialize() não está funcionando como o esperado;
        {
            for (int i=0; i <times.Length; i++)
            {
                times[i] = 0;
            }
        }
        private void vetorizarDezenas() // procedimento verifica a qual time pertence as dezenas apostadas e soma 1
        {                                                  // na posição do time no vetor times[];
            zerarVetorTimes();
            int time;
            for (int i = 0; i < napostados.Length; i++)       
            {
                time = (int)Math.Ceiling(double.Parse(napostados[i]) / 4);

                times[time - 1]++;
            }
        }

        private void dezenasTimeSorteado(string timeSorteado) //Procedimento que descobre quantas vezes foi apostado nas dezenas do time sorteado
        {
            string[] nomesTimesStr = new string[25] { "Atletico Mineiro", "Atletico Paranaense", "Bahia","Botafogo","Ceara"
        ,"Corinthians","Coritiba","Cruzeiro","Flamengo","Fluminense","Fortaleza","Goias","Gremio","Guarani","Internacional"
        ,"Nautico","Palmeiras","Parana Clube","Ponte Preta","Santa Cruz","Santos","Sao Paulo","Sport","Vasco da Gama","Vitoria"};

            int indice;
            indice = System.Array.IndexOf(nomesTimesStr, timeSorteado); //Descoque qual é o incice comparando uma string com um vetor string;
            nTimeSorteado = times[indice];
        }

        public int nTimesEscolhidos()
        {
            int n = 0;
            for (int i = 0; i < 25; i++)
            {
                if (times[i] > 0)
                {
                    n++;
                }
            }
            return n;
        }

        public double calcularAposta(int qtdDezenas) // Função que calcula aposta;
        {
            double precoTotal = 5.00;

            for (int i = 10; i <= qtdDezenas; i++)
            {
                if (i > 10 && i <= 15)
                {
                    precoTotal += 0.75;
                }
                else
                {
                    if (i > 15 && i < 20)
                    {
                        precoTotal += 3.00;
                    }
                    else
                    {
                        if (i == 20)
                            precoTotal += 7.00;
                    }
                }
            }
            if (nTimesEscolhidos() > 5)
                precoTotal += (nTimesEscolhidos() - 5) * 1.25;

            return precoTotal;
        }
/* ---------------------------------------------------------------Eventos-------------------------------------------------------------------- */

        private void Consulta_Load(object sender, EventArgs e)
        {
            BackColor = ColorTranslator.FromHtml("#F5F5F5");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.KeyChar = char.MinValue;
        }

        private void bt_consultar_Click(object sender, EventArgs e)
        {
            try
            {
                nAcertados = 0; nTimeSorteado = 0; valorPremio = 0; valorPremioDezenas = 0; valorPremioTime = 0;
                prot = long.Parse(textBox1.Text);

                if (endpoint.obterTodasDezenasApostadas(prot) != null)
                {
                    napostados = endpoint.obterTodasDezenasApostadas(prot).Split(',');  //recebe todas dezenas apostadas pela API
                    vetorizarDezenas(); //"vetoriza" o vetor times de acordo com as dezenas


                    prot = long.Parse(textBox1.Text);
                    string recibostr = string.Empty;

                    recibostr += "=== MegaTime ===\n\n";//coloca nome do jogo
                    recibostr += "\n\nProtocolo da aposta:\n" + textBox1.Text;
                    recibostr += "\n\nDezenas apostadas:";
                    recibostr += "\n" + endpoint.obterTodasDezenasApostadas(prot) + "\n";

                    for (int i = 0; i < 25; i++)
                    {
                        if (times[i] > 0)
                        {
                            recibostr += "\nQuantidade de dezenas apostadas em " + nomeTimes[i] + ": " + times[i].ToString();
                        }
                    }
                    recibostr += "\n\n\n\nValor da aposta: " + "R$ " + calcularAposta(napostados.Length);

                    try
                    {
                        string[] nsorteados = endpoint.ObterTodosNumerosSorteados().Split(',');
                        string tsorteado = endpoint.obterNomeTimeSorteado();

                        for (int i = 0; i < napostados.Length; i++)
                        {
                            if (nsorteados.Contains(napostados[i]))
                            {
                                nAcertados++;
                            }
                        }

                        dezenasTimeSorteado(tsorteado); // Função que compara strings e soma 1 quando a dezena pertencer ao time apostado
                        // envia como paraâmetro o time sorteado e vetor string de números apostados;
                        if (nAcertados >= 3)
                        {
                            valorPremioDezenas = (float)endpoint.obterPremioPorAcertos(nAcertados);
                        }

                        valorPremioTime = 5 * nTimeSorteado;
                        valorPremio = valorPremioDezenas + valorPremioTime;

                        if (valorPremio > 0)
                        {
                            premiostr = "Parabéns sua aposta foi sorteada!\n\n" + "Valor premiado por dezenas acertadas: R$ " + valorPremioDezenas + "\nValor premiado por dezenas do time sorteado: R$ " + valorPremioTime + "\n\nValor Total: R$ " + valorPremio.ToString("#0.00");
                        }

                        else
                        {
                            premiostr = "Bilhete não sorteado";
                        }
                    }
                    catch
                    {
                        premiostr = "O sorteio ainda não aconteceu";
                    }

                    recibo = new Recibo(recibostr, premiostr);
                    recibo.ShowDialog();
                }
                else
                    MessageBox.Show("O número de protocolo não foi encontrado", "Protocolo inválido");
            }
            catch
            {
                MessageBox.Show("Digite apenas números");
            }
        }

        private void bt_return_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
