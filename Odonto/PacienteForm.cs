using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Odonto
{
    public class PacienteForm
    {
        public int MenuPrincipal()
        {
            int escolha;

            do
            {
                Console.WriteLine("Menu Principal");
                Console.WriteLine("1-Cadastro de pacientes");
                Console.WriteLine("2-Agenda");
                Console.WriteLine("3-Fim");
                escolha = Convert.ToInt32(Console.ReadLine());

                //Parar execução se a escolha for 1, 2 ou 3
            } while (!(escolha == 1 || escolha == 2 || escolha == 3));

            return escolha;
        }
    }
}
