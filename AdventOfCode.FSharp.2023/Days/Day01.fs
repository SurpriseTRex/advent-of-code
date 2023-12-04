module AdventOfCode.FSharp._2023.Days.Day01

open System
open System.IO

let readExample = File.ReadLines("Inputs/01/example_01.txt")
let readInput = File.ReadLines("Inputs/01/input_01.txt")

let toChars input = List.ofSeq input

let getDigits input = input |> List.filter Char.IsDigit

let getFirstAndLast input = (List.head input, List.last input)

let convertToInt (a, b) = $"{a}{b}" |> int


let exampleInput = readExample |> List.ofSeq
let realInput = readInput |> List.ofSeq

let processLines input =
    input
    |> toChars
    |> getDigits
    |> getFirstAndLast
    |> convertToInt
    // |> printfn "%A"
    
realInput |> List.map processLines |> List.sum |> printfn "%A"