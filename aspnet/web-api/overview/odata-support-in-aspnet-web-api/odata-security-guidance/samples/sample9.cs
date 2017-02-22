// Validator to prevent filtering on navigation properties.
public class MyFilterQueryValidator : FilterQueryValidator
{
    public override void ValidateNavigationPropertyNode(
        Microsoft.Data.OData.Query.SemanticAst.QueryNode sourceNode, 
        Microsoft.Data.Edm.IEdmNavigationProperty navigationProperty, 
        ODataValidationSettings settings)
    {
        throw new ODataException("No navigation properties");
    }
}