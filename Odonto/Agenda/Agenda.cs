using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odonto
{
    public class Agenda
    {
        public SortedList<string, > Agendamentos { get; private set; }
        public Agenda() 
        {
            
        }

        public Dictionary<string, List<string>> Marcacoes = new Dictionary<string, List<string>>();

        public void AdicionarMarcacao(string CPF, string Consulta, string Inicio, string Fim)
        {
            List<string> Agendamento = new List<string>();
            Agendamento.Add(Consulta);
            Agendamento.Add(Inicio);
            Agendamento.Add(Fim);

            Marcacoes.Add(CPF, Agendamento);
        }
        
        public void ListarMarcacoes(string CPF)
        {
            for (int i = 0; i < Marcacoes.Count; i++)
            {
                Console.WriteLine(Marcacoes[CPF]);
            }
        }

        public void AgendarConsulta(string CPF, TimeSpan diaConsulta, TimeSpan inicioConsulta, TimeSpan fimConsulta)
        {
 
        }    
    }
}
