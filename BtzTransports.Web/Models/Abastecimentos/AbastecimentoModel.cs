using BtzTransports.Abastecimentos;
using BtzTransports.Web.Models.Motoristas;
using BtzTransports.Web.Models.Veiculos;
using System;

namespace BtzTransports.Web.Models.Abastecimentos
{
    public class AbastecimentoModel
    {
        public int Id { get; set; }
        public int IdVeiculo { get; set; }
        public int IdMotoristaResponsavel { get; set; }
        public DateTime Data { get; set; }
        public TipoDeCombustivel TipoDeCombustivel { get; set; }
        public decimal PrecoDoCombustivel { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Custo { get; set; }

        public VeiculoModel Veiculo { get; set; }
        public MotoristaModel MotoristaResponsavel { get; set; }

        public Abastecimento Converter()
        {
            return new Abastecimento
            {
                Id = Id,
                IdVeiculo = IdVeiculo,
                IdMotoristaResponsavel = IdMotoristaResponsavel,
                Data = Data,
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
                IdMotoristaResponsavel = abastecimento.IdMotoristaResponsavel,
                Data = abastecimento.Data,
                TipoDeCombustivel = abastecimento.TipoDeCombustivel,
                PrecoDoCombustivel = abastecimento.PrecoDoCombustivel,
                Quantidade = abastecimento.Quantidade,
                Custo = abastecimento.Custo,

                Veiculo = veiculo ? VeiculoModel.Converter(abastecimento.Veiculo) : null,
                MotoristaResponsavel = motorista ? MotoristaModel.Converter(abastecimento.MotoristaResponsavel) : null
            };
        }
    }
}