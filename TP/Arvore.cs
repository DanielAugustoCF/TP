using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    class ABB
    {
        #region Parte Generica
        public Nodo raiz;

        public ABB()
        {
            this.raiz = null;
        }

        public void inserir(IDado d)
        {
            Nodo novo = new Nodo(d);
            this.raiz = insRec(novo, this.raiz);
        }

        private Nodo insRec(Nodo novo, Nodo raiz)
        {
            if (raiz == null)
            {
                return novo;
            }
            if (novo.d.CompareTo(raiz.d) < 0)
                raiz.esq = insRec(novo, raiz.esq);
            else
                raiz.dir = insRec(novo, raiz.dir);
            return raiz;
        }
        public Nodo buscar(IDado dado)
        {          
            Nodo busca = new Nodo(dado);
            return buscaRec(busca, this.raiz);
        }

        private Nodo buscaRec(Nodo busca, Nodo raiz)
        {
            if (raiz == null)
            {
                return null;
            }

            if (busca.d.CompareTo(raiz.d) == 0)
                return raiz;
            else if (busca.d.CompareTo(raiz.d) < 0)
                return buscaRec(busca, raiz.esq);
            else
                return buscaRec(busca, raiz.dir);
        }
        public override string ToString()
        {
            return emOrdem(this.raiz);
        }
        private string emOrdem(Nodo raiz)
        {
            if (raiz != null)
            {
                String aux = "";
                aux = emOrdem(raiz.esq);
                aux += raiz.ToString();
                aux += emOrdem(raiz.dir);
                return aux;
            }
            else return "\n";
        }

        public string preOrdem(Nodo raiz)
        {
            if (raiz != null)
            {
                String aux = " ";
                aux += raiz.d.ToString()+"\n";
                aux += preOrdem(raiz.esq);
                aux += preOrdem(raiz.dir);
                return aux;
            }
            else return "";
        }
        public IDado retirar(IDado dado)
        {
            Nodo retirada = new Nodo(dado);
            Nodo aux;
            retiradaRec(retirada, this.raiz, out aux);
            return aux.d;
        }
        public Nodo retiradaRec(Nodo quem, Nodo onde, out Nodo saida)
        {
            saida = new Nodo(null);
            if (onde == null)
            {
                return null;
            }
            if (quem.d.CompareTo(onde.d) < 0)
                onde.esq = retiradaRec(quem, onde.esq, out saida);
            else if (quem.d.CompareTo(onde.d) > 0)
                onde.dir = retiradaRec(quem, onde.dir, out saida);
            else
            {
                saida = new Nodo(onde.d);
                int grau = onde.Grau();
                switch (grau)
                {
                    case 0:
                        return null;
                    case -1:
                        return onde.esq;
                    case 1:
                        return onde.dir;
                    case 2:
                        Nodo antec = onde.Antecessor();
                        onde.d = antec.d;
                        onde.esq = retiradaRec(antec, onde.esq, out saida);
                        break;
                }
            }
            return onde;
        }
        #endregion 

        #region Parte Não Generica

        public Nodo buscarP(ulong id_p)
        {
            IDado dado = new Paciente(null,id_p);
            Nodo busca = new Nodo(dado);
            return buscaPRec(busca, this.raiz);
        }
        private Nodo buscaPRec(Nodo busca, Nodo raiz)
        {
            if (raiz == null)
            {
                return null;
            }
            Paciente n1 = (Paciente)(busca.d);
            Paciente n2 = (Paciente)(raiz.d);
            if (n1.Cpf.CompareTo(n2.Cpf) == 0)
                return raiz;
            else if (n1.Cpf.CompareTo(n2.Cpf) < 0)
                return buscaPRec(busca, raiz.esq);
            else
                return buscaPRec(busca, raiz.dir);
        }

        public Nodo buscarM(string type)
        {
            IDado dado = new Medico(0, null, type);
            Nodo busca = new Nodo(dado);
            return buscaMRec(busca, this.raiz);
        }
        private Nodo buscaMRec(Nodo busca, Nodo raiz)
        {
            if (raiz == null)
            {
                return null;
            }
            Medico n1 = (Medico)(busca.d);
            Medico n2 = (Medico)(raiz.d);
            if (n1.Ex.CompareTo(n2.Ex) == 0)
                return raiz;
            else if (n1.Ex.CompareTo(n2.Ex) < 0)
                return buscaMRec(busca, raiz.esq);
            else
                return buscaMRec(busca, raiz.dir);
        }

        public List<Medico> aux;
        public void InicializarAux()
        {
            aux = new List<Medico>();
        }
        public void ListaM(string type,Nodo raiz)
        {
            if (raiz != null)
            { 
                Medico m = (Medico)raiz.d;
                if(m.Ex == type)
                    aux.Add(m);
                ListaM(type, raiz.esq);
                ListaM(type, raiz.dir);
            }
        }

        #endregion
    }
}
