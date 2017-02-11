<HttpPost()>
 Public Function SearchIndex(ByVal fc As FormCollection, ByVal searchString As String) As String
     Return "<h3> From [HttpPost]SearchIndex: " & searchString & "</h3>"
 End Function