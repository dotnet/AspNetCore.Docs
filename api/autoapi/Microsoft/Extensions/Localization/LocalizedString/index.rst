

LocalizedString Struct
======================



.. contents:: 
   :local:



Summary
-------

A locale specific string.











Syntax
------

.. code-block:: csharp

   public struct LocalizedString





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/localization/src/Microsoft.Extensions.Localization.Abstractions/LocalizedString.cs>`_





.. dn:structure:: Microsoft.Extensions.Localization.LocalizedString

Constructors
------------

.. dn:structure:: Microsoft.Extensions.Localization.LocalizedString
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
        
        
        :param resourceNotFound: Whether the string was found in a resource. Set this to false to indicate an alternate string value was used.
        
        :type resourceNotFound: System.Boolean
    
        
        .. code-block:: csharp
    
           public LocalizedString(string name, string value, bool resourceNotFound)
    

Methods
-------

.. dn:structure:: Microsoft.Extensions.Localization.LocalizedString
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Localization.LocalizedString.ToString()
    
        
    
        Returns the actual string.
    
        
        :rtype: System.String
        :return: The actual string.
    
        
        .. code-block:: csharp
    
           public override string ToString()
    

Properties
----------

.. dn:structure:: Microsoft.Extensions.Localization.LocalizedString
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Localization.LocalizedString.Name
    
        
    
        The name of the string in the resource it was loaded from.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name { get; }
    
    .. dn:property:: Microsoft.Extensions.Localization.LocalizedString.ResourceNotFound
    
        
    
        Whether the string was found in a resource. If <c>false</c>, an alternate string value was used.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool ResourceNotFound { get; }
    
    .. dn:property:: Microsoft.Extensions.Localization.LocalizedString.Value
    
        
    
        The actual string.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Value { get; }
    

