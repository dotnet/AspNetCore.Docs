

TaskCache<T> Class
==================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.TaskCache\<T>`








Syntax
------

.. code-block:: csharp

    public class TaskCache<T>








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.TaskCache`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.TaskCache<T>

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.TaskCache<T>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.TaskCache<T>.DefaultCompletedTask
    
        
    
        
        Gets a completed :any:`System.Threading.Tasks.Task` with the value of <code>default(T)</code>.
    
        
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{T}
    
        
        .. code-block:: csharp
    
            public static Task<T> DefaultCompletedTask { get; }
    

