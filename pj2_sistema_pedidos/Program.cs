using pj2_sistema_pedidos.Domain;
using pj2_sistema_pedidos.Data;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");
var db = new ApplicationContext();
if(db.Database.GetPendingMigrations().Any())
{
    // Adicionar as minhas regras de negocio quanto
    // ao alerta de migrações pendentes.
    Console.WriteLine("Existe migrações pendentes");
}

