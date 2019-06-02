using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    class Especialidade
    {
        List<Consulta> Ex_cli;
        List<Consulta> Ex_ort;
        List<Consulta> Ex_ot;
        List<Consulta> Ex_tra;
        HashTable tabela;

        public Especialidade()
        {

            Ex_cli = new List<Consulta>();
            Ex_ort = new List<Consulta>();
            Ex_ot = new List<Consulta>();
            Ex_tra = new List<Consulta>();
            tabela = new HashTable(13);
        }
        public void InserirListasNaHash()
        {
            tabela.Inserir(Ex_cli);
            tabela.Inserir(Ex_ort);
            tabela.Inserir(Ex_ot);
            tabela.Inserir(Ex_tra);
        }
        public List<Consulta> Ex_Cli
        {
            get{ return Ex_cli; }
            set{ Ex_cli = value; }
        }
        public List<Consulta> Ex_Ort
        {
            get { return Ex_ort; }
        }
        public List<Consulta> Ex_Ot
        {
            get { return Ex_ot; }
        }
        public List<Consulta> Ex_Tra
        {
            get { return Ex_tra; }
        }
        public HashTable Tabela
        {
            get { return tabela; }
        }
    }
}
