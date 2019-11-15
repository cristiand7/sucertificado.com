using System;
using System.Web.Http.Filters;

public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
{
    public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
    {
        /////if (actionExecutedContext.Response != null)
            actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");

        actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
        actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Headers", "X-Requested-With, Accept, Access-Control-Allow-Origin, Content-Type");

        base.OnActionExecuted(actionExecutedContext);
    }
}