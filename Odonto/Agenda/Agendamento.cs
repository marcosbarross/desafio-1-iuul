using Odonto.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odonto
{
    /// <summary>
    /// Define um agendamento realizado para um Paciente
    /// </summary>
    public class Agendamento
    {
        public DateTime DataConsulta { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public TimeSpan Tempo { get; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public Paciente Paciente { get; set; }

        public Agendamento()
        {
            Paciente = new Paciente();
        }

        /// <summary>
        /// Cria uma instância de um agendamento.
        /// </summary>
        /// <param name="data">Representa o valor da propriedade <see cref="DataConsulta"/> e deve estar no formato ddMMaaaa.</param>
        /// <param name="horaInicio">Representa o valor da propriedade <see cref="HoraInicio"/> e deve estar no formato HHmm.</param>
        /// <param name="horaFim">Representa o valor da propriedade <see cref="HoraFim"/> e deve estar no formato HHmm.</param>
        /// <param name="paciente">Representa o valor de uma instância de <see cref="Paciente"/> e não deve ser nula.</param>
        public Agendamento(DateTime data, TimeSpan horaInicio, TimeSpan horaFim, Paciente paciente)
        {
            DataConsulta = data.Date + horaInicio;

            HoraInicio = horaInicio;
            HoraFim = horaFim;
            Paciente = paciente;

            Tempo = horaFim.Subtract(horaInicio);
            Nome = Paciente.Nome;
            Nascimento = Paciente.Nascimento;
        }
        public override string ToString()
        {
            return this.ValoresAgenda();
        }
    }
}
