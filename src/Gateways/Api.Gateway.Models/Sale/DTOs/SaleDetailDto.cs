namespace Api.Gateway.Models.Sale.DTOs
{
    public class SaleDetailDto
    {
        public int SaleDetailId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
    }
}