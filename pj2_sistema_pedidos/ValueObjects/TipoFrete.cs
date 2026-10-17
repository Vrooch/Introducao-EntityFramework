using System;
using System.Collections.Generic;
using System.Text;

namespace pj2_sistema_pedidos.ValueObjects
{
    internal enum TipoFrete
    {
        CIF, // Remetente paga o frete
        FOB, // Destinatario paga o frete
        SemFrete // Retirada em loja
    }
}
