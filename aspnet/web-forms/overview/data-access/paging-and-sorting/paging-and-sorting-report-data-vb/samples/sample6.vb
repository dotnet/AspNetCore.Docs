' Clear out all of the items in the DropDownList
PageList.Items.Clear()
' Add a ListItem for each page
For i As Integer = 0 To Products.PageCount - 1
    ' Add the new ListItem
    Dim pageListItem As New ListItem(String.Concat("Page ", i + 1), i.ToString())
    PageList.Items.Add(pageListItem)
    ' select the current item, if needed
    If i = Products.PageIndex Then
        pageListItem.Selected = True
    End If
Next