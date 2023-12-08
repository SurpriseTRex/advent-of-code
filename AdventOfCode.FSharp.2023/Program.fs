// For more information see https://aka.ms/fsharp-console-apps
open AdventOfCode.FSharp._2023.Days.Day01
open AdventOfCode.FSharp._2023.Modules.Files
open AdventOfCode.FSharp._2023.Modules.Timing

let regex = Inputs.read 1 |> benchmark "regex" day1Part2    
let recurse = Inputs.read 1 |> benchmark "recursive" processRecursive
let indexes = Inputs.read 1 |> benchmark "index" processIndexes

[regex, recurse, indexes] |> Seq.iter (printfn "%A")