using BtzTransports.Abastecimentos;
using BtzTransports.Web.Models.Motoristas;
using BtzTransports.Web.Models.Veiculos;

namespace BtzTransports.Web.Models.Abastecimentos
{
    public class AbastecimentoModel
    {
        public int Id { get; set; }
        public int IdVeiculo { get; set; }
        public int IdMotorista { get; set; }
        public TipoDeCombustivel TipoDeCombustivel { get; set; }
        public decimal Quantidade { get; set; }

        public VeiculoModel Veiculo { get; set; }
        public MotoristaModel Motorista { get; set; }

        public Abastecimento Converter()
        {
            return new Abastecimento
            {
                Id = Id,
                IdVeiculo = IdVeiculo,
                IdMotorista = IdMotorista,
                TipoDeCombustivel = TipoDeCombustivel,
                Quantidade = Quantidade,
            };
        }

        public static AbastecimentoModel Converter(
            Abastecimento abastecimento,
            bool veiculo = false,
            bool motorista = false)
        {
            return new AbastecimentoModel
            {
                Id = abastecimento.Id,
                IdVeiculo = abastecimento.IdVeiculo,
                IdMotorista = abastecimento.IdMotorista,
                TipoDeCombustivel = abastecimento.TipoDeCombustivel,
                Quantidade = abastecimento.Quantidade,

                Veiculo = veiculo ? VeiculoModel.Converter(abastecimento.Veiculo) : null,
                Motorista = motorista ? MotoristaModel.Converter(abastecimento.Motorista) : null
            };
        }
    }
}