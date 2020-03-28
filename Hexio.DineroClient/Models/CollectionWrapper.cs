using System.Collections.Generic;

namespace Hexio.DineroClient.Models
{
    public class CollectionWrapper<T>
    {
        public IList<T> Collection { get; set; }
        public Pagination Pagination { get; set; }
    }

    public class Pagination
    {
        public int MaxPageSizeAllowed { get; set; }
        public int PageSize { get; set; }
        public int Result { get; set; }
        public int ResultWithoutFilter { get; set; }
        public int Page { get; set; }
    }
}