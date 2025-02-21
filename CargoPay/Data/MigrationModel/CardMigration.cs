using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CargoPay.Data.MigrationModel
{
    public class CardMigration
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
        public double CreditLimit { get; set; }

        [JsonIgnore]
        public ICollection<PaymentMigration> ? payments { get; set; }

    }
}
