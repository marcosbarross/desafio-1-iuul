using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odonto.Paciente
{
    public class PacienteValidador
    {
        private readonly PacienteErros erros = new PacienteErros();

        public Paciente Paciente { get; private set; }


        public PacienteValidador()
        {
            Paciente = new Paciente();
        }

        public PacienteErros Erros { get { return erros; } }

    }
}
