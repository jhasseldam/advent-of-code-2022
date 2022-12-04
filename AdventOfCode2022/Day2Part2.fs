namespace AdventOfCode2022.Day2

open System
open RockPaperScissorsPart1

module RockPaperScissorsPart2 =
    
    let decryptElfSelection = function
        | "A" -> Rock
        | "B" -> Paper
        | "C" -> Scissors
        | code -> raise (ArgumentException $"{code} not supported as valid elf selection")
    
    let decryptExpectedRoundOutcome = function
        | "X" -> Lost
        | "Y" -> Draw
        | "Z" -> Won
        | code -> raise (ArgumentException $"{code} not supported as valid round outcome")
        
    let determineMySelection elfSelection expectedOutcome =
        match elfSelection, expectedOutcome with
        | Rock, Won -> Paper
        | Rock, Lost -> Scissors
        | Paper, Won -> Scissors
        | Paper, Lost -> Rock
        | Scissors, Won -> Rock
        | Scissors, Lost -> Paper
        | _, Draw -> elfSelection
    
    let scoreRound (round : string) =
        let result = round.Split(" ", StringSplitOptions.RemoveEmptyEntries)
        let elfSelection = decryptElfSelection result[0]
        let roundOutcome = decryptExpectedRoundOutcome result[1]
        let mySelection = determineMySelection elfSelection roundOutcome
        scoreRoundOutcome roundOutcome + scoreMySelection mySelection
    
    let scoreTournament (strategyGuide : string) =
        strategyGuide.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
        |> Array.map scoreRound
        |> Array.sum
        
    let prettyPrint sum =
        printfn $"The result of the elf rock-paper-scissors tournament if using strategy guide with elf help : {sum}"
