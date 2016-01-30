

Microsoft.AspNet.Routing.Constraints Namespace
==============================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNet/Routing/Constraints/AlphaRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNet/Routing/Constraints/BoolRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNet/Routing/Constraints/DateTimeRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNet/Routing/Constraints/DecimalRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNet/Routing/Constraints/DoubleRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNet/Routing/Constraints/FloatRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNet/Routing/Constraints/GuidRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNet/Routing/Constraints/IntRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNet/Routing/Constraints/LengthRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNet/Routing/Constraints/LongRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNet/Routing/Constraints/MaxLengthRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNet/Routing/Constraints/MaxRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNet/Routing/Constraints/MinLengthRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNet/Routing/Constraints/MinRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNet/Routing/Constraints/OptionalRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNet/Routing/Constraints/RangeRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNet/Routing/Constraints/RegexInlineRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNet/Routing/Constraints/RegexRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNet/Routing/Constraints/RequiredRouteConstraint/index
   
   











.. dn:namespace:: Microsoft.AspNet.Routing.Constraints


    .. rubric:: Classes


    class :dn:cls:`Microsoft.AspNet.Routing.Constraints.AlphaRouteConstraint`
        Constrains a route parameter to contain only lowercase or uppercase letters A through Z in the English alphabet.


    class :dn:cls:`Microsoft.AspNet.Routing.Constraints.BoolRouteConstraint`
        Constrains a route parameter to represent only Boolean values.


    class :dn:cls:`Microsoft.AspNet.Routing.Constraints.DateTimeRouteConstraint`
        Constrains a route parameter to represent only :any:`System.DateTime` values.


    class :dn:cls:`Microsoft.AspNet.Routing.Constraints.DecimalRouteConstraint`
        Constrains a route parameter to represent only decimal values.


    class :dn:cls:`Microsoft.AspNet.Routing.Constraints.DoubleRouteConstraint`
        Constrains a route parameter to represent only 64-bit floating-point values.


    class :dn:cls:`Microsoft.AspNet.Routing.Constraints.FloatRouteConstraint`
        Constrains a route parameter to represent only 32-bit floating-point values.


    class :dn:cls:`Microsoft.AspNet.Routing.Constraints.GuidRouteConstraint`
        Constrains a route parameter to represent only :any:`System.Guid` values.
        Matches values specified in any of the five formats "N", "D", "B", "P", or "X",
        supported by Guid.ToString(string) and Guid.ToString(String, IFormatProvider) methods.


    class :dn:cls:`Microsoft.AspNet.Routing.Constraints.IntRouteConstraint`
        Constrains a route parameter to represent only 32-bit integer values.


    class :dn:cls:`Microsoft.AspNet.Routing.Constraints.LengthRouteConstraint`
        Constrains a route parameter to be a string of a given length or within a given range of lengths.


    class :dn:cls:`Microsoft.AspNet.Routing.Constraints.LongRouteConstraint`
        Constrains a route parameter to represent only 64-bit integer values.


    class :dn:cls:`Microsoft.AspNet.Routing.Constraints.MaxLengthRouteConstraint`
        Constrains a route parameter to be a string with a maximum length.


    class :dn:cls:`Microsoft.AspNet.Routing.Constraints.MaxRouteConstraint`
        Constrains a route parameter to be an integer with a maximum value.


    class :dn:cls:`Microsoft.AspNet.Routing.Constraints.MinLengthRouteConstraint`
        Constrains a route parameter to be a string with a minimum length.


    class :dn:cls:`Microsoft.AspNet.Routing.Constraints.MinRouteConstraint`
        Constrains a route parameter to be a long with a minimum value.


    class :dn:cls:`Microsoft.AspNet.Routing.Constraints.OptionalRouteConstraint`
        Defines a constraint on an optional parameter. If the parameter is present, then it is constrained by InnerConstraint.


    class :dn:cls:`Microsoft.AspNet.Routing.Constraints.RangeRouteConstraint`
        Constraints a route parameter to be an integer within a given range of values.


    class :dn:cls:`Microsoft.AspNet.Routing.Constraints.RegexInlineRouteConstraint`
        Represents a regex constraint which can be used as an inlineConstraint.


    class :dn:cls:`Microsoft.AspNet.Routing.Constraints.RegexRouteConstraint`
        


    class :dn:cls:`Microsoft.AspNet.Routing.Constraints.RequiredRouteConstraint`
        Constraints a route parameter that must have a value.


