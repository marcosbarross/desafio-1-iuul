using Odonto.Extensions;
using System.Collections.Generic;

namespace Odonto
{
    public class ListaPacientes
    {
        /// <summary>
        /// Define uma Lista de Pacientes da Clínica.
        /// </summary>
        public ListaPacientes()
        {
            Pacientes = new Dictionary<string, Paciente>();
        }
        public Dictionary<string, Paciente> Pacientes { get; private set; }

        /// <summary>
        /// Adiciona uma instância de Paciente a Lista de Pacientes.
        /// </summary>
        /// <param name="paciente">Representa o valor de uma instância de <see cref="Paciente"/> e não deve ser nula.</param>
        public void AdicionarNaLista(Paciente paciente)
        {
            Pacientes.Add(paciente.CPF, paciente);
        }

        /// <summary>
        /// Remove um Paciente da Lista de Pacientes.
        /// </summary>
        /// <param name="pacienteCPF">Representa o valor da chave corresponde ao Paciente que deverá ser removido.</param>
        public void RemoverDaLista(string pacienteCPF)
        {
            Pacientes.Remove(pacienteCPF);
        }
        /// <summary>
        /// Mostra todos os Pacientes ordenados, em ordem crescente, pelo valor do CPF
        /// </summary>
        public void ListarPacientesPorCPF()
        {
            Pacientes.ImprimeDicionarioOrdenado(OrdenadoPor.CPF);
        }
        /// <summary>
        /// Mostra todos os Pacientes ordenados, em ordem crescente, pelo valor do Nome
        /// </summary>
        public void ListarPacientesPorNome()
        {
            Pacientes.ImprimeDicionarioOrdenado(OrdenadoPor.Nome);
        }
    }
}
