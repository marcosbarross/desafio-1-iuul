using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odonto
{
    /// <summary>
    /// Define um Intervalo de Tempo entre duas datas e/ou horários
    /// </summary>
    public class Intervalo
    {
        public DateTime DataHoraInicial { get; private set; }
        public DateTime DataHoraFinal { get; private set; }

        /// <summary>
        /// Cria uma instância de um Intervalo.
        /// </summary>
        /// <param name="inicial">Esse valor deve ser menor que o valor final.</param>
        /// <param name="final">Esse valor deve ser maior que o valor inicial.</param>
        public Intervalo(DateTime inicial, DateTime final)
        {
            DataHoraInicial = inicial;
            DataHoraFinal = final;
        }
    }
}
