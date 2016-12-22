public void SetCommandTimeout(int timeout)
{
    if (this.Adapter.InsertCommand != null)
        this.Adapter.InsertCommand.CommandTimeout = timeout;
    if (this.Adapter.DeleteCommand != null)
        this.Adapter.DeleteCommand.CommandTimeout = timeout;
    if (this.Adapter.UpdateCommand != null)
        this.Adapter.UpdateCommand.CommandTimeout = timeout;
    for (int i = 0; i < this.CommandCollection.Length; i++)
        if (this.CommandCollection[i] != null)
            this.CommandCollection[i].CommandTimeout = timeout;
}