using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Commands.MakeThePayment
{
    public class MakeThePaymentCommand : IRequest<Unit>
    {
        public MakeThePaymentCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
        
    }
}
