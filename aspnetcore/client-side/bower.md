---
title: Using Bower in ASP.NET Core | Microsoft Docs
author: rick-anderson
description: Manging client-side packages with Bower.
keywords: ASP.NET Core, bower
ms.author: riande
manager: wpickett
ms.date: 02/14/2017
ms.topic: article
ms.assetid: df7c43da-280e-4df6-86cb-eecec8f12bfc
ms.technology: aspnet
ms.prod: asp.net-core
uid: client-side/bower
ms.custom: H1Hack27Feb2017
---
# Manage client-side packages with Bower in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT), [Noel Rice](http://blog.falafel.com/author/noel-rice/), and [Scott Addie](https://scottaddie.com) 

[Bower](https://bower.io/) 는 스스로를 "웹을 위한 패키지 관리자"라고 부릅니다. .NET 에코시스템에서 Bower는 정적 콘텐츠 파일을 효과적으로 배포하지 못하는 NuGet으로 인한 공백을 보완해줍니다. ASP.NET Core 프로젝트의 경우, 이런 정적 파일들은 [jQuery](http://jquery.com/)나 [Bootstrap](http://getbootstrap.com/) 같은 클라이언트 측 라이브러리에 해당합니다. .NET 라이브러리는 계속해서 [NuGet](https://nuget.org/) 패키지 관리자를 사용하면 됩니다.

ASP.NET Core 프로젝트 템플릿으로 만들어지는 새 프로젝트는 클라이언트 측 빌드 프로세스를 설정합니다. [jQuery](http://jquery.com/)와 [Bootstrap](http://getbootstrap.com/)이 설치되고 Bower가 지원됩니다.

클라이언트 측 패키지는 *bower.json* 파일에 정리된 목록으로 관리됩니다. ASP.NET Core 프로젝트 템플릿은 jQuery, jQuery 유효성 검사, 그리고 Bootstrap을 *bower.json* 파일에 구성합니다.

본문에서는 [Font Awesome](http://fontawesome.io)에 대한 지원을 추가해볼 것입니다. Bower 패키지는 **Bower 패키지 관리** UI를 이용하거나 *bower.json* 파일을 직접 편집해서 설치할 수 있습니다. 

### Bower 패키지 관리 UI를 이용한 설치 

* **ASP.NET Core 웹 응용 프로그램 (.NET Core)** 템플릿으로 새로운 ASP.NET Core 웹 응용 프로그램을 생성합니다. 이때, *웹 응용 프로그램* 템플릿과 *인증 안 함* 옵션을 선택합니다.

* 솔루션 탐색기에서 마우스 오른쪽 버튼으로 프로젝트를 클릭한 다음, **Bower 패키지 관리**를 선택합니다 (또는 메인 메뉴에서 **프로젝트** > **Bower 패키지 관리**를 선택해도 됩니다).

* **Bower: <프로젝트 이름>** 창에서, "찾아보기" 탭을 클릭한 다음, 검색 상자에 `font-awesome`을 입력해서 패키지 목록을 필터링합니다: 

![manage bower packages](bower/_static/manage-bower-packages.png)

* "*bower.json*에 변경 내용 저장(Save changes to bower.json)" 체크상자가 체크되어 있는지 확인합니다. 드롭다운 목록에서 버전을 선택하고 **설치** 버튼을 클릭합니다. 설치에 관한 자세한 정보가 **출력** 창에 나타납니다. 

### bower.json 파일에서 직접 설치 

*bower.json* 파일을 열고 dependencies 섹션에 "font-awesome" 항목을 추가합니다. 그러면 IntelliSense가 사용 가능한 패키지들을 보여줍니다. 패키지를 선택하고 나면 이번에는 사용 가능한 버전들이 나타납니다. 다음 그림에 나타나 있는 버전들은 오래 전에 캡처한 것이므로 여러분이 직접 보게될 버전은 다른 버전일 것입니다.

![IntelliSense of bower package explorer](bower/_static/add-package.png)

![bower version IntelliSense](bower/_static/version-IntelliSense.png)

Bower는 [유의적 버전 관리](http://semver.org/) 방식으로 종속성을 구성합니다. SemVer라고도 알려져 있는 유의적 버전 관리 방식은 \<주>.\<부>.\<패치> 번호 매기기 체계를 사용해서 패키지를 식별합니다. IntelliSense는 몇 가지 일반적인 버전들만 간추려서 보여주는 방식으로 유의적 버전 관리를 단순화시켜줍니다. IntelliSense 목록의 가장 첫 번째 항목은 (위의 그림에서는 4.6.3) 패키지의 안정된 최신 버전에 해당합니다. 캐럿(^) 기호로 시작하는 버전은 가장 최신의 주 버전에 해당하고 틸드(~) 기호로 시작하는 버전은 가장 최신의 부 버전에 해당합니다. 

*bower.json* 파일을 저장합니다. Visual Studio는 *bower.json* 파일의 변경 여부를 감시합니다. 그리고 파일을 저장하는 순간 *bower install* 명령이 실행됩니다. 실행되는 정확한 명령은 **Bower/npm** 출력 보기 창을 참고하시기 바랍니다. 

*bower.json* 파일 하위의 *.bowerrc* 파일을 엽니다. *wwwroot/lib*으로 설정된 `directory` 속성은 Bower가 패키지 자산을 설치할 위치를 지정합니다. 

```json
{
 "directory": "wwwroot/lib"
}
```

솔루션 탐색기의 검색 상자를 이용하면 font-awesome 패키지를 찾아서 볼 수 있습니다. 

*Views\Shared_Layout.cshtml* 파일을 열고 `Development` 환경에 대한 environment [태그 헬퍼](xref:mvc/views/tag-helpers/intro)에 font-awesome CSS 파일을 추가합니다. 솔루션 탐색기에서 *font-awesome.css* 파일을 찾아서 `<environment names="Development">` 요소 안에 끌어서 놓습니다.

[!code-html[Main](bower/sample/_Layout.cshtml?highlight=4&range=9-13)]

프로덕션 응용 프로그램을 위해서는 `Staging,Production` 환경에 대한 environment 태그 헬퍼에 *font-awesome.min.css* 파일을 추가합니다. 

*Views\Home\About.cshtml* Razor 파일의 내용을 다음 마크업으로 대체합니다: 

[!code-html[Main](bower/sample/About.cshtml)]

응용 프로그램을 실행하고 About 뷰로 이동해서 font-awesome 패키지가 동작하는 것을 확인합니다. 

## 클라이언트 측 빌드 프로세스 살펴보기 

대부분의 ASP.NET Core 프로젝트 템플릿은 Bower를 이미 사용하도록 구성되어 있습니다. 계속해서 이번에는 빈 ASP.NET Core 프로젝트에 각 부분들을 수작업으로 추가해보면서 Bower가 프로젝트에서 사용되는 방법을 살펴보겠습니다. 매번 구성이 변경될 때마다 프로젝트 구조 및 런타임 출력에 어떤 일이 발생하는지 확인할 수 있을 것입니다.

Bower를 이용한 클라이언트 측 빌드 프로세스를 사용하는 일반적인 과정은 다음과 같습니다: 

* 프로젝트에 사용되는 패키지를 정의합니다. <!-- once defined, you don't need to download them, VS does -->
* 웹 페이지에서 패키지를 참조합니다.

### 패키지 정의하기 

*bower.json* 파일에 패키지를 추가하면 Visual Studio가 패키지를 다운로드합니다. 다음 예제는 Bower를 사용해서 jQuery와 Bootstrap을 *wwwroot* 폴더에 로드합니다.

* **ASP.NET Core 웹 응용 프로그램 (.NET Core)** 템플릿으로 새로운 ASP.NET Core 웹 응용 프로그램을 생성합니다. **비어 있음** 프로젝트 템플릿을 선택하고 **확인**을 누릅니다. 

* 솔루션 탐색기에서 마우스 오른쪽 버튼으로 프로젝트를 클릭하고 **추가** > **새 항목**을 선택한 다음, **Bower 구성 파일**을 선택합니다. 노트: 이때, *.bowerrc* 파일이 함께 추가됩니다.

* *bower.json* 파일을 열고, `dependencies` 섹션에 jquery와 bootstrap을 추가합니다. 작업을 마친 *bower.json* 파일은 다음 예제와 비슷한 모습일 것입니다. 다만, 버전은 시간이 지날수록 변경되므로 이 예제의 버전과 여러분이 보는 버전은 다를 수 있습니다.

[!code-json[Main](bower/sample/bower.json?highlight=5,6)]

* *bower.json* 파일을 저장합니다. 

프로젝트의 *wwwroot/lib* 하위에 *bootstrap* 및 *jQuery* 디렉터리가 포함되어 있는지 확인합니다. Bower는 *.bowerrc* 파일을 이용해서 *wwwroot/lib*에 자산을 설치합니다. 

노트: "Bower 패키지 관리" UI는 직접 파일을 편집하는 방식의 대안을 제공합니다.

### 정적 파일 활성화시키기 

* 프로젝트에 `Microsoft.AspNetCore.StaticFiles` NuGet 패키지를 추가합니다. 
* [정적 파일 미들웨어](https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.aspnetcore.builder.staticfileextensions)를 이용해서 정적 파일 서비스를 활성화시킬 수 있습니다. `Startup` 클래스의 `Configure` 메서드에 [UseStaticFiles](https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.aspnetcore.builder.staticfileextensions) 호출을 추가합니다.

[!code-csharp[Main](bower/sample/Startup.cs?highlight=9)]

### 패키지 참조하기 

이번 절에서는 HTML 페이지를 생성해서 배포된 패키지에 접근할 수 있는지 확인해봅니다.

* *wwwroot* 폴더에 *Index.html*라는 이름의 새로운 HTML 페이지를 추가합니다. 노트: 반드시 *wwwroot* 폴더 하위에 HTML 파일을 추가해야 합니다. 기본적으로 *wwwroot* 외부의 정적 콘텐츠는 제공되지 않습니다. 더 자세한 정보는 [Working with static files](xref:fundamentals/static-files)를 참고하시기 바랍니다.

*Index.html* 파일의 내용을 다음 마크업으로 대체합니다:

[!code-html[Main](bower/sample/Index.html)]

* 응용 프로그램을 실행하고 `http://localhost:<port>/Index.html`로 이동합니다. 또는 *Index.html* 파일이 열린 상태에서 `Ctrl+Shift+W` 키를 누릅니다. Jumbotron 스타일이 적용됐는지, 버튼을 클릭할 때 jQuery 코드가 반응하는지, Bootstrap 버튼의 상태가 변경되는지 확인해봅니다. 

![jumbotron style applied](bower/_static/jumbotron.png)
