

LookaheadTextReader Class
=========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.MarshalByRefObject`
* :dn:cls:`System.IO.TextReader`
* :dn:cls:`Microsoft.AspNet.Razor.Text.LookaheadTextReader`








Syntax
------

.. code-block:: csharp

   public abstract class LookaheadTextReader : TextReader, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Text/LookaheadTextReader.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Text.LookaheadTextReader

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Text.LookaheadTextReader
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Text.LookaheadTextReader.BeginLookahead()
    
        
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
           public abstract IDisposable BeginLookahead()
    
    .. dn:method:: Microsoft.AspNet.Razor.Text.LookaheadTextReader.CancelBacktrack()
    
        
    
        
        .. code-block:: csharp
    
           public abstract void CancelBacktrack()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Text.LookaheadTextReader
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Text.LookaheadTextReader.CurrentLocation
    
        
        :rtype: Microsoft.AspNet.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
           public abstract SourceLocation CurrentLocation { get; }
    

