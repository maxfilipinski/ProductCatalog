namespace ProductCatalog.Server.Models
{
    public class Product
    {
        public uint Id { get; set; }
        public Guid Code { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
