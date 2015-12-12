

TagHelperAttribute Class
========================



.. contents:: 
   :local:



Summary
-------

An HTML tag helper attribute.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute`








Syntax
------

.. code-block:: csharp

   public class TagHelperAttribute : IReadOnlyTagHelperAttribute, IEquatable<IReadOnlyTagHelperAttribute>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor.Runtime/TagHelpers/TagHelperAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute.TagHelperAttribute()
    
        
    
        Instantiates a new instance of :any:`Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute`\.
    
        
    
        
        .. code-block:: csharp
    
           public TagHelperAttribute()
    
    .. dn:constructor:: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute.TagHelperAttribute(Microsoft.AspNet.Razor.TagHelpers.IReadOnlyTagHelperAttribute)
    
        
    
        Instantiates a new instance of :any:`Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute` with values provided by the given
        ``attribute``.
    
        
        
        
        :param attribute: A  whose values should be copied.
        
        :type attribute: Microsoft.AspNet.Razor.TagHelpers.IReadOnlyTagHelperAttribute
    
        
        .. code-block:: csharp
    
           public TagHelperAttribute(IReadOnlyTagHelperAttribute attribute)
    
    .. dn:constructor:: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute.TagHelperAttribute(System.String, System.Object)
    
        
    
        Instantiates a new instance of :any:`Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute` with the specified ``name``
        and ``value``.
    
        
        
        
        :param name: The  of the attribute.
        
        :type name: System.String
        
        
        :param value: The  of the attribute.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           public TagHelperAttribute(string name, object value)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute.Equals(Microsoft.AspNet.Razor.TagHelpers.IReadOnlyTagHelperAttribute)
    
        
        
        
        :type other: Microsoft.AspNet.Razor.TagHelpers.IReadOnlyTagHelperAttribute
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Equals(IReadOnlyTagHelperAttribute other)
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute.Minimized
    
        
    
        Gets or sets an indication whether the attribute is minimized or not.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Minimized { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute.Name
    
        
    
        Gets or sets the name of the attribute.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute.Value
    
        
    
        Gets or sets the value of the attribute.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object Value { get; set; }
    

