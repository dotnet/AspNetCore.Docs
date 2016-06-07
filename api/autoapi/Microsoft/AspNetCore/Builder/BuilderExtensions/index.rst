

BuilderExtensions Class
=======================






Identity extensions for :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Identity

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.BuilderExtensions`








Syntax
------

.. code-block:: csharp

    public class BuilderExtensions








.. dn:class:: Microsoft.AspNetCore.Builder.BuilderExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.BuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.BuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.BuilderExtensions.UseIdentity(Microsoft.AspNetCore.Builder.IApplicationBuilder)
    
        
    
        
        Enables ASP.NET identity for the current application.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` instance this method extends.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` instance this method extends.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseIdentity(IApplicationBuilder app)
    

