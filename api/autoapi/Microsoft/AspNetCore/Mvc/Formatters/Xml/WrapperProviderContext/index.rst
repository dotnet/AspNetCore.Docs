

WrapperProviderContext Class
============================






The context used by an :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProvider` to wrap or un-wrap types.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Formatters.Xml`
Assemblies
    * Microsoft.AspNetCore.Mvc.Formatters.Xml

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.Xml.WrapperProviderContext`








Syntax
------

.. code-block:: csharp

    public class WrapperProviderContext








.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.WrapperProviderContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.WrapperProviderContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.WrapperProviderContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Formatters.Xml.WrapperProviderContext.WrapperProviderContext(System.Type, System.Boolean)
    
        
    
        
        Initializes a :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.WrapperProviderContext`\.
    
        
    
        
        :param declaredType: The declared type of the object that needs to be wrapped.
        
        :type declaredType: System.Type
    
        
        :param isSerialization: <xref uid="langword_csharp_true" name="true" href=""></xref> if the wrapper provider is invoked during
                serialization, otherwise <xref uid="langword_csharp_false" name="false" href=""></xref>.
        
        :type isSerialization: System.Boolean
    
        
        .. code-block:: csharp
    
            public WrapperProviderContext(Type declaredType, bool isSerialization)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.WrapperProviderContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.Xml.WrapperProviderContext.DeclaredType
    
        
    
        
        The declared type which could be wrapped/un-wrapped by a different type 
        during serialization or de-serializatoin.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public Type DeclaredType { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.Xml.WrapperProviderContext.IsSerialization
    
        
    
        
        <xref uid="langword_csharp_true" name="true" href=""></xref> if a wrapper provider is invoked during serialization,
        <xref uid="langword_csharp_false" name="false" href=""></xref> otherwise.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsSerialization { get; }
    

