using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Odonto.Extensions
{
    public static class GeralExtensions
    {
        /// <summary>
        /// Valida se um texto é um CPF válido e se já existe um cadastro para este CPF
        /// </summary>
        /// <param name="strCPF"></param>
        /// <param name="Pacientes"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Verifica se um CPF é válido, se o paciente está cadastrado e se ele possui consulta futura agendada.
        /// </summary>
        /// <param name="strCPF"></param>
        /// <param name="Pacientes"></param>
        /// <param name="Agendamentos"></param>
        /// <returns></returns>
        public static bool CanDeleteCPF(this string strCPF, Dictionary<string, Paciente> pacientes, SortedList<DateTime, Agendamento> agendamentos)
        {
            if (!strCPF.IsCpf())
                throw new Exception("Erro: CPF inválido.");
            if (!pacientes.ExisteNoDicionario(strCPF))
                throw new Exception("Erro: paciente não cadastrado.");
            if (strCPF.PacienteTemAgendamentoFuturo(agendamentos))
                throw new Exception("Erro: paciente está agendado.");

            return true;
        }

        /// <summary>
        /// Valida se um CPF é válido e se faz parte do conjunto de pacientes cadastrados.
        /// </summary>
        /// <param name="strCPF"></param>
        /// <param name="Pacientes"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Valida se um texto é um CPF válido.
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Verifica se uma escolha não é válida
        /// </summary>
        /// <param name="escolha"></param>
        /// <param name="menu"></param>
        /// <returns>Retorna um valor verdadeiro quando a escolha não é valida.</returns>
        public static bool NaoEhEscolhaValida(this string escolha, Menu menu)
        {
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
        /// <summary>
        /// Verifica se uma chave existe em uma lista com chave e valor quaisquer.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValor"></typeparam>
        /// <param name="dicionario"></param>
        /// <param name="chave"></param>
        /// <returns></returns>
        public static bool ExisteNoDicionario<TKey, TValor>(this Dictionary<TKey, TValor> dicionario, TKey chave)
        {
            return dicionario.ContainsKey(chave);
        }

        // Ref: https://stackoverflow.com/questions/2194999/how-to-calculate-an-age-based-on-a-birthday
        /// <summary>
        /// Calcula a Idade de uma pessoa a partir da data de aniversário fornecida.
        /// </summary>
        /// <param name="aniversario"></param>
        /// <returns>Retorna um número inteiro que representa a idade.</returns>
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
        /// <summary>
        /// Mostra ao usuário uma lista ordenada que possua chave e valor de qualquer tipo.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValor"></typeparam>
        /// <param name="lista"></param>
        public static void ImprimeListaOrdenada<TKey, TValor>(this SortedList<TKey, TValor> lista)
        {
            AgendaExtensions.CabecalhoListaAgenda();

            foreach (var item in lista)
            {
                Console.WriteLine($"{item.Value}");
            }

            AgendaExtensions.RodapeListaAgenda();
        }
        /// <summary>
        /// Fornece ao usuário a mensagem de erro.
        /// </summary>
        /// <param name="ex"></param>
        /// <returns>Retorna um valor falso.</returns>
        public static bool EncerrarProcessoComErro(this Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
        /// <summary>
        /// Verifica se um Intervalo (Data e Hora) tem sopreposição com outro Intervalo.
        /// </summary>
        /// <param name="intervalo"></param>
        /// <param name="outroIntervalo"></param>
        /// <returns>Retorna verdaidado se houver sopreposição.</returns>
        public static bool TemIntersecao(this Intervalo intervalo, Intervalo outroIntervalo)
        {
            //https://stackoverflow.com/questions/13513932/algorithm-to-detect-overlapping-periods
            return intervalo.DataHoraInicial < outroIntervalo.DataHoraFinal && outroIntervalo.DataHoraInicial < intervalo.DataHoraFinal;
        }
        /// <summary>
        /// Verifica se uma data qualquer está no formato (ddMMaaaa), sendo dd = dia com 2 digitos, MM = mes com 2 digitos, aaaa = ano com 4 digitos.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna uma data pronta para uso.</returns>
        /// <exception cref="Exception">Retorna um erro caso a data não esteja no formato correto ou não seja válida</exception>
        public static DateTime VerificaData(this string data)
        {
            if (!DateTime.TryParseExact(data, "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime consulta))
                throw new Exception("Data deve estar no formato ddMMaaaa");

            return consulta;
        }
        /// <summary>
        /// Verifica se a hora informada está no formato correto e se os minutos são múltiplos de 15 minutos
        /// </summary>
        /// <param name="hora"></param>
        /// <returns>Retorna a hora no formato correto para a aplicação.</returns>
        /// <exception cref="Exception"></exception>
        public static TimeSpan VerificaHora(this string hora)
        {
            if (!DateTime.TryParseExact(hora, "HHmm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime horario))
                throw new Exception("Erro: O formato de hora deve estar em HHmm");

            var Minutos = horario.TimeOfDay.Minutes;

            return !(Minutos == 0 || Minutos % 15 == 0)
                ? throw new Exception("Erro: Os minutos devem ser de 15 em 15 minutos")
                : horario.TimeOfDay;
        }
        //Ref: https://stackoverflow.com/questions/17590528/pad-left-pad-right-pad-center-string
        /// <summary>
        /// Faz com que um texto qualquer seja escrita de forma centralizada usando um número específico de espaços
        /// </summary>
        /// <param name="str">Texto que será escrito</param>
        /// <param name="length">Espaço disponível para escrita</param>
        /// <returns>Retorna um texto centralizado com espaços em branco nos espaços disponíveis</returns>
        public static string PadCenter(this string str, int length)
        {
            int spaces = length - str.Length;
            int padLeft = spaces / 2 + str.Length;
            return str.PadLeft(padLeft).PadRight(length);
        }
        public static bool PacienteTemAgendamentoFuturo(this string CPF, SortedList<DateTime, Agendamento> agendamentos)
        {
            // Obtem uma lista com todos os agendamentos
            var values = agendamentos.Values;

            // Filtra apenas pelos agendamentos do paciente em datas e horários futuros

            var query = values.Where(p => p.Paciente.CPF == CPF && p.DataConsulta >= DateTime.Now);

            return query.Any();
        }
    }
}
