#pragma checksum "C:\Programming\Study\Web\ASP.NET Core\Task1\Task1\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2e3e7f5db2304e1bb3c0ed94adb40c3703248ad0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Task1.Pages.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
namespace Task1.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Programming\Study\Web\ASP.NET Core\Task1\Task1\Pages\_ViewImports.cshtml"
using Task1;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2e3e7f5db2304e1bb3c0ed94adb40c3703248ad0", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"29513554490e8fbd37e973be53740911b880799c", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Programming\Study\Web\ASP.NET Core\Task1\Task1\Pages\Index.cshtml"
  
    ViewData["Title"] = "Home page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n\r\n");
#nullable restore
#line 9 "C:\Programming\Study\Web\ASP.NET Core\Task1\Task1\Pages\Index.cshtml"
      
            var Now = DateTime.Now.ToString();
        

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <p>");
#nullable restore
#line 13 "C:\Programming\Study\Web\ASP.NET Core\Task1\Task1\Pages\Index.cshtml"
  Write(Model.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n    <p>Time from cshtml <b>");
#nullable restore
#line 15 "C:\Programming\Study\Web\ASP.NET Core\Task1\Task1\Pages\Index.cshtml"
                      Write(Now);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></p>\r\n    <p>Time from model: <b>");
#nullable restore
#line 16 "C:\Programming\Study\Web\ASP.NET Core\Task1\Task1\Pages\Index.cshtml"
                      Write(Model.TimeNow);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></p>\r\n    <p>");
#nullable restore
#line 17 "C:\Programming\Study\Web\ASP.NET Core\Task1\Task1\Pages\Index.cshtml"
  Write(Model.AppConfiguration["Text"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
