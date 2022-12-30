using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odonto
{
    public class ErrosValidacao<T>
    {
        protected Dictionary<T, string> Erros { get; }


        public ErrosValidacao()
        {
            Erros = new Dictionary<T, string>();
        }

        public void Clear()
        {
            Erros.Clear();
        }

        public void AddError(T campo, string erro)
        {
            Erros.Add(campo, erro);
        }

        public string GetErrorMessage(T campo)
        {
            return HasError(campo) ? Erros[campo] : string.Empty;
        }

        public bool HasError(T campo)
        {
            return Erros.TryGetValue(campo, out var _);
        }

        public bool IsEmpty => Erros.Count == 0;

    }
}
