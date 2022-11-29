using BlazingPizza2022.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazingPizza2022.Server.Models;

public class PizzaStoreContext : DbContext
{
    public DbSet<PizzaSpecial> Specials { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=(localdb)\mssqllocaldb;database=PizzaStore");
    }
}
