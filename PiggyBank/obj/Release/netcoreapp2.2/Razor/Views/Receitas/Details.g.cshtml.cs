#pragma checksum "C:\Users\IntimeSoft02\Desktop\Arquivos\Projetos\PiggyBank\PiggyBank\PiggyBank\Views\Receitas\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c1dbdf9eedb2c0cd70b37c14f0d5750680def16a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Receitas_Details), @"mvc.1.0.view", @"/Views/Receitas/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Receitas/Details.cshtml", typeof(AspNetCore.Views_Receitas_Details))]
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
#line 1 "C:\Users\IntimeSoft02\Desktop\Arquivos\Projetos\PiggyBank\PiggyBank\PiggyBank\Views\_ViewImports.cshtml"
using PiggyBank;

#line default
#line hidden
#line 2 "C:\Users\IntimeSoft02\Desktop\Arquivos\Projetos\PiggyBank\PiggyBank\PiggyBank\Views\_ViewImports.cshtml"
using PiggyBank.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c1dbdf9eedb2c0cd70b37c14f0d5750680def16a", @"/Views/Receitas/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0fe8908c9ef00d8a2cb6d154b078dc85c3dd6eb0", @"/Views/_ViewImports.cshtml")]
    public class Views_Receitas_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PiggyBank.Models.Receita>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\IntimeSoft02\Desktop\Arquivos\Projetos\PiggyBank\PiggyBank\PiggyBank\Views\Receitas\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(86, 6, true);
            WriteLiteral("\r\n<h1>");
            EndContext();
            BeginContext(93, 17, false);
#line 6 "C:\Users\IntimeSoft02\Desktop\Arquivos\Projetos\PiggyBank\PiggyBank\PiggyBank\Views\Receitas\Details.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(110, 108, true);
            WriteLiteral("</h1>\r\n\r\n<div>\r\n    <h4>Receita</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(219, 40, false);
#line 13 "C:\Users\IntimeSoft02\Desktop\Arquivos\Projetos\PiggyBank\PiggyBank\PiggyBank\Views\Receitas\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Nome));

#line default
#line hidden
            EndContext();
            BeginContext(259, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(303, 36, false);
#line 16 "C:\Users\IntimeSoft02\Desktop\Arquivos\Projetos\PiggyBank\PiggyBank\PiggyBank\Views\Receitas\Details.cshtml"
       Write(Html.DisplayFor(model => model.Nome));

#line default
#line hidden
            EndContext();
            BeginContext(339, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(383, 40, false);
#line 19 "C:\Users\IntimeSoft02\Desktop\Arquivos\Projetos\PiggyBank\PiggyBank\PiggyBank\Views\Receitas\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Data));

#line default
#line hidden
            EndContext();
            BeginContext(423, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(467, 36, false);
#line 22 "C:\Users\IntimeSoft02\Desktop\Arquivos\Projetos\PiggyBank\PiggyBank\PiggyBank\Views\Receitas\Details.cshtml"
       Write(Html.DisplayFor(model => model.Data));

#line default
#line hidden
            EndContext();
            BeginContext(503, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(547, 41, false);
#line 25 "C:\Users\IntimeSoft02\Desktop\Arquivos\Projetos\PiggyBank\PiggyBank\PiggyBank\Views\Receitas\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Valor));

#line default
#line hidden
            EndContext();
            BeginContext(588, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(632, 37, false);
#line 28 "C:\Users\IntimeSoft02\Desktop\Arquivos\Projetos\PiggyBank\PiggyBank\PiggyBank\Views\Receitas\Details.cshtml"
       Write(Html.DisplayFor(model => model.Valor));

#line default
#line hidden
            EndContext();
            BeginContext(669, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(713, 41, false);
#line 31 "C:\Users\IntimeSoft02\Desktop\Arquivos\Projetos\PiggyBank\PiggyBank\PiggyBank\Views\Receitas\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Conta));

#line default
#line hidden
            EndContext();
            BeginContext(754, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(798, 42, false);
#line 34 "C:\Users\IntimeSoft02\Desktop\Arquivos\Projetos\PiggyBank\PiggyBank\PiggyBank\Views\Receitas\Details.cshtml"
       Write(Html.DisplayFor(model => model.Conta.Nome));

#line default
#line hidden
            EndContext();
            BeginContext(840, 86, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    <!--<a asp-action=\"Edit\" asp-route-id=\"");
            EndContext();
            BeginContext(927, 8, false);
#line 39 "C:\Users\IntimeSoft02\Desktop\Arquivos\Projetos\PiggyBank\PiggyBank\PiggyBank\Views\Receitas\Details.cshtml"
                                      Write(Model.Id);

#line default
#line hidden
            EndContext();
            BeginContext(935, 45, true);
            WriteLiteral("\" class=\"btn btn-primary\">Edit</a>-->\r\n    ");
            EndContext();
            BeginContext(980, 58, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c1dbdf9eedb2c0cd70b37c14f0d5750680def16a8909", async() => {
                BeginContext(1028, 6, true);
                WriteLiteral("Back");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1038, 12, true);
            WriteLiteral("\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PiggyBank.Models.Receita> Html { get; private set; }
    }
}
#pragma warning restore 1591
