using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TP
{
    class Clinica
    {
        #region Classes e o Contrutor
        IDado novo;//variavel da interface IDado
        ABB PacientesArvore;//Arvore de Pacientes
        ABB MedicosArvore;//Arvore de Pacientes
        Especialidade Ex;//Variavel Ex do tipo Especialidade contendo as lista de cada especialidade alem da tabela hash
        Ordenação Q;//Variavel Q do tipo Ordenação - contendo o metodo de ordenação utilizado no trabalho
        public Medico Med//Metodo get set onde sera armazenado o medico com o maior valor
        { get; set; }
        public float Cofre//Metodo get set onde sera armazenado o valor total recebido pela clinica 
        { get; set; }

        public Clinica()//Metodo contrutor da class Clinica
        {
            PacientesArvore = new ABB();//Intânciando a variavel que sera a Arvore de Pacientes
            MedicosArvore = new ABB();//Intânciando a variavel que sera a Arvore de Medicos
            Ex = new Especialidade();//Intânciando a variavel Ex do tipo Especialidade
            Q = new Ordenação();//Intânciando a variavel Q do tipo Ordenação

            //Chamadas dos metodos onde acontecem a leitura dos arquivos
            CarregarDadosMedicos();
            CarregarDadosPacientes();
            CarregarDadosConsulta();
        }
        #endregion

        #region Metodos de Leitura de Arquivo
        public void CarregarDadosMedicos()//Metodo para leitura do Arquivo dos Medicos
        {
            if (File.Exists("Medicos.txt"))
            {
                StreamReader entrada = new StreamReader("Medicos.txt");
                string linha;
                while ((linha = entrada.ReadLine()) != null)
                {
                    string[] info = linha.Split(';');
                    
                    Medico novo = new Medico(Convert.ToInt32(info[0]), info[1], TipoConsulta(int.Parse(info[2])));
                    MedicosArvore.inserir(novo);//Chamada Do metodo de Inserção da Arvore onde e inserido o medico
                }
            }
        }
        public void CarregarDadosPacientes()//Metodo para leitura do Arquivo dos Pacientes
        {
            if (File.Exists("Pacientes.txt"))
            {
                StreamReader entrada = new StreamReader("Pacientes.txt");
                string linha;
                while ((linha = entrada.ReadLine()) != null)
                {
                    string[] info = linha.Split(';');
                    InserirPessoaNaArvore(info[1], UInt64.Parse(info[0]));//Metodo para inserir cada paciente na Arvore
                }
            }
        }
        public void CarregarDadosConsulta()//Metodo para leitura do Arquivo dos Consultas
        {
            int i = 0;
            if (File.Exists("Consultas.txt"))
            {
                StreamReader entrada = new StreamReader("Consultas.txt");
                string linha;
                while ((linha = entrada.ReadLine()) != null)
                {
                    string[] info = linha.Split(';');
                    switch (int.Parse(info[0]))//Verifica o tipo da especialidade
                    {
                        case 1:
                            InserirConsulta(TipoConsulta(int.Parse(info[0])), i, UInt64.Parse(info[2]), 210, int.Parse(info[1]), DateTime.Parse(info[3]));                            
                            break;
                        case 2:
                            InserirConsulta(TipoConsulta(int.Parse(info[0])), i, UInt64.Parse(info[2]), 200, int.Parse(info[1]), DateTime.Parse(info[3]));
                            break;
                        case 3:
                            InserirConsulta(TipoConsulta(int.Parse(info[0])), i, UInt64.Parse(info[2]), 225, int.Parse(info[1]), DateTime.Parse(info[3]));                            
                            break;
                        case 4:
                            InserirConsulta(TipoConsulta(int.Parse(info[0])), i, UInt64.Parse(info[2]), 185, int.Parse(info[1]), DateTime.Parse(info[3]));
                            break;
                    }
                    i++;
                }
                Ex.InserirListasNaHash();//Metodo para inserir as consultas na tablela hash
                AlocarConsultasNosMedicos();//Metodo para alocar as consultas nos medicos 
            }
        }
        #endregion

        #region Metodos Para Inserção, Alocação
        public void InserirPessoaNaArvore(string n1, ulong n2)
        {
            /*
             * Metodo onde o paciente e inserirndo na arvore vericicandose ela esta vazia ou se existe ja algum paciente nela 
             * para então fazer uma busca para não inserir duas vezes o mesmo paciente na arvore
             */
            novo = new Paciente(n1, n2);
            Nodo busca = PacientesArvore.buscar(novo);
            if (PacientesArvore.raiz == null)
            {
                PacientesArvore.inserir(novo);
            }
            else
            {
                if(busca == null)
                {
                    PacientesArvore.inserir(novo);
                }
                else
                {
                    Paciente aux = (Paciente)(busca.d);
                    if (aux.Cpf != n2)
                    {
                        PacientesArvore.inserir(novo);
                    }
                }
            }
        }
        //TipoConsulta(int.Parse(info[0])), i, UInt64.Parse(info[2]), 210, int.Parse(info[1]), DateTime.Parse(info[3]));
        public void InserirConsulta(string tipo, int id, ulong id_p, float preço, int prioridade,DateTime data)
        {
            Nodo n = PacientesArvore.buscarP(id_p);
            Paciente p = (Paciente)(n.d);
            if (n != null)
            {
                Consulta dado = new Consulta(tipo, id, id_p, preço, prioridade, data);//Criação de uma consulta para sua inserção e uma lista do mesmo tipo de especialidade requerida na consulta
                switch (tipo)
                {
                    case "Clinica Geral":
                        Ex.Ex_Cli.Add(dado);
                        break;
                    case "Ortopedia":
                        Ex.Ex_Ort.Add(dado);
                        break;
                    case "Otorrinolaringologia":
                        Ex.Ex_Ot.Add(dado);
                        break;
                    case "Traumatologia":
                        Ex.Ex_Tra.Add(dado);
                        break;
                    default:
                        Console.Write("Deu Erro 05 - Supera");
                        break;
                }
            }
            else
            {
                Console.Write("Erro 06 - Paciente não Cadastrado");
            }
            
        }
        public void AlocarConsultasNosMedicos()
        {
            List<Consulta> k;
            for (int p = 1; p < 5; p++)
            {
                k = Q.heapSort(Ex.Tabela.Busca((TipoConsulta(p))));// Chamada do Metodo de Ordenação heapSort para ordenar as lista dentro da tabela hash
                MedicosArvore.InicializarAux();
                MedicosArvore.ListaM(TipoConsulta(p), MedicosArvore.raiz);
                int j = MedicosArvore.aux.Count, i = 0;
                foreach (Consulta C in k)//Pecorre as Consultas de um determinado tipo de especialidade 
                {
                    if (i < j)
                    {
                        MedicosArvore.aux[i].Consultas.inserir(C);//Inserindo Consultas nos Medicos
                        i++;
                        if (i == j)
                        {
                            i = 0;
                        }
                    }
                }
            }
        }
        public void AtenderPacientes()//Metodo onde as consultas de cada medico são inserirdas no historico do seu respectivo paciente
        {
            float MaiorValor = 0;

            MedicosArvore.InicializarAux();
            for (int p = 1; p < 5; p++)
                MedicosArvore.ListaM(TipoConsulta(p), MedicosArvore.raiz);

            foreach (Medico Medico in MedicosArvore.aux)//Metodo foreach para pecorrer todos os Medicos
            {
                Elemento number1 = Medico.Consultas.ConsultaTopo();//Metodo não generico para pega a primeira consulta da fila de consultas cada medico
                while (number1 != null)
                {  
                    IDado n0 = number1.d;
                    Consulta n1 = (Consulta)(n0);
                    Nodo n = PacientesArvore.buscarP(n1.ID_Paciente);
                    Paciente n3 = (Paciente)(n.d);
                    if (!n3.Historico.localizar(n1.ID))
                    {
                        Historico h = new Historico(n1.Data, Medico.Nome, Medico.ID, Medico.Ex, n1.Preço, n1.ID, n1.Prioridade);
                        n3.Historico.inserir(h);//inserindo no lista historico do paciente a consulta realizada
                        Medico.Pagamento = n1.Preço/2;//atribui o valor do pagamento ao medico pela metado do valor da consulta
                        Cofre += n1.Preço/2;//A outra metade do pagamento vai para o cofre da clinica
                    }
                    number1 = number1.prox;
                }
            }
            //O foreach a segui sere para indentifica o metodo 
            foreach (Medico Medico in MedicosArvore.aux)
            {
                if(Medico.Pagamento>MaiorValor)
                {
                    MaiorValor = Medico.Pagamento;
                    Med = Medico;
                }
            }
        }
        public string TipoConsulta(int i)//recebe um numero inteiro e retorna uma string do tipo de especialidade correspondente ao numero
        {
            switch (i)
            {
                case 1: return "Ortopedia";

                case 2: return "Otorrinolaringologia";

                case 3: return "Traumatologia";

                case 4: return "Clinica Geral";

                 default:
                     Console.WriteLine("Deu erro, Supera");
                    return " "; 
            }
        }
        #endregion

        #region  Metodos de Impressão
        public void Imprimir1()
        {
            Console.Write(MedicosArvore.ToString());
            Console.Write("\n");
        }
        public void Imprimir2()
        {
            Console.Write("Digite o nome do paciente: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o cpf do paciente: ");
            ulong cpf = UInt64.Parse(Console.ReadLine());
            Paciente p = new Paciente(nome, cpf);
            Console.WriteLine(PacientesArvore.buscar(p));

        }
        public void Imprimir3(string type)
        {
            Console.Write(type);
            Console.Write("\n");
            foreach(Consulta n in Ex.Tabela.Busca(type))
            {
                Console.WriteLine(n.ToString());
            }
        }
        public void Imprimir4()
        {
            Console.Write("Pacientes\n");
            Console.WriteLine(PacientesArvore.preOrdem(PacientesArvore.raiz));
        }
        public void Imprimir5()
        {
            Console.WriteLine("Medico que mais recebeu");
            Console.WriteLine("Nome: " + Med.Nome + " - Id: " + Med.ID + " - Especialidade: " + Med.Ex + " - R$" + Med.Pagamento);
        }
        public void Imprimir6()
        {
            Console.WriteLine("Cofre: R$" + Cofre);
        }
        #endregion
    }
}
