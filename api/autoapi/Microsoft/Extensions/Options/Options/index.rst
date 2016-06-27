

Options Class
=============






Helper class.


Namespace
    :dn:ns:`Microsoft.Extensions.Options`
Assemblies
    * Microsoft.Extensions.Options

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Options.Options`








Syntax
------

.. code-block:: csharp

    public class Options








.. dn:class:: Microsoft.Extensions.Options.Options
    :hidden:

.. dn:class:: Microsoft.Extensions.Options.Options

Methods
-------

.. dn:class:: Microsoft.Extensions.Options.Options
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Options.Options.Create<TOptions>(TOptions)
    
        
    
        
        Creates a wrapper around an instance of TOptions to return itself as an IOptions.
    
        
    
        
        :type options: TOptions
        :rtype: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{TOptions}
    
        
        .. code-block:: csharp
    
            public static IOptions<TOptions> Create<TOptions>(TOptions options)where TOptions : class, new ()
    

