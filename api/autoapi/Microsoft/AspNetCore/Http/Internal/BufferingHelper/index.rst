

BufferingHelper Class
=====================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Internal`
Assemblies
    * Microsoft.AspNetCore.Http

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.Internal.BufferingHelper`








Syntax
------

.. code-block:: csharp

    public class BufferingHelper








.. dn:class:: Microsoft.AspNetCore.Http.Internal.BufferingHelper
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.Internal.BufferingHelper

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.Internal.BufferingHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.BufferingHelper.EnableRewind(Microsoft.AspNetCore.Http.HttpRequest, System.Int32, System.Nullable<System.Int64>)
    
        
    
        
        :type request: Microsoft.AspNetCore.Http.HttpRequest
    
        
        :type bufferThreshold: System.Int32
    
        
        :type bufferLimit: System.Nullable<System.Nullable`1>{System.Int64<System.Int64>}
        :rtype: Microsoft.AspNetCore.Http.HttpRequest
    
        
        .. code-block:: csharp
    
            public static HttpRequest EnableRewind(this HttpRequest request, int bufferThreshold = 30720, long ? bufferLimit = null)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.BufferingHelper.EnableRewind(Microsoft.AspNetCore.WebUtilities.MultipartSection, System.Action<System.IDisposable>, System.Int32, System.Nullable<System.Int64>)
    
        
    
        
        :type section: Microsoft.AspNetCore.WebUtilities.MultipartSection
    
        
        :type registerForDispose: System.Action<System.Action`1>{System.IDisposable<System.IDisposable>}
    
        
        :type bufferThreshold: System.Int32
    
        
        :type bufferLimit: System.Nullable<System.Nullable`1>{System.Int64<System.Int64>}
        :rtype: Microsoft.AspNetCore.WebUtilities.MultipartSection
    
        
        .. code-block:: csharp
    
            public static MultipartSection EnableRewind(this MultipartSection section, Action<IDisposable> registerForDispose, int bufferThreshold = 30720, long ? bufferLimit = null)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.Internal.BufferingHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.BufferingHelper.TempDirectory
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string TempDirectory { get; }
    

