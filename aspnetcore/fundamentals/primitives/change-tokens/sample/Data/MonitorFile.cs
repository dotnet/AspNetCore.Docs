using ChangeTokenSample.Enums;

namespace ChangeTokenSample.Data
{
    #region snippet1
    public static class MonitorFile
    {
        public static string FileName { get; set; } = "Spirits of the Dead";
        public static string FilePath { get; set; } = "poem.txt";
        public static FileState CurrentFileState { get; set; } = FileState.NotUpdated;
    }
    #endregion
}
