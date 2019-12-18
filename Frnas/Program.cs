using log4net;
using log4net.Config;
using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

[assembly: XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
namespace SecretMadonna.NEMS.UI.Frnas
{
    class Program
    {
        public static ILog logger = LogManager.GetLogger(typeof(App));
        public static int numberIndex = 0;

        public static readonly string mainWindowName = "FrnasMainWindow";

        [STAThread]
        static void Main()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);

            var executingAssembly = Assembly.GetExecutingAssembly();
            var assemblyCompanyAttribute = executingAssembly.GetCustomAttribute<AssemblyCompanyAttribute>();
            var assemblyProductAttribute = executingAssembly.GetCustomAttribute<AssemblyProductAttribute>();
            var companyProduct = $"{assemblyCompanyAttribute.Company}_{assemblyProductAttribute.Product}";
            using (var mutex = new Mutex(true, companyProduct, out var createdNew))
            {
                if (createdNew)
                {
                    App app = new App();
                    app.InitializeComponent();
                    app.Run();
                }
                else
                {
                    // 1.唤起已启动的进程
                    var mainWindowHandle = FindWindow(null, mainWindowName);
                    ShowWindowAsync(mainWindowHandle, SW_RESTORE);
                    SetForegroundWindow(mainWindowHandle);
                    // 2.终止当前进程
                    Environment.Exit(Environment.ExitCode); // 终止此进程，并将退出代码返回到操作系统
                    //Environment.FailFast(null, null); // 向 Windows 的应用程序事件日志写入消息后立即终止进程，然后在发往 Microsoft 的错误报告中加入该消息和异常信息
                    //var currentProcess = Process.GetCurrentProcess();
                    //currentProcess.Kill(); // 立即停止关联的进程
                    //var exitCode = (uint)Environment.ExitCode;
                    //ExitProcess(exitCode);
                    //TerminateProcess(currentProcess.Handle, exitCode);
                }
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
        #endregion
    }
}
