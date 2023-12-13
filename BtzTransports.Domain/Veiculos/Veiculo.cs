using BtzTransports.Abastecimentos;
using General.Context;
using System.Collections.Generic;

namespace BtzTransports.Veiculos
{
    public class Veiculo : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Placa { get; set; }
        public string Fabricante { get; set; }
        public int Ano { get; set; }
        public TipoDeCombustivel TiposDeCombustivel { get; set; }
        public decimal CapacidadeDoTanque { get; set; }
        public string Observacoes { get; set; }

        public virtual ICollection<Abastecimento> Abastecimentos { get; private set; } = new HashSet<Abastecimento>();
    }
}
