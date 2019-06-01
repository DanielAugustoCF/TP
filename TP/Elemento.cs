using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    class Elemento
    {
        public IDado d;
        public Elemento prox;
        public Elemento(IDado d)
        {
            this.d = d;
            this.prox = null;
        }
        public override string ToString()
        {
            return d.ToString();
        }
    }
}
