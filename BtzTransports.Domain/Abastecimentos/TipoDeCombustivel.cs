using System;

namespace BtzTransports.Abastecimentos
{
    [Flags]
    public enum TipoDeCombustivel
    {
        Gasolina = 1 << 0,
        Etanol = 1 << 1,
        Diesel = 1 << 2
    }
}
