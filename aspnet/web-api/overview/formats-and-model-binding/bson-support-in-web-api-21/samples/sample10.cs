MediaTypeFormatter bsonFormatter = new BsonMediaTypeFormatter();
var result = await client.PostAsync("api/books", book, bsonFormatter);