using Odonto.Extensions;
using System;

namespace Odonto
{
    /// <summary>
    /// Define um Paciente da Clínica Odontológica.
    /// </summary>
    public class Paciente
    {
        public Paciente()
        { }

        /// <summary>
        /// Cria uma instância de Paciente com os argumentos utilizados.
        /// </summary>
        /// <param name="_cpf">Representa o valor da propriedade <see cref="CPF"/> e deve possuir 11 dígitos númericos.</param>
        /// <param name="_nome">Representa o valor da propriedade <see cref="Nome"/> e deve possuir pelo menos 5 letras.</param>
        /// <param name="_nascimento">Representa o valor da propriedade <see cref="Nascimento"/> e deve estar no formato ddMMaaaa.</param>
        public Paciente(string _cpf, String _nome, DateTime _nascimento)
        {
            CPF = _cpf;
            Nome = _nome;
            Nascimento = _nascimento;
            Idade = Nascimento.Idade();
            //Consulta = new Agendamento();
        }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public int Idade { get; }
        public Agendamento Consulta { get; private set; }
        /// <summary>
        /// Sobreescreve o método ToString para fornecer a saída desejada.
        /// </summary>
        /// <returns>Retorna uma sequência de valores de texto, de uma instância de Paciente, de acordo com os requisitos do projeto.</returns>
        public override string ToString()
        {
            var saida = CPF.ToString().PadRight((int)Espacos.CPF) +
                   Nome.ToString().PadRight((int)Espacos.Nome) +
                   Nascimento.ToShortDateString().PadRight((int)Espacos.Nascimento) +
                   Idade.ToString().PadLeft((int)Espacos.Idade);

            if (Consulta != null)
            {
                saida += "\n" + "".PadRight((int)Espacos.CPF) +
                         $"Agendado para: {Consulta.DataConsulta.ToShortDateString()}".PadRight((int)Espacos.Nome) +
                         "".PadRight((int)Espacos.Nascimento) +
                         "".PadLeft((int)Espacos.Idade) +
                         "\n" + "".PadRight((int)Espacos.CPF) +
                         $"{Consulta.HoraInicio:hh\\:mm} às {Consulta.HoraFim:hh\\:mm}".PadRight((int)Espacos.Nome) +
                         "".PadRight((int)Espacos.Nascimento) +
                         "".PadLeft((int)Espacos.Idade);
            }
            return saida;
        }
        public void AdicionarConsulta(Agendamento _consulta)
        {
            Consulta = _consulta;
        }
    }
}
