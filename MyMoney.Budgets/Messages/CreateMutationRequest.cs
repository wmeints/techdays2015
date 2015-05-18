using Newtonsoft.Json;

namespace MyMoney.Budgets.Messages
{
    public class CreateMutationRequest
    {
        [JsonPropertyAttribute("description")]
        public string Description { get; set; }

        [JsonPropertyAttribute("category")]
        public string Category { get; set; }

        [JsonPropertyAttribute("amount")]
        public double Amount { get; set; }
    }
}