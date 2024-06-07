namespace Dummy.Core.Interfaces.Results.Inputs;

public interface IPagination : IOrderable
{
    int ItemsPerPage { get; set; }
    int Page { get; set; }
    bool CountTotal { get; set; }
}