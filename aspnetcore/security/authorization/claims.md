---
title: Claims-based authorization in ASP.NET Core
author: rick-anderson
description: Learn how to add claims checks for authorization in an ASP.NET Core app.
ms.author: riande
monikerRange: '>= aspnetcore-3.1'
ms.date: 11/26/2021
uid: security/authorization/claims
---
# Claims-based authorization in ASP.NET Core

<a name="security-authorization-claims-based"></a>

:::moniker range=">= aspnetcore-6.0"

Коли сутність користувача створена, їй може бути призначена одна або більше заяв(claims), виданих довіренною стороною. Заява - це пара "імʼя - значення", що представляє сутність, не його функціонал. Наприклад, ви можете мати ліцензію водія, видану місцевим центром ліцензування. На ліцензії є ваша дата народження. В цьому випадку назвою заяви буде `DateOfBirth`, її значенням дата вашого дня народження, наприклад `8th June 1970` та видавцем буде центр ліцензування. Авторизація на заявах, просто кажучи, перевіряє значення заяви та дозволяє доступ до ресурсу на основі цього значення. Наприклад, якщо ви хочете потрапити в нічний клуб, процесс авторизації може бути наступним:

Охоронець може перевірити вас дивлячись на заявленний вік, та валідність підписника у вашому водійському посвіченні.

Сутність користувача може мати багато заяв з багатьма значеннями та може містити заяви одого типу.

## Додавання перевірок заяв

Перевірки авторизації на основі заяв:

* Є декларативними.
* Можуть бути застосовані до Razor Pages, контроллерів, або дій в контроллерах.
* ***Не*** можуть бути застосовані до сторінок Razor Pages на рівні обробника(handler), вони мають бути застосовані до сторінки.

В коді задається якими саме заявами та, за бажанням, їх значеннями має володіти користувач для доступу до ресурсу. Вимоги заяв основані на політиках, розробник має створити та зареєструвати політику, що виражає вимоги заяви.

Найпростіший тип політики заяви перевіряє її наявність, та не перевіряє її значення.

Створіть та зареєструйте політику, а після зробіть виклик <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A>. Реєстрація політики відбувається у конфігурації авторизації, зазвичай у файлі `Program.cs`:

[!code-csharp[](~/security/authorization/claims/samples/6.x/WebAll/Program.cs?name=snippet&highlight=6-9,23)]

В цьому випадку політика `EmployeeOnly` перевіряє наявність заяви `EmployeeNumber` поточної сутності користувача. 
Застосуйте політику використовуючи властивість `Policy` на аттрибуті [`[Authorize]`](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) щоб зазначити назву політики.

[!code-csharp[](~/security/authorization/claims/samples/6.x/WebAll/Controllers/Home2Controller.cs?name=snippet&highlight=1)]

Аттрибут `[Authorize]` можна застосувати до всьогго контроллера або сторінки Razor, у цьому випадку доступ до будь-якої дії на контролері дозволено лише особам, які відповідають політиці.

[!code-csharp[](~/security/authorization/claims/samples/6.x/WebAll/Controllers/VacationController.cs?name=snippet&highlight=1)]

Наступний код застосовує аттрибут `[Authorize]` до сторінки Razor: 

[!code-csharp[](~/security/authorization/claims/samples/6.x/WebAll/Pages/Index.cshtml.cs?name=snippet&highlight=1)]

Політики ***не*** можуть бути застосовані до Razor сторінки на рівні обробника, вони можуть бути застосовані до всієї сторінки.

Якщо ви маєте контроллер, що захищений атрибутом `[Authorize]`, але бажаєте дозволити доступ до певних єндпоінтів анонімним користувачам, можна скористатися атрибутом `AllowAnonymousAttribute`.

[!code-csharp[](~/security/authorization/claims/samples/6.x/WebAll/Controllers/VacationController.cs?name=snippet&highlight=14)]

Як було зазначено - політики ***не*** можуть бути застосовані до Razor сторінки на рівні обробника, але коли є така необхідність ми рекомендуємо використовувати контроллер. Решта додатку, що не потребує політик на рівні обробника Razor сторінки може використовувати Razor Pages.

Більшість заяв мають заповнене значення. Ви можете задати список дозволенних значень під час створення політики. Політика у наступному прикладі дозолить відфільтрувати запити і пропускати лише запити користувачів що мають номери 1,2,3,4 або 5. 

[!code-csharp[](~/security/authorization/claims/samples/6.x/WebAll/Program.cs?name=snippet2&highlight=6-10)]

### Додання узагальненої перевірки заяв

