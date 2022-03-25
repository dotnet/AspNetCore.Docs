---
title: Test Razor components in ASP.NET Core Blazor
author: guardrex
description: Learn how to test Razor components in Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/09/2021
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/test
---
# Test Razor components in ASP.NET Core Blazor

By: [Egil Hansen](https://egilhansen.com/)

:::moniker range=">= aspnetcore-6.0"

Testing Razor components is an important aspect of releasing stable and maintainable Blazor apps.

To test a Razor component, the *component under test* (CUT) is:

* Rendered with relevant input for the test.
* Depending on the type of test performed, possibly subject to interaction or modification. For example, event handlers can be triggered, such as an `onclick` event for a button.
* Inspected for expected values. A test passes when one or more inspected values matches the expected values for the test.

## Test approaches

Two common approaches for testing Razor components are end-to-end (E2E) testing and unit testing:

* **Unit testing**: [Unit tests](/dotnet/core/testing/) are written with a unit testing library that provides:
  * Component rendering.
  * Inspection of component output and state.
  * Triggering of event handlers and life cycle methods.
  * Assertions that component behavior is correct.

  [bUnit](https://github.com/egil/bUnit) is an example of a library that enables Razor component unit testing.

* **E2E testing**: A test runner runs a Blazor app containing the CUT and automates a browser instance. The testing tool inspects and interacts with the CUT through the browser. [Playwright for .NET](https://playwright.dev/dotnet/) is an example of an E2E testing framework that can be used with Blazor apps.

In unit testing, only the Razor component (Razor/C#) is involved. External dependencies, such as services and JS interop, must be mocked. In E2E testing, the Razor component and all of its auxiliary infrastructure are part of the test, including CSS, JS, and the DOM and browser APIs.

*Test scope* describes how extensive the tests are. Test scope typically has an influence on the speed of the tests. Unit tests run on a subset of the app's subsystems and usually execute in milliseconds. E2E tests, which test a broad group of the app's subsystems, can take several seconds to complete. 

Unit testing also provides access to the instance of the CUT, allowing for inspection and verification of the component's internal state. This normally isn't possible in E2E testing.

With regard to the component's environment, E2E tests must make sure that the expected environmental state has been reached before verification starts. Otherwise, the result is unpredictable. In unit testing, the rendering of the CUT and the life cycle of the test are more integrated, which improves test stability.

E2E testing involves launching multiple processes, network and disk I/O, and other subsystem activity that often lead to poor test reliability. Unit tests are typically insulated from these sorts of issues.

The following table summarizes the difference between the two testing approaches.

| Capability                       | Unit testing                    | E2E testing                            |
| -------------------------------- | ------------------------------- | -------------------------------------- |
| Test scope                       | Razor component (Razor/C#) only | Razor component (Razor/C#) with CSS/JS |
| Test execution time              | Milliseconds                    | Seconds                                |
| Access to the component instance | Yes                             | No                                     |
| Sensitive to the environment     | No                              | Yes                                    |
| Reliability                      | More reliable                   | Less reliable                          |

## Choose the most appropriate test approach

Consider the scenario when choosing the type of testing to perform. Some considerations are described in the following table.

| Scenario | Suggested approach | Remarks |
| -------- | ------------------ | ------- |
| Component without JS interop logic | Unit testing | When there's no dependency on JS interop in a Razor component, the component can be tested without access to JS or the DOM API. In this scenario, there are no disadvantages to choosing unit testing. |
| Component with simple JS interop logic | Unit testing | It's common for components to query the DOM or trigger animations through JS interop. Unit testing is usually preferred in this scenario, since it's straightforward to mock the JS interaction through the <xref:Microsoft.JSInterop.IJSRuntime> interface. |
| Component that depends on complex JS code | Unit testing and separate JS testing | If a component uses JS interop to call a large or complex JS library but the interaction between the Razor component and JS library is simple, then the best approach is likely to treat the component and JS library or code as two separate parts and test each individually. Test the Razor component with a unit testing library, and test the JS with a JS testing library. |
| Component with logic that depends on JS manipulation of the browser DOM | E2E testing | When a component's functionality is dependent on JS and its manipulation of the DOM, verify both the JS and Blazor code together in an E2E test. This is the approach that the Blazor framework developers have taken with Blazor's browser rendering logic, which has tightly-coupled C# and JS code. The C# and JS code must work together to correctly render Razor components in a browser.
| Component that depends on 3rd party class library with hard-to-mock dependencies | E2E testing | When a component's functionality is dependent on a 3rd party class library that has hard-to-mock dependencies, such as JS interop, E2E testing might be the only option to test the component. |

## Test components with bUnit

There's no official Microsoft testing framework for Blazor, but the community-driven project [bUnit](https://github.com/egil/bUnit) provides a convenient way to unit test Razor components.

> [!NOTE]
> bUnit is a third-party testing library and isn't supported or maintained by Microsoft.

bUnit works with general-purpose testing frameworks, such as [MSTest](/dotnet/core/testing/unit-testing-with-mstest), [NUnit](https://nunit.org/), and [xUnit](https://xunit.net/). These testing frameworks make bUnit tests look and feel like regular unit tests. bUnit tests integrated with a general-purpose testing framework are ordinarily executed with:

* [Visual Studio's Test Explorer](/visualstudio/test/run-unit-tests-with-test-explorer).
* [`dotnet test`](/dotnet/core/tools/dotnet-test) CLI command in a command shell.
* An automated DevOps testing pipeline.

> [!NOTE]
> Test concepts and test implementations across different test frameworks are similar but not identical. Refer to the test framework's documentation for guidance.

The following demonstrates the structure of a bUnit test on the `Counter` component in an app based on a [Blazor project template](xref:blazor/project-structure). The `Counter` component displays and increments a counter based on the user selecting a button in the page:

```razor
@page "/counter"

<h1>Counter</h1>

<p>Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

@code {
    private int currentCount = 0;

    private void IncrementCount()
    {
        currentCount++;
    }
}
```

The following bUnit test verifies that the CUT's counter is incremented correctly when the button is selected:

```csharp
[Fact]
public void CounterShouldIncrementWhenSelected()
{
    // Arrange
    using var ctx = new TestContext();
    var cut = ctx.RenderComponent<Counter>();
    var paraElm = cut.Find("p");

    // Act
    cut.Find("button").Click();
    var paraElmText = paraElm.TextContent;

    // Assert
    paraElmText.MarkupMatches("Current count: 1");
}
```

The following actions take place at each step of the test:

* *Arrange*: The `Counter` component is rendered using bUnit's `TestContext`. The CUT's paragraph element (`<p>`) is found and assigned to `paraElm`.

* *Act*: The button's element (`<button>`) is located and then selected by calling `Click`, which should increment the counter and update the content of the paragraph tag (`<p>`). The paragraph element text content is obtained by calling `TextContent`.

* *Assert*: `MarkupMatches` is called on the text content to verify that it matches the expected string, which is `Current count: 1`.

> [!NOTE]
> The `MarkupMatches` assert method differs from a regular string comparison assertion (for example, `Assert.Equal("Current count: 1", paraElmText);`) `MarkupMatches` performs a semantic comparison of the input and expected HTML markup. A semantic comparison is aware of HTML semantics, meaning things like insignificant whitespace is ignored. This results in more stable tests. For more information, see [Customizing the Semantic HTML Comparison](https://bunit.egilhansen.com/docs/verification/semantic-html-comparison).

## Additional resources

* [Getting Started with bUnit](https://bunit.egilhansen.com/docs/getting-started/): bUnit instructions include guidance on creating a test project, referencing testing framework packages, and building and running tests.

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

Testing is an important aspect of building stable and maintainable software.

To test a Razor component, the *component under test* (CUT) is:

* Rendered with relevant input for the test.
* Depending on the type of test performed, possibly subject to interaction or modification. For example, event handlers can be triggered, such as an `onclick` event for a button.
* Inspected for expected values.

## Test approaches

Two common approaches for testing Razor components are end-to-end (E2E) testing and unit testing:

* **Unit testing**: [Unit tests](/dotnet/core/testing/) are written with a unit testing library that provides:
  * Component rendering.
  * Inspection of component output and state.
  * Triggering of event handlers and life cycle methods.
  * Assertions that component behavior is correct.

  [bUnit](https://github.com/egil/bUnit) is an example of a library that enables Razor component unit testing.

* **E2E testing**: A test runner runs a Blazor app containing the CUT and automates a browser instance. The testing tool inspects and interacts with the CUT through the browser. [Playwright for .NET](https://playwright.dev/dotnet/) is an example of an E2E testing framework that can be used with Blazor apps.

In unit testing, only the Razor component (Razor/C#) is involved. External dependencies, such as services and JS interop, must be mocked. In E2E testing, the Razor component and all of its auxiliary infrastructure are part of the test, including CSS, JS, and the DOM and browser APIs.

*Test scope* describes how extensive the tests are. Test scope typically has an influence on the speed of the tests. Unit tests run on a subset of the app's subsystems and usually execute in milliseconds. E2E tests, which test a broad group of the app's subsystems, can take several seconds to complete. 

Unit testing also provides access to the instance of the CUT, allowing for inspection and verification of the component's internal state. This normally isn't possible in E2E testing.

With regard to the component's environment, E2E tests must make sure that the expected environmental state has been reached before verification starts. Otherwise, the result is unpredictable. In unit testing, the rendering of the CUT and the life cycle of the test are more integrated, which improves test stability.

E2E testing involves launching multiple processes, network and disk I/O, and other subsystem activity that often lead to poor test reliability. Unit tests are typically insulated from these sorts of issues.

The following table summarizes the difference between the two testing approaches.

| Capability                       | Unit testing                    | E2E testing                            |
| -------------------------------- | ------------------------------- | -------------------------------------- |
| Test scope                       | Razor component (Razor/C#) only | Razor component (Razor/C#) with CSS/JS |
| Test execution time              | Milliseconds                    | Seconds                                |
| Access to the component instance | Yes                             | No                                     |
| Sensitive to the environment     | No                              | Yes                                    |
| Reliability                      | More reliable                   | Less reliable                          |

## Choose the most appropriate test approach

Consider the scenario when choosing the type of testing to perform. Some considerations are described in the following table.

| Scenario | Suggested approach | Remarks |
| -------- | ------------------ | ------- |
| Component without JS interop logic | Unit testing | When there's no dependency on JS interop in a Razor component, the component can be tested without access to JS or the DOM API. In this scenario, there are no disadvantages to choosing unit testing. |
| Component with simple JS interop logic | Unit testing | It's common for components to query the DOM or trigger animations through JS interop. Unit testing is usually preferred in this scenario, since it's straightforward to mock the JS interaction through the <xref:Microsoft.JSInterop.IJSRuntime> interface. |
| Component that depends on complex JS code | Unit testing and separate JS testing | If a component uses JS interop to call a large or complex JS library but the interaction between the Razor component and JS library is simple, then the best approach is likely to treat the component and JS library or code as two separate parts and test each individually. Test the Razor component with a unit testing library, and test the JS with a JS testing library. |
| Component with logic that depends on JS manipulation of the browser DOM | E2E testing | When a component's functionality is dependent on JS and its manipulation of the DOM, verify both the JS and Blazor code together in an E2E test. This is the approach that the Blazor framework developers have taken with Blazor's browser rendering logic, which has tightly-coupled C# and JS code. The C# and JS code must work together to correctly render Razor components in a browser.
| Component that depends on 3rd party class library with hard-to-mock dependencies | E2E testing | When a component's functionality is dependent on a 3rd party class library that has hard-to-mock dependencies, such as JS interop, E2E testing might be the only option to test the component. |

## Test components with bUnit

There's no official Microsoft testing framework for Blazor, but the community-driven project [bUnit](https://github.com/egil/bUnit) provides a convenient way to unit test Razor components.

> [!NOTE]
> bUnit is a third-party testing library and isn't supported or maintained by Microsoft.

bUnit works with general-purpose testing frameworks, such as [MSTest](/dotnet/core/testing/unit-testing-with-mstest), [NUnit](https://nunit.org/), and [xUnit](https://xunit.net/). These testing frameworks make bUnit tests look and feel like regular unit tests. bUnit tests integrated with a general-purpose testing framework are ordinarily executed with:

* [Visual Studio's Test Explorer](/visualstudio/test/run-unit-tests-with-test-explorer).
* [`dotnet test`](/dotnet/core/tools/dotnet-test) CLI command in a command shell.
* An automated DevOps testing pipeline.

> [!NOTE]
> Test concepts and test implementations across different test frameworks are similar but not identical. Refer to the test framework's documentation for guidance.

The following demonstrates the structure of a bUnit test on the `Counter` component in an app based on a [Blazor project template](xref:blazor/project-structure). The `Counter` component displays and increments a counter based on the user selecting a button in the page:

```razor
@page "/counter"

<h1>Counter</h1>

<p>Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

@code {
    private int currentCount = 0;

    private void IncrementCount()
    {
        currentCount++;
    }
}
```

The following bUnit test verifies that the CUT's counter is incremented correctly when the button is selected:

```csharp
[Fact]
public void CounterShouldIncrementWhenSelected()
{
    // Arrange
    using var ctx = new TestContext();
    var cut = ctx.RenderComponent<Counter>();
    var paraElm = cut.Find("p");

    // Act
    cut.Find("button").Click();
    var paraElmText = paraElm.TextContent;

    // Assert
    paraElmText.MarkupMatches("Current count: 1");
}
```

The following actions take place at each step of the test:

* *Arrange*: The `Counter` component is rendered using bUnit's `TestContext`. The CUT's paragraph element (`<p>`) is found and assigned to `paraElm`.

* *Act*: The button's element (`<button>`) is located and then selected by calling `Click`, which should increment the counter and update the content of the paragraph tag (`<p>`). The paragraph element text content is obtained by calling `TextContent`.

* *Assert*: `MarkupMatches` is called on the text content to verify that it matches the expected string, which is `Current count: 1`.

> [!NOTE]
> The `MarkupMatches` assert method differs from a regular string comparison assertion (for example, `Assert.Equal("Current count: 1", paraElmText);`) `MarkupMatches` performs a semantic comparison of the input and expected HTML markup. A semantic comparison is aware of HTML semantics, meaning things like insignificant whitespace is ignored. This results in more stable tests. For more information, see [Customizing the Semantic HTML Comparison](https://bunit.egilhansen.com/docs/verification/semantic-html-comparison).

## Additional resources

* [Getting Started with bUnit](https://bunit.egilhansen.com/docs/getting-started/): bUnit instructions include guidance on creating a test project, referencing testing framework packages, and building and running tests.

:::moniker-end

:::moniker range="< aspnetcore-5.0"

Testing is an important aspect of building stable and maintainable software.

To test a Razor component, the *component under test* (CUT) is:

* Rendered with relevant input for the test.
* Depending on the type of test performed, possibly subject to interaction or modification. For example, event handlers can be triggered, such as an `onclick` event for a button.
* Inspected for expected values.

## Test approaches

Two common approaches for testing Razor components are end-to-end (E2E) testing and unit testing:

* **Unit testing**: [Unit tests](/dotnet/core/testing/) are written with a unit testing library that provides:
  * Component rendering.
  * Inspection of component output and state.
  * Triggering of event handlers and life cycle methods.
  * Assertions that component behavior is correct.

  [bUnit](https://github.com/egil/bUnit) is an example of a library that enables Razor component unit testing.

* **E2E testing**: A test runner runs a Blazor app containing the CUT and automates a browser instance. The testing tool inspects and interacts with the CUT through the browser. [Playwright for .NET](https://playwright.dev/dotnet/) is an example of an E2E testing framework that can be used with Blazor apps.

In unit testing, only the Razor component (Razor/C#) is involved. External dependencies, such as services and JS interop, must be mocked. In E2E testing, the Razor component and all of its auxiliary infrastructure are part of the test, including CSS, JS, and the DOM and browser APIs.

*Test scope* describes how extensive the tests are. Test scope typically has an influence on the speed of the tests. Unit tests run on a subset of the app's subsystems and usually execute in milliseconds. E2E tests, which test a broad group of the app's subsystems, can take several seconds to complete. 

Unit testing also provides access to the instance of the CUT, allowing for inspection and verification of the component's internal state. This normally isn't possible in E2E testing.

With regard to the component's environment, E2E tests must make sure that the expected environmental state has been reached before verification starts. Otherwise, the result is unpredictable. In unit testing, the rendering of the CUT and the life cycle of the test are more integrated, which improves test stability.

E2E testing involves launching multiple processes, network and disk I/O, and other subsystem activity that often lead to poor test reliability. Unit tests are typically insulated from these sorts of issues.

The following table summarizes the difference between the two testing approaches.

| Capability                       | Unit testing                    | E2E testing                            |
| -------------------------------- | ------------------------------- | -------------------------------------- |
| Test scope                       | Razor component (Razor/C#) only | Razor component (Razor/C#) with CSS/JS |
| Test execution time              | Milliseconds                    | Seconds                                |
| Access to the component instance | Yes                             | No                                     |
| Sensitive to the environment     | No                              | Yes                                    |
| Reliability                      | More reliable                   | Less reliable                          |

## Choose the most appropriate test approach

Consider the scenario when choosing the type of testing to perform. Some considerations are described in the following table.

| Scenario | Suggested approach | Remarks |
| -------- | ------------------ | ------- |
| Component without JS interop logic | Unit testing | When there's no dependency on JS interop in a Razor component, the component can be tested without access to JS or the DOM API. In this scenario, there are no disadvantages to choosing unit testing. |
| Component with simple JS interop logic | Unit testing | It's common for components to query the DOM or trigger animations through JS interop. Unit testing is usually preferred in this scenario, since it's straightforward to mock the JS interaction through the <xref:Microsoft.JSInterop.IJSRuntime> interface. |
| Component that depends on complex JS code | Unit testing and separate JS testing | If a component uses JS interop to call a large or complex JS library but the interaction between the Razor component and JS library is simple, then the best approach is likely to treat the component and JS library or code as two separate parts and test each individually. Test the Razor component with a unit testing library, and test the JS with a JS testing library. |
| Component with logic that depends on JS manipulation of the browser DOM | E2E testing | When a component's functionality is dependent on JS and its manipulation of the DOM, verify both the JS and Blazor code together in an E2E test. This is the approach that the Blazor framework developers have taken with Blazor's browser rendering logic, which has tightly-coupled C# and JS code. The C# and JS code must work together to correctly render Razor components in a browser.
| Component that depends on 3rd party class library with hard-to-mock dependencies | E2E testing | When a component's functionality is dependent on a 3rd party class library that has hard-to-mock dependencies, such as JS interop, E2E testing might be the only option to test the component. |

## Test components with bUnit

There's no official Microsoft testing framework for Blazor, but the community-driven project [bUnit](https://github.com/egil/bUnit) provides a convenient way to unit test Razor components.

> [!NOTE]
> bUnit is a third-party testing library and isn't supported or maintained by Microsoft.

bUnit works with general-purpose testing frameworks, such as [MSTest](/dotnet/core/testing/unit-testing-with-mstest), [NUnit](https://nunit.org/), and [xUnit](https://xunit.net/). These testing frameworks make bUnit tests look and feel like regular unit tests. bUnit tests integrated with a general-purpose testing framework are ordinarily executed with:

* [Visual Studio's Test Explorer](/visualstudio/test/run-unit-tests-with-test-explorer).
* [`dotnet test`](/dotnet/core/tools/dotnet-test) CLI command in a command shell.
* An automated DevOps testing pipeline.

> [!NOTE]
> Test concepts and test implementations across different test frameworks are similar but not identical. Refer to the test framework's documentation for guidance.

The following demonstrates the structure of a bUnit test on the `Counter` component in an app based on a [Blazor project template](xref:blazor/project-structure). The `Counter` component displays and increments a counter based on the user selecting a button in the page:

```razor
@page "/counter"

<h1>Counter</h1>

<p>Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

@code {
    private int currentCount = 0;

    private void IncrementCount()
    {
        currentCount++;
    }
}
```

The following bUnit test verifies that the CUT's counter is incremented correctly when the button is selected:

```csharp
[Fact]
public void CounterShouldIncrementWhenSelected()
{
    // Arrange
    using var ctx = new TestContext();
    var cut = ctx.RenderComponent<Counter>();
    var paraElm = cut.Find("p");

    // Act
    cut.Find("button").Click();
    var paraElmText = paraElm.TextContent;

    // Assert
    paraElmText.MarkupMatches("Current count: 1");
}
```

The following actions take place at each step of the test:

* *Arrange*: The `Counter` component is rendered using bUnit's `TestContext`. The CUT's paragraph element (`<p>`) is found and assigned to `paraElm`.

* *Act*: The button's element (`<button>`) is located and then selected by calling `Click`, which should increment the counter and update the content of the paragraph tag (`<p>`). The paragraph element text content is obtained by calling `TextContent`.

* *Assert*: `MarkupMatches` is called on the text content to verify that it matches the expected string, which is `Current count: 1`.

> [!NOTE]
> The `MarkupMatches` assert method differs from a regular string comparison assertion (for example, `Assert.Equal("Current count: 1", paraElmText);`) `MarkupMatches` performs a semantic comparison of the input and expected HTML markup. A semantic comparison is aware of HTML semantics, meaning things like insignificant whitespace is ignored. This results in more stable tests. For more information, see [Customizing the Semantic HTML Comparison](https://bunit.egilhansen.com/docs/verification/semantic-html-comparison).

## Additional resources

* [Getting Started with bUnit](https://bunit.egilhansen.com/docs/getting-started/): bUnit instructions include guidance on creating a test project, referencing testing framework packages, and building and running tests.

:::moniker-end
