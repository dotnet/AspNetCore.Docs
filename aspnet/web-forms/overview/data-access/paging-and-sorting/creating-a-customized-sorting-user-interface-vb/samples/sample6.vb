Dim currentValue As String = String.Empty
If gvr.Cells(sortColumnIndex).Controls.Count > 0 Then
    If TypeOf gvr.Cells(sortColumnIndex).Controls(0) Is CheckBox Then
        If CType(gvr.Cells(sortColumnIndex).Controls(0), CheckBox).Checked Then
            currentValue = "Yes"
        Else
            currentValue = "No"
        End If
        ' ... Add other checks here if using columns with other
        '      Web controls in them (Calendars, DropDownLists, etc.) ...
    End If
Else
    currentValue = gvr.Cells(sortColumnIndex).Text
End If