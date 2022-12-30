using Odonto.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odonto
{
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
