

TagHelperAttributeDescriptor Class
==================================



.. contents:: 
   :local:



Summary
-------

A metadata class describing a tag helper attribute.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor`








Syntax
------

.. code-block:: csharp

   public class TagHelperAttributeDescriptor





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Compilation/TagHelpers/TagHelperAttributeDescriptor.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor.TagHelperAttributeDescriptor()
    
        
    
        Instantiates a new instance of the :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor` class.
    
        
    
        
        .. code-block:: csharp
    
           public TagHelperAttributeDescriptor()
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor.IsNameMatch(System.String)
    
        
    
        Determines whether HTML attribute ``name`` matches this 
        :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor`\.
    
        
        
        
        :param name: Name of the HTML attribute to check.
        
        :type name: System.String
        :rtype: System.Boolean
        :return: <c>true</c> if this <see cref="T:Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor" /> matches <paramref name="name" />.
            <c>false</c> otherwise.
    
        
        .. code-block:: csharp
    
           public bool IsNameMatch(string name)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor.DesignTimeDescriptor
    
        
    
        The :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperAttributeDesignTimeDescriptor` that contains design time information about
        this attribute.
    
        
        :rtype: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperAttributeDesignTimeDescriptor
    
        
        .. code-block:: csharp
    
           public TagHelperAttributeDesignTimeDescriptor DesignTimeDescriptor { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor.IsIndexer
    
        
    
        Gets an indication whether this :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor` is used for dictionary indexer
        assignments.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsIndexer { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor.IsStringProperty
    
        
    
        Gets or sets an indication whether this property is of type :any:`System.String` or, if 
        :dn:prop:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor.IsIndexer` is <c>true</c>, whether the indexer's value is of type :any:`System.String`\.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsStringProperty { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor.Name
    
        
    
        The HTML attribute name or, if :dn:prop:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor.IsIndexer` is <c>true</c>, the prefix for matching attribute
        names.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor.PropertyName
    
        
    
        The name of the CLR property that corresponds to the HTML attribute.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string PropertyName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor.TypeName
    
        
    
        The full name of the named (see <see name="PropertyName" />) property's :any:`System.Type` or, if 
        :dn:prop:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor.IsIndexer` is <c>true</c>, the full name of the indexer's value :any:`System.Type`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string TypeName { get; set; }
    

