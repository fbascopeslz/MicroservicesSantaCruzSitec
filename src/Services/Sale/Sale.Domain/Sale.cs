using static Sale.Common.Enums;

namespace Sale.Domain
{
    public class Sale
    {
        public int SaleId { get; set; }
        public SaleStatus Status { get; set; }        
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public ICollection<SaleDetail> Items { get; set; } = new List<SaleDetail>();
    }
}