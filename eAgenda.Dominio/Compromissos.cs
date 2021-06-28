using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.Dominio
{
    public class Compromissos : DominioBase
    {
        public string assunto;
        public string local;
        public DateTime dataCompromisso;
        public DateTime horaInicio;
        public DateTime horaTermino;

        public Compromissos(string assunto, string local, DateTime dataCompromisso, DateTime horaInicio, DateTime horaTermino)
        {
            this.assunto = assunto;
            this.local = local;
            this.dataCompromisso = dataCompromisso;
            this.horaInicio = horaInicio;
            this.horaTermino = horaTermino;
        }
    }
}
