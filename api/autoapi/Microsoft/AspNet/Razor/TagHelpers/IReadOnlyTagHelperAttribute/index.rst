

IReadOnlyTagHelperAttribute Interface
=====================================



.. contents:: 
   :local:



Summary
-------

A read-only HTML tag helper attribute.











Syntax
------

.. code-block:: csharp

   public interface IReadOnlyTagHelperAttribute : IEquatable<IReadOnlyTagHelperAttribute>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor.Runtime/TagHelpers/IReadOnlyTagHelperAttribute.cs>`_





.. dn:interface:: Microsoft.AspNet.Razor.TagHelpers.IReadOnlyTagHelperAttribute

Properties
----------

.. dn:interface:: Microsoft.AspNet.Razor.TagHelpers.IReadOnlyTagHelperAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.IReadOnlyTagHelperAttribute.Minimized
    
        
    
        Gets an indication whether the attribute is minimized or not.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool Minimized { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.IReadOnlyTagHelperAttribute.Name
    
        
    
        Gets the name of the attribute.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string Name { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.IReadOnlyTagHelperAttribute.Value
    
        
    
        Gets the value of the attribute.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           object Value { get; }
    

