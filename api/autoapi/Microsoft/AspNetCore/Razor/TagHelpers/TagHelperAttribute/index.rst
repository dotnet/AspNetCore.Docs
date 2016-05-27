

TagHelperAttribute Class
========================






An HTML tag helper attribute.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.TagHelpers`
Assemblies
    * Microsoft.AspNetCore.Razor.Runtime

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute`








Syntax
------

.. code-block:: csharp

    public class TagHelperAttribute








.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Minimized
    
        
    
        
        Gets an indication whether the attribute is minimized or not.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Minimized
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Name
    
        
    
        
        Gets the name of the attribute.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Value
    
        
    
        
        Gets the value of the attribute.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object Value
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.TagHelperAttribute(System.String)
    
        
    
        
        Instantiates a new instance of :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute` with the specified <em>name</em>.
        :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Minimized` is set to <code>true</code> and :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Value` to <code>null</code>.
    
        
    
        
        :param name: The :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Name` of the attribute.
        
        :type name: System.String
    
        
        .. code-block:: csharp
    
            public TagHelperAttribute(string name)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.TagHelperAttribute(System.String, System.Object)
    
        
    
        
        Instantiates a new instance of :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute` with the specified <em>name</em>
        and <em>value</em>. :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Minimized` is set to <code>false</code>.
    
        
    
        
        :param name: The :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Name` of the attribute.
        
        :type name: System.String
    
        
        :param value: The :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Value` of the attribute.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
            public TagHelperAttribute(string name, object value)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.TagHelperAttribute(System.String, System.Object, System.Boolean)
    
        
    
        
        Instantiates a new instance of :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute` with the specified <em>name</em>,
        <em>value</em> and <em>minimized</em>.
    
        
    
        
        :param name: The :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Name` of the new instance.
        
        :type name: System.String
    
        
        :param value: The :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Value` of the new instance.
        
        :type value: System.Object
    
        
        :param minimized: The :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Minimized` value of the new instance.
        
        :type minimized: System.Boolean
    
        
        .. code-block:: csharp
    
            public TagHelperAttribute(string name, object value, bool minimized)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Equals(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute)
    
        
    
        
        :type other: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Equals(TagHelperAttribute other)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    

