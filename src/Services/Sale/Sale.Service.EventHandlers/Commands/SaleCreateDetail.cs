namespace Sale.Service.EventHandlers.Commands
{
    public class SaleCreateDetail
    {        
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }        
    }
}