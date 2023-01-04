﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Odonto;


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
                    DicionarioOrdenado = dicionario.OrderBy(paciente => paciente.Key).ToList();
                    break;

                case OrdenadoPor.Nome:

                    DicionarioOrdenado = dicionario.OrderBy(paciente => paciente.Value).ToList();
                    break;
            }

            for (int i = 0; i < DicionarioOrdenado.Count; i++)
            {
                Console.WriteLine($"{DicionarioOrdenado[i].Value}");
            }
            DicionarioOrdenado.Count.RodapeListaPacientes();
        }

        public static bool EncerrarProcessoComErro(this Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
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
                throw new Exception("O formato de hora deve estar em HHmm");

            return horario;
        }
        //public static void MostrarErros<TCampo>(this IValidador<TCampo> validador)
        //{
        //    if (!validador.Erros.IsEmpty)
        //    {
        //        Console.WriteLine("\n---------------------------- ERROS ---------------------------");

        //        // Percorre cada item do Enumerável
        //        foreach (TCampo campo in Enum.GetValues(typeof(TCampo)))
        //        {
        //            var msg = validador.Erros.GetErrorMessage(campo);

        //            if (msg.Length > 0)
        //                Console.WriteLine("{0}: {1}", campo.ToString(), msg);
        //        }

        //        Console.WriteLine("--------------------------------------------------------------");
        //    }
        //}

    }
}
