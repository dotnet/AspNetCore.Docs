

Microsoft.AspNetCore.Routing.Constraints Namespace
==================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Routing/Constraints/AlphaRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/Constraints/BoolRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/Constraints/CompositeRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/Constraints/DateTimeRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/Constraints/DecimalRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/Constraints/DoubleRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/Constraints/FloatRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/Constraints/GuidRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/Constraints/HttpMethodRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/Constraints/IntRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/Constraints/LengthRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/Constraints/LongRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/Constraints/MaxLengthRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/Constraints/MaxRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/Constraints/MinLengthRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/Constraints/MinRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/Constraints/OptionalRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/Constraints/RangeRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/Constraints/RegexInlineRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/Constraints/RegexRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/Constraints/RequiredRouteConstraint/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Routing.Constraints


    .. rubric:: Classes


    class :dn:cls:`AlphaRouteConstraint`
        .. object: type=class name=Microsoft.AspNetCore.Routing.Constraints.AlphaRouteConstraint

        
        Constrains a route parameter to contain only lowercase or uppercase letters A through Z in the English alphabet.


    class :dn:cls:`BoolRouteConstraint`
        .. object: type=class name=Microsoft.AspNetCore.Routing.Constraints.BoolRouteConstraint

        
        Constrains a route parameter to represent only Boolean values.


    class :dn:cls:`CompositeRouteConstraint`
        .. object: type=class name=Microsoft.AspNetCore.Routing.Constraints.CompositeRouteConstraint

        
        Constrains a route by several child constraints.


    class :dn:cls:`DateTimeRouteConstraint`
        .. object: type=class name=Microsoft.AspNetCore.Routing.Constraints.DateTimeRouteConstraint

        
        Constrains a route parameter to represent only :any:`System.DateTime` values.


    class :dn:cls:`DecimalRouteConstraint`
        .. object: type=class name=Microsoft.AspNetCore.Routing.Constraints.DecimalRouteConstraint

        
        Constrains a route parameter to represent only decimal values.


    class :dn:cls:`DoubleRouteConstraint`
        .. object: type=class name=Microsoft.AspNetCore.Routing.Constraints.DoubleRouteConstraint

        
        Constrains a route parameter to represent only 64-bit floating-point values.


    class :dn:cls:`FloatRouteConstraint`
        .. object: type=class name=Microsoft.AspNetCore.Routing.Constraints.FloatRouteConstraint

        
        Constrains a route parameter to represent only 32-bit floating-point values.


    class :dn:cls:`GuidRouteConstraint`
        .. object: type=class name=Microsoft.AspNetCore.Routing.Constraints.GuidRouteConstraint

        
        Constrains a route parameter to represent only :any:`System.Guid` values.
        Matches values specified in any of the five formats "N", "D", "B", "P", or "X",
        supported by Guid.ToString(string) and Guid.ToString(String, IFormatProvider) methods.


    class :dn:cls:`HttpMethodRouteConstraint`
        .. object: type=class name=Microsoft.AspNetCore.Routing.Constraints.HttpMethodRouteConstraint

        
        Constrains the HTTP method of request or a route.


    class :dn:cls:`IntRouteConstraint`
        .. object: type=class name=Microsoft.AspNetCore.Routing.Constraints.IntRouteConstraint

        
        Constrains a route parameter to represent only 32-bit integer values.


    class :dn:cls:`LengthRouteConstraint`
        .. object: type=class name=Microsoft.AspNetCore.Routing.Constraints.LengthRouteConstraint

        
        Constrains a route parameter to be a string of a given length or within a given range of lengths.


    class :dn:cls:`LongRouteConstraint`
        .. object: type=class name=Microsoft.AspNetCore.Routing.Constraints.LongRouteConstraint

        
        Constrains a route parameter to represent only 64-bit integer values.


    class :dn:cls:`MaxLengthRouteConstraint`
        .. object: type=class name=Microsoft.AspNetCore.Routing.Constraints.MaxLengthRouteConstraint

        
        Constrains a route parameter to be a string with a maximum length.


    class :dn:cls:`MaxRouteConstraint`
        .. object: type=class name=Microsoft.AspNetCore.Routing.Constraints.MaxRouteConstraint

        
        Constrains a route parameter to be an integer with a maximum value.


    class :dn:cls:`MinLengthRouteConstraint`
        .. object: type=class name=Microsoft.AspNetCore.Routing.Constraints.MinLengthRouteConstraint

        
        Constrains a route parameter to be a string with a minimum length.


    class :dn:cls:`MinRouteConstraint`
        .. object: type=class name=Microsoft.AspNetCore.Routing.Constraints.MinRouteConstraint

        
        Constrains a route parameter to be a long with a minimum value.


    class :dn:cls:`OptionalRouteConstraint`
        .. object: type=class name=Microsoft.AspNetCore.Routing.Constraints.OptionalRouteConstraint

        
        Defines a constraint on an optional parameter. If the parameter is present, then it is constrained by InnerConstraint. 


    class :dn:cls:`RangeRouteConstraint`
        .. object: type=class name=Microsoft.AspNetCore.Routing.Constraints.RangeRouteConstraint

        
        Constraints a route parameter to be an integer within a given range of values.


    class :dn:cls:`RegexInlineRouteConstraint`
        .. object: type=class name=Microsoft.AspNetCore.Routing.Constraints.RegexInlineRouteConstraint

        
        Represents a regex constraint which can be used as an inlineConstraint.


    class :dn:cls:`RegexRouteConstraint`
        .. object: type=class name=Microsoft.AspNetCore.Routing.Constraints.RegexRouteConstraint

        


    class :dn:cls:`RequiredRouteConstraint`
        .. object: type=class name=Microsoft.AspNetCore.Routing.Constraints.RequiredRouteConstraint

        
        Constraints a route parameter that must have a value.


