---
title: "OData Expand"
author: FIVIL
description: Using OData expand to query related data
ms.author: riande
ms.custom: mvc
ms.date: 4/5/2019
uid: web-api/advanced/odata-expand
---

# OData Expand

By [FIVIL](https://twitter.com/F_IVI_L) and [Rick Anderson](https://twitter.com/RickAndMSFT)

This article demonstrates querying related entities using [OData](https://www.odata.org/).

The [ContosoUniversity sample](https://github.com/aspnet/AspNetCore.Docs/tree/master/aspnetcore/data/ef-rp/intro/samples/cu21) is used for the starter project.

A malicious or naive client may construct a query that consumes excessive resources. Such a query can disrupt access to your service. Review <xref:web-api/advanced/odata-security> before starting this tutorial.

## Enable OData

Update *Startup.cs* with the following highlighted code:

[!code-csharp[](odata-advanced/sample/odata-expand/Startup.cs?highlight=19,36-40&name=snippet)]

The preceding  code:

* Calls `services.AddOData();` to enable OData middleware.
* Calls `routeBuilder.Expand().Select()` to enable querying related entities with OData.

## Add a controller

Create new Controller named `EnrollmentController` and with the following action:

[!code-csharp[](odata-advanced/sample/odata-expand/Controllers/EnrollmentController.cs?name=snippet_EnableQuery)]

The preceding code enables OData queries and returns enrollment entities `SchoolContext`.

## $expand

OData `expand` functionality can be used to query related data. For example, to get the *Course* data for each *Enrollment* entity, include `?$expand=course` at the end of the request path:

This tutorial uses Postman to test the web API.

* Install [Postman](https://www.getpostman.com/apps)
* Start the web app.
* Start Postman.
* Disable **SSL certificate verification**
  
  * From  **File > Settings** (**General* tab), disable **SSL certificate verification**.
    > [!WARNING]
    > Re-enable SSL certificate verification after testing the controller.

* Create a new request.
  * Set the HTTP method to `GET`.
  * Set the request URL to `https://localhost:5001/api/Enrollment/?$expand=course($expand=Department)`. Change the port as necessary.
* Select **Send**.
* The *Course* data for each *Enrollment* entity is included in the response.

## Expand depth

Expand can be applied to more than one level of navigation property. For example, to get the *Department* data of each *Course* for each *Enrollment* entity, include `?$expand=course($expand=Department)` at the end of the request path. The following JSON shows a portion of the output:

```json
[
    {
        "Course": {
            "Department": {
                "DepartmentID": 3,
                "Name": "Engineering",
                "Budget": 350000,
                "StartDate": "2007-09-01T00:00:00",
                "InstructorID": 3
            },
            "CourseID": 1050,
            "Title": "Chemistry",
            "Credits": 3,
            "DepartmentID": 3
        },
        "EnrollmentID": 1,
        "CourseID": 1050,
        "StudentID": 1,
        "Grade": 0
    },
    {
        "Course": {
            <!-- Deleted for brevity -->
]
```

By default, Web API allows the maximum expansion depth of two. To override the default, set the `MaxExpansionDepth` property on the `[EnableQuery]` attribute.

## Security concerns

Consider disallowing expand:

* On sensitive data for security reasons.
* On non-trivial data sets for performance reasons.

In this section, code is added to prevent querying `CourseAssignments` related data.

Override `SelectExpandQueryValidator` to prevent `$expand=CourseAssignments`. Create a new class named `MyExpandValidator` with the following code:

[!code-csharp[](odata-advanced/sample/odata-expand/ODataValidators/MyExpandValidator.cs?name=snippet)]

The preceding code throws an exception if `$expand` is used with `CourseAssignments`.

Create a new class named `MyEnableQueryAttribute` with the following code:

[!code-csharp[](odata-advanced/sample/odata-expand/ODataValidators/MyEnableQueryAttribute.cs?name=snippet)]

The preceding code creates the `MyEnableQuery` attribute. The `MyEnableQuery` attribute adds the `MyExpandValidator`, which prevents `$expand=CourseAssignments`

Replace the `EnableQuery` attribute with `MyEnableQuery` attribute in the `EnrollmentController`:

[!code-csharp[](odata-advanced/sample/odata-expand/Controllers/EnrollmentController.cs?name=snippet_MyEnableQuery)]

In Postman:

* Send the previous `Get` request `https://localhost:5001/api/Enrollment/?$expand=course($expand=Department)`. The request returns data because `($expand=Department)` is not prohibited.
* Send a `Get` request for with `($expand=CourseAssignments)`. For example, `https://localhost:5001/api/Enrollment/?$expand=course($expand=CourseAssignments)`

 The preceding query returns `400 Bad Request`.