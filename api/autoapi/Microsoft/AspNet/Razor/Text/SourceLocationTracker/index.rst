

SourceLocationTracker Class
===========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Text.SourceLocationTracker`








Syntax
------

.. code-block:: csharp

   public class SourceLocationTracker





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Text/SourceLocationTracker.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Text.SourceLocationTracker

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Text.SourceLocationTracker
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Text.SourceLocationTracker.SourceLocationTracker()
    
        
    
        
        .. code-block:: csharp
    
           public SourceLocationTracker()
    
    .. dn:constructor:: Microsoft.AspNet.Razor.Text.SourceLocationTracker.SourceLocationTracker(Microsoft.AspNet.Razor.SourceLocation)
    
        
        
        
        :type currentLocation: Microsoft.AspNet.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
           public SourceLocationTracker(SourceLocation currentLocation)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Text.SourceLocationTracker
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Text.SourceLocationTracker.CalculateNewLocation(Microsoft.AspNet.Razor.SourceLocation, System.String)
    
        
        
        
        :type lastPosition: Microsoft.AspNet.Razor.SourceLocation
        
        
        :type newContent: System.String
        :rtype: Microsoft.AspNet.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
           public static SourceLocation CalculateNewLocation(SourceLocation lastPosition, string newContent)
    
    .. dn:method:: Microsoft.AspNet.Razor.Text.SourceLocationTracker.UpdateLocation(System.Char, System.Char)
    
        
        
        
        :type characterRead: System.Char
        
        
        :type nextCharacter: System.Char
    
        
        .. code-block:: csharp
    
           public void UpdateLocation(char characterRead, char nextCharacter)
    
    .. dn:method:: Microsoft.AspNet.Razor.Text.SourceLocationTracker.UpdateLocation(System.String)
    
        
        
        
        :type content: System.String
        :rtype: Microsoft.AspNet.Razor.Text.SourceLocationTracker
    
        
        .. code-block:: csharp
    
           public SourceLocationTracker UpdateLocation(string content)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Text.SourceLocationTracker
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Text.SourceLocationTracker.CurrentLocation
    
        
        :rtype: Microsoft.AspNet.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
           public SourceLocation CurrentLocation { get; set; }
    

