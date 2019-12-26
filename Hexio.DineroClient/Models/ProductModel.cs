using System;

namespace Hexio.DineroClient.Models
{
    public class ProductModel
    {
        public Guid ProductGuid { get; set; }
        public string Name { get; set; }
        public string ExternalReference { get; set; }
    }
}