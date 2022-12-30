﻿using System;
using System.Collections.Generic;
using System.Linq;
using Odonto;


namespace Odonto.Extensions
{
    public static class GeralExtensions
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
                Console.WriteLine($"{DicionarioOrdenado[i].Value}");
            }
            DicionarioOrdenado.Count.RodapeListaPacientes();
        }
        

        public static void MostrarErrosPaciente(this PacienteValidador validador) 
        {
            if (!validador.IsEmpty)
            {
                Console.WriteLine("\n---------------------------- ERROS ---------------------------");

                // Percorre cada item do Enumerável
                foreach (CamposPaciente campo in Enum.GetValues(typeof(CamposPaciente)))
                {
                    var msg = validador.GetErrorMessage(campo);

                    if (msg.Length > 0)
                        Console.WriteLine("{0}: {1}", campo.ToString(), msg);
                }

                Console.WriteLine("--------------------------------------------------------------");
            }
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