using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataAPI.ODataAttribute
{
    #region snippet
    public class MyEnableQueryAttribute : EnableQueryAttribute
    {
        private readonly DefaultQuerySettings defaultQuerySettings;
        public MyEnableQueryAttribute() : base()
        {
            defaultQuerySettings = new DefaultQuerySettings();
            defaultQuerySettings.EnableOrderBy = true;
        }
        public override void ValidateQuery(HttpRequest request, ODataQueryOptions queryOptions)
        {
            if (queryOptions.OrderBy != null)
            {
                queryOptions.OrderBy.Validator = new MyOrderByValidator(defaultQuerySettings);
            }
            base.ValidateQuery(request, queryOptions);
        }
    }
    #endregion
}
