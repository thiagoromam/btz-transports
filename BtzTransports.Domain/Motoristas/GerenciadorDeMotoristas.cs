using BtzTransports.Context;
using General.Exceptions;

namespace BtzTransports.Motoristas
{
    public interface IGerenciadorDeMotoristas
    {
        void Adicionar(Motorista motorista);
        void Atualizar(Motorista motorista);
        void Remover(int id);
    }

    class GerenciadorDeMotoristas : IGerenciadorDeMotoristas
    {
        private readonly IContextoDeDados _contexto;

        public GerenciadorDeMotoristas(IContextoDeDados contexto)
        {
            _contexto = contexto;
        }

        public void Adicionar(Motorista motorista)
        {
            _contexto.Motoristas.Add(motorista);
            _contexto.SaveChanges();
        }
        public void Atualizar(Motorista motorista)
        {
            Motorista existente = _contexto.Motoristas.Find(motorista.Id) ?? throw new NotFoundException();

            existente.Nome = motorista.Nome;
            existente.Cpf = motorista.Cpf;
            existente.Cnh = motorista.Cnh;
            existente.DataDeNascimento = motorista.DataDeNascimento;
            existente.Status = motorista.Status;

            _contexto.SaveChanges();
        }
        public void Remover(int id)
        {
            Motorista motorista = _contexto.Motoristas.Find(id) ?? throw new NotFoundException();

            _contexto.Motoristas.Remove(motorista);
            _contexto.SaveChanges();
        }
    }
}
