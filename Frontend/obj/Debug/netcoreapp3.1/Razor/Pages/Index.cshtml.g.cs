<<<<<<< HEAD
#pragma checksum "C:\Proyecto\Aplicacion\ProyectosED\frontend\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1d305e4385b820f8a2671ff69c0a4ccfc7decbaa"
=======
#pragma checksum "C:\Users\Felip\Documents\Desarrollo de software\Proyecto\ProyectosED\Frontend\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e1c91de9109554f067eeac5db3d403c1fe558f68"
>>>>>>> e2da962b8c75d1021634a51ea3ab04633d2e49bb
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Frontend.Pages.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
namespace Frontend.Pages
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
#line 1 "C:\Proyecto\Aplicacion\ProyectosED\frontend\Pages\_ViewImports.cshtml"
using Frontend;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e1c91de9109554f067eeac5db3d403c1fe558f68", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"10e7216069f48c57b0b0fadbe8f10eca06aff21f", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Proyecto\Aplicacion\ProyectosED\frontend\Pages\Index.cshtml"
  
    ViewData["Title"] = "Home page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
  <div id=""tit"">
    <h5 class=""display-7"" style=""background-color: white;border-radius:40%;color:#0165A9;"">Eventos Deportivos</h5>
  </div> 
    <hr style=""background-color: #0165A9;height:4px;border-radius:50%;"">

<div id=""carouselExampleInterval"" class=""carousel slide"" data-bs-ride=""carousel"">
  <div class=""carousel-inner"">
    <div class=""carousel-item active"" data-bs-interval=""3000"" >
      <img src=""https://www.eazycityblog.com/wp-content/uploads/2016/05/Wikinews_Sports.png"" class=""d-block w-100"" alt=""..."" style=""height: 550px;"" >
    </div>
    <div class=""carousel-item"" data-bs-interval=""3000"">
      <img src=""https://www.adn-mundo.com/wp-content/uploads/2021/08/eventos-deportivos-de-este-2021.jpg"" class=""d-block w-100"" alt=""..."" style=""height: 550px;"" >
    </div>
    <div class=""carousel-item"" data-bs-interval=""3000"">
      <img src=""https://i2.wp.com/noticiasenvivo.co/wp-content/uploads/2021/10/maxresdefault.jpg?w=1280&ssl=1"" class=""d-block w-100"" alt=""...");
            WriteLiteral(@""" style=""height: 550px;"">
    </div>
  </div>
  <button class=""carousel-control-prev"" type=""button"" data-bs-target=""#carouselExampleInterval"" data-bs-slide=""prev"">
    <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
    <span class=""visually-hidden"">Previous</span>
  </button>
  <button class=""carousel-control-next"" type=""button"" data-bs-target=""#carouselExampleInterval"" data-bs-slide=""next"">
    <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
    <span class=""visually-hidden"">Next</span>
  </button>
</div>
    <hr style=""background-color: #0165A9;height:4px;border-radius:50%;"">
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
