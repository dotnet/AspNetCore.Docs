

LookaheadToken Class
====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Text.LookaheadToken`








Syntax
------

.. code-block:: csharp

   public class LookaheadToken : IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Text/LookaheadToken.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Text.LookaheadToken

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Text.LookaheadToken
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Text.LookaheadToken.LookaheadToken(System.Action)
    
        
        
        
        :type cancelAction: System.Action
    
        
        .. code-block:: csharp
    
           public LookaheadToken(Action cancelAction)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Text.LookaheadToken
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Text.LookaheadToken.Accept()
    
        
    
        
        .. code-block:: csharp
    
           public void Accept()
    
    .. dn:method:: Microsoft.AspNet.Razor.Text.LookaheadToken.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    
    .. dn:method:: Microsoft.AspNet.Razor.Text.LookaheadToken.Dispose(System.Boolean)
    
        
        
        
        :type disposing: System.Boolean
    
        
        .. code-block:: csharp
    
           protected virtual void Dispose(bool disposing)
    

