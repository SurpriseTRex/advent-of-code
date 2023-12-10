module Day02_Tests

open AdventOfCode.FSharp._2023.Days.Day02
open AdventOfCode.FSharp._2023.Modules.Files
open Xunit
open Faqt

[<Fact>]
let ``string to handful`` () =
    let result = "2 green" |> toHandfulOfCubes
    Assert.Equal(result, Hand(Green, 2))

    let result = "184 red" |> toHandfulOfCubes
    Assert.Equal(result, Hand(Red, 184))
    Assert.NotEqual(result, Hand(Red, 183))

    let result = "14 blue" |> toHandfulOfCubes
    Assert.Equal(result, Hand(Blue, 14))
    Assert.NotEqual(result, Hand(Red, 14))

[<Fact>]
let ``sets string to handfuls`` () =
    let result = " 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green" |> splitSetsIntoHands
    Assert.Equal(result, [ "3 blue"; "4 red"; "1 red"; "2 green"; "6 blue"; "2 green" ])

[<Fact>]
let ``get game id from game string``() =
    let result = "Game 15235" |> gameID
    Assert.Equal(15235, result)
    
[<Fact>]
let ``isHandPossible for a given hand``() =
    let maximums = [|Red, 1; Green, 4; Blue, 4|] |> Map.ofArray
    
    let notPossible = (Red, 4) |> isPossibleHand maximums
    let possible1 = (Green, 4) |> isPossibleHand maximums
    let possible2 = (Blue, 3) |> isPossibleHand maximums
    
    Assert.False notPossible
    Assert.True possible1
    Assert.True possible2
    
[<Fact>]
let ``isPossibleGame``() =
    let maximums = [|Red, 5; Green, 4; Blue, 4|] |> Map.ofArray
    
    let possible =
        [|Red, 1; Green, 3; Green, 4; Blue, 4; Blue, 1; Red, 4|]
        |> arePossibleHands maximums
        
    let impossible =
        [|Red, 1; Green, 3; Green, 4; Blue, 4; Blue, 1; Red, 6|]
        |> arePossibleHands maximums
    
    Assert.True possible
    Assert.False impossible

[<Fact>]
let ``parseRow``() =
    let result =
        "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue"
        |> parseRow
    
    Assert.Equal((2, [|Blue, 1; Green, 2; Green, 3; Blue, 4; Red, 1; Green, 1; Blue, 1|]), result)
    
[<Fact>]
let ``processPart1 e1``() =
    let maximum = [|Red, 12; Green, 13; Blue, 14|] |> Map.ofArray
    let result = e1 |> processPart1 maximum
    
    Assert.Equal(8, result)
    
[<Fact>]
let ``processPart1 input``() =
    let maximum = [|Red, 12; Green, 13; Blue, 14|] |> Map.ofArray
    let result = (Inputs.read 2) |> processPart1 maximum
    
    Assert.Equal(2810, result)
    
[<Fact>]
let ``processPart2 e2``() =
    let result = (Examples.read 2 1) |> processPart2
    
    Assert.Equal(2286, result)

[<Fact>]
let ``processPart2 input``() =
    let result = (Inputs.read 2) |> processPart2
    
    Assert.Equal(69110, result)