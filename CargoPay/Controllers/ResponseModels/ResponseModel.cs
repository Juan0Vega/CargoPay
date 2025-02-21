using System.Text.Json.Serialization;

namespace CargoPay.Controllers.ResponseModels
{
    public class ResponseModel<T>
    {
        public string ? Message { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public T? data { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Balance { get; set; }

    }
}
