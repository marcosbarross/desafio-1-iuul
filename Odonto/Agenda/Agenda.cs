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
            Agendamentos.Add(ChaveAgendamento(agendamento), agendamento);
        }
        public void RemoverDaLista(Agendamento agendamento)
        {
            Agendamentos.Remove(ChaveAgendamento(agendamento));
        }
        public int IndexElementoLista(Agendamento agendamento)
        {
            return Agendamentos.IndexOfKey(ChaveAgendamento(agendamento));
        }
        private DateTime ChaveAgendamento(Agendamento agendamento)
        {
            return agendamento.DataConsulta.Date + agendamento.HoraInicio;
        }
        public void ListarAgendaToda()
        {
            Agendamentos.ImprimeListaOrdenada();
        }
    }
}
