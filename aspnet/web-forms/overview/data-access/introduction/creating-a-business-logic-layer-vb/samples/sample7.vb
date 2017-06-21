Dim productLogic As New ProductsBLL()

Try
    productLogic.UpdateProduct("Scotts Tea", 1, 1, Nothing, _
      -14, 10, Nothing, Nothing, False, 1)
Catch ae As ArgumentException
    Response.Write("There was a problem: " & ae.Message)
End Try