namespace AvaloniaTest.Desktop
open System
open Avalonia
open AvaloniaTest
open Elmish.Avalonia.AppBuilder

module Program =
    let BuildAvaloniaApp() =
        AppBuilder
            .Configure<App>()
            .UsePlatformDetect()
            .UseElmishBindings()


    [<EntryPoint; STAThread>]
    let main argv =
        BuildAvaloniaApp().StartWithClassicDesktopLifetime(argv) |> ignore
        0
