using BtzTransports.Motoristas;
using System;

namespace BtzTransports.Web.Models.Motoristas
{
    public class MotoristaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Cnh { get; set; }
        public CategoriaDaCnh CategoriaDaCnh { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public StatusDoMotorista Status { get; set; }

        public Motorista Converter()
        {
            return new Motorista
            {
                Id = Id,
                Nome = Nome,
                Cpf = Cpf,
                Cnh = Cnh,
                CategoriaDaCnh = CategoriaDaCnh,
                DataDeNascimento = DataDeNascimento,
                Status = Status,
            };
        }

        public static MotoristaModel Converter(Motorista motorista)
        {
            return new MotoristaModel
            {
                Id = motorista.Id,
                Nome = motorista.Nome,
                Cpf = motorista.Cpf,
                Cnh = motorista.Cnh,
                CategoriaDaCnh = motorista.CategoriaDaCnh,
                DataDeNascimento = motorista.DataDeNascimento,
                Status = motorista.Status,
            };
        }
    }
}