using pratica.ValueObjects;

namespace pratica.Domain
{
    internal class Entity
    {
        public int Id {get; set;}
        public string Nome {get; set;}
        public string  SobreNome {get; set;}
        public int Telefone {get; set;}
        public int CEP {get; set;}
        public TipoPessoa TipoPessoa {get; set;}
    }
}