Якщо значення заяви не є одиничним, або потребує певної трансформації, використовуйте <xref:Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireAssertion%2A>. Для біль детальної інформації, дивіться [Use a func to fulfill a policy](xref:security/authorization/policies#use-a-func-to-fulfill-a-policy).

## Використання декількох політик

Якщо ви застосовуєте декілька політик до контроллера чи ендпоінта, то всі політики мають виконуватись запитом до видачі доступа. Наприклад:

[!code-csharp[](~/security/authorization/claims/samples/6.x/WebAll/Controllers/SalaryController.cs?name=snippet&highlight=1,14)]

У цьому прикладі будь-який користовач, що відповідає політиці `EmployeeOnly` може отримати доступ до ендпоінту `Payslip`, тому що ця політика застосована до всього контроллеру. Однак для того щоб викликати ендпоінт `UpdateSalary` користувач має відповідати обидвом політикам - `EmployeeOnly` та `HumanResources`.

Якщо ви хочете додати більш складні політики, такі як обмеження доступу для користувачів молодше 21 року на основі заяви з датою народження користувача 
 [custom policy handlers](xref:security/authorization/policies).
 
 В наступному прикладі, для доступу до двох методів користувач має задовільняти обидві політики - `EmployeeOnly` та `HumanResources`:
 
[!code-csharp[](~/security/authorization/claims/samples/6.x/WebAll/Pages/X/Salary.cshtml.cs?name=snippet&highlight=1,2)] 

:::moniker-end

:::moniker range="= aspnetcore-5.0"

When an identity is created it may be assigned one or more claims issued by a trusted party. A claim is a name value pair that represents what the subject is, not what the subject can do. For example, you may have a driver's license, issued by a local driving license authority. Your driver's license has your date of birth on it. In this case the claim name would be `DateOfBirth`, the claim value would be your date of birth, for example `8th June 1970` and the issuer would be the driving license authority. Claims based authorization, at its simplest, checks the value of a claim and allows access to a resource based upon that value. For example if you want access to a night club the authorization process might be:

The door security officer would evaluate the value of your date of birth claim and whether they trust the issuer (the driving license authority) before granting you access.

An identity can contain multiple claims with multiple values and can contain multiple claims of the same type.

## Adding claims checks

Claim based authorization checks are declarative - the developer embeds them within their code, against a controller or an action within a controller, specifying claims which the current user must possess, and optionally the value the claim must hold to access the requested resource. Claims requirements are policy based, the developer must build and register a policy expressing the claims requirements.

The simplest type of claim policy looks for the presence of a claim and doesn't check the value.

Build and register the policy. This takes place as part of the Authorization service configuration, which normally takes part in `ConfigureServices()` in your `Startup.cs` file.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllersWithViews();
    services.AddRazorPages();

    services.AddAuthorization(options =>
    {
        options.AddPolicy("EmployeeOnly", policy => policy.RequireClaim("EmployeeNumber"));
    });
}
```

Call <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A> in `Configure`. The following code is generated by the ASP.NET Core web app templates:

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        app.UseMigrationsEndPoint();
    }
    else
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapRazorPages();
    });
}
```

In this case the `EmployeeOnly` policy checks for the presence of an `EmployeeNumber` claim on the current identity.

You then apply the policy using the `Policy` property on the `[Authorize]` attribute to specify the policy name;

```csharp
[Authorize(Policy = "EmployeeOnly")]
public IActionResult VacationBalance()
{
    return View();
}
```

The `[Authorize]` attribute can be applied to an entire controller, in this instance only identities matching the policy will be allowed access to any Action on the controller.

```csharp
[Authorize(Policy = "EmployeeOnly")]
public class VacationController : Controller
{
    public ActionResult VacationBalance()
    {
    }
}
```

If you have a controller that's protected by the `[Authorize]` attribute, but want to allow anonymous access to particular actions you apply the `AllowAnonymousAttribute` attribute.

```csharp
[Authorize(Policy = "EmployeeOnly")]
public class VacationController : Controller
{
    public ActionResult VacationBalance()
    {
    }

    [AllowAnonymous]
    public ActionResult VacationPolicy()
    {
    }
}
```

Most claims come with a value. You can specify a list of allowed values when creating the policy. The following example would only succeed for employees whose employee number was 1, 2, 3, 4 or 5.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllersWithViews();
    services.AddRazorPages();

    services.AddAuthorization(options =>
    {
        options.AddPolicy("Founders", policy =>
                          policy.RequireClaim("EmployeeNumber", "1", "2", "3", "4", "5"));
    });
}
```

### Add a generic claim check

If the claim value isn't a single value or a transformation is required, use <xref:Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireAssertion%2A>. For more information, see [Use a func to fulfill a policy](xref:security/authorization/policies#use-a-func-to-fulfill-a-policy).

## Multiple Policy Evaluation

If you apply multiple policies to a controller or action, then all policies must pass before access is granted. For example:

```csharp
[Authorize(Policy = "EmployeeOnly")]
public class SalaryController : Controller
{
    public ActionResult Payslip()
    {
    }

