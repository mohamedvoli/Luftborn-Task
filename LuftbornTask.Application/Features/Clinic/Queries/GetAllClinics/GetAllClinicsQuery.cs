using LuftbornTask.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftbornTask.Application.Features.Clinic.Queries
{
    public class GetAllClinicsQuery:IRequest<IEnumerable<Domain.Entities.Clinic>>
    {
    }
}
