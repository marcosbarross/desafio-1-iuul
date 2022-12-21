using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Odonto
{
    public class Paciente
    {

        public Paciente(long CPF, String Nome, String Nascimento) 
        
        {
            Console.WriteLine("Paciente cadastrado!");
        }
        long cpf;
        public long CPF
        {
            
            get { return cpf; }

            set
            {
                if (IsValidCPF(value))
                {
                    cpf = value;
                }

                else { throw new InvalidOperationException("CPF é inválido"); }
            }


        }

        string nome;
        public string Nome
        {

            get { return nome; }

            set
            {
                try
                {
                    if (value.Length < 5)
                    {
                        throw new FormatException();
                    }

                    else
                    {
                        nome = value;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Formato de nome não aceito! É preciso ter mais de 5 caracteres");
                }
            }
        }

        string nascimento;
        public String Nascimento
        {
            get { return nascimento; }
            set
            {
                DateTime data = DateTime.Now;
                string Dia = value.Substring(0, 1);
                string Mes = value.Substring(3, 4);
                string Ano = value.Substring(6, 9);

                if (value.Length == 10 && value.Contains("/") && Convert.ToInt32(Ano) - data.Year < 13)
                {
                  
                  nascimento = value;
                    
                }
            }
        } 




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
