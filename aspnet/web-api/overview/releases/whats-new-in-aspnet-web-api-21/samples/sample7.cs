// Query parsing
HttpValueCollection collection = new Uri("http://api/something?catId=3&catId=4&dogId=1,2").ParseQueryString();

Console.WriteLine(collection["catId"]); // output: 3,4
Console.WriteLine(collection["dogId"]); // output: 1,2

// Modify the query
collection.Add("dogId", "7");

// Index into the values
Console.WriteLine(collection["catId"]); // output: 3,4
Console.WriteLine(collection["dogId"]); // output: 1,2,7

// Recreate the query string
Console.WriteLine(collection.ToString()); // output: catId=3&catId=4&dogId=1%2C2&dogId=7

// Query generation
HttpValueCollection newCollection = new HttpValueCollection();

newCollection.Add("catId", "1");
newCollection.Add("dogId", "7");

// Index into the values
Console.WriteLine(newCollection["catId"]); // output: 1
Console.WriteLine(newCollection["dogId"]); // output: 7

// Create the query string
Console.WriteLine(newCollection.ToString()); // catId=1&dogId=7