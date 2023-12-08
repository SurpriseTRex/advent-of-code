module AdventOfCode.FSharp._2023.Modules.Files

open System.IO

module Inputs =
    let read day =
        $"Inputs/%02i{day}/input_%02i{day}.txt" |> File.ReadLines

module Examples =
    let read day part =
        $"Inputs/%02i{day}/example_%02i{day}_%02i{part}.txt" |> File.ReadLines
