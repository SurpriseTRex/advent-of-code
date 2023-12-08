module AdventOfCode.FSharp._2023.Modules.Timing

let withTiming func arg =
    let sw = System.Diagnostics.Stopwatch.StartNew()
    func arg |> ignore
    sw.Stop()
    sw.Elapsed

let runNTimes times func arg =
    Array.init times (fun _ -> func arg)

let benchmark name func arg =
    let func = withTiming func
    runNTimes 500 func arg
    |> Array.averageBy(fun r -> r.TotalSeconds)
    |> fun seconds -> (name, System.TimeSpan.FromSeconds seconds)