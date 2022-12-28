using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odonto.Agenda
{
    public class Agenda
    {
        public DateTime Data { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; }
        public DateTime Tempo { get; }
    }
}
