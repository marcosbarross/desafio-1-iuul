using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Odonto.Extensions
{
    public static class GeralExtensions
    {
        public static bool IsValidCPF(this string strCPF, Dictionary<string, Paciente> Pacientes)
        {
            // CPF
            try
            {
                if (!strCPF.IsCpf())
                    throw new Exception("Erro: CPF inválido");
                if (Pacientes.ExisteNoDicionario(strCPF))
                    throw new Exception("Erro: CPF já cadastrado");
            }
            catch (Exception ex)
            {
                return ex.EncerrarProcessoComErro();
            }
            return true;
        }
        public static bool CanDeleteCPF(this string strCPF, Dictionary<string, Paciente> Pacientes, SortedList<DateTime, Agendamento> Agendamentos)
        {
            // CPF
            try
            {
                if (!strCPF.IsCpf())
                    throw new Exception("Erro: CPF inválido");
                if (!Pacientes.ExisteNoDicionario(strCPF))
                    throw new Exception("Erro: paciente não cadastrado");
                //ToDo: Verificar se o CPF tem consulta agendada
            }
            catch (Exception ex)
            {
                return ex.EncerrarProcessoComErro();
            }
            return true;
        }
        public static bool IsValidCPFAgenda(this string strCPF, Dictionary<string, Paciente> Pacientes)
        {
            // CPF
            try
            {
                if (!strCPF.IsCpf())
                    throw new Exception("Erro: CPF inválido");
                if (!Pacientes.ExisteNoDicionario(strCPF))
                    throw new Exception("Erro: paciente não cadastrado");
            }
            catch (Exception ex)
            {
                return ex.EncerrarProcessoComErro();
            }
            return true;
        }
        public static bool IsCpf(this string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            //cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
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

        public static void ImprimeDicionarioOrdenado<TKey, TValor>(this Dictionary<TKey, TValor> dicionario, OrdenadoPor ordenado)
        {
            PacienteExtensions.CabecalhoListaPacientes();
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
                var item = DicionarioOrdenado[i].Value;

                Console.WriteLine($"{DicionarioOrdenado[i].Value}");
            }
            DicionarioOrdenado.Count.RodapeListaPacientes();
        }

        public static void ImprimeListaOrdenada<TKey, TValor>(this SortedList<TKey, TValor> lista)
        {
            AgendaExtensions.CabecalhoListaAgenda();

            foreach (var item in lista)
            {
                Console.WriteLine($"{item.Value}");
            }

            AgendaExtensions.RodapeListaAgenda();
        }

        public static bool EncerrarProcessoComErro(this Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }

        public static bool TemIntersecao(this Intervalo intervalo, Intervalo outroIntervalo)
        {
            //https://stackoverflow.com/questions/13513932/algorithm-to-detect-overlapping-periods
            return intervalo.DataHoraInicial < outroIntervalo.DataHoraFinal && outroIntervalo.DataHoraInicial < intervalo.DataHoraFinal;
        }

        public static DateTime VerificaData(this string data)
        {
            if (!DateTime.TryParseExact(data, "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime consulta))
                throw new Exception("Data deve estar no formato ddMMaaaa");

            return consulta;
        }
        public static DateTime VerificaHora(this string hora)
        {
            if (!DateTime.TryParseExact(hora, "HHmm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime horario))
                throw new Exception("Erro: O formato de hora deve estar em HHmm");
            // Todo: Verificar se As horas inicial e final são definidas sempre de 15 em 15 minutos.
            var Minutos = horario.TimeOfDay.Minutes;

            if (Minutos != 0 && Minutos % 15 != 0)
                throw new Exception("Erro: Os minutos devem ser de 15 em 15 minutos");

            return horario;
        }
        //Ref: https://stackoverflow.com/questions/17590528/pad-left-pad-right-pad-center-string
        public static string PadCenter(this string str, int length)
        {
            int spaces = length - str.Length;
            int padLeft = spaces / 2 + str.Length;
            return str.PadLeft(padLeft).PadRight(length);
        }
    }
}
