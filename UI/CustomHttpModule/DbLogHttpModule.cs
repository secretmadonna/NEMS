using log4net;
using System;
using System.Reflection;
using System.Web;

namespace SecretMadonna.NEMS.UI.CustomHttpModule
{
    class DbLogHttpModule : IHttpModule
    {
        public static ILog logger = LogManager.GetLogger(typeof(DbLogHttpModule));
        public static int numberIndex = 0;

        static DbLogHttpModule()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public DbLogHttpModule()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        ~DbLogHttpModule()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        /// <summary>
        /// 您将需要在网站的 Web.config 文件中配置此模块
        /// 并向 IIS 注册它，然后才能使用它。有关详细信息，
        /// 请参阅以下链接: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule Members
        public void Dispose()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            //此处放置清除代码。
        }

        public void Init(HttpApplication context)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            context.BeginRequest += new EventHandler(OnBeginRequest);
            context.AuthenticateRequest += new EventHandler(OnAuthenticateRequest);
            context.PostAuthenticateRequest += new EventHandler(OnPostAuthenticateRequest);
            context.AuthorizeRequest += new EventHandler(OnAuthorizeRequest);
            context.PostAuthorizeRequest += new EventHandler(OnPostAuthorizeRequest);
            context.ResolveRequestCache += new EventHandler(OnResolveRequestCache);
            context.PostResolveRequestCache += new EventHandler(OnPostResolveRequestCache);
            context.MapRequestHandler += new EventHandler(OnMapRequestHandler);
            context.PostMapRequestHandler += new EventHandler(OnPostMapRequestHandler);
            // Session_Start
            context.AcquireRequestState += new EventHandler(OnAcquireRequestState);
            context.PostAcquireRequestState += new EventHandler(OnPostAcquireRequestState);
            context.PreRequestHandlerExecute += new EventHandler(OnPreRequestHandlerExecute);
            // HttpHandler
            context.PostRequestHandlerExecute += new EventHandler(OnPostRequestHandlerExecute);
            context.ReleaseRequestState += new EventHandler(OnReleaseRequestState);
            context.PostReleaseRequestState += new EventHandler(OnPostReleaseRequestState);
            context.UpdateRequestCache += new EventHandler(OnUpdateRequestCache);
            context.PostUpdateRequestCache += new EventHandler(OnPostUpdateRequestCache);
            // 下面是如何处理 LogRequest 事件并为其 
            // 提供自定义日志记录实现的示例
            context.LogRequest += new EventHandler(OnLogRequest);
            context.PostLogRequest += new EventHandler(OnPostLogRequest);
            context.EndRequest += new EventHandler(OnEndRequest);
            context.PreSendRequestHeaders += new EventHandler(OnPreSendRequestHeaders);
            context.PreSendRequestContent += new EventHandler(OnPreSendRequestContent);
            context.Error += new EventHandler(OnError);
        }
        #endregion

        #region EventHandler
        public void OnBeginRequest(Object source, EventArgs e)
        {
            var httpContext = HttpContext.Current;
            logger.InfoFormat("{0:D3}.{1}  {2}", ++numberIndex, MethodBase.GetCurrentMethod().Name, httpContext.Request.RawUrl);
            //httpContext.ApplicationInstance.CompleteRequest();
        }
        public void OnAuthenticateRequest(Object source, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public void OnPostAuthenticateRequest(Object source, EventArgs e)
        {
            var ctx = HttpContext.Current;
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            //ctx.Request.
        }
        public void OnAuthorizeRequest(Object source, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public void OnPostAuthorizeRequest(Object source, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public void OnResolveRequestCache(Object source, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public void OnPostResolveRequestCache(Object source, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public void OnMapRequestHandler(Object source, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public void OnPostMapRequestHandler(Object source, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public void OnAcquireRequestState(Object source, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public void OnPostAcquireRequestState(Object source, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public void OnPreRequestHandlerExecute(Object source, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public void OnPostRequestHandlerExecute(Object source, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public void OnReleaseRequestState(Object source, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public void OnPostReleaseRequestState(Object source, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public void OnUpdateRequestCache(Object source, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public void OnPostUpdateRequestCache(Object source, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public void OnLogRequest(Object source, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            //可以在此处放置自定义日志记录逻辑

        }
        public void OnPostLogRequest(Object source, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public void OnEndRequest(Object source, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public void OnPreSendRequestHeaders(Object source, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public void OnPreSendRequestContent(Object source, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public void OnError(Object source, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        #endregion
    }
}
