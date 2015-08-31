using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API_OrgaoRegulador;
using System.IO;

namespace MegaTime
{
    public partial class Form1 : Form
    {
        //declarando o vetor que armazena os nomes dos times
        string[] nomeTimes = new string[25] { "Atlético Mineiro", "Atlético Paranaense", "Bahia","Botafogo","Ceará"
        ,"Corinthians","Coritiba","Cruzeiro","Flamengo","Fluminense","Fortaleza","Goiás","Grêmio","Guarani","Internacional"
        ,"Náutico","Palmeiras","Paraná Clube","Ponte preta","Santa Cruz","Santos","São Paulo","Sport","Vasco da Gama","Vitória"};


        int[] nApostados = new int[20]; // vetor criado para armazenar os numeros apostados. Todos os seus 20 valores se iniciam em 0
        // e de acordo com a escolha do usuário cada posição do vetor ganhará o numero selecionado por ele
        // a funcao addNumero() atribuirá o numero escolhido para a posição certa do vetor

        int countns=0;//contador para numero total apostados

        int[] times = new int[25];//criar vetor com 25 posições (0 a 24) para administrar times selecionados
        //a posição 0 do vetor representará o time 1. a posição 24 o time 25
        //se o valor de uma tal posição for 0 = time não selecionado; se o valor for 2 quer dizer que foram escolhidos 2 numeros para o tal time

        EndPoint endpoint = new EndPoint();//instanciando a classe EndPoints da API reguladora
        long protocolo;
        public Form1(int a)
        {
            InitializeComponent();
            string xx = a.ToString();
        }

/* ---------------------------------------------Funções------------------------------------------------------------------*/
        
        private void circularButton()
        {
            GraphicsPath formato = new GraphicsPath();
            formato.AddEllipse(0, 0, bt_n01.Width, bt_n01.Height);

            foreach (Control d in this.Controls)    //para cada controle (objeto, componente) "d" dentro de "this"
            {
                if (d is Panel)  //se controle "d" for um painel
                {
                    foreach (Control c in d.Controls)   //para cada controle "c" dentro de "d" (lembrando que "d" só entra aqui se for um painel)
                    {
                        if (c is Button)    // se "c" for um botao
                        {
                            ((Button)c).Region = new Region(formato);   //botao ganha uma região (espécie de máscara) com parametros (formato)
                            ((Button)c).BackColor = Color.Transparent;
                            ((Button)c).Cursor = Cursors.Hand;
                        }
                    }
                }
            }
        }

        private int addNumero(string valorstr)   //função que adiciona o numero ao textbox
        {  //achei melhor separar isso numa função, assim podemos passar como parametro o valor escrito nos botoes dos times

            if (countns < 20)
            {   //só entra, pela ultima vez, se o numero de dezenas escolhidos for 19 ou menos, evitando a escolha de 21 ou mais dezenas


                if (int.Parse(valorstr) < 10)//se valorstr<10 acrescenta um "0" na frente para ficar "01" no textbox e nao "1"
                {
                    valorstr = "0" + valorstr;

                }

                bool contem = false;//cria uma booleana que serve para indicar se a dezena escolhida ja foi ou nao adicionada

                for (int i = 0; i < 20; i++)//for que percorre indiretamente o vetor nApostados[]
                {
                    if (nApostados[i] == int.Parse(valorstr))//verifica se o numero ja foi adicionado
                    {
                        contem = true;//se ele ja foi adicionado entao "contem" se torna verdadeira
                    }
                }

                if (!contem)//se "contem" for falsa, ou seja, o numero escolhido ainda nao foi adicionado
                {
                    dezena_setButtonColor(valorstr);
                    nApostados[countns] = int.Parse(valorstr);// nApostados[] na posicao de valor countns recebe o valorstr (dezena escolhida) em forma de inteiro
                    panelcolor(nApostados[countns]);
                    atualizarTextBox(countns);//função que atualiza o textbox que mostra as dezenas apostadas
                    contaTimes(int.Parse(valorstr),true);//função que soma em cada posição
                    countns++;//countns ganha mais 1
                    lbl_valor.Text = "R$ "+calcularAposta().ToString("#,##0.00");//atualiza o label e estipula o valor da aposta 
                    lbl_nr_apostas.Text = countns.ToString();//// atualiza o label que diz para o usuario quantas dezenas ele escolheu
                    return 1;
                }
            }
            return 0;
        }

