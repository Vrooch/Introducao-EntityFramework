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

/*
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
*/