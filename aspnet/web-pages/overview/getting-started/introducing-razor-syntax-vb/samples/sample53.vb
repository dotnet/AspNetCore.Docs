@Code
    Dim teamMembers() As String = {"Matt", "Joanne", "Robert", "Nancy"}
    @<p>The number of names in the teamMembers array: @teamMembers.Length </p>
    @<p>Robert is now in position: @Array.IndexOf(teamMembers, "Robert")</p>
    @<p>The array item at position 2 (zero-based) is @teamMembers(2)</p>
    @<h3>Current order of team members in the list</h3>
    For Each name In teamMembers
        @<p>@name</p>
    Next name
    @<h3>Reversed order of team members in the list</h3>
    Array.Reverse(teamMembers)
    For Each reversedItem In teamMembers
        @<p>@reversedItem</p>
    Next reversedItem
End Code