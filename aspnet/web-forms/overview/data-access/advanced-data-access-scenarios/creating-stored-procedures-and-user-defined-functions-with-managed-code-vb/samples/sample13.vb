Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports Microsoft.SqlServer.Server
Partial Public Class UserDefinedFunctions
    <Microsoft.SqlServer.Server.SqlFunction()> _
    Public Shared Function udf_ComputeInventoryValue_Managed() As SqlString
        ' Add your code here
        Return New SqlString("Hello")
    End Function
End Class