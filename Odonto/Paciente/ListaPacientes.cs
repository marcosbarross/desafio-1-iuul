using Odonto.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Odonto
{
    public class ListaPacientes
    {
        public Dictionary<string, Paciente> Pacientes { get; private set; }

        public ListaPacientes()
        {
            Pacientes = new Dictionary<string, Paciente>();
        }

        public void AdicionarNaLista(Paciente paciente)
        {
            Pacientes.Add(paciente.CPF, paciente);
        }
        
        public void RemoverDaLista(string pacienteCPF)
        {
            try
            {
                Pacientes.Remove(pacienteCPF);
            }
            catch
            {
                
            }
        }

        public void ListarPacientesPorCPF()
        {
            Pacientes.ImprimeDicionarioOrdenado(OrdenadoPor.CPF);
        }
        public void ListarPacientesPorNome()
        {
            Pacientes.OrderBy(p => p.Value.Nome);
            Pacientes.ImprimeDicionarioOrdenado(OrdenadoPor.Nome);
        }

    }
}
