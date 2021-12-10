// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open System.Threading

[<EntryPoint>]
let main argv =

    Console.WriteLine(SquidBingo.bingo)
    let closing = new AutoResetEvent(false)
    let onExit = new ConsoleCancelEventHandler(fun _ args -> Console.WriteLine("Exit"); closing.Set() |> ignore)
    Console.CancelKeyPress.AddHandler onExit
    closing.WaitOne() |> ignore
    0