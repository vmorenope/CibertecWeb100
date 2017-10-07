﻿using Cibertec.Models;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace CIbertec.WebApi.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty().WithMessage("This field is required");
            RuleFor(x => x.LastName).NotNull().NotEmpty().WithMessage("This field is required");
            RuleFor(x => x.City).NotNull().NotEmpty().WithMessage("This field is required");
        }
    }

}
