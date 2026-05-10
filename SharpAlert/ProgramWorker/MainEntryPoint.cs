using AwokenNotifications;
using SharpAlert.AlertComponents;
using SharpAlert.DataProcessing;
using SharpAlert.DisplayDialogs;
using SharpAlert.Languages;
using SharpAlert.SourceCapturing;
using SharpAlert.SourceCapturing.SystemSpecific;
using SharpAlert.WebServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Velopack;
using Velopack.Exceptions;
using Velopack.Sources;
using static SharpAlert.ProgramWorker.HaidaWorker;
using static SharpAlert.ProgramWorker.NotificationWorker;

namespace SharpAlert.ProgramWorker
{
    public class SharpDataItem(string name, string data)
    {
        public string Name { get; set; } = name;
        public string Data { get; set; } = data;
    }

    internal static class MainEntryPoint
    {
        public static readonly DateTime startDT = DateTime.UtcNow;
        public static bool AllowThreadRestarts = true;
        private static int FeedSuccessfulCalls_ = 0;
        public static int FeedSuccessfulCalls
        {
            get => FeedSuccessfulCalls_;
            set
            {
                FeedSuccessfulCalls_ = value;
                if (FeedSuccessfulCalls_ >= 10000000)
                {
                    FeedSuccessfulCalls_ = 0;
                }
            }
        }

        public static FeedCapture? feed;
        public static WeatherAtomCapture? atomfeed;
        public static DirectFeedCapture? directfeed;
        public static IDAPFeedCapture? idapfeed;
        //public static CacheCapture? cache;
        public static DataProcessor? dataproc;
        //public static TeleIdleForm idle;
        //public static StatusForm status;
        public static bool CloseIdleWindow = false;
        public static bool CloseStatusWindow = false;
        public static object IdleWindowLock = new();
        public static object StatusWindowLock = new();
        public static object AudioOutputLock = new();
        public static HyperServer? hyper;
        public static object AlertValuesLock = new();
        private static bool _AlertDisplaying = false;
        public static DateTime AlertDisplayingBeginTime { get; private set; } = DateTime.MinValue;

        public static bool AlertDisplaying
        {
            get
            {
                return _AlertDisplaying;
            }
            set
            {
                _AlertDisplaying = value;
                AlertDisplayingBeginTime = DateTime.UtcNow;
            }
        }

        public static Icon icon = SystemIcons.Information;

        public static List<SharpDataItem> SharpDataQueue { get; } = [];
        public static List<SharpDataItem> SharpDataHistory { get; } = [];
        public static List<string> SharpDataRelayedNamesHistory { get; } = [];
        
        public static string AssemblyFile
        {
            get
            {
                return Environment.ProcessPath ?? string.Empty;
            }
        }

        public static string AssemblyDirectory
        {
            get
            {
                return Path.GetDirectoryName(Environment.ProcessPath) ?? string.Empty;
            }
        }

        public static readonly string CustomURLsFileName = "feeds.txt";

