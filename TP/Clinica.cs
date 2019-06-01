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
        IDado novo;
        ABB PacientesArvore;
        ABB MedicosArvore;
        Especialidade Ex = new Especialidade();
        public float Cofre
        { get; set; }
        float MaiorValor = 0;
        public Medico Med;
        Ordenação Q;

        public Clinica()
        {
            PacientesArvore = new ABB();
            MedicosArvore = new ABB();
            Q = new Ordenação();
            CarregarDadosMedicos();
            CarregarDadosPacientes();
            CarregarDadosConsulta();
        }
        public void CarregarDadosMedicos()
        {
            if (File.Exists("Medicos.txt"))
            {
                StreamReader entrada = new StreamReader("Medicos.txt");
                string linha;
                while ((linha = entrada.ReadLine()) != null)
                {
                    string[] info = linha.Split(';');
                    Medico novo = new Medico(info[0], info[1], Convert.ToInt32(info[2]));
                    MedicosArvore.inserir(novo);

                }
            }
        }
        public void CarregarDadosPacientes()
        {
            if (File.Exists("Pacientes.txt"))
            {
                StreamReader entrada = new StreamReader("Pacientes.txt");
                string linha;
                while ((linha = entrada.ReadLine()) != null)
                {
                    string[] info = linha.Split(';');
                    InserirPessoaNaArvore(info[0], UInt64.Parse(info[1]));
                }
            }
        }
        public void CarregarDadosConsulta()
        {
            if (File.Exists("Consultas.txt"))
            {
                StreamReader entrada = new StreamReader("Consultas.txt");
                string linha;
                while ((linha = entrada.ReadLine()) != null)
                {
                    string[] info = linha.Split(';');
                    novo = new Paciente(info[0], UInt64.Parse(info[1]));
                    InserirConsulta(novo, int.Parse(info[3]), float.Parse(info[4]), info[2] , int.Parse(info[5]),DateTime.Parse(info[6]));
                }
                Ex.InserirListasNaHash();
                AlocarConsultasNosMedicos();
            }
        }
        public void InserirPessoaNaArvore(string n1, ulong n2)
        {
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
                        Console.Write("\nPaciente cadastrada com sucesso.\n");

                    }
                    else
                    {
                        Console.Write("\nPaciente já esta cadastrado.\n");
                    }
                }
            }
        }
        public void InserirConsulta(IDado d,int id,float preço, string tipoE, int prioridade,DateTime data)
        {
            Nodo n = PacientesArvore.buscar(d);
            Paciente p = (Paciente)(d);
            if (n != null)
            {
                novo = new Consulta(p, id, tipoE, preço, prioridade, data);
                switch (tipoE)
                {
                    case "Clinica Geral":
                        Ex.Inserir_Consultas(novo);
                        break;
                    case "Ortopedia":
                        Ex.Inserir_Consultas(novo);
                        break;
                    case "Otorrinolaringologia":
                        Ex.Inserir_Consultas(novo);
                        break;
                    case "Traumatologia":
                        Ex.Inserir_Consultas(novo);
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
        public List<Consulta> ordenar(string tipo)
        {
            return Q.heapSort(Ex.Tabela.Busca(tipo));
        }
        public void AlocarConsultasNosMedicos()
        {
            List<Consulta> k = ordenar("Clinica Geral");
            MedicosArvore.InicializarAux();
            MedicosArvore.ListaM("Clinica Geral", MedicosArvore.raiz);
            int j = MedicosArvore.aux.Count, i = 0;
            foreach(Consulta C in k)
            {
                if(i<j)
                {
                    MedicosArvore.aux[i].Consultas.inserir(C);
                    i++;
                    if(i==j)
                    {
                        i = 0;
                    }
                }
            }
            foreach(Medico m in MedicosArvore.aux)
            {
                Console.WriteLine(m.ToString());
            }
            k = ordenar("Ortopedia");
            MedicosArvore.InicializarAux();
            MedicosArvore.ListaM("Ortopedia", MedicosArvore.raiz);
            j = MedicosArvore.aux.Count; i = 0;
            foreach (Consulta C in k)
            {
                if (i < j)
                {
                    MedicosArvore.aux[i].Consultas.inserir(C);
                    i++;
                    if (i == j)
                    {
                        i = 0;
                    }
                }
            }
            foreach (Medico m in MedicosArvore.aux)
            {
                Console.WriteLine(m.ToString());
            }
            k = ordenar("Otorrinolaringologia");
            MedicosArvore.InicializarAux();
            MedicosArvore.ListaM("Otorrinolaringologia", MedicosArvore.raiz);
            j = MedicosArvore.aux.Count; i = 0;
            foreach (Consulta C in k)
            {
                if (i < j)
                {
                    MedicosArvore.aux[i].Consultas.inserir(C);
                    i++;
                    if (i == j)
                    {
                        i = 0;
                    }
                }
            }
            foreach (Medico m in MedicosArvore.aux)
            {
                Console.WriteLine(m.ToString());
            }
            k = ordenar("Traumatologia");
            MedicosArvore.InicializarAux();
            MedicosArvore.ListaM("Traumatologia", MedicosArvore.raiz);
            j = MedicosArvore.aux.Count; i = 0;
            foreach (Consulta C in k)
            {
                if (i < j)
                {
                    MedicosArvore.aux[i].Consultas.inserir(C);
                    i++;
                    if (i == j)
                    {
                        i = 0;
                    }
                }
            }
            foreach (Medico m in MedicosArvore.aux)
            {
                Console.WriteLine(m.ToString());
            }
        }
        public void AtenderPacientes()
        {
            MedicosArvore.InicializarAux();
            MedicosArvore.ListaM("Clinica Geral", MedicosArvore.raiz);
            MedicosArvore.ListaM("Ortopedia", MedicosArvore.raiz);
            MedicosArvore.ListaM("Otorrinolaringologia", MedicosArvore.raiz);
            MedicosArvore.ListaM("Traumatologia", MedicosArvore.raiz);

            foreach (Medico Medico in MedicosArvore.aux)
            {
                Elemento number1 = Medico.Consultas.ConsultaTopo();
                while (number1 != null)
                {
                    
                    IDado n0 = number1.d;
                    Consulta n1 = (Consulta)(n0);
                    IDado n2 = (n1.P);
                    Nodo n = PacientesArvore.buscar(n2);
                    Paciente n3 = (Paciente)(n.d);
                    if (!n3.Historico.localizar(n1.ID))
                    {
                        Historico h = new Historico(n1.Data, Medico.Nome, Medico.ID, Medico.Ex, n1.Preço, n1.ID, n1.Prioridade);
                        n3.Historico.inserir(h);
                        Medico.Pagamento = n1.Preço/2;
                        Cofre += n1.Preço;
                    }
                    number1 = number1.prox;
                }
            }
            foreach (Medico Medico in MedicosArvore.aux)
            {

                if(Medico.Pagamento>MaiorValor)
                {
                    MaiorValor = Medico.Pagamento;
                    Med = Medico;
                }
            }
        }
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
    }
}
