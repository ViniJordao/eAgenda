using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.Telas
{
    public enum Prioridade : int
    {
        Alta = 0,
        Media = 1,
        Baixa = 2
    }

    public static class ConfiguracoesPrioridade
    {
        public static Prioridade DefinirPrioridade(string strPrioridade)
        {
            switch (strPrioridade)
            {
                case "Alta": return Prioridade.Alta;
                case "Média": return Prioridade.Media;
                case "Baixa": return Prioridade.Baixa;
            }

            return Prioridade.Baixa;
        }
    }
}
