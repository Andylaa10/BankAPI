using Domain;

namespace Application.Interfaces;

public interface IBankRepository
{
    //C
    Customer AddCustomer(Customer customer);
    Account AddAccount(Account account);
    
    //R
    List<Customer> GetCustomers();
    List<Account> GetAccounts();

    Customer GetCustomer(int id);
    Account GetAccount(int id);
    

    //U
    Customer UpdateCustomer(Customer customer, int id);
    Account UpdateAccount(Account account, int id);
    
    //D
    Customer DeleteCustomer(int customerId);
    Account DeleteAccount(int accountId); 
}