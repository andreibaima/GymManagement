using GymManagement.Core.Entities;
using GymManagement.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Commands.MakeThePayment
{
    public class MakeThePaymentHandler : IRequestHandler<MakeThePaymentCommand, Unit>
    {
        private readonly IMonthlyPaymentsRepository _monthlyPayments;

        public MakeThePaymentHandler(IMonthlyPaymentsRepository monthlyPayments)
        {
            _monthlyPayments = monthlyPayments;
        }

        public async Task<Unit> Handle(MakeThePaymentCommand request, CancellationToken cancellationToken)
        {
            var registro = await _monthlyPayments.GetById(request.Id);

            if (registro == null) throw new KeyNotFoundException("Mensalidade não encontrada");
                //throw new Exception("Mensalidade não encontrado"); // throw new HttpResponseException(HttpStatusCode.NotFound);

            registro.makePayment();
            //_monthlyPayments.MakePayment(registro);
            await _monthlyPayments.SalveChangesAsync();


            return Unit.Value;
        }
    }
}
