using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    class Consulta : IDado
    {
        public Paciente P { get; set; }
        public float Preço { get; set; }
        public double ID { get; set; } 
        public string TipoE { get; set; }
        public DateTime Data { get; set; }
        public int Prioridade { get; set; }
        public Consulta(Paciente p, double id, string tipoE ,float preço, int prioridade,DateTime data)
        {
            this.P = p;
            this.ID = id;
            this.TipoE = tipoE;
            this.Preço = preço;
            this.Data = data;
            this.Prioridade = prioridade;
        }
        public bool Equals(IDado obj)
        {
            Consulta aux = (Consulta)(obj);
            if (this.ID == aux.ID)
                return true;
            else
                return false;
        }
        public int CompareTo(IDado obj)
        {
            Consulta aux = (Consulta)(obj);
            if (this.ID.Equals(aux.ID))
            {
                return 0;
            }
            else
            {
                return 1;
            }

        }
        public override string ToString()
        {

            return "    "+ this.P.Nome + " - " + this.P.Cpf + " - " + this.ID.ToString() + " - " + this.Prioridade + " - " +this.Preço +" - "+ this.Data.ToString("d");
        }
    }
}
