public override void WriteToStream(Type type, object value, Stream writeStream, HttpContent content)
{
    using (var writer = new StreamWriter(writeStream))
    {
        var products = value as IEnumerable<Product>;
        if (products != null)
        {
            foreach (var product in products)
            {
                WriteItem(product, writer);
            }
        }
        else
        {
            var singleProduct = value as Product;
            if (singleProduct == null)
            {
                throw new InvalidOperationException("Cannot serialize type");
            }
            WriteItem(singleProduct, writer);
        }
    }
}

// Helper methods for serializing Products to CSV format. 
private void WriteItem(Product product, StreamWriter writer)
{
    writer.WriteLine("{0},{1},{2},{3}", Escape(product.Id),
        Escape(product.Name), Escape(product.Category), Escape(product.Price));
}

static char[] _specialChars = new char[] { ',', '\n', '\r', '"' };

private string Escape(object o)
{
    if (o == null)
    {
        return "";
    }
    string field = o.ToString();
    if (field.IndexOfAny(_specialChars) != -1)
    {
        // Delimit the entire field with quotes and replace embedded quotes with "".
        return String.Format("\"{0}\"", field.Replace("\"", "\"\""));
    }
    else return field;
}