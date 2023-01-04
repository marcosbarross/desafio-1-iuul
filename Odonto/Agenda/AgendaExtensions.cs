using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odonto.Extensions
{
    /// <summary>
    /// Define as extensões usadas pela Classe Agenda e relacionadas com agendamento.
    /// </summary>
    public static class AgendaExtensions
    {
        public static string ValoresAgenda(this Agendamento agendamento)
        {
            return agendamento.DataConsulta.ToShortDateString().PadCenter((int)EspacosAgenda.Data) +
                   agendamento.HoraInicio.ToString(@"hh\:mm").PadCenter((int)EspacosAgenda.Tempo) +
                   agendamento.HoraFim.ToString(@"hh\:mm").PadCenter((int)EspacosAgenda.Tempo) +
                   agendamento.Tempo.ToString(@"hh\:mm").PadCenter((int)EspacosAgenda.Tempo) +
                   agendamento.Nome.ToString().PadRight((int)EspacosAgenda.Nome) +
                   agendamento.Nascimento.ToShortDateString().PadCenter((int)EspacosAgenda.Data);
        }
        public static void CabecalhoListaAgenda()
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.Write("Data".PadCenter((int)EspacosAgenda.Data));
            Console.Write("H.Ini".PadCenter((int)EspacosAgenda.Tempo));
            Console.Write("H.Fim".PadCenter((int)EspacosAgenda.Tempo));
            Console.Write("Tempo".PadCenter((int)EspacosAgenda.Tempo));
            Console.Write("Nome".PadRight((int)EspacosAgenda.Nome));
            Console.WriteLine("Dt.Nasc.".PadCenter((int)EspacosAgenda.Data));


            Console.WriteLine("-------------------------------------------------------------");
        }
        public static void RodapeListaAgenda()
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine(" ");
        }
    }
}
