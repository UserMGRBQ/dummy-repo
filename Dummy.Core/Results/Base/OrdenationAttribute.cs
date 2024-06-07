using System.ComponentModel;

namespace Dummy.Core.Results.Base;

public class OrdenationAttribute
{
    public string PropertyName { get; set; }
    public ListSortDirection Direction { get; set; }
}