

ElmStore Class
==============



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.Elm.ElmStore`








Syntax
------

.. code-block:: csharp

   public class ElmStore





GitHub
------

`View on GitHub <https://github.com/aspnet/diagnostics/blob/master/src/Microsoft.AspNet.Diagnostics.Elm/ElmStore.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.ElmStore

Methods
-------

.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.ElmStore
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Elm.ElmStore.AddActivity(Microsoft.AspNet.Diagnostics.Elm.ActivityContext)
    
        
    
        Adds a new :any:`Microsoft.AspNet.Diagnostics.Elm.ActivityContext` to the store.
    
        
        
        
        :type activity: Microsoft.AspNet.Diagnostics.Elm.ActivityContext
    
        
        .. code-block:: csharp
    
           public void AddActivity(ActivityContext activity)
    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Elm.ElmStore.Clear()
    
        
    
        Removes all activity contexts that have been stored.
    
        
    
        
        .. code-block:: csharp
    
           public void Clear()
    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Elm.ElmStore.Count()
    
        
    
        Returns the total number of logs in all activities in the store
    
        
        :rtype: System.Int32
        :return: The total log count
    
        
        .. code-block:: csharp
    
           public int Count()
    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Elm.ElmStore.GetActivities()
    
        
    
        Returns an IEnumerable of the contexts of the logs.
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Diagnostics.Elm.ActivityContext}
        :return: An IEnumerable of <see cref="T:Microsoft.AspNet.Diagnostics.Elm.ActivityContext" /> objects where each context stores
            information about a top level scope.
    
        
        .. code-block:: csharp
    
           public IEnumerable<ActivityContext> GetActivities()
    

