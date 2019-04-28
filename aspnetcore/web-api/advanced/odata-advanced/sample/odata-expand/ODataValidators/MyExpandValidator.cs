using ContosoUniversity.Models;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Query.Validators;
using Microsoft.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.ODataValidators
{
    public class MyExpandValidator : SelectExpandQueryValidator
    {
        public MyExpandValidator(DefaultQuerySettings defaultQuerySettings) : base(defaultQuerySettings)
        {

        }
        public override void Validate(SelectExpandQueryOption selectExpandQueryOption, ODataValidationSettings validationSettings)
        {
            if (selectExpandQueryOption.RawExpand.Contains(nameof(Course.CourseAssignments)))
                throw new ODataException($"You can't query {nameof(Course.CourseAssignments)}!!!");
            base.Validate(selectExpandQueryOption, validationSettings);
        }
    }
}
