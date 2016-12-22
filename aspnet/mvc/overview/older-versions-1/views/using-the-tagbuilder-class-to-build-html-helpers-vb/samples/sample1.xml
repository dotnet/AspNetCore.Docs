Public Module ImageHelper

<System.Runtime.CompilerServices.Extension> _
Function Image(ByVal helper As HtmlHelper, ByVal id As String, ByVal url As String, ByVal alternateText As String) As String
	Return Image(helper, id, url, alternateText, Nothing)
End Function

<System.Runtime.CompilerServices.Extension> _
Function Image(ByVal helper As HtmlHelper, ByVal id As String, ByVal url As String, ByVal alternateText As String, ByVal htmlAttributes As Object) As String
	' Create tag builder
	Dim builder = New TagBuilder("img")

	' Create valid id
	builder.GenerateId(id)

	' Add attributes
	builder.MergeAttribute("src", url)
	builder.MergeAttribute("alt", alternateText)
	builder.MergeAttributes(New RouteValueDictionary(htmlAttributes))

	' Render tag
	Return builder.ToString(TagRenderMode.SelfClosing)
End Function

End Module