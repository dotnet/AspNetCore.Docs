

SignInResult Class
==================



.. contents:: 
   :local:



Summary
-------

Represents the result of a sign-in operation.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.SignInResult`








Syntax
------

.. code-block:: csharp

   public class SignInResult





GitHub
------

`View on GitHub <https://github.com/aspnet/identity/blob/master/src/Microsoft.AspNet.Identity/SignInResult.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.SignInResult

Methods
-------

.. dn:class:: Microsoft.AspNet.Identity.SignInResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.SignInResult.ToString()
    
        
    
        Converts the value of the current :any:`Microsoft.AspNet.Identity.SignInResult` object to its equivalent string representation.
    
        
        :rtype: System.String
        :return: A string representation of value of the current <see cref="T:Microsoft.AspNet.Identity.SignInResult" /> object.
    
        
        .. code-block:: csharp
    
           public override string ToString()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Identity.SignInResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Identity.SignInResult.Failed
    
        
    
        Returns a :any:`Microsoft.AspNet.Identity.SignInResult` that represents a failed sign-in.
    
        
        :rtype: Microsoft.AspNet.Identity.SignInResult
        :return: A <see cref="T:Microsoft.AspNet.Identity.SignInResult" /> that represents a failed sign-in.
    
        
        .. code-block:: csharp
    
           public static SignInResult Failed { get; }
    
    .. dn:property:: Microsoft.AspNet.Identity.SignInResult.IsLockedOut
    
        
    
        Returns a flag indication whether the user attempting to sign-in is locked out.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsLockedOut { get; protected set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.SignInResult.IsNotAllowed
    
        
    
        Returns a flag indication whether the user attempting to sign-in is not allowed to sign-in.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsNotAllowed { get; protected set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.SignInResult.LockedOut
    
        
    
        Returns a :any:`Microsoft.AspNet.Identity.SignInResult` that represents a sign-in attempt that failed because
        the user was logged out.
    
        
        :rtype: Microsoft.AspNet.Identity.SignInResult
        :return: A <see cref="T:Microsoft.AspNet.Identity.SignInResult" /> that represents sign-in attempt that failed due to the
            user being locked out.
    
        
        .. code-block:: csharp
    
           public static SignInResult LockedOut { get; }
    
    .. dn:property:: Microsoft.AspNet.Identity.SignInResult.NotAllowed
    
        
    
        Returns a :any:`Microsoft.AspNet.Identity.SignInResult` that represents a sign-in attempt that failed because
        the user is not allowed to sign-in.
    
        
        :rtype: Microsoft.AspNet.Identity.SignInResult
        :return: A <see cref="T:Microsoft.AspNet.Identity.SignInResult" /> that represents sign-in attempt that failed due to the
            user is not allowed to sign-in.
    
        
        .. code-block:: csharp
    
           public static SignInResult NotAllowed { get; }
    
    .. dn:property:: Microsoft.AspNet.Identity.SignInResult.RequiresTwoFactor
    
        
    
        Returns a flag indication whether the user attempting to sign-in requires two factor authentication.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool RequiresTwoFactor { get; protected set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.SignInResult.Succeeded
    
        
    
        Returns a flag indication whether the sign-in was successful.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Succeeded { get; protected set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.SignInResult.Success
    
        
    
        Returns a :any:`Microsoft.AspNet.Identity.SignInResult` that represents a successful sign-in.
    
        
        :rtype: Microsoft.AspNet.Identity.SignInResult
        :return: A <see cref="T:Microsoft.AspNet.Identity.SignInResult" /> that represents a successful sign-in.
    
        
        .. code-block:: csharp
    
           public static SignInResult Success { get; }
    
    .. dn:property:: Microsoft.AspNet.Identity.SignInResult.TwoFactorRequired
    
        
    
        Returns a :any:`Microsoft.AspNet.Identity.SignInResult` that represents a sign-in attempt that needs two-factor
        authentication.
    
        
        :rtype: Microsoft.AspNet.Identity.SignInResult
        :return: A <see cref="T:Microsoft.AspNet.Identity.SignInResult" /> that represents sign-in attempt that needs two-factor
            authentication.
    
        
        .. code-block:: csharp
    
           public static SignInResult TwoFactorRequired { get; }
    

