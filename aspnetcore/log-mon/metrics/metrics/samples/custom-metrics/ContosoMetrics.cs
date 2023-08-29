using System.Diagnostics.Metrics;
using Microsoft.Extensions.Diagnostics.Metrics;

// <snippet_ContosoMetrics>
public class ContosoMetrics
{
    private readonly Counter<int> _productSoldCounter;

    public ContosoMetrics(IMeterFactory meterFactory)
    {
        var meter = meterFactory.Create("Contoso.Web");
        _productSoldCounter = meter.CreateCounter<int>("contoso.product.sold");
    }

    public void ProductSold(string productName, int quantity)
    {
        _productSoldCounter.Add(quantity,
            new KeyValuePair<string, object?>("contoso.product.name", productName));
    }
}
// </snippet_ContosoMetrics>
