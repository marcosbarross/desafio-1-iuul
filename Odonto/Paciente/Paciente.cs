using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Odonto.PacienteNameSpace
{
    public class Paciente
    {
        private readonly int cpf = 14;
        private readonly int nome = 14;
        private readonly int nascimento = 14;
        private readonly int idade = 5;

        public Paciente()
        { }

        public Paciente(long _cpf, String _nome, DateTime _nascimento)
        {
            CPF = _cpf;
            Nome = _nome;
            Nascimento = _nascimento;
            Idade = Nascimento.Idade();
        }
        public long CPF { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public int Idade { get; }

        public override string ToString()
        {
            return this.ValoresPacientes();
        }
        //public Paciente(long _cpf, String _nome, String _nascimento) 
        //{
        //    try
        //    {
        //        if (IsValidCPF(_cpf))
        //        {
        //            CPF = _cpf;
        //        }
        //        else { throw new InvalidOperationException(); }
        //    }

        //    catch (InvalidOperationException)
        //    {
        //        Console.WriteLine("CPF INVÁLIDO!");
        //    }
        //    try
        //    {
        //        if (_nome.Length < 5)
        //        {
        //            throw new FormatException();
        //        }

        //        else
        //        {
        //            Nome = _nome;
        //        }
        //    }
        //    catch (FormatException)
        //    {
        //        Console.WriteLine("Formato de nome não aceito! É preciso ter mais de 5 caracteres");
        //    }
        //    try
        //    {
        //        DateTime data = DateTime.Now;
        //        string Dia = _nascimento.Substring(0, 2);
        //        string Mes = _nascimento.Substring(3, 2);
        //        string Ano = _nascimento.Substring(6, 4);
        //        idade = data.Year - Convert.ToInt32(Ano);

        //        if (_nascimento.Length == 10 && _nascimento.Contains("/") && idade > 13)
        //        {

        //            Nascimento = _nascimento;
        //        }
        //        else if (idade < 13)
        //        {
        //            throw new ArgumentOutOfRangeException();
        //        }
        //        else
        //        {
        //            throw new FormatException();
        //        }
        //    }
        //    catch (FormatException)
        //    {
        //        Console.WriteLine("Formato de data não aceito!");
        //    }
        //    catch (ArgumentOutOfRangeException)
        //    {
        //        Console.WriteLine("Paciente menor que 13 anos!");
        //    }

        //}
    }
}
