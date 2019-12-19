using log4net;
using log4net.Config;
using System;
using System.Diagnostics;
using System.IO.MemoryMappedFiles;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;

[assembly: XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
namespace SecretMadonna.NEMS.UI.Frnas
{
    class Program
    {
        public static ILog logger = LogManager.GetLogger(typeof(App));
        public static int numberIndex = 0;

        private static readonly string processIdentity;
        static Program()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            var executingAssembly = Assembly.GetExecutingAssembly();
            var assemblyCompanyAttribute = executingAssembly.GetCustomAttribute<AssemblyCompanyAttribute>();
            var assemblyProductAttribute = executingAssembly.GetCustomAttribute<AssemblyProductAttribute>();
            var companyProduct = $"{assemblyCompanyAttribute.Company}_{assemblyProductAttribute.Product}";
            processIdentity = companyProduct;
        }
        Program()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        ~Program()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        [STAThread]
        static void Main()
        {
            MessageBox.Show();

            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);

            #region 利用 Mutex 防止应用程序多开
            //var executingAssembly = Assembly.GetExecutingAssembly();
            //var assemblyCompanyAttribute = executingAssembly.GetCustomAttribute<AssemblyCompanyAttribute>();
            //var assemblyProductAttribute = executingAssembly.GetCustomAttribute<AssemblyProductAttribute>();
            //var companyProduct = $"{assemblyCompanyAttribute.Company}_{assemblyProductAttribute.Product}";

            //processIdentity = companyProduct;
            //var currentProcess = Process.GetCurrentProcess();
            //currentProcess.StartInfo.

            using (var mutex = new Mutex(true, $"Mutex_{processIdentity}", out var createdNew))
            {
                var capacity = Marshal.SizeOf(typeof(int));
                if (createdNew)
                {
                    var currentProcessId = Process.GetCurrentProcess().Id;
                    using (var mmf = MemoryMappedFile.CreateOrOpen(processIdentity, capacity, MemoryMappedFileAccess.ReadWrite))
                    {
                        var viewAccessor = mmf.CreateViewAccessor(0, capacity);
                        viewAccessor.Write(0, currentProcessId);


                        //var appDomain = AppDomain.CurrentDomain;
                        //var appDirectory = appDomain.SetupInformation.ApplicationBase;
                        //var version = Assembly.GetExecutingAssembly().GetName().Version;
                        //var v = System.Windows.Application.ResourceAssembly.GetName().Version;
                        //return;
                        var app = new App();
                        app.InitializeComponent();
                        app.Run();
                    }
                }
                else
                {
                    // 1.唤起已启动的进程
                    try
                    {
                        using (var mmf = MemoryMappedFile.OpenExisting(processIdentity))
                        {
                            var viewAccessor = mmf.CreateViewAccessor(0, capacity);
                            viewAccessor.Read(0, out int processId);
                            var process = Process.GetProcessById(processId);
                            var mainWindowHandle = process.MainWindowHandle; // 主窗口的句柄不会改变，其他窗口的句柄可能会改变。FindWindow(null, "{Window.Title}");
                            ShowWindowAsync(mainWindowHandle, SW_RESTORE);
                            SetForegroundWindow(mainWindowHandle);
                            //SwitchToThisWindow(mainWindowHandle, true);
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally { }
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
            #endregion
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="fAltTab"></param>
        [DllImport("user32")]
        static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

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
