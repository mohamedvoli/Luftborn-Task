using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftbornTask.Application.Features.Clinic.Commands
{
    public class DeleteClinicCommandValidator:AbstractValidator<DeleteClinicCommand>
    {
        public DeleteClinicCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
        }

    }
}
