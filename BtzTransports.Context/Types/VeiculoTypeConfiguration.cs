using BtzTransports.Veiculos;
using System.Data.Entity.ModelConfiguration;

namespace BtzTransports.Context.Types
{
    class VeiculoTypeConfiguration : EntityTypeConfiguration<Veiculo>
    {
        public VeiculoTypeConfiguration()
        {
            ToTable(nameof(Veiculo));

            HasKey(v => v.Id);
        }
    }
}
