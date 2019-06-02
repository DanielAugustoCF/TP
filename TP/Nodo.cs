using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    class Nodo
    {
        public IDado d;
        public Nodo esq, dir;
        public Nodo(IDado d)
        {
            this.d = d;
            this.esq = null;
            this.dir = null;
        }
        public override string ToString()
        {
            return d.ToString();
        }
        public int Grau()
        {
            if (this.esq != null)
                if (this.dir != null)
                    return 2;
                else
                    return -1;
            else if (this.dir != null)
                return 1;
            else
                return 0;
        }
        public Nodo Antecessor()
        {
            Nodo aux = this.esq;
            while (aux.dir != null)
                aux = aux.dir;
            return aux;
        }
    }
}
