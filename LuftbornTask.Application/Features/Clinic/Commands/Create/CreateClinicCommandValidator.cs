using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace LuftbornTask.Application.Features.Clinic.Commands
{
    public class CreateClinicCommandValidator : AbstractValidator<CreateClinicCommand>
    {
        public CreateClinicCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().MaximumLength(100);
            RuleFor(c => c.Address).NotEmpty();
            RuleFor(c => c.PhoneNumber).NotEmpty().MaximumLength(20);
            RuleFor(c => c.Email).EmailAddress().MaximumLength(100);
            RuleFor(c => c.OpeningTime).NotEmpty();
            RuleFor(c => c.ClosingTime).NotEmpty();
            RuleFor(c => c.Description).MaximumLength(500);
        }
    }
}
