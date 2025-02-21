
using CargoPay.Controllers.ResponseModels;
using CargoPay.Data;
using CargoPay.Data.MigrationModel;
using CargoPay.Service.IServices;


namespace CargoPay.Bussiness
{
    public class CardService : ICardService
    {

        private readonly CargoPayContext _CargoPayContext;

        public CardService(CargoPayContext cargoPayContext)
        {
            _CargoPayContext = cargoPayContext;
        }


        public async Task<ResponseModel<CardMigration>> CreateCard(double creditLimit)
        {
            long newCardId = generateCard();

            var newCard = new CardMigration()
            {
                Id = newCardId,
                CreditLimit = creditLimit
            };
            
            var response = new ResponseModel<CardMigration>();

            try
            {
                await _CargoPayContext.Cards.AddAsync(newCard);
                int result = await _CargoPayContext.SaveChangesAsync();

                response.Message = result > 0 ? "Tarjeta creada con exito" : "No se pudo crear la tarjeta";
                response.data = result > 0 ? newCard : null;

                return response;

                
            }
            catch (Exception ex)
            {
                response.Message = $"Error: {ex.Message}";

                return response;
            }
            
        }

        public async Task<ResponseModel<object>> GetBalance(long cardNumber)
        {
            
            var record = await _CargoPayContext.Cards.FindAsync(cardNumber);

            var response = new ResponseModel<object>() {

                Message = $"La tarjeta {cardNumber} no existe"

            };

            if(record != null)
            {
                response.Message = "Consulta exitosa";
                response.Balance = record.CreditLimit;
            }

            return response;
        }

        public long generateCard()
        {

            Random randomId = new Random();

            long newCardId = randomId.NextInt64(100_000_000_000_000, 999_999_999_999_999);
          
            Console.WriteLine($"Este es el número: {newCardId}");

            return newCardId;

        }
    }
}
