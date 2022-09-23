using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public class BankRepository : IBankRepository
{
    private DbContextOptions<RepositoryDbContext> _opts;
    
    public BankRepository()
    {
        _opts = new DbContextOptionsBuilder<RepositoryDbContext>()
            .UseSqlite("Data source=..//BankAPI/db.db").Options;
        using (var context = new RepositoryDbContext(_opts, ServiceLifetime.Scoped))
        {
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }

    public Customer AddCustomer(Customer customer)
    {
        using (var context = new RepositoryDbContext(_opts, ServiceLifetime.Scoped))
        {
            context.Customers.Add(customer);
            context.SaveChanges();
            return customer;
        }
    }

    public Account AddAccount(Account account)
    {
        using (var context = new RepositoryDbContext(_opts, ServiceLifetime.Scoped))
        {
            context.Accounts.Add(account);
            context.SaveChanges();
            return account;
        }
    }

    public List<Customer> GetCustomers()
    {
        using (var context = new RepositoryDbContext(_opts, ServiceLifetime.Scoped))
        {
            return context.Customers.ToList();
        }
    }

    public List<Account> GetAccounts()
    {
        using (var context = new RepositoryDbContext(_opts, ServiceLifetime.Scoped))
        {
            return context.Accounts.ToList();
        }
    }

    public Customer GetCustomer(int id)
    {
        using (var context = new RepositoryDbContext(_opts, ServiceLifetime.Scoped))
        {
            var cust = context.Customers.FirstOrDefault(c=> c.Id == id);
            cust.Accounts = GetAccounts().Where(x => x.CustomerId == cust.Id).ToList();
            return cust;
        }
    }

    public Account GetAccount(int id)
    {
        using (var context = new RepositoryDbContext(_opts, ServiceLifetime.Scoped))
        {
            var account = context.Accounts.FirstOrDefault(acc=> acc.Id == id);
            account.Customer = GetCustomer(account.CustomerId);
            return account;
        }
    }

    public Customer UpdateCustomer(Customer customer, int id)
    {
        using (var context = new RepositoryDbContext(_opts, ServiceLifetime.Scoped))
        {
            var cust = context.Customers.FirstOrDefault(c=> c.Id == id);
            
            if (cust.Id == id)
            {
                cust.FirstName = customer.FirstName;
                cust.LastName = customer.LastName;
                context.Update(cust);
                context.SaveChanges();
            }

            return cust;
        }
    }

    public Account UpdateAccount(Account account, int id)
    {
        using (var context = new RepositoryDbContext(_opts, ServiceLifetime.Scoped))
        {
            var acc = context.Accounts.FirstOrDefault(acc=> acc.Id == id);
            if (acc.Id == id)
            {
                acc.AccountName = account.AccountName;
                acc.Amount = account.Amount;
                acc.CustomerId = account.CustomerId;
                context.Update(acc);
                context.SaveChanges();
            }
            return acc;
        }
    }

    public Customer DeleteCustomer(int customerId)
    {
        using (var context = new RepositoryDbContext(_opts, ServiceLifetime.Scoped))
        {
            var cust = context.Customers.FirstOrDefault(c=> c.Id == customerId);
            context.Customers.Remove(cust);
            context.SaveChanges();
            return cust;
        }
    }

    public Account DeleteAccount(int accountId)
    {
        using (var context = new RepositoryDbContext(_opts, ServiceLifetime.Scoped))
        {
            var acc = context.Accounts.FirstOrDefault(acc=> acc.Id == accountId);
            context.Accounts.Remove(acc);
            context.SaveChanges();
            return acc;
        }
    }
}