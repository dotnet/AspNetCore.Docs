// Not the final implementation!
public Product PostProduct(Product item)
{
    item = repository.Add(item);
    return item;
}