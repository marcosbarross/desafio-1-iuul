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

        public dictionario<string, Agendamento> Agendamentos { get; private set; }
        
        /*
        public void AgendarConsulta(string CPF, TimeSpan diaConsulta, TimeSpan inicioConsulta, TimeSpan fimConsulta)
        {
            if (diaConsulta < DateTime.Now.TimeOfDay) 
            { 
                throw new Exception("Data da consulta deve ser maior que a data atual"); 
            }
 
            else
            {
                Agendamentos.Add(diaConsulta, diaConsulta, inicioConsulta, fimConsulta);
            }
        }
        */
    }
}
