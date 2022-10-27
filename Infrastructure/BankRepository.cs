using Application.Interfaces;
using Domain;

namespace Infrastructure;

public class BankRepository : IBankRepository
{
    private RepositoryDbContext _context;
    
    public BankRepository(RepositoryDbContext context)
    {
        _context = context;
    }

    public Customer AddCustomer(Customer customer)
    {
        _context.Customers.Add(customer);
        _context.SaveChanges();
        return customer;
    }

    public Account AddAccount(Account account)
    {
        _context.Accounts.Add(account);
        _context.SaveChanges();
        return account;
    }

    public List<Customer> GetCustomers()
    {
        return _context.Customers.ToList();
    }

    public List<Account> GetAccounts()
    {
        return _context.Accounts.ToList();
    }

    public Customer GetCustomer(int id)
    {
        var cust = _context.Customers.FirstOrDefault(c=> c.Id == id);
        cust.Accounts = GetAccounts().Where(x => x.CustomerId == cust.Id).ToList();
        return cust;
    }

    public Account GetAccount(int id)
    {
        var account = _context.Accounts.FirstOrDefault(acc=> acc.Id == id);
        account.Customer = GetCustomer(account.CustomerId);
        return account;
    }

    public Customer UpdateCustomer(Customer customer, int id)
    {
        var cust = _context.Customers.FirstOrDefault(c=> c.Id == id);
            
        if (cust.Id == id)
        {
            cust.FirstName = customer.FirstName;
            cust.LastName = customer.LastName;
            _context.Update(cust);
            _context.SaveChanges();
        }

        return cust;
    }

    public Account UpdateAccount(Account account, int id)
    {
        var acc = _context.Accounts.FirstOrDefault(acc=> acc.Id == id);
        if (acc.Id == id)
        {
            acc.AccountName = account.AccountName;
            acc.Amount = account.Amount;
            acc.CustomerId = account.CustomerId;
            _context.Update(acc);
            _context.SaveChanges();
        }
        return acc;
    }

    public Customer DeleteCustomer(int customerId)
    {
        var cust = _context.Customers.FirstOrDefault(c=> c.Id == customerId);
        _context.Customers.Remove(cust);
        _context.SaveChanges();
        return cust;
    }

    public Account DeleteAccount(int accountId)
    {
        var acc = _context.Accounts.FirstOrDefault(acc=> acc.Id == accountId);
        _context.Accounts.Remove(acc);
        _context.SaveChanges();
        return acc;
    }

    public void RebuildDB()
    {
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
    }
}