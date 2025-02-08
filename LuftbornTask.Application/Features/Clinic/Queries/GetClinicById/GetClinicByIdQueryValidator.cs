using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftbornTask.Application.Features.Clinic.Queries
{
    public class GetClinicByIdQueryValidator:AbstractValidator<GetClinicByIdQuery>
    {
        public GetClinicByIdQueryValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
        }
    }
}
