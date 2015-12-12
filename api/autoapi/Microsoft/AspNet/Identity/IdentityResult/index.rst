

IdentityResult Class
====================



.. contents:: 
   :local:



Summary
-------

Represents the result of an identity operation.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.IdentityResult`








Syntax
------

.. code-block:: csharp

   public class IdentityResult





GitHub
------

`View on GitHub <https://github.com/aspnet/identity/blob/master/src/Microsoft.AspNet.Identity/IdentityResult.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.IdentityResult

Methods
-------

.. dn:class:: Microsoft.AspNet.Identity.IdentityResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.IdentityResult.Failed(Microsoft.AspNet.Identity.IdentityError[])
    
        
    
        Creates an :any:`Microsoft.AspNet.Identity.IdentityResult` indicating a failed identity operation, with a list of ``errors`` if applicable.
    
        
        
        
        :param errors: An optional array of s which caused the operation to fail.
        
        :type errors: Microsoft.AspNet.Identity.IdentityError[]
        :rtype: Microsoft.AspNet.Identity.IdentityResult
        :return: An <see cref="T:Microsoft.AspNet.Identity.IdentityResult" /> indicating a failed identity operation, with a list of <paramref name="errors" /> if applicable.
    
        
        .. code-block:: csharp
    
           public static IdentityResult Failed(params IdentityError[] errors)
    
    .. dn:method:: Microsoft.AspNet.Identity.IdentityResult.ToString()
    
        
    
        Converts the value of the current :any:`Microsoft.AspNet.Identity.IdentityResult` object to its equivalent string representation.
    
        
        :rtype: System.String
        :return: A string representation of the current <see cref="T:Microsoft.AspNet.Identity.IdentityResult" /> object.
    
        
        .. code-block:: csharp
    
           public override string ToString()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Identity.IdentityResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Identity.IdentityResult.Errors
    
        
    
        An :any:`System.Collections.Generic.IEnumerable\`1` of :any:`Microsoft.AspNet.Identity.IdentityError`\s containing an errors
        that occurred during the identity operation.
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Identity.IdentityError}
    
        
        .. code-block:: csharp
    
           public IEnumerable<IdentityError> Errors { get; }
    
    .. dn:property:: Microsoft.AspNet.Identity.IdentityResult.Succeeded
    
        
    
        Flag indicating whether if the operation succeeded or not.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Succeeded { get; protected set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.IdentityResult.Success
    
        
    
        Returns an :any:`Microsoft.AspNet.Identity.IdentityResult` indicating a successful identity operation.
    
        
        :rtype: Microsoft.AspNet.Identity.IdentityResult
        :return: An <see cref="T:Microsoft.AspNet.Identity.IdentityResult" /> indicating a successful operation.
    
        
        .. code-block:: csharp
    
           public static IdentityResult Success { get; }
    

