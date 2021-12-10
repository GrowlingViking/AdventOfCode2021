module SquidBingo

open System
open System.IO

// PART 1
let bingo = 
    
    let lines = File.ReadAllLines(@"C:\AdventOfCode2021\Data\Day04_Bingo.txt")
    
    // Convert lines into a list
    let list = lines |> Seq.toList

    let createBoard listOfLines = 
        let rec loop list linesOfNumbers = 
            match list with 
            | [] -> linesOfNumbers
            | (head: string) :: tail -> 
                let line = head.Split ' ' |> Array.toList |> List.filter (fun x -> x <> "")
                loop tail linesOfNumbers @ [line]
        loop listOfLines []

    let extractBingoNumbers inputList = 
        match inputList with 
        | (numbers: string) :: empty :: tail -> 
            let bingoNumbers = numbers.Split ',' |> Array.toList
            (bingoNumbers, tail)
        | _ -> ([], inputList)

    let extractBoards list =
        let rec loop list boards =
            match list with
            | line1 :: line2 :: line3 :: line4 :: line5 :: emptyLine :: tail ->
                let board = createBoard (line1 :: line2 :: line3 :: line4 :: line5 :: [])
                loop tail (boards @ [board])
            | _ -> boards
        loop list []

    let (bingoNumbers, listOfBoards) = extractBingoNumbers list
    let bingoBoards = extractBoards listOfBoards

    // let checkForWin board drawnNumbers = 
        

    let drawNumber boards drawnNumbers = 
        let rec loop boards drawnNumbers winningBoard = 
            match (boards, winningBoard) with
            | (_, [x]) -> x
            | ([], []) -> []
            | (head :: tail, []) -> 
                

    let play boards numbers = 
        let rec loop numbers boards drawnNumbers winningBoard =
            match (numbers, winningBoard) with
            | (_, [x]) -> x
            | (head :: tail, []) -> 
                let drawingNumbers = drawnNumbers @ [head]
                let winningBoard = drawNumber boards drawingNumbers
                loop tail boards drawingNumbers winningBoard
        loop numbers boards [] []
    0