﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Odonto.PacienteNameSpace
{
    public class ListaPacientes
    {
        public Dictionary<long, Paciente> Pacientes { get; private set; }

        public ListaPacientes()
        {
            Pacientes = new Dictionary<long, Paciente>();
        }

        public void AdicionarNaLista(Paciente paciente)
        {
            Pacientes.Add(paciente.CPF, paciente);
        }

        public void RemoverDaLista(Paciente paciente)
        {
            Pacientes.Remove(paciente.CPF);
        }

        public void ListarPacientesPorCPF()
        {
            Pacientes.ImprimeDicionarioOrdenado(OrdenadoPor.CPF);
        }
        public void ListarPacientesPorNome()
        {
            Pacientes.ImprimeDicionarioOrdenado(OrdenadoPor.Nome);
        }

    }
}
