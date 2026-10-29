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

//Cadastrar_pedido();

Console.WriteLine("\nVerificando o pedido: ");
using (var db = new ApplicationContext())
{
    var pedidos = db.Pedido
                    .Include(p => p.Itens)
                        .ThenInclude(item => item.Produto)
                    .Include(p => p.Cliente)
                    .ToList();

    Console.WriteLine(pedidos.Count);

}

foreach(var prod in ConsultarProdutos_method())
{
    Console.WriteLine($"Produto: {prod.Id}, Descrição: {prod.Descricao}, valor: {prod.Valor:C}");
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
static void Cadastrar_pedido()
{
    /*
    using (var db = new ApplicationContext())
    {
        db.Cliente.Add(new Cliente
        {
            Nome = "Andre",
            Telefone = "00915532445",
            CEP = "78954652",
            Estado = "SP",
            Cidade = "Jundiai"
        });

        db.SaveChanges();
    }
    */


    using (var db = new ApplicationContext())
    {
        Produto? produto = db.Produto.FirstOrDefault();
        Produto produto2 = db.Produto.Where(p => p.Id > 10).FirstOrDefault();
        Cliente cliente = db.Cliente.FirstOrDefault();

        Console.WriteLine(produto.Id);
        Console.WriteLine(produto2.Id);
        Console.WriteLine(cliente.Id);

        db.Pedido.Add(new Pedido()
        {
            ClienteId = cliente.Id,
            IniciadoEm = DateTime.Now,
            FinalizadoEm = DateTime.Now,
            TipoFrete = TipoFrete.SemFrete,
            Status = StatusPedido.Finalizado,
            Observacao = "N/A",
            Itens = new List<PedidoItem>()
            {
                new PedidoItem()
                {
                    ProdutoId = produto.Id,
                    Quantidade = 2,
                    valor = produto.Valor,
                    Desconto = 0.0m
                },
                new PedidoItem()
                {
                    ProdutoId = produto2.Id,
                    Quantidade = 1,
                    valor = produto2.Valor,
                    Desconto = 0.0m
                }

            }
        });

        db.SaveChanges();
    }
}
