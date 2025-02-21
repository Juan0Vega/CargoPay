using CargoPay.Controllers.ResponseModels;
using CargoPay.Data;
using CargoPay.Data.MigrationModel;
using CargoPay.Service.IServices;
using CargoPay.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace CargoPay.Bussiness
{
    public class PaymentService : IPaymentService
    {
        private readonly CargoPayContext _cargoPayContext;
        private readonly IFeeService _feeService;
    
        
        public PaymentService(CargoPayContext cargoPayContext, IFeeService feeService)
        {
            _cargoPayContext = cargoPayContext;
            _feeService = feeService;
        }

        private class PaymentResult
        {
            public decimal currentFee { get; set; }
            public double finalAmount { get; set; }
        }

        public async Task<ResponseModel<PaymentMigration>> Pay(Payment payment)
        {
            var currentFee = await ApplyPayment(payment);

            var response = new ResponseModel<PaymentMigration>();

            if(currentFee != null)
            {
                var newRecord = new PaymentMigration()
                {
                    CardNumber = payment.CardNumber,
                    Amount = payment.Amount,
                    Fee = currentFee.currentFee,
                    FinalAmount =  currentFee.finalAmount                 
                };

                await _cargoPayContext.Payments.AddAsync(newRecord);
                await _cargoPayContext.SaveChangesAsync();
                response.Message = "Pago realizado";
                response.data = newRecord;

                return response;
            }
            else
            {
                response.Message = "No se pudo realizar el pago";
                return response;
            }

        }

        private async Task<PaymentResult?>ApplyPayment(Payment payment)
        {
            var card = await _cargoPayContext.Cards.FirstOrDefaultAsync(x=>x.Id == payment.CardNumber);

            decimal currentFee = _feeService.GetNewFee();
            double feePay = payment.Amount * Convert.ToDouble(currentFee)/ 100;
            double finalAmount = Math.Round(payment.Amount + feePay);

            if (card == null || card.CreditLimit < finalAmount)
            {
                return null;
            }

            card.CreditLimit -= finalAmount;

            var fullPayment = new PaymentResult()
            {
                currentFee = currentFee,
                finalAmount = finalAmount,
            };

            return fullPayment;

        } 

    }
}
