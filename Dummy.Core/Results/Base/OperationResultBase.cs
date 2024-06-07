using Dummy.Core.Enums;
using System.Security.AccessControl;

namespace Dummy.Core.Results.Base;

public class OperationResultBase
{
    public List<string> Messages { get; set; }
    public EnumResultType ResultType { get; set; }
    public Exception Exception { get; set; }
    public bool IsSuccessResultType { get; set; }


}