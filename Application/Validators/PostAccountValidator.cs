using BankAPI.DTOs;
using FluentValidation;

namespace BankAPI;

public class PostAccountValidator : AbstractValidator<PostAccountDTO>
{
    public PostAccountValidator()
    {
        RuleFor(a => a.AccountName).NotEmpty();
        RuleFor(a => a.CustomerId).NotEmpty();
    }
}