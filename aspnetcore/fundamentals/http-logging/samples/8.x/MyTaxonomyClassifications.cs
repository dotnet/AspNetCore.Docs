using Microsoft.Extensions.Compliance.Classification;

namespace HttpLoggingSample
{
    public static class MyTaxonomyClassifications
    {
        public static string Name => "MyTaxonomy";

        public static DataClassification Private => new(Name, nameof(Private));
        public static DataClassification Public => new(Name, nameof(Public));
        public static DataClassification Personal => new(Name, nameof(Personal));
    }
}
