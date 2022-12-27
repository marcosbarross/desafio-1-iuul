using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odonto.PacienteNameSpace
{
    public class PacienteErrosValidacao
    {
        private readonly Dictionary<CamposPaciente, string> erros;

        public PacienteErrosValidacao()
        {
            erros = new Dictionary<CamposPaciente, string>();
        }

        public void Clear()
        {
            erros.Clear();
        }

        public void AddError(CamposPaciente campo, string erro)
        {
            erros.Add(campo, erro);
        }

        public string GetErrorMessage(CamposPaciente field)
        {
            return HasError(field) ? erros[field] : string.Empty;
        }

        public bool HasError(CamposPaciente field)
        {
            return erros.TryGetValue(field, out var _);
        }

        public bool IsEmpty => erros.Count == 0;

    }
}
