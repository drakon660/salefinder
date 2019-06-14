//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace SaleFinder
//{
//    class CefGlueInProgress
//    {
//        CefRuntime.Load();
//            var cefMainArgs = new CefMainArgs(args);
//        var cefSettings = new CefSettings
//        {

//            LogFile = "cef.log",
//            LogSeverity = CefLogSeverity.Verbose,
//            RemoteDebuggingPort = 4200,

//            ResourcesDirPath = System.IO.Path.GetDirectoryName(new Uri(System.Reflection.Assembly.GetEntryAssembly().CodeBase).LocalPath)

//        };
//            if (CefRuntime.ExecuteProcess(cefMainArgs, new DemoCefApp()) != -1)
//            {
//                Console.Error.WriteLine("Could not the secondary process.");
//            }

//    CefRuntime.Initialize(cefMainArgs, cefSettings, new DemoCefApp(), IntPtr.Zero);
//            CefWindowInfo cefWindowInfo = CefWindowInfo.Create();
//    //cefWindowInfo.SetAsWindowless(IntPtr.Zero, false);
//    var browser = CefBrowserHost.CreateBrowserSync(cefWindowInfo, new DemoCefClient(), new CefBrowserSettings(), "http://google.pl");
//    Console.ReadKey();
//            //WebBrowser webBrowser = new WebBrowser()

//            // Instruct CEF to not render to a window at all.
            
//            //cefWindowInfo.SetAsWindowless(IntPtr.Zero);

//            //CefGlueBrowser cefGlueBrowser = CefGlueBrowser.
            
//    }

//nternal sealed class DemoBrowserProcessHandler : CefBrowserProcessHandler
//{
//    protected override void OnBeforeChildProcessLaunch(CefCommandLine commandLine)
//    {
//        Console.WriteLine("AppendExtraCommandLineSwitches: {0}", commandLine);
//        Console.WriteLine(" Program == {0}", commandLine.GetProgram());

//        // .NET in Windows treat assemblies as native images, so no any magic required.
//        // Mono on any platform usually located far away from entry assembly, so we want prepare command line to call it correctly.
//        if (Type.GetType("Mono.Runtime") != null)
//        {
//            if (!commandLine.HasSwitch("cefglue"))
//            {
//                var path = new Uri(Assembly.GetEntryAssembly().CodeBase).LocalPath;
//                commandLine.SetProgram(path);

//                var mono = CefRuntime.Platform == CefRuntimePlatform.Linux ? "/usr/bin/mono" : @"C:\Program Files\Mono-2.10.8\bin\monow.exe";
//                commandLine.PrependArgument(mono);

//                commandLine.AppendSwitch("cefglue", "w");
//            }
//        }

//        Console.WriteLine("  -> {0}", commandLine);
//    }
//}
//class DemoRenderProcessHandler : CefRenderProcessHandler
//{



//}
//internal sealed class DemoCefApp : CefApp
//{
//    private CefBrowserProcessHandler _browserProcessHandler = new DemoBrowserProcessHandler();
//    private CefRenderProcessHandler _renderProcessHandler = new DemoRenderProcessHandler();

//    protected override void OnBeforeCommandLineProcessing(string processType, CefCommandLine commandLine)
//    {
//        Console.WriteLine("OnBeforeCommandLineProcessing: {0} {1}", processType, commandLine);

//        // TODO: currently on linux platform location of locales and pack files are determined
//        // incorrectly (relative to main module instead of libcef.so module).
//        // Once issue http://code.google.com/p/chromiumembedded/issues/detail?id=668 will be resolved
//        // this code can be removed.
//        if (CefRuntime.Platform == CefRuntimePlatform.Linux)
//        {
//            var path = new Uri(Assembly.GetEntryAssembly().CodeBase).LocalPath;
//            path = Path.GetDirectoryName(path);

//            commandLine.AppendSwitch("resources-dir-path", path);
//            commandLine.AppendSwitch("locales-dir-path", Path.Combine(path, "locales"));
//        }
//    }

//    protected override CefBrowserProcessHandler GetBrowserProcessHandler()
//    {
//        return _browserProcessHandler;
//    }

//    protected override CefRenderProcessHandler GetRenderProcessHandler()
//    {
//        return _renderProcessHandler;
//    }
//}
//class DemoCefClient : CefClient
//{
//    protected override CefLoadHandler GetLoadHandler()
//    {
//        return new DemoCefLoadHandler();
//    }
//}
//class DemoCefLoadHandler : CefLoadHandler
//{
//    protected override void OnLoadingStateChange(CefBrowser browser, bool isLoading, bool canGoBack, bool canGoForward)
//    {
//        Console.WriteLine($"loading {isLoading}");
//    }
//}
//    //internal class DemoCefClient : CefClient
//    //{
//    //    private readonly DemoCefLoadHandler _loadHandler;
//    //    private readonly DemoCefRenderHandler _renderHandler;

//    //    public DemoCefClient(int windowWidth, int windowHeight)
//    //    {
//    //        _renderHandler = new DemoCefRenderHandler(windowWidth, windowHeight);
//    //        _loadHandler = new DemoCefLoadHandler();
//    //    }

//    //    protected override CefRenderHandler GetRenderHandler()
//    //    {
//    //        return _renderHandler;
//    //    }

//    //    protected override CefLoadHandler GetLoadHandler()
//    //    {
//    //        return _loadHandler;
//    //    }
//    //}

//    //internal class DemoCefRenderHandler : CefRenderHandler
//    //{
//    //    private readonly int _windowHeight;
//    //    private readonly int _windowWidth;

//    //    public DemoCefRenderHandler(int windowWidth, int windowHeight)
//    //    {
//    //        _windowWidth = windowWidth;
//    //        _windowHeight = windowHeight;
//    //    }

//    //    protected override bool GetRootScreenRect(CefBrowser browser, ref CefRectangle rect)
//    //    {
//    //        return GetViewRect(browser, ref rect);
//    //    }

//    //    protected override bool GetScreenPoint(CefBrowser browser, int viewX, int viewY, ref int screenX, ref int screenY)
//    //    {
//    //        screenX = viewX;
//    //        screenY = viewY;
//    //        return true;
//    //    }

//    //    protected override bool GetViewRect(CefBrowser browser, ref CefRectangle rect)
//    //    {
//    //        rect.X = 0;
//    //        rect.Y = 0;
//    //        rect.Width = _windowWidth;
//    //        rect.Height = _windowHeight;
//    //        return true;
//    //    }

//    //    protected override bool GetScreenInfo(CefBrowser browser, CefScreenInfo screenInfo)
//    //    {
//    //        return false;
//    //    }

//    //    protected override void OnPopupSize(CefBrowser browser, CefRectangle rect)
//    //    {
//    //    }

//    //    protected override void OnPaint(CefBrowser browser, CefPaintElementType type, CefRectangle[] dirtyRects, IntPtr buffer, int width, int height)
//    //    {
//    //        // Save the provided buffer (a bitmap image) as a PNG.

//    //    }


//    //    protected override CefAccessibilityHandler GetAccessibilityHandler()
//    //    {

//    //    }

//    //    protected override void OnCursorChange(CefBrowser browser, IntPtr cursorHandle, CefCursorType type, CefCursorInfo customCursorInfo)
//    //    {

//    //    }

//    //    protected override void OnScrollOffsetChanged(CefBrowser browser, double x, double y)
//    //    {

//    //    }

//    //    protected override void OnImeCompositionRangeChanged(CefBrowser browser, CefRange selectedRange, CefRectangle[] characterBounds)
//    //    {

//    //    }
//    //}
//}
