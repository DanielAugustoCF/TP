using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    public class Paciente : IDado
    {
        string nome;
        ulong cpf;
        Lista historico;
        public Paciente(string nome, ulong cpf)
        {
            this.nome = nome;
            this.cpf = cpf;
            this.historico = new Lista();
        }
        public bool Equals(IDado d)
        {
            Paciente aux = (Paciente)(d);
            if (this.Cpf == aux.Cpf)
                return true;
            else
                return false;
        }
        public int CompareTo(IDado d)
        {
            Paciente aux = (Paciente)(d);
            if (this.Cpf.Equals(aux.Cpf))
            {
                return 0;
            }
            else if(this.Cpf < aux.Cpf)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
        public override string ToString()
        {
            return ":" + this.nome.ToString() + " - " + this.cpf.ToString() + "\n"  + this.historico.ToString();
        }
        public string Nome
        {
            get { return nome; }
            set { this.nome = value; }
        }
        public ulong Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }
        public Lista Historico
        {
            get { return historico; }
        }
    }
}
