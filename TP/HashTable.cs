using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    class HashTable
    {
        int tamanho;
        List<Consulta>[] tablet;
        public HashTable(int tamanho)
        {
            this.tamanho = tamanho;
            tablet = new List<Consulta>[tamanho];
            
        }
        public int Hashing(string l)
        {
            int prev = 0;
            switch(l)
            {
                case "Clinica Geral":
                    prev = (int)'C';
                    break;

                case "Ortopedia":
                    prev = (int)'O';
                    break;

                case "Otorrinolaringologia":
                    prev = (int)'R';
                    break;

                case "Traumatologia":
                    prev = (int)'T';
                    break;

                default:
                    Console.WriteLine("Deu erro, Supera");
                    break;
            }
            return (prev % tamanho);
        }
        public void Inserir(List<Consulta> C)
        {
            int posicion = Hashing(C[0].TipoE);
            if(tablet[posicion]==null)
                this.tablet[posicion]=C;
            else
            {   
                for(int i = posicion+1; i<tamanho; i++)
                {
                    if (tablet[i] == null)
                    {
                        tablet[i] = C;
                        return;
                    }          
                }
            }
        }
        public List<Consulta> Busca(string type)
        {
            List<Consulta> C = new List<Consulta>();
            for(int i = Hashing(type); i < this.tamanho; i++)
            {
                if(tablet[i]!=null)
                {
                    C = tablet[i];
                    if(type == C[0].TipoE)
                    {
                        return C;
                    }
                }
            }
            return null;
        }
        public override string ToString()
        {
            string aux = "";
            foreach(List<Consulta> T in tablet)
            {
                if(T!= null)
                    foreach(Consulta c in T)
                    {
                        aux += c.ToString();
                        aux += "\n";
                    }
            }
            return aux;
        }
    }
}
