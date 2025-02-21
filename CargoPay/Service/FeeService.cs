using CargoPay.Service.IServices;

namespace CargoPay.Service
{
    public class FeeService : IFeeService
    {

        private decimal baseFee;
        private Timer timer;
        private readonly object _lock = new object();

        public FeeService()
        {
            baseFee = 5;

            timer = new Timer(SetNewFee, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
        }

        public void SetNewFee(object? state)
        {
            lock (_lock)
            {
                Random randomDecimal = new Random();

                var result = 0.1m + (decimal)randomDecimal.NextDouble() * 1.9m;

                baseFee *= result;
            }
        }
        public decimal GetNewFee()
        {
            lock (_lock)
            {
                return baseFee;
            }
        }
    }
}
