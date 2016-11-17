using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.Mvc;

namespace PizzaStoreMvc.Client
{
  public class ValidAction : ActionFilterAttribute
  {
    private Timer t = new Timer();
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
      var context = filterContext.RequestContext.HttpContext;
      if (context.Request.UserAgent.Contains("IE"))
      {
        context.Response.Redirect("~/ie/index");
      }
      //Log.Write();
      t.Start();
    }


    public override void OnActionExecuted(ActionExecutedContext filterContext)
    {
      var context = filterContext.RequestContext.HttpContext;
      if (context.Request.UserAgent.Contains("IE"))
      {
        context.Response.Redirect("~/ie/index");
      }
      t.Stop();
      //Log.Write();
      //  Timer.Start();
      //Log.Write(t.Interval.ToString());
    }
  }
}