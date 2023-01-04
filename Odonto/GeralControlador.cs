using System;
using System.Collections.Generic;
using System.Linq;

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
            var pacienteTeste = new Paciente("16329868093", "Lucas da Silva", Nascimento);
            var pacienteTeste1 = new Paciente("79405414046", "Ana de Lima", Nascimento);
            var pacienteTeste2 = new Paciente("44704062015", "Lucas de Lima", Nascimento);


            ListaPacientes.AdicionarNaLista(pacienteTeste);
            ListaPacientes.AdicionarNaLista(pacienteTeste1);
            ListaPacientes.AdicionarNaLista(pacienteTeste2);

            var data = new DateTime(2023, 01, 15);
            var data1 = new DateTime(2023, 01, 14);
            var data2 = new DateTime(2023, 01, 13);


            var inicio = new TimeSpan(12, 0, 0);
            var inicio1 = new TimeSpan(11, 0, 0);

            var fim = new TimeSpan(15, 0, 0);
            var consulta = new Agendamento(data, inicio, fim, pacienteTeste);
            var consulta1 = new Agendamento(data1, inicio, fim, pacienteTeste1);
            var consulta2 = new Agendamento(data2, inicio1, fim, pacienteTeste2);

            ListaAgendamento.AdicionarNaLista(consulta);
            ListaAgendamento.AdicionarNaLista(consulta1);
            ListaAgendamento.AdicionarNaLista(consulta2);

            ListaPacientes.Pacientes[pacienteTeste.CPF].AdicionarConsulta(consulta);
            ListaPacientes.Pacientes[pacienteTeste1.CPF].AdicionarConsulta(consulta1);
            ListaPacientes.Pacientes[pacienteTeste2.CPF].AdicionarConsulta(consulta2);

            //ListaAgendamento.ListarAgendaToda();
            ListaPacientes.ListarPacientesPorNome();

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
                    ExcluirPacienteCadastrado();
                    break;
                case "3":
                    ListaPacientes.ListarPacientesPorCPF();
                    break;
                case "4":
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
                    AgendarConsulta();
                    break;
                case "2":
                    Console.WriteLine("//2 - Cancelar agendamento (NotImplemented)");
                    break;
                case "3":
                    MenuListarAgenda();
                    break;
                case "4":
                    return;
            }
            MenuAgenda();
        }

        private void AgendarConsulta()
        {
            SolicitarCPFAgenda();
            SolicitarDataHoraConsulta();

            Console.WriteLine("Agendamento realizado com sucesso!");
        }

        private void MenuListarAgenda()
        {
            switch (AgendaForm.MenuListarAgenda())
            {
                case "1":
                    Console.WriteLine("//1 - Listar toda agenda");
                    ListaAgendamento.ListarAgendaToda();
                    break;
                case "2":
                    Console.WriteLine("//2 - Listar agenda periodo (NotImplemented)");
                    break;
                case "3":
                    return;

            }
            MenuListarAgenda();
        }

        // Paciente
        private void CadastrarNovoPaciente()
        {
            SolicitarCPF();
            SolicitarNome();
            SolicitarNascimento();
            var Paciente = new Paciente(Validador.Paciente.CPF, Validador.Paciente.Nome, Validador.Paciente.Nascimento);

            ListaPacientes.AdicionarNaLista(Paciente);

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

        // Agenda
        private void SolicitarCPFAgenda()
        {
            // CPF
            do
            {
                AgendaForm.SolicitarCPF();
                isValid = AgendaValidador.IsValidCPF(AgendaForm.CPF, ListaPacientes.Pacientes);

            } while (!isValid);
        }
        private void SolicitarDataHoraConsulta()
        {
            try
            {
                AgendaForm.SolicitarDataConsulta();
                AgendaValidador.IsValidDataConsulta(AgendaForm.Consulta);

                // Todo: e se não houver nenhum horário disponível para a data escolhida? Nunca vai sair do loop
                bool isValidHora = false;
                do
                {
                    SolicitarHoraInicio();
                    if (AgendaValidador.Agendamento.HoraInicio != AgendaValidador.FechaAs)
                        SolicitarHoraFim();

                    isValidHora = AgendaValidador.IsHorarioDisponivelInicio(ListaAgendamento.Agendamentos);

                } while (!isValidHora);

                // Agendar Consulta para o Paciente
                var auxiliarConsulta = AgendaValidador.Agendamento;
                var consulta = new Agendamento(auxiliarConsulta, ListaPacientes.Pacientes[auxiliarConsulta.Paciente.CPF]);
                ListaAgendamento.AdicionarNaLista(consulta);
                ListaPacientes.Pacientes[auxiliarConsulta.Paciente.CPF].AdicionarConsulta(consulta);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                SolicitarDataHoraConsulta();
            }
        }
        private void SolicitarHoraInicio()
        {
            // Hora Inicio Consulta
            do
            {
                AgendaForm.SolicitarHoraInicio();
                isValid = AgendaValidador.IsValidHoraInicio(AgendaForm.Inicio);

            } while (!isValid);
        }
        private void SolicitarHoraFim()
        {
            // Hora Fim Consulta
            do
            {
                AgendaForm.SolicitarHoraFim();
                isValid = AgendaValidador.IsValidHoraFim(AgendaForm.Fim);

            } while (!isValid);
        }
        private void ExcluirPacienteCadastrado()
        {
            AgendaForm.SolicitarCPF();
            isValid = AgendaValidador.CanDeleteCPF(AgendaForm.CPF, ListaPacientes.Pacientes, ListaAgendamento.Agendamentos);

            if (isValid)
            {
                // Pega uma lista com todos os agendamentos
                var values = ListaAgendamento.Agendamentos.Values;

                // Busca todos os agendamentos de um paciente
                var query = values.Where(c => c.Paciente.CPF == AgendaForm.CPF);

                // Se o paciente tiver uma ou mais consultas agendadas passadas, ele pode ser excluído.
                if (query.Any())
                {
                    ListaPacientes.RemoverDaLista(AgendaForm.CPF);

                    //Excluí os respectivos agendamentos.
                    int[] IndexParaRemocao = new int[] { };
                    foreach (var item in query.Reverse())
                    {
                        ListaAgendamento.RemoverDaLista(item);
                    }
                }
            }
        }
    }
}
