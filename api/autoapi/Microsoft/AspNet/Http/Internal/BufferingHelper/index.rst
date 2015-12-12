

BufferingHelper Class
=====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.Internal.BufferingHelper`








Syntax
------

.. code-block:: csharp

   public class BufferingHelper





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http/BufferingHelper.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Internal.BufferingHelper

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.Internal.BufferingHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Internal.BufferingHelper.EnableRewind(Microsoft.AspNet.Http.HttpRequest, System.Int32)
    
        
        
        
        :type request: Microsoft.AspNet.Http.HttpRequest
        
        
        :type bufferThreshold: System.Int32
        :rtype: Microsoft.AspNet.Http.HttpRequest
    
        
        .. code-block:: csharp
    
           public static HttpRequest EnableRewind(HttpRequest request, int bufferThreshold = 30720)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.Internal.BufferingHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Internal.BufferingHelper.TempDirectory
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string TempDirectory { get; }
    

