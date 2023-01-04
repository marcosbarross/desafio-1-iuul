using Odonto.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Odonto
{
    public class AgendaValidador
    {
        public Agendamento Agendamento { get; private set; }

        public AgendaValidador()
        {
            Agendamento = new Agendamento();
        }

        public bool IsValidCPF(string strCPF, Dictionary<string, Paciente> Pacientes)
        {
            Agendamento.Paciente.CPF = strCPF.Trim();
            return strCPF.IsValidCPFAgenda(Pacientes);
        }
        public bool IsValidDataConsulta(string strConsulta)
        {
            try
            {
                // Data de Consulta
                Agendamento.DataConsulta = strConsulta.VerificaData();

                if (Agendamento.DataConsulta.Date < DateTime.Today.Date)
                    throw new Exception("Erro: data da consulta não deve ser menor que a data de hoje");
            }
            catch (Exception ex)
            {
                return ex.EncerrarProcessoComErro();
            }
            return true;
        }
        public bool IsValidDataHoraConsulta(string dataHoraConsulta)
        {

        }
        public bool IsValidHoraInicio(string strInicio)
        {
            try
            {
                // Data de Consulta
                Agendamento.HoraInicio = strInicio.VerificaHora().TimeOfDay;
            }
            catch (Exception ex)
            {
                return ex.EncerrarProcessoComErro();
            }
            return true;
        }
        public bool IsValidHoraFim(string strFim)
        {
            try
            {
                // Data de Consulta
                Agendamento.HoraFim = strFim.VerificaHora().TimeOfDay;
            }
            catch (Exception ex)
            {
                return ex.EncerrarProcessoComErro();
            }
            return true;
        }

        public bool CanDeleteCPF(string strCPF, Dictionary<string, Paciente> Pacientes, SortedList<DateTime, Agendamento> Agendamentos)
        {
            try
            {
                Agendamento.Paciente.CPF = strCPF.Trim();
                strCPF.CanDeleteCPF(Pacientes, Agendamentos);
            }
            catch (Exception ex)
            {
                return ex.EncerrarProcessoComErro();
            }
            return true;
        }



    }
}
