using BtzTransports.Motoristas;
using BtzTransports.Veiculos;
using General.Context;
using System;

namespace BtzTransports.Abastecimentos
{
    public class Abastecimento : IEntity
    {
        public int Id { get; set; }
        public int IdVeiculo { get; set; }
        public int IdMotoristaResponsavel { get; set; }
        public DateTime Data { get; set; }
        public TipoDeCombustivel TipoDeCombustivel { get; set; }
        public decimal PrecoDoCombustivel { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Custo
        {
            get => Quantidade * PrecoDoCombustivel;
        }

        public virtual Veiculo Veiculo { get; set; }
        public virtual Motorista MotoristaResponsavel { get; set; }
    }
}
