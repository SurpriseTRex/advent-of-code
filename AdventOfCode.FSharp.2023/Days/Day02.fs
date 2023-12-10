module AdventOfCode.FSharp._2023.Days.Day02

open AdventOfCode.FSharp._2023.Modules.Files

let e1 = Examples.read 2 1

type Color =
    | Red
    | Green
    | Blue

type Hand = Color * int

let toHandfulOfCubes (hand: string) =
    let toColor =
        function
        | "red" -> Red
        | "green" -> Green
        | "blue" -> Blue
        | _ -> failwith "todo"

    let doMapping =
        function
        | [| i; c |] -> Hand(toColor c, int i)
        | _ -> failwith "todo"

    hand.Split ' ' |> doMapping

let trim (s: string) = s.Trim()

let splitSetsIntoHands (sets: string) = sets.Split(';', ',') |> Array.map trim

let gameID (game: string) =
    game.Split ' ' |> Array.skip 1 |> Array.head |> int

let isPossibleHand (limits: Map<Color, int>) input =
    let (c, i) = input
    limits[c] >= i

let arePossibleHands limits hands =
    hands |> Array.forall (isPossibleHand limits)

let parseRow (row: string) =
    let doMapping =
        function
        | [| game; sets |] -> (game |> gameID, sets |> splitSetsIntoHands |> Array.map toHandfulOfCubes)
        | _ -> failwith "todo"

    row.Split ':' |> doMapping

let processPart1 limits input =
    input
    |> Seq.map parseRow
    |> Seq.filter (fun (_, hands) -> hands |> arePossibleHands limits)
    |> Seq.sumBy fst

let getPower row =
    let powerOf color hands =
        hands
        |> Seq.filter (fun (c, _) -> c = color)
        |> Seq.maxBy snd
        |> snd
        
    (snd row |> powerOf Red) *
    (snd row |> powerOf Green) *
    (snd row |> powerOf Blue)
    
let processPart2 input =
     input
     |> Seq.map parseRow
     |> Seq.map getPower
     |> Seq.sum
     