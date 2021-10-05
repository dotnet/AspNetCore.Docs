namespace TodoApi.Models
{
    #region snippet_LoggingEvents
    public class MyLogEvents
    {
        public const int GenerateItems = 1000;
        public const int ListItems     = 1001;
        public const int GetItem       = 1002;
        public const int InsertItem    = 1003;
        public const int UpdateItem    = 1004;
        public const int DeleteItem    = 1005;

        public const int TestItem      = 3000;

        public const int GetItemNotFound    = 4000;
        public const int UpdateItemNotFound = 4001;
    }
    #endregion

    // review, enum nicer but doesn't work 
    #region snippet_LoggingEvents2
    public class MyLogEvent
    {
        public enum ID : int
        {
            GenerateItems = 1000,
            ListItems,
            GetItem,
            InsertItem,
            UpdateItem,
            DeleteItem,

            TestItem = 3000,

            GetItemNotFound = 4000,
            UpdateItemNotFound
        }
    }
    #endregion
}
