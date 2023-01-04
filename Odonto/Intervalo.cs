using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odonto
{
    public class Intervalo
    {
        public DateTime DataHoraInicial { get; private set; }
        public DateTime DataHoraFinal { get; private set; }

        public Intervalo(DateTime inicial, DateTime final)
        {
            DataHoraInicial = inicial;
            DataHoraFinal = final;
        }
        //public bool TemIntersecao(Intervalo value)
        //{
        //    //https://stackoverflow.com/questions/13513932/algorithm-to-detect-overlapping-periods
        //    return DataHoraInicial < value.DataHoraFinal && value.DataHoraInicial < DataHoraFinal;
        //}
    }
}
