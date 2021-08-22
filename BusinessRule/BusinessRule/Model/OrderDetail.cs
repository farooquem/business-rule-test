namespace BusinessRule.Services
{
    public class OrderDetail
    {
        public bool IsPhysical { get; set; }

        public ProductCategory ProductCategory { get; set; }

        public string ProductName { get; set; }
    }

    public enum ProductCategory
    {
        Book =1,
        Video = 2,
        Membership = 3
    }
}