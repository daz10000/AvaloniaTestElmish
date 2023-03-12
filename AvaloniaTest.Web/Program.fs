open System.Runtime.Versioning
open Avalonia
open Avalonia.Browser

open AvaloniaTest
open Elmish.Avalonia.AppBuilder

module Program =
    [<assembly: SupportedOSPlatform("browser")>]
    do
        printfn "AAA"

    [<CompiledName "BuildAvaloniaApp">]
    let buildAvaloniaApp () =
        printfn "BBB"
        AppBuilder
            .Configure<App>()

    [<EntryPoint>]
    let main argv =
        printfn "XXX"
        System.Diagnostics.Trace.Listeners.Add( new System.Diagnostics.ConsoleTraceListener()) |> ignore
        try
            buildAvaloniaApp()
                .LogToTrace(Logging.LogEventLevel.Verbose
                            (*
                            areas=[|
                                Logging.LogArea.Binding
                                Logging.LogArea.Win32Platform
                                Logging.LogArea.Control
                                //Logging.LogArea.Property
                                //Logging.LogArea.Visual
                                Logging.LogArea.Animations
                                Logging.LogArea.Platform
                            |]
                            *)
                        )
                .UseElmishBindings()
                .SetupBrowserApp("out")
                |> ignore
        with x ->
            printfn "ZZZ"
            printfn $"Exception: {x.Message}\n{x.StackTrace}"
        printfn "YYY"
        0
