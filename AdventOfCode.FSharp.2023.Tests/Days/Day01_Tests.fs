module Day01_Tests

open AdventOfCode.FSharp._2023.Modules.Files
open Xunit
open AdventOfCode.FSharp._2023.Days.Day01

[<Fact>]
let ``day01 part 01`` () =
    Assert.Equal(56042, Inputs.read 1 |> day1Part1)

[<Fact>]
let ``day 01 part 02 regex`` () =
    Assert.Equal(55358, Inputs.read 1 |> day1Part2)
    
[<Fact>]
let ``day 01 part 02 recursive`` () =
    Assert.Equal(55358, Inputs.read 1 |> processRecursive)
        
[<Fact>]
let ``day 01 part 02 finding indexes`` () =
    Assert.Equal(55358, Inputs.read 1 |> processIndexes)
