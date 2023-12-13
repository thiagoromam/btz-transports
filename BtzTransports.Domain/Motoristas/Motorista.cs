using BtzTransports.Abastecimentos;
using General.Context;
using System;
using System.Collections.Generic;

namespace BtzTransports.Motoristas
{
    public class Motorista : IEntity
    {
        private DateTime _dataDeNascimento;

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Cnh { get; set; }
        public DateTime DataDeNascimento
        {
            get => _dataDeNascimento;
            set => _dataDeNascimento = value.Date;
        }
        public StatusDoMotorista Status { get; set; }

        public virtual ICollection<Abastecimento> Abastecimentos { get; private set; } = new HashSet<Abastecimento>();
    }
}
