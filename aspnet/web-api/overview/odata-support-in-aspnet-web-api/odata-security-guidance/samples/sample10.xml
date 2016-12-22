// Validator to restrict which properties can be used in $filter expressions.
public class MyFilterQueryValidator : FilterQueryValidator
{
    static readonly string[] allowedProperties = { "ReleaseYear", "Title" };

    public override void ValidateSingleValuePropertyAccessNode(
        SingleValuePropertyAccessNode propertyAccessNode,
        ODataValidationSettings settings)
    {
        string propertyName = null;
        if (propertyAccessNode != null)
        {
            propertyName = propertyAccessNode.Property.Name;
        }

        if (propertyName != null && !allowedProperties.Contains(propertyName))
        {
            throw new ODataException(
                String.Format("Filter on {0} not allowed", propertyName));
        }
        base.ValidateSingleValuePropertyAccessNode(propertyAccessNode, settings);
    }
}