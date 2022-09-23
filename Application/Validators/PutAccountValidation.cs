using BankAPI.DTOs;
using FluentValidation;

namespace BankAPI;

public class PutAccountValidation : AbstractValidator<PutAccountDTO>
{
    public PutAccountValidation()
    {
        RuleFor(a => a.Id).NotEmpty();
        RuleFor(a => a.AccountName).NotEmpty();
        RuleFor(a => a.CustomerId).NotEmpty();
    }
}