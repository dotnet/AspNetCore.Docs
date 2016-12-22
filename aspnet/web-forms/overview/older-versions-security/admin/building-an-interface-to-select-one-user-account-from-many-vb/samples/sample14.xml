Protected Sub lnkFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkFirst.Click
 Me.PageIndex = 0
 BindUserAccounts()
End Sub

Protected Sub lnkPrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkPrev.Click
 Me.PageIndex -= 1
 BindUserAccounts()
End Sub

Protected Sub lnkNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkNext.Click
 Me.PageIndex += 1
 BindUserAccounts()
End Sub

Protected Sub lnkLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkLast.Click
 ' Determine the total number of records
 Dim totalRecords As Integer
 Membership.FindUsersByName(Me.UsernameToMatch + "%", Me.PageIndex, Me.PageSize, totalRecords)
 ' Navigate to the last page index
 Me.PageIndex = (totalRecords - 1) / Me.PageSize
 BindUserAccounts()
End Sub