        /// <summary>
        /// Stops everything. Maybe.
        /// </summary>
        public static void SafeExit(bool restart = false)
        {
            AllowThreadRestarts = false;

            DiscordWebhook.SendFormattedMessage($"SharpAlert is stopping.");

            Notify?.ShowNotification("Closing everything down now.",
                "SharpAlert is stopping.",
                ToolTipIcon.Info);

            Thread.Sleep(500);

            try
            {
                Notify?.Dispose();
            }
            catch (ObjectDisposedException)
            {
            }

            new Thread(() =>
            {
                Thread.Sleep(3000);
                Process curProc = Process.GetCurrentProcess();
                if (restart) Environment.ExitCode = 100;
                curProc.Kill();
            }).Start();

            FormCollection forms = Application.OpenForms;

            foreach (Form form in forms)
            {
                form?.Dispose();
            }

            if (restart) Environment.Exit(100);
            else Environment.Exit(0);

            // we should never be going beyond this point, but just in case lol
            return;

            //Notify.ShowNotification($"Haida is working to get everything shutdown. This may take a few moments.",
            //        "SharpAlert is stopping",
            //        ToolTipIcon.Info);

            //Console.WriteLine("Preparing for termination.");
            //AllowThreadRestarts = false;
            //Thread.Sleep(500);

            //bool Finished = false;
            //new Thread(() =>
            //{
            //    try
            //    {
            //        while (!ServiceRunnerScheduled)
            //        {
            //            LogFault(new Exception("The program cannot exit safely, because the service runner hasn't indicated a successful startup."));
            //            Thread.Sleep(2500);
            //            Finished = true;
            //            return;
            //        }

            //        //if (ServiceRunnerScheduled)
            //        {
            //            Console.WriteLine("Hyper Server is shutting down.");
            //            hyper?.ServiceStop();
            //            QuickSettings.Instance.DisableAlertProcessing = true;
            //            QuickSettings.Instance.PauseDataProcessing = true;
            //            //Console.WriteLine("Feed Capture is shutting down.");
            //            //feed?.ServiceStop();
            //            //Console.WriteLine("Direct Feed Capture is shutting down.");
            //            //directfeed?.ServiceStop();
            //            Console.WriteLine("Cache Capture is shutting down.");
            //            cache?.ServiceStop();
            //            Console.WriteLine("Data Processor is shutting down.");
            //            dataproc?.ServiceStop();
            //            Console.WriteLine("Idle Window is shutting down.");
            //            if (idle != null) IdleWindowVisible = false;
            //            Console.WriteLine("Status Window is shutting down.");
            //            if (status != null) StatusWindowVisible = false;
            //            Console.WriteLine("Stopping all sounds.");
            //            try
            //            {
            //                StopAllAudioSilently();
            //            }
            //            catch (Exception)
            //            {
            //                Console.WriteLine("Cannot stop some sounds.");
            //            }
            //            if (!string.IsNullOrWhiteSpace(QuickSettings.Instance.DiscordWebhook))
            //            {
            //                DiscordWebhook.SendFormattedMessage("SharpAlert has stopped.");
            //            }
            //        }
            //    }
            //    catch (Exception)
            //    {
            //    }
            //    Finished = true;
            //}).Start();

            //static void Restart()
            //{
            //    // Only restarts if the watchdog is running, maybe we need to do something to avoid this, or not.
            //    Environment.Exit(100);
            //}

            //// The shutdown messages are just for fun lol

            //for (int i = 0; !(i >= 15);)
            //{
            //    if (Finished)
            //    {
            //        Console.WriteLine("Shutdown was successful. Say thanks to Haida for his hard work... -w-");
            //        Notify.ShowNotification($"Shutdown was successful. Say thanks to Haida for his hard work... -w-",
            //            "SharpAlert has stopped",
            //            ToolTipIcon.Info);

            //        if (restart) Restart();
            //        else Environment.Exit(0);
            //        return;
            //    }
            //    Thread.Sleep(1000);
            //    i++;
            //}

            //Console.WriteLine("Shutdown timed out. Say thanks to Haida for his hard work... -w-");
            //Notify.ShowNotification($"Shutdown timed out. Say thanks to Haida for his hard work... -w-",
            //    "SharpAlert has stopped",
            //    ToolTipIcon.Info);
            
            //if (restart) Restart();
            //else Environment.Exit(0);

            //return;
        }

        public static bool IsAdministrator => new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
        public static bool ServiceMode { get; private set; } = false;
        public static List<string> Args { get; private set; } = [];
        // --alt-config-1/2/3/4

        //private static bool Secret = false;
        //public static bool IsUserSuperSecretAccessor()
        //{
        //    try
        //    {
        //        string userIDs = client.GetStringAsync("https://bunnytub.com/SharpAlert/SharpAlert.shfile").Result;
        //        foreach (string userID in userIDs.Split())
        //        {
        //            if (userID.Contains(InternalUserID.ToString()))
        //            {
        //                Secret = true;
        //                return true;
        //            }
        //        }
        //        return false;
        //    }
        //    catch (Exception)
        //    {
        //        return Secret;
        //    }
        //}

