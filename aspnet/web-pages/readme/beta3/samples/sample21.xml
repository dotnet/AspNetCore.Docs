Dim engine As SqlCeEngine = New SqlCeEngine(connString)
engine.CreateDatabase()
engine.Dispose()
Dim conn As SqlCeConnection = New SqlCeConnection(connString)
conn.Open()
Dim cmd As SqlCeCommand = conn.CreateCommand()
cmd.CommandText = "CREATE TABLE BlobTable(name nvarchar(128), blob ntext);"
cmd.ExecuteNonQuery()
cmd.CommandText = "INSERT INTO BlobTable(name, blob) VALUES (@name, @blob);"
Dim paramName As SqlCeParameter
Dim paramBlob As SqlCeParameterparamName = cmd.Parameters.Add("name", SqlDbType.NVarChar, 128)
paramName.Value = "Name1"
paramBlob = cmd.Parameters.Add("blob", SqlDbType.NText)
paramBlob.Value = "Name1".PadLeft(4001)
cmd.ExecuteNonQuery()