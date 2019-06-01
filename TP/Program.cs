using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace TP
{
    class Program
    {
        static void Main(string[] args)
        {
            Clinica PDB = new Clinica();
            Menu(PDB);
            Console.Write("Fim");
            Console.ReadKey();
        }
        static void Menu(Clinica PDB)
        {
            char op = 'N';
            while (op != 'Y')
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Menu");
                    Console.WriteLine("1 - Atender pacientes: ");
                    Console.WriteLine("2 - Imprimir arvores de medicos com suas repectivas consultas");
                    Console.WriteLine("3 - Imprimir o historico de consultas do paciente desejado");
                    Console.WriteLine("4 - Imprimir todas as consultas da especialidade desejada");
                    Console.WriteLine("5 - Imprimir historico de consultas dos pacientes");
                    Console.WriteLine("6 - Imprimir Medico que recebeu maior valor");
                    Console.WriteLine("7 - Imprimir valor total recebido pela clinica");
                    Console.WriteLine("8 - Sair");
                    int op2 = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    switch (op2)
                    {
                        case 1:
                            Console.WriteLine("Deseja iniciar o atendimento aos pacientes? ");
                            Console.WriteLine("Y - Sim  N - Não");
                            char op3 = Convert.ToChar(Console.ReadLine());
                            if (op3 == 'Y' || op3 == 'y')
                            {
                                PDB.AtenderPacientes();
                                Console.ReadKey();
                            }
                            break;
                        case 2:
                            PDB.Imprimir1();
                            Console.ReadKey();
                            break;
                        case 3:
                            PDB.Imprimir2();
                            Console.ReadKey();
                            break;
                        case 4:
                            Console.Write("Digite a Especialidade:");
                            string es = Console.ReadLine();
                            PDB.Imprimir3(es);
                            Console.ReadKey();
                            break;
                        case 5:
                            PDB.Imprimir4();
                            Console.ReadKey();
                            break;
                        case 6:
                            Console.WriteLine("Nome: "+PDB.Med.Nome+" - Id: "+ PDB.Med.ID + " - Especialidade: " + PDB.Med.Ex + " - R$" + PDB.Med.Pagamento);
                            Console.ReadKey();
                            break;
                        case 7:
                            Console.WriteLine("Total em R$" + PDB.Cofre);
                            Console.ReadKey();
                            break;
                        case 8:
                            op = 'Y';
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Error");
                }
            }
        }

    }
}
