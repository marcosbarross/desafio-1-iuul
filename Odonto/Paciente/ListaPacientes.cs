using Odonto.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

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
            PacienteExtensions.CabecalhoListaPacientes();
            var values = Pacientes.Values;

            var listaOrdenada = values.OrderBy(x => x.CPF);

            foreach (var item in listaOrdenada)
            {
                Console.WriteLine(item);
            }
            PacienteExtensions.RodapeListaPacientes();

        }
        /// <summary>
        /// Mostra todos os Pacientes ordenados, em ordem crescente, pelo valor do Nome
        /// </summary>
        public void ListarPacientesPorNome()
        {
            PacienteExtensions.CabecalhoListaPacientes();

            var values = Pacientes.Values;

            var listaOrdenada = values.OrderBy(x => x.Nome);

            foreach (var item in listaOrdenada)
            {
                Console.WriteLine(item);
            }
            PacienteExtensions.RodapeListaPacientes();

        }
    }
}
