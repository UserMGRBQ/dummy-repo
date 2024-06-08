using Dummy.Core.Utilities;

namespace Dummy.Core.Validations.Base;

public static class BaseValidations
{
    public static bool BeValidDocument(string document)
    {
        return document.ValidateIndividualTaxpayerDocument() || document.ValidateCorporateTaxpayerDocument();
    }
}