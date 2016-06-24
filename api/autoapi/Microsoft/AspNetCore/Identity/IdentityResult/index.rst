

IdentityResult Class
====================






Represents the result of an identity operation.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Identity`
Assemblies
    * Microsoft.AspNetCore.Identity

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Identity.IdentityResult`








Syntax
------

.. code-block:: csharp

    public class IdentityResult








.. dn:class:: Microsoft.AspNetCore.Identity.IdentityResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.IdentityResult

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Identity.IdentityResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Identity.IdentityResult.Errors
    
        
    
        
        An :any:`System.Collections.Generic.IEnumerable\`1` of :any:`Microsoft.AspNetCore.Identity.IdentityError`\s containing an errors
        that occurred during the identity operation.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Identity.IdentityError<Microsoft.AspNetCore.Identity.IdentityError>}
        :return: An :any:`System.Collections.Generic.IEnumerable\`1` of :any:`Microsoft.AspNetCore.Identity.IdentityError`\s.
    
        
        .. code-block:: csharp
    
            public IEnumerable<IdentityError> Errors { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.IdentityResult.Succeeded
    
        
    
        
        Flag indicating whether if the operation succeeded or not.
    
        
        :rtype: System.Boolean
        :return: True if the operation succeeded, otherwise false.
    
        
        .. code-block:: csharp
    
            public bool Succeeded { get; protected set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.IdentityResult.Success
    
        
    
        
        Returns an :any:`Microsoft.AspNetCore.Identity.IdentityResult` indicating a successful identity operation.
    
        
        :rtype: Microsoft.AspNetCore.Identity.IdentityResult
        :return: An :any:`Microsoft.AspNetCore.Identity.IdentityResult` indicating a successful operation.
    
        
        .. code-block:: csharp
    
            public static IdentityResult Success { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Identity.IdentityResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.IdentityResult.Failed(Microsoft.AspNetCore.Identity.IdentityError[])
    
        
    
        
        Creates an :any:`Microsoft.AspNetCore.Identity.IdentityResult` indicating a failed identity operation, with a list of <em>errors</em> if applicable.
    
        
    
        
        :param errors: An optional array of :any:`Microsoft.AspNetCore.Identity.IdentityError`\s which caused the operation to fail.
        
        :type errors: Microsoft.AspNetCore.Identity.IdentityError<Microsoft.AspNetCore.Identity.IdentityError>[]
        :rtype: Microsoft.AspNetCore.Identity.IdentityResult
        :return: An :any:`Microsoft.AspNetCore.Identity.IdentityResult` indicating a failed identity operation, with a list of <em>errors</em> if applicable.
    
        
        .. code-block:: csharp
    
            public static IdentityResult Failed(params IdentityError[] errors)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IdentityResult.ToString()
    
        
    
        
        Converts the value of the current :any:`Microsoft.AspNetCore.Identity.IdentityResult` object to its equivalent string representation.
    
        
        :rtype: System.String
        :return: A string representation of the current :any:`Microsoft.AspNetCore.Identity.IdentityResult` object.
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

