public static string[] GetCustomerIDs(string prefixText, int count)
{
     //Customer IDs cached in _CustomerIDs field to improve performance
     if (_CustomerIDs == null)
     {
          List<string> ids = new List<string>();
          //SQL text used for simplicity...recommend using sprocs
          string sql = "SELECT CustomerID FROM Customers";
          DbConnection conn = GetDBConnection();
          conn.Open();
          DbCommand cmd = conn.CreateCommand();
          cmd.CommandText = sql;
          DbDataReader reader = cmd.ExecuteReader();
          while (reader.Read())
          {
               ids.Add(reader["CustomerID"].ToString());
          }
          reader.Close();
          conn.Close();
          _CustomerIDs = ids.ToArray();
     }
     int index = Array.BinarySearch(_CustomerIDs, prefixText, new CaseInsensitiveComparer());
     //~ is bitwise complement (reverse each bit)
     if (index < 0) index = ~index;
     int matchingCount;
     for (matchingCount = 0; matchingCount < count && index + matchingCount < _CustomerIDs.Length; matchingCount++)
     {
          if (!_CustomerIDs[index + matchingCount].StartsWith(prefixText, StringComparison.CurrentCultureIgnoreCase))
          {
               break;
          }
     }
     String[] returnValue = new string[matchingCount];
     if (matchingCount > 0)
     {
          Array.Copy(_CustomerIDs, index, returnValue, 0, matchingCount);
     }
     return returnValue;
}