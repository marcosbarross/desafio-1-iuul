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
            Console.WriteLine($"A escolha do Paciente foi {paciente.MenuPrincipal()}");
        }
    }
}
