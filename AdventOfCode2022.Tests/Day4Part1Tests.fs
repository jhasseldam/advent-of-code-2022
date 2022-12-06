module AdventOfCode2022.Tests.Day4Part1Tests

open System.IO
open Xunit
open FsUnit
open AdventOfCode2022.Day4.CampCleanupPart1

[<Fact>]
let ``Can correctly split assignment pairs into ranges`` () =
   "2-4,6-8" |> createCollectionsFromAssignmentPair |> should equal ([2; 3; 4], [6; 7; 8])
   "2-3,4-5" |> createCollectionsFromAssignmentPair |> should equal ([2; 3], [4; 5])
   "5-7,7-9" |> createCollectionsFromAssignmentPair |> should equal ([5; 6; 7], [7; 8; 9])
   
[<Fact>]
let ``Can identify when an assignment range covers the other`` () =
   ([5; 6; 7], [7; 8; 9]) |> completeRangeOverlap |> should equal false
   ([6], [4; 5; 6]) |> completeRangeOverlap |> should equal true
   
[<Fact>]
let ``Can find the correct amount of assignment pairs which fully cover each other`` () =
   File.ReadAllText("TestData/Day4/day4-small.txt") |> findCompleteOverlappingAssignmentPairsSum |> should equal 2
