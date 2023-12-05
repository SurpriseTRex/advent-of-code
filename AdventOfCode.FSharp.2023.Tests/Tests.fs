module Tests

open Xunit
open AdventOfCode.FSharp._2023.Days.Day01

[<Fact>]
let ``day01 part 01`` () = Assert.Equal(56042, day1Part1)

[<Fact>]
let ``day 01 part 02 `` () = Assert.Equal(55358, day1Part2)
