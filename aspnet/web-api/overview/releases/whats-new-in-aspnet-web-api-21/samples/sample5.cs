// Add Accept header.
client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/bson"));

// POST data in BSON format.
HttpResponseMessage response = await client.PostAsync<MyData>("api/MyData", data, new 
BsonMediaTypeFormatter());

// GET data in BSON format.
data = await response.Content.ReadAsAsync<MyData>(new MediaTypeFormatter[] { 
  new BsonMediaTypeFormatter() });