﻿namespace Api.Gateway.Models.Sale.Commands
{
    public class SaleCreateDetail
    {        
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }        
    }
}