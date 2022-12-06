namespace AdventOfCode2022.Day5

open System

module SupplyStacks =

    let populateEmptyStacks (procedureDrawing : string) = procedureDrawing.Replace("    ", "[ ]")
        
    let splitInputInstructions (instructions : string) =
        let instructionLines = instructions.Split(Environment.NewLine)
        Seq.filter (fun (l : string) -> l.Contains('[')) instructionLines |> List.ofSeq,
        Seq.filter (fun (l : string) -> l.StartsWith("move")) instructionLines |> List.ofSeq
        
    let addCargo (cargo : string option) (columnNumber : int) map =
        match Map.tryFind columnNumber map, cargo with
        | None, Some cargoChar -> Map.add columnNumber [cargoChar] map
        | Some stack, Some cargoChar ->  Map.add columnNumber (stack @ [cargoChar]) map
        | _ -> map
    
    let addCargoColumnLine (cargoItems : string option list) map =
        List.fold (fun (map, column) cargo -> addCargo cargo column map, column + 1) (map, 1) cargoItems
        |> fst
        
    let buildStartingCargoPosition (cargoColumnPosition : string list) =
        let cargoColumnsWithEmptyIndicators = List.map populateEmptyStacks cargoColumnPosition
        let mapCargoLineToOption (cargoLine : string) =
            cargoLine.Split('[', StringSplitOptions.RemoveEmptyEntries)
            |> Seq.map (fun (c : string) -> Seq.head c |> string)
            |> Seq.map (fun maybeCargoItem -> if String.IsNullOrWhiteSpace(maybeCargoItem) then None else Some maybeCargoItem)
            |> List.ofSeq
        List.fold (fun map cargoLine -> addCargoColumnLine (mapCargoLineToOption cargoLine) map) Map.empty cargoColumnsWithEmptyIndicators 
        
    type MoveInstruction =
        { From: int
          To: int
          Quantity : int }
        
    let rec moveCargo moveInstruction cargoMap =
        match moveInstruction.Quantity, Map.tryFind moveInstruction.From cargoMap with
        | n, Some (sourceCargoItem::restSource) when n > 0 ->
            let targetCargoColumn = Map.find moveInstruction.To cargoMap
            let newTargetColumn = sourceCargoItem::targetCargoColumn
            let newCargoMap =
                Map.add moveInstruction.To newTargetColumn cargoMap
                |> Map.add moveInstruction.From restSource
            moveCargo {moveInstruction with Quantity = moveInstruction.Quantity - 1} newCargoMap
        | _ -> cargoMap
        
    let parseMoveLines (moveInstructionLines : string list) =
        List.map (fun (l : string) -> l.Split(' ')) moveInstructionLines
        |> List.map (fun instructionArray ->
            {
                From = Int32.Parse(instructionArray[3])
                To = Int32.Parse(instructionArray[5])
                Quantity = Int32.Parse(instructionArray[1])
            })
        
    let getTopCargoString (movedCargo : Map<int, string list>) =
       Map.values movedCargo
       |> Seq.map Seq.head
       |> String.Concat
        
    let rearrangeCargo input =
        let startingCargoPositionLines, moveLines = splitInputInstructions input
        let startingCargoMap = buildStartingCargoPosition startingCargoPositionLines
        let moveInstructions = parseMoveLines moveLines
        let movedCargoMap = List.fold (fun map instruction -> moveCargo instruction map) startingCargoMap moveInstructions
        getTopCargoString movedCargoMap
        
    
    let prettyPrint cargoComboStr =
        printfn $"After rearranging all the cargo, the cargo items on top form the following string: {cargoComboStr}"
        
        
                
            
            
        
        
        