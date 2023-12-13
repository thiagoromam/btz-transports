using BtzTransports.Abastecimentos;
using System.Data.Entity.ModelConfiguration;

namespace BtzTransports.Context.Types
{
    class CombustivelTypeConfiguration : EntityTypeConfiguration<Combustivel>
    {
        public CombustivelTypeConfiguration()
        {
            ToTable(nameof(Combustivel));

            HasKey(c => c.Tipo);
        }
    }
}
