@Code
    Dim dataFilePath = "~/dataFile.txt"
    Dim fileContents = ""
    Dim physicalPath = Server.MapPath(dataFilePath)
    Dim userMessage = "Hello world, the time is " + DateTime.Now
    Dim userErrMsg = ""
    Dim errMsg = ""
    
    If IsPost Then
        ' When the user clicks the "Open File" button and posts
        ' the page, try to open the file.
        Try
            ' This code fails because of faulty path to the file.
            fileContents = File.ReadAllText("c:\batafile.txt")
            
            ' This code works. To eliminate error on page, 
            ' comment the above line of code and uncomment this one.
            ' fileContents = File.ReadAllText(physicalPath)
            
        Catch ex As FileNotFoundException
            ' You can use the exception object for debugging, logging, etc.
            errMsg = ex.Message
            ' Create a friendly error message for users.
            userErrMsg = "The file could not be opened, please contact " _
                & "your system administrator."
                
        Catch ex As DirectoryNotFoundException
            ' Similar to previous exception.
            errMsg = ex.Message
            userErrMsg = "The file could not be opened, please contact " _
                & "your system administrator."
        End Try
    Else
        ' The first time the page is requested, create the text file.
        File.WriteAllText(physicalPath, userMessage)
    End If
End Code
<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="utf-8" />
        <title>Try-Catch Statements</title>
    </head>
    <body>  
    <form method="POST" action="" >
      <input type="Submit" name="Submit" value="Open File"/>
    </form>
    
    <p>@fileContents</p>
    <p>@userErrMsg</p>
    
    </body>
</html>