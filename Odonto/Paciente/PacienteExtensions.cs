using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odonto.Extensions
{
    public static class PacienteExtensions
    {
        public static string ValoresPacientes(this Paciente paciente)
        {
            return paciente.CPF.ToString().PadRight((int)Espacos.CPF) +
                   paciente.Nome.ToString().PadRight((int)Espacos.Nome) +
                   paciente.Nascimento.ToShortDateString().PadRight((int)Espacos.Nascimento) +
                   paciente.Idade.ToString().PadLeft((int)Espacos.Idade);
        }
        public static void CabecalhoListaPacientes()
        {
            Console.WriteLine("------------------------------------------------------------");
            Console.Write("CPF".PadRight((int)Espacos.CPF));
            Console.Write("Nome".PadRight((int)Espacos.Nome));
            Console.Write("Dt. Nasc.".PadRight((int)Espacos.Nascimento));
            Console.WriteLine("Idade".PadLeft((int)Espacos.Idade));
            Console.WriteLine("------------------------------------------------------------");
        }
        public static void RodapeListaPacientes(this int Index)
        {
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine(" ");
            Console.WriteLine($"{Index} pacientes cadastrados!");
            Console.WriteLine(" ");
        }
    }
}
