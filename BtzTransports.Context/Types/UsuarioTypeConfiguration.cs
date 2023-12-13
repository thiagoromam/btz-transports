using BtzTransports.Contas;
using System.Data.Entity.ModelConfiguration;

namespace BtzTransports.Context.Types
{
    class UsuarioTypeConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioTypeConfiguration()
        {
            ToTable(nameof(Usuario));

            HasKey(u => u.Id);
        }
    }
}
