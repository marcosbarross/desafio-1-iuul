using Odonto.PacienteNameSpace;
using System;
using System.Collections.Generic;

namespace Odonto
{
    public class Controlador
    {
        private readonly PacienteForm PacienteForm;
        bool isValid, ExistePaciente, isRight;

        public PacienteValidador Validador { get; }

        public ListaPacientes ListaPacientes { get; }

        public Controlador()
        {
            PacienteForm = new PacienteForm();
            Validador = new PacienteValidador();
            ListaPacientes = new ListaPacientes();
        }

        public void Inicia()
        {
            DateTime Nascimento = new DateTime(2000, 01, 01);
            var pacienteTeste = new Paciente(16329868093, "Albert", Nascimento);

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
                    break;
                case "3":
                    Console.WriteLine("//3 - Listar pacientes(ordenado por CPF)");
                    ListaPacientes.ListarPacientesPorCPF();
                    break;
                case "4":
                    Console.WriteLine("//4 - Listar pacientes(ordenado por nome)");
                    break;
            }
            // Sempre retorna ao Menu Principal depois de processar o pedido
            MenuPrincipal();
        }
        private void MenuAgenda()
        {
            switch (PacienteForm.MenuCadastraPaciente())
            {
                case "1":
                    Console.WriteLine("//1 - Agendar consulta");
                    break;
                case "2":
                    Console.WriteLine("//2 - Cancelar agendamento");
                    break;
                case "3":
                    Console.WriteLine("//3 - Listar agenda");
                    break;
            }
            // Sempre retorna ao Menu Principal depois de processar o pedido
            MenuPrincipal();
        }
        private void CadastrarNovoPaciente()
        {
            PacienteForm.CadastrarNovoPaciente();

            do
            {
                isValid = Validador.IsValid(PacienteForm.Nome, PacienteForm.CPF, PacienteForm.DataNascimento);
                ExistePaciente = ListaPacientes.Pacientes.ExisteNoDicionario(Validador.Paciente.CPF);
                isRight = isValid && !ExistePaciente;

                if (isRight)
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
            } while (!isRight);
        }

    }
}
