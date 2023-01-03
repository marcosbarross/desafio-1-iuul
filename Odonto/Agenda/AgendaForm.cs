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

        public void SolicitarCPF()
        {
            Console.Write("CPF: ");
            CPF = Console.ReadLine();
        }
        public void SolicitarDataConsulta()
        {
            Console.Write("Data da consulta (ddMMaaaa): ");
            Consulta = Console.ReadLine();
        }
        public void SolicitarHoraInicio()
        {
            Console.Write("Hora inicial (HHmm): ");
            Inicio = Console.ReadLine();
        }
        public void SolicitarHoraFim()
        {
            Console.Write("Hora final (HHmm): ");
            Fim = Console.ReadLine();
        }




    }
}
