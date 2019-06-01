using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    class Medico : IDado
    {
        private Fila consultas;
        float pagamento = 0;
        public Medico(string nome, string ex, int id)
        {
            this.Nome = nome;
            this.Ex = ex;
            this.ID = id;
            consultas = new Fila();
        }
        public bool Equals(IDado obj)
        {
            Medico aux = (Medico)(obj);
            if (this.ID == aux.ID)
                return true;
            else
                return false;
        }
        public int CompareTo(IDado obj)
        {
            Medico aux = (Medico)(obj);
            if (this.ID.Equals(aux.ID))
            {
                return 0;
            }
            else if (this.ID > aux.ID)
            {
                return 1;
            }
            else if (this.ID < aux.ID)
            {
                return -1;
            }
            return 2;
        }
        public string Nome { get; set; }
        public string Ex { get; set; }
        public int ID { get; set; }
        public float Pagamento
        {
            get { return pagamento; }
            set { pagamento += value; }
        }
        public Fila Consultas { get { return consultas; } }
        public override string ToString()
        {

            return ":Nome " + this.Nome.ToString() + " - ID " + this.ID.ToString() + " - EX " + this.Ex.ToString() + " - R$" + this.Pagamento.ToString()+" \n" + Consultas.ToString();
        }
    }
}