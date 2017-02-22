@Code
    Dim myScores = New Dictionary(Of String, Integer)()
    myScores.Add("test1", 71)
    myScores.Add("test2", 82)
    myScores.Add("test3", 100)
    myScores.Add("test4", 59)
End Code
<p>My score on test 3 is: @myScores("test3")%</p>
@Code 
    myScores("test4") = 79
End Code
<p>My corrected score on test 4 is: @myScores("test4")%</p>