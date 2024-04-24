using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SchoolWeb.Filters
{
    public class CustomExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var contentResult = new ContentResult();
            contentResult.Content = context.Exception.Message;

            context.Result = contentResult;
        }
    }
}