        public void atualizarTextBox(int pos)//atualiza o textbox que mostra os numeros apostados colocando os valores do vetor nApostados nesse textbox e um "-" para separar
        {
            string adicional;

            if (countns > 0)
                adicional = "-";
            else
                adicional = "";

            if (nApostados[pos] < 10)
                selected_n.Text += adicional + "0" + nApostados[pos].ToString();
            else
                selected_n.Text += adicional + nApostados[pos].ToString();
        }

        public void limpar()
        {
            for (int i = 0; i < 20; i++)
            {
                nApostados[i] = 0;
            }

            for (int i = 0; i < 25; i++)
            {
                times[i] = 0;
            }
            selected_n.Text = string.Empty;
            lbl_valor.Text = "R$ 5,00";
            countns = 0;
            lbl_nr_apostas.Text = countns.ToString();
            apostar.Enabled = false;

            foreach (Control d in this.Controls)    //para cada controle (objeto, componente) "d" dentro de "this"
            {
                if (d is Panel)  //se controle "d" for um painel
                {
                    d.BackColor = Color.Transparent;
                    foreach (Control c in d.Controls)   //para cada controle "c" dentro de "d" (lembrando que "d" só entra aqui se for um painel)
                    {
                        if (c is Button)    // se "c" for um botao
                        {
                            ((Button)c).BackColor = Color.Transparent;//reinicia cores dos botoes redondos
                        }
                    }
                }
            }
        }

        private int contaTimes(int nEscolhido, bool altera)//recebe nescolhido pelo usuario
        {
            double x = Math.Ceiling((double)nEscolhido / 4);// x recebe nescolhido/4 arredondado para o proximo numero inteiro possivel
            if(altera)//se for pra somar no vetor
                times[((int)x) - 1]++;// o time a qual "nEscolhido" pertence ganha +1. Assim é possível saber se esse time
            // foi escolhido(caso valor>0) e quantas dezenas desse time foram escolhidas(Valor).
            //MessageBox.Show("Time: "+x+" Soma total: "+times[((int)x) - 1].ToString());
            //
            return (int)x;
        }

