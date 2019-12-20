namespace PageFilter.Models
{
    public class MyOptions
    {
        public MyOptions()
        {
            // Set default value.
            UserAgentID = "value1_from_ctor";
        }

        public string UserAgentID { get; set; }
        public int Option2 { get; set; } = 5;
    }
}
