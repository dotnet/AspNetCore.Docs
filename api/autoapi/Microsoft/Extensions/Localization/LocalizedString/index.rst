

LocalizedString Class
=====================






A locale specific string.


Namespace
    :dn:ns:`Microsoft.Extensions.Localization`
Assemblies
    * Microsoft.Extensions.Localization.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Localization.LocalizedString`








Syntax
------

.. code-block:: csharp

    public class LocalizedString








.. dn:class:: Microsoft.Extensions.Localization.LocalizedString
    :hidden:

.. dn:class:: Microsoft.Extensions.Localization.LocalizedString

Constructors
------------

.. dn:class:: Microsoft.Extensions.Localization.LocalizedString
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Localization.LocalizedString.LocalizedString(System.String, System.String)
    
        
    
        
        Creates a new :any:`Microsoft.Extensions.Localization.LocalizedString`\.
    
        
    
        
        :param name: The name of the string in the resource it was loaded from.
        
        :type name: System.String
    
        
        :param value: The actual string.
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
            public LocalizedString(string name, string value)
    
    .. dn:constructor:: Microsoft.Extensions.Localization.LocalizedString.LocalizedString(System.String, System.String, System.Boolean)
    
        
    
        
        Creates a new :any:`Microsoft.Extensions.Localization.LocalizedString`\.
    
        
    
        
        :param name: The name of the string in the resource it was loaded from.
        
        :type name: System.String
    
        
        :param value: The actual string.
        
        :type value: System.String
    
        
        :param resourceNotFound: Whether the string was found in a resource. Set this to <code>false</code> to indicate an alternate string value was used.
        
        :type resourceNotFound: System.Boolean
    
        
        .. code-block:: csharp
    
            public LocalizedString(string name, string value, bool resourceNotFound)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.Localization.LocalizedString
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Localization.LocalizedString.Name
    
        
    
        
        The name of the string in the resource it was loaded from.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name { get; }
    
    .. dn:property:: Microsoft.Extensions.Localization.LocalizedString.ResourceNotFound
    
        
    
        
        Whether the string was found in a resource. If <code>false</code>, an alternate string value was used.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool ResourceNotFound { get; }
    
    .. dn:property:: Microsoft.Extensions.Localization.LocalizedString.Value
    
        
    
        
        The actual string.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Value { get; }
    

Operators
---------

.. dn:class:: Microsoft.Extensions.Localization.LocalizedString
    :noindex:
    :hidden:

    
    .. dn:operator:: Microsoft.Extensions.Localization.LocalizedString.Implicit(Microsoft.Extensions.Localization.LocalizedString to System.String)
    
        
    
        
        :type localizedString: Microsoft.Extensions.Localization.LocalizedString
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static implicit operator string (LocalizedString localizedString)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Localization.LocalizedString
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Localization.LocalizedString.ToString()
    
        
    
        
        Returns the actual string.
    
        
        :rtype: System.String
        :return: The actual string.
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

