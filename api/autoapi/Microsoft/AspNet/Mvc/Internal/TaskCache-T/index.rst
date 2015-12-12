

TaskCache<T> Class
==================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Internal.TaskCache\<T>`








Syntax
------

.. code-block:: csharp

   public class TaskCache<T>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Internal/TaskCacheOfT.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Internal.TaskCache<T>

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Internal.TaskCache<T>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Internal.TaskCache<T>.DefaultCompletedTask
    
        
    
        Gets a completed :any:`System.Threading.Tasks.Task` with the value of <c>default(T)</c>.
    
        
        :rtype: System.Threading.Tasks.Task{{T}}
    
        
        .. code-block:: csharp
    
           public static Task<T> DefaultCompletedTask { get; }
    

