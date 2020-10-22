using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    class Consulta : IDado
    {
        public ulong ID_Paciente { get; set;}
        public float Preço { get; set; }
        public double ID { get; set; } 
        public string TipoE { get; set; }
        public DateTime Data { get; set; }
        public int Prioridade { get; set; }
        public Consulta(string tipoE ,double id , ulong id_p ,float preço, int prioridade,DateTime data)
        {
            this.ID_Paciente = id_p;
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
        public override string ToString() {
            return "    " + ID_Paciente.ToString() + " - " + this.ID.ToString() + " - " + this.Prioridade + " - " +this.Preço +" - "+ this.Data.ToString("d");
        }
    }
}
