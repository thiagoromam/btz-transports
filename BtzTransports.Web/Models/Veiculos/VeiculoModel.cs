using BtzTransports.Abastecimentos;
using BtzTransports.Veiculos;

namespace BtzTransports.Web.Models.Veiculos
{
    public class VeiculoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Placa { get; set; }
        public string Fabricante { get; set; }
        public int Ano { get; set; }
        public TipoDeCombustivel TiposDeCombustivel { get; set; }
        public decimal CapacidadeDoTanque { get; set; }
        public string Observacoes { get; set; }

        public Veiculo Converter()
        {
            return new Veiculo
            {
                Id = Id,
                Nome = Nome,
                Placa = Placa,
                Fabricante = Fabricante,
                Ano = Ano,
                TiposDeCombustivel = TiposDeCombustivel,
                CapacidadeDoTanque = CapacidadeDoTanque,
                Observacoes = Observacoes,
            };
        }

        public static VeiculoModel Converter(Veiculo veiculo)
        {
            return new VeiculoModel
            {
                Id = veiculo.Id,
                Nome = veiculo.Nome,
                Placa = veiculo.Placa,
                Fabricante = veiculo.Fabricante,
                Ano = veiculo.Ano,
                TiposDeCombustivel = veiculo.TiposDeCombustivel,
                CapacidadeDoTanque = veiculo.CapacidadeDoTanque,
                Observacoes = veiculo.Observacoes,
            };
        }
    }
}