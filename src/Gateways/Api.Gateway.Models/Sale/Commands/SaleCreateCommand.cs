namespace Api.Gateway.Models.Sale.Commands
{
    public class SaleCreateCommand
    {
        public IEnumerable<SaleCreateDetail> Items { get; set; } = new List<SaleCreateDetail>();
    }
}