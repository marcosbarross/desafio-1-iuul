using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odonto
{
    /// <summary>
    /// Define a Agenda da Clínica Odontológica.
    /// </summary>
    public class Agenda
    {
        public Agenda()
        {
            Agendamentos = new SortedList<DateTime, Agendamento>();
        }
        public SortedList<DateTime, Agendamento> Agendamentos { get; private set; }

        public void AgendarConsulta(string CPF, TimeSpan diaConsulta, TimeSpan inicioConsulta, TimeSpan fimConsulta)
        {

        }
    }
}
