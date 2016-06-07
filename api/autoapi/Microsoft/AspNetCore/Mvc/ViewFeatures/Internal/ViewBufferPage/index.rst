

ViewBufferPage Class
====================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferPage`








Syntax
------

.. code-block:: csharp

    public class ViewBufferPage








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferPage
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferPage

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferPage
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferPage.Buffer
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferValue<Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferValue>[]
    
        
        .. code-block:: csharp
    
            public ViewBufferValue[] Buffer
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferPage.Capacity
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Capacity
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferPage.Count
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Count
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferPage.IsFull
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsFull
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferPage
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferPage.ViewBufferPage(Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferValue[])
    
        
    
        
        :type buffer: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferValue<Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferValue>[]
    
        
        .. code-block:: csharp
    
            public ViewBufferPage(ViewBufferValue[] buffer)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferPage
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferPage.Append(Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferValue)
    
        
    
        
        :type value: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferValue
    
        
        .. code-block:: csharp
    
            public void Append(ViewBufferValue value)
    

