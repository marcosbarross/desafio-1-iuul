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

namespace Odonto
{
    public class Paciente : ListaPacientes
    {
        public Paciente(long _cpf, String _nome, String _nascimento) 
        {
            try
            {
                if (IsValidCPF(_cpf))
                {
                    CPF = _cpf;
                }
                else { throw new InvalidOperationException(); }
            }

            catch (InvalidOperationException)
            {
                Console.WriteLine("CPF INVÁLIDO!");
            }
            try
            {
                if (_nome.Length < 5)
                {
                    throw new FormatException();
                }

                else
                {
                    Nome = _nome;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Formato de nome não aceito! É preciso ter mais de 5 caracteres");
            }
            try
            {
                DateTime data = DateTime.Now;
                string Dia = _nascimento.Substring(0, 2);
                string Mes = _nascimento.Substring(3, 2);
                string Ano = _nascimento.Substring(6, 4);

                if (_nascimento.Length == 10 && _nascimento.Contains("/") && (data.Year - Convert.ToInt32(Ano)) > 13)
                {
                    Nascimento = _nascimento;
                }
                else if ((data.Year - Convert.ToInt32(Ano) < 13))
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    throw new FormatException();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Formato de data não aceito!");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Paciente menor que 13 anos!");
            }
   
        }

        long cpf;
        public long CPF { get { return cpf; } private set { cpf = value; } }

        string nome;
        public string Nome { get { return nome; } private set { nome = value; } }



        string nascimento;
        public string Nascimento { get { return nascimento; } private set { nascimento = value; } }



        private bool IsValidCPF(long cpf) //método copiado da implementação
        {
            if (cpf > 99999999999 || cpf < 11111111111)
                return false;
            else if (cpf == long.Parse(new string((char)((cpf % 10) + 48), 11)))
                return false;
            else
            {
                long cpf_sem_dv = cpf / 100;

                long soma = 0;
                for (int valor = 2; valor <= 11; valor++)
                {
                    soma += cpf_sem_dv % 10 * valor;
                    cpf_sem_dv /= 10;
                }

                int dv1 = (int)(11 - (soma % 11));

                if (dv1 > 9)
                    dv1 = 0;

                cpf_sem_dv = cpf / 10;

                soma = 0;
                for (int valor = 2; valor <= 12; valor++)
                {
                    soma += cpf_sem_dv % 10 * valor;
                    cpf_sem_dv /= 10;
                }

                int dv2 = (int)(11 - (soma % 11));

                if (dv2 > 9)
                    dv2 = 0;

                return dv1 == cpf % 100 / 10 && dv2 == cpf % 10;
            }
        }
    }
}
