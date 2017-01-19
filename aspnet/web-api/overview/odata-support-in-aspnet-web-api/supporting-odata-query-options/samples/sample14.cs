public class MyOrderByValidator : OrderByQueryValidator
{
    // Disallow the 'desc' parameter for $orderby option.
    public override void Validate(OrderByQueryOption orderByOption,
                                    ODataValidationSettings validationSettings)
    {
        if (orderByOption.OrderByNodes.Any(
                node => node.Direction == OrderByDirection.Descending))
        {
            throw new ODataException("The 'desc' option is not supported.");
        }
        base.Validate(orderByOption, validationSettings);
    }
}