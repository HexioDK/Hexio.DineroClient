using System.Collections.Generic;

namespace Hexio.DineroClient.Models
{
    public interface IReadModel
    {
        IList<string> FieldsToFilter { get; }
        IList<string> GetDefaultFields();
    }
}