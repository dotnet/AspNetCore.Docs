private System.Data.SqlClient.SqlDataAdapter _adapter;
private void InitAdapter() {
    this._adapter = new System.Data.SqlClient.SqlDataAdapter();
    
    ... Code that creates the InsertCommand, UpdateCommand, ...
    ... and DeleteCommand instances - omitted for brevity ...
}
private System.Data.SqlClient.SqlDataAdapter Adapter {
    get {
        if ((this._adapter == null)) {
            this.InitAdapter();
        }
        return this._adapter;
    }
}
private System.Data.SqlClient.SqlCommand[] _commandCollection;
private void InitCommandCollection() {
    this._commandCollection = new System.Data.SqlClient.SqlCommand[9];
    ... Code that creates the command objects for the main query and the ...
    ... ProductsTableAdapter�s other eight methods - omitted for brevity ...
}
protected System.Data.SqlClient.SqlCommand[] CommandCollection {
    get {
        if ((this._commandCollection == null)) {
            this.InitCommandCollection();
        }
        return this._commandCollection;
    }
}