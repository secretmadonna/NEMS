using log4net;
using log4net.Config;
using SecretMadonna.NEMS.Infrastructure.Common;
using System;
using System.ComponentModel;
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
        public static ILog logger = LogManager.GetLogger(typeof(MvcApplication));
        public static int numberIndex = 0;

        static MvcApplication()
        {
            var httpContext = HttpContext.Current;
            var request = httpContext.Request;
            var requestContext = request.RequestContext;
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public MvcApplication()
        {
            //var events = Events;
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        ~MvcApplication()
        {
            //var events = Events;
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

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

        }
        //private static readonly object EventDisposed = new object();
        //private static readonly object EventErrorRecorded = new object();
        //private static readonly object EventRequestCompleted = new object();
        //private static readonly object EventPreSendRequestHeaders = new object();
        //private static readonly object EventPreSendRequestContent = new object();
        //private static readonly object EventBeginRequest = new object();
        //private static readonly object EventAuthenticateRequest = new object();
        //private static readonly object EventDefaultAuthentication = new object();
        //private static readonly object EventPostAuthenticateRequest = new object();
        //private static readonly object EventAuthorizeRequest = new object();
        //private static readonly object EventPostAuthorizeRequest = new object();
        //private static readonly object EventResolveRequestCache = new object();
        //private static readonly object EventPostResolveRequestCache = new object();
        //private static readonly object EventMapRequestHandler = new object();
        //private static readonly object EventPostMapRequestHandler = new object();
        //private static readonly object EventAcquireRequestState = new object();
        //private static readonly object EventPostAcquireRequestState = new object();
        //private static readonly object EventPreRequestHandlerExecute = new object();
        //private static readonly object EventPostRequestHandlerExecute = new object();
        //private static readonly object EventReleaseRequestState = new object();
        //private static readonly object EventPostReleaseRequestState = new object();
        //private static readonly object EventUpdateRequestCache = new object();
        //private static readonly object EventPostUpdateRequestCache = new object();
        //private static readonly object EventLogRequest = new object();
        //private static readonly object EventPostLogRequest = new object();
        //private static readonly object EventEndRequest = new object();
        public override void Init()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            base.Init();
            //HttpContext.Current.Items["Application_EventBeginRequestBeginRequest"] = (object)1;
            //HttpContext.Current.Items.Add("Application_EventBeginRequestBeginRequest", new object());
            //HttpContext.Current.Items.Add("Application_EventBeginRequestBeginRequest", new object());
            //HttpContext.Current.Items.Add("Application_EventBeginRequestBeginRequest", new object());
            //HttpContext.Current.Items.Add("Application_EventBeginRequestBeginRequest", new object());
            //HttpContext.Current.Items.Add("Application_EventBeginRequestBeginRequest", new object());
            //HttpContext.Current.Items.Add("Application_EventBeginRequestBeginRequest", new object());
            //HttpContext.Current.Items.Add("Application_EventBeginRequestBeginRequest", new object());
            //HttpContext.Current.Items.Add("Application_EventBeginRequestBeginRequest", new object());
            //HttpContext.Current.Items.Add("Application_EventBeginRequestBeginRequest", new object());
            //HttpContext.Current.Items.Add("Application_EventBeginRequestBeginRequest", new object());
            //HttpContext.Current.Items.Add("Application_EventBeginRequestBeginRequest", new object());
            //HttpContext.Current.Items.Add("Application_EventBeginRequestBeginRequest", new object());
            //HttpContext.Current.Items.Add("Application_EventBeginRequestBeginRequest", new object());
            //HttpContext.Current.Items.Add("Application_EventBeginRequestBeginRequest", new object());
            //HttpContext.Current.Items.Add("Application_EventBeginRequestBeginRequest", new object());
            //HttpContext.Current.Items.Add("Application_EventBeginRequestBeginRequest", new object());
            //HttpContext.Current.Items.Add("Application_EventBeginRequestBeginRequest", new object());
            //HttpContext.Current.Items.Add("Application_EventBeginRequestBeginRequest", new object());
            //HttpContext.Current.Items.Add("Application_EventBeginRequestBeginRequest", new object());
            //HttpContext.Current.Items.Add("Application_EventBeginRequestBeginRequest", new object());
            //HttpContext.Current.Items.Add("Application_EventBeginRequestBeginRequest", new object());
            //HttpContext.Current.Items.Add("Application_EventBeginRequestBeginRequest", new object());
            //HttpContext.Current.Items.Add("Application_EventBeginRequestBeginRequest", new object());
            //HttpContext.Current.Items.Add("Application_EventBeginRequestBeginRequest", new object());
            //HttpContext.Current.Items.Add("Application_EventBeginRequestBeginRequest", new object());
            //HttpContext.Current.Items.Add("Application_EventBeginRequestBeginRequest", new object());
            //HttpContext.Current.Items.Add("Application_EventBeginRequestBeginRequest", new object());
            //HttpContext.Current.Items.Add("Application_EventBeginRequestBeginRequest", new object());
            //HttpContext.Current.Items.Add("Application_EventBeginRequestBeginRequest", new object());
            //HttpContext.Current.Items.Add("Application_EventBeginRequestBeginRequest", new object());
            //HttpContext.Current.Items.Add("Application_EventBeginRequestBeginRequest", new object());
            //HttpContext.Current.Items.Add("Application_EventBeginRequestBeginRequest", new object());
            //HttpContext.Current.Items.Add("Application_EventBeginRequestBeginRequest", new object());
            //HttpContext.Current.Items.Add("Application_EventBeginRequestBeginRequest", new object());

            //HttpContext.Current.Items["Application_EventBeginRequestBeginRequest"] = (object)2;
            //HttpContext.Current.Items["Application_EventBeginRequestBeginRequest"] = EventBeginRequest;
            //HttpContext.Current.Items.Add("Application_EventBeginRequestBeginRequest", EventBeginRequest);
            //var key = HttpContext.Current.Items["Application_EventBeginRequestBeginRequest"];
            //var events = Events;
            //var delegateBeginRequest = events[key];
            //var delegates = delegateBeginRequest.GetInvocationList();

            //var type = this.GetType();
            //var eventInfo = type.GetEvent("BeginRequest");
            //var eventInfoRuntime = type.GetRuntimeEvent("BeginRequest");
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}  {2}", ++numberIndex, MethodBase.GetCurrentMethod().Name, Request.RawUrl);
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
        }
        /// <summary>
        /// Application_PostMapRequestHandler 之后执行
        ///   IHttpModule(System.Web.SessionState.SessionStateModule) 中 Application_AcquireRequestState 事件中处理的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Session_Start(Object sender, EventArgs e)
        {
            //logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            var stackTrace = new System.Diagnostics.StackTrace(true);
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, Environment.NewLine + stackTrace.DescInfo() + Environment.NewLine);
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
