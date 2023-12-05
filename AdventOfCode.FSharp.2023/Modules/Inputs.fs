module AdventOfCode.FSharp._2023.Modules.Inputs

open System.IO

let readInput day =
    $"Inputs/%02i{day}/input_%02i{day}.txt" |> File.ReadLines

let readExample day part =
    $"Inputs/%02i{day}/example_%02i{day}_%02i{part}.txt"
