using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using System;
using System.IO;
using System.Threading.Tasks;

namespace eMAS.Api.TerrenosComodatos
{
    public class RenderViewService
    {
        private IRazorViewEngine _razorViewEngine;
        private IServiceProvider _serviceProvider;
        private ITempDataProvider _tempDataProvider;

        public RenderViewService(
            IRazorViewEngine engine,
            IServiceProvider serviceProvider,
            ITempDataProvider tempDataProvider)
        {
            this._razorViewEngine = engine;
            this._serviceProvider = serviceProvider;
            this._tempDataProvider = tempDataProvider;
        }
        public async Task<string> GetHtmlViewAsStringAsync<T>(string viewName, T model) where T : class, new()
        {
            var httpContext = new DefaultHttpContext() { RequestServices = _serviceProvider };
            var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());

            using (StringWriter sw = new StringWriter())
            {
                var viewResult = _razorViewEngine.FindView(actionContext, viewName, false);

                if (viewResult.View == null)
                {
                    return string.Empty;
                }

                var metadataProvider = new EmptyModelMetadataProvider();
                var msDictionary = new ModelStateDictionary();
                var viewDataDictionary = new ViewDataDictionary(metadataProvider, msDictionary);

                viewDataDictionary.Model = model;

                var tempDictionary = new TempDataDictionary(actionContext.HttpContext, _tempDataProvider);
                var viewContext = new ViewContext(
                    actionContext,
                    viewResult.View,
                    viewDataDictionary,
                    tempDictionary,
                    sw,
                    new HtmlHelperOptions()
                );

                await viewResult.View.RenderAsync(viewContext);
                return sw.ToString();
            }
        }
    }
}
