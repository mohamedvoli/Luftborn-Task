using LuftbornTask.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftbornTask.Application.Features.Clinic.Commands
{
    public class DeleteClinicCommandHandler : IRequestHandler<DeleteClinicCommand>
    {
        private readonly IBaseRepository<Domain.Entities.Clinic> _clinicRepository;   
        public DeleteClinicCommandHandler(IBaseRepository<Domain.Entities.Clinic> clinicRepository) 
        {
            _clinicRepository = clinicRepository;
        }
        public async  Task Handle(DeleteClinicCommand request, CancellationToken cancellationToken)
        {
            var clinic = await _clinicRepository.GetByIdAsync(request.Id);
            if (clinic != null)
            {
                await _clinicRepository.DeleteAsync(clinic); // Soft delete
                await _clinicRepository.SaveChangesAsync();
            }
        }
    }
}
