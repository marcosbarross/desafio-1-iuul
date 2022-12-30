using Odonto.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Odonto
{
    public class AgendaValidador : Validador<CamposAgenda>
    {
        public Agendamento Agendamento { get; private set; }

        public AgendaValidador()
        {
            Agendamento = new Agendamento();
        }
        private bool EncerraProcesso(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return IsEmpty;
        }
        public bool AgendamentoIsValid(string strCPF, string strConsulta, string strInicio, string strFim, SortedList<DateTime, Agendamento> Agendamentos, Dictionary<long, Paciente> Pacientes)
        {
            // CPF
            strCPF = strCPF.Trim();

            try
            {
                if (!long.TryParse(strCPF, out long cpf))
                    throw new Exception("Erro: CPF deve ter 11 dígitos númericos");

                Agendamento.Paciente.CPF = cpf;

                if (!cpf.IsValidCPF())
                   throw new Exception("Erro: CPF inválido");
                else if(!Pacientes.ExisteNoDicionario(cpf))
                   throw new Exception("Erro: paciente não cadastrado");
            }
            catch (Exception ex) 
            {
                AddError(CamposAgenda.CPF, ex.Message);
                return EncerraProcesso(ex);
            }

            // Data de Consulta
            try
            {
                Agendamento.DataConsulta = DateTime.ParseExact(strConsulta, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                Exception ex = new Exception("Data da consulta deve estar no formato dd/mm/aaaa");
                AddError(CamposAgenda.CONSULTA, ex.Message);
                return EncerraProcesso(ex);
            }
            return IsEmpty;
        }
    }
}
