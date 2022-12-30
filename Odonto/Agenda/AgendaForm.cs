using Odonto.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odonto
{
    public class AgendaForm
    {
        public string CPF { get; private set; }
        public string Consulta { get; private set; }
        public string Inicio { get; private set; }
        public string Fim { get; private set; }

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
        public void AgendarConsulta(AgendaValidador validador = null)
        {
            //validador?.MostrarErro();

            if (validador == null || validador.HasError(CamposAgenda.CPF))
            {
                Console.Write("CPF: ");
                CPF = Console.ReadLine();
            }
            if (validador == null || validador.HasError(CamposAgenda.CONSULTA))
            {
                Console.Write("Data da consulta (dd/mm/aaaa): ");
                Consulta = Console.ReadLine();
            }
        }
    }
}
