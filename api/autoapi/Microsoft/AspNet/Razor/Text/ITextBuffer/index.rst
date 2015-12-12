

ITextBuffer Interface
=====================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface ITextBuffer





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Text/ITextBuffer.cs>`_





.. dn:interface:: Microsoft.AspNet.Razor.Text.ITextBuffer

Methods
-------

.. dn:interface:: Microsoft.AspNet.Razor.Text.ITextBuffer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Text.ITextBuffer.Peek()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int Peek()
    
    .. dn:method:: Microsoft.AspNet.Razor.Text.ITextBuffer.Read()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int Read()
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Razor.Text.ITextBuffer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Text.ITextBuffer.Length
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int Length { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Text.ITextBuffer.Position
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int Position { get; set; }
    

