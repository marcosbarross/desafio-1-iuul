using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odonto
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

        public void listarpacientes()
        {
            for (int i = 0; i < pacientes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {pacientes[i].Nome}, {pacientes[i].CPF}, {pacientes[i].Nascimento}");
            }

            Console.WriteLine();
            Console.WriteLine($"{index} pacientes cadastrados!");
        }

    }
}
