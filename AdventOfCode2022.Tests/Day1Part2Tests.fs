module AdventOfCode2022.Tests.Day1Part2Tests

open Xunit
open FsUnit
open System.IO
open AdventOfCode2022.Day1.ElfCaloriesPart2

[<Fact>]
let ``Correctly calculate the sum of the top three calories carriers`` () =
    File.ReadAllText("TestData/Day1/day1-small.txt") |> topThreeCaloriesSum |> should equal 45000

