static void ListAllProducts()
{
    HttpResponseMessage resp = client.GetAsync("api/products").Result;
    resp.EnsureSuccessStatusCode();

    var products = resp.Content.ReadAsAsync<IEnumerable<SelfHost.Product>>().Result;
    foreach (var p in products)
    {
        Console.WriteLine("{0} {1} {2} ({3})", p.Id, p.Name, p.Price, p.Category);
    }
}

static void ListProduct(int id)
{
    var resp = client.GetAsync(string.Format("api/products/{0}", id)).Result;
    resp.EnsureSuccessStatusCode();

    var product = resp.Content.ReadAsAsync<SelfHost.Product>().Result;
    Console.WriteLine("ID {0}: {1}", id, product.Name);
}

static void ListProducts(string category)
{
    Console.WriteLine("Products in '{0}':", category);

    string query = string.Format("api/products?category={0}", category);

    var resp = client.GetAsync(query).Result;
    resp.EnsureSuccessStatusCode();

    var products = resp.Content.ReadAsAsync<IEnumerable<SelfHost.Product>>().Result;
    foreach (var product in products)
    {
        Console.WriteLine(product.Name);
    }
}