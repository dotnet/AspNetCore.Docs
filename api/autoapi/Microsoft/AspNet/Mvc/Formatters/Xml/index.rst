

Microsoft.AspNet.Mvc.Formatters.Xml Namespace
=============================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNet/Mvc/Formatters/Xml/DelegatingEnumerable-TWrapped-TDeclared/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Formatters/Xml/DelegatingEnumerator-TWrapped-TDeclared/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Formatters/Xml/EnumerableWrapperProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Formatters/Xml/EnumerableWrapperProviderFactory/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Formatters/Xml/IUnwrappable/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Formatters/Xml/IWrapperProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Formatters/Xml/IWrapperProviderFactory/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Formatters/Xml/SerializableErrorWrapper/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Formatters/Xml/SerializableErrorWrapperProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Formatters/Xml/SerializableErrorWrapperProviderFactory/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Formatters/Xml/WrapperProviderContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Formatters/Xml/WrapperProviderFactoriesExtensions/index
   
   











.. dn:namespace:: Microsoft.AspNet.Mvc.Formatters.Xml


    .. rubric:: Classes


    class :dn:cls:`Microsoft.AspNet.Mvc.Formatters.Xml.DelegatingEnumerable\<TWrapped, TDeclared>`
        Serializes :any:`System.Collections.Generic.IEnumerable\`1` types by delegating them through a concrete implementation.


    class :dn:cls:`Microsoft.AspNet.Mvc.Formatters.Xml.DelegatingEnumerator\<TWrapped, TDeclared>`
        Delegates enumeration of elements to the original enumerator and wraps the items
        with the supplied :any:`Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProvider`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.Formatters.Xml.EnumerableWrapperProvider`
        Provides a :any:`Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProvider` for interface types which implement 
        :any:`System.Collections.Generic.IEnumerable\`1`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.Formatters.Xml.EnumerableWrapperProviderFactory`
        Creates an :any:`Microsoft.AspNet.Mvc.Formatters.Xml.EnumerableWrapperProvider` for interface types implementing the 
        :any:`System.Collections.Generic.IEnumerable\`1` type.


    class :dn:cls:`Microsoft.AspNet.Mvc.Formatters.Xml.SerializableErrorWrapper`
        Wrapper class for :dn:prop:`Microsoft.AspNet.Mvc.Formatters.Xml.SerializableErrorWrapper.SerializableError` to enable it to be serialized by the xml formatters.


    class :dn:cls:`Microsoft.AspNet.Mvc.Formatters.Xml.SerializableErrorWrapperProvider`
        Wraps the object of type :any:`Microsoft.AspNet.Mvc.SerializableError`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.Formatters.Xml.SerializableErrorWrapperProviderFactory`
        Creates an :any:`Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProvider` for the type :any:`Microsoft.AspNet.Mvc.SerializableError`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.Formatters.Xml.WrapperProviderContext`
        The context used by an :any:`Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProvider` to wrap or un-wrap types.


    class :dn:cls:`Microsoft.AspNet.Mvc.Formatters.Xml.WrapperProviderFactoriesExtensions`
        Extension methods for :any:`Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProviderFactory`\.


    .. rubric:: Interfaces


    interface :dn:iface:`Microsoft.AspNet.Mvc.Formatters.Xml.IUnwrappable`
        Defines an interface for objects to be un-wrappable after deserialization.


    interface :dn:iface:`Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProvider`
        Defines an interface for wrapping objects for serialization or deserialization into xml.


    interface :dn:iface:`Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProviderFactory`
        Create a :any:`Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProvider` given a :any:`Microsoft.AspNet.Mvc.Formatters.Xml.WrapperProviderContext`\.


