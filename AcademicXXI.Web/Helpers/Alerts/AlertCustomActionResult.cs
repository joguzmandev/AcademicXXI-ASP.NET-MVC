
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Academic.Web.Helpers.Alerts
{
    public class AlertCustomActionResult : ActionResult
    {

        public ActionResult InnerResult { get; set; }
        public string AlertClass { get; set; }
        public string Message { get; set; }

        public AlertCustomActionResult(ActionResult innerResult, string alertClass, string message)
        {
            InnerResult = innerResult;
            AlertClass = alertClass;
            Message = message;
        }
 
        public override void ExecuteResult(ControllerContext context)
        {
           
            var alert = context.Controller.TempData.GetAlerts();
            alert.Add(new Alert(AlertClass, Message));
            InnerResult.ExecuteResult(context);
        }
    }
}