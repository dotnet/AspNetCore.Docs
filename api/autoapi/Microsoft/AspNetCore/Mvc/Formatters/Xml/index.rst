

Microsoft.AspNetCore.Mvc.Formatters.Xml Namespace
=================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/Xml/DelegatingEnumerable-TWrapped-TDeclared/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/Xml/DelegatingEnumerator-TWrapped-TDeclared/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/Xml/EnumerableWrapperProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/Xml/EnumerableWrapperProviderFactory/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/Xml/IUnwrappable/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/Xml/IWrapperProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/Xml/IWrapperProviderFactory/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/Xml/SerializableErrorWrapper/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/Xml/SerializableErrorWrapperProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/Xml/SerializableErrorWrapperProviderFactory/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/Xml/WrapperProviderContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/Xml/WrapperProviderFactoriesExtensions/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Mvc.Formatters.Xml


    .. rubric:: Interfaces


    interface :dn:iface:`IUnwrappable`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Formatters.Xml.IUnwrappable

        
        Defines an interface for objects to be un-wrappable after deserialization.


    interface :dn:iface:`IWrapperProvider`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProvider

        
        Defines an interface for wrapping objects for serialization or deserialization into xml.


    interface :dn:iface:`IWrapperProviderFactory`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProviderFactory

        
        Create a :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProvider` given a :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.WrapperProviderContext`\.


    .. rubric:: Classes


    class :dn:cls:`DelegatingEnumerable\<TWrapped, TDeclared>`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Formatters.Xml.DelegatingEnumerable\<TWrapped, TDeclared>

        
        Serializes :any:`System.Collections.Generic.IEnumerable\`1` types by delegating them through a concrete implementation.


    class :dn:cls:`DelegatingEnumerator\<TWrapped, TDeclared>`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Formatters.Xml.DelegatingEnumerator\<TWrapped, TDeclared>

        
        Delegates enumeration of elements to the original enumerator and wraps the items
        with the supplied :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProvider`\.


    class :dn:cls:`EnumerableWrapperProvider`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Formatters.Xml.EnumerableWrapperProvider

        
        Provides a :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProvider` for interface types which implement 
        :any:`System.Collections.Generic.IEnumerable\`1`\.


    class :dn:cls:`EnumerableWrapperProviderFactory`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Formatters.Xml.EnumerableWrapperProviderFactory

        
        Creates an :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.EnumerableWrapperProvider` for interface types implementing the 
        :any:`System.Collections.Generic.IEnumerable\`1` type.


    class :dn:cls:`SerializableErrorWrapper`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Formatters.Xml.SerializableErrorWrapper

        
        Wrapper class for :dn:prop:`Microsoft.AspNetCore.Mvc.Formatters.Xml.SerializableErrorWrapper.SerializableError` to enable it to be serialized by the xml formatters.


    class :dn:cls:`SerializableErrorWrapperProvider`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Formatters.Xml.SerializableErrorWrapperProvider

        
        Wraps the object of type :any:`Microsoft.AspNetCore.Mvc.SerializableError`\.


    class :dn:cls:`SerializableErrorWrapperProviderFactory`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Formatters.Xml.SerializableErrorWrapperProviderFactory

        
        Creates an :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProvider` for the type :any:`Microsoft.AspNetCore.Mvc.SerializableError`\.


    class :dn:cls:`WrapperProviderContext`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Formatters.Xml.WrapperProviderContext

        
        The context used by an :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProvider` to wrap or un-wrap types.


    class :dn:cls:`WrapperProviderFactoriesExtensions`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Formatters.Xml.WrapperProviderFactoriesExtensions

        
        Extension methods for :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProviderFactory`\.


