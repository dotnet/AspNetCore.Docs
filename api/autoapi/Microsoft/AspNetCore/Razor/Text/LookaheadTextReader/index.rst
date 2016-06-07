

LookaheadTextReader Class
=========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Text`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.MarshalByRefObject`
* :dn:cls:`System.IO.TextReader`
* :dn:cls:`Microsoft.AspNetCore.Razor.Text.LookaheadTextReader`








Syntax
------

.. code-block:: csharp

    public abstract class LookaheadTextReader : TextReader, IDisposable








.. dn:class:: Microsoft.AspNetCore.Razor.Text.LookaheadTextReader
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Text.LookaheadTextReader

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Text.LookaheadTextReader
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Text.LookaheadTextReader.CurrentLocation
    
        
        :rtype: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
            public abstract SourceLocation CurrentLocation
            {
                get;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Text.LookaheadTextReader
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Text.LookaheadTextReader.BeginLookahead()
    
        
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
            public abstract IDisposable BeginLookahead()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Text.LookaheadTextReader.CancelBacktrack()
    
        
    
        
        .. code-block:: csharp
    
            public abstract void CancelBacktrack()
    

