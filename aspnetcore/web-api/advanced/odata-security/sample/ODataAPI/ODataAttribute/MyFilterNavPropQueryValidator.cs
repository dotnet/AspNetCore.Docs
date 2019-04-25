using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Query.Validators;
using Microsoft.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.UriParser;

namespace ODataAPI.ODataAttribute
{
    #region snippet
    // Validator to prevent filtering on navigation properties.
    public class MyFilterNavPropQueryValidator : FilterQueryValidator
    {
        
        public override void ValidateNavigationPropertyNode(
        QueryNode sourceNode,
        IEdmNavigationProperty navigationProperty,
        ODataValidationSettings settings)
        {
            throw new ODataException("Filtering on navigation properties prohibited");
        }

        public MyFilterNavPropQueryValidator(DefaultQuerySettings defaultQuerySettings) 
                                                           : base(defaultQuerySettings)
        {

        }
    }
    #endregion
}
