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

    }
}