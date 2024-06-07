using Dummy.Core.Interfaces.Results.Inputs;

namespace Dummy.Core.Results.Base;

public class BaseFilter : IPagination
{
    public int ItemsPerPage { get; set; } = 30;
    public int Page { get; set; }
    public bool CountTotal { get; set; }
    public IEnumerable<OrdenationAttribute> Ordenations { get; set; }
}