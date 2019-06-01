using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TP
{
	class Fila
	{
		Elemento prim;
		Elemento ult;
		public Fila()
		{
			this.prim = new Elemento(null);
			this.ult = this.prim;
		}
		public bool vazia()
		{
			return (this.prim == this. ult);
		}	
		public void inserir(IDado d)
		{
			Elemento novo = new Elemento(d);
			this.ult.prox = novo;
			this.ult =  novo;
		}
		public IDado retirar()
		{
			if(this.vazia())
				return null;
			Elemento aux = this.prim.prox;
			this.prim.prox = aux.prox;
			if(aux == this.ult)
				this.ult = this.prim;
			else 
				aux.prox = null;
			return aux.d;
		}
		public override string ToString()
		{
			if(this.vazia())
				return null;
			StringBuilder auxString = new StringBuilder();
			Elemento aux  = this.prim.prox;
			while(aux!=null)
            { 
			    aux.ToString();
			    auxString.AppendLine(aux.ToString());
			    aux = aux.prox;	
			}
			return auxString.ToString();
		}
        public Elemento ConsultaTopo()
        {
            return prim.prox;
        }
        public Elemento ConsultaFundo()
        {
            return ult;
        }
    }
    
}