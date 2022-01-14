namespace SampleApp.Models
{
    // <snippet1>
    public class MyOptions
    {
        public MyOptions()
        {
            Option1 = "Value set in constructor";
        }

        public string Option1 { get; set; }
        public int Option2 { get; set; } = 5;
    }
    // </snippet1>
}
