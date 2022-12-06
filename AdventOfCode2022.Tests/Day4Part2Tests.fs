module AdventOfCode2022.Tests.Day4Part2Tests

open System.IO
open Xunit
open FsUnit
open AdventOfCode2022.Day4.CampCleanupPart2

[<Fact>]
let ``Can calculate correct sum of assigment pairs with any overlap`` () =
   ([5; 6; 7], [7; 8; 9]) |> hasSomeRangeOverlap |> should equal true
   ([2; 3; 4], [6; 7; 8]) |> hasSomeRangeOverlap |> should equal false
   ([6], [4; 5; 6]) |> hasSomeRangeOverlap |> should equal true
   
[<Fact>]
let ``Can find the correct sum of elf assignments with some overlap`` () =
   File.ReadAllText("TestData/Day4/day4-small.txt") |> findAnyOverlappingAssigmentPairsSum |> should equal 4
