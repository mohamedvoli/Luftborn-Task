using LuftbornTask.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftbornTask.Application.Features.Clinic.Queries
{
    public class GetAllClinicsQueryHandler : IRequestHandler<GetAllClinicsQuery, IEnumerable<Domain.Entities.Clinic>>
    {
        private readonly IBaseRepository<Domain.Entities.Clinic> _ClinicRepository;

        public GetAllClinicsQueryHandler(IBaseRepository<Domain.Entities.Clinic> ClinicRepository)
        {
            _ClinicRepository = ClinicRepository;
        }
        public async Task<IEnumerable<Domain.Entities.Clinic>> Handle(GetAllClinicsQuery request, CancellationToken cancellationToken)
        {
            return await _ClinicRepository.GetAllAsync();
        }
    }
}
