ProductsBLL productLogic = new ProductsBLL();

// Update information for ProductID 1
try
{
    // This will fail since we are attempting to use a
    // UnitPrice value less than 0.
    productLogic.UpdateProduct(
        "Scott s Tea", 1, 1, null, -14m, 10, null, null, false, 1);
}
catch (ArgumentException ae)
{
    Response.Write("There was a problem: " + ae.Message);
}