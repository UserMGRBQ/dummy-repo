using Dummy.Core.Results.Base;

namespace Dummy.Core.Interfaces.Results.Inputs;

public interface IOrderable
{
    IEnumerable<OrdenationAttribute> Ordenations { get; set; }
}