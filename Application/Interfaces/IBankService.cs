using BankAPI.DTOs;
using Domain;

namespace Application.Interfaces;

public interface IBankService
{
    //C
    Customer AddCustomer(PostCustomerDTO customer);
    Account AddAccount(PostAccountDTO account);
    
    //R
    List<Customer> GetCustomers();
    List<Account> GetAccounts();

    Customer GetCustomer(int id);
    Account GetAccount(int id);
    

    //U
    Customer UpdateCustomer(PutCustomerDTO customer, int id);
    Account UpdateAccount(PutAccountDTO account, int id);
    
    //D
    Customer DeleteCustomer(int customerId);
    Account DeleteAccount(int accountId); 
}