#pragma checksum "/Users/Bailey/Documents/Bootcamp/c_sharp_stack/WeddingPlanner/Views/Home/OneWedding.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cb25877036af29f3679d0ffdc08272171c1053ff"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_OneWedding), @"mvc.1.0.view", @"/Views/Home/OneWedding.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/OneWedding.cshtml", typeof(AspNetCore.Views_Home_OneWedding))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "/Users/Bailey/Documents/Bootcamp/c_sharp_stack/WeddingPlanner/Views/_ViewImports.cshtml"
using WeddingPlanner;

#line default
#line hidden
#line 2 "/Users/Bailey/Documents/Bootcamp/c_sharp_stack/WeddingPlanner/Views/_ViewImports.cshtml"
using WeddingPlanner.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cb25877036af29f3679d0ffdc08272171c1053ff", @"/Views/Home/OneWedding.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e9e38482b8beecdb199b7be73dfa5c3d6a2f574", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_OneWedding : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Wedding>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(15, 5, true);
            WriteLiteral("\n<h1>");
            EndContext();
            BeginContext(21, 15, false);
#line 3 "/Users/Bailey/Documents/Bootcamp/c_sharp_stack/WeddingPlanner/Views/Home/OneWedding.cshtml"
Write(Model.WedderOne);

#line default
#line hidden
            EndContext();
            BeginContext(36, 5, true);
            WriteLiteral(" and ");
            EndContext();
            BeginContext(42, 15, false);
#line 3 "/Users/Bailey/Documents/Bootcamp/c_sharp_stack/WeddingPlanner/Views/Home/OneWedding.cshtml"
                    Write(Model.WedderTwo);

#line default
#line hidden
            EndContext();
            BeginContext(57, 118, true);
            WriteLiteral("\'s Wedding</h1>\n<a href=\"/Dashboard\">Dashboard</a>\n<a href=\"/logout\">Log Out</a>\n\n<h3 style=\"margin-top: 30px;\">Date: ");
            EndContext();
            BeginContext(176, 36, false);
#line 7 "/Users/Bailey/Documents/Bootcamp/c_sharp_stack/WeddingPlanner/Views/Home/OneWedding.cshtml"
                               Write(Model.Date.ToString("MMMM dd, yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(212, 58, true);
            WriteLiteral("</h3>\n<h3>Guests:</h3>\n<ul style=\"list-style-type:none;\">\n");
            EndContext();
#line 10 "/Users/Bailey/Documents/Bootcamp/c_sharp_stack/WeddingPlanner/Views/Home/OneWedding.cshtml"
     foreach (var item in Model.WeddingsToAttend)
    {

#line default
#line hidden
            BeginContext(326, 12, true);
            WriteLiteral("        <li>");
            EndContext();
            BeginContext(339, 19, false);
#line 12 "/Users/Bailey/Documents/Bootcamp/c_sharp_stack/WeddingPlanner/Views/Home/OneWedding.cshtml"
       Write(item.user.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(358, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(360, 18, false);
#line 12 "/Users/Bailey/Documents/Bootcamp/c_sharp_stack/WeddingPlanner/Views/Home/OneWedding.cshtml"
                            Write(item.user.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(378, 6, true);
            WriteLiteral("</li>\n");
            EndContext();
#line 13 "/Users/Bailey/Documents/Bootcamp/c_sharp_stack/WeddingPlanner/Views/Home/OneWedding.cshtml"
    }

#line default
#line hidden
            BeginContext(390, 9, true);
            WriteLiteral("  \n</ul> ");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Wedding> Html { get; private set; }
    }
}
#pragma warning restore 1591
