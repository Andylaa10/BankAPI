using BankAPI.DTOs;
using FluentValidation;

namespace BankAPI;

public class PostCustomerValidation : AbstractValidator<PostCustomerDTO>
{
    public PostCustomerValidation()
    {
        RuleFor(c => c.FirstName).NotEmpty();
        RuleFor(c => c.LastName).NotEmpty();
    }
}