namespace PurchaseApi.Services
{
    public class DataProviderService : IDataProviderService
    {
        private static readonly List<string> ProductNames = new List<string>
        { "Hoover", "TV", "Washing machine", "Dishwasher", "Skrewkdriver", "Saw" };

        public string CreateProduct(string name)
        {
            ProductNames.Add(name);
            return name;
        }
        public string UpdateProduct(int index, string name)
        {
            ProductNames[index] = name;
            return name;
        }

        public void DeleteProduct(int index)
        {
            ProductNames.RemoveAt(index);
        }

        public string GetProduct(int index)
        {
            return ProductNames[index];
        }

        public List<string> GetProducts()
        {
            return ProductNames;
        }
    }
}
