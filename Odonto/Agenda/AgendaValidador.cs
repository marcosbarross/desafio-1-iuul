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
    /// <summary>
    /// Define o Validador da Agenda da Clínica Odontológica.
    /// </summary>
    public class AgendaValidador
    {
        public Agendamento Agendamento { get; private set; }

        public AgendaValidador()
        {
            Agendamento = new Agendamento();
        }
        /// <summary>
        /// Faz as validações necessárias para o CPF informado.
        /// </summary>
        /// <param name="strCPF">Representa o valor do CPF informado.</param>
        /// <param name="Pacientes">Representa a lista de Pacientes do sistema.</param>
        /// <returns>Retorna um valor verdadeiro se o CPF informado for válido.</returns>
        public bool IsValidCPF(string strCPF, Dictionary<string, Paciente> Pacientes)
        {
            Agendamento.Paciente.CPF = strCPF.Trim();
            return strCPF.IsValidCPFAgenda(Pacientes);
        }
        /// <summary>
        /// Faz as validações necessárias para a data de consulta informada.
        /// </summary>
        /// <param name="strConsulta">Representa o valor da data de consulta informada.</param>
        /// <returns>Retorna um valor verdadeiro se a data de consulta for válida.</returns>
        public bool IsValidDataConsulta(string strConsulta)
        {
            try
            {
                // Data de Consulta
                Agendamento.DataConsulta = strConsulta.VerificaData();
            }
            catch (Exception ex)
            {
                return ex.EncerrarProcessoComErro();
            }
            return true;
        }
        /// <summary>
        /// Faz as validações necessárias para o horário de início da consulta.
        /// </summary>
        /// <param name="strInicio">Representa o valor da hora de início da consulta.</param>
        /// <returns>Retorna um valor verdadeiro se a hora de início for válida.</returns>
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
        /// <summary>
        /// Faz as validações necessárias para o horário de término da consulta.
        /// </summary>
        /// <param name="strInicio">Representa o valor da hora de término da consulta.</param>
        /// <returns>Retorna um valor verdadeiro se a hora de término for válida.</returns>
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
        /// <summary>
        /// Faz as validações necessárias para exclusão de um paciente.
        /// </summary>
        /// <param name="strCPF"></param>
        /// <param name="Pacientes"></param>
        /// <param name="Agendamentos"></param>
        /// <returns></returns>
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
