namespace AppleShop.Web.Infrastructure;

public static class API
{
    public static class Product
    {
        public static string GetAll(string baseUri)
            => $"{baseUri}/product";

        public static string GetById(string baseUri, Guid id)
            => $"{baseUri}/product/{id}";

        public static string Create(string baseUri)
            => $"{baseUri}/product/create";

        public static string Delete(string baseUri, Guid id)
            => $"{baseUri}/product/delete/{id}";

        public static string Update(string baseUri, Guid id)
            => $"{baseUri}/product/update/{id}";
    }

    public static class Category
    {
        public static string GetAllWithProducts(string baseUri)
            => $"{baseUri}/category/getAllWithProducts";
    }
}