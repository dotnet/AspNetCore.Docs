public ProductCsvFormatter()
{
    SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/csv"));

    // New code:
    SupportedEncodings.Add(new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
    SupportedEncodings.Add(Encoding.GetEncoding("iso-8859-1"));
}