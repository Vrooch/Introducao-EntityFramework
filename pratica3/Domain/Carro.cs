using pratica3.ValueObject;

namespace pratica3.Domain
{
    internal class Carro
    {
        public int Id {get; set;}
        public string Montadora {get; set;}
        public string Modelo {get; set;}
        public TipoCarro TipoCarro {get; set;}
        public decimal Valor {get; set;}
    }
}