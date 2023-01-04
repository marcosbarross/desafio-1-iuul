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
            var pacienteTeste = new Paciente("16329868093", "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx", Nascimento);

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
                    return;
            }
            MenuPrincipal();
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
                case "5":
                    return;
            }
            MenuCadastraPaciente();
        }
        private void MenuAgenda()
        {
            switch (PacienteForm.MenuAgenda())
            {
                case "1":
                    //ToDo: após cadastrar uma consulta, a opcao retornar ao menu principal e depois Fim, não encerra
                    //o processo na primeira vez, apenas ao inserir novamente a opcao Fim
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
                case "4":
                    return;
            }
            MenuAgenda();
        }

        private void AgendarConsulta()
        {
            SolicitarCPFAgenda();
            SolicitarDataConsulta();
            SolicitarHoraInicio();
            SolicitarHoraFim();

            Console.WriteLine("Agendamento realizado com sucesso!");
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
                    return;

            }
            MenuListarAgenda();
        }

        private void CadastrarNovoPaciente()
        {
            SolicitarCPF();
            SolicitarNome();
            SolicitarNascimento();
            ListaPacientes.AdicionarNaLista(PacienteForm);

            Console.WriteLine("Paciente cadastrado com sucesso!");
        }

        private void SolicitarCPF()
        {
            // CPF
            do
            {
                PacienteForm.SolicitarCPF();
                isValid = Validador.IsValidCPF(PacienteForm.CPF, ListaPacientes.Pacientes);

            } while (!isValid);
        }



        private void SolicitarNome()
        {
            // Nome
            do
            {
                PacienteForm.SolicitarNome();
                isValid = Validador.IsValidNome(PacienteForm.Nome);

            } while (!isValid);
        }
        private void SolicitarNascimento()
        {
            // Nascimento
            do
            {
                PacienteForm.SolicitarNascimento();
                isValid = Validador.IsValidNascimento(PacienteForm.DataNascimento);

            } while (!isValid);
        }

        private void SolicitarCPFAgenda()
        {
            // CPF
            do
            {
                AgendaForm.SolicitarCPF();
                isValid = AgendaValidador.IsValidCPF(AgendaForm._CPF, ListaPacientes.Pacientes);

            } while (!isValid);
        }
        private void SolicitarDataConsulta()
        {
            // Data de Consulta
            do
            {
                AgendaForm.SolicitarDataConsulta();
                isValid = AgendaValidador.IsValidDataConsulta(AgendaForm._Consulta);

            } while (!isValid);
        }
        private void SolicitarHoraInicio()
        {
            // Hora Inicio Consulta
            do
            {
                //AgendaForm.SolicitarHoraInicio();
                isValid = AgendaValidador.IsValidHoraInicio(AgendaForm._Inicio);

            } while (!isValid);
        }
        private void SolicitarHoraFim()
        {
            // Hora Fim Consulta
            do
            {
                //AgendaForm.SolicitarHoraFim();
                isValid = AgendaValidador.IsValidHoraFim(AgendaForm._Fim);

            } while (!isValid);
        }
        private void ExcluirPacienteCadastrado()
        {
            SolicitarExclusaoCPF();

            if (isValid)
            {
                // TODO
                // a. Um paciente com uma consulta agendada futura não pode ser excluído.
                // b. Se o paciente tiver uma ou mais consultas agendadas passadas, ele pode ser excluído.
                //    Nesse caso, os respectivos agendamentos também devem ser excluídos.

                ListaPacientes.RemoverDaLista(Validador.Paciente.CPF);
            }
        }

        private void SolicitarExclusaoCPF()
        {
            // Hora Fim Consulta
            do
            {
                AgendaForm.SolicitarCPF();
                isValid = AgendaValidador.CanDeleteCPF(AgendaForm._CPF, ListaPacientes.Pacientes, ListaAgendamento.Agendamentos);

            } while (!isValid);
        }
    }
}
