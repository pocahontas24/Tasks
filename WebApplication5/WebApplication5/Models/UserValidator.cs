using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class UserValidator:AbstractValidator<User>
    {

        public UserValidator() {
            RuleFor(x => x.ID).NotNull();
            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.LastName).NotNull();
            RuleFor(x => x.BankNumber).NotNull().WithMessage("Bank number must have 16 digits!");
            RuleFor(x => x.Birthday).NotNull();
            RuleFor(x => x.Email).NotNull().EmailAddress();
            RuleFor(x => x.PhoneNumber).MaximumLength(15).WithMessage("Phone number must be in format +3876xxxxxxx!");
        }
    }
}
