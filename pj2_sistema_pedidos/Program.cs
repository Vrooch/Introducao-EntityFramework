using pj2_sistema_pedidos.Domain;
using pj2_sistema_pedidos.Data;
using Microsoft.EntityFrameworkCore;
using pj2_sistema_pedidos.ValueObjects;

Console.WriteLine("Hello, World!");
using (var db = new ApplicationContext())
{
    if(db.Database.GetPendingMigrations().Any())
    {
        // Adicionar as minhas regras de negocio quanto
        // ao alerta de migrações pendentes.
        Console.WriteLine("Existe migrações pendentes");
    }

}

Console.WriteLine("Criando uma nova entidade de produto");
InserirProdutosEmMassa();

static void InserirProduto()
{
    var produto = new Produto()
    {
        Descricao = "Carregador",
        CodigoBarras = "123456789",
        Valor = 37.50m,
        TipoProduto = TipoProduto.MercadoriaParaRevenda,
        Ativo = true
    };

    using (var db = new ApplicationContext())
    {
        db.Produto.Add(produto);
        var registrosAfetados = db.SaveChanges();
        Console.WriteLine($"Registros afetados: {registrosAfetados}");
    };
}
static void InserirProdutosEmMassa()
{
    var lista_produtos = new List<Produto>()
    {
        new Produto()
        {
            Descricao = "teclado",
            CodigoBarras = "234567890",
            Valor = 37.50m,
            TipoProduto = TipoProduto.MercadoriaParaRevenda,
            Ativo = true
        },
        new Produto()
        {
            Descricao = "Fone de Ouvido",
            CodigoBarras = "345678901",
            Valor = 99.90m,
            TipoProduto = TipoProduto.MercadoriaParaRevenda,
            Ativo = true
        },
        new Produto()
        {
            Descricao = "Cabo USB",
            CodigoBarras = "456789012",
            Valor = 19.90m,
            TipoProduto = TipoProduto.MercadoriaParaRevenda,
            Ativo = true
        }
    };

    using (var db = new ApplicationContext())
    {
        db.Produto.AddRange(lista_produtos);

        int registrosAfetados = db.SaveChanges();
        Console.WriteLine($"Registros afetados: {registrosAfetados}");
    };
}