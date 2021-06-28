using eAgenda.Controladores;
using eAgenda.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.Telas
{
    public class TelaTarefas : TelaBase<Tarefas>
    {
        private readonly ControladorTarefas controlador;

        public TelaTarefas(ControladorTarefas ctrl) : base("E-Agenda")
        {
            controlador = ctrl;
        }

        public void ObterOpcao()
        {

            Console.WriteLine("1 para cadastrar uma nova tarefa");
            Console.WriteLine("2 para editar uma tarefa");
            Console.WriteLine("3 para excluir uma tarefa");
            Console.WriteLine("4 para visualizar tarefas em aberto");
            Console.WriteLine("5 para visualizar tarefas concluídas");
            Console.WriteLine("S para sair");
           
        }

        public void CadastrarNovaTarefa()
        {

            Console.Write("Digite o título da tarefa: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite a data de abertura da tarefa: ");
            DateTime dataAbertura = Convert.ToDateTime(Console.ReadLine());

            Prioridade prioridade;
            string strPrioridade;

            do
            {
                Console.WriteLine("Qual a prioridade da tarefa? (Alta, Media ou Baixa)");
                strPrioridade = Console.ReadLine();

            } while (strPrioridade != "Alta" && strPrioridade != "Media" && strPrioridade != "Baixa");

            prioridade = ConfiguracoesPrioridade.DefinirPrioridade(strPrioridade);

            controlador.InserirNovaLista(new Tarefas(titulo, dataAbertura, (int)prioridade));

            ApresentarMensagem("Tarefa cadastrada com sucesso!", Mensagem.Sucesso);
        }

        public void AtualizarTarefa()
        {
 

            VisualizarTarefasEmAberto();

            Console.Write("\nDigite o ID da tarefa que deseja atualizar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Tarefas lista = controlador.SelecionarTarefaPorId(id);

            Console.Write("Digite o título da tarefa: ");
            lista.Titulo = Console.ReadLine();

            Prioridade prioridade;
            string strPrioridade;

            do
            {
                Console.WriteLine("Qual a prioridade da tarefa? (Alta, Media ou Baixa)");
                strPrioridade = Console.ReadLine();

            } while (strPrioridade != "Alta" && strPrioridade != "Media" && strPrioridade != "Baixa");

            prioridade = ConfiguracoesPrioridade.DefinirPrioridade(strPrioridade);

            lista.Prioridade = (int)prioridade;

            controlador.AtualizarTarefa(lista);

            ApresentarMensagem("Tarefa atualizada com sucesso!", Mensagem.Sucesso);
        }

        public void ExcluirTarefa()
        {


            VisualizarTodasAsTarefas();

            Console.Write("\nDigite o ID da tarefa que deseja excluir: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Tarefas tarefas = controlador.SelecionarTarefaPorId(id);

            controlador.ExcluirTarefa(tarefas);

            ApresentarMensagem("Tarefa excluída sucesso!", Mensagem.Sucesso);
        }

        public void VisualizarTodasAsTarefas()
        {


            List<Tarefas> tarefas = controlador.SelecionarTodasAsTarefas();

            if (ListaVazia(tarefas))
            {
                ApresentarMensagem("Nenhuma tarefa cadastrada!", Mensagem.Atencao);
                return;
            }

            string configuracaColunasTabela = "{0,-5} | {1,-25} | {2,-22} | {3,-3} | {4, -10}";

            MontarCabecalhoTabela(configuracaColunasTabela, "Id", "Título", "Data de Criação", "Prioridade");

            foreach (Tarefas tarefa in tarefas)
            {
                Console.WriteLine(configuracaColunasTabela, tarefa.Id, tarefa.Titulo, tarefa.DataCriacao.ToShortDateString(), tarefa.Prioridade);
            }
            Console.ReadLine();
        }

        public void VisualizarTarefasEmAberto()
        {


            List<Tarefas> tarefasEmAberto = controlador.SelecionarTodasAsTarefasEmAberto();

            if (ListaVazia(tarefasEmAberto))
            {
                ApresentarMensagem("Nenhuma tarefa em aberto!", Mensagem.Atencao);
                return;
            }

            string configuracaColunasTabela = "{0,-5} | {1,-25} | {2,-22} | {3,-3} | {4, -10}";

            MontarCabecalhoTabela(configuracaColunasTabela, "Id", "Título", "Data de Criação", "%", "Prioridade");

            foreach (Tarefas tarefa in tarefasEmAberto)
            {
                Console.WriteLine(configuracaColunasTabela, tarefa.Id, tarefa.Titulo, tarefa.DataCriacao.ToShortDateString(), tarefa.Prioridade);
            }
            Console.ReadLine();
        }

        public void VisualizarTarefasConcluidas()
        {


            List<Tarefas> tarefaConcluida = controlador.SelecionarTodasAsTarefasConcluidas();

            if (ListaVazia(tarefaConcluida))
            {
                ApresentarMensagem("Nenhuma tarefa concluída!", Mensagem.Atencao);
                return;
            }

            string configuracaColunasTabela = "{0,-5} | {1,-25} | {2,-22} | {3,-22} | {4,-4}";

            MontarCabecalhoTabela(configuracaColunasTabela, "Id", "Título", "Data de Criação", "Data de Conclusão", "Prioridade");

            foreach (Tarefas lista in tarefaConcluida)
            {
                Console.WriteLine(configuracaColunasTabela, lista.Id, lista.Titulo, lista.DataCriacao.ToShortDateString(),
                    lista.DataConclusao.ToShortDateString(), lista.Prioridade);
            }

            Console.ReadLine();
        }
    }
}
