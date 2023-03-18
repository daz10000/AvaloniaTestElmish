namespace AvaloniaTest

open Avalonia
open Avalonia.Markup.Xaml
open AvaloniaTest.Views
open Avalonia.Controls.ApplicationLifetimes

type App() =
    inherit Application()

    override this.Initialize() =
        // Initialize Avalonia controls from NuGet packages:
        printfn "App.Initialize top"
        let _ = typeof<Avalonia.Controls.DataGrid>
        printfn "App.Initialize loading"

        AvaloniaXamlLoader.Load(this)
        printfn "App.Initialize loaded"

    override this.OnFrameworkInitializationCompleted() =
        printfn "App.OnFrameworkInit top"
        match this.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime as desktop ->
            printfn "App.OnFrameworkInit classic view"
            let view = MainView()
            printfn "App.OnFrameworkInit got view"
            // HACKHACK - commented out since this won't work for a usercontrol
            // desktop.MainWindow <- view
            printfn "App.OnFrameworkInit starting"
            try
                ViewModels.MainViewModel.vm.Start(view)
            with x ->
                printfn $"Exception: {x.Message} \n {x.StackTrace}"
            printfn "App.OnFrameworkInit started"
        | :? ISingleViewApplicationLifetime as singleViewLifetime ->
            try
                printfn "App.OnFrameworkInit single view lifetime"
                printfn "App.OnFrameworkInit set mainview"

                let view = MainView()
                singleViewLifetime.MainView <- view

                let x = ViewModels.MainViewModel.vm
                printfn "App.OnFrameworkInit start vm"
                x.Start(view)
                printfn "App.OnFrameworkInit done"
            with x ->
                printfn $"Exception: {x.Message} \n {x.StackTrace}"

        | _ ->
            // leave this here for design view re-renders
            printfn "App.OnFrameworkInit other view"

        printfn "App.OnFrameworkInit mark completed"
        base.OnFrameworkInitializationCompleted()
        printfn "App.OnFrameworkInit done"
