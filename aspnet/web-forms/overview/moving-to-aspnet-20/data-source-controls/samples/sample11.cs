using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
public class NorthwindData {
    private string _connectionString;
    public NorthwindData() {
        Initialize();
    }

    private void Initialize() {
        if (ConfigurationManager.ConnectionStrings["Northwind"] == null ||
            ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString.Trim() == "") {
                throw new Exception("A connection string named 'Northwind' with " +
                "a valid connection string must exist in the <connectionStrings> " +
                "configuration section for the application.");
        }
        _connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
    }

    public DataTable GetAllEmployees(string sortColumns, int startRecord, int maxRecords) {
        VerifySortColumns(sortColumns);
        string sqlCmd = "SELECT EmployeeID, LastName, FirstName, Address, " +
            "City, Region, PostalCode FROM Employees ";
        if (sortColumns.Trim() == "")
            sqlCmd += "ORDER BY EmployeeID";
        else
            sqlCmd += "ORDER BY " + sortColumns;

        SqlConnection conn = new SqlConnection(_connectionString);
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
        DataSet ds = new DataSet();
        try {
            conn.Open();
            da.Fill(ds, startRecord, maxRecords, "Employees");
        } catch (SqlException e) {
            // Handle exception.
        } finally {
            conn.Close();
        }
        return ds.Tables["Employees"];
    }

    public int SelectCount() {
        SqlConnection conn = new SqlConnection(_connectionString);
        SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Employees", conn);
        int result = 0;

        try {
            conn.Open();
            result = (int)cmd.ExecuteScalar();
        } catch (SqlException e) {
            // Handle exception.
        } finally {
            conn.Close();
        }
        return result;
    }

    //////////
    // Verify that only valid columns are specified in the sort expression to
    // avoid a SQL Injection attack.
    private void VerifySortColumns(string sortColumns) {
        if (sortColumns.ToLowerInvariant().EndsWith(" desc"))
            sortColumns = sortColumns.Substring(0, sortColumns.Length - 5);
        string[] columnNames = sortColumns.Split(',');
        foreach (string columnName in columnNames) {
            switch (columnName.Trim().ToLowerInvariant()) {
                case "employeeid":
                    break;
                case "lastname":
                    break;
                case "firstname":
                    break;
                case "":
                    break;
                default:
                    throw new ArgumentException("SortColumns contains an " +
                        "invalid column name.");
                    break;
            }
        }
    }

    // Select an employee.
    public DataTable GetEmployee(int EmployeeID) {
        SqlConnection conn = new SqlConnection(_connectionString);
        SqlDataAdapter da =
            new SqlDataAdapter("SELECT EmployeeID, LastName, FirstName, " +
            "Address, City, Region, PostalCode " +
            " FROM Employees WHERE EmployeeID = @EmployeeID", conn);
        da.SelectCommand.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = EmployeeID;
        DataSet ds = new DataSet();
        try {
            conn.Open();
            da.Fill(ds, "Employees");
        } catch (SqlException e) {
            // Handle exception.
        } finally {
            conn.Close();
        }

        return ds.Tables["Employees"];
    }

    // Delete the Employee by ID.
    public int DeleteEmployee(int EmployeeID) {
         SqlConnection conn = new SqlConnection(_connectionString);
         SqlCommand cmd = new SqlCommand("DELETE FROM Employees WHERE " +
             "EmployeeID = @EmployeeID", conn);
         cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = EmployeeID;
         int result = 0;
         try {
             conn.Open();
             result = cmd.ExecuteNonQuery();
         } catch (SqlException e) {
             // Handle exception.
         } finally {
             conn.Close();
         }

         return result;
     }

