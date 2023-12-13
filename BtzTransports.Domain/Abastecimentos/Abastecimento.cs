using BtzTransports.Motoristas;
using BtzTransports.Veiculos;
using General.Context;

namespace BtzTransports.Abastecimentos
{
    public class Abastecimento : IEntity
    {
        public int Id { get; set; }
        public int IdVeiculo { get; set; }
        public int IdMotorista { get; set; }
        public TipoDeCombustivel TipoDeCombustivel { get; set; }
        public decimal Quantidade { get; set; }

        public virtual Veiculo Veiculo { get; set; }
        public virtual Motorista Motorista { get; set; }
    }
}
