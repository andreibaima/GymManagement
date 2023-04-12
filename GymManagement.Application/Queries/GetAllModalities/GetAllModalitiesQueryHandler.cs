using GymManagement.Application.ViewModels;
using GymManagement.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Queries.GetAllModalities
{
    public class GetAllModalitiesQueryHandler : IRequestHandler<GetAllModalitiesQuery, List<ModalityViewModel>>
    {
        private readonly IModalityRepository _modalityRepository;

        public GetAllModalitiesQueryHandler(IModalityRepository modalityRepository)
        {
            _modalityRepository = modalityRepository;
        }

        public async Task<List<ModalityViewModel>> Handle(GetAllModalitiesQuery request, CancellationToken cancellationToken)
        {
            var modalities = await _modalityRepository.GetAllAsync();

            var modalitiesViewModel = modalities.Select(m => new ModalityViewModel(m.Code, m.Description)).ToList();

            return modalitiesViewModel;
        }
    }
}
