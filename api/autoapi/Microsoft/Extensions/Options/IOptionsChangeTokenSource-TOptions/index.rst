

IOptionsChangeTokenSource<TOptions> Interface
=============================================





Namespace
    :dn:ns:`Microsoft.Extensions.Options`
Assemblies
    * Microsoft.Extensions.Options

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IOptionsChangeTokenSource<out TOptions>








.. dn:interface:: Microsoft.Extensions.Options.IOptionsChangeTokenSource`1
    :hidden:

.. dn:interface:: Microsoft.Extensions.Options.IOptionsChangeTokenSource<TOptions>

Methods
-------

.. dn:interface:: Microsoft.Extensions.Options.IOptionsChangeTokenSource<TOptions>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Options.IOptionsChangeTokenSource<TOptions>.GetChangeToken()
    
        
    
        
        Returns a IChangeToken which can be used to register a change notification callback.
    
        
        :rtype: Microsoft.Extensions.Primitives.IChangeToken
    
        
        .. code-block:: csharp
    
            IChangeToken GetChangeToken()
    

