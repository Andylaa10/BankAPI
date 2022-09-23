using BankAPI.DTOs;
using FluentValidation;

namespace BankAPI;

public class PutCustomerValidation : AbstractValidator<PutCustomerDTO>
{
    public PutCustomerValidation()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.FirstName).NotEmpty();
        RuleFor(c => c.LastName).NotEmpty();
    }
}