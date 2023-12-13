using BtzTransports.Exceptions;

namespace General.Exceptions
{
    public class NotFoundException : CommonException
    {
        public NotFoundException()
            : base("Registro não encontrado.") { }
    }
}
