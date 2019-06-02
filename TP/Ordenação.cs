using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    class Ordenação
    {
        public Ordenação() {}
        public List<Consulta> quickSort(List<Consulta> vetor)
        {
            int trocas = 0, comparacoes = 0;
            int inicio = 0;
            int fim = vetor.Count - 1;
            quickSort(vetor, inicio, fim, ref trocas, ref comparacoes);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\n\nNúmeros de trocas:" + trocas + "\nNúmero de comparações:" + comparacoes);
            Console.ResetColor();
            return vetor;

        }
        private static void quickSort(List<Consulta> vetor, int inicio, int fim, ref int trocas, ref int comparacoes)
        {

            if (inicio < fim)
            {
                Consulta p = vetor[inicio];
                int i = inicio + 1;
                int f = fim;

                comparacoes++;
                while (i <= f)
                {
                    if (vetor[i].Prioridade <= p.Prioridade)
                    {
                        i++;
                        comparacoes++;
                    }
                    else if (p.Prioridade < vetor[f].Prioridade)
                    {
                        f--;
                        comparacoes++;
                    }
                    else
                    {
                        comparacoes++;
                        Consulta troca = vetor[i];
                        vetor[i] = vetor[f];
                        vetor[f] = troca;
                        i++;
                        f--;
                        trocas++;
                    }
                }
                vetor[inicio] = vetor[f];
                vetor[f] = p;
                trocas++;
                quickSort(vetor, inicio, f - 1, ref trocas, ref comparacoes);
                quickSort(vetor, f + 1, fim, ref trocas, ref comparacoes);
            }


        }

        public List<Consulta> heapSort(List<Consulta> vetor)
        {
            int trocas = 0, comparacoes = 0;
            buildMaxHeap(vetor, ref trocas, ref comparacoes);
            int n = vetor.Count;
            for (int i = vetor.Count - 1; i > 0; i--)
            {
                swap(vetor, i, 0, ref trocas);
                maxHeapify(vetor, 0, --n, ref trocas, ref comparacoes);
            }
            Console.ResetColor();
            return vetor;
        }

        private static void buildMaxHeap(List<Consulta> v, ref int trocas, ref int comparacoes)
        {
            for (int i = v.Count / 2 - 1; i >= 0; i--)
            {
                maxHeapify(v, i, v.Count, ref trocas, ref comparacoes);
            }
        }
        private static void maxHeapify(List<Consulta> v, int pos, int n, ref int trocas, ref int comparacoes)
        {
            int max = 2 * pos + 1, right = max + 1;
            if (max < n)
            {
                if (right < n && v[max].Data < v[right].Data)
                {
                    max = right;
                    comparacoes++;
                }
                if (v[max].Data > v[pos].Data)
                {
                    comparacoes++;
                    swap(v, max, pos, ref trocas);
                    maxHeapify(v, max, n, ref trocas, ref comparacoes);
                }
            }
        }
        private static void swap(List<Consulta> v, int j, int aposJ, ref int trocas)
        {
            Consulta aux = v[j];
            v[j] = v[aposJ];
            v[aposJ] = aux;
            trocas++;
        }
    }
}
