module modularity

// discuss lists, partial functions, function composition first

let list = [1..100]

let rec sum list = 
 match list with
  | [] -> 0
  | head::tail -> head + sum(tail)
  
printf "%d" (sum(list))

let rec reduce f initial list = 
 match list with
  | [] -> initial
  | head::tail -> f head (reduce f initial tail)   

let add x y = x + y

let sum1 = reduce add 0

let mul = reduce (*) 1

// type inference 
let anytrue =  reduce (or) false

let anyfalse =  reduce (&&) true

let cons el list = el :: list

//let listcopy = reduce cons [] 

let doubleandcons el list = el*2 :: list

let listdouble = reduce doubleandcons []

let fAndCons f el list = f el :: list

let double x = 2 * x 

let listdouble1 = reduce (fAndCons double) []

let listdouble2 = reduce ( double >> cons) []

let listdouble3 = reduce ( (fun x -> x *2) >> cons) []

let map f = reduce (f >> cons) []

let summatrix (list:int list list) = sum(map sum list) 

let summatrix1   = (map sum ) >> sum



//By modularising a simple function (sum) as a
//combination of a “higher order function” and some simple arguments, we have
//arrived at a part (reduce) that can be used to write down many other functions
//on lists with no more programming effort

 
 