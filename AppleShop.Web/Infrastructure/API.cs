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

        public static string GetDashboardAmount(string baseUri)
            => $"{baseUri}/product/getDashboardAmount";

        public static string GetTopProducts(string baseUri)
            => $"{baseUri}/product/getTopProducts";
    }

    public static class Category
    {
        public static string GetAllWithProducts(string baseUri)
            => $"{baseUri}/category/getAllWithProducts";
    }

    public static class Basket
    {
        public static string GetCart(string baseUri, string userId)
            => $"{baseUri}/cart/getCart/{userId}";

        public static string AddCart(string baseUri)
            => $"{baseUri}/cart/addCart";

        public static string UpdateCart(string baseUri)
            => $"{baseUri}/cart/updateCart";

        public static string RemoveCart(string baseUri, int cartId)
            => $"{baseUri}/cart/removeCart/{cartId}";
    }
}