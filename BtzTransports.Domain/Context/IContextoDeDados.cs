using BtzTransports.Abastecimentos;
using BtzTransports.Motoristas;
using BtzTransports.Veiculos;
using System.Data.Entity;

namespace BtzTransports.Context
{
    public interface IContextoDeDados
    {
        DbSet<Abastecimento> Abastecimentos { get; }
        DbSet<Motorista> Motoristas { get; }
        DbSet<Veiculo> Veiculos { get; }
    }
}
