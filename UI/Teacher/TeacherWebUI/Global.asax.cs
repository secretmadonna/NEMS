using log4net;
using log4net.Config;
using SecretMadonna.NEMS.Infrastructure.Common;
using System;
using System.ComponentModel;
using System.Reflection;
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
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public MvcApplication()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        ~MvcApplication()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        protected void Application_Start(Object sender, EventArgs e)
        {
            //System.Web.HttpRuntime httpRuntime;
            //Microsoft.Web.Administration.ApplicationPool applicationPool;
            //System.AppDomain appDomain;
            //System.Web.Hosting.HostingEnvironment hostingEnvironment;
            //System.Web.Hosting.ApplicationManager applicationManager;

            Console.WriteLine(Site);
            Console.WriteLine(User);
            Console.WriteLine(Server);
            Console.WriteLine(Application);
            //Console.WriteLine(Session);
            Console.WriteLine(Modules);
            //Console.WriteLine(Request);
            Console.WriteLine(Context);
            //Console.WriteLine(Response);
            Console.WriteLine(Events);


            //System.Web.SessionState.SessionStateStoreProviderBase
            //System.Configuration.Provider.ProviderBase 
            //System.Web.SessionState.ISessionIDManager





            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);




            for (int i = 0; i < Modules.Count; i++)
            {
                var module = Modules[i];
                var type = module.GetType();
                logger.InfoFormat("{0}:  {1}  {2}  {3}", i, type.FullName, type.Assembly.ManifestModule.Name, type.Assembly.ManifestModule.FullyQualifiedName);
            }
        }

        ////
        //// 摘要:
        ////     ASP.NET 将 HTTP 标头发送到客户端之前发生。
        //new public event EventHandler PreSendRequestHeaders;
        ////
        //// 摘要:
        ////     在选择该处理程序对请求作出响应时发生。
        //new public event EventHandler MapRequestHandler;
        ////
        //// 摘要:
        ////     释放应用程序时发生。
        //new public event EventHandler Disposed;
        ////
        //// 摘要:
        ////     作为执行的 HTTP 管道链中的第一个事件发生，当 ASP.NET 的请求做出响应。
        //new public event EventHandler BeginRequest;
        ////
        //// 摘要:
        ////     当安全模块已建立的用户标识时出现。
        //new public event EventHandler AuthenticateRequest;
        ////
        //// 摘要:
        ////     当安全模块已建立的用户标识时出现。
        //new public event EventHandler PostAuthenticateRequest;
        ////
        //// 摘要:
        ////     安全模块已验证用户身份验证时发生。
        //new public event EventHandler AuthorizeRequest;
        ////
        //// 摘要:
        ////     当前请求的用户已被授权时发生。
        //new public event EventHandler PostAuthorizeRequest;
        ////
        //// 摘要:
        ////     当 ASP.NET 完成授权事件以便从缓存中，跳过的事件处理程序 （例如，一个页面或 XML Web 服务） 执行的请求提供服务的缓存模块时发生。
        //new public event EventHandler ResolveRequestCache;
        ////
        //// 摘要:
        ////     ASP.NET 将绕过当前事件处理程序的执行，并允许缓存模块以处理从缓存请求时发生。
        //new public event EventHandler PostResolveRequestCache;
        ////
        //// 摘要:
        ////     ASP.NET 将内容发送到客户端之前发生。
        //new public event EventHandler PreSendRequestContent;
        ////
        //// 摘要:
        ////     当 ASP.NET 已映射到相应的事件处理程序的当前请求时出现。
        //new public event EventHandler PostMapRequestHandler;
        ////
        //// 摘要:
        ////     当 ASP.NET 已完成处理的事件处理程序时发生 System.Web.HttpApplication.LogRequest 事件。
        //new public event EventHandler PostLogRequest;
        ////
        //// 摘要:
        ////     已释放与请求相关联的托管的对象时发生。
        //new public event EventHandler RequestCompleted;
        ////
        //// 摘要:
        ////     获取与当前的请求相关联的请求状态 （例如，会话状态） 时发生。
        //new public event EventHandler PostAcquireRequestState;
        ////
        //// 摘要:
        ////     ASP.NET 开始执行事件处理程序 （例如，一个页面或 XML Web 服务） 之前发生。
        //new public event EventHandler PreRequestHandlerExecute;
        ////
        //// 摘要:
        ////     当 ASP.NET 事件处理程序 （例如，一个页面或 XML Web 服务） 完成执行时发生。
        //new public event EventHandler PostRequestHandlerExecute;
        ////
        //// 摘要:
        ////     ASP.NET 完成执行所有请求事件处理程序后发生。 此事件会导致状态模块保存当前的状态数据。
        //new public event EventHandler ReleaseRequestState;
        ////
        //// 摘要:
        ////     当 ASP.NET 已完成执行所有请求事件处理程序和存储数据的请求状态时发生。
        //new public event EventHandler PostReleaseRequestState;
        ////
        //// 摘要:
        ////     当 ASP.NET 完成执行事件处理程序，以便让缓存模块存储将用于为从缓存中的后续请求提供服务的响应时发生。
        //new public event EventHandler UpdateRequestCache;
        ////
        //// 摘要:
        ////     当 ASP.NET 完成更新的缓存模块和存储用于为从缓存中的后续请求提供服务的响应时发生。
        //new public event EventHandler PostUpdateRequestCache;
        ////
        //// 摘要:
        ////     ASP.NET 执行当前请求的任何日志记录之前发生。
        //new public event EventHandler LogRequest;
        ////
        //// 摘要:
        ////     当 ASP.NET 获取与当前的请求相关联的当前状态 （例如，会话状态）。
        //new public event EventHandler AcquireRequestState;
        ////
        //// 摘要:
        ////     作为执行的 HTTP 管道链中的最后一个事件发生，当 ASP.NET 的请求做出响应。
        //new public event EventHandler EndRequest;
        ////
        //// 摘要:
        ////     当引发未处理的异常时发生。
        //new public event EventHandler Error;

        public override void Init()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            base.Init();

            //var envents = Events;
            //var dsPreSendRequestHeaders = PreSendRequestHeaders.GetInvocationList();
            //var dsMapRequestHandler = MapRequestHandler.GetInvocationList();
            ////var dsDisposed = Disposed.GetInvocationList();
            //var dsBeginRequest = BeginRequest.GetInvocationList();
            //var dsAuthenticateRequest = AuthenticateRequest.GetInvocationList();
            //var dsPostAuthenticateRequest = PostAuthenticateRequest.GetInvocationList();
            //var dsAuthorizeRequest = AuthorizeRequest.GetInvocationList();
            //var dsPostAuthorizeRequest = PostAuthorizeRequest.GetInvocationList();
            //var dsResolveRequestCache = ResolveRequestCache.GetInvocationList();
            //var dsPostResolveRequestCache = PostResolveRequestCache.GetInvocationList();
            //var dsPreSendRequestContent = PreSendRequestContent.GetInvocationList();
            //var dsPostMapRequestHandler = PostMapRequestHandler.GetInvocationList();
            //var dsPostLogRequest = PostLogRequest.GetInvocationList();
            ////var dsRequestCompleted = RequestCompleted.GetInvocationList();
            //var dsPostAcquireRequestState = PostAcquireRequestState.GetInvocationList();
            //var dsPreRequestHandlerExecute = PreRequestHandlerExecute.GetInvocationList();
            //var dsPostRequestHandlerExecute = PostRequestHandlerExecute.GetInvocationList();
            //var dsReleaseRequestState = ReleaseRequestState.GetInvocationList();
            //var dsPostReleaseRequestState = PostReleaseRequestState.GetInvocationList();
            //var dsUpdateRequestCache = UpdateRequestCache.GetInvocationList();
            //var dsPostUpdateRequestCache = PostUpdateRequestCache.GetInvocationList();
            //var dsLogRequest = LogRequest.GetInvocationList();
            //var dsAcquireRequestState = AcquireRequestState.GetInvocationList();
            //var dsEndRequest = EndRequest.GetInvocationList();
            //var dsError = Error.GetInvocationList();
            //var type = this.GetType();
            //var memberInfos = type.GetMember("BeginRequest");
            //EventHandlerList eventHandlerList = (System.Reflection.RuntimeEventInfo)memberInfos.GetValue(0);
            // var propertyInfos = type.GetProperties();
            //type.GetRuntimeProperties();type.GetFields();
            //foreach (var propertyInfo in propertyInfos)
            //{
            //    type.GetEvents();
            //}
            //EventHandlerList eventList = (EventHandlerList)propertyInfo.GetValue(btnDemo, null);



            //var delegateInfo = Events["BeginRequest"];
            //var delegateInfos = delegateInfo.GetInvocationList();
            //foreach (var tempDelegateInfo in delegateInfos)
            //{
            //    //logger.InfoFormat("{0}:  {1}  {2}  {3}", "BeginRequest", tempDelegateInfo);
            //}
            var type = this.GetType();
            var memberInfos = type.GetMember("BeginRequest");
            var v=memberInfos.GetValue(0);
            var t = v.GetType();
            //foreach (var memberInfo in memberInfos)
            //{
            //    var methodInfos = eventInfo.GetOtherMethods(true);
            //}
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
