namespace AvaloniaTest.ViewModels

open Elmish.Avalonia

type IStart =
    abstract member Start : view:Avalonia.Controls.Control -> unit

/// Used to bind a view with a view model and provides a method to start the Elmish loop.
type Start<'model, 'msg>(program: AvaloniaProgram<'model, 'msg>) =
    interface IStart with
        member this.Start(view: Avalonia.Controls.Control) =
            printfn $"Start:IStart running startElmishLoop"
            try
                program
                |> AvaloniaProgram.startElmishLoop view
            with x ->
                printfn $"StartElmishLoop exited with {x.Message}\n{x.StackTrace}"
