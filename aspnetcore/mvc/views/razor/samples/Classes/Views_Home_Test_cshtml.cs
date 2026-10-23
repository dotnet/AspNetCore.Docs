using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;

public class _Views_Home_Test_cshtml : RazorPage<dynamic>
{
    // Functions placed between here 
    public string GetHello()
    {
        return "Hello";
    }
    // And here.
#pragma warning disable 1998
    public override async Task ExecuteAsync()
    {
        WriteLiteral("\r\n<div>From method: ");
        Write(GetHello());
        WriteLiteral("</div>\r\n");
    }
#pragma warning restore 1998
}



/*
 * #pragma checksum "/Views/Home/Contact5.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "df105f5597cff871aaa18b2a5cc82662d6e6963d"
namespace AspNetCore
{
#line 1 "/Views/_ViewImports.cshtml"
using RazorSample

#line default
#line hidden
;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Threading.Tasks;

public class _Views_Home_Contact5_cshtml : Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
{
#line 1 "/Views/Home/Contact5.cshtml"

public string GetHello()
{
    return "Hello";
}

#line default
#line hidden
    #line hidden
    public _Views_Home_Contact5_cshtml()
    {
    }
    #line hidden
    [Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
    public Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
    [Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
    public Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
    [Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
    public Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
    [Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
    public Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
    [Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
    public Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }

    #line hidden

    #pragma warning disable 1998
    public override async Task ExecuteAsync()
    {
        BeginContext(86, 20, true);
        WriteLiteral("\r\n<div>From method: ");
        EndContext();
        BeginContext(107, 10, false);
#line 8 "/Views/Home/Contact5.cshtml"
         Write(GetHello());

#line default
#line hidden
        EndContext();
        BeginContext(117, 8, true);
        WriteLiteral("</div>\r\n");
        EndContext();
    }
    #pragma warning restore 1998
}
}
*/
