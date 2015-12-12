

TemplatePart Class
==================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Routing.Template.TemplatePart`








Syntax
------

.. code-block:: csharp

   public class TemplatePart





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/routing/src/Microsoft.AspNet.Routing/Template/TemplatePart.cs>`_





.. dn:class:: Microsoft.AspNet.Routing.Template.TemplatePart

Methods
-------

.. dn:class:: Microsoft.AspNet.Routing.Template.TemplatePart
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Routing.Template.TemplatePart.CreateLiteral(System.String)
    
        
        
        
        :type text: System.String
        :rtype: Microsoft.AspNet.Routing.Template.TemplatePart
    
        
        .. code-block:: csharp
    
           public static TemplatePart CreateLiteral(string text)
    
    .. dn:method:: Microsoft.AspNet.Routing.Template.TemplatePart.CreateParameter(System.String, System.Boolean, System.Boolean, System.Object, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Routing.Template.InlineConstraint>)
    
        
        
        
        :type name: System.String
        
        
        :type isCatchAll: System.Boolean
        
        
        :type isOptional: System.Boolean
        
        
        :type defaultValue: System.Object
        
        
        :type inlineConstraints: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Routing.Template.InlineConstraint}
        :rtype: Microsoft.AspNet.Routing.Template.TemplatePart
    
        
        .. code-block:: csharp
    
           public static TemplatePart CreateParameter(string name, bool isCatchAll, bool isOptional, object defaultValue, IEnumerable<InlineConstraint> inlineConstraints)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Routing.Template.TemplatePart
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Routing.Template.TemplatePart.DefaultValue
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object DefaultValue { get; }
    
    .. dn:property:: Microsoft.AspNet.Routing.Template.TemplatePart.InlineConstraints
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Routing.Template.InlineConstraint}
    
        
        .. code-block:: csharp
    
           public IEnumerable<InlineConstraint> InlineConstraints { get; }
    
    .. dn:property:: Microsoft.AspNet.Routing.Template.TemplatePart.IsCatchAll
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsCatchAll { get; }
    
    .. dn:property:: Microsoft.AspNet.Routing.Template.TemplatePart.IsLiteral
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsLiteral { get; }
    
    .. dn:property:: Microsoft.AspNet.Routing.Template.TemplatePart.IsOptional
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsOptional { get; }
    
    .. dn:property:: Microsoft.AspNet.Routing.Template.TemplatePart.IsOptionalSeperator
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsOptionalSeperator { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Routing.Template.TemplatePart.IsParameter
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsParameter { get; }
    
    .. dn:property:: Microsoft.AspNet.Routing.Template.TemplatePart.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name { get; }
    
    .. dn:property:: Microsoft.AspNet.Routing.Template.TemplatePart.Text
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Text { get; }
    

