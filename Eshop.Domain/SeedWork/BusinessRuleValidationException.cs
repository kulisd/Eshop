namespace Eshop.Domain.SeedWork;

public class BusinessRuleValidationException(IBusinessRule brokenRule) : Exception("Violation of a business rule.")
{
    private IBusinessRule BrokenRule { get; } = brokenRule;

    public string Details { get; } = brokenRule.Message;

    public override string ToString()
    {
        return $"{BrokenRule.GetType().FullName}: {BrokenRule.Message}";
    }
}