using LuftbornTask.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuftbornTask.Domain.Entities;

namespace LuftbornTask.Application.Features.Clinic.Commands
{
    public class CreateClinicCommandHandler : IRequestHandler<CreateClinicCommand, int>
    {
        private readonly IBaseRepository<Domain.Entities.Clinic> _clinicRepository;
        public CreateClinicCommandHandler(IBaseRepository<Domain.Entities.Clinic> baseRepository)
        {
            _clinicRepository = baseRepository;
        }
        public async Task<int> Handle(CreateClinicCommand request, CancellationToken cancellationToken)
        {
            var clinic = new Domain.Entities.Clinic
            {
                Name = request.Name,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                OpeningTime = request.OpeningTime,
                ClosingTime = request.ClosingTime,
                Description = request.Description
            };

            await _clinicRepository.AddAsync(clinic);
            await _clinicRepository.SaveChangesAsync();

            return clinic.Id;
        }
    }
}
