using Newtonsoft.Json;

namespace CosmosDBDemo;
public class Measurement
{
    [JsonProperty(PropertyName = "id")]
    public string ID { get; set; } = Guid.NewGuid().ToString();
    public string Temperature { get; set; }
    public string Humidity { get; set; }
    public string Co2 { get; set; }
}
