module rover4

type Direction = { left : Direction;
                   right : Direction;
                   delta : int*int }

let rec N = { left = W; right = E; delta = 0,1 } 
and W = { left = S; right = N; delta = -1,0 } 
and E = { left = N; right = S; delta = 1,0 }
and S = { left = E; right = W; delta = 0,-1 }

let move (x,y,d) =
    let (dx,dy) = d.delta
    (x+dx,y+dy,d)
   
let turnRight (x,y,d) =
    let nextDir = d.right
    (x,y,nextDir)
   
let turnLeft (x,y,d) =
    let nextDir = d.left
    (x,y,nextDir)
   

let commandMap = Map.ofList ['M',move;'R',turnRight;'L',turnLeft]

// converts a list of string into a list of functions by looking into the commandMap which is a Map of char -> function.
let commands = "LMRRMMLLRLM" |> List.ofSeq |> List.map (fun x -> commandMap.[x])

// f is a single composite function composed of all the series of move and turn functions., >> is the function composition operator,
// it kind of concatenates together a list of functions into a single function..which will be evaluated in series..
// i.e f(g(h(x))) is same as (f >> g >> h) (x)

let f = commands |> List.reduce (>>)

let initPos = (1,1,N)

let finalPos = f(initPos)
