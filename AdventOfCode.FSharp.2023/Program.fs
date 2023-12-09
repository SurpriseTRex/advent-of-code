// For more information see https://aka.ms/fsharp-console-apps
open AdventOfCode.FSharp._2023.Days.Day02
open AdventOfCode.FSharp._2023.Modules.Files

// Examples.read 2 1
//      |> Seq.map toGame
//      |> Seq.iter (printfn "%A")


let x = "1 green, 2 red, 1 blue; 2 blue; 1 blue; 34 red"

x
|> toSets
|> Seq.map (fun set ->
    match set with
    | Draw d -> d
    | _ -> failwith "todo")
|> Seq.iter (printfn "%A")
