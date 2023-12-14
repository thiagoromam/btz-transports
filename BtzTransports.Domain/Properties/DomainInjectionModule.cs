using BtzTransports.Abastecimentos;
using BtzTransports.Contas;
using BtzTransports.Motoristas;
using BtzTransports.Veiculos;
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

            Abastecimentos();
            Contas();
            Motoristas();
            Veiculos();
        }

        private void Abastecimentos()
        {
            _container.Register<IGerenciadorDeAbastecimentos, GerenciadorDeAbastecimentos>();
        }
        private void Contas()
        {
            _container.Register<IUsuarioDaSessao, UsuarioDaSessao>(Lifestyle.Scoped);
            _container.Register<ISessionUser, UsuarioDaSessao>(Lifestyle.Scoped);
            _container.Register<IGerenciadorDeContas, GerenciadorDeContas>();
            _container.Register<IGerenciadorDeUsuarios, GerenciadorDeUsuarios>();
        }
        private void Motoristas()
        {
            _container.Register<IGerenciadorDeMotoristas, GerenciadorDeMotoristas>();
        }
        private void Veiculos()
        {
            _container.Register<IGerenciadorDeVeiculos, GerenciadorDeVeiculos>();
        }
    }
}
