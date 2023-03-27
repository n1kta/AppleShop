namespace AppleShop.Web.Infrastructure
{
    public static class API
    {
        public static class Product
        {
            public static string GetAll(string baseUri)
            {
                return $"{baseUri}/product";
            }

            public static string GetById(string baseUri, Guid id)
            {
                return $"{baseUri}/product/{id}";
            }

            public static string Create(string baseUri)
            {
                return $"{baseUri}/product/create";
            }

            public static string Delete(string baseUri, Guid id)
            {
                return $"{baseUri}/product/delete/{id}";
            }

            public static string Update(string baseUri, Guid id)
            {
                return $"{baseUri}/product/update/{id}";
            }
        }
    }
}
