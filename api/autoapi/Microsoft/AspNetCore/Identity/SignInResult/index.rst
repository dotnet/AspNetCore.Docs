

SignInResult Class
==================






Represents the result of a sign-in operation.


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
* :dn:cls:`Microsoft.AspNetCore.Identity.SignInResult`








Syntax
------

.. code-block:: csharp

    public class SignInResult








.. dn:class:: Microsoft.AspNetCore.Identity.SignInResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.SignInResult

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Identity.SignInResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Identity.SignInResult.Failed
    
        
    
        
        Returns a :any:`Microsoft.AspNetCore.Identity.SignInResult` that represents a failed sign-in.
    
        
        :rtype: Microsoft.AspNetCore.Identity.SignInResult
        :return: A :any:`Microsoft.AspNetCore.Identity.SignInResult` that represents a failed sign-in.
    
        
        .. code-block:: csharp
    
            public static SignInResult Failed { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.SignInResult.IsLockedOut
    
        
    
        
        Returns a flag indication whether the user attempting to sign-in is locked out.
    
        
        :rtype: System.Boolean
        :return: True if the user attempting to sign-in is locked out, otherwise false.
    
        
        .. code-block:: csharp
    
            public bool IsLockedOut { get; protected set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.SignInResult.IsNotAllowed
    
        
    
        
        Returns a flag indication whether the user attempting to sign-in is not allowed to sign-in.
    
        
        :rtype: System.Boolean
        :return: True if the user attempting to sign-in is not allowed to sign-in, otherwise false.
    
        
        .. code-block:: csharp
    
            public bool IsNotAllowed { get; protected set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.SignInResult.LockedOut
    
        
    
        
        Returns a :any:`Microsoft.AspNetCore.Identity.SignInResult` that represents a sign-in attempt that failed because 
        the user was logged out.
    
        
        :rtype: Microsoft.AspNetCore.Identity.SignInResult
        :return: A :any:`Microsoft.AspNetCore.Identity.SignInResult` that represents sign-in attempt that failed due to the
            user being locked out.
    
        
        .. code-block:: csharp
    
            public static SignInResult LockedOut { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.SignInResult.NotAllowed
    
        
    
        
        Returns a :any:`Microsoft.AspNetCore.Identity.SignInResult` that represents a sign-in attempt that failed because 
        the user is not allowed to sign-in.
    
        
        :rtype: Microsoft.AspNetCore.Identity.SignInResult
        :return: A :any:`Microsoft.AspNetCore.Identity.SignInResult` that represents sign-in attempt that failed due to the
            user is not allowed to sign-in.
    
        
        .. code-block:: csharp
    
            public static SignInResult NotAllowed { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.SignInResult.RequiresTwoFactor
    
        
    
        
        Returns a flag indication whether the user attempting to sign-in requires two factor authentication.
    
        
        :rtype: System.Boolean
        :return: True if the user attempting to sign-in requires two factor authentication, otherwise false.
    
        
        .. code-block:: csharp
    
            public bool RequiresTwoFactor { get; protected set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.SignInResult.Succeeded
    
        
    
        
        Returns a flag indication whether the sign-in was successful.
    
        
        :rtype: System.Boolean
        :return: True if the sign-in was successful, otherwise false.
    
        
        .. code-block:: csharp
    
            public bool Succeeded { get; protected set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.SignInResult.Success
    
        
    
        
        Returns a :any:`Microsoft.AspNetCore.Identity.SignInResult` that represents a successful sign-in.
    
        
        :rtype: Microsoft.AspNetCore.Identity.SignInResult
        :return: A :any:`Microsoft.AspNetCore.Identity.SignInResult` that represents a successful sign-in.
    
        
        .. code-block:: csharp
    
            public static SignInResult Success { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.SignInResult.TwoFactorRequired
    
        
    
        
        Returns a :any:`Microsoft.AspNetCore.Identity.SignInResult` that represents a sign-in attempt that needs two-factor 
        authentication.
    
        
        :rtype: Microsoft.AspNetCore.Identity.SignInResult
        :return: A :any:`Microsoft.AspNetCore.Identity.SignInResult` that represents sign-in attempt that needs two-factor
            authentication.
    
        
        .. code-block:: csharp
    
            public static SignInResult TwoFactorRequired { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Identity.SignInResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.SignInResult.ToString()
    
        
    
        
        Converts the value of the current :any:`Microsoft.AspNetCore.Identity.SignInResult` object to its equivalent string representation.
    
        
        :rtype: System.String
        :return: A string representation of value of the current :any:`Microsoft.AspNetCore.Identity.SignInResult` object.
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

