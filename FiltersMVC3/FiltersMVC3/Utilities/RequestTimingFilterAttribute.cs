using System;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Routing;

namespace FiltersMVC3.Utilities
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RequestTimingFilterAttribute : FilterAttribute, IActionFilter, IResultFilter
    {
        IStatefulStorage storage = StatefulStorage.PerRequest;

        Stopwatch GetStopwatch(string name)
        {
            return storage.GetOrAdd<Stopwatch>(name, () => new Stopwatch());
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            GetStopwatch("action").Start();
            //if (userDoesNotHaveRole())
            //{
            //    filterContext.Controller.TempData["Message"] = "You do not have access to this page.";
            //    filterContext.Controller.TempData["MessageClass"] = "warning";
            //    filterContext.Result =
            //      new RedirectToRouteResult(
            //        new RouteValueDictionary{{ "controller", "InvalidPermissions" },
            //                                     { "action", "Index" },
            //                                     { "returnUrl",    filterContext.HttpContext.Request.RawUrl }
            //                                    });

            //}

        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            GetStopwatch("action").Stop();
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            GetStopwatch("result").Start();
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            var resultStopwatch = GetStopwatch("result");
            resultStopwatch.Stop();

            var actionStopwatch = GetStopwatch("action");
            var response = filterContext.HttpContext.Response;

            if (!filterContext.IsChildAction && response.ContentType == "text/html")
                response.Write(
                    String.Format(
                        "<h5>Action '{0} :: {1}', Execute: {2}ms, Result: {3}ms.</h5>",
                        filterContext.RouteData.Values["controller"],
                        filterContext.RouteData.Values["action"],
                        actionStopwatch.ElapsedMilliseconds,
                        resultStopwatch.ElapsedMilliseconds
                    )
                );
        }
    }
}