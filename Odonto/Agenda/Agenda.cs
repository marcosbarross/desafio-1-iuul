using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odonto
{
    public class Agenda
    {
        public SortedList<DateTime, Agendamento> Agendamentos { get; private set; }
        public Agenda() 
        {
            Agendamentos = new SortedList<DateTime, Agendamento>();
        }
        public void AgendarConsulta(string CPF, TimeSpan diaConsulta, TimeSpan inicioConsulta, TimeSpan fimConsulta)
        {

        }
    }
}
