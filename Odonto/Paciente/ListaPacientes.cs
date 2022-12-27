using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odonto.Paciente
{
    public class ListaPacientes
    {
        Dictionary<long, List<Paciente>> pacientess = new Dictionary<long, List<Paciente>>();
        
        List<Paciente> pacientes = new List<Paciente>();
        private int index;

        public void AdicionarNaLista(Paciente paciente)
        {
            try
            {
                pacientes.Add(paciente);
                pacientess.Add(paciente.CPF, pacientes);
                index++;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("CPF repetido! Paciente já cadastrado!");
            }

        }
        
        public void RemoverDaLista(Paciente paciente)
        {
            pacientes.Remove(paciente);
            pacientess.Remove(paciente.CPF);
            index--;
        }

        public void ListarPacientes()
        {
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("   CPF          NOME   Dt. Nasc.   Idade");
            Console.WriteLine("------------------------------------------------------------");
            for (int i = 0; i < pacientes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {pacientes[i].CPF}, {pacientes[i].Nome}, {pacientes[i].Nascimento}, {pacientes[i].Idade}");
            }

            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine(" ");
            Console.WriteLine($"{index} pacientes cadastrados!");
        }

    }
}
