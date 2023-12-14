using BtzTransports.Abastecimentos;
using General.Context;
using General.Helpers;
using System.Collections.Generic;

namespace BtzTransports.Veiculos
{
    public class Veiculo : IEntity
    {
        private string _placa;
        private string _observacoes;

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Placa
        {
            get => _placa; 
            set => _placa = value?.ToUpper();
        }
        public string Fabricante { get; set; }
        public int Ano { get; set; }
        public TipoDeCombustivel TiposDeCombustivel { get; set; }
        public decimal CapacidadeDoTanque { get; set; }
        public string Observacoes
        {
            get => _observacoes;
            set => _observacoes = value.IfEmptyThenNull();
        }

        public virtual ICollection<Abastecimento> Abastecimentos { get; private set; } = new HashSet<Abastecimento>();
    }
}
