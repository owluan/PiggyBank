#pragma checksum "C:\Users\IntimeSoft02\Desktop\Arquivos\Projetos\PiggyBank\PiggyBank\PiggyBank\Views\Contas\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a12f4679c2167174561d0a5dd374c9503f7b60d6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Contas_Dashboard), @"mvc.1.0.view", @"/Views/Contas/Dashboard.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Contas/Dashboard.cshtml", typeof(AspNetCore.Views_Contas_Dashboard))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a12f4679c2167174561d0a5dd374c9503f7b60d6", @"/Views/Contas/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0fe8908c9ef00d8a2cb6d154b078dc85c3dd6eb0", @"/Views/_ViewImports.cshtml")]
    public class Views_Contas_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 517, true);
            WriteLiteral(@"<center><h3>Gráfico Despesas/Receitas</h3></center>
<br /><br />
<script src=""https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.7.2/Chart.bundle.min.js""></script>

<center>
    <div id=""canvas-holder"" style=""width:80%;"">
        <canvas id=""chart-area""></canvas>
    </div>
</center>

<script>
    var randomScalingFactor = function () {
        return Math.round(Math.random() * 100);
    };

    var config = {
        type: 'pie',
        data: {
            datasets: [{
                data: [");
            EndContext();
            BeginContext(518, 24, false);
#line 20 "C:\Users\IntimeSoft02\Desktop\Arquivos\Projetos\PiggyBank\PiggyBank\PiggyBank\Views\Contas\Dashboard.cshtml"
                  Write(Html.Raw(ViewBag.Valor1));

#line default
#line hidden
            EndContext();
            BeginContext(542, 1, true);
            WriteLiteral(",");
            EndContext();
            BeginContext(544, 24, false);
#line 20 "C:\Users\IntimeSoft02\Desktop\Arquivos\Projetos\PiggyBank\PiggyBank\PiggyBank\Views\Contas\Dashboard.cshtml"
                                            Write(Html.Raw(ViewBag.Valor2));

#line default
#line hidden
            EndContext();
            BeginContext(568, 38, true);
            WriteLiteral("],\r\n                backgroundColor: [");
            EndContext();
            BeginContext(607, 23, false);
#line 21 "C:\Users\IntimeSoft02\Desktop\Arquivos\Projetos\PiggyBank\PiggyBank\PiggyBank\Views\Contas\Dashboard.cshtml"
                             Write(Html.Raw(ViewBag.Cores));

#line default
#line hidden
            EndContext();
            BeginContext(630, 78, true);
            WriteLiteral("],\r\n                label: \'Dataset 1\'\r\n            }],\r\n            labels: [");
            EndContext();
            BeginContext(709, 24, false);
#line 24 "C:\Users\IntimeSoft02\Desktop\Arquivos\Projetos\PiggyBank\PiggyBank\PiggyBank\Views\Contas\Dashboard.cshtml"
                Write(Html.Raw(ViewBag.Labels));

#line default
#line hidden
            EndContext();
            BeginContext(733, 265, true);
            WriteLiteral(@"]
        },
        options: {
            responsive: true
        }
    };

    window.onload = function () {
        var ctx = document.getElementById('chart-area').getContext('2d');
        window.myPie = new Chart(ctx, config);
    };

</script>
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
