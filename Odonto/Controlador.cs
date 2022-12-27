using Odonto.Paciente;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Odonto
{
    public class Controlador
    {
        private readonly PacienteForm Paciente;

        public Controlador()
        {
            Paciente = new PacienteForm();
        }

        public void Inicia()
        {
            MenuPrincipal();
        }
        private void MenuPrincipal()
        {
            switch (Paciente.MenuPrincipal())
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
            switch (Paciente.MenuCadastraPaciente())
            {
                case "1":
                    CadastrarNovoPaciente();
                    break;
                case "2":
                    Console.WriteLine("//2 - Excluir paciente");
                    break;
                case "3":
                    Console.WriteLine("//3 - Listar pacientes(ordenado por CPF)");
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
            switch (Paciente.MenuCadastraPaciente())
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
            Paciente.CadastrarNovoPaciente();
        }

    }
}
