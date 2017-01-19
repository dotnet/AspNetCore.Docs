@Code
    ' Embedding the value of a variable into HTML markup.
    ' Precede the markup with @ because we are in a code block.
    @<p>@greeting, friends!</p>
End Code

<!-- Using a variable with an inline expression in HTML. --> 
<p>The predicted annual total is: @( monthlyTotal * 12)</p>

<!--  Displaying the page URL with a variable. --> 
<p>The URL to this page is:  @myPath</p>