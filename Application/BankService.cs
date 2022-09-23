using Application.DTOs;
using Application.Interfaces;
using Application.Validators;
using AutoMapper;
using Domain;
using FluentValidation;

namespace Application;

public class BankService : IBankService
{
    private IBankRepository _repository;
    private IMapper _mapper;
    private IValidator<PutCustomerValidation> _validationCustomerPut;
    private IValidator<PostCustomerValidation> _validationCustomerPost;
    private IValidator<PutAccountValidation> _validationAccountPut;
    private IValidator<PostAccountValidator> _validationAccountPost;

    public BankService(IBankRepository repository, 
        IMapper mapper, 
        IValidator<PutCustomerValidation> validationCustomerPut, 
        IValidator<PostCustomerValidation> validationCustomerPost, 
        IValidator<PutAccountValidation> validationAccountPut, 
        IValidator<PostAccountValidator> validationAccountPost)
    {
        _repository = repository;
        _mapper = mapper;
        _validationCustomerPut = validationCustomerPut;
        _validationCustomerPost = validationCustomerPost;
        _validationAccountPut = validationAccountPut;
        _validationAccountPost = validationAccountPost;
    }

    public Customer AddCustomer(PostCustomerDTO customer)
    {
        var validate = _validationCustomerPost.Validate(customer);
        if (!validate.IsValid)
            throw new ValidationException(validate.ToString());
        
        return _repository.AddCustomer(_mapper.Map<Customer>(customer));
    }

    public Account AddAccount(PostAccountDTO account)
    {
        var validate = _validationAccountPost.Validate(account);
        if (!validate.IsValid)
            throw new ValidationException(validate.ToString());
        return _repository.AddAccount(_mapper.Map<Account>(account));
    }

    public List<Customer> GetCustomers()
    {
        return _repository.GetCustomers();
    }

    public List<Account> GetAccounts()
    {
        return _repository.GetAccounts();
    }

    public Customer GetCustomer(int id)
    {
        return _repository.GetCustomer(id);
    }

    public Account GetAccount(int id)
    {
        return _repository.GetAccount(id);
    }

    public Customer UpdateCustomer(PutCustomerDTO customer, int id)
    {
        if (id != customer.Id)
            throw new ValidationException("ID in the body and route are different");
        var validate = _validationCustomerPut.Validate(customer);
        if (!validate.IsValid)
            throw new ValidationException(validate.ToString());
        return _repository.UpdateCustomer(_mapper.Map<Customer>(customer), id);
    }

    public Account UpdateAccount(PutAccountDTO account, int id)
    {
        if (id != account.Id)
            throw new ValidationException("ID in the body and route are different");
        var validate = _validationAccountPut.Validate(account);
        if (!validate.IsValid)
            throw new ValidationException(validate.ToString());
        return _repository.UpdateAccount(_mapper.Map<Account>(account), id);
    }

    public Customer DeleteCustomer(int customerId)
    {
        return _repository.DeleteCustomer(customerId);
    }

    public Account DeleteAccount(int accountId)
    {
        return _repository.DeleteAccount(accountId);
    }
}