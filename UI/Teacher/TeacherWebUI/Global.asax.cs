using log4net;
using log4net.Config;
using SecretMadonna.NEMS.Infrastructure.Common;
using System;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

[assembly: XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
namespace SecretMadonna.NEMS.UI.TeacherWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(MvcApplication));
        private static int numberIndex = 0;

        static MvcApplication()
        {
            var ctx = HttpContext.Current;
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            var request = ctx.Request;
            var requestContext = request.RequestContext;
        }
        public MvcApplication()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        ~MvcApplication()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        //private static readonly object EventBeginRequest = new object();
        protected void Application_Start(Object sender, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            for (int i = 0; i < Modules.Count; i++)
            {
                var module = Modules[i];
                var type = module.GetType();
                logger.InfoFormat("{0}:{1},{2}", i, type.FullName, type.Assembly.ManifestModule.FullyQualifiedName);
            }
            //System.Web.HttpRuntime httpRuntime;
            //Microsoft.Web.Administration.ApplicationPool applicationPool;
            //System.AppDomain appDomain;
            //System.Web.Hosting.HostingEnvironment hostingEnvironment;
            //System.Web.Hosting.ApplicationManager applicationManager;

            //Console.WriteLine(Site);
            //Console.WriteLine(User);
            //Console.WriteLine(Server);
            //Console.WriteLine(Application);
            //Console.WriteLine(Session);
            //Console.WriteLine(Modules);
            //Console.WriteLine(Request);
            //Console.WriteLine(Context);
            //Console.WriteLine(Response);
            //Console.WriteLine(Events);

            //System.Web.SessionState.SessionStateStoreProviderBase
            //System.Configuration.Provider.ProviderBase 
            //System.Web.SessionState.ISessionIDManager


            //HttpContext.Current.Items["Application_EventBeginRequest"] = EventBeginRequest;

            //var key = HttpContext.Current.Items["Application_EventBeginRequest"];
            //var events = Events;
            //var delegateBeginRequest = events[key];
            //var delegates = delegateBeginRequest.GetInvocationList();

            //var type = this.GetType();
            //var eventInfo = type.GetEvent("BeginRequest");
            //var eventInfoRuntime = type.GetRuntimeEvent("BeginRequest");
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
            var ctx = HttpContext.Current;
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        protected void Application_MapRequestHandler(Object sender, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        protected void Application_PostMapRequestHandler(Object sender, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        /// <summary>
        /// Application_PostMapRequestHandler 之后执行
        ///   IHttpModule(System.Web.SessionState.SessionStateModule) 中 Application_AcquireRequestState 事件中处理的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Session_Start(Object sender, EventArgs e)
        {
            var stackTrace = new System.Diagnostics.StackTrace(true);
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name + Environment.NewLine + stackTrace.DescInfo() + Environment.NewLine);
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
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
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
