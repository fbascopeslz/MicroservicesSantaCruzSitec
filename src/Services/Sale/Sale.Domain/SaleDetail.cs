namespace Sale.Domain
{
    public class SaleDetail
    {
        public int SaleDetailId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
    }
}