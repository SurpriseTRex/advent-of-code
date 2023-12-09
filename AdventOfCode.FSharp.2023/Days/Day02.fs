module AdventOfCode.FSharp._2023.Days.Day02

open AdventOfCode.FSharp._2023.Modules.Files

let e1 = Examples.read 2 1

// 12 red, 13 green, 14 blue
// e1 = 8

// e1 |> Seq.iter (printfn "%A")


type Draw =
    | Red of int
    | Green of int
    | Blue of int

type Game = Game of id: int * draws: Draw list

let (|GameNumber|_|) (input: string) =
    match input.Split(' ') with
    | [| _; id |] -> id |> int |> Some
    | _ -> None

let (|Draw|_|) (input: string) =
    match input.Split ' ' with
    | [| i; "red" |] -> Red(i |> int) |> Some
    | [| i; "blue" |] -> Blue(i |> int) |> Some
    | [| i; "green" |] -> Green(i |> int) |> Some
    | _ -> None

    
let toSets (input: string) =
    input.Split(',', ';') |> Seq.map (fun s -> s.Trim())

let toGame (input: string) =
    input.Split ":" |> fun split -> (split |> Seq.head, split[1] |> toSets)
