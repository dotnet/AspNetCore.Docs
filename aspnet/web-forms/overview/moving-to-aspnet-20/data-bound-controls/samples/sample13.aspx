<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>

<script runat="server">
    void PopulateNode(Object sender, TreeNodeEventArgs e) {
        // Call the appropriate method to populate a node at a particular level.
        switch (e.Node.Depth) {
            case 0:
                // Populate the first-level nodes.
                PopulateCategories(e.Node);
                break;
            case 1:
                // Populate the second-level nodes.
                PopulateProducts(e.Node);
                break;
            default:
                // Do nothing.
                break;
        }

    }
    void PopulateCategories(TreeNode node) {

        // Query for the product categories. These are the values
        // for the second-level nodes.
        DataSet ResultSet = RunQuery("Select CategoryID, CategoryName From Categories");
        // Create the second-level nodes.
        if (ResultSet.Tables.Count > 0) {

            // Iterate through and create a new node for each row in the query results.
            // Notice that the query results are stored in the table of the DataSet.
            foreach (DataRow row in ResultSet.Tables[0].Rows) {

                // Create the new node. Notice that the CategoryId is stored in the Value property
                // of the node. This will make querying for items in a specific category easier when
                // the third-level nodes are created.
                TreeNode newNode = new TreeNode();
                newNode.Text = row["CategoryName"].ToString();
                newNode.Value = row["CategoryID"].ToString();
                // Set the PopulateOnDemand property to true so that the child nodes can be
                // dynamically populated.
                newNode.PopulateOnDemand = true;

                // Set additional properties for the node.
                newNode.SelectAction = TreeNodeSelectAction.Expand;

                // Add the new node to the ChildNodes collection of the parent node.
                node.ChildNodes.Add(newNode);

            }

        }

    }
    void PopulateProducts(TreeNode node) {
        // Query for the products of the current category. These are the values
        // for the third-level nodes.
        DataSet ResultSet = RunQuery("Select ProductName From Products Where CategoryID=" + node.Value);
        // Create the third-level nodes.
        if (ResultSet.Tables.Count > 0) {

            // Iterate through and create a new node for each row in the query results.
            // Notice that the query results are stored in the table of the DataSet.
            foreach (DataRow row in ResultSet.Tables[0].Rows) {

                // Create the new node.
                TreeNode NewNode = new TreeNode(row["ProductName"].ToString());

                // Set the PopulateOnDemand property to false, because these are leaf nodes and
                // do not need to be populated.
                NewNode.PopulateOnDemand = false;

                // Set additional properties for the node.
                NewNode.SelectAction = TreeNodeSelectAction.None;

                // Add the new node to the ChildNodes collection of the parent node.
                node.ChildNodes.Add(NewNode);

            }

        }
    }
    DataSet RunQuery(String QueryString) {
        // Declare the connection string. This example uses Microsoft SQL Server
        // and connects to the Northwind sample database.
        String ConnectionString = "server=localhost;database=NorthWind;Integrated Security=SSPI";
        SqlConnection DBConnection = new SqlConnection(ConnectionString);
        SqlDataAdapter DBAdapter;
        DataSet ResultsDataSet = new DataSet();
        try {
            // Run the query and create a DataSet.
            DBAdapter = new SqlDataAdapter(QueryString, DBConnection);
            DBAdapter.Fill(ResultsDataSet);
            // Close the database connection.
            DBConnection.Close();
        } catch (Exception ex) {
            // Close the database connection if it is still open.
            if (DBConnection.State == ConnectionState.Open) {
                DBConnection.Close();
            }

            Message.Text = "Unable to connect to the database.";
        }
        return ResultsDataSet;
    }
</script>

<html>
<body>
    <form id="Form1" runat="server">
        <h3>
            TreeView PopulateNodesFromClient Example</h3>
        <asp:TreeView ID="LinksTreeView" 
          Font-Name="Arial" ForeColor="Blue" EnableClientScript="true"
          PopulateNodesFromClient="false" 
          OnTreeNodePopulate="PopulateNode" runat="server"
            ExpandDepth="0">
            <Nodes>
                <asp:TreeNode Text="Inventory" SelectAction="Expand"
                              PopulateOnDemand="True" Value="Inventory" />
            </Nodes>
        </asp:TreeView>
        <br>
        <br>
        <asp:Label ID="Message" runat="server" />
    </form>
</body>
</html>