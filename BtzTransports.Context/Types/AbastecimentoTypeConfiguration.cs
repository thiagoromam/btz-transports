using BtzTransports.Abastecimentos;
using System.Data.Entity.ModelConfiguration;

namespace BtzTransports.Context.Types
{
    class AbastecimentoTypeConfiguration : EntityTypeConfiguration<Abastecimento>
    {
        public AbastecimentoTypeConfiguration()
        {
            ToTable(nameof(Abastecimento));

            HasKey(a => a.Id);

            HasRequired(a => a.Veiculo).WithMany(v => v.Abastecimentos).HasForeignKey(a => a.IdVeiculo);
            HasRequired(a => a.MotoristaResponsavel).WithMany(v => v.Abastecimentos).HasForeignKey(a => a.IdMotoristaResponsavel);
        }
    }
}
