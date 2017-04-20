private System.Data.SqlClient.SqlConnection _connection;
private void InitConnection() {
    this._connection = new System.Data.SqlClient.SqlConnection();
    this._connection.ConnectionString = 
        ConfigurationManager.ConnectionStrings["NORTHWNDConnectionString"].ConnectionString;
}
internal System.Data.SqlClient.SqlConnection Connection {
    get {
        if ((this._connection == null)) {
            this.InitConnection();
        }
        return this._connection;
    }
    set {
        this._connection = value;
        if ((this.Adapter.InsertCommand != null)) {
            this.Adapter.InsertCommand.Connection = value;
        }
        if ((this.Adapter.DeleteCommand != null)) {
            this.Adapter.DeleteCommand.Connection = value;
        }
        if ((this.Adapter.UpdateCommand != null)) {
            this.Adapter.UpdateCommand.Connection = value;
        }
        for (int i = 0; (i < this.CommandCollection.Length); i = (i + 1)) {
            if ((this.CommandCollection[i] != null)) {
                ((System.Data.SqlClient.SqlCommand)
                    (this.CommandCollection[i])).Connection = value;
            }
        }
    }
}