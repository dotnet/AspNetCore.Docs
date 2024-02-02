---
title: ASP.NET Core built-in Razor components
author: guardrex
description: Find information on Razor components provided by the Blazor framework.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/14/2023
uid: blazor/components/built-in-components
---
# ASP.NET Core built-in Razor components

[!INCLUDE[](~/includes/not-latest-version.md)]

The following built-in Razor components are provided by the Blazor framework. For more information on built-in components that are used by the Blazor project templates, see <xref:blazor/project-structure>.

:::moniker range=">= aspnetcore-8.0"

<!-- Link for FormMappingValidator. Addition to docs tracked by 
     https://github.com/dotnet/AspNetCore.Docs/issues/31621

* [`FormMappingValidator`](xref:blazor/forms/validation#validation-summary-and-validation-message-components)
-->

* [`App`](xref:blazor/project-structure)
* [`AntiforgeryToken`](xref:blazor/forms/index#antiforgery-support)
* [`Authentication`](xref:blazor/security/webassembly/index#authentication-component)
* [`AuthorizeView`](xref:blazor/security/index#authorizeview-component)
* [`CascadingValue`](xref:blazor/components/cascading-values-and-parameters#cascadingvalue-component)
* [`DataAnnotationsValidator`](xref:blazor/forms/validation#data-annotations-validator-component-and-custom-validation)
* [`DynamicComponent`](xref:blazor/components/dynamiccomponent)
* [`Editor<T>`](xref:blazor/forms/binding#nest-and-bind-forms)
* [`EditForm`](xref:blazor/forms/binding#editformeditcontext-model)
* [`ErrorBoundary`](xref:blazor/fundamentals/handle-errors#error-boundaries)
* [`FocusOnNavigate`](xref:blazor/fundamentals/routing#focus-an-element-on-navigation)
* [`HeadContent`](xref:blazor/components/control-head-content)
* [`HeadOutlet`](xref:blazor/components/control-head-content)
* [`InputCheckbox`](xref:blazor/forms/input-components)
* [`InputDate`](xref:blazor/forms/input-components)
* [`InputFile`](xref:blazor/file-uploads)
* [`InputNumber`](xref:blazor/forms/input-components)
* [`InputRadio`](xref:blazor/forms/input-components)
* [`InputRadioGroup`](xref:blazor/forms/input-components)
* [`InputSelect`](xref:blazor/forms/input-components)
* [`InputText`](xref:blazor/forms/input-components)
* [`InputTextArea`](xref:blazor/forms/input-components)
* [`LayoutView`](xref:blazor/components/layouts#apply-a-layout-to-arbitrary-content-layoutview-component)
* [`MainLayout`](xref:blazor/components/layouts#mainlayout-component)
* [`NavLink`](xref:blazor/fundamentals/routing#navlink-and-navmenu-components)
* [`NavMenu`](xref:blazor/fundamentals/routing#navlink-and-navmenu-components)
* [`PageTitle`](xref:blazor/components/control-head-content)
* [`QuickGrid`](xref:blazor/components/quickgrid)
* [`Router`](xref:blazor/fundamentals/routing#route-templates)
* [`RouteView`](xref:blazor/fundamentals/routing#route-templates)
* [`SectionContent`](xref:blazor/components/sections)
* [`SectionOutlet`](xref:blazor/components/sections)
* [`ValidationSummary`](xref:blazor/forms/validation#validation-summary-and-validation-message-components)
* [`Virtualize`](xref:blazor/components/virtualization)

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

* [`App`](xref:blazor/project-structure)
* [`Authentication`](xref:blazor/security/webassembly/index#authentication-component)
* [`AuthorizeView`](xref:blazor/security/index#authorizeview-component)
* [`CascadingValue`](xref:blazor/components/cascading-values-and-parameters#cascadingvalue-component)
* [`DataAnnotationsValidator`](xref:blazor/forms/validation#data-annotations-validator-component-and-custom-validation)
* [`DynamicComponent`](xref:blazor/components/dynamiccomponent)
* [`EditForm`](xref:blazor/forms/binding#editformeditcontext-model)
* [`ErrorBoundary`](xref:blazor/fundamentals/handle-errors#error-boundaries)
* [`FocusOnNavigate`](xref:blazor/fundamentals/routing#focus-an-element-on-navigation)
* [`HeadContent`](xref:blazor/components/control-head-content)
* [`HeadOutlet`](xref:blazor/components/control-head-content)
* [`InputCheckbox`](xref:blazor/forms/input-components)
* [`InputDate`](xref:blazor/forms/input-components)
* [`InputFile`](xref:blazor/file-uploads)
* [`InputNumber`](xref:blazor/forms/input-components)
* [`InputRadio`](xref:blazor/forms/input-components)
* [`InputRadioGroup`](xref:blazor/forms/input-components)
* [`InputSelect`](xref:blazor/forms/input-components)
* [`InputText`](xref:blazor/forms/input-components)
* [`InputTextArea`](xref:blazor/forms/input-components)
* [`LayoutView`](xref:blazor/components/layouts#apply-a-layout-to-arbitrary-content-layoutview-component)
* [`MainLayout`](xref:blazor/components/layouts#mainlayout-component)
* [`NavLink`](xref:blazor/fundamentals/routing#navlink-and-navmenu-components)
* [`NavMenu`](xref:blazor/fundamentals/routing#navlink-and-navmenu-components)
* [`PageTitle`](xref:blazor/components/control-head-content)
* [`QuickGrid`](xref:blazor/components/quickgrid)
* [`Router`](xref:blazor/fundamentals/routing#route-templates)
* [`RouteView`](xref:blazor/fundamentals/routing#route-templates)
* [`ValidationSummary`](xref:blazor/forms/validation#validation-summary-and-validation-message-components)
* [`Virtualize`](xref:blazor/components/virtualization)

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

* [`App`](xref:blazor/project-structure)
* [`Authentication`](xref:blazor/security/webassembly/index#authentication-component)
* [`AuthorizeView`](xref:blazor/security/index#authorizeview-component)
* [`CascadingValue`](xref:blazor/components/cascading-values-and-parameters#cascadingvalue-component)
* [`DataAnnotationsValidator`](xref:blazor/forms/validation#data-annotations-validator-component-and-custom-validation)
* [`DynamicComponent`](xref:blazor/components/dynamiccomponent)
* [`EditForm`](xref:blazor/forms/binding#editformeditcontext-model)
* [`ErrorBoundary`](xref:blazor/fundamentals/handle-errors#error-boundaries)
* [`FocusOnNavigate`](xref:blazor/fundamentals/routing#focus-an-element-on-navigation)
* [`HeadContent`](xref:blazor/components/control-head-content)
* [`HeadOutlet`](xref:blazor/components/control-head-content)
* [`InputCheckbox`](xref:blazor/forms/input-components)
* [`InputDate`](xref:blazor/forms/input-components)
* [`InputFile`](xref:blazor/file-uploads)
* [`InputNumber`](xref:blazor/forms/input-components)
* [`InputRadio`](xref:blazor/forms/input-components)
* [`InputRadioGroup`](xref:blazor/forms/input-components)
* [`InputSelect`](xref:blazor/forms/input-components)
* [`InputText`](xref:blazor/forms/input-components)
* [`InputTextArea`](xref:blazor/forms/input-components)
* [`LayoutView`](xref:blazor/components/layouts#apply-a-layout-to-arbitrary-content-layoutview-component)
* [`MainLayout`](xref:blazor/components/layouts#mainlayout-component)
* [`NavLink`](xref:blazor/fundamentals/routing#navlink-and-navmenu-components)
* [`NavMenu`](xref:blazor/fundamentals/routing#navlink-and-navmenu-components)
* [`PageTitle`](xref:blazor/components/control-head-content)
* [`Router`](xref:blazor/fundamentals/routing#route-templates)
* [`RouteView`](xref:blazor/fundamentals/routing#route-templates)
* [`ValidationSummary`](xref:blazor/forms/validation#validation-summary-and-validation-message-components)
* [`Virtualize`](xref:blazor/components/virtualization)

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

* [`App`](xref:blazor/project-structure)
* [`Authentication`](xref:blazor/security/webassembly/index#authentication-component)
* [`AuthorizeView`](xref:blazor/security/index#authorizeview-component)
* [`CascadingValue`](xref:blazor/components/cascading-values-and-parameters#cascadingvalue-component)
* [`DataAnnotationsValidator`](xref:blazor/forms/validation#data-annotations-validator-component-and-custom-validation)
* [`EditForm`](xref:blazor/forms/binding#editformeditcontext-model)
* [`InputCheckbox`](xref:blazor/forms/input-components)
* [`InputDate`](xref:blazor/forms/input-components)
* [`InputFile`](xref:blazor/file-uploads)
* [`InputNumber`](xref:blazor/forms/input-components)
* [`InputRadio`](xref:blazor/forms/input-components)
* [`InputRadioGroup`](xref:blazor/forms/input-components)
* [`InputSelect`](xref:blazor/forms/input-components)
* [`InputText`](xref:blazor/forms/input-components)
* [`InputTextArea`](xref:blazor/forms/input-components)
* [`LayoutView`](xref:blazor/components/layouts#apply-a-layout-to-arbitrary-content-layoutview-component)
* [`MainLayout`](xref:blazor/components/layouts#mainlayout-component)
* [`NavLink`](xref:blazor/fundamentals/routing#navlink-and-navmenu-components)
* [`NavMenu`](xref:blazor/fundamentals/routing#navlink-and-navmenu-components)
* [`Router`](xref:blazor/fundamentals/routing#route-templates)
* [`RouteView`](xref:blazor/fundamentals/routing#route-templates)
* [`ValidationSummary`](xref:blazor/forms/validation#validation-summary-and-validation-message-components)
* [`Virtualize`](xref:blazor/components/virtualization)

:::moniker-end

:::moniker range="< aspnetcore-5.0"

* [`App`](xref:blazor/project-structure)
* [`Authentication`](xref:blazor/security/webassembly/index#authentication-component)
* [`AuthorizeView`](xref:blazor/security/index#authorizeview-component)
* [`CascadingValue`](xref:blazor/components/cascading-values-and-parameters#cascadingvalue-component)
* [`DataAnnotationsValidator`](xref:blazor/forms/validation#data-annotations-validator-component-and-custom-validation)
* [`EditForm`](xref:blazor/forms/binding#editformeditcontext-model)
* [`InputCheckbox`](xref:blazor/forms/input-components)
* [`InputDate`](xref:blazor/forms/input-components)
* [`InputNumber`](xref:blazor/forms/input-components)
* [`InputRadio`](xref:blazor/forms/input-components)
* [`InputRadioGroup`](xref:blazor/forms/input-components)
* [`InputSelect`](xref:blazor/forms/input-components)
* [`InputText`](xref:blazor/forms/input-components)
* [`InputTextArea`](xref:blazor/forms/input-components)
* [`LayoutView`](xref:blazor/components/layouts#apply-a-layout-to-arbitrary-content-layoutview-component)
* [`MainLayout`](xref:blazor/components/layouts#mainlayout-component)
* [`NavLink`](xref:blazor/fundamentals/routing#navlink-and-navmenu-components)
* [`NavMenu`](xref:blazor/fundamentals/routing#navlink-and-navmenu-components)
* [`Router`](xref:blazor/fundamentals/routing#route-templates)
* [`RouteView`](xref:blazor/fundamentals/routing#route-templates)
* [`ValidationSummary`](xref:blazor/forms/validation#validation-summary-and-validation-message-components)

:::moniker-end
