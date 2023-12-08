module AdventOfCode.FSharp._2023.Days.Day01

open System
open System.Text.RegularExpressions
open AdventOfCode.FSharp._2023.Modules

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

let day1Part1 input =
    input |> Seq.map (processLine numberRegex) |> Seq.sum

let day1Part2 input =
    input |> Seq.map (processLine numberWithWordRegex) |> Seq.sum

let private (|Prefix|_|) (prefix: string) (text: string) =
    if text.StartsWith(prefix) then Some prefix else None

let private recursiveScan input =
    let rec innerScan text acc =
        match text with
        | "" -> acc |> List.rev
        | s when Char.IsDigit s[0] -> innerScan s[1..] ($"{s[0]}" :: acc)
        | Prefix "one" num -> innerScan text[1..] (num :: acc)
        | Prefix "two" num -> innerScan text[1..] (num :: acc)
        | Prefix "three" num -> innerScan text[1..] (num :: acc)
        | Prefix "four" num -> innerScan text[1..] (num :: acc)
        | Prefix "five" num -> innerScan text[1..] (num :: acc)
        | Prefix "six" num -> innerScan text[1..] (num :: acc)
        | Prefix "seven" num -> innerScan text[1..] (num :: acc)
        | Prefix "eight" num -> innerScan text[1..] (num :: acc)
        | Prefix "nine" num -> innerScan text[1..] (num :: acc)
        | _ -> innerScan text[1..] acc

    innerScan input List.Empty
    |> (fun l -> (Seq.head l, Seq.last l))
    |> (fun (a, b) -> toDigit a, toDigit b)

let processRecursive input =
    input |> Seq.map recursiveScan |> Seq.map tupleToInt |> Seq.sum


let private numWords =
    [ "one"
      "two"
      "three"
      "four"
      "five"
      "six"
      "seven"
      "eight"
      "nine"
      "1"
      "2"
      "3"
      "4"
      "5"
      "6"
      "7"
      "8"
      "9" ]

let private getFirstIndex (input: string) (substring: string) = input.IndexOf(substring)

let private getLastIndex (input: string) (substring: string) = input.LastIndexOf(substring)

let private getBothIndexes (input: string) (substring: string) =
    [ (substring, getFirstIndex input substring)
      (substring, getLastIndex input substring) ]

let private wasFound (_, i) = i >= 0

let private findIndexes inputLine =
    numWords
    |> Seq.collect (getBothIndexes inputLine)
    |> Seq.filter wasFound
    |> Seq.sortBy snd
    |> fun x -> (Seq.head x |> fst, Seq.last x |> fst)
    |> fun (a, b) -> $"{toDigit a}{toDigit b}"
    |> int
    
let processIndexes input =
    input
    |> Seq.map findIndexes
    |> Seq.sum