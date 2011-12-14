module partials

// two ways of calling functions
let add a b = a + b
let add1 (a,b) = a + b

// we can define a new fn 
let inc a = add a 1

// what happens if i do the below? shudnt it give a compile time error?
let a = add 1

//curried functionadd
let inc1 = add 1



let s = add 1 12
let s1 = (add 1) 12

//applied add to just one argument
let f = add 1
let s3 = f 12



let l1 = List.map inc [1..10]
let inc2 a = add 1
let l2 = List.map (add 1) [1..10]

// The technique of calling a function with fewer arguments than it
// expects (resulting in a new function that expects the rest of the arguments) is called "partial application"

//all functions have exactly one argument.

