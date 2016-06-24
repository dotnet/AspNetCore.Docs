

TemplatePart Class
==================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Routing.Template`
Assemblies
    * Microsoft.AspNetCore.Routing

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Routing.Template.TemplatePart`








Syntax
------

.. code-block:: csharp

    [DebuggerDisplay("{DebuggerToString()}")]
    public class TemplatePart








.. dn:class:: Microsoft.AspNetCore.Routing.Template.TemplatePart
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.Template.TemplatePart

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Routing.Template.TemplatePart
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.Template.TemplatePart.CreateLiteral(System.String)
    
        
    
        
        :type text: System.String
        :rtype: Microsoft.AspNetCore.Routing.Template.TemplatePart
    
        
        .. code-block:: csharp
    
            public static TemplatePart CreateLiteral(string text)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.Template.TemplatePart.CreateParameter(System.String, System.Boolean, System.Boolean, System.Object, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Routing.Template.InlineConstraint>)
    
        
    
        
        :type name: System.String
    
        
        :type isCatchAll: System.Boolean
    
        
        :type isOptional: System.Boolean
    
        
        :type defaultValue: System.Object
    
        
        :type inlineConstraints: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Routing.Template.InlineConstraint<Microsoft.AspNetCore.Routing.Template.InlineConstraint>}
        :rtype: Microsoft.AspNetCore.Routing.Template.TemplatePart
    
        
        .. code-block:: csharp
    
            public static TemplatePart CreateParameter(string name, bool isCatchAll, bool isOptional, object defaultValue, IEnumerable<InlineConstraint> inlineConstraints)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Routing.Template.TemplatePart
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.Template.TemplatePart.DefaultValue
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object DefaultValue { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Template.TemplatePart.InlineConstraints
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Routing.Template.InlineConstraint<Microsoft.AspNetCore.Routing.Template.InlineConstraint>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<InlineConstraint> InlineConstraints { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Template.TemplatePart.IsCatchAll
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsCatchAll { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Template.TemplatePart.IsLiteral
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsLiteral { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Template.TemplatePart.IsOptional
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsOptional { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Template.TemplatePart.IsOptionalSeperator
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsOptionalSeperator { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Template.TemplatePart.IsParameter
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsParameter { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Template.TemplatePart.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Template.TemplatePart.Text
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Text { get; }
    

