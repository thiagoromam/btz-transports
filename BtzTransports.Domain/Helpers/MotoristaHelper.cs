using BtzTransports.Motoristas;
using System.Linq;

namespace BtzTransports.Helpers
{
    public static class MotoristaHelper
    {
        public static IQueryable<Motorista> Ativos(this IQueryable<Motorista> query)
        {
            return query.Where(a => a.Status == StatusDoMotorista.Ativo);
        }
    }
}
