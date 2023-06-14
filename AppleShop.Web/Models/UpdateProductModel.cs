namespace AppleShop.Web.Models
{
    public class UpdateProductModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Color { get; set; }
        public int Memory { get; set; }
        public int AvailableStock { get; set; }
        public IFormFile? Picture { get; set; }
        public double Price { get; set; }
        public Guid CategoryId { get; set; }
        public string? Series { get; set; }
    }
}
