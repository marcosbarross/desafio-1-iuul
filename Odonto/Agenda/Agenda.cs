using Odonto.Extensions;
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
        public void AgendarConsulta(string CPF, DateTime diaConsulta, TimeSpan inicioConsulta, TimeSpan fimConsulta)
        {

        }
        public void AdicionarNaLista(Agendamento agendamento)
        {
            var chave = agendamento.DataConsulta.Date + agendamento.HoraInicio;
            Agendamentos.Add(chave, agendamento);
        }
        public void ListarAgendaToda()
        {
            Agendamentos.ImprimeListaOrdenada();
        }
    }
}
