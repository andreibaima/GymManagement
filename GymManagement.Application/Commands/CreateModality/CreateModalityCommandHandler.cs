using GymManagement.Core.Entities;
using GymManagement.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Commands.CreateModality
{
    public class CreateModalityCommandHandler : IRequestHandler<CreateModalityCommand, string>
    {
        private IModalityRepository _modalityRepository;

        public CreateModalityCommandHandler(IModalityRepository modalityRepository)
        {
            _modalityRepository = modalityRepository;
        }

        public async Task<string> Handle(CreateModalityCommand request, CancellationToken cancellationToken)
        {
            var modality = new Modality(request.Code, request.Description);

            if (request.Observation != null) modality.adicionarObservacao(request.Observation);

            await _modalityRepository.AddAsync(modality);

            return modality.Code;
        }
    }
}
