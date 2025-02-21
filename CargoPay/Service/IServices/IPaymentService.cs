using CargoPay.Controllers.ResponseModels;
using CargoPay.Data.MigrationModel;
using CargoPay.Service.Models;

namespace CargoPay.Service.IServices
{
    public interface IPaymentService
    {
        public Task<ResponseModel<PaymentMigration>> Pay(Payment payment);

    }
}
