using System.Data.Entity;
using System.Reflection;

namespace BtzTransports.Context
{
    class ContextoDeDados : DbContext, IContextoDeDados
    {
        public ContextoDeDados() : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder model)
        {
            model.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(model);
        }
    }
}
