module patterns
// talk abt pattern matching n static compile time safety

let square x = x*x
let double x = x*2

let squareAndDouble x = (x*x)*2

let squareAndDouble1 x = double(square(x))


// why both?
let squareAndDouble2 x = x |> square |> double

let squareAndDouble3  = square >> double

//(f . g) h = f (g h)