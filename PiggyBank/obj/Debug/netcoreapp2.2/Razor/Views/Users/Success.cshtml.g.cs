#pragma checksum "D:\Documentos\Portfólio\PiggyBank\PiggyBank\Views\Users\Success.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bafb4da8d11a6c67541044ea0ba263f6aa9a6cd5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Users_Success), @"mvc.1.0.view", @"/Views/Users/Success.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Users/Success.cshtml", typeof(AspNetCore.Views_Users_Success))]
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
#line 1 "D:\Documentos\Portfólio\PiggyBank\PiggyBank\Views\_ViewImports.cshtml"
using PiggyBank;

#line default
#line hidden
#line 2 "D:\Documentos\Portfólio\PiggyBank\PiggyBank\Views\_ViewImports.cshtml"
using PiggyBank.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bafb4da8d11a6c67541044ea0ba263f6aa9a6cd5", @"/Views/Users/Success.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e74523493d975274c6655350c4585472ab94be46", @"/Views/_ViewImports.cshtml")]
    public class Views_Users_Success : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "D:\Documentos\Portfólio\PiggyBank\PiggyBank\Views\Users\Success.cshtml"
  
    Layout = "../Shared/_LayoutLogin.cshtml";

#line default
#line hidden
            BeginContext(54, 281, true);
            WriteLiteral(@"
<div class=""alert-success"" style=""background-color:rgba(239, 239, 239, 0.80); border-radius:10px; padding:20px; color:dimgrey"">
    <h2>Congratulations your account has been successfully created! Click <a href=""../Users/Login"">here</a> to log into the system...</h2>
</div>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591