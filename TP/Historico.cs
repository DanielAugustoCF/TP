using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    public class Historico : IDado
    {
        DateTime data;
        string Nome_Medico;
        int ID_Medico;
        string Especialidade;
        double custo_consulta;
        double codigo_consulta;
        int prioridade;

        public Historico(DateTime date, string Nome, int ID, string Ex, double custo, double codigo,int prioridade)
        {
            this.data = date;
            this.Nome_Medico = Nome;
            this.ID_Medico = ID;
            this.Especialidade = Ex;
            this.custo_consulta = custo;
            this.codigo_consulta = codigo;
            this.prioridade = prioridade;
        }
        public bool Equals(IDado obj)
        {
            Historico aux = (Historico)(obj);
            if (this.ID_Medico == aux.ID_Medico)
                return true;
            else
                return false;
        }
        public int CompareTo(IDado obj)
        {
            Historico aux = (Historico)(obj);
            if (this.ID_Medico.Equals(aux.ID_Medico))
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

            return "    Nome: " + this.Nome_Medico.ToString() + " - Id: " + this.ID_Medico.ToString() + " - Especialidade: " + this.Especialidade.ToString() + " - " +
                "Custo R$" + this.custo_consulta.ToString() + " - ID da Consulta: " + this.codigo_consulta.ToString() + " - data da consulta: " + this.data.ToString("d");
        }
        public double ID_consulta
        {
            get { return codigo_consulta; }
            set { this.codigo_consulta = value; }
        }
    }
}
