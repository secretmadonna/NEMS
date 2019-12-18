using log4net;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Navigation;

namespace SecretMadonna.NEMS.UI.Frnas
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public static ILog logger = LogManager.GetLogger(typeof(App));
        public static int numberIndex = 0;

        public App()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        ~App()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        #region Event
        private void Application_Activated(object sender, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Application_Deactivated(object sender, EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Application_FragmentNavigation(object sender, System.Windows.Navigation.FragmentNavigationEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Application_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Application_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Application_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Application_NavigationFailed(object sender, System.Windows.Navigation.NavigationFailedEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Application_NavigationProgress(object sender, System.Windows.Navigation.NavigationProgressEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Application_NavigationStopped(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Application_SessionEnding(object sender, SessionEndingCancelEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        #endregion

        #region override
        protected override void OnActivated(EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            base.OnActivated(e);
        }
        protected override void OnDeactivated(EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            base.OnDeactivated(e);
            //throw new Exception("测试异常");
        }
        protected override void OnExit(ExitEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            base.OnExit(e);
        }
        protected override void OnFragmentNavigation(FragmentNavigationEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            base.OnFragmentNavigation(e);
        }
        protected override void OnLoadCompleted(NavigationEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            base.OnLoadCompleted(e);
        }
        protected override void OnNavigated(NavigationEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            base.OnNavigated(e);
        }
        protected override void OnNavigating(NavigatingCancelEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            base.OnNavigating(e);
        }
        protected override void OnNavigationFailed(NavigationFailedEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            base.OnNavigationFailed(e);
        }
        protected override void OnNavigationProgress(NavigationProgressEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            base.OnNavigationProgress(e);
        }
        protected override void OnNavigationStopped(NavigationEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            base.OnNavigationStopped(e);
        }
        protected override void OnSessionEnding(SessionEndingCancelEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            base.OnSessionEnding(e);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            //ForbidMultiOpenApplication();
            base.OnStartup(e);
        }
        #endregion

        private void ForbidMultiOpenApplication()
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            var assemblyCompanyAttribute = executingAssembly.GetCustomAttribute<AssemblyCompanyAttribute>();
            var assemblyProductAttribute = executingAssembly.GetCustomAttribute<AssemblyProductAttribute>();
            var companyProduct = $"{assemblyCompanyAttribute.Company}_{assemblyProductAttribute.Product}";
            using (var mutex = new Mutex(true, companyProduct, out var createdNew))
            {
                var currentProcess = Process.GetCurrentProcess();
                Process runningProcess;
                if (createdNew)
                {
                    var processName = currentProcess.ProcessName.Replace(".vshost", "");
                    var processes = Process.GetProcessesByName(processName);
                    runningProcess = processes.FirstOrDefault(m => m.Id != currentProcess.Id && $"{m.MainModule.FileVersionInfo.CompanyName}_{m.MainModule.FileVersionInfo.ProductName}".Equals(companyProduct));
                    if (runningProcess == null)
                    {
                        return;
                    }
                }
                else
                {
                    var processName = currentProcess.ProcessName.Replace(".vshost", "");
                    var processes = Process.GetProcessesByName(processName);
                    runningProcess = processes.OrderBy(m => m.StartTime).FirstOrDefault(m => m.Id != currentProcess.Id && $"{m.MainModule.FileVersionInfo.CompanyName}_{m.MainModule.FileVersionInfo.ProductName}".Equals(companyProduct));
                }
                // 1.唤起已启动的进程
                if (runningProcess != null && runningProcess.MainWindowHandle != IntPtr.Zero)
                {
                    ShowWindowAsync(runningProcess.MainWindowHandle, SW_RESTORE);
                    SetForegroundWindow(runningProcess.MainWindowHandle);
                }
                // 2.终止当前进程
                Environment.Exit(Environment.ExitCode); // 终止此进程，并将退出代码返回到操作系统
                //Environment.FailFast(null, null); // 向 Windows 的应用程序事件日志写入消息后立即终止进程，然后在发往 Microsoft 的错误报告中加入该消息和异常信息
                //currentProcess.Kill(); // 立即停止关联的进程
                //var exitCode = (uint)Environment.ExitCode;
                //ExitProcess(exitCode);
                //TerminateProcess(currentProcess.Handle, exitCode);
            }
        }

        #region Win32 API
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uExitCode"></param>
        [DllImport("kernel32.dll")]
        static extern void ExitProcess(uint uExitCode);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hProcess"></param>
        /// <param name="uExitCode"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool TerminateProcess(IntPtr hProcess, uint uExitCode);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpClassName"></param>
        /// <param name="lpWindowName"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nCmdShow"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nCmdShow"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32")]
        static extern int SetForegroundWindow(IntPtr hWnd);

        private const int SW_HIDE = 0;
        private const int SW_NORMAL = 1;
        private const int SW_MAXIMIZE = 3;
        private const int SW_SHOWNOACTIVATE = 4;
        private const int SW_SHOW = 5;
        private const int SW_MINIMIZE = 6;
        private const int SW_RESTORE = 9;
        private const int SW_SHOWDEFAULT = 10;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="Msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="Msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        #endregion
    }
}