        //private static bool Locked = false;
        //public static bool IsUserLocked()
        //{
        //    try
        //    {
        //        string userIDs = client.GetStringAsync("https://bunnytub.com/SharpAlert/SharpAlert.lkfile").Result;
        //        foreach (string userID in userIDs.Split())
        //        {
        //            if (userID.Contains(InternalUserID.ToString()))
        //            {
        //                Locked = true;
        //                return true;
        //            }
        //        }
        //        return false;
        //    }
        //    catch (Exception)
        //    {
        //        return Locked;
        //    }
        //}

        public static ulong InternalUserID
        {
            get;
            set;
        } = 0;

        public static readonly DateTimeOffset DateUpTime = DateTimeOffset.UtcNow;
        public static Awoken? AwokenNotifier = null;

        /// <summary>
        /// Starts everything.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            //watchdog self-child process
            Args = [.. Environment.GetCommandLineArgs()];

            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                Exception ex = new("Unknown exception.");
                if (e.ExceptionObject is Exception exc) ex = exc;

                if (MessageBox.Show($"{ex.Message}\r\n{ex.StackTrace}" +
                    $"\r\n\r\n" +
                    $"Click OK to close the app.\r\n" +
                    $"Click CANCEL to copy this message too.", "SharpAlert - Toppled Over (Crash)", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.Cancel)
                {
                    Clipboard.SetText($"{ex.Message}\r\n{ex.StackTrace}");
                }
            };

            //AppDomain.CurrentDomain.FirstChanceException += (s, e) =>
            //{
            //    Console.WriteLine($"(First chance exception) {e.Exception.Message}\r\n{e.Exception.StackTrace}");
            //    //if (MessageBox.Show($"{e.Exception.Message}\r\n{e.Exception.StackTrace}", "SharpAlert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
            //    //{
            //    //    Environment.Exit(-1);
            //    //}
            //};

            QuickSettings.Reload();
            Application.SetHighDpiMode(HighDpiMode.DpiUnaware);
            Application.EnableVisualStyles();
            //Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NoneEnabled;
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += (a, b) =>
            {
                UnsafeFault(b.Exception, true);
            };
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            AwokenNotifier = new(true)
            {
                UseBackdrop = false
            };

            Language.Load(QuickSettings.Instance.LanguageCode);

