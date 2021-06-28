
using eAgenda.Dominio;
using eAgenda.Controladores;
using eAgenda.Telas;
using System;


namespace eAgenda.ConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            ControladorTarefas controladorTarefas = new ControladorTarefas();
            ControladorContatos controladorContatos = new ControladorContatos();
            ControladorCompromissos controladorCompromissos = new ControladorCompromissos();

            TelaTarefas telaTarefas = new TelaTarefas(controladorTarefas);
            TelaContatos telaContatos = new TelaContatos(controladorContatos);
            TelaCompromisso telaCompromisso = new TelaCompromisso(controladorCompromissos);

            string opcaoMenuPrincipal = "";
            string opcaoSubMenus = "";

            Console.WriteLine();

            Console.Clear();
     
            Console.WriteLine("E-Agenda");
            Console.WriteLine();

            
            Console.WriteLine("Digite 1 para o menu Tarefas");
            Console.WriteLine("Digite 2 para o menu Contatos");
            Console.WriteLine("Digite 3 para o menu Compromissos");
           
            Console.WriteLine("Digite S para Sair");

          
            opcaoMenuPrincipal = Console.ReadLine();
            Console.Clear();

            if (opcaoMenuPrincipal == "1")
            {
                while (true)
                {
                    telaTarefas.ObterOpcao();
                    Console.Clear();

                    if (Console.ReadLine().Equals("s", StringComparison.OrdinalIgnoreCase))
                        break;

                    if (opcaoMenuPrincipal == "1")
                        telaTarefas.CadastrarNovaTarefa();
                        

                    if (opcaoSubMenus == "2")
                        telaTarefas.AtualizarTarefa();

                    if (opcaoSubMenus == "3")
                        telaTarefas.ExcluirTarefa();

                    if (opcaoSubMenus == "4")
                        telaTarefas.VisualizarTarefasEmAberto();

                    if (opcaoSubMenus == "5")
                        telaTarefas.VisualizarTarefasConcluidas();
                }
            }

            else if (opcaoMenuPrincipal == "2")
            {
                while (true)
                {
                    telaContatos.ObterOpcao();
                   

                     if (Console.ReadLine().Equals("s", StringComparison.OrdinalIgnoreCase))
                        break;

                     if (opcaoSubMenus == "1")
                        telaContatos.CadastrarNovoContato();

                    else if(opcaoSubMenus == "2")
                        telaContatos.AtualizarContato();

                    else if(opcaoSubMenus == "3")
                        telaContatos.ExcluirContato();

                    else if (opcaoSubMenus == "4")
                        telaContatos.VisualizarTodosOsContatos();
                }

                if (opcaoMenuPrincipal == "3")
                {
                    while (true)
                    {
                        telaCompromisso.ObterOpcao();

                        if (Console.ReadLine().Equals("s", StringComparison.OrdinalIgnoreCase))
                            break;

                        else if (opcaoSubMenus == "1")
                            telaCompromisso.CadastrarNovoCompromisso();

                        else if (opcaoSubMenus == "2")
                            telaCompromisso.AtualizarCompromisso();

                        else if(opcaoSubMenus == "3")
                            telaCompromisso.ExcluirCompromisso();

                        else if (opcaoSubMenus == "4")
                            telaCompromisso.VisualizarCompromissos();

                    }
                }
            }
        }
    }
}
