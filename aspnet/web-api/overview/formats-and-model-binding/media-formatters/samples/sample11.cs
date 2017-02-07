public override void WriteToStream(Type type, object value, Stream writeStream, HttpContent content)
{
    Encoding effectiveEncoding = SelectCharacterEncoding(content.Headers);

    using (var writer = new StreamWriter(writeStream, effectiveEncoding))
    {
        // Write the object (code not shown)
    }
}