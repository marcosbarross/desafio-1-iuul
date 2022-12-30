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
        public Dictionary<long, Paciente> Pacientes { get; private set; }

        public ListaPacientes()
        {
            Pacientes = new Dictionary<long, Paciente>();
        }

        public void AdicionarNaLista(Paciente paciente)
        {
            Pacientes.Add(paciente.CPF, paciente);
        }

        public void RemoverDaLista(long pacienteCPF)
        {
            Pacientes.Remove(pacienteCPF);
        }

        public void ListarPacientesPorCPF()
        {
            Pacientes.ImprimeDicionarioOrdenado(OrdenadoPor.CPF);
        }
        public void ListarPacientesPorNome()
        {
            Pacientes.ImprimeDicionarioOrdenado(OrdenadoPor.Nome);
        }

    }
}
