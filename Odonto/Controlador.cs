using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Odonto
{
    public class Controlador
    {
        public static void Inicia()
        {
            PacienteForm paciente = new PacienteForm();

            //Teste Básico
            Console.WriteLine($"A escolha do Paciente no {Menu.Principal} foi {paciente.MenuPrincipal()}");
            Console.WriteLine($"A escolha do Paciente no {Menu.Cadastra} foi {paciente.MenuCadastraPaciente()}");
            Console.WriteLine($"A escolha do Paciente no {Menu.Agenda} foi {paciente.MenuAgenda()}");

        }
    }
}
