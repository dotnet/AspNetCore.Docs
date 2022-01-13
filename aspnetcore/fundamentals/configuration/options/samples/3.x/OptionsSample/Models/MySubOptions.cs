namespace SampleApp.Models
{
    // <snippet1>
    public class MySubOptions
    {
        public MySubOptions()
        {
            // Set default values.
            SubOption1 = "value1_from_ctor";
            SubOption2 = 5;
        }

        public string SubOption1 { get; set; }
        public int SubOption2 { get; set; }
    }
    // </snippet1>
}
