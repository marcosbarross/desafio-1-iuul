using System;

namespace Odonto.Extensions
{
    /// <summary>
    /// Define as extensões usadas pela Classe Agenda e relacionadas com agendamento.
    /// </summary>
    public static class AgendaExtensions
    {
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
