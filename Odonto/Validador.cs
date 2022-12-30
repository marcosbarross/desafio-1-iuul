using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odonto
{
    public class Validador<T> : ErrosValidacao<T>
    {
        public void MostrarErros()
        {
            if (!IsEmpty)
            {
                Console.WriteLine("\n---------------------------- ERROS ---------------------------");

                // Percorre cada item do Enumerável
                foreach (T campo in Enum.GetValues(typeof(T)))
                {
                    var msg = GetErrorMessage(campo);

                    if (msg.Length > 0)
                        Console.WriteLine("{0}: {1}", campo.ToString(), msg);
                }

                Console.WriteLine("--------------------------------------------------------------");
            }
        }
        public void MostrarErro()
        {
            if (!IsEmpty)
            {
                Console.WriteLine("\n");

                // Percorre cada item do Enumerável
                foreach (T campo in Enum.GetValues(typeof(T)))
                {
                    var msg = GetErrorMessage(campo);

                    if (msg.Length > 0)
                        Console.WriteLine("{0}: {1}\n", campo.ToString(), msg);
                }
            }
        }

    }
}
