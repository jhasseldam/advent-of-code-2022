module AdventOfCode2022.Tests.Day5Part1Tests

open System.IO
open Xunit
open FsUnit
open AdventOfCode2022.Day5.SupplyStacks

[<Fact>]
let ``Add cargo to the correct cargo lines`` () =
   let cargoMap =
       Map.empty
       |> addCargoColumnLine [Some "N"; None; Some "C"; None; None; None; None; Some "Q"; None] 
       |> addCargoColumnLine [Some "S"; Some "Q"; Some "V"; Some "P"; Some "S"; Some "F"; Some "D"; Some "R"; Some "S"]
       
   Map.find 1 cargoMap |> should equal ['N'; 'S']
   Map.find 2 cargoMap |> should equal ['Q']
   Map.find 3 cargoMap |> should equal ['C'; 'V']
   Map.find 4 cargoMap |> should equal ['P']
   Map.find 5 cargoMap |> should equal ['S']
   Map.find 6 cargoMap |> should equal ['F']
   Map.find 7 cargoMap |> should equal ['D']
   Map.find 8 cargoMap |> should equal ['Q'; 'R']
   Map.find 9 cargoMap |> should equal ['S']

[<Fact>]
let ``Can successfully carry out move cargo instructions`` () =
   let cargoMap =
       Map.empty
       |> Map.add 1 ['N'; 'S']
       |> Map.add 2 ['Q']
       |> Map.add 3 ['C'; 'V']
       |> Map.add 4 ['P']
       |> Map.add 5 ['S']
       |> Map.add 6 ['F']
       |> Map.add 7 ['D']
       |> Map.add 8 ['Q'; 'R']
       |> Map.add 9 ['S']
   let moveInstruction = { From = 1; To = 7; Quantity = 2 }
   let expected =
       Map.empty
       |> Map.add 1 []
       |> Map.add 2 ['Q']
       |> Map.add 3 ['C'; 'V']
       |> Map.add 4 ['P']
       |> Map.add 5 ['S']
       |> Map.add 6 ['F']
       |> Map.add 7 ['S'; 'N'; 'D']
       |> Map.add 8 ['Q'; 'R']
       |> Map.add 9 ['S']
   moveCargo moveInstruction cargoMap |> should equal expected
   
[<Fact>]
let ``Can correctly rearrange cargo and end up with correct string from top cargo items`` () =
    File.ReadAllText("TestData/Day5/day5-small.txt") |> rearrangeCargo |> should equal "CMZ"
    
    
   
   

