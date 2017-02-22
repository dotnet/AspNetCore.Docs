using System.Collections.Generic;
using System.ComponentModel;

namespace MvcApplication1.Models
{

    public partial class Movie : IDataErrorInfo
    {
        private Dictionary<string, string> _errors = new Dictionary<string, string>();

        partial void OnTitleChanging(string value)
        {
            if (value.Trim().Length == 0)
                _errors.Add("Title", "Title is required.");
        }

        partial void OnDirectorChanging(string value)
        {
            if (value.Trim().Length == 0)
                _errors.Add("Director", "Director is required.");
        }

        #region IDataErrorInfo Members

        public string Error
        {
            get
            {
                return string.Empty;
            }
        }

        public string this[string columnName]
        {
            get
            {
                if (_errors.ContainsKey(columnName))
                    return _errors[columnName];
                return string.Empty;
            }
        }

        #endregion
    }
}