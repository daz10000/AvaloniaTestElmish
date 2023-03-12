module AvaloniaTest.ViewModels.MainViewModel

open Elmish.Avalonia

type Model =
    {
        ContentVM: IStart
    }

type Msg =
    | Msg

let init() =
    printfn "MainView:init"
    {
        ContentVM = CounterViewModel.vm
    }

let update (msg: Msg) (model: Model) =
    printfn "MainView:update {msg}"
    model

let bindings() : Binding<Model, Msg> list =
    printfn "MainView: bindings"
    [
    // Properties
    "ContentVM" |> Binding.oneWay (fun m -> m.ContentVM) ]

printfn $"MainViewModel : create designVM"
let designVM = ViewModel.designInstance (init()) (bindings())

printfn $"MainViewModel : create vm"
let vm : IStart =
    Start(
            AvaloniaProgram.mkSimple init update bindings
            |> AvaloniaProgram.withElmishErrorHandler
                (fun msg exn ->
                    printfn $"ElmishErrorHandler: msg={msg}\n{exn.Message}\n{exn.StackTrace}"
                )
    )
