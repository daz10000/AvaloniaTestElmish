namespace AvaloniaTest.Views

open Avalonia
open Avalonia.Controls
open Avalonia.Markup.Xaml

type CounterView () as this =
    inherit UserControl ()

    do
        printfn $"CounterView: initialize component"
        this.InitializeComponent()
        printfn $"CounterView: initialize component done"

    member private this.InitializeComponent() =
        printfn $"CounterView: initialize component loading"
        AvaloniaXamlLoader.Load(this)
        printfn $"CounterView: initialize component done loading"
