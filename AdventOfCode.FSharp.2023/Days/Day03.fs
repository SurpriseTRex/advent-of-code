module AdventOfCode.FSharp._2023.Days.Day03

open System
open AdventOfCode.FSharp._2023.Modules.Files

let rows = Examples.read 03 01

let findSymbolIndexes row = 
    row
    |> Seq.choose symbolIndex