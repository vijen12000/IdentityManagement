using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI._1._0.Core
{
    public class DisposeFilterAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //var container = .GetConfiguredContainer();
            //var context = container.Resolve<DbContext>();
            //context.Dispose();
            //container.Teardown(context);
            //base.OnResultExecuted(filterContext);
        }
    }
}