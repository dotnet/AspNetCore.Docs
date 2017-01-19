int? categoryIDValue = null;
if (!string.IsNullOrEmpty(categories.SelectedValue))
    categoryIDValue = Convert.ToInt32(categories.SelectedValue);
int? supplierIDValue = null;
if (!string.IsNullOrEmpty(suppliers.SelectedValue))
    supplierIDValue = Convert.ToInt32(suppliers.SelectedValue);