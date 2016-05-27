

PathNormalizer Class
====================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Http`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Http.PathNormalizer`








Syntax
------

.. code-block:: csharp

    public class PathNormalizer








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.PathNormalizer
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.PathNormalizer

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.PathNormalizer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.PathNormalizer.NormalizeToNFC(System.String)
    
        
    
        
        :type path: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string NormalizeToNFC(string path)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.PathNormalizer.RemoveDotSegments(System.String)
    
        
    
        
        :type path: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string RemoveDotSegments(string path)
    

