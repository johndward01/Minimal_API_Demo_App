using Minimal_API_Demo;

internal interface IProductRepo
{
    public IEnumerable<Product> GetProducts();
    public Product GetProduct(int id);
    public void InsertProduct(Product prod);
    public void UpdateProduct(Product prod);
    public void DeleteProduct(Product prod);
}