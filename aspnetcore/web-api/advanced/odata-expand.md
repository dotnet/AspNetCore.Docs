---
title: "OData Expand"
#author: 
description: Using OData expand to query related data
#ms.author: riande
ms.custom: mvc
ms.date: 4/5/2019
uid: web-api/advanced/odata-expand
---

# OData Expand

By [FIVIL](https://twitter.com/F_IVI_L) 

This tutorial demonstrates how you can query related entities using OData.

For this tutorial we use [ContosoUniversity sample](https://github.com/aspnet/AspNetCore.Docs/tree/master/aspnetcore/data/ef-rp/intro/samples/cu21) as a base project model.

## Configure middleware

Update the `Configure` method in *Startup.cs* with the following highlighted code:

[!code-csharp[](odata-advanced/sample/odata-expand/Startup.cs?highlight=57-61,37)]

Using **expand** you can query related entities in OData.

## Adding a controller

Create new Controller named `EnrollmentController` and add new action like:

[!code-csharp[](odata-advanced/sample/odata-expand/Controllers/EnrollmentController.cs?name=snippet_EnableQuery)]

## $expand

You can use OData **expand** functionality to query related data. For example, to get the *Course* data for each *Enrollment* entity, include `?$expand=course` at the end of your request path:

This tutorial uses Postman to test the web API.

* Install [Postman](https://www.getpostman.com/apps)
* Start the web app.
* Start Postman.
* Disable **SSL certificate verification**
  
  * From  **File > Settings** (**General* tab), disable **SSL certificate verification**.
    > [!WARNING]
    > Re-enable SSL certificate verification after testing the controller.

* Create a new request.
  * Set the HTTP method to **GET**.
  * Set the request URL to `https://localhost:<port>/api/Enrollment/GetEnrollments?$expand=course`.
* Select **Send**.
* You can now see that the *Course* data for each *Enrollment* entity is now included int the response.

```json
[
    {
        "Course": {
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
            "CourseID": 4022,
            "Title": "Microeconomics",
            "Credits": 3,
            "DepartmentID": 4
        },
        "EnrollmentID": 2,
        "CourseID": 4022,
        "StudentID": 1,
        "Grade": 2
    },
    {
        "Course": {
            "CourseID": 4041,
            "Title": "Macroeconomics",
            "Credits": 3,
            "DepartmentID": 4
        },
        "EnrollmentID": 3,
        "CourseID": 4041,
        "StudentID": 1,
        "Grade": 1
    },
    {
        "Course": {
            "CourseID": 1045,
            "Title": "Calculus",
            "Credits": 4,
            "DepartmentID": 2
        },
        "EnrollmentID": 4,
        "CourseID": 1045,
        "StudentID": 2,
        "Grade": 1
    },
    {
        "Course": {
            "CourseID": 3141,
            "Title": "Trigonometry",
            "Credits": 4,
            "DepartmentID": 2
        },
        "EnrollmentID": 5,
        "CourseID": 3141,
        "StudentID": 2,
        "Grade": 1
    },
    {
        "Course": {
            "CourseID": 2021,
            "Title": "Composition",
            "Credits": 3,
            "DepartmentID": 1
        },
        "EnrollmentID": 6,
        "CourseID": 2021,
        "StudentID": 2,
        "Grade": 1
    },
    {
        "Course": {
            "CourseID": 1050,
            "Title": "Chemistry",
            "Credits": 3,
            "DepartmentID": 3
        },
        "EnrollmentID": 7,
        "CourseID": 1050,
        "StudentID": 3,
        "Grade": null
    },
    {
        "Course": {
            "CourseID": 4022,
            "Title": "Microeconomics",
            "Credits": 3,
            "DepartmentID": 4
        },
        "EnrollmentID": 8,
        "CourseID": 4022,
        "StudentID": 3,
        "Grade": 1
    },
    {
        "Course": {
            "CourseID": 1050,
            "Title": "Chemistry",
            "Credits": 3,
            "DepartmentID": 3
        },
        "EnrollmentID": 9,
        "CourseID": 1050,
        "StudentID": 4,
        "Grade": 1
    },
    {
        "Course": {
            "CourseID": 2021,
            "Title": "Composition",
            "Credits": 3,
            "DepartmentID": 1
        },
        "EnrollmentID": 10,
        "CourseID": 2021,
        "StudentID": 5,
        "Grade": 1
    },
    {
        "Course": {
            "CourseID": 2042,
            "Title": "Literature",
            "Credits": 4,
            "DepartmentID": 1
        },
        "EnrollmentID": 11,
        "CourseID": 2042,
        "StudentID": 6,
        "Grade": 1
    }
]
```

## Customizing related data

You can customize and use other OData functionalities over your related data using **Parentheses** in your *expand* clause. For example, to get only the *Title* and *Credits* of each *Course*, add `?$expand=course($select=Title,Credits)` at the end of your request path:

```json
[
    {
        "Course": {
            "Title": "Chemistry",
            "Credits": 3
        },
        "EnrollmentID": 1,
        "CourseID": 1050,
        "StudentID": 1,
        "Grade": 0
    },
    {
        "Course": {
            "Title": "Microeconomics",
            "Credits": 3
        },
        "EnrollmentID": 2,
        "CourseID": 4022,
        "StudentID": 1,
        "Grade": 2
    },
    {
        "Course": {
            "Title": "Macroeconomics",
            "Credits": 3
        },
        "EnrollmentID": 3,
        "CourseID": 4041,
        "StudentID": 1,
        "Grade": 1
    },
    {
        "Course": {
            "Title": "Calculus",
            "Credits": 4
        },
        "EnrollmentID": 4,
        "CourseID": 1045,
        "StudentID": 2,
        "Grade": 1
    },
    {
        "Course": {
            "Title": "Trigonometry",
            "Credits": 4
        },
        "EnrollmentID": 5,
        "CourseID": 3141,
        "StudentID": 2,
        "Grade": 1
    },
    {
        "Course": {
            "Title": "Composition",
            "Credits": 3
        },
        "EnrollmentID": 6,
        "CourseID": 2021,
        "StudentID": 2,
        "Grade": 1
    },
    {
        "Course": {
            "Title": "Chemistry",
            "Credits": 3
        },
        "EnrollmentID": 7,
        "CourseID": 1050,
        "StudentID": 3,
        "Grade": null
    },
    {
        "Course": {
            "Title": "Microeconomics",
            "Credits": 3
        },
        "EnrollmentID": 8,
        "CourseID": 4022,
        "StudentID": 3,
        "Grade": 1
    },
    {
        "Course": {
            "Title": "Chemistry",
            "Credits": 3
        },
        "EnrollmentID": 9,
        "CourseID": 1050,
        "StudentID": 4,
        "Grade": 1
    },
    {
        "Course": {
            "Title": "Composition",
            "Credits": 3
        },
        "EnrollmentID": 10,
        "CourseID": 2021,
        "StudentID": 5,
        "Grade": 1
    },
    {
        "Course": {
            "Title": "Literature",
            "Credits": 4
        },
        "EnrollmentID": 11,
        "CourseID": 2042,
        "StudentID": 6,
        "Grade": 1
    }
]
```
 