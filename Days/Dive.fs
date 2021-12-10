module Dive

open System
open System.IO

// PART1
let diveInstructions = 
    let lines = File.ReadAllLines(@"C:\AdventOfCode2021\Data\Day02_Dive.txt")
    
    // Convert lines into a list
    let list = lines |> Seq.toList

    let (|Prefix|_|) (p:string) (s:string) = 
        if s.StartsWith(p) then 
            Some(s.Substring(p.Length))
        else 
            None

    let parseMovement (movement:string) (up:int) (down:int) (forward:int) = 
        match movement with
        | Prefix "up " rest -> 
            let num = Int32.Parse rest
            up + num, down, forward
        | Prefix "down " rest -> 
            let num = Int32.Parse rest
            up, down + num, forward
        | Prefix "forward " rest -> 
            let num = Int32.Parse rest
            up, down, forward + num
        | _ -> up, down, forward

    let calculateDepth list = 
        let rec loop list up down forward =
            match list with
            | head :: tail -> 
                let (a, b, c) = parseMovement head up down forward
                loop tail a b c
            | [] -> up, down, forward
        loop list 0 0 0

    let (up, down, forward) = calculateDepth list
    (down - up) * forward

// PART 2 
let correctDiveInstructions = 
    let lines = File.ReadAllLines(@"C:\AdventOfCode2021\Data\Day02_Dive.txt")
    
    // Convert lines into a list
    let list = lines |> Seq.toList

    let (|Prefix|_|) (p:string) (s:string) = 
        if s.StartsWith(p) then 
            Some(s.Substring(p.Length))
        else 
            None

    let parseMovement (movement:string) (aim:int) (depth:int) (forward:int) = 
        match movement with
        | Prefix "up " rest -> 
            let num = Int32.Parse rest
            aim - num, depth, forward
        | Prefix "down " rest -> 
            let num = Int32.Parse rest
            aim + num, depth, forward
        | Prefix "forward " rest -> 
            let num = Int32.Parse rest
            aim, depth + (aim * num), forward + num
        | _ -> aim, depth, forward

    let calculateDepth list = 
        let rec loop list aim depth forward =
            match list with
            | head :: tail -> 
                let (a, b, c) = parseMovement head aim depth forward
                loop tail a b c
            | [] -> aim, depth, forward
        loop list 0 0 0

    let (aim, depth, forward) = calculateDepth list
    depth * forward