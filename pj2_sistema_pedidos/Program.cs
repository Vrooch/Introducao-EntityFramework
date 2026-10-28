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

foreach(var prod in ConsultarProdutos_sintaxe())
{
    Console.WriteLine($"Produto: {prod.Descricao}, valor: {prod.Valor:C}");
}

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
static List<Produto> ConsultarProdutos_sintaxe()
{
    using (var db = new ApplicationContext())
    {
        return (from c in db.Produto select c).ToList();
    }
}

static List<Produto> ConsultarProdutos_method()
{
    using (var db = new ApplicationContext())
    {
        return db.Produto.ToList();
    }
}

static void AumentarValor()
{
    using (var db = new ApplicationContext())
    {
        foreach (var produto in db.Produto.ToList())
        {
            produto.Valor += 10m;
        }
        db.SaveChanges();
    }
}

static void AumentarValor_AsNoTracking()
{
    using (var db = new ApplicationContext())
    {
        foreach (var produto in db.Produto.AsNoTracking().ToList())
        {
            produto.Valor += 10m;
        }
        db.SaveChanges();
    }
}