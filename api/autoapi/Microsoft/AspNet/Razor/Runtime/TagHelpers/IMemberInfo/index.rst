

IMemberInfo Interface
=====================



.. contents:: 
   :local:



Summary
-------

Metadata common to types and properties.











Syntax
------

.. code-block:: csharp

   public interface IMemberInfo





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor.Runtime/Runtime/TagHelpers/IMemberInfo.cs>`_





.. dn:interface:: Microsoft.AspNet.Razor.Runtime.TagHelpers.IMemberInfo

Methods
-------

.. dn:interface:: Microsoft.AspNet.Razor.Runtime.TagHelpers.IMemberInfo
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.TagHelpers.IMemberInfo.GetCustomAttributes<TAttribute>()
    
        
    
        Retrieves a collection of custom :any:`System.Attribute`\s of type ``TAttribute`` applied
        to this instance of :any:`Microsoft.AspNet.Razor.Runtime.TagHelpers.IMemberInfo`\.
    
        
        :rtype: System.Collections.Generic.IEnumerable{{TAttribute}}
        :return: A sequence of custom <see cref="T:System.Attribute" />s of type
            <typeparamref name="TAttribute" />.
    
        
        .. code-block:: csharp
    
           IEnumerable<TAttribute> GetCustomAttributes<TAttribute>()where TAttribute : Attribute
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Razor.Runtime.TagHelpers.IMemberInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.TagHelpers.IMemberInfo.Name
    
        
    
        Gets the name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string Name { get; }
    

