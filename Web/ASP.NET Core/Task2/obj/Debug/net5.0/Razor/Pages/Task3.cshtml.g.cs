#pragma checksum "C:\Programming\Study\Web\ASP.NET Core\Task2\Pages\Task3.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e0140b6eafd1a6b1f033c598ddb5e8f850eab926"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Task2.Pages.Pages_Task3), @"mvc.1.0.razor-page", @"/Pages/Task3.cshtml")]
namespace Task2.Pages
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
#line 1 "C:\Programming\Study\Web\ASP.NET Core\Task2\Pages\_ViewImports.cshtml"
using Task2;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0140b6eafd1a6b1f033c598ddb5e8f850eab926", @"/Pages/Task3.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ea273c818630b84da0668d0a2429f99ea974278", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_Task3 : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<b>Address: ");
#nullable restore
#line 6 "C:\Programming\Study\Web\ASP.NET Core\Task2\Pages\Task3.cshtml"
       Write(Model.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b><br />\r\n<b>Name: ");
#nullable restore
#line 7 "C:\Programming\Study\Web\ASP.NET Core\Task2\Pages\Task3.cshtml"
    Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b><br />\r\n<b>Places: ");
#nullable restore
#line 8 "C:\Programming\Study\Web\ASP.NET Core\Task2\Pages\Task3.cshtml"
      Write(Model.Places);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b><br />\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Task2.Pages.Task3Model> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Task2.Pages.Task3Model> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Task2.Pages.Task3Model>)PageContext?.ViewData;
        public Task2.Pages.Task3Model Model => ViewData.Model;
    }
}
#pragma warning restore 1591