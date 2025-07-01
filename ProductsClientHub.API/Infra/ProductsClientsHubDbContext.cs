using Microsoft.EntityFrameworkCore;
using ProductsClientHub.API.Entities;

namespace ProductsClientHub.API.Infra;

public class ProductsClientsHubDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=C:\\Users\\ferna\\Downloads\\1737062251373-attachment.db");
    }
}
