using Odonto.Extensions;
using System;

namespace Odonto
{
    public class PacienteForm
    {
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string DataNascimento { get; private set; }
        public string MenuPrincipal()
        {
            string escolha;

            do
            {
                Console.WriteLine("Menu Principal");
                Console.WriteLine("1-Cadastro de pacientes");
                Console.WriteLine("2-Agenda");
                Console.WriteLine("3-Fim");
                Console.Write("Digite sua escolha: ");

                escolha = Console.ReadLine();

            } while (escolha.NaoEhEscolhaValida(Menu.Principal));

            return escolha;
        }
        public string MenuCadastraPaciente()
        {
            string escolha;

            do
            {
                Console.WriteLine("Menu do Cadastro de Pacientes");
                Console.WriteLine("1-Cadastrar novo paciente");
                Console.WriteLine("2-Excluir paciente");
                Console.WriteLine("3-Listar pacientes (ordenado por CPF)");
                Console.WriteLine("4-Listar pacientes (ordenado por nome)");
                Console.WriteLine("5-Voltar p/ menu principal");
                Console.Write("Digite sua escolha: ");

                escolha = Console.ReadLine();

            } while (escolha.NaoEhEscolhaValida(Menu.Cadastra));

            return escolha;
        }
        public string MenuAgenda()
        {
            string escolha;

            do
            {
                Console.WriteLine("Agenda");
                Console.WriteLine("1-Agendar consulta");
                Console.WriteLine("2-Cancelar agendamento");
                Console.WriteLine("3-Listar agenda");
                Console.WriteLine("4-Voltar p/ menu principal");
                Console.Write("Digite sua escolha: ");

                escolha = Console.ReadLine();

            } while (escolha.NaoEhEscolhaValida(Menu.Agenda));

            return escolha;
        }

        public void SolicitarCPF()
        {
            Console.Write("CPF: ");
            CPF = Console.ReadLine();
        }
        public void SolicitarNome()
        {
            Console.Write("Nome: ");
            Nome = Console.ReadLine();
        }
        public void SolicitarNascimento()
        {
            Console.Write("Data de Nascimento: ");
            DataNascimento = Console.ReadLine();
        }
    }

}
