namespace PurchaseApi.Services
{
    public interface IDataProviderService
    {
        List<string> GetProducts();
        string GetProduct(int index);
        void DeleteProduct(int index);
        string UpdateProduct(int index, string name);
        string CreateProduct(string name);
    }
}
