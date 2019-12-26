using System.Collections.Generic;

namespace Hexio.DineroClient.Models
{
    public class CollectionWrapper<T>
    {
        public IList<T> Collection { get; set; }
    }
}