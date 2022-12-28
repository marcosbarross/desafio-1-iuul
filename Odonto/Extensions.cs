using Odonto.PacienteNameSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Odonto
{
    public static class Extensions
    {
        public static bool IsValidCPF(this long cpf)
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

        public static bool NaoEhEscolhaValida(this string escolha, Menu menu)
        {
            // Todo: Se possível, melhorar esse método. Motivo: Repetição de código
            switch (menu)
            {
                case Menu.Principal:
                    return !EscolhaUmDoisTres(escolha);
                case Menu.Cadastra:
                    return !(EscolhaUmDoisTres(escolha) || escolha == "4" || escolha == "5");
                case Menu.Agenda:
                    return !(EscolhaUmDoisTres(escolha) || escolha == "4");
                case Menu.ListarAgenda:
                    return !EscolhaUmDoisTres(escolha);
                default: return false;
            }
        }
        public static bool EscolhaUmDoisTres(string escolha)
        {
            return escolha == "1" || escolha == "2" || escolha == "3";
        }
        public static bool ExisteNoDicionario<TKey, TValor>(this Dictionary<TKey, TValor> dicionario, TKey chave)
        {
            return dicionario.ContainsKey(chave);
        }

        // Ref: https://stackoverflow.com/questions/2194999/how-to-calculate-an-age-based-on-a-birthday
        public static int Idade(this DateTime aniversario)
        {
            DateTime now = DateTime.Today;
            int idade = now.Year - aniversario.Year;
            if (now < aniversario.AddYears(idade))
            {
                idade--;
            }

            return idade;
        }

        public static void CabecalhoListaPacientes()
        {
            Console.WriteLine("------------------------------------------------------------");
            Console.Write("CPF".PadRight((int)Espacos.CPF));
            Console.Write("Nome".PadRight((int)Espacos.Nome));
            Console.Write("Dt. Nasc.".PadRight((int)Espacos.Nascimento));
            Console.WriteLine("Idade".PadLeft((int)Espacos.Idade));
            Console.WriteLine("------------------------------------------------------------");
        }
        public static void RodapeListaPacientes(this int Index)
        {
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine(" ");
            Console.WriteLine($"{Index} pacientes cadastrados!");
            Console.WriteLine(" ");
        }
        public static void ImprimeDicionarioOrdenado<TKey, TValor>(this Dictionary<TKey, TValor> dicionario, OrdenadoPor ordenado)
        {
            CabecalhoListaPacientes();
            var DicionarioOrdenado = new List<KeyValuePair<TKey, TValor>>();
            switch (ordenado)
            {
                case OrdenadoPor.CPF:
                    DicionarioOrdenado = dicionario.OrderBy(x => x.Key).ToList();
                    break; 
                case OrdenadoPor.Nome:
                    DicionarioOrdenado = dicionario.OrderBy(x => x.Value).ToList();
                    break;
            }

            for (int i = 0; i < DicionarioOrdenado.Count; i++)
            {
                Console.WriteLine($"{DicionarioOrdenado[i].Value}");
            }
            DicionarioOrdenado.Count.RodapeListaPacientes();
        }
        public static string ValoresPacientes(this Paciente paciente)
        {
            return paciente.CPF.ToString().PadRight((int)Espacos.CPF) +
                   paciente.Nome.ToString().PadRight((int)Espacos.Nome) +
                   paciente.Nascimento.ToShortDateString().PadRight((int)Espacos.Nascimento) +
                   paciente.Idade.ToString().PadLeft((int)Espacos.Idade);
        }
    }
}
