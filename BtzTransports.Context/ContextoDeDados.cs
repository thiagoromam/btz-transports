using BtzTransports.Abastecimentos;
using BtzTransports.Motoristas;
using BtzTransports.Veiculos;
using System.Data.Entity;
using System.Reflection;

namespace BtzTransports.Context
{
    class ContextoDeDados : DbContext, IContextoDeDados
    {
        public ContextoDeDados() : base("DefaultConnection")
        {
        }

        public DbSet<Abastecimento> Abastecimentos { get; set; }
        public DbSet<Motorista> Motoristas { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }

        protected override void OnModelCreating(DbModelBuilder model)
        {
            model.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(model);
        }
    }
}
