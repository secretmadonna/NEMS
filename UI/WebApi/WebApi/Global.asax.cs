using log4net;
using log4net.Config;
using System;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Http;

[assembly: XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
namespace SecretMadonna.NEMS.UI.WebApi
{
    public class WebApiApplication : HttpApplication
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(WebApiApplication));
        private static int numberIndex = 0;

        static WebApiApplication()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public WebApiApplication()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        ~WebApiApplication()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        protected void Application_Start()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        public override void Init()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            base.Init();
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            var ctx = HttpContext.Current;
            logger.InfoFormat("{0:D3}.{1}  {2}", ++numberIndex, MethodBase.GetCurrentMethod().Name, ctx.Request.RawUrl);
        }
        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        protected void Application_AuthorizeRequest(Object sender, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        protected void Application_PostAuthorizeRequest(Object sender, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        protected void Application_ResolveRequestCache(Object sender, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        protected void Application_PostResolveRequestCache(Object sender, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        protected void Application_MapRequestHandler(Object sender, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        protected void Application_PostMapRequestHandler(Object sender, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            //CompleteRequest();
        }
        /// <summary>
        /// Application_PostMapRequestHandler 之后执行
        ///   IHttpModule(System.Web.SessionState.SessionStateModule) 中 Application_AcquireRequestState 事件中处理的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Session_Start(Object sender, EventArgs e)
        {
            var ctx = HttpContext.Current;
            logger.InfoFormat("{0:D3}.{1}  {2}", ++numberIndex, MethodBase.GetCurrentMethod().Name, ctx.Session.SessionID);
            //var stackTrace = new System.Diagnostics.StackTrace(true);
            //logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name + Environment.NewLine + stackTrace.DescInfo() + Environment.NewLine);
        }
        protected void Application_AcquireRequestState(Object sender, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        protected void Application_PostAcquireRequestState(Object sender, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        protected void Application_PreRequestHandlerExecute(Object sender, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        // HttpHandler

        protected void Application_PostRequestHandlerExecute(Object sender, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        protected void Application_ReleaseRequestState(Object sender, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        protected void Application_PostReleaseRequestState(Object sender, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        protected void Application_UpdateRequestCache(Object sender, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        protected void Application_PostUpdateRequestCache(Object sender, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        /// <summary>
        /// 总是会被执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_LogRequest(Object sender, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        /// <summary>
        /// 总是会被执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_PostLogRequest(Object sender, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        /// <summary>
        /// 总是会被执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_EndRequest(Object sender, EventArgs e)
        {
            var ctx = HttpContext.Current;
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            var response = ctx.Response;
        }
        /// <summary>
        /// 总是会被执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_PreSendRequestHeaders(Object sender, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        /// <summary>
        /// 总是会被执行（Application_PreSendRequestHeaders 一旦发生异常，Application_PreSendRequestContent 将不会被执行）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_PreSendRequestContent(Object sender, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        /// <summary>
        /// 前面的方法发生了错误，该方法会被执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(Object sender, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        /// <summary>
        /// Session_OnEnd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Session_End(Object sender, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        /// <summary>
        /// Application_OnEnd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_End(Object sender, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        public override void Dispose()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            base.Dispose();
        }

        //RequestCompleted
    }
}
