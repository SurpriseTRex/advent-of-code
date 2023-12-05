module AdventOfCode.FSharp._2023.Days.Day01

open System.Text.RegularExpressions
open AdventOfCode.FSharp._2023.Modules
open AdventOfCode.FSharp._2023.Modules.Files

let private numberRegex = Regex "(?=(\d){1}).*(\d){1}"

let private numberWithWordRegex =
    Regex(
        "(?=(one|two|three|four|five|six|seven|eight|nine|\d){1}).*(one|two|three|four|five|six|seven|eight|nine|\d){1}"
    )

let private toDigit (input: string) =
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

let private tupleToInt (a, b) = $"{a}{b}" |> int

let private getMatches (regex: Regex) input = regex.Match input

let private firstLastMatchGroup (m: Match) =
    m.Groups
    |> Seq.skip 1
    |> Seq.take 2
    |> Seq.map string
    |> fun pair -> (Seq.head pair, Seq.last pair)

let private processLine regex input =
    input
    |> getMatches regex
    |> firstLastMatchGroup
    |> Pair.map toDigit
    |> tupleToInt

let day1Part1 = Inputs.read 1 |> Seq.map (processLine numberRegex) |> Seq.sum

let day1Part2 = Inputs.read 1 |> Seq.map (processLine numberWithWordRegex) |> Seq.sum
