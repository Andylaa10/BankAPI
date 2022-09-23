using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class PostAccountValidator : AbstractValidator<PostAccountDTO>
{
    public PostAccountValidator()
    {
        RuleFor(a => a.AccountName).NotEmpty();
        RuleFor(a => a.CustomerId).NotEmpty();
    }
}