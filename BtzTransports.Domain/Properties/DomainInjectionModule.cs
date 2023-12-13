using BtzTransports.Contas;
using BtzTransports.Motoristas;
using General.Authorization;
using General.Injection;
using SimpleInjector;

namespace BtzTransports.Domain.Properties
{
    public class DomainInjectionModule : IInjectionModule
    {
        private Container _container;

        public void Register(Container container)
        {
            _container = container;

            Contas();
            Motoristas();
        }

        private void Contas()
        {
            _container.Register<IUsuarioDaSessao, UsuarioDaSessao>(Lifestyle.Scoped);
            _container.Register<ISessionUser, UsuarioDaSessao>(Lifestyle.Scoped);
            _container.Register<IGerenciadorDeContas, GerenciadorDeContas>();
        }
        private void Motoristas()
        {
            _container.Register<IGerenciadorDeMotoristas, GerenciadorDeMotoristas>();
        }
    }
}
