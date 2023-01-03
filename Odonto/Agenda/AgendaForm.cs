using Odonto.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odonto
{
    /// <summary>
    /// Define a Interface com o usuário.
    /// </summary>
    public class AgendaForm
    {
        public string CPF { get; private set; }
        public string Consulta { get; private set; }
        public string Inicio { get; private set; }
        public string Fim { get; private set; }

        /// <summary>
        /// Mostra ao usuário todas as opções disponíveis em relação ao formato de listagem da Agenda
        /// </summary>
        /// <returns>Retorna a escolha do usuário</returns>
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

        /// <summary>
        /// Solicita um valor de CPF ao usuário.
        /// </summary>
        public void SolicitarCPF()
        {
            Console.Write("CPF: ");
            CPF = Console.ReadLine();
        }
        /// <summary>
        /// Solicita uma data de consulta ao usuário.
        /// </summary>
        public void SolicitarDataConsulta()
        {
            Console.Write("Data da consulta (ddMMaaaa): ");
            Consulta = Console.ReadLine();
        }
        /// <summary>
        /// Solicita o horário de início da consulta ao usuário.
        /// </summary>
        public void SolicitarHoraInicio()
        {
            Console.Write("Hora inicial (HHmm): ");
            Inicio = Console.ReadLine();
        }
        /// <summary>
        /// Solicita o horário de término da consulta ao usuário.
        /// </summary>
        public void SolicitarHoraFim()
        {
            Console.Write("Hora final (HHmm): ");
            Fim = Console.ReadLine();
        }




    }
}
