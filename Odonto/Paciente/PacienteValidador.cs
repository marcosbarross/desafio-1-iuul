using Odonto.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odonto
{
    public class PacienteValidador : Validador<CamposPaciente>
    {
        public Paciente Paciente { get; private set; }

        public PacienteValidador()
        {
            Paciente = new Paciente();
        }

        public bool PacienteIsValid(string nome, string strCPF, string strDataNascimento, Dictionary<long, Paciente> Pacientes)
        {
            Clear();

            // Nome
            nome = nome.Trim();
            if (nome.Length < 5)
                AddError(CamposPaciente.NOME, "Nome deve ter ao menos 5 letras");
            else
                Paciente.Nome = nome;

            // Data de nascimento
            try
            {
                Paciente.Nascimento = DateTime.ParseExact(strDataNascimento, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                if (Paciente.Nascimento > DateTime.Now.AddYears(-13))
                    AddError(CamposPaciente.NASCIMENTO, "O paciente deve ter pelo menos 13 anos na data atual");
            }
            catch (Exception)
            {
                AddError(CamposPaciente.NASCIMENTO, "Data de nascimento deve estar no formato DD/MM/AAAA");
            }

            // CPF
            strCPF = strCPF.Trim();

            try
            {
                Paciente.CPF = long.Parse(strCPF);

                if (!Paciente.CPF.IsValidCPF())
                    AddError(CamposPaciente.CPF, "CPF inválido");
                else
                {
                    if (Pacientes.ExisteNoDicionario(Paciente.CPF))
                    {
                        AddError(CamposPaciente.CPF, "CPF repetido! Paciente já cadastrado!");
                    }
                }
            }
            catch (Exception)
            {
                AddError(CamposPaciente.CPF, "CPF deve ter 11 dígitos númericos");
            }

            return IsEmpty;
        }
        public bool IsValidCPF(string strCPF, Dictionary<long, Paciente> Pacientes)
        {
            Erros.Clear();

            // CPF
            strCPF = strCPF.Trim();
            try
            {
                // Todo: CPFs que iniciam com zero estão sendo inválidos, sugestão: fazer tratamento usando a string
                Paciente.CPF = long.Parse(strCPF);

                if (!Paciente.CPF.IsValidCPF())
                    AddError(CamposPaciente.CPF, "CPF inválido");
                else
                {
                    if (!Pacientes.ExisteNoDicionario(Paciente.CPF))
                    {
                        AddError(CamposPaciente.CPF, "O paciente não está cadastrado!");
                    }
                }
            }
            catch (Exception)
            {
                AddError(CamposPaciente.CPF, "CPF deve ter 11 dígitos númericos");
            }
            return IsEmpty;
        }
    }
}
