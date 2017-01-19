Public Module MenuItemHelper

   <System.Runtime.CompilerServices.Extension> _
   Function MenuItem(ByVal helper As HtmlHelper, ByVal linkText As String, ByVal actionName As String, ByVal controllerName As String) As String
		Dim currentControllerName As String = helper.ViewContext.RouteData.Values("controller")
		Dim currentActionName As String = helper.ViewContext.RouteData.Values("action")

		Dim builder = New TagBuilder("li")

		' Add selected class
		If currentControllerName.Equals(controllerName, StringComparison.CurrentCultureIgnoreCase) AndAlso currentActionName.Equals(actionName, StringComparison.CurrentCultureIgnoreCase) Then
			builder.AddCssClass("selected")
		End If

		' Add link
		builder.InnerHtml = helper.ActionLink(linkText, actionName, controllerName)

		' Render Tag Builder
		Return builder.ToString(TagRenderMode.Normal)
   End Function

End Module