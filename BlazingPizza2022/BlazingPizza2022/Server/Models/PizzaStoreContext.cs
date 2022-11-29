using BlazingPizza2022.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazingPizza2022.Server.Models;

public class PizzaStoreContext : DbContext
{
    public DbSet<PizzaSpecial> Specials { get; set; }
    public DbSet<Topping> Toppings { get; set; }
    public DbSet<Pizza> Pizzas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=(localdb)\mssqllocaldb;database=PizzaStore");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PizzaTopping>()
            .HasKey(pst => new { pst.PizzaId, pst.ToppingId });

        modelBuilder.Entity<PizzaTopping>()
            .HasOne<Pizza>().WithMany(ps => ps.Toppings);

        modelBuilder.Entity<PizzaTopping>()
            .HasOne(pst => pst.Topping).WithMany();
    }
}
