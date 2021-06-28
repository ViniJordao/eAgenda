using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.Dominio
{
    public class Tarefas : DominioBase
    {
        public string Titulo;
        public DateTime DataCriacao;
        public DateTime DataConclusao;
        public int Prioridade;

        public Tarefas(string titulo, DateTime dataCriacao, int prioridade)
        {
            Titulo = titulo;
            DataCriacao = dataCriacao;
            Prioridade = prioridade;
        }

        public Tarefas(string titulo, DateTime dataCriacao, DateTime dataConclusao,
            int prioridade)
        {
            Titulo = titulo;
            DataCriacao = dataCriacao;
            DataConclusao = dataConclusao;
            Prioridade = prioridade;
        }
    }
}
