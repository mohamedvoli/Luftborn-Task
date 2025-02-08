using LuftbornTask.Domain.Entities;
using LuftbornTask.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftbornTask.Application.Features.Clinic.Commands
{
    public class UpdateClinicCommandHandler : IRequestHandler<UpdateClinicCommand>
    {
        private readonly IBaseRepository<Domain.Entities.Clinic> _clinicRepository;
        public UpdateClinicCommandHandler(IBaseRepository<Domain.Entities.Clinic> clinicRepository)
        {
         _clinicRepository = clinicRepository;
        }
        public async Task Handle(UpdateClinicCommand request, CancellationToken cancellationToken)
        {
            var clinic = await _clinicRepository.GetByIdAsync(request.Id);
            if (clinic != null)
            {
                clinic.Name = request.Name;
                clinic.Address = request.Address;
                clinic.PhoneNumber = request.PhoneNumber;
                clinic.Email = request.Email;
                clinic.OpeningTime = request.OpeningTime;
                clinic.ClosingTime = request.ClosingTime;
                clinic.Description = request.Description;

                _clinicRepository.UpdateAsync(clinic);
                await _clinicRepository.SaveChangesAsync();
            }
        }
    }
}
