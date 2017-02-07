Private Sub BindUserAccounts()
 Dim totalRecords As Integer
 UserAccounts.DataSource = Membership.FindUsersByName(Me.UsernameToMatch + "%", Me.PageIndex, Me.PageSize, totalRecords)
 UserAccounts.DataBind()

 ' Enable/disable the paging interface
 Dim visitingFirstPage As Boolean = (Me.PageIndex = 0)
 lnkFirst.Enabled = Not visitingFirstPage
 lnkPrev.Enabled = Not visitingFirstPage

 Dim lastPageIndex As Integer = (totalRecords - 1) / Me.PageSize
 Dim visitingLastPage As Boolean = (Me.PageIndex >= lastPageIndex)
 lnkNext.Enabled = Not visitingLastPage
 lnkLast.Enabled = Not visitingLastPage
End Sub