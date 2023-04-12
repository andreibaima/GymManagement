using GymManagement.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Queries.GetModalityByCode
{
    public class GetModalityByCodeQuery : IRequest<ModalityViewModel>
    {
        public GetModalityByCodeQuery(string code)
        {
            Code = code;
        }

        public string Code { get; set; }
    }
}
