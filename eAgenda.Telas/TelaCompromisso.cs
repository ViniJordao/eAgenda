using eAgenda.Controladores;
using eAgenda.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.Telas
{
    public class TelaCompromisso : TelaBase<Compromissos>
    {
        private readonly ControladorCompromissos controladorCompromisso;

        public TelaCompromisso(ControladorCompromissos ctrlcompromissos) : base("E-Agenda")
        {
            controladorCompromisso = ctrlcompromissos;
        }

        public  void ObterOpcao()
        {
            

            Console.WriteLine("1 para cadastrar uma novo compromisso");
            Console.WriteLine("2 para editar um compromisso");
            Console.WriteLine("3 para excluir um compromisso");
            Console.WriteLine("4 para visualizar todos os compromissos");
            Console.WriteLine("S para sair");
        }

        public void CadastrarNovoCompromisso()
        {
       

            Console.WriteLine("Digite o assunto: ");
            string assunto = Console.ReadLine();

            Console.WriteLine("Digite o local: ");
            string local = Console.ReadLine();

            Console.WriteLine("Digite a data do compromisso: ");
            DateTime dataCompromisso = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Digite a hora de inicio do compromisso");
            DateTime horaInicio = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Digite a hora de inicio do compromisso");
            DateTime horaTermino = Convert.ToDateTime(Console.ReadLine());

            controladorCompromisso.InserirNovoCompromisso(new Compromissos(assunto, local, dataCompromisso, horaInicio, horaTermino));

            ApresentarMensagem("Compromisso cadastrada com sucesso", Mensagem.Sucesso);
        }

        public void AtualizarCompromisso()
        {
          

            VisualizarCompromissos();
        }

        public void VisualizarCompromissos()
        {
           
            List<Compromissos> compromissosConcluidos = controladorCompromisso.SelecionarTodosOsCompromissos();

            if (ListaVazia(compromissosConcluidos))
            {
                ApresentarMensagem("Nenhum contato cadastrado!", Mensagem.Atencao);
                return;
            }
            string configuracaColunasTabela = "{0,-5} | {1,-25} | {2,-22} | {3,-3} | {4, -10} | {5, -14}";

            MontarCabecalhoTabela(configuracaColunasTabela, "Id", "Assunto", "Local", "Data", "Hora Inicio", "Hora Término");

            foreach (Compromissos compromissos in compromissosConcluidos)
            {
                Console.WriteLine(configuracaColunasTabela, compromissos.Id, compromissos.assunto, compromissos.dataCompromisso, compromissos.horaInicio, compromissos.horaTermino);
            }
            Console.ReadLine();
        }
        public void ExcluirCompromisso()
        {
        

            VisualizarCompromissos();

            Console.Write("\nDigite o ID do compromisso que deseja excluir: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Compromissos compromissos = controladorCompromisso.SelecionarCompromissoPorId(id);

            controladorCompromisso.ExcluirCompromisso(compromissos);

            ApresentarMensagem("Compromisso excluído sucesso!", Mensagem.Sucesso);
        }
    }
}
