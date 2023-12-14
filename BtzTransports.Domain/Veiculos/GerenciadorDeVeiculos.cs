using BtzTransports.Context;
using BtzTransports.Exceptions;
using General.Exceptions;
using System.Linq;

namespace BtzTransports.Veiculos
{
    public interface IGerenciadorDeVeiculos
    {
        void Adicionar(Veiculo veiculo);
        void Atualizar(Veiculo veiculo);
        void Remover(int id);
    }

    class GerenciadorDeVeiculos : IGerenciadorDeVeiculos
    {
        private readonly IContextoDeDados _contexto;

        public GerenciadorDeVeiculos(IContextoDeDados contexto)
        {
            _contexto = contexto;
        }

        public void Adicionar(Veiculo veiculo)
        {
            ValidarEdicao(veiculo);

            _contexto.Veiculos.Add(veiculo);
            _contexto.SaveChanges();
        }
        public void Atualizar(Veiculo veiculo)
        {
            ValidarEdicao(veiculo);

            Veiculo existente = _contexto.Veiculos.Find(veiculo.Id) ?? throw new NotFoundException();

            existente.Nome = veiculo.Nome;
            existente.Nome = veiculo.Nome;
            existente.Placa = veiculo.Placa;
            existente.Fabricante = veiculo.Fabricante;
            existente.Ano = veiculo.Ano;
            existente.TiposDeCombustivel = veiculo.TiposDeCombustivel;
            existente.CapacidadeDoTanque = veiculo.CapacidadeDoTanque;
            existente.Observacoes = veiculo.Observacoes;

            _contexto.SaveChanges();
        }
        public void Remover(int id)
        {
            Veiculo veiculo = _contexto.Veiculos.Find(id) ?? throw new NotFoundException();

            if (!PodeSerRemovido(veiculo))
                throw new CommonException("Esse veículos contém vínculos e não pode ser removido.");

            _contexto.Veiculos.Remove(veiculo);
            _contexto.SaveChanges();
        }

        private void ValidarEdicao(Veiculo veiculo)
        {
            var query = _contexto.Veiculos.AsQueryable();

            if (veiculo.Id > 0)
                query = query.Where(m => m.Id != veiculo.Id);

            if (query.Any(m => m.Placa == veiculo.Placa))
                throw new CommonException("Já existe um veiculo com essa placa.");
        }
        private bool PodeSerRemovido(Veiculo veiculo)
        {
            return !_contexto.Abastecimentos.Any(a => a.IdVeiculo == veiculo.Id);
        }
    }
}
