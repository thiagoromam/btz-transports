using BtzTransports.Motoristas;
using System.Data.Entity.ModelConfiguration;

namespace BtzTransports.Context.Types
{
    class MotoristaTypeConfiguration : EntityTypeConfiguration<Motorista>
    {
        public MotoristaTypeConfiguration()
        {
            ToTable(nameof(Motorista));

            HasKey(m => m.Id);
        }
    }
}
