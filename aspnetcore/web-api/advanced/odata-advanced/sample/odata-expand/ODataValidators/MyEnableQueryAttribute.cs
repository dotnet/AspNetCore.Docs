using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Http;

namespace ContosoUniversity.ODataValidators
{
    #region snippet
    public class MyEnableQueryAttribute : EnableQueryAttribute
    {
        private readonly DefaultQuerySettings defaultQuerySettings;
        public MyEnableQueryAttribute()
        {
            this.defaultQuerySettings = new DefaultQuerySettings();
            this.defaultQuerySettings.EnableExpand = true;
            this.defaultQuerySettings.EnableSelect = true;
        }
        public override void ValidateQuery(HttpRequest request, ODataQueryOptions queryOptions)
        {
            queryOptions.SelectExpand.Validator = 
                                              new MyExpandValidator(this.defaultQuerySettings);
            base.ValidateQuery(request, queryOptions);
        }
    }
    #endregion
}