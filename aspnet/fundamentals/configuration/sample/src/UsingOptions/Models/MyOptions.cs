public class MyOptions
{
    public MyOptions()
    {
        // Set default values.
        Option1 = "value1_from_ctor";
        Option2 = 5;
    }
    public string Option1 { get; set; }
    public int Option2 { get; set; }
}