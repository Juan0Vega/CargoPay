using CargoPay.Controllers.ResponseModels;
using CargoPay.Data.MigrationModel;


namespace CargoPay.Service.IServices
{
    public interface ICardService
    {

        public Task<ResponseModel<CardMigration>> CreateCard(double creditLimit);
        public Task<ResponseModel<object>> GetBalance(long cardNumber);
        public long generateCard();

    }
}
