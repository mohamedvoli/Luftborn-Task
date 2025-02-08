using LuftbornTask.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftbornTask.Application.Features.Clinic.Queries
{
    public class GetClinicByIdQueryHandler:IRequestHandler<GetClinicByIdQuery, Domain.Entities.Clinic>
    {
        private readonly IBaseRepository<Domain.Entities.Clinic> _clinicRepository;
        public GetClinicByIdQueryHandler(IBaseRepository<Domain.Entities.Clinic> clinicRepository)
        {
            _clinicRepository = clinicRepository;
        }

        public async Task<Domain.Entities.Clinic> Handle(GetClinicByIdQuery request, CancellationToken cancellationToken)
        {
            return await _clinicRepository.GetByIdAsync(request.Id);
        }
    }
}
