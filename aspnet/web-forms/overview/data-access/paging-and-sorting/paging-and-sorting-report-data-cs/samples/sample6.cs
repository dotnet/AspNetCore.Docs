// Clear out all of the items in the DropDownList
PageList.Items.Clear();
// Add a ListItem for each page
for (int i = 0; i < Products.PageCount; i++)
{
    // Add the new ListItem
    ListItem pageListItem = new ListItem(string.Concat("Page ", i + 1), i.ToString());
    PageList.Items.Add(pageListItem);
    // select the current item, if needed
    if (i == Products.PageIndex)
        pageListItem.Selected = true;
}