using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odonto.Agenda
{
    public class AgendaForm
    {
        public string MenuListarAgenda()
        {
            string escolha;

            do
            {
                Console.WriteLine("Listar Agenda");
                Console.WriteLine("1-Listar toda a agenda");
                Console.WriteLine("2-Listar agenda de um período");
                Console.WriteLine("3-Voltar p/ Menu Agenda");
                Console.Write("Digite sua escolha: ");

                escolha = Console.ReadLine();

            } while (escolha.NaoEhEscolhaValida(Menu.ListarAgenda));

            return escolha;
        }
    }
}
