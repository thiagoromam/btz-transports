using BtzTransports.Abastecimentos;
using BtzTransports.Contas;
using BtzTransports.Motoristas;
using BtzTransports.Veiculos;
using System.Data.Entity;

namespace BtzTransports.Context
{
    public interface IContextoDeDados
    {
        DbSet<Abastecimento> Abastecimentos { get; }
        DbSet<Combustivel> Combustiveis { get; }
        DbSet<Motorista> Motoristas { get; }
        DbSet<Veiculo> Veiculos { get; }
        DbSet<Usuario> Usuarios { get; }
    }
}
