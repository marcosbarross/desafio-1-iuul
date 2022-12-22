using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odonto
{
    public class Program
    {
        
        static void Main(string[] args)
        {

            List<Paciente> pacientes = new List<Paciente> { };

            Paciente p1 = new Paciente(62813265047, "Marcos", "17/07/2001");
            Console.WriteLine(pacientes[0]);


            // Controlador.Inicia();
        }

    }

    
}
