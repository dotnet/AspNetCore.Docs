public partial class Northwind
{
    public partial class ProductsDataTable
    {
        public override void BeginInit()
         {
            this.ColumnChanging += ValidateColumn;
         }

         void ValidateColumn(object sender,
           DataColumnChangeEventArgs e)
         {
            if(e.Column.Equals(this.UnitPriceColumn))
            {
               if(!Convert.IsDBNull(e.ProposedValue) &&
                  (decimal)e.ProposedValue < 0)
               {
                  throw new ArgumentException(
                      "UnitPrice cannot be less than zero", "UnitPrice");
               }
            }
            else if (e.Column.Equals(this.UnitsInStockColumn) ||
                     e.Column.Equals(this.UnitsOnOrderColumn) ||
                     e.Column.Equals(this.ReorderLevelColumn))
            {
                if (!Convert.IsDBNull(e.ProposedValue) &&
                    (short)e.ProposedValue < 0)
                {
                    throw new ArgumentException(string.Format(
                        "{0} cannot be less than zero", e.Column.ColumnName),
                        e.Column.ColumnName);
                }
            }
         }
    }
}