Public Class LocalhostConstraint
    Implements IRouteConstraint
    Public Function Match( _
                ByVal httpContext As HttpContextBase, _
                ByVal route As Route, _
                ByVal parameterName As String, _
                ByVal values As RouteValueDictionary, _
                ByVal routeDirection As RouteDirection _
            ) As Boolean Implements IRouteConstraint.Match
        Return httpContext.Request.IsLocal
    End Function
End Class