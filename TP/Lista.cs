using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    public class Lista
    {
        Elemento prim;
        Elemento ult;
        public Lista()
        {
            this.prim = new Elemento(null);
            this.ult = this.prim;
        }
        public bool vazia()
        {
            return (this.prim == this.ult);
        }
        public void inserir(IDado d)
        {
            Elemento novo = new Elemento(d);
            this.ult.prox = novo;
            this.ult = novo;
        }
        public IDado retirar(IDado valor)
        {
            if (this.vazia()) { return null; }

            Elemento aux = this.prim;

            while ((aux.prox != null) && (!aux.prox.d.Equals(valor)))
                aux = aux.prox;

            if (aux.prox == null) return null;

            else
            {
                Elemento auxRet = aux.prox;
                aux.prox = auxRet.prox;
                if (auxRet == this.ult)
                    this.ult = aux;
                else
                    auxRet.prox = null;
                return auxRet.d;
            }
        }
        public bool localizar(double loc)
        {
            Elemento aux = this.prim.prox;
            if (vazia())
            {
                return false;
            }
            else
            {
                while (aux != null)
                {
                    Historico c = (Historico)(aux.d);
                    if(c.ID_consulta.Equals(loc))
                    {
                        return true;
                    }
                    else
                    {
                        aux = aux.prox;
                    }
                }
                return false;
            }
        }
        public void concatenar(Lista outra)
        {
            if (outra.vazia()) return;

            this.ult.prox = outra.prim.prox;
            this.ult = outra.ult;
            outra = new Lista();
        }
        public override string ToString()
        {
            if (this.vazia())
                return null;
            StringBuilder auxString = new StringBuilder();
            Elemento aux = this.prim.prox;
            while (aux != null)
            {
                aux.ToString();
                auxString.AppendLine(aux.ToString());
                aux = aux.prox;
            }
            return auxString.ToString();
        }
    }
}