            if (Args.Count >= 2)
            {
                if (Args.Contains("--wait-until-parent-closes"))
                {
                    try
                    {
                        _ = GetParentProcess()?.WaitForExit(10000);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Couldn't identify the parent process to wait for it to exit. It may have already exited. {ex.Message}");
                        Thread.Sleep(5000);
                    }

                    // remove the wait argument, so it doesn't accidentally get parsed by a child process under watchdog
                    Args.RemoveAll(delegate (string str) {
                        return str == "--wait-until-parent-closes";
                    });
                }

                if (Args.Contains("--internal-remove-old"))
                {
                    try
                    {
                        if (File.Exists(AssemblyFile + "_"))
                        {
                            File.Delete(AssemblyFile + "_");
                        }
                    }
                    catch (Exception)
                    {
                    }

                    Args.RemoveAll(delegate (string str) {
                        return str == "--internal-remove-old";
                    });
                }

                if (Args.Contains("--service-mode"))
                {
                    AllocateTerminal(false);
                    Console.WriteLine("SERVICE MODE ACTIVE --- PERFORMANCE MAY BE IMPACTED --- THIS IS FOR TESTING PURPOSES");
                    ServiceMode = true;
                    new Thread(() => { new ServiceMonitorForm().ShowDialog(); }).Start();
                }
                else
                {
                    if (Args.Contains("--console"))
                    {
                        AllocateTerminal(false);
                    }
                }

                if (Args.Contains("--update"))
                {
                    UpdateWorker.TryUpdate(UpdateWorker.TryGetRemoteVersion(), true);
                    return;
                }

                if (Args.Contains("--monitored") || ServiceMode)
                {
                    Mutex mutex = new(false, "BUNNYTUB_EASCULTURE_SharpAlert_ProtectEZ");

                    try
                    {
                        if (!ServiceMode)
                        {
                            if (!Args.Contains("--ignore-duplicates"))
                            {
                                if (!mutex.WaitOne(0, false))
                                {
                                    new Thread(() =>
                                    {
                                        Thread.Sleep(1000 * 15);
                                        Environment.Exit(0);
                                    }).Start();

                                    if (MessageBox.Show("SharpAlert is already running.\r\nDo you want to forcibly close it?",
                                            "SharpAlert",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        Process curProc = Process.GetCurrentProcess();

                                        try
                                        {
                                            foreach (Process proc in Process.GetProcessesByName(Path.GetFileNameWithoutExtension(AssemblyFile)))
                                            {
                                                ProcessModule? procMod = proc.MainModule;
                                                
                                                if (procMod != null)
                                                {
                                                    if (procMod.FileName.Equals(AssemblyFile, StringComparison.InvariantCultureIgnoreCase))
                                                    {
                                                        if (proc != curProc) proc.Kill();
                                                    }
                                                }
                                            }
                                        }
                                        catch (Exception)
                                        {
                                        }
                                    }

                                    Environment.Exit(0);
                                    return;
                                }

                                //VelopackApp.Build().Run();
                            }
                        }

                        new Thread(ServiceRun).Start();

                        if (!ServiceMode)
                        {
                            try
                            {
                                Process? parentProc = GetParentProcess();

                                if (parentProc != null)
                                {
                                    ProcessModule? mainMod = parentProc.MainModule;

                                    if (mainMod != null)
                                    {
                                        if (mainMod.FileName.Equals(AssemblyFile, StringComparison.InvariantCultureIgnoreCase))
                                        {
                                            parentProc.WaitForExit();
                                            QuickSettings.Instance.Save();
                                            SafeExit();
                                        }
                                    }
                                }

                            }
                            catch (Exception)
                            {
                                //LogFault(new Exception("Couldn't identify the parent process. This may limit the ability for SharpAlert to recover from a problem.", ex));
                            }
                        }
                        else
                        {
                            mutex?.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"SharpAlert failed to start! ServiceMode = {ServiceMode}\r\n" +
                            $"{ex.StackTrace}\r\n" +
                            $"{ex.Message}\r\n" +
                            $"Please report this.\r\n" +
                            $"If this is your first time running SharpAlert,\r\n" +
                            $"make sure your operating system is officially supported.\r\n" +
                            $"Make sure no compatibility options are enabled.",
                            "SharpAlert",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        LogFault(ex);
                        try { Environment.Exit(unchecked(ex.HResult)); } catch (Exception) { Environment.Exit(1); }
                    }
                    finally
                    {
                        mutex?.Close();
                    }
                    return;
                }
            }

            bool restartable = true;
            bool debuggable = false;
            bool forceNewWatchdogProcess = false;

            // prevent writing to the config if this is the monitoring process, just in case
            QuickSettings.ReadOnlyMode = true;

            while (restartable)
            {
                ProcessStartInfo self = new()
                {
                    FileName = AssemblyFile,
                    ErrorDialog = false
                };

                if (!forceNewWatchdogProcess)
                {
                    string arguments = "--monitored";
                    foreach (string arg in Args)
                    {
                        arguments += $"\x20{arg}";
                    }

                    if (debuggable)
                    {
                        arguments += $"\x20--call-debugger";
                        debuggable = false;
                    }

                    self.Arguments = arguments;
                }
                else
                {
                    self.Arguments = "--wait-until-parent-closes";
                }

                using Process monitorSelf = new()
                {
                    StartInfo = self
                };

                monitorSelf.Start();

                if (forceNewWatchdogProcess)
                {
                    Environment.Exit(0);
                    return;
                }

                monitorSelf.WaitForExit();
            
                switch (unchecked(monitorSelf.ExitCode))
                {
                    case 0:
                    case -1:
                    case -1073741510:
                        //DiscordWebhook.SendFormattedMessage($"SharpAlert has stopped.");
                        restartable = false;
                        Environment.Exit(0);
                        return;
                    case 100:
                        restartable = true;
                        QuickSettings.Reload();
                        if (!string.IsNullOrWhiteSpace(QuickSettings.Instance.DiscordWebhook))
                        {
                            DiscordWebhook.SendFormattedMessage($"SharpAlert is restarting.");
                        }
                        break;
                    default:
                        restartable = true;
                        QuickSettings.Reload();
                        if (!string.IsNullOrWhiteSpace(QuickSettings.Instance.DiscordWebhook))
                        {
                            switch (unchecked(monitorSelf.ExitCode))
                            {
                                case 1073807364:
                                    DiscordWebhook.SendFormattedMessage($"SharpAlert has stopped because the host is shutting down.");
                                    Thread.Sleep(5000);
                                    Environment.Exit(0);
                                    break;
                                case -1073741571:
                                    DiscordWebhook.SendFormattedMessage($"SharpAlert has stopped abruptly due to a recursion problem.");
                                    break;
                                case -1073741819:
                                case -1073740791:
                                case -1073740940:
                                case -1073741553:
                                case -1073741800:
                                case -1073740988:
                                    DiscordWebhook.SendFormattedMessage($"SharpAlert has stopped abruptly due to a security problem.");
                                    break;
                                default:
                                    DiscordWebhook.SendFormattedMessage($"SharpAlert has stopped abruptly. ({monitorSelf.ExitCode})");
                                    break;
                            }
                        }

                        string Details = $"SharpAlert closed with a non-zero exit code. ({unchecked(monitorSelf.ExitCode)})\r\n" +
                            $"{new Win32Exception(unchecked(monitorSelf.ExitCode)).Message}";
                        LogFault(new Exception(Details));
                        ToppleForm tf = new(Details, true);
                        tf.ShowDialog();
                        if (tf.DialogResult == DialogResult.Yes) debuggable = true;
                        else debuggable = false;
                        tf.Dispose();
                        break;
                }

                monitorSelf.Dispose();
            }
        }

        private static Process? GetParentProcess()
        {
            int iParentPid = 0;
            int iCurrentPid = Environment.ProcessId;

            IntPtr oHnd = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);

            if (oHnd == IntPtr.Zero)
                return null;

            PROCESSENTRY32 oProcInfo = new()
            {
                dwSize =
                (uint)Marshal.SizeOf(typeof(PROCESSENTRY32))
            };

            if (Process32First(oHnd, ref oProcInfo) == false)
                return null;

            do
            {
                if (iCurrentPid == oProcInfo.th32ProcessID)
                    iParentPid = (int)oProcInfo.th32ParentProcessID;
            }
            while (iParentPid == 0 && Process32Next(oHnd, ref oProcInfo));

            if (iParentPid > 0)
                return Process.GetProcessById(iParentPid);
            else
                return null;
        }

