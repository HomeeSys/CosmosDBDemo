using Newtonsoft.Json;

namespace CosmosDBDemo;
public class Measurement
{
    [JsonProperty(PropertyName = "id")]
    public string ID { get; set; } = Guid.NewGuid().ToString();
    
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public double? Temperature { get; set; }
    
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public double? Humidity { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public double? Co2 { get; set; }
}
