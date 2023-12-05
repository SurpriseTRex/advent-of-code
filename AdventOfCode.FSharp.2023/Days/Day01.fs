module AdventOfCode.FSharp._2023.Days.Day01

open System
open System.IO
open System.Text.RegularExpressions

let readExamplePart1 = File.ReadLines("Inputs/01/example_01_01.txt")
let readExamplePart2 = File.ReadLines("Inputs/01/example_01_02.txt")
let readInput = File.ReadLines("Inputs/01/input_01.txt")


let numberWithWordRegex =
    Regex(
        "(?=(one|two|three|four|five|six|seven|eight|nine|\d){1}).*(one|two|three|four|five|six|seven|eight|nine|\d){1}"
    )

let toDigit (input: string) =
    match input with
    | "one" -> "1"
    | "two" -> "2"
    | "three" -> "3"
    | "four" -> "4"
    | "five" -> "5"
    | "six" -> "6"
    | "seven" -> "7"
    | "eight" -> "8"
    | "nine" -> "9"
    | s -> s

let digitsOnly input = input |> Seq.filter Char.IsDigit

let getFirstAndLast input = (Seq.head input, Seq.last input)

let convertToInt (a, b) = $"{a}{b}" |> int

let processLinePart1 input =
    input |> digitsOnly |> getFirstAndLast |> convertToInt

let getMatches input = numberWithWordRegex.Match input

let firstLastMatchGroup (m: Match) =
    m.Groups
    |> Seq.skip 1
    |> Seq.take 2
    |> Seq.map string
    |> fun pair -> (Seq.head pair, Seq.last pair)

let processLinePart2 input =
    input
    |> getMatches
    |> firstLastMatchGroup
    |> (fun (a, b) -> (toDigit a, toDigit b))
    |> convertToInt

let day1Part1 = readInput |> Seq.map processLinePart2 |> Seq.sum

let day1Part2 = readInput |> Seq.map processLinePart2 |> Seq.sum
