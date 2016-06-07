

DependencyInjectionSpecificationTests Class
===========================================





Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection.Specification`
Assemblies
    * Microsoft.Extensions.DependencyInjection.Specification.Tests

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests`








Syntax
------

.. code-block:: csharp

    public abstract class DependencyInjectionSpecificationTests








.. dn:class:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests

Properties
----------

.. dn:class:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.CreateInstanceFuncs
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Object<System.Object>[]}
    
        
        .. code-block:: csharp
    
            public static IEnumerable<object[]> CreateInstanceFuncs
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.ServiceContainerPicksConstructorWithLongestMatchesData
    
        
        :rtype: Xunit.TheoryData
    
        
        .. code-block:: csharp
    
            public static TheoryData ServiceContainerPicksConstructorWithLongestMatchesData
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.TypesWithNonPublicConstructorData
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Object<System.Object>[]}
    
        
        .. code-block:: csharp
    
            public static IEnumerable<object[]> TypesWithNonPublicConstructorData
            {
                get;
            }
    

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.AttemptingToResolveNonexistentServiceReturnsNull()
    
        
    
        
        .. code-block:: csharp
    
            [Fact]
            public void AttemptingToResolveNonexistentServiceReturnsNull()
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.ClosedServicesPreferredOverOpenGenericServices()
    
        
    
        
        .. code-block:: csharp
    
            [Fact]
            public void ClosedServicesPreferredOverOpenGenericServices()
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.CreateServiceProvider(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        
        :type serviceCollection: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            protected abstract IServiceProvider CreateServiceProvider(IServiceCollection serviceCollection)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.DisposingScopeDisposesService()
    
        
    
        
        .. code-block:: csharp
    
            [Fact]
            public void DisposingScopeDisposesService()
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.FactoryServicesAreCreatedAsPartOfCreatingObjectGraph()
    
        
    
        
        .. code-block:: csharp
    
            [Fact]
            public void FactoryServicesAreCreatedAsPartOfCreatingObjectGraph()
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.FactoryServicesCanBeCreatedByGetService()
    
        
    
        
        .. code-block:: csharp
    
            [Fact]
            public void FactoryServicesCanBeCreatedByGetService()
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.GetServiceOrCreateInstanceRegisteredServiceSingleton()
    
        
    
        
        .. code-block:: csharp
    
            [Fact]
            public void GetServiceOrCreateInstanceRegisteredServiceSingleton()
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.GetServiceOrCreateInstanceRegisteredServiceTransient()
    
        
    
        
        .. code-block:: csharp
    
            [Fact]
            public void GetServiceOrCreateInstanceRegisteredServiceTransient()
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.GetServiceOrCreateInstanceUnregisteredService()
    
        
    
        
        .. code-block:: csharp
    
            [Fact]
            public void GetServiceOrCreateInstanceUnregisteredService()
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.LastServiceReplacesPreviousServices()
    
        
    
        
        .. code-block:: csharp
    
            [Fact]
            public void LastServiceReplacesPreviousServices()
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.MultipleServiceCanBeIEnumerableResolved()
    
        
    
        
        .. code-block:: csharp
    
            [Fact]
            public void MultipleServiceCanBeIEnumerableResolved()
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.NestedScopedServiceCanBeResolved()
    
        
    
        
        .. code-block:: csharp
    
            [Fact]
            public void NestedScopedServiceCanBeResolved()
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.NestedScopedServiceCanBeResolvedWithNoFallbackProvider()
    
        
    
        
        .. code-block:: csharp
    
            [Fact]
            public void NestedScopedServiceCanBeResolvedWithNoFallbackProvider()
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.NonexistentServiceCanBeIEnumerableResolved()
    
        
    
        
        .. code-block:: csharp
    
            [Fact]
            public void NonexistentServiceCanBeIEnumerableResolved()
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.OpenGenericServicesCanBeResolved()
    
        
    
        
        .. code-block:: csharp
    
            [Fact]
            public void OpenGenericServicesCanBeResolved()
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.OuterServiceCanHaveOtherServicesInjected()
    
        
    
        
        .. code-block:: csharp
    
            [Fact]
            public void OuterServiceCanHaveOtherServicesInjected()
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.SafelyDisposeNestedProviderReferences()
    
        
    
        
        .. code-block:: csharp
    
            [Fact]
            public void SafelyDisposeNestedProviderReferences()
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.ScopedServiceCanBeResolved()
    
        
    
        
        .. code-block:: csharp
    
            [Fact]
            public void ScopedServiceCanBeResolved()
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.SelfResolveThenDispose()
    
        
    
        
        .. code-block:: csharp
    
            [Fact]
            public void SelfResolveThenDispose()
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.ServiceContainerPicksConstructorWithLongestMatches(Microsoft.Extensions.DependencyInjection.IServiceCollection, Microsoft.Extensions.DependencyInjection.Specification.Fakes.TypeWithSupersetConstructors)
    
        
    
        
        :type serviceCollection: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :type expected: Microsoft.Extensions.DependencyInjection.Specification.Fakes.TypeWithSupersetConstructors
    
        
        .. code-block:: csharp
    
            [Theory]
            [MemberData("ServiceContainerPicksConstructorWithLongestMatchesData", new object[]{})]
            public void ServiceContainerPicksConstructorWithLongestMatches(IServiceCollection serviceCollection, TypeWithSupersetConstructors expected)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.ServiceInstanceCanBeResolved()
    
        
    
        
        .. code-block:: csharp
    
            [Fact]
            public void ServiceInstanceCanBeResolved()
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.ServiceProviderRegistersServiceScopeFactory()
    
        
    
        
        .. code-block:: csharp
    
            [Fact]
            public void ServiceProviderRegistersServiceScopeFactory()
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.ServicesRegisteredWithImplementationTypeCanBeResolved()
    
        
    
        
        .. code-block:: csharp
    
            [Fact]
            public void ServicesRegisteredWithImplementationTypeCanBeResolved()
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.ServicesRegisteredWithImplementationType_ReturnDifferentInstancesPerResolution_ForTransientServices()
    
        
    
        
        .. code-block:: csharp
    
            [Fact]
            public void ServicesRegisteredWithImplementationType_ReturnDifferentInstancesPerResolution_ForTransientServices()
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.ServicesRegisteredWithImplementationType_ReturnSameInstancesPerResolution_ForSingletons()
    
        
    
        
        .. code-block:: csharp
    
            [Fact]
            public void ServicesRegisteredWithImplementationType_ReturnSameInstancesPerResolution_ForSingletons()
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.SingleServiceCanBeIEnumerableResolved()
    
        
    
        
        .. code-block:: csharp
    
            [Fact]
            public void SingleServiceCanBeIEnumerableResolved()
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.SingletonServiceCanBeResolved()
    
        
    
        
        .. code-block:: csharp
    
            [Fact]
            public void SingletonServiceCanBeResolved()
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.SingletonServicesComeFromRootProvider()
    
        
    
        
        .. code-block:: csharp
    
            [Fact]
            public void SingletonServicesComeFromRootProvider()
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.TransientServiceCanBeResolvedFromProvider()
    
        
    
        
        .. code-block:: csharp
    
            [Fact]
            public void TransientServiceCanBeResolvedFromProvider()
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.TransientServiceCanBeResolvedFromScope()
    
        
    
        
        .. code-block:: csharp
    
            [Fact]
            public void TransientServiceCanBeResolvedFromScope()
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.TypeActivatorAcceptsAnyNumberOfAdditionalConstructorParametersToProvide(Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.CreateInstanceFunc)
    
        
    
        
        :type createFunc: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.CreateInstanceFunc
    
        
        .. code-block:: csharp
    
            [Theory]
            [MemberData("CreateInstanceFuncs", new object[]{})]
            public void TypeActivatorAcceptsAnyNumberOfAdditionalConstructorParametersToProvide(DependencyInjectionSpecificationTests.CreateInstanceFunc createFunc)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.TypeActivatorCanDisambiguateConstructorsWithUniqueArguments(Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.CreateInstanceFunc)
    
        
    
        
        :type createFunc: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.CreateInstanceFunc
    
        
        .. code-block:: csharp
    
            [Theory]
            [MemberData("CreateInstanceFuncs", new object[]{})]
            public void TypeActivatorCanDisambiguateConstructorsWithUniqueArguments(DependencyInjectionSpecificationTests.CreateInstanceFunc createFunc)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.TypeActivatorCreateFactoryDoesNotAllowForAmbiguousConstructorMatches(System.Type)
    
        
    
        
        :type paramType: System.Type
    
        
        .. code-block:: csharp
    
            [Theory]
            [InlineData(new object[]{typeof (string)})]
            [InlineData(new object[]{typeof (int)})]
            public void TypeActivatorCreateFactoryDoesNotAllowForAmbiguousConstructorMatches(Type paramType)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.TypeActivatorEnablesYouToCreateAnyTypeWithServicesEvenWhenNotInIocContainer(Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.CreateInstanceFunc)
    
        
    
        
        :type createFunc: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.CreateInstanceFunc
    
        
        .. code-block:: csharp
    
            [Theory]
            [MemberData("CreateInstanceFuncs", new object[]{})]
            public void TypeActivatorEnablesYouToCreateAnyTypeWithServicesEvenWhenNotInIocContainer(DependencyInjectionSpecificationTests.CreateInstanceFunc createFunc)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.TypeActivatorRequiresAllArgumentsCanBeAccepted(Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.CreateInstanceFunc)
    
        
    
        
        :type createFunc: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.CreateInstanceFunc
    
        
        .. code-block:: csharp
    
            [Theory]
            [MemberData("CreateInstanceFuncs", new object[]{})]
            public void TypeActivatorRequiresAllArgumentsCanBeAccepted(DependencyInjectionSpecificationTests.CreateInstanceFunc createFunc)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.TypeActivatorRequiresPublicConstructor(Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.CreateInstanceFunc, System.Type)
    
        
    
        
        :type createFunc: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.CreateInstanceFunc
    
        
        :type type: System.Type
    
        
        .. code-block:: csharp
    
            [Theory]
            [MemberData("TypesWithNonPublicConstructorData", new object[]{})]
            public void TypeActivatorRequiresPublicConstructor(DependencyInjectionSpecificationTests.CreateInstanceFunc createFunc, Type type)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.TypeActivatorRethrowsOriginalExceptionFromConstructor(Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.CreateInstanceFunc)
    
        
    
        
        :type createFunc: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.CreateInstanceFunc
    
        
        .. code-block:: csharp
    
            [Theory]
            [MemberData("CreateInstanceFuncs", new object[]{})]
            public void TypeActivatorRethrowsOriginalExceptionFromConstructor(DependencyInjectionSpecificationTests.CreateInstanceFunc createFunc)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.TypeActivatorWorksWithCtorWithOptionalArgs(Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.CreateInstanceFunc)
    
        
    
        
        :type createFunc: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.CreateInstanceFunc
    
        
        .. code-block:: csharp
    
            [Theory]
            [MemberData("CreateInstanceFuncs", new object[]{})]
            public void TypeActivatorWorksWithCtorWithOptionalArgs(DependencyInjectionSpecificationTests.CreateInstanceFunc createFunc)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.TypeActivatorWorksWithStaticCtor(Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.CreateInstanceFunc)
    
        
    
        
        :type createFunc: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.CreateInstanceFunc
    
        
        .. code-block:: csharp
    
            [Theory]
            [MemberData("CreateInstanceFuncs", new object[]{})]
            public void TypeActivatorWorksWithStaticCtor(DependencyInjectionSpecificationTests.CreateInstanceFunc createFunc)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.UnRegisteredServiceAsConstructorParameterThrowsException(Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.CreateInstanceFunc)
    
        
    
        
        :type createFunc: Microsoft.Extensions.DependencyInjection.Specification.DependencyInjectionSpecificationTests.CreateInstanceFunc
    
        
        .. code-block:: csharp
    
            [Theory]
            [MemberData("CreateInstanceFuncs", new object[]{})]
            public void UnRegisteredServiceAsConstructorParameterThrowsException(DependencyInjectionSpecificationTests.CreateInstanceFunc createFunc)
    

