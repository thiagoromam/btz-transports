using BtzTransports.Abastecimentos;

namespace BtzTransports.Web.Models.Abastecimentos
{
    public class CombustivelModel
    {
        public TipoDeCombustivel Tipo { get; set; }
        public decimal Preco { get; set; }

        public static CombustivelModel Converter(Combustivel combustivel)
        {
            return new CombustivelModel
            {
                Tipo = combustivel.Tipo,
                Preco = combustivel.Preco,
            };
        }
    }
}