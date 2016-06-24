

TagHelperAttributeDescriptor Class
==================================






A metadata class describing a tag helper attribute.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor`








Syntax
------

.. code-block:: csharp

    public class TagHelperAttributeDescriptor








.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor.TagHelperAttributeDescriptor()
    
        
    
        
        Instantiates a new instance of the :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor` class.
    
        
    
        
        .. code-block:: csharp
    
            public TagHelperAttributeDescriptor()
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor.DesignTimeDescriptor
    
        
    
        
        The :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDesignTimeDescriptor` that contains design time information about
        this attribute.
    
        
        :rtype: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDesignTimeDescriptor
    
        
        .. code-block:: csharp
    
            public TagHelperAttributeDesignTimeDescriptor DesignTimeDescriptor { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor.IsEnum
    
        
    
        
        Gets or sets an indication whether this property is an :any:`System.Enum`\.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsEnum { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor.IsIndexer
    
        
    
        
        Gets an indication whether this :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor` is used for dictionary indexer
        assignments.
    
        
        :rtype: System.Boolean
        :return: 
            If <code>true</code> this :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor` should be associated with all HTML
            attributes that have names starting with :dn:prop:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor.Name`\. Otherwise this 
            :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor` is used for property assignment and is only associated with an
            HTML attribute that has the exact :dn:prop:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor.Name`\.
    
        
        .. code-block:: csharp
    
            public bool IsIndexer { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor.IsStringProperty
    
        
    
        
        Gets or sets an indication whether this property is of type :any:`System.String` or, if 
        :dn:prop:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor.IsIndexer` is <code>true</code>, whether the indexer's value is of type :any:`System.String`\.
    
        
        :rtype: System.Boolean
        :return: 
            If <code>true</code> the :dn:prop:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor.TypeName` is for :any:`System.String`\. This causes the Razor parser
            to allow empty values for HTML attributes matching this :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor`\. If
            <code>false</code> empty values for such matching attributes lead to errors.
    
        
        .. code-block:: csharp
    
            public bool IsStringProperty { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor.Name
    
        
    
        
        The HTML attribute name or, if :dn:prop:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor.IsIndexer` is <code>true</code>, the prefix for matching attribute
        names.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor.PropertyName
    
        
    
        
        The name of the CLR property that corresponds to the HTML attribute.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string PropertyName { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor.TypeName
    
        
    
        
        The full name of the named (see <see name="PropertyName"></see>) property's :any:`System.Type` or, if 
        :dn:prop:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor.IsIndexer` is <code>true</code>, the full name of the indexer's value :any:`System.Type`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string TypeName { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor.IsNameMatch(System.String)
    
        
    
        
        Determines whether HTML attribute <em>name</em> matches this 
        :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor`\.
    
        
    
        
        :param name: Name of the HTML attribute to check.
        
        :type name: System.String
        :rtype: System.Boolean
        :return: 
            <code>true</code> if this :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor` matches <em>name</em>.
            <code>false</code> otherwise.
    
        
        .. code-block:: csharp
    
            public bool IsNameMatch(string name)
    

