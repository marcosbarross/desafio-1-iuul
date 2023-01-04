using Odonto.Extensions;
using System;
using System.Collections.Generic;

namespace Odonto
{
    public class PacienteValidador
    {
        public Paciente Paciente { get; private set; }

        public PacienteValidador()
        {
            Paciente = new Paciente();
        }

        public bool IsValidCPF(string strCPF, Dictionary<string, Paciente> Pacientes)
        {
            Paciente.CPF = strCPF.Trim();
            return strCPF.IsValidCPF(Pacientes);
        }

        public bool IsValidNome(string nome)
        {
            try
            {
                // Nome
                nome = nome.Trim();
                if (nome.Length < 5)
                    throw new Exception("Nome deve ter ao menos 5 letras");
            }
            catch (Exception ex)
            {
                return ex.EncerrarProcessoComErro();
            }
            return true;
        }

        public bool IsValidNascimento(string dataNascimento)
        {
            try
            {
                // Data de nascimento
                Paciente.Nascimento = dataNascimento.VerificaData();

                if (Paciente.Nascimento > DateTime.Now.AddYears(-13))
                    throw new Exception("O paciente deve ter pelo menos 13 anos na data atual");
            }
            catch (Exception ex)
            {
                return ex.EncerrarProcessoComErro();
            }
            return true;
        }
    }
}
