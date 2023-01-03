using System;

namespace Odonto
{
    public class ExcecaoNomeInvalido : Exception
    {
        public ExcecaoNomeInvalido(string ex)
            : base(ex)
        {

        }
    }
    public class ExcecaoCPFInvalido : Exception
    {
        public ExcecaoCPFInvalido(string ex)
            : base(ex)
        {

        }
    }
    public class ExcecaoDataInvalida : Exception
    {
        public ExcecaoDataInvalida(string ex)
            : base(ex)
        {

        }
    }
    public class ExcecaoHoraInicioInvalida : Exception
    {
        public ExcecaoHoraInicioInvalida(string ex)
            : base(ex)
        {

        }
    }
    public class ExcecaoHoraFimInvalida : Exception
    {
        public ExcecaoHoraFimInvalida(string ex)
            : base(ex)
        {

        }
    }
}