        private string dezenasString()//transforma dezenas apostadas armazenadas em nApostados[] em uma só string
        {
            string dezenas = "";

            for (int i = 0; i < nApostados.Length; i++)
            {
                if (nApostados[i] > 0)
                    dezenas += nApostados[i].ToString() + ",";
            }
            dezenas = dezenas.Substring(0, dezenas.Length - 1);

            return dezenas;
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

        public bool validar()
        {
            int ntimes = nTimesEscolhidos();

            if (ntimes > 4)//se numero de times maior ou igual a 5 retorna verdadeiro
            {
                return true;
            }
            else//se nao retorna falso e mostra uma msg
            {
                MessageBox.Show("Aposte em pelo menos 5 times!\nVocê apostou em " + ntimes + " times.", "Número de times insuficientes");
                return false;
            }

        }

        public double calcularAposta()
        {
            double precoTotal = 5.00;
            int ndezenas = countns;

            for (int i = 10; i <= ndezenas; i++)
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

            //MessageBox.Show(precoTotal.ToString());

            return precoTotal;
        }

        private void criarRecibo()//método que criará uma string que será enviada por parametros ao formulário "Recibo"
        {   //usar listbox futuramente
            string recibostr = string.Empty;//inicia uma string 
            recibostr += "=== MegaTime ===\n\n";//coloca nome do jogo
            recibostr += "\n\nProtocolo da aposta:\n" + protocolo.ToString();//coloca o protocolo na string
            recibostr += "\n\nDezenas apostadas:";
            recibostr += "\n" + dezenasString() + "\n";

            for (int i = 0; i < 25; i++)
            {
                if (times[i] > 0)
                {
                    recibostr += "\nQuantidade de dezenas apostadas em "+ nomeTimes[i] + ": " + times[i];
                }
            }

            recibostr += "\n\n\n\nValor da aposta: " + "R$ " + calcularAposta().ToString("#0.00");

            Recibo recibo = new Recibo(recibostr,string.Empty);//abre form recibo enviando essa grande string como parametro
            recibo.Show();//mostra o form recibo
        }

        public void panelcolor (int n)
        {
            switch (contaTimes(n,false))
            {
                case 1: panel1.BackColor = ColorTranslator.FromHtml("#757575"); break;
                case 2: panel2.BackColor = ColorTranslator.FromHtml("#757575"); break;
                case 3: panel3.BackColor = ColorTranslator.FromHtml("#757575"); break;
                case 4: panel4.BackColor = ColorTranslator.FromHtml("#757575"); break;
                case 5: panel5.BackColor = ColorTranslator.FromHtml("#757575"); break;
                case 6: panel6.BackColor = ColorTranslator.FromHtml("#757575"); break;
                case 7: panel7.BackColor = ColorTranslator.FromHtml("#757575"); break;
                case 8: panel8.BackColor = ColorTranslator.FromHtml("#757575"); break;
                case 9: panel9.BackColor = ColorTranslator.FromHtml("#757575"); break;
                case 10: panel10.BackColor = ColorTranslator.FromHtml("#757575"); break;
                case 11: panel11.BackColor = ColorTranslator.FromHtml("#757575"); break;
                case 12: panel12.BackColor = ColorTranslator.FromHtml("#757575"); break;
                case 13: panel13.BackColor = ColorTranslator.FromHtml("#757575"); break;
                case 14: panel14.BackColor = ColorTranslator.FromHtml("#757575"); break;
                case 15: panel15.BackColor = ColorTranslator.FromHtml("#757575"); break;
                case 16: panel16.BackColor = ColorTranslator.FromHtml("#757575"); break;
                case 17: panel17.BackColor = ColorTranslator.FromHtml("#757575"); break;
                case 18: panel18.BackColor = ColorTranslator.FromHtml("#757575"); break;
                case 19: panel19.BackColor = ColorTranslator.FromHtml("#757575"); break;
                case 20: panel20.BackColor = ColorTranslator.FromHtml("#757575"); break;
                case 21: panel21.BackColor = ColorTranslator.FromHtml("#757575"); break;
                case 22: panel22.BackColor = ColorTranslator.FromHtml("#757575"); break;
                case 23: panel23.BackColor = ColorTranslator.FromHtml("#757575"); break;
                case 24: panel24.BackColor = ColorTranslator.FromHtml("#757575"); break;
                case 25: panel25.BackColor = ColorTranslator.FromHtml("#757575"); break;
            }
        }

        private int gerarNrRandomico()
        {
            Random random = new Random();
            int nr;

            nr = random.Next(1, 101);
            return nr;
        }

/*----------------------------------------------Eventos------------------------------------------------------------------------------*/
        
        private void Form1_Load(object sender, EventArgs e)
        {
            circularButton();  //Chama a função que arredonda os botões
            selected_n.TextAlign = HorizontalAlignment.Center;//define alinhamento da barra de dezenas para centro
            if (selected_n.Enabled == false)       //Cor do textbox de saida
                selected_n.BackColor = Color.White;
        }

        private void bt_add_Click(object sender, EventArgs e)// Evento dos 100 botões
        {
            //int valor = (int)selected_n1.Value;
            addNumero(selected_n1.Value.ToString());//chamada da funcao "addnumero" passando como parametro o valor, em string, de selected_n1
        
        }


        private void lbl_nr_apostas_TextChanged(object sender, EventArgs e)
        {
            if (countns >= 10)
            {
                apostar.Enabled = true;
            }
        }

        private void dezena_setButtonColor(string numeroDezena)//muda a cor do botao redondo (das dezenas do form1) de acordo com o estado de aposta
        {
            //trecho que define cor de seleção nos botoes que representam as dezenas
            foreach (Control d in this.Controls)    //para cada controle (objeto, componente) "d" dentro de "this"
            {
                if (d is Panel)  //se controle "d" for um painel
                {
                    foreach (Control c in d.Controls)   //para cada controle "c" dentro de "d" (lembrando que "d" só entra aqui se for um painel)
                    {
                        if (c is Button)    // se "c" for um botao
                        {
                            if (int.Parse(((Button)c).Text) == int.Parse(numeroDezena))//quando achar irá chamar a função de atualizar cor que mudará a cor do botao
                            {
                                if (((Button)c).BackColor == Color.Transparent)
                                    ((Button)c).BackColor = Color.FromArgb(39, 39, 39);
                                else
                                    ((Button)c).BackColor = Color.Transparent;
                                break; //para o for
                            }
                        }
                    }
                }
            }

        }

        private void bt_numeros_Click(object sender, EventArgs e)
        {
            Button botao = (Button)sender;//atribui o botao do evento a "botao", assim podemos manusear o botao do evento
                                            //sem mesmo saber o nome dele e por tanto usar esse método de click em todos os 100 botoes
            if (botao.Text.Substring(0,1)=="0")//se o botao tiver como primeiro caracter "0"
                addNumero(botao.Text.Substring(1,botao.Text.Length-1));//envia o texto do botao para a função addNumero retirando o zero do comeco
            else
                addNumero(botao.Text);//envia o texto do botao para a função addNumero
            
        }

        private void apostar_Click(object sender, EventArgs e)// evento do botao apostar
        {

            if (validar()) // se for verdadeiro é porque o apostador atingiu os requisitos
            {
                try
                {
                    protocolo = endpoint.gravarAposta(dezenasString());//grava a aposta e recebe o valor do protocolo
                    //MessageBox.Show("Protocolo: "+protocolo.ToString());
                    criarRecibo();
                    limpar();
                }
                catch (DirectoryNotFoundException)
                {
                    MessageBox.Show("Pasta TEMP não foi encontrada em disco C:","Erro ao gravar aposta");
                }
            }
            else
            {
                limpar();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpar();
        }

        private void bt_random_Click(object sender, EventArgs e)
        {
            int nr;
            do
            {
                nr = gerarNrRandomico();
            }
            while (addNumero(nr.ToString()) == 0 && countns<20);
        }

        private void bt_returnP_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bts_numeros_MouseEnter(object sender, EventArgs e)
        {
            Button btSelecionado;
            btSelecionado = (Button)sender;

            btSelecionado.ForeColor = Color.Black;
        }

        private void bts_numeros_MouseLeave(object sender, EventArgs e)
        {
            Button btSelecionado;
            btSelecionado = (Button)sender;

            btSelecionado.ForeColor = Color.White;
        }

        private void bt_info_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Para fazer uma aposta você deve escolher no mínimo 10 dezenas e 5 times, podendo apostar em até 20 dezenas e 20 times, porém, com um acrescimo de preço para cada valor acima do mínimo.", "Informações sobre o jogo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (selected_n.Text != "")
            {
                DialogResult abandonarAposta;
                abandonarAposta = MessageBox.Show("Deseja sair sem terminar a aposta?", "Saindo...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (abandonarAposta == DialogResult.No)
                    e.Cancel = true;                     
            }

        }

    }
}

