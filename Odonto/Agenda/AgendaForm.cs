using Odonto.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odonto
{
    public class AgendaForm : Agenda
    {
        public string _CPF { get; private set; }

        public string _Consulta { get; private set; }
        public string _Inicio { get; private set; }
        public string _Fim { get; private set; }


        public string MenuListarAgenda()
        {
            string escolha;

            do
            {
                Console.WriteLine("Listar Agenda");
                Console.WriteLine("1-Listar toda a agenda");
                Console.WriteLine("2-Listar agenda de um período");
                Console.WriteLine("3-Voltar p/ Menu Agenda");
                Console.Write("Digite sua escolha: ");

                escolha = Console.ReadLine();

            } while (escolha.NaoEhEscolhaValida(Menu.ListarAgenda));

            return escolha;
        }

        public void SolicitarCPF()
        {
            Console.Write("CPF: ");
            _CPF = Console.ReadLine();
        }

        public void SolicitarDataConsulta()
        {
            string _consulta;
            DateTime consulta;

            try
            {
                Console.Write("Data da consulta (ddMMaaaa): ");
                _consulta = Console.ReadLine();
                string Dia = _consulta.Substring(0, 2);
                string Mes = _consulta.Substring(2, 2);
                string Ano = _consulta.Substring(4, 4);

                consulta = new DateTime(Convert.ToInt32(Ano), Convert.ToInt32(Mes), Convert.ToInt32(Dia));

                if (consulta < DateTime.Now)
                {
                    throw new ArgumentOutOfRangeException("Data da consulta deve ser maior que a data atual");
                }


                else if (consulta == DateTime.Now)
                {
                    TimeSpan inicio;

                    inicio = new TimeSpan(Convert.ToInt32(_Inicio));

                    do
                    {
                        SolicitarHoraInicio();
                        if (inicio < DateTime.Now.TimeOfDay)
                            Console.WriteLine("Hora da consulta deve ser maior que a data atual");
                        
                    }

                    while (inicio < DateTime.Now.TimeOfDay);

                    /*
                    if (inicio < DateTime.Now.TimeOfDay)
                    {
                        throw new ArgumentOutOfRangeException("Hora da consulta deve ser maior que a data atual");
                    }
                    */
                }

                else
                {
                    _Consulta = _consulta;
                    SolicitarHora();
                    AdicionarMarcacao(_CPF, _Consulta, _Inicio, _Fim);
                }

            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine(("Data da consulta deve ser maior que a data atual"));
                SolicitarDataConsulta();
            }


        }
        public void SolicitarHoraInicio()
        {
            Console.Write("Hora inicial (HHmm): ");
            _Inicio = Console.ReadLine();
        }



        public void SolicitarHoraFim()
        {

            Console.Write("Hora final (HHmm): ");
            _Fim = Console.ReadLine();

        }

        public void SolicitarHora()
        {
            try
            {
                SolicitarHoraInicio();
                TimeSpan inicio;

                inicio = new TimeSpan(Convert.ToInt32(_Inicio));


                SolicitarHoraFim();
                TimeSpan fim;

                fim = new TimeSpan(Convert.ToInt32(_Fim));

                if (fim < inicio)
                {
                    throw new ArgumentOutOfRangeException("Hora de término da consulta deve ser maior que a hora de início");
                }
                else
                {
                    _Fim = fim.ToString();
                }
            }
            catch(ArgumentOutOfRangeException) {
                Console.WriteLine("Hora de término da consulta deve ser maior que a hora de início");
                SolicitarHora(); 
            }

        }
    } 
}
