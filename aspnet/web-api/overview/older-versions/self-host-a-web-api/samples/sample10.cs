static void Main(string[] args)
{
    client.BaseAddress = new Uri("http://localhost:8080");

    ListAllProducts();
    ListProduct(1);
    ListProducts("toys");

    Console.WriteLine("Press Enter to quit.");
    Console.ReadLine();
}