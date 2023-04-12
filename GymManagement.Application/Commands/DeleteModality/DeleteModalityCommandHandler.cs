using GymManagement.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Commands.DeleteModality
{
    public class DeleteModalityCommandHandler : IRequestHandler<DeleteModalityCommand, Unit>
    {
        private readonly IModalityRepository _modalityRepository;

        public DeleteModalityCommandHandler(IModalityRepository modalityRepository)
        {
            _modalityRepository = modalityRepository;
        }

        public async Task<Unit> Handle(DeleteModalityCommand request, CancellationToken cancellationToken)
        {
            var modality = await _modalityRepository.GetByCodeAsync(request.Code);

            if(modality != null) await _modalityRepository.DeleteAsync(modality);

            return Unit.Value;
        }
    }
}
