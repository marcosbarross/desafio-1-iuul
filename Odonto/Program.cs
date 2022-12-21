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

            Paciente marcos = new Paciente(13634164484, "Marcos", "19/07/2001");
            Console.WriteLine($"{marcos.CPF} {marcos.Nome} {marcos.Nascimento}");

        }
    }
}
