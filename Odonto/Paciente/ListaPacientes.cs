using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Odonto.PacienteNameSpace
{
    public class ListaPacientes
    {
        public Dictionary<long, Paciente> Pacientes { get; private set; }

        public ListaPacientes()
        {
            Pacientes = new Dictionary<long, Paciente>();
        }


        //List<Paciente> pacientes = new List<Paciente>();
        private int Index { get; set; }

        public void AdicionarNaLista(Paciente paciente)
        {
            Pacientes.Add(paciente.CPF, paciente);
            Index++;
        }
        //    try
        //    {
        //        pacientes.Add(paciente);
        //        pacientess.Add(paciente.CPF, pacientes);

        //    }
        //    catch (ArgumentException)
        //    {
        //        Console.WriteLine("CPF repetido! Paciente já cadastrado!");
        //    }

        //}

        public void RemoverDaLista(Paciente paciente)
        {
            Pacientes.Remove(paciente.CPF);
            Index--;
        }

        public void ListarPacientes()
        {
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("   CPF          NOME   Dt. Nasc.   Idade");
            Console.WriteLine("------------------------------------------------------------");
            //for (int i = 0; i < Pacientes.Count; i++)
            //{
            //    Console.WriteLine($"{i + 1}. {Pacientes[i].CPF}, {Pacientes[i].Nome}, {Pacientes[i].Nascimento}");
            //}

            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine(" ");
            Console.WriteLine($"{Index} pacientes cadastrados!");
        }
        public void ListarPacientesPorCPF()
        {
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("   CPF          NOME   Dt. Nasc.   Idade");
            Console.WriteLine("------------------------------------------------------------");
            var DicionarioOrdenado = Pacientes.OrderBy(x => x.Key).ToList();

            for (int i = 0; i < Pacientes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {DicionarioOrdenado[i].Value}");
            }

            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine(" ");
            Console.WriteLine($"{Index} pacientes cadastrados!");
        }

    }
}
