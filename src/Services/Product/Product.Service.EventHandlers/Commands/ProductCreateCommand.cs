﻿using MediatR;

namespace Product.Service.EventHandlers.Commands
{
    public class ProductCreateCommand : INotification
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}