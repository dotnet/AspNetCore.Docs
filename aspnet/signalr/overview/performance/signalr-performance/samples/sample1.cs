using Newtonsoft.Json; 
using System; 
public class ShapeModel
{
	[JsonProperty("l")]
    public double Left { get; set; }
	[JsonProperty("t")]
    public double Top { get; set; }
    // We don't want the client to get the "LastUpdatedBy" property
	[JsonIgnore]
    public string LastUpdatedBy { get; set; }
}