var bson = new BsonMediaTypeFormatter();
bson.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/vnd.contoso"));
config.Formatters.Add(bson);