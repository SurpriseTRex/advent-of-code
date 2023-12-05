module AdventOfCode.FSharp._2023.Days.Day01

open System
open System.IO
open System.Text.RegularExpressions
open AdventOfCode.FSharp._2023.Modules

let readExamplePart1 = File.ReadLines("Inputs/01/example_01_01.txt")
let readExamplePart2 = File.ReadLines("Inputs/01/example_01_02.txt")
let readInput = File.ReadLines("Inputs/01/input_01.txt")


let numberRegex = Regex "(?=(\d){1}).*(\d){1}"

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

let tupleToInt (a, b) = $"{a}{b}" |> int

let getMatches (regex: Regex) input = regex.Match input

let firstLastMatchGroup (m: Match) =
    m.Groups
    |> Seq.skip 1
    |> Seq.take 2
    |> Seq.map string
    |> fun pair -> (Seq.head pair, Seq.last pair)

let processLine regex input =
    input
    |> getMatches regex
    |> firstLastMatchGroup
    |> Pair.map toDigit
    |> tupleToInt

let day1Part1 = readInput |> Seq.map (processLine numberRegex) |> Seq.sum

let day1Part2 = readInput |> Seq.map (processLine numberWithWordRegex) |> Seq.sum
