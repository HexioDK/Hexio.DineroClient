using System;
using System.Collections.Generic;

namespace Hexio.DineroClient.Models.Products
{
    public class ProductReadModel : CreateProductModel, IReadModel
    {
        public Guid ProductGuid { get; set; }
        public long? BaseAmountValueInclVat { get; set; }
        public long? TotalAmount { get; set; }
        public long? TotalAmountInclVat { get; set; }
        
        public IList<string> FieldsToFilter { get; } = new List<string>
        {
            "Name",
            "ProductNumber",
            "ExternalReference"
        };
        
        public IList<string> GetDefaultFields()
        {
            return new List<string>
            {
                "Name",
                "ProductGuid"
            };
        }
    }
}