

ElmStore Class
==============





Namespace
    :dn:ns:`Microsoft.AspNetCore.Diagnostics.Elm`
Assemblies
    * Microsoft.AspNetCore.Diagnostics.Elm

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Diagnostics.Elm.ElmStore`








Syntax
------

.. code-block:: csharp

    public class ElmStore








.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.ElmStore
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.ElmStore

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.ElmStore
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Diagnostics.Elm.ElmStore.AddActivity(Microsoft.AspNetCore.Diagnostics.Elm.ActivityContext)
    
        
    
        
        Adds a new :any:`Microsoft.AspNetCore.Diagnostics.Elm.ActivityContext` to the store.
    
        
    
        
        :param activity: The :any:`Microsoft.AspNetCore.Diagnostics.Elm.ActivityContext` to be added to the store.
        
        :type activity: Microsoft.AspNetCore.Diagnostics.Elm.ActivityContext
    
        
        .. code-block:: csharp
    
            public void AddActivity(ActivityContext activity)
    
    .. dn:method:: Microsoft.AspNetCore.Diagnostics.Elm.ElmStore.Clear()
    
        
    
        
        Removes all activity contexts that have been stored.
    
        
    
        
        .. code-block:: csharp
    
            public void Clear()
    
    .. dn:method:: Microsoft.AspNetCore.Diagnostics.Elm.ElmStore.Count()
    
        
    
        
        Returns the total number of logs in all activities in the store
    
        
        :rtype: System.Int32
        :return: The total log count
    
        
        .. code-block:: csharp
    
            public int Count()
    
    .. dn:method:: Microsoft.AspNetCore.Diagnostics.Elm.ElmStore.GetActivities()
    
        
    
        
        Returns an IEnumerable of the contexts of the logs.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Diagnostics.Elm.ActivityContext<Microsoft.AspNetCore.Diagnostics.Elm.ActivityContext>}
        :return: An IEnumerable of :any:`Microsoft.AspNetCore.Diagnostics.Elm.ActivityContext` objects where each context stores 
            information about a top level scope.
    
        
        .. code-block:: csharp
    
            public IEnumerable<ActivityContext> GetActivities()
    

