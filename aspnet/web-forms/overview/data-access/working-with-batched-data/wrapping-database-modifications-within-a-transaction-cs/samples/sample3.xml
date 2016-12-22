using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
namespace NorthwindTableAdapters
{
    public partial class ProductsTableAdapter
    {
        private SqlTransaction _transaction;
        private SqlTransaction Transaction
        {
            get
            {                
                return this._transaction;
            }
            set
            {
                this._transaction = value;
            }
        }
        public void BeginTransaction()
        {
            // Open the connection, if needed
            if (this.Connection.State != ConnectionState.Open)
                this.Connection.Open();
            // Create the transaction and assign it to the Transaction property
            this.Transaction = this.Connection.BeginTransaction();
            // Attach the transaction to the Adapters
            foreach (SqlCommand command in this.CommandCollection)
            {
                command.Transaction = this.Transaction;
            }
            this.Adapter.InsertCommand.Transaction = this.Transaction;
            this.Adapter.UpdateCommand.Transaction = this.Transaction;
            this.Adapter.DeleteCommand.Transaction = this.Transaction;
        }
        public void CommitTransaction()
        {
            // Commit the transaction
            this.Transaction.Commit();
            // Close the connection
            this.Connection.Close();
        }
        public void RollbackTransaction()
        {
            // Rollback the transaction
            this.Transaction.Rollback();
            // Close the connection
            this.Connection.Close();
        }
   }
}