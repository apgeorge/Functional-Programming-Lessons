module tails
//Stack overflow
let test1 = [ 1 .. 10000 ] 
let test2 = [ 1 .. 100000 ] 

let rec sumList(lst) =
    match lst with
    | [] -> 0 
    | hd::tl -> hd + sumList(tl) 

sumList(test1) 

sumList(test2) 

// Tail recursion
let rec foo(arg) =
    if (arg = 1000) then true
    else foo(arg + 1)