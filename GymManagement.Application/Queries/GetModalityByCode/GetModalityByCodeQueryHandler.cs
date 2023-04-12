using GymManagement.Application.ViewModels;
using GymManagement.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Queries.GetModalityByCode
{
    public class GetModalityByCodeQueryHandler : IRequestHandler<GetModalityByCodeQuery, ModalityViewModel>
    {
        private IModalityRepository _modalityRepository;

        public GetModalityByCodeQueryHandler(IModalityRepository modalityRepository)
        {
            _modalityRepository = modalityRepository;
        }

        public async Task<ModalityViewModel> Handle(GetModalityByCodeQuery request, CancellationToken cancellationToken)
        {
            var modality = await _modalityRepository.GetByCodeAsync(request.Code);

            if (modality == null) return null;

            var modalityViewModel = new ModalityViewModel(modality.Code, modality.Description);

            return modalityViewModel;
        }
    }
}
