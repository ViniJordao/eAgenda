using eAgenda.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.Telas
{
    public abstract class TelaBase<T> where T : DominioBase
    {
        public string Titulo;

        public TelaBase(string titulo)
        {
            Titulo = titulo;
        }

      

        protected void MontarCabecalhoTabela(string configuracaoColunasTabela, params object[] colunas)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(configuracaoColunasTabela, colunas);
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();
        }

       

        protected bool ListaVazia(List<T> lista)
        {
            if (lista.Count == 0)
                return true;

            return false;
        }

        protected void ApresentarMensagem(string mensagem, Mensagem tm)
        {
            switch (tm)
            {
                case Mensagem.Sucesso:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case Mensagem.Atencao:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

                case Mensagem.Erro:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                default:
                    break;
            }

            Console.WriteLine();
            Console.WriteLine(mensagem);
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
