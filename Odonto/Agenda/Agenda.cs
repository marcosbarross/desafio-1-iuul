using Odonto.Extensions;
using System;
using System.Collections.Generic;

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
