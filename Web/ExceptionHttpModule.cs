using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Globalization;
using System.Text.RegularExpressions;
namespace Web
{
    public class ExceptionHttpModule : IHttpModule
    {
        // Methods
        private void Application_OnError(object source, EventArgs e)
        {
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;
            try
            {
                Exception innerException = context.Server.GetLastError();
                if (innerException.InnerException != null)
                {
                    innerException = innerException.InnerException;
                }
                if (innerException is HttpException)
                {
                    HttpException exception3 = (HttpException)innerException;
                    if (exception3.GetHttpCode() == 0x194)
                    {
                        return;
                    }
                }

                CustomErrorsMode mode = CompilationDebug();

                string msg = "";
                if (mode == CustomErrorsMode.Off)
                {
                    msg = innerException.Message;
                }
                else
                {
                    msg = "抱歉，当前操作无法进行";
                }

                WebUtility.WriteMessage(msg);

            }
            catch
            {
            }
       
        }

        private static CustomErrorsMode CompilationDebug()
        {
            string currentExecutionFilePath = HttpContext.Current.Request.CurrentExecutionFilePath;
            CustomErrorsSection section = WebConfigurationManager.OpenWebConfiguration(currentExecutionFilePath.Substring(0, currentExecutionFilePath.LastIndexOf("/", StringComparison.CurrentCultureIgnoreCase))).GetSection("system.web/customErrors") as CustomErrorsSection;
            return section.Mode;
        }

        public void Dispose()
        {

        }

        public void Init(HttpApplication context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            context.Error += new EventHandler(this.Application_OnError);
        }

    }
}
