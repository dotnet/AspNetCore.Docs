using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.DAL
{
    [MetadataType(typeof(DepartmentMetaData))]
    public partial class Department
    {
    }

    public class DepartmentMetaData
    {
        [DataType(DataType.Currency)]
        [Range(0, 1000000, ErrorMessage = "Budget must be less than $1,000,000.00")]
        public Decimal Budget { get; set; }

        [DisplayFormat(DataFormatString="{0:d}",ApplyFormatInEditMode=true)]
        public DateTime StartDate { get; set; }

    }
}