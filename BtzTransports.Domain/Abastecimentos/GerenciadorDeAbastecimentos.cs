using BtzTransports.Context;
using BtzTransports.Exceptions;
using BtzTransports.Motoristas;
using General.Exceptions;

namespace BtzTransports.Abastecimentos
{
    public interface IGerenciadorDeAbastecimentos
    {
        void Adicionar(Abastecimento abastecimento);
        void Atualizar(Abastecimento abastecimento);
        void Remover(int id);
    }

    class GerenciadorDeAbastecimentos : IGerenciadorDeAbastecimentos
    {
        private readonly IContextoDeDados _contexto;

        public GerenciadorDeAbastecimentos(IContextoDeDados contexto)
        {
            _contexto = contexto;
        }

        public void Adicionar(Abastecimento abastecimento)
        {
            CarregarDados(abastecimento);
            ValidarEdicao(abastecimento);

            _contexto.Abastecimentos.Add(abastecimento);
            _contexto.SaveChanges();
        }
        public void Atualizar(Abastecimento abastecimento)
        {
            CarregarDados(abastecimento);
            ValidarEdicao(abastecimento);

            Abastecimento existente = _contexto.Abastecimentos.Find(abastecimento.Id) ?? throw new NotFoundException();

            existente.IdVeiculo = abastecimento.IdVeiculo;
            existente.IdMotoristaResponsavel = abastecimento.IdMotoristaResponsavel;
            existente.TipoDeCombustivel = abastecimento.TipoDeCombustivel;
            existente.Quantidade = abastecimento.Quantidade;

            existente.Veiculo = abastecimento.Veiculo;
            existente.MotoristaResponsavel = abastecimento.MotoristaResponsavel;

            _contexto.SaveChanges();
        }
        public void Remover(int id)
        {
            Abastecimento abastecimento = _contexto.Abastecimentos.Find(id) ?? throw new NotFoundException();

            _contexto.Abastecimentos.Remove(abastecimento);
            _contexto.SaveChanges();
        }

        private void CarregarDados(Abastecimento abastecimento)
        {
            abastecimento.Veiculo = _contexto.Veiculos.Find(abastecimento.IdVeiculo);
            abastecimento.MotoristaResponsavel = _contexto.Motoristas.Find(abastecimento.IdMotoristaResponsavel);
        }
        private void ValidarEdicao(Abastecimento abastecimento)
        {
            if (abastecimento.MotoristaResponsavel.Status != StatusDoMotorista.Ativo)
                throw new CommonException("Esse motorista não está ativo.");
        }
    }
}
