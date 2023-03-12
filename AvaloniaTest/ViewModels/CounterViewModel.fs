module AvaloniaTest.ViewModels.CounterViewModel

open System
open Elmish.Avalonia

type Model =
    {
        Count: int
        Actions: Action list
    }

and Action =
    {
        Description: string
        Timestamp: DateTime
    }

type Msg =
    | Increment
    | Decrement
    | Reset

let init() =
    printfn $"CounterViewModel: init model state"
    {
        Count = 100
        Actions = [ { Description = "Initialized count."; Timestamp = DateTime.Now } ]
    }

let update (msg: Msg) (model: Model) =
    printfn $"Update:msg={msg}"
    match msg with
    | Increment ->
        { model with
            Count = model.Count + 1
            Actions = model.Actions @ [ { Description = "Incremented"; Timestamp = DateTime.Now } ]
        }
    | Decrement ->
        { model with
            Count = model.Count - 1
            Actions = model.Actions @ [ { Description = "Decremented"; Timestamp = DateTime.Now } ]
        }
    | Reset ->
        init()

let bindings ()  : Binding<Model, Msg> list =
    printfn "bindings: called"
    [
        "Count" |> Binding.oneWay (fun m -> printfn "bind: get count"; m.Count)
        "Actions" |> Binding.oneWay (fun m -> printfn "bind: get actions"; m.Actions)
        "Increment" |> Binding.cmd Increment
        "Decrement" |> Binding.cmd Decrement
        "Reset" |> Binding.cmd Reset
    ]

let designVM = ViewModel.designInstance (init()) (bindings())

printfn "CounterViewModel - initializing vm"
let vm = Start(AvaloniaProgram.mkSimple init update bindings
            |> AvaloniaProgram.withElmishErrorHandler
                (fun msg exn ->
                    printfn $"ElmishErrorHandlerCV: msg={msg}\n{exn.Message}\n{exn.StackTrace}"
                )
        )
printfn "CounterViewModel - done"
