using System;
using System.Collections.Generic;

namespace Odonto.Controlador
{
    public class GeralControlador
    {
        private readonly PacienteForm PacienteForm;
        private readonly AgendaForm AgendaForm;
        bool isValid;

        public PacienteValidador Validador { get; }
        public AgendaValidador AgendaValidador { get; }


        public ListaPacientes ListaPacientes { get; }

        public Agenda ListaAgendamento { get; }

        public GeralControlador()
        {
            PacienteForm = new PacienteForm();
            AgendaForm = new AgendaForm();

            Validador = new PacienteValidador();
            ListaPacientes = new ListaPacientes();

            ListaAgendamento = new Agenda();

            AgendaValidador = new AgendaValidador();
        }

        public void Inicia()
        {
            DateTime Nascimento = new DateTime(2000, 01, 01);
            var pacienteTeste = new Paciente(16329868093, "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx", Nascimento);

            ListaPacientes.AdicionarNaLista(pacienteTeste);

            ListaPacientes.ListarPacientesPorCPF();
            MenuPrincipal();
        }
        private void MenuPrincipal()
        {
            switch (PacienteForm.MenuPrincipal())
            {
                case "1":
                    MenuCadastraPaciente();
                    break;
                case "2":
                    MenuAgenda();
                    break; 
                case "3":
                    Console.WriteLine("Fim");
                    break;
            }
        }

        private void MenuCadastraPaciente()
        {
            switch (PacienteForm.MenuCadastraPaciente())
            {
                case "1":
                    CadastrarNovoPaciente();
                    break;
                case "2":
                    Console.WriteLine("//2 - Excluir paciente");
                    ExcluirPacienteCadastrado();
                    break;
                case "3":
                    Console.WriteLine("//3 - Listar pacientes(ordenado por CPF)");
                    ListaPacientes.ListarPacientesPorCPF();
                    break;
                case "4":
                    Console.WriteLine("//4 - Listar pacientes(ordenado por nome)");
                    ListaPacientes.ListarPacientesPorNome();
                    break;
            }
            // Sempre retorna ao Menu Principal depois de processar o pedido
            MenuPrincipal();
        }
        private void MenuAgenda()
        {
            switch (PacienteForm.MenuAgenda())
            {
                case "1":
                    Console.WriteLine("//1 - Agendar consulta");
                    AgendarConsulta();
                    break;
                case "2":
                    Console.WriteLine("//2 - Cancelar agendamento");
                    break;
                case "3":
                    MenuListarAgenda();
                    Console.WriteLine("//3 - Listar agenda");
                    break;
            }
            // Sempre retorna ao Menu Principal depois de processar o pedido
            MenuPrincipal();
        }

        private void AgendarConsulta()
        {
            AgendaForm.AgendarConsulta();
            do
            {
                isValid = AgendaValidador.AgendamentoIsValid(AgendaForm.CPF, AgendaForm.Consulta, AgendaForm.Inicio, AgendaForm.Fim, ListaAgendamento.Agendamentos, ListaPacientes.Pacientes);

                if (isValid)
                {
                    Console.WriteLine("Fim");
                }
                else
                {
                    AgendaForm.AgendarConsulta(AgendaValidador);
                }
            } while (!isValid);
            MenuAgenda();
        }

        private void MenuListarAgenda()
        {
            switch (AgendaForm.MenuListarAgenda())
            {
                case "1":
                    Console.WriteLine("//1 - Listar toda agenda");
                    break; 
                case "2":
                    Console.WriteLine("//2 - Listar agenda periodo");

                    break;
                case "3":
                    MenuAgenda();
                    break;

            }
            MenuAgenda();
        }

        private void CadastrarNovoPaciente()
        {
            PacienteForm.CadastrarNovoPaciente();

            do
            {
                isValid = Validador.PacienteIsValid(PacienteForm.Nome, PacienteForm.CPF, PacienteForm.DataNascimento, ListaPacientes.Pacientes);

                if (isValid)
                {
                    var paciente = new Paciente(Validador.Paciente.CPF,
                                                Validador.Paciente.Nome,
                                                Validador.Paciente.Nascimento);

                    ListaPacientes.AdicionarNaLista(paciente);
                }
                else
                {
                    PacienteForm.CadastrarNovoPaciente(Validador);
                }
            } while (!isValid);
        }
        private void ExcluirPacienteCadastrado()
        {
            PacienteForm.ExcluirPacienteCadastrado();
            do
            {
                isValid = Validador.IsValidCPF(PacienteForm.CPF, ListaPacientes.Pacientes);

                if (isValid)
                {
                    // TODO
                    // a. Um paciente com uma consulta agendada futura não pode ser excluído.
                    // b. Se o paciente tiver uma ou mais consultas agendadas passadas, ele pode ser excluído.
                    //    Nesse caso, os respectivos agendamentos também devem ser excluídos.

                    ListaPacientes.RemoverDaLista(Validador.Paciente.CPF);
                }
                else
                {
                    PacienteForm.ExcluirPacienteCadastrado(Validador);
                }
            } while (!isValid);
        }

    }
}