        private static readonly UpdateManager UpdateMgr = new(new GithubSource("https://github.com/BunnyTub/SharpAlert", string.Empty, false));

        private static bool NotInstalledMessageShown = false;

        internal static async Task<UpdateInfo?> CheckUpdate()
        {
            try
            {
                UpdateInfo? info = await UpdateMgr.CheckForUpdatesAsync();
                return info;
            }
            catch (NotInstalledException)
            {
                if (!NotInstalledMessageShown)
                {
                    NotInstalledMessageShown = true;
                    MessageBox.Show("SharpAlert doesn't seem to be installed. Updates won't be available. Check https://bunnytub.com/SharpAlert for up-to-date downloads.", "SharpAlert - Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return null;
            }
        }

        internal static int UpdateProgress = -1;

        internal static async Task DoUpdate(UpdateInfo info)
        {
            await UpdateMgr.DownloadUpdatesAsync(info, (int progress) =>
            {
                UpdateProgress = progress;
            });

            QuickSettings.Instance.Save();

            UpdateMgr.ApplyUpdatesAndRestart(info, ["-fr"]);
        }

        private static readonly uint TH32CS_SNAPPROCESS = 2;

        [StructLayout(LayoutKind.Sequential)]
        public struct PROCESSENTRY32
        {
            public uint dwSize;
            public uint cntUsage;
            public uint th32ProcessID;
            public IntPtr th32DefaultHeapID;
            public uint th32ModuleID;
            public uint cntThreads;
            public uint th32ParentProcessID;
            public int pcPriClassBase;
            public uint dwFlags;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szExeFile;
        };

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateToolhelp32Snapshot(uint dwFlags, uint th32ProcessID);

        [DllImport("kernel32.dll")]
        static extern bool Process32First(IntPtr hSnapshot, ref PROCESSENTRY32 lppe);

        [DllImport("kernel32.dll")]
        static extern bool Process32Next(IntPtr hSnapshot, ref PROCESSENTRY32 lppe);

        /// <summary>
        /// Returns an MD5 value of the input string.
        /// </summary>
        /// <param name="input">The string to produce an MD5 from.</param>
        /// <returns></returns>
        public static string CreateMD5(string input)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = MD5.HashData(inputBytes);

            StringBuilder sb = new();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }

        //private static object IdleWindowVisible_ = false;
        //public static bool IdleWindowVisible
        //{
        //    get => (bool)IdleWindowVisible_;
        //    set
        //    {
        //        lock (IdleWindowVisible_)
        //        {
        //            if (value)
        //            {
        //                ThreadDrool.StartAndForget(() =>
        //                {
        //                    if (idle != null && !idle.IsDisposed)
        //                    {
        //                        idle.Invoke(new MethodInvoker(() => idle.Dispose()));
        //                    }
        //                    else
        //                    {
        //                        idle = new TeleIdleForm();
        //                    }
        //                    idle?.ShowDialog();
        //                });
        //            }
        //            else
        //            {
        //                if (idle != null && !idle.IsDisposed)
        //                {
        //                    idle.Invoke(new MethodInvoker(() => idle.Dispose()));
        //                }
        //            }

        //            IdleWindowVisible_ = value;
        //        }
        //    }
        //}

        //private static object StatusWindowVisible_ = false;
        //public static bool StatusWindowVisible
        //{
        //    get => (bool)StatusWindowVisible_;
        //    set
        //    {
        //        lock (StatusWindowVisible_)
        //        {
        //            if (value)
        //            {
        //                ThreadDrool.StartAndForget(() =>
        //                {
        //                    if (status != null && !status.IsDisposed)
        //                    {
        //                        status.Invoke(new MethodInvoker(() => status.Dispose()));
        //                    }
        //                    else
        //                    {
        //                        status = new StatusForm();
        //                    }
        //                    status?.ShowDialog();
        //                });
        //            }
        //            else
        //            {
        //                if (status != null && !status.IsDisposed)
        //                {
        //                    status.Invoke(new MethodInvoker(() => status.Dispose()));
        //                }
        //            }

        //            StatusWindowVisible_ = value;
        //        }
        //    }
        //}

        public static bool ClearAlertHistory()
        {
            lock (SharpDataHistory)
            {
                lock (SharpDataRelayedNamesHistory)
                {
                    if (SharpDataHistory.Count != 0 || SharpDataRelayedNamesHistory.Count != 0)
                    {
                        SharpDataHistory.Clear();
                        SharpDataRelayedNamesHistory.Clear();
                        AwokenNotifier?.ShowBasicText("The alert history was destroyed.");
                        return true;
                    }
                    else
                    {
                        AwokenNotifier?.ShowBasicText("The alert history is already empty!");
                        return false;
                    }
                }
            }
        }
    }
}

