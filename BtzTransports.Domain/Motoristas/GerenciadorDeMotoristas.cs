using BtzTransports.Context;
using BtzTransports.Exceptions;
using General.Exceptions;
using System.Linq;

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
            ValidarEdicao(motorista);

            _contexto.Motoristas.Add(motorista);
            _contexto.SaveChanges();
        }
        public void Atualizar(Motorista motorista)
        {
            ValidarEdicao(motorista);

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

        private void ValidarEdicao(Motorista motorista)
        {
            var query = _contexto.Motoristas.AsQueryable();

            if (motorista.Id > 0)
                query = query.Where(m => m.Id != motorista.Id);

            if (query.Any(m => m.Cpf == motorista.Cpf))
                throw new CommonException("Já existe um motorista com esse CPF");

            if (query.Any(m => m.Cnh == motorista.Cnh))
                throw new CommonException("Já existe um motorista com essa CNH");
        }
    }
}
