module declarative
open System

let nums = [1 .. 100]
let evenList = List.filter (fun i -> i % 2 = 0) nums    
List.iter (fun i -> printf "i = %d," i) evenList

//Another way to print a list
let evenNumStr = List.map (fun (x:int) -> String.Format("i = {0}",x))  evenList
printf "%s" (String.Join(",", (Array.ofList evenNumStr)))