     // Update the Employee by original ID.
     public int UpdateEmployee(int EmployeeID, string LastName, string FirstName,
         string Address, string City, string Region,
         string PostalCode) {
         if (String.IsNullOrEmpty(FirstName))
             throw new ArgumentException("FirstName cannot be null or an empty string.");
         if (String.IsNullOrEmpty(LastName))
             throw new ArgumentException("LastName cannot be null or an empty string.");
         if (Address == null) { Address = String.Empty; }
         if (City == null) { City = String.Empty; }
         if (Region == null) { Region = String.Empty; }
         if (PostalCode == null) { PostalCode = String.Empty; }

         SqlConnection conn = new SqlConnection(_connectionString);
         SqlCommand cmd = new SqlCommand("UPDATE Employees " +
             " SET FirstName=@FirstName, " +
             "LastName=@LastName, " +
             "Address=@Address, City=@City, " +
             "Region=@Region, " +
             "PostalCode=@PostalCode " +
             "WHERE EmployeeID=@EmployeeID", conn);
         cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 10).Value = FirstName;
         cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 20).Value = LastName;
         cmd.Parameters.Add("@Address", SqlDbType.VarChar, 60).Value = Address;
         cmd.Parameters.Add("@City", SqlDbType.VarChar, 15).Value = City;
         cmd.Parameters.Add("@Region", SqlDbType.VarChar, 15).Value = Region;
         cmd.Parameters.Add("@PostalCode", SqlDbType.VarChar, 10).Value = PostalCode;
         cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = EmployeeID;

         int result = 0;
         try {
             conn.Open();
             result = cmd.ExecuteNonQuery();
         } catch (SqlException e) {
             // Handle exception.
         } finally {
             conn.Close();
         }

         return result;
    }

    // Insert an Employee.
    public int InsertEmployee(string LastName, string FirstName,
        string Address, string City, string Region,
        string PostalCode) {
        if (String.IsNullOrEmpty(FirstName))
            throw new ArgumentException("FirstName cannot be null or an empty string.");
        if (String.IsNullOrEmpty(LastName))
            throw new ArgumentException("LastName cannot be null or an empty string.");
        if (Address == null) { Address = String.Empty; }
        if (City == null) { City = String.Empty; }
        if (Region == null) { Region = String.Empty; }
        if (PostalCode == null) { PostalCode = String.Empty; }

        SqlConnection conn = new SqlConnection(_connectionString);
        SqlCommand cmd = new SqlCommand("INSERT INTO Employees " +
            " (FirstName, LastName, Address, " +
            " City, Region, PostalCode) " +
            " Values(@FirstName, @LastName, " +
            "@Address, @City, @Region, @PostalCode); " +
            "SELECT @EmployeeID = SCOPE_IDENTITY()", conn);

        cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 10).Value = FirstName;
        cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 20).Value = LastName;
        cmd.Parameters.Add("@Address", SqlDbType.VarChar, 60).Value = Address;
        cmd.Parameters.Add("@City", SqlDbType.VarChar, 15).Value = City;
        cmd.Parameters.Add("@Region", SqlDbType.VarChar, 15).Value = Region;
        cmd.Parameters.Add("@PostalCode", SqlDbType.VarChar, 10).Value = PostalCode;
        SqlParameter p = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
        int newEmployeeID = 0;
        try {
            conn.Open();
            cmd.ExecuteNonQuery();
            newEmployeeID = (int)p.Value;
        } catch (SqlException e) {
            // Handle exception.
        } finally {
            conn.Close();
        }

        return newEmployeeID;
    }

    //
    // Methods that support Optimistic Concurrency checks.
    //
    // Delete the Employee by ID.
    public int DeleteEmployee(int original_EmployeeID, string original_LastName,
        string original_FirstName, string original_Address,
        string original_City, string original_Region,
        string original_PostalCode) {

        if (String.IsNullOrEmpty(original_FirstName))
            throw new ArgumentException("FirstName cannot be null or an empty string.");
        if (String.IsNullOrEmpty(original_LastName))
            throw new ArgumentException("LastName cannot be null or an empty string.");
        if (original_Address == null) { original_Address = String.Empty; }
        if (original_City == null) { original_City = String.Empty; }
        if (original_Region == null) { original_Region = String.Empty; }
        if (original_PostalCode == null) { original_PostalCode = String.Empty; }
        string sqlCmd = "DELETE FROM Employees WHERE EmployeeID = " + @original_EmployeeID

        SqlConnection conn = new SqlConnection(_connectionString);
        SqlCommand cmd = new SqlCommand(sqlCmd, conn);
        cmd.Parameters.Add("@original_EmployeeID",
            SqlDbType.Int).Value = original_EmployeeID;
        cmd.Parameters.Add("@original_FirstName",
            SqlDbType.VarChar, 10).Value = original_FirstName;
        cmd.Parameters.Add("@original_LastName",
            SqlDbType.VarChar, 20).Value = original_LastName;
        cmd.Parameters.Add("@original_Address",
            SqlDbType.VarChar, 60).Value = original_Address;
        cmd.Parameters.Add("@original_City",
            SqlDbType.VarChar, 15).Value = original_City;
        cmd.Parameters.Add("@original_Region",
            SqlDbType.VarChar, 15).Value = original_Region;
        cmd.Parameters.Add("@original_PostalCode",
            SqlDbType.VarChar, 10).Value = original_PostalCode;

        int result = 0;
        try {
            conn.Open();
            result = cmd.ExecuteNonQuery();
        } catch (SqlException e) {
            // Handle exception.
        } finally {
            conn.Close();
        }

        return result;
    }

    // Update the Employee by original ID.
    public int UpdateEmployee(string LastName, string FirstName,
        string Address, string City, string Region,
        string PostalCode, int original_EmployeeID,
        string original_LastName, string original_FirstName,
        string original_Address, string original_City,
        string original_Region, string original_PostalCode) {

        if (String.IsNullOrEmpty(FirstName))
            throw new ArgumentException("FirstName cannot be null or an empty string.");
        if (String.IsNullOrEmpty(LastName))
            throw new ArgumentException("LastName cannot be null or an empty string.");
        if (Address == null) { Address = String.Empty; }
        if (City == null) { City = String.Empty; }
        if (Region == null) { Region = String.Empty; }
        if (PostalCode == null) { PostalCode = String.Empty; }
        if (original_Address == null) { original_Address = String.Empty; }
        if (original_City == null) { original_City = String.Empty; }
        if (original_Region == null) { original_Region = String.Empty; }
        if (original_PostalCode == null) { original_PostalCode = String.Empty; }

        string sqlCmd = "UPDATE Employees " +
            " SET FirstName = @FirstName, LastName = @LastName, " +
            " Address = @Address, City = @City, Region = @Region, " +
            " PostalCode = @PostalCode " +
            " WHERE EmployeeID = @original_EmployeeID";

        SqlConnection conn = new SqlConnection(_connectionString);
        SqlCommand cmd = new SqlCommand(sqlCmd, conn);
        cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 10).Value = FirstName;
        cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 20).Value = LastName;
        cmd.Parameters.Add("@Address", SqlDbType.VarChar, 60).Value = Address;
        cmd.Parameters.Add("@City", SqlDbType.VarChar, 15).Value = City;
        cmd.Parameters.Add("@Region", SqlDbType.VarChar, 15).Value = Region;
        cmd.Parameters.Add("@PostalCode", SqlDbType.VarChar, 10).Value = PostalCode;
        cmd.Parameters.Add("@original_EmployeeID",
            SqlDbType.Int).Value = original_EmployeeID;
        cmd.Parameters.Add("@original_FirstName",
            SqlDbType.VarChar, 10).Value = original_FirstName;
        cmd.Parameters.Add("@original_LastName",
            SqlDbType.VarChar, 20).Value = original_LastName;
        cmd.Parameters.Add("@original_Address",
            SqlDbType.VarChar, 60).Value = original_Address;
        cmd.Parameters.Add("@original_City",
            SqlDbType.VarChar, 15).Value = original_City;
        cmd.Parameters.Add("@original_Region",
            SqlDbType.VarChar, 15).Value = original_Region;
        cmd.Parameters.Add("@original_PostalCode",
            SqlDbType.VarChar, 10).Value = original_PostalCode;

        int result = 0;

        try {
            conn.Open();
            result = cmd.ExecuteNonQuery();
        } catch (SqlException e) {
            // Handle exception.
        } finally {
            conn.Close();
        }
        return result;
    }
}