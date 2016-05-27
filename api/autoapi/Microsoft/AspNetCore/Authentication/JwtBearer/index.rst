

Microsoft.AspNetCore.Authentication.JwtBearer Namespace
=======================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Authentication/JwtBearer/AuthenticationFailedContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/JwtBearer/BaseJwtBearerContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/JwtBearer/IJwtBearerEvents/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/JwtBearer/JwtBearerChallengeContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/JwtBearer/JwtBearerDefaults/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/JwtBearer/JwtBearerEvents/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/JwtBearer/JwtBearerMiddleware/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/JwtBearer/MessageReceivedContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/JwtBearer/TokenValidatedContext/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Authentication.JwtBearer


    .. rubric:: Classes


    class :dn:cls:`AuthenticationFailedContext`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.JwtBearer.AuthenticationFailedContext

        


    class :dn:cls:`BaseJwtBearerContext`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.JwtBearer.BaseJwtBearerContext

        


    class :dn:cls:`JwtBearerChallengeContext`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerChallengeContext

        


    class :dn:cls:`JwtBearerDefaults`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults

        
        Default values used by bearer authentication.


    class :dn:cls:`JwtBearerEvents`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents

        
        Specifies events which the :any:`Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerMiddleware` invokes to enable developer control over the authentication process.


    class :dn:cls:`JwtBearerMiddleware`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerMiddleware

        
        Bearer authentication middleware component which is added to an HTTP pipeline. This class is not
        created by application code directly, instead it is added by calling the the IAppBuilder UseJwtBearerAuthentication
        extension method.


    class :dn:cls:`MessageReceivedContext`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.JwtBearer.MessageReceivedContext

        


    class :dn:cls:`TokenValidatedContext`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.JwtBearer.TokenValidatedContext

        


    .. rubric:: Interfaces


    interface :dn:iface:`IJwtBearerEvents`
        .. object: type=interface name=Microsoft.AspNetCore.Authentication.JwtBearer.IJwtBearerEvents

        
        Specifies events which the :any:`Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerMiddleware` invokes to enable developer control over the authentication process.


