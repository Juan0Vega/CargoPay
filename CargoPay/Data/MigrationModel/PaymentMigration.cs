using System.Text.Json.Serialization;

namespace CargoPay.Data.MigrationModel
{
    public class PaymentMigration
    {
        public Guid Id { get; set; }
        public long CardNumber { get; set; }
        public double Amount { get; set; }
        public decimal Fee { get; set; }

        public double FinalAmount { get; set; }
        [JsonIgnore]
        public CardMigration ? card { get; set; }

    }
}