    [Authorize(Policy = "HumanResources")]
    public ActionResult UpdateSalary()
    {
    }
}
```

In the above example any identity which fulfills the `EmployeeOnly` policy can access the `Payslip` action as that policy is enforced on the controller. However in order to call the `UpdateSalary` action the identity must fulfill *both* the `EmployeeOnly` policy and the `HumanResources` policy.

If you want more complicated policies, such as taking a date of birth claim, calculating an age from it then checking the age is 21 or older then you need to write [custom policy handlers](xref:security/authorization/policies).

:::moniker-end

:::moniker range="= aspnetcore-3.1"

When an identity is created it may be assigned one or more claims issued by a trusted party. A claim is a name value pair that represents what the subject is, not what the subject can do. For example, you may have a driver's license, issued by a local driving license authority. Your driver's license has your date of birth on it. In this case the claim name would be `DateOfBirth`, the claim value would be your date of birth, for example `8th June 1970` and the issuer would be the driving license authority. Claims based authorization, at its simplest, checks the value of a claim and allows access to a resource based upon that value. For example if you want access to a night club the authorization process might be:

The door security officer would evaluate the value of your date of birth claim and whether they trust the issuer (the driving license authority) before granting you access.

An identity can contain multiple claims with multiple values and can contain multiple claims of the same type.

## Adding claims checks

Claim based authorization checks are declarative - the developer embeds them within their code, against a controller or an action within a controller, specifying claims which the current user must possess, and optionally the value the claim must hold to access the requested resource. Claims requirements are policy based, the developer must build and register a policy expressing the claims requirements.

The simplest type of claim policy looks for the presence of a claim and doesn't check the value.

Build and register the policy. This takes place as part of the Authorization service configuration, which normally takes part in `ConfigureServices()` in your `Startup.cs` file.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllersWithViews();
    services.AddRazorPages();

    services.AddAuthorization(options =>
    {
        options.AddPolicy("EmployeeOnly", policy => policy.RequireClaim("EmployeeNumber"));
    });
}
```

In this case the `EmployeeOnly` policy checks for the presence of an `EmployeeNumber` claim on the current identity.

You then apply the policy using the `Policy` property on the `[Authorize]` attribute to specify the policy name;

```csharp
[Authorize(Policy = "EmployeeOnly")]
public IActionResult VacationBalance()
{
    return View();
}
```

The `[Authorize]` attribute can be applied to an entire controller, in this instance only identities matching the policy will be allowed access to any Action on the controller.

```csharp
[Authorize(Policy = "EmployeeOnly")]
public class VacationController : Controller
{
    public ActionResult VacationBalance()
    {
    }
}
```

If you have a controller that's protected by the `[Authorize]` attribute, but want to allow anonymous access to particular actions you apply the `AllowAnonymousAttribute` attribute.

```csharp
[Authorize(Policy = "EmployeeOnly")]
public class VacationController : Controller
{
    public ActionResult VacationBalance()
    {
    }

    [AllowAnonymous]
    public ActionResult VacationPolicy()
    {
    }
}
```

Most claims come with a value. You can specify a list of allowed values when creating the policy. The following example would only succeed for employees whose employee number was 1, 2, 3, 4 or 5.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllersWithViews();
    services.AddRazorPages();

    services.AddAuthorization(options =>
    {
        options.AddPolicy("Founders", policy =>
                          policy.RequireClaim("EmployeeNumber", "1", "2", "3", "4", "5"));
    });
}
```

### Add a generic claim check

If the claim value isn't a single value or a transformation is required, use <xref:Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireAssertion%2A>. For more information, see [Use a func to fulfill a policy](xref:security/authorization/policies#use-a-func-to-fulfill-a-policy).

## Multiple Policy Evaluation

If you apply multiple policies to a controller or action, then all policies must pass before access is granted. For example:

```csharp
[Authorize(Policy = "EmployeeOnly")]
public class SalaryController : Controller
{
    public ActionResult Payslip()
    {
    }

    [Authorize(Policy = "HumanResources")]
    public ActionResult UpdateSalary()
    {
    }
}
```

In the above example any identity which fulfills the `EmployeeOnly` policy can access the `Payslip` action as that policy is enforced on the controller. However in order to call the `UpdateSalary` action the identity must fulfill *both* the `EmployeeOnly` policy and the `HumanResources` policy.

If you want more complicated policies, such as taking a date of birth claim, calculating an age from it then checking the age is 21 or older then you need to write [custom policy handlers](xref:security/authorization/policies).

:::moniker-end
