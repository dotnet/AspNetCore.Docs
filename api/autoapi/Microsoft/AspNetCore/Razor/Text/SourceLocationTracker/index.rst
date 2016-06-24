

SourceLocationTracker Class
===========================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.Text.SourceLocationTracker`








Syntax
------

.. code-block:: csharp

    public class SourceLocationTracker








.. dn:class:: Microsoft.AspNetCore.Razor.Text.SourceLocationTracker
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Text.SourceLocationTracker

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Text.SourceLocationTracker
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Text.SourceLocationTracker.SourceLocationTracker()
    
        
    
        
        .. code-block:: csharp
    
            public SourceLocationTracker()
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Text.SourceLocationTracker.SourceLocationTracker(Microsoft.AspNetCore.Razor.SourceLocation)
    
        
    
        
        :type currentLocation: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
            public SourceLocationTracker(SourceLocation currentLocation)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Text.SourceLocationTracker
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Text.SourceLocationTracker.CalculateNewLocation(Microsoft.AspNetCore.Razor.SourceLocation, System.String)
    
        
    
        
        :type lastPosition: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :type newContent: System.String
        :rtype: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
            public static SourceLocation CalculateNewLocation(SourceLocation lastPosition, string newContent)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Text.SourceLocationTracker.UpdateLocation(System.Char, System.Char)
    
        
    
        
        :type characterRead: System.Char
    
        
        :type nextCharacter: System.Char
    
        
        .. code-block:: csharp
    
            public void UpdateLocation(char characterRead, char nextCharacter)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Text.SourceLocationTracker.UpdateLocation(System.String)
    
        
    
        
        :type content: System.String
        :rtype: Microsoft.AspNetCore.Razor.Text.SourceLocationTracker
    
        
        .. code-block:: csharp
    
            public SourceLocationTracker UpdateLocation(string content)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Text.SourceLocationTracker
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Text.SourceLocationTracker.CurrentLocation
    
        
        :rtype: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
            public SourceLocation CurrentLocation { get; set; }
    

