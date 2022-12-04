namespace AdventOfCode2022.Day2

open System

module RockPaperScissorsPart1 =
    
    type Selection =
        Rock
        | Paper
        | Scissors
        
    type Outcome = Won | Lost | Draw

    let decryptCode = function
        | "A" | "X" -> Rock
        | "B" | "Y" -> Paper
        | "C" | "Z" -> Scissors
        | code -> raise (ArgumentException($"Code {code} is not supported"))
    
    let scoreMySelection = function
        | Rock -> 1
        | Paper -> 2
        | Scissors -> 3
        
    let scoreRoundOutcome = function
        | Won -> 6
        | Draw -> 3
        | Lost -> 0
        
    let determineRoundOutcome = function
        | Rock, Paper -> Won
        | Rock, Scissors -> Lost
        | Scissors, Rock -> Won
        | Scissors, Paper -> Lost
        | Paper, Scissors -> Won
        | Paper, Rock -> Lost
        | _ -> Draw
        
    let scoreRound (input : string) =
        let decrypted = input.Split(" ", StringSplitOptions.RemoveEmptyEntries) |> Array.map decryptCode
        let elfSelection, mySelection = decrypted[0], decrypted[1]
        let score = determineRoundOutcome (elfSelection, mySelection) |> scoreRoundOutcome
        score + scoreMySelection mySelection
        
    let scoreTournament (strategyGuide : string) =
        strategyGuide.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
        |> Array.map scoreRound
        |> Array.sum
    
    let prettyPrint sum =
        printfn $"The result of the elf rock-paper-scissors tournament after guessing how strategy guide works is : {sum}"
        