using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public class RepositoryDbContext : DbContext
{
    public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options, ServiceLifetime serviceLifetime) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Customer builder
        modelBuilder.Entity<Customer>().Property(c => c.Id).ValueGeneratedOnAdd();
        
        //Account builder
        modelBuilder.Entity<Account>().Property(c => c.Id).ValueGeneratedOnAdd();
        
        //Foreign key
        modelBuilder.Entity<Account>()
            .HasOne(a => a.Customer)
            .WithMany(c => c.Accounts)
            .HasForeignKey(a => a.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        var c1 = new Customer{ Id = 1, FirstName = "Andy", LastName = "Johnson"};
        var c2 = new Customer{ Id = 2, FirstName = "Peter", LastName = "Ib"};
        var c3 = new Customer{ Id = 3, FirstName = "Bo", LastName = "Carlson"};
        var c4 = new Customer{ Id = 4, FirstName = "Thomas", LastName = "GG"};
        modelBuilder.Entity<Customer>().HasData(c1, c2, c3, c4);

        var a1 = new Account { Id  = 1, Amount = 1.2323F, AccountName = "Andys", CustomerId = c1.Id};
        var a2 = new Account { Id  = 2, Amount = 333.2323F, AccountName = "Peters", CustomerId = c2.Id};
        var a3 = new Account { Id  = 3, Amount = 222.2323F, AccountName = "Bo", CustomerId = c3.Id};
        var a4 = new Account { Id  = 4, Amount = 12.2323F, AccountName = "Thomas", CustomerId = c4.Id};
        modelBuilder.Entity<Account>().HasData(a1, a2, a3, a4);
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Account> Accounts { get; set; }
    
    


}