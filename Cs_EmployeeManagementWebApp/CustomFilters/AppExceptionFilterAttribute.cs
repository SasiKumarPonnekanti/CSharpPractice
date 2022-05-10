using Microsoft.AspNetCore.Mvc;
using Cs_EmployeeManagementWebApp.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Diagnostics;

namespace Cs_EmployeeManagementWebApp.CustomFilters
{
    public class AppExceptionFilterAttribute: ExceptionFilterAttribute
    {

        private readonly IModelMetadataProvider modelMetadata;
        //Injecting IModelMetadataProvider

        private readonly sample1Context ctx;
        public AppExceptionFilterAttribute(IModelMetadataProvider modelMetadata, sample1Context ctx)
        {
            this.modelMetadata = modelMetadata;
            this.ctx = ctx;
        }

        public override void OnException(ExceptionContext context)
        {
            //1.Handle Exception to Complete Execution process

             context.ExceptionHandled = true;
            //Read The Exception message
             Exception exception = context.Exception;
            //Define a view Result to genereate result
            ViewResult viewResult = new ViewResult();
            //set the view name
            if (exception.GetType().Name == "Exception")
            {
                viewResult.ViewName = "CustomError";
            }
            else
            {
                viewResult.ViewName = "DbError";
            }

            // c. Since the View Needs data, we need to use the ViewDataDictionary
            // modelMetadata: The Current Model used in Request
            // ModelState: State of all Values for Model Objet in Current Request
            ViewDataDictionary valuePairs = new ViewDataDictionary(modelMetadata, context.ModelState);
            //fill required values to valuepairs
            valuePairs["ControllerName"] = context.RouteData.Values["controller"].ToString();
            valuePairs["ActionName"] = context.RouteData.Values["action"].ToString();
            valuePairs["Message"] = exception.Message;
            //pass valuepairs to viewdata of viewresult
            viewResult.ViewData = valuePairs;
            //set result property of context with viewresult
            context.Result = viewResult;
            ErrorLog log = new ErrorLog()
            {
                ControllerName = valuePairs["controllername"].ToString(),
                ActionName = valuePairs["actionname"].ToString(),
                RequestDateTime = System.DateTime.Now,
                ExecutionCompletionTime = 0,
                ExceptionMessage = valuePairs["message"].ToString(),
                ExceptionType = exception.GetType().Name,
            };
            ctx.ErrorLogs.Add(log);
            ctx.SaveChanges();
        }

    }
}
